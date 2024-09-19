# 4.1
See generated lexer and parser in FunPar.fs and FunLex.fs

# 4.2 
Write more example programs in the functional language, and test
them in the same way as in Exercise 4.1:
• Compute the sum of the numbers from 1000 down to 1. Do this by defining a function
sum n that computes the sum n+(n−1)+· · ·+2+1. (Use straightforward
summation, no clever tricks).
• Compute the number 38, that is, 3 raised to the power 8. Again, use a recursive
function.
• Compute 30 + 31 + · · · + 310 + 311, using a recursive function (or two, if you
prefer).
• Compute 18 + 28 +· · ·+108, again using a recursive function (or two).


let f n acc = if n = 0 then acc else f ( n - 1 ) ( acc + n )