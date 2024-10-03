Compiling and loading the typed micro-ML evaluator (TypedFun/README.TXT)
------------------------------------------------------------------------

A. Loading evaluator and type checker for the explicitly typed language

   dotnet fsi TypedFun.fs

   open TypedFun;;

   // These typechecks should succeed:
   typeCheck (Prim("+", CstI 5, CstI 7));;
   typeCheck ex1;;

   // This typecheck should throw exception:
   typeCheck exErr1;;

   #q;;
   
Opgave 6.5
1 Letfun ("f", "x", CstI 1, Call (Var "f", Var "f"))
2 Letfun ("f", "g", Call (Var "g", Var "g"), Var "f")
3 Letfun
      ("f", "x", Letfun ("g", "y", Var "y", Call (Var "g", CstB false)),
       Call (Var "f", CstI 42))
4 Letfun
      ("f", "x",
       Letfun
         ("g", "y", If (CstB true, Var "y", Var "x"), Call (Var "g", CstB false)),
       Call (Var "f", CstI 42))
5 Letfun
      ("f", "x",
       Letfun
         ("g", "y", If (CstB true, Var "y", Var "x"), Call (Var "g", CstB false)),
       Call (Var "f", CstB true))

