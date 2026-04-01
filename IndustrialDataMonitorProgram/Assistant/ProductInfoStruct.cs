using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialDataMonitorProgram.Assistant
{
    internal struct ProductInfoStruct
    {
        public string p_id {  get; }
        public double p_temp {  get;  }
        public double p_pressure {  get;  }
        public int p_speed {  get; }

        public ProductInfoStruct(string pid,double ptemp,double ppressure,int pspeed)
        {
            p_id = pid;
            p_temp = ptemp;
            p_pressure = ppressure;
            p_speed = pspeed;
        }
    }
}
