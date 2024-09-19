# 4.1
See generated lexer and parser in FunPar.fs and FunLex.fs

# 4.2 
Write more example programs in the functional language, and test
them in the same way as in Exercise 4.1:
• Compute the sum of the numbers from 1000 down to 1. Do this by defining a function
sum n that computes the sum n+(n−1)+· · ·+2+1. (Use straightforward
summation, no clever tricks).

let sum x = if x = 1 then 1 else x + sum(x - 1) in sum 1000 end

• Compute the number 3^8, that is, 3 raised to the power 8. Again, use a recursive
function.

let pow x = if x = 0 then 1 else 3 * pow(x - 1) in pow 8 end

• Compute 3^0 + 3^1 + · · · + 3^10 + 3^11, using a recursive function (or two, if you
prefer).

//TODO pow bliver ikke fundet, så vi skal ændre måden vi anvender pow i powsum...

let powsum x = if x = 0 then 1 else let pow = if x = 0 then 1 else 3 * pow (x - 1) in (pow x) + powsum (x-1) end in powsum 11 end

• Compute 18 + 28 +· · ·+108, again using a recursive function (or two).




