using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject
{
    public class Token
    {
        public string Tag;
        public string Literal;

        // C# allows developers to create an expression bodied member with only 
        // the expression and without the curly braces or explicit returns.
        public string ToJsonString() => "{ tag: \"" + Tag + "\", literal: \"" + Literal + "\"}";
    }
}
