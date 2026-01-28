using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRUHF_Reader_SDK_Demo
{
    public class Helpers
    {
        public static byte[] StringToHexArray(string HexString)
        {
            byte[] array = null;

            try
            {
                string text = HexString.Replace(" ", "");
                List<string> list = new List<string>();
                for (int i = 0; i < text.Length; i += 2)
                {
                    list.Add(text.Substring(i, 2));
                }
                array = new byte[list.Count];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = (byte)Convert.ToInt32(list[j], 16);
                }
            }
            catch
            {
                Console.WriteLine("Please Use HEX words!");
            }

            return (array);
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string TimeStampStr(byte[] TimeStamp)
        {
            string sTimeStamp = string.Empty;
            
            string s1 = TimeStamp[0].ToString();
            if(s1.Length < 2) { s1 = '0' + s1; }

            string s2 = TimeStamp[1].ToString();
            if (s2.Length < 2) { s2 = '0' + s2; }

            string s3 = TimeStamp[2].ToString();
            if (s3.Length < 2) { s3 = '0' + s3; }

            sTimeStamp = s1 + s2 + s3;

            return (sTimeStamp);
        }
    }
}
