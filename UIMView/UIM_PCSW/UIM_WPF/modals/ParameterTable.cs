using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIM_WPF.modals
{
    /*
     *  Modal used for displaying Live and param grids. The array legth is hard coded to 8 as max
     */
    public class ParameterTable
    {
        //this is to show the Parameter group
        public string ParameterGroupName { get; set; }
        public ushort ModbusID { get; set; }
        // this is parameter
        public string Name { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public string Value7 { get; set; }
        public string Value8 { get; set; }
        public string Value9 { get; set; }
        public string Value10 { get; set; }
        public string Value11 { get; set; }
        public string Value12 { get; set; }
        public string Unit { get; set; }

    }
}
