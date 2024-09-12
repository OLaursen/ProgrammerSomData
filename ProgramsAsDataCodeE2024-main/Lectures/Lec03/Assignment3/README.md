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
          /               |                \                     \
      LET NAME           IN               EXP                   EXP
         |                                 |                     |
       NAME Z                         CSTINT 17        ____________________
                                                      /          |          \
                                                    EXP        PLUS        EXP
                                                     |                       |
                                                   NAME Z            _________________
                                                                    /        |        \
                                                                  EXP     TIMES      EXP
                                                                   |                  |
                                                                CSTINT 2           CSTINT 3        
```


