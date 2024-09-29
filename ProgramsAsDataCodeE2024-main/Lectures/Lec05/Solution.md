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


# 6.3

# 6.4

# 6.5