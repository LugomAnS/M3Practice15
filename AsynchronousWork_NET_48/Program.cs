using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Example_Net_48;

namespace AsynchronousWork_NET_48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main запущен в потоке - {Thread.CurrentThread.ManagedThreadId}");

            ThreadWorkClass testObject = new ThreadWorkClass();

            Action actionFirst = new Action(testObject.WritePlus);
            Action actionSecond = testObject.WriteMinus;

            actionFirst.BeginInvoke(null, null);
            actionSecond.BeginInvoke(null, null);

            Console.WriteLine("Через делегат потоки идут как Background, остановим вручную Main");
            Thread.Sleep(3000);

            Console.WriteLine("\nЗапускаем потоки и ждем их завершение");

            actionFirst.EndInvoke(actionFirst.BeginInvoke(null, null));

            Console.WriteLine("Управление вернулось в первичный поток, ждем теперь второй");

            actionSecond.EndInvoke(actionSecond.BeginInvoke(null, null));


            Console.WriteLine("\nРабота с критической секцией");

            actionFirst = testObject.WritePlusWithLock;
            actionSecond = testObject.WriteMinusWithLock;

            actionFirst.BeginInvoke(null, null);
            actionSecond.BeginInvoke(null, null);


            Console.WriteLine("Main завершен, --> Программа прервется без ожидания");

            Console.ReadKey(true);
        }
    }
}
