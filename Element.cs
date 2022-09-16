using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalAnalyzer
{
    internal class Element
    {
        string identifier;
        string token;
        int number;

        public Element() { }
        
        public Element(string identifier, string token, int number) {
            this.identifier = identifier;
            this.token = token;
            this.number = number;
        }


        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}
