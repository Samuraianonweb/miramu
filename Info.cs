using System.Management;

namespace NewMiner
{
    internal class Info
    {
        public static void Get()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string video = (string)queryObj["Caption"];
                    string video_nvd = NVD(video);
                    string video_amd = AMD(video);
                    if (video_nvd.Contains("Other"))
                    {
                        if (video_amd.Contains("Other"))
                        {
                            Properties.Settings.Default.gpu = "Other";
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.gpu = video_amd;
                            Properties.Settings.Default.Save();
                            break;
                        }                     
                    }
                    else
                    {
                        Properties.Settings.Default.gpu = video_nvd;
                        Properties.Settings.Default.Save();
                        break;
                    }
                }
            }
            catch { }
        }
        static string AMD(string video)
        {
            if (video.Contains("470"))
            {
                return "RX470";
            }
            else if (video.Contains("480"))
            {
                return "RX480";
            }
            else if (video.Contains("5600"))
            {
                return "RX5600XT";
            }
            else if (video.Contains("570"))
            {
                return "RX570-RX5700";
            }
            else if (video.Contains("580"))
            {
                return "RX580";
            }
            else if (video.Contains("590"))
            {
                return "RX590";
            }
            else if (video.Contains("6800"))
            {
                return "RX6800-6800XT";
            }
            else if (video.Contains("Vega") & video.Contains("56"))
            {
                return "Vega56";
            }
            else if (video.Contains("Vega") & video.Contains("64"))
            {
                return "Vega64";
            }
            return "Other";
        }
        static string NVD(string video)
        {
            if (video.Contains("1050"))
            {
                return "1050-1050ti";
            }
            else if (video.Contains("1060"))
            {
                return "1060-1060ti";
            }
            else if (video.Contains("1070"))
            {
                return "1070-1070ti";
            }
            else if (video.Contains("1080"))
            {
                return "1080-1080ti";
            }
            else if (video.Contains("1660"))
            {
                return "1660-1660ti";
            }
            else if (video.Contains("2060"))
            {
                return "2060-2060ti";
            }
            else if (video.Contains("2070"))
            {
                return "2070-2070S";
            }
            else if (video.Contains("2080"))
            {
                return "2080-2080ti";
            }
            else if (video.Contains("3060"))
            {
                return "3060-3060ti";
            }
            else if (video.Contains("3070"))
            {
                return "3070";
            }
            else if (video.Contains("3080"))
            {
                return "3080";
            }
            else if (video.Contains("3090"))
            {
                return "3090";
            }
            else if (video.Contains("1650"))
            {
                return "1060";
            }
            else if (video.Contains("1030"))
            {
                return "1030";
            }
            return "Other";
        }
    }
}