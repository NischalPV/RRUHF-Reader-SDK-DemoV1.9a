using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRUHF_Reader_SDK_Demo
{
    public class RegionTable
    {
        string Name;
        UInt32 StartFreq;
        UInt32 Spacing;
        UInt32[] FreqTable;
        UInt16 ChannelCount;
        UInt16[] UsableChannel;
        bool RandomHop;

        public void Update(string name, uint startFreq, uint spacing, ushort channelCount, ushort[] usableChannel, bool randomHop)
        {
            Name = name;
            StartFreq = startFreq;
            Spacing = spacing;
            ChannelCount = channelCount;
            UsableChannel = usableChannel;
            RandomHop = randomHop;

            BuildTable();
        }

        public RegionTable()
        {
            Name = "INDIA";
            StartFreq = 865100;
            Spacing = 200;
            ChannelCount = 4;

            UInt16[] Chn = UsableRfChannels.GetRFChannels(Name);
            UsableChannel = Chn;
            RandomHop = false;
        }

        public void BuildTable()
        {
            UInt32[] fTable = new UInt32[ChannelCount];
            if(UsableChannel == null)
            {
                UInt16[] Channel = new UInt16[ChannelCount];
                for (int i = 0; i < ChannelCount; i++)
                {
                    Channel[i] = (UInt16)(i + 1);
                }

                UsableChannel = Channel;
            }
            for (int i=0; i< ChannelCount; i++)
            {
                UInt16 temp = (UInt16)(UsableChannel[i] - 1);
                fTable[i] = StartFreq + (temp * Spacing);
            }

            FreqTable = fTable;
        }

        public string[] GetFreqTable()
        {
            string [] fTable = new string[FreqTable.Length];

            for(int i=0; i< FreqTable.Length; i++)
            {
                fTable[i] = FreqTable[i].ToString();    
            }
            return (fTable);
        }
    }
}
