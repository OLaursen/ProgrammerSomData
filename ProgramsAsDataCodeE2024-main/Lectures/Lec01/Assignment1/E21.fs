(*
    Exercise 2.1 Extend the expression language expr from Intcomp1.fs with
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