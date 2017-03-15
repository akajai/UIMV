using FieldTalk.Modbus.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIM
{
    public class MbusMasterFunctionsasyc
    {
        //  private  MbusMasterFunctions mConnection;
        // private ParamManager.ModbusReadHoldingMsg msg;
        internal async void readMultipleRegistersasyc(dynamic mConnection, dynamic msg)
        {
            try
            {
               
                var task = await mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg, msg.ReadVals, msg.NumRegs);
                // DoStuff(data);
                dynamic result = await task;


            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static implicit operator MbusMasterFunctionsasyc(MbusMasterFunctions v)
        {
            throw new NotImplementedException();
        }
    }
}
