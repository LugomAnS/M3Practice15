using Example;

namespace ThreadWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Метод Main запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");

            ThreadWorkClass testObject = new ThreadWorkClass();

            Thread[] threads = new Thread[2];

            threads[0] = new Thread(testObject.WritePlus);
            threads[1] = new Thread(testObject.WriteMinus);
            
            Console.WriteLine("Main ждет завершения выполнения вторичных потоков");
            Console.WriteLine("Потоки выполняются одновременно");

            threads[0].Start();
            threads[1].Start();
            threads[0].Join();
            threads[1].Join();          

            Console.WriteLine("Возобновление Main");

            threads[0] = new Thread(testObject.WritePlusWithLock);
            threads[1] = new Thread(testObject.WriteMinusWithLock);

            Console.WriteLine("Запускаются потоки с блокировкой выполнения при работе" +
                " с разделяемым ресурсом");

            threads[0].Start();
            threads[1].Start();

            Console.WriteLine("Main завершен");

        }
    }
}