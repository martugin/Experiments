open System
open Microsoft.FSharp.Text.Lexing

open Ast
open Lexer
open Parser

/// Evaluate a factor
let rec getFun f=
    match f with
    | "cos" -> fun x -> Math.Cos(x)
    | "sin" -> fun x -> Math.Sin(x)
    | "abs" -> fun x -> Math.Abs(x)

and evalFactor factor =
    match factor with
    | Float x -> x
    | Integer x -> float x
    | ParenEx x -> evalExpr x
    | ApplyFun (f, x) -> getFun f (evalExpr x)

/// Evaluate a term
and evalTerm term =
    match term with
    | Times (term, fact)  -> (evalTerm term) * (evalFactor fact)
    | Divide (term, fact) -> (evalTerm term) / (evalFactor fact)
    | Factor fact         -> evalFactor fact

/// Evaluate an expression
and evalExpr expr =
    match expr with
    | Plus (expr, term)  -> (evalExpr expr) + (evalTerm term)
    | Minus (expr, term) -> (evalExpr expr) - (evalTerm term)
    | Term term          -> evalTerm term

/// Evaluate an equation
and evalEquation eq =
    match eq with
    | Equation expr -> evalExpr expr

printfn "Calculator"

let rec readAndProcess() =   
    printf ":"
    match Console.ReadLine() with
    | "quit" -> ()
    | expr ->
        try
            printfn "Lexing [%s]" expr
            let lexbuff = LexBuffer<char>.FromString(expr)
            
            printfn "Parsing..."
            let equation = Parser.start Lexer.tokenize lexbuff
            
            printfn "Evaluating Equation..."
            let result = evalEquation equation
            
            printfn "Result: %s" (result.ToString())
            
        with ex ->
            printfn "Unhandled Exception: %s" ex.Message

        readAndProcess()

readAndProcess()