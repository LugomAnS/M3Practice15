using ExampleAsyncAwait;

namespace AsyncAwaitWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main запущен в потоке - {Thread.CurrentThread.ManagedThreadId}");
            AsyncAwaitWorkClass testObject = new AsyncAwaitWorkClass();

            testObject.WritePlusAsync();
            testObject.WriteMinusAsync();

            Console.WriteLine("Потоки идут в background, вручную держим Main");

            Thread.Sleep(3000);

            Console.WriteLine($"\nПоследовательный запуск задач");

            Task taskPlus = testObject.WritePlusTaskAsync();
            taskPlus.ContinueWith(t => testObject.WriteMinusTaskAsync());

            Thread.Sleep(5500);

            Console.WriteLine("\nПроизводим расчеты и ждем результат");

            Task<int> taskCalculate = testObject.CalculateAsync(5);

            while (!taskCalculate.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }

            Console.WriteLine($"\nРезультат вычислений {taskCalculate.Result}");

        }
    }
}