using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Books
    {
        public string Name { get; set; }
        public int Page { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Page}, {Author}";
        }
    }
}
