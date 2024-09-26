# 5.1
## A

## B

```Csharp
    static int[] merge(int[] xs, int[] ys)
    {
        int[] result = new int[xs.Length + ys.Length - 1];
        int xsI = 0;
        int ysI = 0;
    
        result = xs.Concat(ys).ToArray();
        Array.Sort(result);
        return result;
    }
```

# 5.7
*Extend the monomorphic type checker to deal with lists:*


# 6.1
"let add x = let f y = x+y in f end in add 2 5 end" :

Letfun("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"), Call (Call (Var "add", CstI 2), CstI 5))

let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end
Letfun ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"), Let ("addtwo", Call (Var "add", CstI 2), Call (Var "addtwo", CstI 5)))

let add x = let f y = x+y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end
Letfun("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"), Let ("addtwo", Call (Var "add", CstI 2), Let ("x", CstI 77, Call (Var "addtwo", CstI 5))))

let add x = let f y = x+y in f end in add 2 end

Letfun("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"), Call (Var "add", CstI 2))

# 6.2

# 6.3

# 6.4

# 6.5