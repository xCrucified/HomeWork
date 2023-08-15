using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Authors
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Surname}, {Country}";
        }
    }
}
