(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)


//New code

type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

let ae1 = Sub(Var "v", Add(Var "W", Var "z"));;

let ae2 = Mul(CstI 2, ae1);;

let ae3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")));;

let ae4 = Mul(CstI 2, Add(Var "x", Var "y"));;

let ae5 = Sub(Var "x", CstI 34);;

let ae6 = Add(CstI 0, Var "x");;

let ae7 = Mul(CstI 1, Var "x");;

let ae8 = Sub(Var "x", Var "x");;

let rec fmt (e : aexpr) : string =
    match e with
    | CstI i -> string i
    | Var x  -> x
    | Add(e1, e2) -> "(" + fmt e1 + " + " + fmt e2 + ")"
    | Mul(e1, e2) -> "(" + fmt e1 + " * " + fmt e2 + ")"
    | Sub(e1, e2) -> "(" + fmt e1 + " - " + fmt e2 + ")";;

let rec simplify (e : aexpr) : string =
    match e with
    | Add(CstI 0, e2) -> simplify e2
    | Add(e1, CstI 0) -> simplify e1
    | Sub(e1, CstI 0) -> simplify e1
    | Sub(e1, e2) when e1 = e2 -> "0"
    | Mul(CstI 0, e2) -> "0"
    | Mul(e1, CstI 0) -> "0"
    | Mul(CstI 1, e2) -> simplify e2
    | Mul(e1, CstI 1) -> simplify e1
    | _ -> fmt e;;

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  //New code
  | If of expr * expr * expr;;
  
let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

//New code
let e4 = Prim("==", Prim("Max", CstI 7, CstI 10), Prim("Min", CstI 13, CstI 10));;

let e5 = Prim("==", Prim("Max", CstI 7, CstI 9), Prim("Min", CstI 13, CstI 10));;

let e6 = If(Var "a", CstI 11, CstI 22) 

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(op, e1, e2) ->
        let i1 = eval e1 env
        let i2 = eval e2 env
        match op with
        | "-"     -> i1 - i2
        | "*"     -> i1 * i2
        | "+"     -> i1 + i2
        //New code
        | "=="    -> if i1 = i2 then 1 else 0
        | "Max"   -> 
            if i1 < i2 then i2
            elif i2 < i1 then i1
            else i1
        | "Min"     -> 
            if i1 < i2 then i1
            elif i2 < i1 then i2
            else i1
        | _    -> failwith "unknown operator"
    | If (e1, e2, e3) -> 
        let i1 = eval e1 env
        let i2 = eval e2 env
        let i3 = eval e3 env    
        match i1 with 
            | 0 -> i3
            | _ -> i2
    | Prim _            -> failwith "unknown primitive";;
    

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;
