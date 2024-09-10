

(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)
let sinstrToInt = function
  | SCstI i -> [0;i]
  | SVar i  -> [1;i]
  | SAdd    -> [2]
  | SSub    -> [3]
  | SMul    -> [4]
  | SPop    -> [5]
  | SSwap   -> [6]

let assemble (inss : sinstr list) : int list =
    let rec assemble' inss acc =
        match inss with
        | [] -> List.rev acc
        | SCstI i :: rest -> assemble' rest (i :: 0 :: acc)
        | SVar i :: rest -> assemble' rest (i :: 1 :: acc)
        | SAdd :: rest -> assemble' rest ( 2 :: acc)
        | SSub :: rest -> assemble' rest (3 :: acc)
        | SMul :: rest -> assemble' rest (4 :: acc)
        | SPop :: rest -> assemble' rest (5 :: acc)
        | SSwap :: rest -> assemble' rest (6 :: acc)
    assemble' inss []

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;
