using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedWineQuality
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var stream = new StreamReader(".\\"))
            using (var helper = new CsvHelper.CsvReader(stream))
            {

            }
        }
    }
}
