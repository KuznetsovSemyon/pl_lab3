using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pl_lab3
{
    internal class Token
    {
        public string? data;
        public int recipient;
        public int ttl;

        public Token(string message, int rec, int tockenTtl)
        {
            data = message;
            recipient = rec;
            ttl = tockenTtl;
        }
    }
}
