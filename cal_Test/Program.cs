using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace cal_Test
{
class Program
    {
        static void Main(string[] args)
        {
            char c;
            bool flag = true;
            while (flag)
            {

                calculater calculator = new calculater();
                //1.输入两个数
                Console.WriteLine("请输入两个操作数以空格结束：");
                String result = Console.ReadLine();
                //通过空格将两个操作数分开，用string数组接收
                String[] shu = result.Split(' ');
                Console.WriteLine("请输入操作符：");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "+": Console.WriteLine("运算结果为：" + calculator.add(shu[0], shu[1])); break;
                    case "-": Console.WriteLine("运算结果为：" + calculator.jian(shu[0], shu[1])); break;
                    case "*": Console.WriteLine("运算结果为：" + calculator.chen(shu[0], shu[1])); break;
                    case "/": Console.WriteLine("运算结果为：" + calculator.chu(shu[0], shu[1])); break;
                }
                Console.WriteLine("是否继续？（y或Y继续，n或N退出）");
                c = char.Parse(Console.ReadLine());
                if (c == 'n' || c == 'N')
                    flag = false;
            }
            Console.WriteLine("退出成功，欢迎下次使用");
        }
    }

    class calculater
    {
        public string add(string a, string b)
        {
            int m = 0, n = 0;
            string c, d, v;
            bool q = false, p = false;
            if (!(a.Contains("\"") || Regex.IsMatch(a, "[a-zA-Z]")))
            {
                m = int.Parse(a);
                q = true;
            }
            if (!(b.Contains("\"") || Regex.IsMatch(b, "[a-zA-Z]")))
            {
                n = int.Parse(b);
                p = true;
            }
            if (p && q)
            {
                v = (m + n).ToString();
            }
            else
            {
                v = a + b;
                v = v.Replace("\"", "");
            }
            return v;
        }

        public string jian(string a, string b)
        {
            int m = 0, n = 0;
            string c, d, v;
            bool q = false, p = false;
            if (!(a.Contains("\"") || Regex.IsMatch(a, "[a-zA-Z]")))
            {
                m = int.Parse(a);
                q = true;
            }
            if (!(b.Contains("\"") || Regex.IsMatch(b, "[a-zA-Z]")))
            {
                n = int.Parse(b);
                p = true;
            }
            if (p && q)
            {
                v = (m - n).ToString();
            }
            else
            {
                v = a.Replace(b, "").Replace("\"", "");
            }
            return v;
        }

        public string chen(string a, string b)
        {
            int m = 0, n = 0;
            m = int.Parse(a);
            n = int.Parse(b);
            return (m * n).ToString();
        }

        public string chu(string a, string b)
        {
            int m = 0, n = 0;
            m = int.Parse(a);
            n = int.Parse(b);
            if (n == 0)
                return "除数不能为0";
            else
                return (m / n).ToString();
        }
    }
}
