namespace Example
{
    public class ThreadWorkClass
    {
        // разделяемый ресурс
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
                Thread.Sleep(50);
            }

            Console.WriteLine($"<--Завершен поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void WriteMinus()
        {
            Console.WriteLine($"-->Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 0; i < 30; i++)
            {
                Console.Write("-");
                Thread.Sleep(80);
            }

            Console.WriteLine($"<--Завершен поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void WritePlusWithLock()
        {
            Console.WriteLine($"**>Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            lock(o)
            {
                Console.WriteLine($"***Работа с критической секцией, блокировка доступа, поток - {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(20);
                for (int i = 0; i < 40; i++)
                {
                    Console.Write("+");
                    Thread.Sleep(50);
                }
                Console.WriteLine($"\n***Блокировка снята, поток - {Thread.CurrentThread.ManagedThreadId}");
            }

            Console.WriteLine($"<**Завершен поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

        public void WriteMinusWithLock()
        {
            Console.WriteLine($"**>Запущен поток №: {Thread.CurrentThread.ManagedThreadId}");

            lock (o)
            {
                Thread.Sleep(20);
                Console.WriteLine($"***Работа с критической секцией, блокировка доступа, поток - {Thread.CurrentThread.ManagedThreadId}");
                for (int i = 0; i < 30; i++)
                {
                    Console.Write("-");
                    Thread.Sleep(80);
                }
                Console.WriteLine($"\n***Блокировка снята, поток - {Thread.CurrentThread.ManagedThreadId}");
            }

            Console.WriteLine($"<**Завершен поток №: {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}