module e21

(*
    Exercise 2.1 
    Extend the expression language expr from Intcomp1.fs with
    multiple sequential let-bindings, such as this (in concrete syntax):
    let x1 = 5+7 x2 = x1*2 in x1+x2 end
    To evaluate this, the right-hand side expression 5+7 must be evaluated and bound
    to x1, and then x1*2 must be evaluated and bound to x2, after which the let-body
    x1+x2 is evaluated.
    The new abstract syntax for expr might be
    type expr =
    | CstI of int
    | Var of string
    | Let of (string * expr) list * expr (* CHANGED *)
    | Prim of string * expr * expr

    28 2 Interpreters and Compilers
    so that the Let constructor takes a list of bindings, where a binding is a pair of a
    variable name and an expression. The example above would be represented as:
    Let ([("x1", ...); ("x2", ...)], Prim("+", Var "x1", Var "x2"))
    Revise the eval interpreter from Intcomp1.fs to work for the expr language
    extended with multiple sequential let-bindings.
*)

(*
    erhs = expression right hand side
    ebody = expression body
*)


type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr //Changed from Let of string * expr * ecpr
  | Prim of string * expr * expr;;

//Test expressions
let e1 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))
//let x1 = 5+7 x2 = x1 * 2 in x1*x2 
let e3 = Let([("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))
let e2 = Let([("z", CstI 17)], Prim("+", Var "z", Var "z"));;

let e4 = Let([("x1", Prim("+", CstI 5, CstI 7))], Prim("+", Var "x1", Var "y"))
let e5 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", Var "z"))], Prim("+", Var "x1", Var "x2"))
let e6 = Let([("x1", CstI 10)], Prim("*", Var "x1", Var "z"))

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i              -> i
    | Var x               -> lookup env x 
    | Let(lst, ebody) -> //Changes start here
        let rec aux lst env = 
            match lst with
                | [] ->  env
                | (x, erhs) :: xs -> 
                    let xval = eval erhs env
                    let env1 = (x, xval) :: env
                    aux xs env1
        eval ebody (aux lst env) //Changes end here
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;

(*
    Exercise 2.2
    Revise the function freevars : expr -> string list to
    work for the language as extended in Exercise 2.1. Note that the example expression
    in the beginning of Exercise 2.1 has no free variables, but let x1 = x1+7 in
    x1+8 end has the free variable x1, because the variable x1 is bound only in the
    body (x1+8), not in the right-hand side (x1+7), of its own binding. There are
    programming languages where a variable can be used in the right-hand side of its
    own binding, but ours is not such a language.
*)
let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;
let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;
let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

let ls = [5; 7; 1];;
let ls2 = [5; 3; 2];;
//let e5 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", Var "z"))], Prim("+", Var "x1", Var "x2"))
let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(lst, ebody) -> //changes start here 
            let rec aux lst freeV bound =
                match lst with
                | (x, erhs) :: xs -> 
                        let newBound = x :: bound
                        aux xs (union (minus (freevars erhs, bound), freeV)) newBound //Check om x er i body, hvis ja så gør ikek noget hvis nej så tilføj til liste (freevars) 
                | [] -> 
                    minus (freevars ebody, bound) @ freeV
            aux lst [] [] //changes end here
          //union (freevars erhs, minus (freevars ebody, [x]))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;


type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;

(* Map variable name to variable index at compile-time *)

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

(* Compiling from expr to texpr *)
//let e5 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", Var "z"))], Prim("+", Var "x1", Var "x2"))
let e10 = Let([("x", CstI 10); ("y", Prim("+", Var "x", CstI 5))], Prim("*", Var "x", Var "y"))

let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x -> TVar (getindex cenv x)
    | Let(lst, ebody) ->
        // Recursively process all bindings in lst
        let rec aux bindings cenv =
            match bindings with
            | [] -> tcomp ebody cenv  // Compile the body with the updated environment bindings
            | (x, erhs) :: xs -> 
                let compRight = tcomp erhs cenv  // Compile the right-hand side of the current binding
                let newCenv = x :: cenv  // Add the new variable to the environment
                TLet(compRight, aux xs newCenv)  // Compile the remaining bindings
        aux lst cenv
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv)

(* Evaluation of target expressions with variable indexes.  The
   run-time environment renv is a list of variable values (ints).  *)

let rec teval (e : texpr) (renv : int list) : int =
    match e with
    | TCstI i -> i
    | TVar n  -> List.item n renv
    | TLet(erhs, ebody) -> 
      let xval = teval erhs renv
      let renv1 = xval :: renv 
      teval ebody renv1 
    | TPrim("+", e1, e2) -> teval e1 renv + teval e2 renv
    | TPrim("*", e1, e2) -> teval e1 renv * teval e2 renv
    | TPrim("-", e1, e2) -> teval e1 renv - teval e2 renv
    | TPrim _            -> failwith "unknown primitive";;