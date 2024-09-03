module Intro2

(* Association lists map object language variables to their values *)
//New code

type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr
  | Pow of aexpr * aexpr
  | Div of aexpr * aexpr;;

let ae1 = Sub(Var "v", Add(Var "W", Var "z"));;

let ae2 = Mul(CstI 2, ae1);;

let ae3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")));;

let ae4 = Mul(CstI 2, Add(Var "x", Var "y"));;

let ae5 = Sub(Var "x", CstI 34);;

let ae6 = Add(CstI 0, Var "x");;

let ae7 = Mul(CstI 1, Var "x");;

let ae8 = Sub(Var "x", Var "x");;

let ae9 = Add(CstI 1, Mul(CstI 2, CstI 3 ));

let ae10 = Mul(CstI 0, Add(CstI 2, CstI 3 ));;

let ae11 = Add(CstI 1, Mul(CstI 0, CstI 3 ));

let ae12 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0));;



let rec fmt (e : aexpr) : string =
    match e with
    | CstI 0 -> ""
    | CstI i -> string i
    | Var x  -> x
    | Add(e1, e2) -> "(" + fmt e1 + " + " + fmt e2 + ")"
    | Mul(e1, e2) -> "(" + fmt e1 + " * " + fmt e2 + ")"
    | Sub(e1, e2) -> "(" + fmt e1 + " - " + fmt e2 + ")"
    | Pow(e1, e2) -> "(" + fmt e1 + " ^ " + fmt e2 + ")"
    | Div(e1, e2) -> "(" + fmt e1 + " / " + fmt e2 + ")"
    ;;

let rec simplifyOnce (e : aexpr) : aexpr =
    match e with
    | Add(CstI 0, e2) -> simplifyOnce e2
    | Add(e1, CstI 0) -> simplifyOnce e1
    | Sub(e1, CstI 0) -> simplifyOnce e1
    | Sub(e1, e2) when e1 = e2 -> CstI 0
    | Mul(CstI 0, _) -> CstI 0
    | Mul(_, CstI 0) -> CstI 0
    | Mul(CstI 1, e2) -> simplifyOnce e2
    | Mul(e1, CstI 1) -> simplifyOnce e1
    | Add(e1, e2) -> Add(simplifyOnce e1, simplifyOnce e2)
    | Mul(e1, e2) -> Mul(simplifyOnce e1, simplifyOnce e2)
    | Sub(e1, e2) -> Sub(simplifyOnce e1, simplifyOnce e2)
    | Div(e1, e2) -> Div(simplifyOnce e1, simplifyOnce e2)
    | Pow(_, CstI 0) -> CstI 1
    | Pow(e1, CstI 1) -> simplifyOnce e1
    | _ -> e

let rec simplify (e : aexpr) : aexpr =
    let simplified = simplifyOnce e
    //Check if there were any changes
    if simplified = e then e // Return if there were no changes
    else simplify simplified // Continue simplifying if there were changes

let rec differentiate (expr : aexpr) : aexpr =
    match expr with
    | CstI i -> CstI 0
    | Var x -> CstI 1
    | Add(e1,e2) -> Add(differentiate (e1), differentiate(e2))
    | Mul(e1,e2) -> Add(Mul(differentiate(e1), e2), Mul(e1, differentiate(e2)))
    | Sub(e1,e2) -> Sub(differentiate (e1), differentiate(e2))
    | Pow(e1,e2) -> Mul(e2, Pow(e1, Sub(e2, CstI 1)))
    | _ -> expr;;

let difTest = differentiate(Add(Add(Pow(Var "x", CstI 2), Mul(CstI 3, Var "x")), CstI 3));;