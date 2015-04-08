namespace Ast
open System

type Factor =
    | Int of String    
    | Real of String    
    | ParenEx of Expr
    | ApplyFun of String * ParamList 

and Ident =
    | Ident of String

and ParamList =
    | Sep of ParamList * Expr
    | ParamExpr of Expr 

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