using System;
using System.Collections.Generic;
using System.Text;

//C# 6 introduced static class inclusion
using static System.Console;

namespace CSharpProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shouldCatchException = false;

            //const string validInput = "jump jump run jump";

            const string invalidInput = "run read swim";
            var output = "";
            var rest = invalidInput;

            var tokens = new List<Token>();

            var verbLexer = new VerbLexer();
            var whitespaceLexer = new WhitespaceLexer();

            Token result = null;

            do
            {
                try
                {
                    // In C# 6, 'identifierA ?? identifierB' operator is shorthand for 'if(identifierA != null) identifierA; else identifierB'
                    result = verbLexer.Lex(rest, out rest)
                             ?? whitespaceLexer.Lex(rest, out rest);

                    // in C# 6, 'the identifier?.property' feature is shorthand for 'if(identifier != null) identifier.property'
                    // it can be stringed.  ie: 'identifier?.property?.anotherProperty?.soOn?.andSoForth'
                    // if any element along the way is null, then it short-circuits the command.
                    output += result?.Literal;

                    // The 'Delegate', 'Action', and 'Func' classes allow the use of anonymous functions and lambda expressions.
                    Action exceptionLambda = () =>
                    {
                        shouldCatchException = true;
                        throw new Exception("The input contains unlexable data.");
                    };
                    Action addResultToTree = () => { tokens.Add(result); };
                    
                    var actionToPerform = result == null ? exceptionLambda : addResultToTree;

                    actionToPerform();

                }
                // C# 6 allows for exception filters.  Any predicate can be used, even if it doesn't have anything to do with the exception.
                catch (Exception exception) when (shouldCatchException)
                {
                    WriteLine(exception.Message);
                }
            }
            while (result != null && rest.Length > 0);

            if (result == null)
            {
                // Console.WriteLine is not required, because System.Console was included
                WriteLine("Could not lex entire input.");
                WriteLine("Unlexed section:");
                WriteLine(rest);
            }

            WriteLine("Lexed section:");
            WriteLine(output);
            WriteLine("Tokens:");
            WriteLine(DisplayTokens(tokens));

            // Console.ReadLine is not required, because System.Console was included
            ReadLine();
        }

        private static string DisplayTokens(List<Token> tokens)
        {
            // Stringbuilders in C# help to prevent unneccessary copying of strings when concatenating them.
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var lexResult in tokens)
            {
                var jsonResult = lexResult.ToJsonString();

                // C# 6 introduced string interpolation.  It is syntactic sugar that can be used in place of String.Format.
                stringBuilder.Append($"{jsonResult},\n");
            }
            var result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }
    }
}
