using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cal_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();
            //用死循环来控制用户多次使用
            while (true)
            {   //提示用户输入操作数
                Console.WriteLine("请输入两个数：");
                String result = Console.ReadLine();
                //用切割方法进行切割
                String[] shu = result.Split(' ');
                double m=0, n=0;
                int flag = 1;
                //提示用户输入操作符
                Console.WriteLine("请输入操作符以回车结束");
                char c = char.Parse(Console.ReadLine());
                try
                {
                    n = double.Parse(shu[0]);
                    m = double.Parse(shu[1]);
                }catch(Exception e){
                    Console.WriteLine("输入的数字格式错误！");
                    flag = 0;

                }
                int a, b;
                //强转为int
               a = (int)n;
               b = (int)m;
                //判断两个操作数是否相等
               if (cal.Equals(a, b))
               {
                   Console.WriteLine("两个操作数相等");
               }
               else
               {
                   Console.WriteLine("两个操作数不相等");
               }
               //进入判断
                if (flag != 0)
                {
                    switch (c)
                    {
                        case '+': Console.WriteLine(cal.add(n, m)); break;
                        case '-': Console.WriteLine(cal.sub(n, m)); break;
                        case '*': Console.WriteLine(cal.mul(n, m)); break;
                        case '/':
                            if (cal.div(n, m) == 0)
                            {
                                Console.WriteLine("除数不能为0"); break;
                            }
                            else
                            {
                                Console.WriteLine(cal.div(n, m)); break;
                            }
                    }
                }
                Console.WriteLine("是否要继续计算，y:是，n:退出");
                char d = char.Parse(Console.ReadLine());
                if (d == 'n')
                    break;
            }
            Console.WriteLine("退出成功！谢谢使用");
        }
    }
   

    class Calculator
    {
        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="n">被加数</param>
        /// <param name="m">加数</param>
        /// <returns></returns>
        public double add(double n,double m){
            return n + m;
    }
        /// <summary>
        /// 减法运算
        /// </summary>
        /// <param name="n">被减数</param>
        /// <param name="m">减数</param>
        /// <returns></returns>
        public double sub(double n, double m)
        {
            return n - m;
        }
        /// <summary>
        /// 乘法运算
        /// </summary>
        /// <param name="n">被乘数</param>
        /// <param name="m">乘数</param>
        /// <returns></returns>
        public double mul(double n, double m)
        {
            return n * m;
        }
        /// <summary>
        /// 除法运算
        /// </summary>
        /// <param name="n">被除数</param>
        /// <param name="m">除数</param>
        /// <returns></returns>
        public double div(double n, double m)
        {
            if (m == 0)
                return 0;
            else {
                double num = n / m;
                num = double.Parse(num.ToString("0.00"));
                return n / m;
            }
                
        }

        /// <summary>
        /// 重载equals方法
        /// </summary>
        /// <param name="obj1">第一个参数</param>
        /// <param name="obj2">第二个参数</param>
        /// <returns></returns>

        public bool Equals(int obj1, int obj2)
        {
            if (obj1 != obj2)
                return false;
            else
                return true;

        }

    }

}


