namespace ExampleAsyncAwait
{
    public class AsyncAwaitWorkClass
    {

        public AsyncAwaitWorkClass()
        {
        }

        #region Стандартные методы
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

        private int Calculate(object a)
        {
            Thread.Sleep(2000);
            return (int)a + (int)a;
        }

        #endregion

        #region Асинхронные методы

        public async void WritePlusAsync()
        {
            Task task = new Task(this.WritePlus);
            task.Start();
            await task;
        }

        public async void WriteMinusAsync()
        {
            await Task.Factory.StartNew(this.WriteMinus);
        }

        public async Task WritePlusTaskAsync() => await Task.Factory.StartNew(this.WritePlus);

        public async Task WriteMinusTaskAsync() => await Task.Factory.StartNew(this.WriteMinus);
        
        public async Task<int> CalculateAsync(int a)
        {
            return await Task<int>.Factory.StartNew(this.Calculate, a);
        }

        #endregion

    }
}