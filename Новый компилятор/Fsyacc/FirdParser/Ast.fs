namespace Ast
open System

type Result = String * Int32 * String    

and Factor =
    | GetResult of Result    
    | ParenEx of Expr

and Term =
    | Times  of Term * Factor
    | Divide of Term * Factor
    | Factor of Factor

and Expr =
    | Plus  of Expr * Term
    | Minus of Expr * Term
    | Term  of Term
    
and Equation =
    | Equation of Expr