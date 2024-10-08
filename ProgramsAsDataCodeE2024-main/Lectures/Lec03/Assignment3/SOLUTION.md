# Exercise 3.3

Write out the rightmost derivation of the string below from the expression
grammar at the end of Sect. 3.6.5, corresponding to ExprPar.fsy. Take note
of the sequence of grammar rules (A–I) used.

```
    let z = (17) in z + 2 * 3 end EOF
```

```
    LET z EQ CSTINT 17 IN z PLUS CSTINT 2 TIMES CSTINT 3 END
    
    Main =>
    Expr EOF => 
    Let Name z EQ Expr IN Expr END EOF => 
    Let Name z EQ Expr IN Expr Plus Expr END EOF =>  
    Let Name z EQ Expr IN Expr Plus Expr Times Expr END EOF => 
    Let Name z EQ Expr IN Expr Plus Expr Times CSTINT 3 END EOF => 
    Let Name z EQ Expr IN Expr Plus CSTINT 2 Times CSTINT 3 END EOF => 
    Let Name z EQ Expr IN Name z Plus CSTINT 2 Times CSTINT 3 END EOF => 
    Let Name z EQ CSTINT 17 IN Name z Plus CSTINT 2 Times CSTINT 3 END EOF =>
    
```
# Exercise 3.4
Draw the above derivation as a tree.

```
                            __________________________ MAIN ____________________________
                          /                                                             \                          
           _____________ EXP ______________ _____________________                       EOF
          /               |                \          \          \
      LET NAME           EQ               EXP         IN         EXP
         |                                 |                     |
       NAME Z                          CSTINT 17       ____________________
                                                      /          |          \
                                                    EXP        PLUS        EXP
                                                     |                       |
                                                   NAME Z            _________________
                                                                    /        |        \
                                                                  EXP     TIMES      EXP
                                                                   |                  |
                                                                CSTINT 2           CSTINT 3        
```

# Exercise 3.5
Get expr.zip from the book homepage and unpack it. Using a
command prompt, generate:

(1) the lexer and
(2) the parser for expressions by running fslex and fsyacc; 
(3) load the expression abstract syntax, the lexer and parser modules, and the expression interpreter and compilers, into an interactive F# session (fsharpi): 

fslex --unicode ExprLex.fsl
fsyacc --module ExprPar ExprPar.fsy
fsharpi -r FSharp.PowerPack.dll Absyn.fs ExprPar.fs ExprLex.fs ˆ
Parse.fs
Now try the parser on several example expressions, both well-formed and ill-formed
ones, such as these, and some of your own invention:
```
open Parse;;
fromString "1 + 2 * 3";;
fromString "1 - 2 - 3";;
fromString "1 + -2";;
fromString "x++";;
fromString "1 + 1.2";;
fromString "1 + ";;
fromString "let z = (17) in z + 2 * 3 end";;
fromString "let z = 17) in z + 2 * 3 end";;
fromString "let in = (17) in z + 2 * 3 end";;
fromString "1 + let x=5 in let y=7+x in y+y end + x end";;

```

# Exercise 3.6
Use the expression parser from Parse.fs and the compiler scomp
(from expressions to stack machine instructions) and the associated datatypes from
Expr.fs, to define a function compString : string -> sinstr list
that parses a string as an expression and compiles it to stack machine code.

Look at the function in E3_6.fs
# Exercise 3.7
Extend the expression language abstract syntax and the lexer and
parser specifications with conditional expressions. The abstract syntax should be
If(e1, e2, e3), so modify file Absyn.fs as well as ExprLex.fsl and file
ExprPar.fsy. The concrete syntax may be the keyword-laden F#/ML-style:
if e1 then e2 else e3
or the more light-weight C/C++/Java/C#-style:
e1 ? e2 : e3



