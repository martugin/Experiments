// This project type requires the F# PowerPack at http://fsharppowerpack.codeplex.com/releases
// Learn more about F# at http://fsharp.net
// Original project template by Jomo Fisher based on work of Brian McNamara, Don Syme and Matt Valerio
// This posting is provided "AS IS" with no warranties, and confers no rights.

open System
open Microsoft.FSharp.Text.Lexing
open System.Collections.Generic;
open DAO;

open Ast
open Lexer
open Parser

/// Evaluate a factor
let rec evalFactor factor =
    match factor with
    | Int x   -> x    
    | Real x   -> x    
    | ParenEx x -> evalExpr x
    | ApplyFun (id, ls) -> (evalList ls ) + ";" + id

and evalList ls=
    match ls with
    | Sep (l, x) -> (evalList l) + ";" + (evalExpr x)
    | ParamExpr x -> evalExpr x

/// Evaluate a term
and evalTerm term =
    match term with
    | Times (term, fact)  -> (evalTerm term) + ";" + (evalFactor fact) + ";*" 
    | Divide (term, fact) -> (evalTerm term) + ";" + (evalFactor fact) + ";/"
    | Factor fact         -> evalFactor fact

/// Evaluate an expression
and evalExpr expr =
    match expr with
    | Plus (expr, term)  -> (evalExpr expr) + ";" + (evalTerm term) + ";+"
    | Minus (expr, term) -> (evalExpr expr) + ";" + (evalTerm term) + ";-"
    | Term term          -> evalTerm term

/// Evaluate an equation
and evalEquation eq =
    match eq with
    | Equation expr -> evalExpr expr

let rec readAndProcess() =
    let en=new DAO.DBEngineClass();
    let cdb = en.OpenDatabase("db1.mdb"); 
    let rs = cdb.OpenRecordset("T1");    
    rs.MoveFirst();
    while (rs.EOF = false) do    
        let f=rs.Fields.["a1"].Value.ToString()                
        Console.WriteLine(f)
        let lexbuff = LexBuffer<char>.FromString(f)
        let g=Lexer.tokenize lexbuff
        while lexbuff.IsPastEndOfStream=false do
            Console.Write(lexbuff.Lexeme)  
            Console.WriteLine(" " + lexbuff.StartPos.Column.ToString() + " " + lexbuff.LexemeLength.ToString())
            Lexer.tokenize lexbuff
        try                    
            let equation = Parser.start Lexer.tokenize lexbuff            
            let result = evalEquation equation            
            printfn "Result: %s" (result)    
        with ex ->
            let pos = lexbuff.EndPos            
            Console.WriteLine(lexbuff.Lexeme)
            printfn "Error near line %d, character %d\n" pos.Line pos.Column            
            
        rs.MoveNext()

printfn "Calculator"
readAndProcess()

