// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | PLUS  -> 9 
  | MINUS  -> 10 
  | TIMES  -> 11 
  | DIV  -> 12 
  | MOD  -> 13 
  | ELSE  -> 14 
  | END  -> 15 
  | FALSE  -> 16 
  | IF  -> 17 
  | IN  -> 18 
  | LET  -> 19 
  | NOT  -> 20 
  | THEN  -> 21 
  | TRUE  -> 22 
  | CSTBOOL _ -> 23 
  | NAME _ -> 24 
  | CSTINT _ -> 25 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_TIMES 
  | 12 -> TOKEN_DIV 
  | 13 -> TOKEN_MOD 
  | 14 -> TOKEN_ELSE 
  | 15 -> TOKEN_END 
  | 16 -> TOKEN_FALSE 
  | 17 -> TOKEN_IF 
  | 18 -> TOKEN_IN 
  | 19 -> TOKEN_LET 
  | 20 -> TOKEN_NOT 
  | 21 -> TOKEN_THEN 
  | 22 -> TOKEN_TRUE 
  | 23 -> TOKEN_CSTBOOL 
  | 24 -> TOKEN_NAME 
  | 25 -> TOKEN_CSTINT 
  | 28 -> TOKEN_end_of_input
  | 26 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_AtExpr 
    | 18 -> NONTERM_AtExpr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AppExpr 
    | 23 -> NONTERM_AppExpr 
    | 24 -> NONTERM_Const 
    | 25 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 28 
let _fsyacc_tagOfErrorTerminal = 26

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;21us;65535us;0us;2us;6us;7us;8us;9us;10us;11us;12us;13us;30us;14us;31us;15us;32us;16us;33us;17us;34us;18us;35us;19us;36us;20us;37us;21us;38us;22us;39us;23us;40us;24us;45us;25us;46us;26us;49us;27us;50us;28us;52us;29us;23us;65535us;0us;4us;4us;54us;5us;55us;6us;4us;8us;4us;10us;4us;12us;4us;30us;4us;31us;4us;32us;4us;33us;4us;34us;4us;35us;4us;36us;4us;37us;4us;38us;4us;39us;4us;40us;4us;45us;4us;46us;4us;49us;4us;50us;4us;52us;4us;21us;65535us;0us;5us;6us;5us;8us;5us;10us;5us;12us;5us;30us;5us;31us;5us;32us;5us;33us;5us;34us;5us;35us;5us;36us;5us;37us;5us;38us;5us;39us;5us;40us;5us;45us;5us;46us;5us;49us;5us;50us;5us;52us;5us;23us;65535us;0us;41us;4us;41us;5us;41us;6us;41us;8us;41us;10us;41us;12us;41us;30us;41us;31us;41us;32us;41us;33us;41us;34us;41us;35us;41us;36us;41us;37us;41us;38us;41us;39us;41us;40us;41us;45us;41us;46us;41us;49us;41us;50us;41us;52us;41us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;25us;49us;71us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;12us;1us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;1us;1us;2us;2us;22us;2us;3us;23us;1us;4us;12us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;1us;4us;12us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;1us;4us;12us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;1us;5us;12us;5us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;12us;6us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;12us;6us;7us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;12us;6us;7us;8us;8us;9us;10us;11us;12us;13us;14us;15us;16us;12us;6us;7us;8us;9us;9us;10us;11us;12us;13us;14us;15us;16us;12us;6us;7us;8us;9us;10us;10us;11us;12us;13us;14us;15us;16us;12us;6us;7us;8us;9us;10us;11us;11us;12us;13us;14us;15us;16us;12us;6us;7us;8us;9us;10us;11us;12us;12us;13us;14us;15us;16us;12us;6us;7us;8us;9us;10us;11us;12us;13us;13us;14us;15us;16us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;14us;15us;16us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;15us;16us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;16us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;19us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;19us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;20us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;20us;12us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;21us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;2us;19us;20us;2us;19us;20us;1us;19us;1us;19us;1us;19us;1us;20us;1us;20us;1us;20us;1us;20us;1us;21us;1us;21us;1us;22us;1us;23us;1us;24us;1us;25us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;17us;19us;22us;25us;27us;40us;42us;55us;57us;70us;72us;85us;98us;111us;124us;137us;150us;163us;176us;189us;202us;215us;228us;241us;254us;267us;280us;293us;295us;297us;299us;301us;303us;305us;307us;309us;311us;313us;315us;317us;319us;322us;325us;327us;329us;331us;333us;335us;337us;339us;341us;343us;345us;347us;349us;|]
let _fsyacc_action_rows = 58
let _fsyacc_actionTableElements = [|7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;0us;49152us;12us;32768us;0us;3us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;0us;16385us;5us;16386us;1us;52us;19us;43us;23us;57us;24us;42us;25us;56us;5us;16387us;1us;52us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;21us;8us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;14us;10us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;11us;16388us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;3us;16389us;11us;32us;12us;33us;13us;34us;3us;16390us;11us;32us;12us;33us;13us;34us;3us;16391us;11us;32us;12us;33us;13us;34us;0us;16392us;0us;16393us;0us;16394us;9us;16395us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;9us;16396us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;5us;16397us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;5us;16398us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;5us;16399us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;5us;16400us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;18us;46us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;15us;47us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;18us;50us;12us;32768us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;15us;51us;12us;32768us;2us;53us;3us;35us;4us;36us;5us;37us;6us;38us;7us;39us;8us;40us;9us;30us;10us;31us;11us;32us;12us;33us;13us;34us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;0us;16401us;0us;16402us;1us;32768us;24us;44us;2us;32768us;3us;45us;24us;48us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;0us;16403us;1us;32768us;3us;49us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;0us;16404us;7us;32768us;1us;52us;10us;12us;17us;6us;19us;43us;23us;57us;24us;42us;25us;56us;0us;16405us;0us;16406us;0us;16407us;0us;16408us;0us;16409us;|]
let _fsyacc_actionTableRowOffsets = [|0us;8us;9us;22us;23us;29us;35us;43us;56us;64us;77us;85us;97us;105us;109us;113us;117us;118us;119us;120us;130us;140us;146us;152us;158us;164us;177us;190us;203us;216us;229us;237us;245us;253us;261us;269us;277us;285us;293us;301us;309us;317us;318us;319us;321us;324us;332us;340us;341us;343us;351us;359us;360us;368us;369us;370us;371us;372us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;1us;1us;7us;8us;3us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;3us;3us;3us;3us;3us;4us;4us;5us;5us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16401us;16402us;65535us;65535us;65535us;65535us;16403us;65535us;65535us;65535us;16404us;65535us;16405us;16406us;16407us;16408us;16409us;|]
let _fsyacc_reductions = lazy [|
# 250 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 259 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 270 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 281 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 292 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 305 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 316 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 328 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 340 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 352 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 364 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 376 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 388 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 400 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 412 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 424 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 436 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 448 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               _1                     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 459 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               Var _1                 
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 470 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 483 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 497 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               _2                     
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 508 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 64 "FunPar.fsy"
                 : Absyn.expr));
# 520 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 65 "FunPar.fsy"
                 : Absyn.expr));
# 532 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 69 "FunPar.fsy"
                 : Absyn.expr));
# 543 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
|]
# 555 "FunPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 29;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _
