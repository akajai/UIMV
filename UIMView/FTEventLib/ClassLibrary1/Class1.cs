using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBEventLib
{
    public class MBMasterComm
    {
        public event EventHandler OnComm;
        public void SendMsg()
        {
            EventHandler onComm = OnComm;
            //EventArgs e = ;
            onComm(this, null);
        }

    }
}
