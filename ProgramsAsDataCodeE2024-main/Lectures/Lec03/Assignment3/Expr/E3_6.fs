module compString

open Absyn
open Parse
open Expr
open ExprPar
open ExprLex

let compString (str : string) : Expr.sinstr list =
    scomp (fromString str) [];;