using System;

namespace Console_Application
{
    class Program    
    {
        public delegate int Num(int n1, int n2);
        static void Main(string[] args)
        {
            Console.WriteLine("Введите действие +,-,*,/");
            string n1 = Console.ReadLine();
            Console.WriteLine("Введите первое число");
            int num1  =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Num num;
            switch (n1)
            {
                case "+":
                    num = (c, n2) =>  c + n2; ;

                    int del = num (num1, num2);
                    Console.WriteLine("Ответ:{0}", del);
                    break;
                case "-":
                    num = (c, n2) => c - n2; ;

                    int del1 = num(num1, num2);
                    Console.WriteLine("Ответ:{0}", del1);
                    break;
                case "*":
                    num = (c, n2) => c * n2; ;

                    int del2 = num(num1, num2);
                    Console.WriteLine("Ответ:{0}", del2);
                    break;
                case "/":
                    num = (c, n2)  => n2 == 0 ? 0 : c / n2; ;

                    int del3 = num(num1, num2);
                    Console.WriteLine("Ответ:{0}", del3);
                    break;
                default:
                    Console.WriteLine("Нет такой операции");
                    break;
            }
            

                    

            }
    }
}
