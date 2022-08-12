using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace NewMiner
{
    internal class Mutar
    {
        private static Mutex SYSTEM_MutEx;

        public static bool Get()
        {
            SYSTEM_MutEx = new Mutex(true, ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString(), out bool m); 
            return m;
        }
    }