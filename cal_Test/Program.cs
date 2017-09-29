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
            char c;
            bool flag = true;
            while (flag)
            {

                Calculator calculator = new Calculator();
                //1.输入两个数
                Console.WriteLine("请输入两个操作数以空格结束：");
                String result = Console.ReadLine();
                //通过空格将两个操作数分开，用string数组接收
                String[] shu = result.Split(' ');
                calculator.A = shu[0];
                calculator.B = shu[1];
                Console.WriteLine("请输入操作符：");
                string op = Console.ReadLine();
                Console.WriteLine("运算结果为：" + calculator.Calculate(op));
                Console.WriteLine("是否继续？（y或Y继续，n或N退出）");
                c = char.Parse(Console.ReadLine());
                if (c == 'n' || c == 'N')
                    flag = false;
            }
            Console.WriteLine("退出成功，欢迎下次使用");
        }
    }
    class Calculator
    {
        int _a, _b;//为数字的数据成员
        bool _statusA = true, _statusB = true;//标记是否都是数字
        string _c, _d;//当为字符串时用这俩数据接收
        public string A//将不同类型的操作数用异常判断而分开
        {
            set
            {
                try
                {
                    _a = int.Parse(value);
                }
                catch (FormatException e)
                {//标记false证明不是int型，是string型
                    _statusA = false;
                    //用string接收操作数
                    _c = value;
                }
            }
        }
        public string B
        {
            set
            {
                try
                {
                    _b = int.Parse(value);
                }
                catch (FormatException e)
                {
                    _statusB = false;
                    _d = value;
                }
            }
        }

        public string Calculate(string op)
        {
            switch (op)
            {
                case "+":
                    if (_statusA && _statusB)
                    {
                        return (_a + _b) + "";
                    }
                    else if (_statusA && !_statusB)
                    {
                        _c = _a.ToString();
                        //将”替换为空，进行字符串连接
                        return (_c + _d).Replace("\"", "");
                    }
                    else if (!_statusA && _statusB)
                    {
                        _d = _b.ToString();
                        return (_c + _d).Replace("\"", "");
                    }
                    else
                    {
                        return (_c + _d).Replace("\"", "");
                    }
                case "-":
                    if (_statusA && _statusB)
                    {
                        //为了统一将结果都统一为字符串
                        return (_a - _b) + "";
                    }
                    else if (_statusA && !_statusB)
                    {
                        _c = _a.ToString();
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                    else if (!_statusA && _statusB)
                    {
                        _d = _b.ToString();
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                    else
                    {
                        return (_c.Replace(_d, "")).Replace("\"", "");
                    }
                case "*":
                    return (_a * _b) + "";
                case "/":
                    if (_b == 0)
                    {
                        return "运算出错：除数不能为0！";
                    }
                    else
                    {
                        return ((float)_a / (float)_b) + "";
                    }
                default:
                    return "输入的运算符错误！";
            }
        }
    }
} 



