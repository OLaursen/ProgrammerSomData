# 5.1
## A
```fsharp
    let merge (lists: int list * int list) : int list =
        let merged = fst lists @ snd lists
        List.sort(merged)
```
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
Check TypedFun/TypedFun.fs

# 6.1
"let add x = let f y = x+y in f end in add 2 5 end" :

let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end

## Is the third one as expected? 
```fsharp
    let add x = let f y = x+y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end
```

It evaluates as expected, because we can ignore x = 77 due to it being irrelevant in the evaluation.
We can then see the following flow in the evaluation:
addtwo 5 -> add 2 + 5 -> 7. 

## Explain the result of the last one

```fsharp
   let add x = let f y = x+y in f end in add 2 end
   
   // result
    Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])

```
We can see that it's missing an variable(y in f y = x+y) to complete the closure, which is why it returns the closure. 

# 6.2
Look at HigherFun Eval, FunPar.fsy and FunLex.fsl


# 6.3
Check FunLex.fsl and FunPar.fsy

# 6.4
#TODO oliie
# 6.5
## Part 1

inferType (fromString "let f x = 1 in f f end");;          
val it: string = "int"

inferType (fromString "let f g = g g in f end");;
System.Exception: type error: circularity
_The exception is thrown because g gets g as an argument, and therefore tries to define g as both a function
and a variable._ 

inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"

inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
System.Exception: type error: bool and int
_The output of g is either a bool or int, which means the return type can't be correctly typed._ 

inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"

## Part 2
### bool -> bool

let f x = if x then true else false in f end

### int -> int

let f x = x+x in f end

### int -> int -> int

let f x = let g y = x+y in g end in f end

### 'a -> 'b -> 'a 

let f x = let g y = let h z = z in h x end in g end in f end

### 'a -> 'b -> 'b 

let f x = let g y = y in g end in f end

         f            g             h
### ('a -> 'b) -> ('b -> c) -> ('a -> 'c)

let f x =
    let h z =
        let g y = 
            x (z y)
        in g end
    in h end 
in f end

### 'a -> 'b
let f x = f x in f end

### 'a