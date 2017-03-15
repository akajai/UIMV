using FieldTalk.Modbus.Master;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static UIM_WPF.ParamManager;
using System.ComponentModel;
using UIM_WPF.modals;

namespace UIM_WPF.Helper
{
    public class Utils
    {

        public static Hashtable getSourceStrings()
        {
            Hashtable mSourceStringsHash = new Hashtable();
            mSourceStringsHash.Add(0, "Vel");
            mSourceStringsHash.Add(1, "Vol");
            mSourceStringsHash.Add(2, "Tot");
            mSourceStringsHash.Add(3, "Length");
            mSourceStringsHash.Add(4, "Temp");
            mSourceStringsHash.Add(5, "Press");
            mSourceStringsHash.Add(6, "DeltaT");
            mSourceStringsHash.Add(7, "TransTime");
            mSourceStringsHash.Add(8, "Signal");
            mSourceStringsHash.Add(9, "Density");
            mSourceStringsHash.Add(10, "ViscosityAbs");
            mSourceStringsHash.Add(-1, "");
            return mSourceStringsHash;
        }

        public static Hashtable getUnitStringsUS()
        {
            Hashtable mSourceStringsHash = new Hashtable();
            mSourceStringsHash.Add(0, "M/s");
            mSourceStringsHash.Add(1, "M3/h");
            mSourceStringsHash.Add(2, "M3");
            mSourceStringsHash.Add(3, "M");
            mSourceStringsHash.Add(4, "C");
            mSourceStringsHash.Add(5, "MPa");
            mSourceStringsHash.Add(6, "nSecs");
            mSourceStringsHash.Add(7, "uSecs");
            mSourceStringsHash.Add(8, "dB");
            mSourceStringsHash.Add(9, "Kg/M3");
            mSourceStringsHash.Add(10, "PaS");
            mSourceStringsHash.Add(-1, "");
            return mSourceStringsHash;
        }
        public static Hashtable getUnitStringsNonUS()
        {
            Hashtable mSourceStringsHash = new Hashtable();
            mSourceStringsHash.Add(0, "Ft/s");
            mSourceStringsHash.Add(1, "CuFt/h");
            mSourceStringsHash.Add(2, "CuFt");
            mSourceStringsHash.Add(3, "In");
            mSourceStringsHash.Add(4, "F");
            mSourceStringsHash.Add(5, "PSIa");
            mSourceStringsHash.Add(6, "nSecs");
            mSourceStringsHash.Add(7, "uSecs");
            mSourceStringsHash.Add(8, "dB");
            mSourceStringsHash.Add(9, "Kg/M3");
            mSourceStringsHash.Add(10, "PaS");
            mSourceStringsHash.Add(-1, "");
            return mSourceStringsHash;
        }
        public static void FillParameterTableValueArray(ref modals.ParameterTable parameterTable, string Value)
        {
            string[] valArray = Value.Split(',');
            for (int index = 0; index < valArray.Length; index++)
            {
                switch (index)
                {
                    case 0:
                        parameterTable.Value1 = valArray[0];
                        break;
                    case 1:
                        parameterTable.Value2 = valArray[1];
                        break;
                    case 2:
                        parameterTable.Value3 = valArray[2];
                        break;
                    case 3:
                        parameterTable.Value4 = valArray[3];
                        break;
                    case 4:
                        parameterTable.Value5 = valArray[4];
                        break;
                    case 5:
                        parameterTable.Value6 = valArray[5];
                        break;
                    case 6:
                        parameterTable.Value7 = valArray[6];
                        break;
                    case 7:
                        parameterTable.Value8 = valArray[7];
                        break;
                    case 8:
                        parameterTable.Value9 = valArray[8];
                        break;
                    case 9:
                        parameterTable.Value10 = valArray[9];
                        break;
                    case 10:
                        parameterTable.Value11 = valArray[10];
                        break;
                    case 11:
                        parameterTable.Value12 = valArray[11];
                        break;

                    default:
                        break;
                }
            }
        }
        public static void PopulateTreeAndGrids(ParamManager paramManager, ref TreeViewItem treeDVMainNode, ref TreeViewItem treeParamsMainNode, ref TreeViewItem treeLiveMainNode, ref List<modals.ParameterTable> livelstTree, ref List<modals.ParameterTable> paramslstTree)
        {

            ParameterTable parameterTable;
            //treeLiveMainNode
            //treeDVMainNode

            treeLiveMainNode.IsExpanded = true;
            treeLiveMainNode.Header = "Device 1";
            treeLiveMainNode.IsSelected = true;
            treeDVMainNode.IsExpanded = true;
            treeDVMainNode.Header = "Device 1";
            treeDVMainNode.IsSelected = true;

            treeParamsMainNode.IsExpanded = true;
            treeParamsMainNode.Header = "Device 1";
            treeParamsMainNode.IsSelected = true;

            ParameterContainer parameterContainer = paramManager.mParamContainer;
            foreach (ParamManager.ParameterGroup pGroup in parameterContainer.ParameterGroups)
            {

                TreeViewItem treeliveNode = new TreeViewItem();
                TreeViewItem treeParamsNode = new TreeViewItem();
                treeliveNode.Header = pGroup.Name;
                treeliveNode.IsExpanded = true;
                treeParamsNode.Header = pGroup.Name;
                treeParamsNode.IsExpanded = true;
                Boolean isR = false;
                Boolean isRW = false;
                foreach (Parameter parameter in pGroup.Parameters.ToList())
                {
                    parameterTable = new modals.ParameterTable();
                    parameterTable.ParameterGroupName = pGroup.Name;
                    parameterTable.Name = parameter.Name;
                    parameterTable.ModbusID = parameter.ModbusID;
                    /*if (parameter.Elements == "1")
                    {
                        parameterTable.Value1 = parameter.Value;
                    }
                    else
                    {
                        Utils.FillParameterTableValueArray(ref parameterTable, parameter.Value);
                    }*/
                    parameterTable.Unit = Helper.Utils.getUnitStringsUS()[parameter.Unit].ToString();
                    if (parameter.RW == Constants.R)
                    {
                        isR = true;
                        TreeViewItem treeLiveInnerNode = new TreeViewItem();
                        treeLiveInnerNode.Header = String.Format(Constants.TREENODEFORMAT, parameter.Name, parameter.Value, Helper.Utils.getUnitStringsUS()[parameter.Unit].ToString());
                        treeliveNode.Items.Add(treeLiveInnerNode);
                        livelstTree.Add(parameterTable);
                    }
                    else if (parameter.RW == Constants.RW)
                    {
                        isRW = true;
                        paramslstTree.Add(parameterTable);
                    }
                }
                if (isR == true)
                {
                    treeDVMainNode.Items.Add(treeliveNode);
                }
                if (isRW == true)
                {
                    // treeParamsMainNode.Items.Add(treeParamsNode);
                }
            }
        }



        // THis function will Queue the messages for the diag signal charts after async comm is working.
        // Until then it works sync. WIll be called by timer expiration routine.

        public static void QueueSignalMessages(ref List<KeyValuePair<string, float>> chartList, MbusMasterFunctions mConnection, ushort usstartReg)
        {
            ParamManager.ModbusReadHoldingMsg msg = new ParamManager.ModbusReadHoldingMsg();
            int result = 0;
            // Do AB first.
            UInt16 nNumSignalPoints = Constants.SIGNAL_DEFAULT_NUM_POINTS;
            chartList.Clear();
            //      ((LineSeries)chartAB.Series[0]).ItemsSource = null;
            // PENDING Change this to queue messages and dispatch to signal chart object to populate the charts.
            msg.StartReg = usstartReg;
            msg.NumRegs = Constants.MODBUS_MAX_REGS_16BIT;
            //       mConnection.timeout = 5000;
            for (int msgIndex = 0; msgIndex < nNumSignalPoints / msg.NumRegs; msgIndex++)
            {
                msg.SlaveID = 1; // PENDING, make current device id variable.
                msg.NumRegs = Constants.MODBUS_MAX_REGS_16BIT; // PENDING MAKE constant and for above in loop control.
                result = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg, msg.ReadVals, msg.NumRegs);

                for (int chartPoint = 0; chartPoint < msg.NumRegs; chartPoint++)
                {
                    chartList.Add(new KeyValuePair<string, float>((msg.StartReg + chartPoint).ToString(), msg.ReadVals[chartPoint]));
                }

                msg.StartReg += msg.NumRegs;
            }

            // Create message for the remaining points if we are not even multiple of max 16bit regs.
            ushort remainingRegs = (ushort)(nNumSignalPoints % msg.NumRegs);
            if (remainingRegs != 0)
            {
                msg.StartReg += msg.NumRegs;
                msg.NumRegs = remainingRegs;
                result = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg, msg.ReadVals, msg.NumRegs);
            }
        }

        public static void InitModbusGroups(ref ParamManager mParamManager, string strdeviceID)
        {
            bool bLiveDataGroupWritten = false;
            bool bParamGroupWritten = false;
            int liveDataRow = 0, paramDataRow = 0;

            // Pending make param groups enumeratable.
            for (int i = 0; i < mParamManager.mParamContainer.ParameterGroups.Count(); i++)
            {
                bLiveDataGroupWritten = false;
                bParamGroupWritten = false;
                ParamManager.ParameterGroup pg = mParamManager.mParamContainer.ParameterGroups[i];
                // Pending make parameters enumeratable.
                for (int j = 0; j < pg.Parameters.Count(); j++) // (Parameter param in pg.Parameters)
                {
                    ParamManager.Parameter param = pg.Parameters[j];
                    if (param.ModbusID != 0)
                    {
                        if (param.RW == "R") // && param.Type == "D")
                        {
                            // Add the Group Name the first time through.
                            if (!bLiveDataGroupWritten)
                            {
                                bLiveDataGroupWritten = true;
                                // Add the name.
                                liveDataRow++;
                            }
                            // Add the param name, value boxes and unit string.
                            // Loop through all the elements in the value array.
                            for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            {   // Create a new row every 4 element vaues and add a label for the param name.
                                // we only put the name in the first row, we will add a blank label to the
                                // other rows to maintain spacing.
                                if (k % 4 == 0)
                                {
                                    liveDataRow++;
                                    //lbl.Font = new System.Drawing.Font("Lucida Console", 8, FontStyle.Regular);

                                    if (k == 0) // The first time we add the name of the param in the label.
                                    {
                                        // lbl.Text = param.Name;
                                    }
                                }
                                // Add a value box for each element.
                                //for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                                //{
                                int modbusID = 0;
                                switch (param.Type)
                                {
                                    case "D": // Skip 2 regs for float 32.
                                        modbusID = param.ModbusID + 2 * k;
                                        break;
                                    case "X":
                                    case "UI":
                                    case "I": // If its a Int32 skip 2, (0x100 in options)
                                        if ((param.Options & (UInt32)UIM_WPF.ParamManager.ParamOptions.eModbusULong) != 0)
                                        {
                                            modbusID = param.ModbusID + 2 * k;
                                        }
                                        else // Int16, skip just one register.
                                        {
                                            modbusID = param.ModbusID + k;
                                        }
                                        break;
                                }
                                mParamManager.mRegisterControlHash.Add(modbusID, modbusID.ToString());
                            }
                            // Add the unit string.
                            // If we get to 46 rows go to the next panel.

                        } // End Read only.
                        else //if (param.Type == "UI" || param.Type == "X")
                        { // ReadWrite
                            if (!bParamGroupWritten)
                            {

                                // Add the name.
                                paramDataRow++;
                            }
                            for (int k = 0; k < Convert.ToInt16(param.Elements); k++)
                            {   // New row every 4 params.
                                if (k % 4 == 0)
                                {
                                    paramDataRow++;

                                    if (k == 0)
                                    {
                                        //    lbl.Text = param.Name;
                                    }

                                }
                                // Add a value box for each element.

                                int modbusID = 0;
                                switch (param.Type)
                                {
                                    case "D":
                                        modbusID = param.ModbusID + 2 * k;
                                        break;
                                    case "X":
                                    case "UI":
                                    case "I":
                                        if ((Convert.ToInt16(param.Options) & 0x0100) != 0)
                                        {
                                            modbusID = param.ModbusID + 2 * k;
                                        }
                                        else
                                        {
                                            modbusID = param.ModbusID + k;
                                        }
                                        break;
                                }
                                mParamManager.mRegisterControlHash.Add(modbusID, modbusID.ToString());

                            }
                            // Add the unit string.


                        } // Read Write.
                    } // Modbus ID
                } // For Param.
            } // For Group.

            mParamManager.InitModbusMsgGroups(Convert.ToUInt16(strdeviceID));
        }
        public static void UpdateLiveAndParamsData(ParamManager mParamManager, MbusMasterFunctions mConnection, ref List<ParameterTable> livelstTree, ref List<ParameterTable> paramslstTree, ref BackgroundWorker bgWorkerDignosticSignal)
        {
            int iCount = 0;
            int mMaxErrors = 0;
            // Copy any repeating messages into the message q.
            foreach (ParamManager.ModbusReadHoldingMsg msg in mParamManager.mModbusMsgGroup)
            {
                mParamManager.mMessageQ.Add(msg);
            }
            // mParamManager.mModbusMsgGroup.Clear();
            int ticPercentage = 50 / mParamManager.mMessageQ.Count;
            int ticIndex = 0;
            foreach (ParamManager.ModbusReadHoldingMsg msg in mParamManager.mMessageQ)
            {
                if (iCount < 32)
                {
                    Int32 res = 0;
                    int count = 0;
                    do
                    {
                        res = mConnection.readMultipleRegisters(msg.SlaveID, msg.StartReg + 1, msg.ReadVals, msg.NumRegs);
                        //if (res != 0)
                        //    Thread.Sleep(500);
                    } while (res != 0 && count++ < 20);

                    if (count > mMaxErrors)
                        mMaxErrors = count;

                    iCount++;
                    if (res == BusProtocolErrors.FTALK_SUCCESS)
                    {

                        switch (msg.DataType)
                        {
                            case "D":
                                mParamManager.MBRegsToFloats(msg);

                                break;
                            case "U16":
                                mParamManager.MBRegsToUInt16(msg);

                                break;
                            case "I16":
                                mParamManager.MBRegsToInt16(msg);

                                break;
                            case "U32":
                                mParamManager.MBRegsToUInt32(msg);

                                break;
                        }
                    }
                    //ProcessResponse(msg);
                }

                bgWorkerDignosticSignal.ReportProgress(50 + (ticPercentage * (++ticIndex)));


            }

            // Updating Data grids data source
            foreach (ModbusReadHoldingMsg msg in mParamManager.mMessageQ)
            {
                for (ushort index = 0; index < msg.NumRegs; index++)
                {

                    for (int liveindex = 0; liveindex < livelstTree.Count; liveindex++)
                    {
                        modals.ParameterTable liveparam = livelstTree[liveindex];
                        if (msg.RegIds[index] == liveparam.ModbusID)
                        {

                            switch (msg.DataType)
                            {
                                case "D":
                                    //msg.FloatVals[index];
                                    liveparam.Value1 = msg.FloatVals[index].ToString();

                                    break;
                                case "U16":
                                    //     mParamManager.MBRegsToUInt16(msg);
                                    liveparam.Value1 = msg.UInt16Vals[index].ToString();
                                    break;
                                case "I16":
                                    //  mParamManager.MBRegsToInt16(msg);
                                    liveparam.Value1 = msg.ReadVals[index].ToString();

                                    break;
                                case "U32":
                                    //mParamManager.MBRegsToUInt32(msg);
                                    liveparam.Value1 = msg.UInt32Vals[index].ToString();
                                    break;
                            }
                        }

                        livelstTree[liveindex] = liveparam;
                    }

                    for (int paramindex = 0; paramindex < paramslstTree.Count; paramindex++)
                    {
                        modals.ParameterTable paramParam = paramslstTree[paramindex];
                        if (msg.RegIds[index] == paramParam.ModbusID)
                        {

                            switch (msg.DataType)
                            {
                                case "D":
                                    //msg.FloatVals[index];
                                    paramParam.Value1 = msg.FloatVals[index].ToString();
                                    break;
                                case "U16":
                                    // mParamManager.MBRegsToUInt16(msg);
                                    paramParam.Value1 = msg.UInt16Vals[index].ToString();
                                    break;
                                case "I16":
                                    //mParamManager.MBRegsToInt16(msg);
                                    paramParam.Value1 = msg.ReadVals[index].ToString();
                                    break;
                                case "U32":
                                    //mParamManager.MBRegsToUInt32(msg);
                                    paramParam.Value1 = msg.UInt32Vals[index].ToString();
                                    break;
                            }

                        }

                        paramslstTree[paramindex] = paramParam;
                    }
                }


                // DeQueue the message.
                //  mParamManager.mMessageQ.Clear();

            }
        }

    }
}
