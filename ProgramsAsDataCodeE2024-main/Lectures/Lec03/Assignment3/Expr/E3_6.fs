module compString

open Absyn
open Parse
open Expr

let compString (str : string) : sinstr list =
    scomp (fromString str) [];;