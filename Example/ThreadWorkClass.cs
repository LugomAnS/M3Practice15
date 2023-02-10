namespace Example
{
    public class ThreadWorkClass
    {
        private static object o = new object();

        public ThreadWorkClass()
        {
        }

        public void WritePlus()
        {
            Console.WriteLine($"-->Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 40; i++)
            {
                Console.Write("+");
                Thread.Sleep(25);
            }

            Console.WriteLine($"<--Завершен поток поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void WriteMinus()
        {
            Console.WriteLine($"-->Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 30; i++)
            {
                Console.Write("-");
                Thread.Sleep(50);
            }

            Console.WriteLine($"<--Завершен поток поток №: {Thread.CurrentThread.ManagedThreadId}");
        }


        public void WritePlusWithLock()
        {
            Console.WriteLine($"-->Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            lock(o)
            {
                Console.WriteLine("---Работа с критической секцией, блокировка доступа");
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("+");
                    Thread.Sleep(25);
                }

            }
            Console.WriteLine("---Блокировка снята");

            Console.WriteLine($"<--Завершен поток поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void WriteMinusWithLock()
        {
            Console.WriteLine($"-->Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            lock (o)
            {
                Console.WriteLine("---Работа с критической секцией, блокировка доступа");
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-");
                    Thread.Sleep(50);
                }

            }
            Console.WriteLine("---Блокировка снята");

            Console.WriteLine($"<--Завершен поток поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}