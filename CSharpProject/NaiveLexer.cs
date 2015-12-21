using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject
{
    public class NaiveLexer
    {
        // C# 6 introduced an auto-property initialization feature, which allows developers
        // to initialize properties without using a private set or the need for a local
        // variable.
        public string Tag { set; get; } = "base";

        // C# supports instantiation during declaration this way too.
        public List<string> AcceptedStrings = new List<string>();

        // C# supports 'out' parameters.
        public Token Lex(string input, out string rest)
        {
            Token result = null;

            rest = input;

            // C# supports linq statements
            var literal = AcceptedStrings.Where(input.StartsWith).FirstOrDefault();

            if (literal != null)
            {
                result = new Token() { Literal = literal, Tag = Tag };
                rest = input.Substring(result.Literal.Length, input.Length - result.Literal.Length);
            }
            return result;
        }
    }
}
