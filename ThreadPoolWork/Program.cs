using Example;

namespace ThreadPoolWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Метод Main запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");

            ThreadPoolWorkClass testObject = new ThreadPoolWorkClass();

            ThreadPool.QueueUserWorkItem(new WaitCallback(testObject.WritePlus));
            ThreadPool.QueueUserWorkItem(testObject.WriteMinus);

            Thread.Sleep(500);

            Console.WriteLine("Потоки из ThreadPool запускаются с IsBackGroud = true");
           
            Console.WriteLine("Main завершен");
        }
    }
}