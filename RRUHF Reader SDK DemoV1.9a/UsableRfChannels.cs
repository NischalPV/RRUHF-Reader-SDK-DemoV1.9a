using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRUHF_Reader_SDK_Demo
{
    public static class UsableRfChannels
    {
        public static UInt16[] GetRFChannels(string Region)
        {
            UInt16[] HK = { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, };
            UInt16[] TAIWAN = { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, };
            UInt16[] ETSI_LOWER = { 4, 7, 10, 13, };
            UInt16[] ETSI_UPPER = { 3, 6, 9, 12, };
            UInt16[] MALAYSIA = { 34, 35, 36, 37, 38, 39, 40, 41, };
            UInt16[] CHINA = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, };
            UInt16[] BRAZIL = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, };
            UInt16[] THAILAND = { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, };
            UInt16[] SINGAPORE = { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, };
            UInt16[] AUSTRALIA = { 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, };
            UInt16[] INDIA = { 1, 4, 7, 10, };
            UInt16[] URUGUAY = { 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, };
            UInt16[] VIETNAM = { 33, 34, 35, 36, 37, 38, 39, 40, };
            UInt16[] ISRAEL = { 28, };
            UInt16[] INDONESIA = { 37, 38, 39, 30, };
            UInt16[] NEW_ZEALAND = { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, };
            UInt16[] JAPAN2 = { 6, 12, 18, 24, };
            UInt16[] PERU = { 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, };
            UInt16[] RUSSIA = { 1, 2, 3, 4, };
            UInt16[] Chn = null;

            if (Region == "HK")
            {
                return(HK);
            }
            else if (Region == "TAIWAN")
            {
                return (TAIWAN);
            }
            else if (Region == "ETSI LOWER")
            {
                return (ETSI_LOWER);
            }
            else if (Region == "ETSI UPPER")
            {
                return (ETSI_UPPER);
            }
             else if (Region == "MALAYSIA")
            {
                return (MALAYSIA);
            }
            else if (Region == "CHINA")
            {
                return (CHINA);
            }
            else if (Region == "BRAZIL")
            {
                return (BRAZIL);
            }
            else if (Region == "THAILAND")
            {
                return (THAILAND);
            }
            else if (Region == "SINGAPORE")
            {
                return (TAIWAN);
            }
            else if (Region == "AUSTRALIA")
            {
                return (AUSTRALIA);
            }
            else if (Region == "INDIA")
            {
                return (INDIA);
            }
            else if (Region == "URUGUAY")
            {
                return (URUGUAY);
            }
            else if (Region == "VIETNAM")
            {
                return (VIETNAM);
            }
            else if (Region == "ISRAEL")
            {
                return (ISRAEL);
            }
            else if (Region == "INDONESIA")
            {
                return (INDONESIA);
            }
            else if (Region == "NEW ZEALAND")
            {
                return (NEW_ZEALAND);
            }
            else if (Region == "JAPAN2")
            {
                return (JAPAN2);
            }
            else if (Region == "PERU")
            {
                return (PERU);
            }
            else if (Region == "PERU")
            {
                return (PERU);
            }
            return (Chn);
        }
    }
}
