using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject
{
    public class WhitespaceLexer: NaiveLexer
    {
        public WhitespaceLexer()
        {
            Tag = "whitespace";
            AcceptedStrings.Add(" ");
        }
    }
}
