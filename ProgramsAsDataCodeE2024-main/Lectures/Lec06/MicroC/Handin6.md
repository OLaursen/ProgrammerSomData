# Handin 6


## Exercise 7.1
```
Prog
    [Fundec
        (None, "main", [(TypI, "n")],
            Block
                [Stmt
                    (While
                        (Prim2 (">", Access (AccVar "n"), CstI 0),
                            Block
                                [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                                    Stmt
                                        (Expr
                                            (Assign
                                                (AccVar "n",
                                                    Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
                        Stmt (Expr (Prim1 ("printc", CstI 10)))])]

```
**Declarations**
* Fundec

**Statements**
* Block 
* While
* Expr

**Types**
* TypI

**Expressions**
* CstI
* Access
* Prim1
* Prim2

*We've run the interpreter with the following commands*
```
run (fromFile "ex1.c") [17]
run (fromFile "ex5.c") [4]
```

## Exercise 7.2

### i
See MicroC/ex72i.c

### ii
See MicroC/ex72ii.c

### iii
See MicroC/ex72iii.c
If we adjust the length of the freq array to lower than max, we can't track the frequencey on the amount of 
indexes expected, causing a segmantation fault.  

## Exercise 7.3
See MicroC/CPar.fsi and MicroC/CLex.fsl
Changes to incorporate for loops can be found at MicroC/:
* ex73i.c
* ex73ii.c
* ex73iii.c

## Exercise 7.4
See MicroC/Interp.fs

## Exercise 7.5
See MicroC/CPar.fsi and MicroC/CLex.fsl
