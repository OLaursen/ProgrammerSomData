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

# 6.1

# 6.2

# 6.3

# 6.4

# 6.5