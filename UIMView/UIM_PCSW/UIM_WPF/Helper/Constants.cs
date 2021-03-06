﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIM_WPF.Helper
{
    public class Constants
    {
        public const int RET_ERR = -1;
        public const int RET_OK = 0;
        public const string R = "R";
        public const string RW = "RW";
        public const string TREENODEFORMAT = "{0} : {1} [{2}]";
        public const string FILENAME = "1.0.1_ParamsWClassNames.xml";
        public const ushort NUM_REG = 120;
        public const ushort NUM_REG_LAST = 20;
        // ->Signal Chart
        public const ushort SIGNAL_TIMER_INTERVAL_SECS = 5000;
        public const ushort SIGNAL_DEFAULT_NUM_POINTS = 500;
        public const ushort SIGNAL_START_REGISTER_AB = 40002;
        public const ushort SIGNAL_START_REGISTER_BA = 42050;
        // <-Signal Chart
        public const ushort MODBUS_MAX_REGS_16BIT = 125;
        //Livedatagrid
        public const ushort LIVE_TIMER_INTERVAL_SECS = 1000;
        //Dignostic signal data
        public const ushort SIGNUMPOINTS_MODBUSID = 12141;
        public const ushort SIGPATHMASK_MODBUSID = 12142;
        public const ushort SIGSTART_MODBUSID = 12143;
        public const ushort SIGTYPES_MODBUSID = 12144;


    }
}
