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

//Test expressions
let e1 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))
//let x1 = 5+7 in x2 = x1 * 2 in x1*x2 
let e3 = Let([("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))
let e2 = Let([("z", CstI 17)], Prim("+", Var "z", Var "z"));;
type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr //Changed from Let of string * expr * ecpr
  | Prim of string * expr * expr;;

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
let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(lst, ebody) -> //changes start here 
            let rec aux lst freeV =
                match lst with
                | [] -> freeV
                | (x, erhs) :: xs -> 
                                    aux xs ((union (freevars erhs, minus(freevars ebody, [x]))) :: freeV)  //Check om x er i body, hvis ja så gør ikek noget hvis nej så tilføj til liste (freevars) 
            aux lst []
          //union (freevars erhs, minus (freevars ebody, [x]))
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;