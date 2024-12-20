# Assignment 7

## Ex 8.1

### Bytecode Ex3
```
24 19 1 5 main(n) 
LDARGS; CALL (1, "L1"); 

L1: 
   15 1 int i;
   INCSP 1;
   13 0 1 1 0 0 12 15 -1 i=0;
   GETBP; CSTI 1; ADD; CSTI 0; STI; INCSP -1
   16 43
   GOTO "L3"
L2:
   13 0 1 1 11 22 15 -1 print i;
   Label "L2"; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   13 0 1 1 13 0 1 1 11 0 1 1 12 15 -1 15 0 i=i+1;
   GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0;
L3
  13 0 1 1 11 13 0 0 1 11 7 i<n
  GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
  18 18 i<n = false;
  IFNZRO "L2"
  15 -1 21 0 return/break/endloop;
  INCSP -1; RET 0
   
25 EOF;
STOP;
```



### Bytecode Ex5
```
24 19 1 5  main(n);
LDARGS; CALL (1, "L1");

L1
    
    15 1 int r;
    INCSP 1;
    
    13 0 1 1 13 0 0 1 11 12 15 -1 r = n;
    GETBP; CSTI 1; ADD; GETBP; CSTI 0; ADD; LDI; STI; INCSP -1;
    
    15 1 int r;
    INCSP 1;
    
    13 0 0 1 11 13 0 2 1 19 2 57 square(n, &r);
    GETBP; CSTI 0; ADD; LDI; GETBP; CSTI 2; ADD; CALL (2, "L2");
    
    15 -1
    INCSP -1;
    
    13 0 2 1 11 22 15 -1 print r;
    GETBP; CSTI 2; ADD; LDI; PRINTI; INCSP -1;
    
    15 -1
    INCSP -1;
    
    13 0 1 1 11 22 15 -1 print r;
    GETBP; CSTI 2; ADD; LDI; PRINTI; INCSP -1;
    
    15 -1
    INCSP -1;
    21 0 return/break/endloop;
    RET 0;

L2:
    13 0 1 1 11 13 0 0 1 11 13 0 0 1 11 3 12 15 -1 15 0 21 1 *rp = i*i;
    GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1

25 EOF;
STOP;
```
We can see the block, or rather the scope changes the block introduces in the bytecode by observing the different positions of "r" on the stack. The block introduced "r" sits at bp+2 while the original "r" sits at b+1.

Also check ex3trace

## Ex 8.3
Check Comp.fs method Cexp
Example to test it out is seen in ex3modifed.c
```
    > compileToFile (fromFile "ex3modified.c") "ex3modified.out";;
    val it: Machine.instr list =
      [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
       CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
       PRINTI; INCSP -1; GETBP; CSTI 1; ADD; DUP; LDI; CSTI 1; ADD; STI; INCSP -1;
       INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
       IFNZRO "L2"; INCSP -1; RET 0]
       
       java Machine ex3modified.out 5
            0 1 2 3 4 
            Ran 0.009 seconds
```
## Ex 8.4 
Ex8.c is much slower because it first has to find the address of i, load the value of i, before it can decrement, check and store the value. 
This results in multiple extra instructions compared to prog1, that simply takes the value at the top of the stack, duplicates it, checks if it's 0, then decrements. 

## Ex 8.5
See solution in Cpar.fsy, Clex,fsl, Comp.fs, Absyn.fs and an example used to test can be seen in ex85.c.
