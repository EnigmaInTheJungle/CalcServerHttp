using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpCalcServer
{
    class Calculate
    {
        public static int Calc(string a, string b,string op)
        {
            int res = 0;

            int num1 = Convert.ToInt32(a);
            int num2 = Convert.ToInt32(b);

            switch(op)
            {
                case "+": res = num1 + num2; break;
                case "-": res = num1 - num2; break;
                case "*": res = num1 * num2; break;
                case "/": res = num1 / num2; break;
            }
            Console.WriteLine(res);
            return res;
        }
    }
}
