# 3.2

```
    (b*a?b*)*
``` 

# Hellolex Exercise

## Question 1
Regex involved: 
```
    ['0'-'9']
```
Each single digit character is converted to string. The semantic value is an integer as a string. 
It also uses wildcard, but only to declare exception.

## Question 2
### Which additional file(s) is generated during the process
* hello.fs
* hello.fsi
### How many states
* 3

## Question 3
Look at files hello.fs, hello.fsi

## Question 4
Look at files hello2.fs, hello2.fsi

## Question 5
Look at files hello3.fs, hello3.fsi

## Question 6
### Input: 34
Is recognized by the lexer because the regex can handle more than one digit, by using the '+' behind the '['0'-'9']' which ensures that it takes one or more digits. 

### Input: 34.24
Is recognized by the lexer because the regex can handle having more than one digit on both sides of a '.'.
### Input 34,34
Isn't entirely recognized by the lexer, as we haven't included ',' in the regex expression, leading to only the leading part of the number to be recognized. 


