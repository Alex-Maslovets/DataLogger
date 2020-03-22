using System;
using System.Data;
using System.Text;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OPCSiemensDAAutomation;
using Settings;
using Tools;
using System.Diagnostics;
////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
using System.Linq;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;
using System.Security.Cryptography.X509Certificates;
////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////


namespace DataManager
{
    public enum OPCState
    {
        Disconnected,
        Failed,
        Noconfig,
        Running,
        Suspended,
        Test,
        Unknown
    }
    public enum OPCQuality : short
    {
        Bad = 0,
        Uncertain = 64,
        Good = 192,
        NotConnected = 8,
        DeviceFailure = 13,
        SensorFailure = 16,
        LastKnown = 20,
        CommFailure = 24,
        OutOfService = 28,
        LastUsable = 132,
        SensorCal = 144,
        EguExceeded = 148,
        SubNormal = 152,
        LocalOverride = 216
    }
    public enum ConfigState
    {
        Starting,
        Started,
        Stopping,
        Stopped,
    }

    public enum ConfigStateOPCUA
    {
        Started,
        Stopped,
    }
    public enum ConfigConnectStateOPCUA
    {
        ConnectEstablish,
        Connecting,
        noConnect,
    }

    public class OPCEventArgs : EventArgs
    {
        private string desc;

        public OPCEventArgs(string text)
        {
            desc = text;
        }
        public string Description
        {
            get
            {
                return desc;
            }
        }
    }
    public class OPCDataEventArgs : EventArgs
    {
        private int clientHandle;
        private object value;

        public OPCDataEventArgs(int clientHandle, object value)
        {
            this.clientHandle = clientHandle;
            this.value = value;
        }
        public int ClientHandle
        {
            get
            {
                return this.clientHandle;
            }
        }
        public object Value
        {
            get
            {
                return this.value;
            }
        }
    }
    public class OPCStateEventArgs : EventArgs
    {
        private OPCState state;

        public OPCStateEventArgs(OPCState state)
        {
            this.state = state;
        }
        public OPCState State
        {
            get
            {
                return state;
            }
        }
    }
    public class ConfigStateEventArgs : EventArgs
    {
        private ConfigState state;

        public ConfigStateEventArgs(ConfigState state)
        {
            this.state = state;
        }
        public ConfigState State
        {
            get
            {
                return this.state;
            }
        }
    }
    ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
    public class ConfigStateOPCUAEventArgs : EventArgs
    {
        private ConfigStateOPCUA state;

        public ConfigStateOPCUAEventArgs(ConfigStateOPCUA state)
        {
            this.state = state;
        }
        public ConfigStateOPCUA State
        {
            get
            {
                return this.state;
            }
        }
    }
    public class ConfigConnectStateOPCUAEventArgs : EventArgs
    {
        private ConfigConnectStateOPCUA state;

        public ConfigConnectStateOPCUAEventArgs(ConfigConnectStateOPCUA state)
        {
            this.state = state;
        }
        public ConfigConnectStateOPCUA State
        {
            get
            {
                return this.state;
            }
        }
    }
    ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

    public class ConfigStatisticsEventArgs : EventArgs
    {
        private string tranName;
        private ConnectionState odbcState;
        private OPCState opcState;
        private Statistics tranStat;

        public ConfigStatisticsEventArgs(Transaction tran)
        {
            tranName = tran.tranName;
            opcState = tran.opcConn.State;
            odbcState = tran.odbcConn.State;
            tranStat = new Statistics(tran.stat);
        }
        public string TransactionName
        {
            get
            {
                return tranName;
            }
        }
        public ConnectionState ODBCConnState
        {
            get
            {
                return odbcState;
            }
        }
        public OPCState OPCConnState
        {
            get
            {
                return opcState;
            }
        }
        public Statistics TransactionStatistics
        {
            get
            {
                return tranStat;
            }
        }
    }

    public delegate void OPCEventHandler(object sender, OPCEventArgs e);
    public delegate void OPCDataEventHandler(object sender, OPCDataEventArgs e);
    public delegate void OPCStateEventHandler(object sender, OPCStateEventArgs e);
    public delegate void ConfigStateEventHandler(object sender, ConfigStateEventArgs e);
    ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
    public delegate void ConfigStateOPCUAEventHandler(object sender, ConfigStateOPCUAEventArgs e);
    ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
    public delegate void StatisticsEventHandler(object sender, ConfigStatisticsEventArgs e);

    public static class Config
    {
        private static ConfigState state = ConfigState.Stopped;
        private static BackgroundWorker bgwStarting = null;
        private static BackgroundWorker bgwStopping = null;
        private static BackgroundWorker bgwDisposing = null;
        private static SingleEventLog appLog = null;
        private static AppSettings appSets = null;
        private static bool disposing = false;
        private static bool disposed = false;
        private static bool reconnect = false;
        private static bool stopping = false;
        private static List<Transaction> transactions = new List<Transaction>();

        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        private static ConfigStateOPCUA stateOPCUA = ConfigStateOPCUA.Stopped;
        private static BackgroundWorker bgwStartingOPCUA = null;
        private static BackgroundWorker bgwStoppingOPCUA = null;
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        private static BackgroundWorker BGWStarting
        {
            get
            {
                if (bgwStarting == null)
                {
                    bgwStarting = new BackgroundWorker();
                    bgwStarting.DoWork += Starting;
                }
                return bgwStarting;
            }
        }
        private static BackgroundWorker BGWStopping
        {
            get
            {
                if (bgwStopping == null)
                {
                    bgwStopping = new BackgroundWorker();
                    bgwStopping.DoWork += Stopping;
                }
                return bgwStopping;
            }
        }
        
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        private static BackgroundWorker BGWStartingOPCUA
        {
            get
            {
                if (bgwStartingOPCUA == null)
                {
                    bgwStartingOPCUA = new BackgroundWorker();
                    bgwStartingOPCUA.DoWork += bgwStartOPCUA;
                }
                return bgwStartingOPCUA;
            }
        }
        private static BackgroundWorker BGWStoppingOPCUA
        {
            get
            {
                if (bgwStoppingOPCUA == null)
                {
                    bgwStoppingOPCUA = new BackgroundWorker();
                    bgwStoppingOPCUA.DoWork += bgwStopOPCUA;
                }
                return bgwStoppingOPCUA;
            }
        }
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        private static BackgroundWorker BGWDisposing
        {
            get
            {
                if (bgwDisposing == null)
                {
                    bgwDisposing = new BackgroundWorker();
                    bgwDisposing.DoWork += Disposing;
                }
                return bgwDisposing;
            }
        }
        
        public static SingleEventLog Log
        {
            get
            {
                if (appLog == null) appLog = new SingleEventLog(Application.ProductName);
                return appLog;
            }
        }
        public static AppSettings Sets
        {
            get
            {
                if (appSets == null)
                {
                    appSets = new AppSettings(Application.StartupPath + "\\config.xml", Log);
                    appSets.Load();
                }
                return appSets;
            }
        }

        public static ConfigState State
        {
            get
            {
                return state;
            }
        }
        
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        public static ConfigStateOPCUA StateOPCUA
        {
            get
            {
                return stateOPCUA;
            }
        }
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        public static bool IsDisposing
        {
            get
            {
                return disposing;
            }
        }
        public static bool IsDisposed
        {
            get
            {
                return disposed;
            }
        }

        private static void OPCStateChanged(object sender, OPCStateEventArgs e)
        {
            if (state == ConfigState.Started && e.State != OPCState.Running && !reconnect)
            {
                reconnect = true;
                StopTransact();
                if (!stopping)
                {
                    Thread.Sleep(1000);
                    if (!stopping)
                    {
                        CreateTransact();
                        StartTransact();
                    }
                }
                reconnect = false;
            }
        }
        private static void TransactStatistics(object sender, ConfigStatisticsEventArgs e)
        {
            if (Statistics != null) Statistics(sender, e);
        }

        public static bool Ready
        {
            get
            {
                if (Sets.Primary_ODBC_DSN != "")
                {
                    if (Sets.TransactionBase.Tables["TransactionTable"].Rows.Count > 0) return true;
                }
                return false;
            }
        }
        
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        public static bool ReadyOPCUA
        {
            get
            {
                if (Sets.Primary_ODBC_DSN != "")
                {
                    if (Config.Sets.Primary_OPCUA_Node != "") return true;
                }
                return false;
            }
        }
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        public static void Dispose()
        {
            disposing = true;
            if (!BGWDisposing.IsBusy) BGWDisposing.RunWorkerAsync();
            while (BGWDisposing.IsBusy) Application.DoEvents();
            disposing = false;
            disposed = true;
        }

        public static void Save()
        {
            //savedInfoGridView_Update();
            if (appSets != null) appSets.Save();
        }
        public static void Start()
        {
            if (!BGWStarting.IsBusy) BGWStarting.RunWorkerAsync();
            if (!Sets.Running) Sets.Running = true;
        }
        public static void Stop()
        {
            Sets.Running = false;
            if (!BGWStopping.IsBusy) BGWStopping.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        public static void StartOPCUA()
        {
            if (!BGWStartingOPCUA.IsBusy) BGWStartingOPCUA.RunWorkerAsync();
            if (!Sets.Running_OPCUA) Sets.Running_OPCUA = true;
        }
        public static void StopOPCUA()
        {
            Sets.Running_OPCUA = false;
            if (!BGWStoppingOPCUA.IsBusy) BGWStoppingOPCUA.RunWorkerAsync();
        }
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        private static void CreateTransact()
        {
            string tableName;
            string fTranDT;
            string fCtrlDT;
            string fParID;
            string fParVal;

            transactions.Clear();
            
            foreach (DataRow row in Sets.TransactionBase.Tables["TransactionTable"].Rows)
            {
                tableName = row["Table Name"].ToString();
                fTranDT = row["Transaction DT"].ToString();
                fCtrlDT = row["Controller DT"].ToString();
                fParID = row["Parameter ID"].ToString();
                fParVal = row["Parameter Value"].ToString();

                Transaction tran = new Transaction(Log);

                tran.tranName = row["Transaction Name"].ToString();
                tran.S7ConnName = row["Connection Name"].ToString();
                tran.S7DbNumber = row["DB #"] is int ? (int)row["DB #"] : 0;
                tran.odbcConn.GenerateCommand(tableName, fTranDT, fCtrlDT, fParID, fParVal);
                tran.Statistics += TransactStatistics;
                tran.OPConnStateChange += OPCStateChanged;
                tran.ConnectToODBC();
                tran.ConnectToOPC();

                transactions.Add(tran);
                if (Statistics != null) Statistics(tran, new ConfigStatisticsEventArgs(tran));
            }
        }

        private static void Starting(object sender, DoWorkEventArgs e)
        {
            state = ConfigState.Starting;            
            if (StateChange != null) StateChange(null, new ConfigStateEventArgs(state));

            stopping = false;
            CreateTransact();

            state = ConfigState.Started;
            if (StateChange != null) StateChange(null, new ConfigStateEventArgs(state));
            Log.WriteEntry("The configuration was started");
        }
        private static void Stopping(object sender, DoWorkEventArgs e)
        {
            if (state == ConfigState.Starting || state == ConfigState.Started)
            {
                state = ConfigState.Stopping;                
                if (StateChange != null) StateChange(null, new ConfigStateEventArgs(state));                
            }
            stopping = true;
            StopTransact();            
            if (state != ConfigState.Stopped)
            {
                state = ConfigState.Stopped;
                Log.WriteEntry("The configuration was stopped");
                if (StateChange != null) StateChange(null, new ConfigStateEventArgs(state));
            }
        }


        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        private static void bgwStartOPCUA(object sender, DoWorkEventArgs e)
        {
            stateOPCUA = ConfigStateOPCUA.Started;
            if (StateChangeOPCUA != null) StateChangeOPCUA(null, new ConfigStateOPCUAEventArgs(stateOPCUA));
            Log.WriteEntry("The configuration OPCUA was started");
            Console.WriteLine("The configuration OPCUA was started");
            OPCUA classOPCUA = new OPCUA();
            classOPCUA.start_BGW_OPCUA();
        }
        private static void bgwStopOPCUA(object sender, DoWorkEventArgs e)
        {
            if (stateOPCUA != ConfigStateOPCUA.Stopped)
            {
                stateOPCUA = ConfigStateOPCUA.Stopped;
                Log.WriteEntry("The configuration OPCUA was stopped");
                Console.WriteLine("The configuration OPCUA was stopped");
                if (StateChangeOPCUA != null) StateChangeOPCUA(null, new ConfigStateOPCUAEventArgs(stateOPCUA));
                OPCUA classOPCUA = new OPCUA();
                classOPCUA.stop_BGW_OPCUA();
            }
        }
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        private static void StartTransact()
        {
            foreach (Transaction tran in transactions)
            {
                tran.ConnectToODBC();
                tran.ConnectToOPC();
            }
        }        
        private static void StopTransact()
        {
            foreach (Transaction tran in transactions)
            {
                tran.DisconnectFromOPC();
                tran.DisconnectFromODBC();
            }
            bool busy;
            do
            {
                busy = false;
                foreach (Transaction tran in transactions)
                {
                    if (tran.IsBusy)
                    {
                        busy = true;
                        break;
                    }
                }
            } while (busy);
        }
        private static void Disposing(object sender, DoWorkEventArgs e)
        {
            if (!BGWStopping.IsBusy)
            {
                BGWStopping.RunWorkerAsync();
                while (BGWStopping.IsBusy) Application.DoEvents();
            }            
        }

        public static event ConfigStateEventHandler StateChange;
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        public static event ConfigStateOPCUAEventHandler StateChangeOPCUA;
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////
        public static event StatisticsEventHandler Statistics;
    }

    public class OPCSimaticNet : IDisposable
    {
        private bool disposed = false;
        private SingleEventLog log;
        private const string serverName = "OPC.SimaticNET";
        private OPCState state = OPCState.Disconnected;
        private OPCServer serverObj;
        private OPCGroup groupTriggers = null;
        private OPCGroup groupItems = null;
        private System.Timers.Timer timer = null;
        private int updateRate = 1000;
        private int clientHandle = 0;

        public event OPCDataEventHandler DataChanged;
        public event OPCStateEventHandler StateChange;

        public bool IsSubscribed
        {
            get
            {
                if (groupTriggers != null)
                {
                    return groupTriggers.IsActive && groupTriggers.IsSubscribed;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (groupTriggers != null)
                {
                    bool oldValue = groupTriggers.IsActive && groupTriggers.IsSubscribed;
                    if (value != oldValue)
                    {
                        groupTriggers.IsActive = value;
                        groupTriggers.IsSubscribed = value;
                    }
                }
            }
        }
        public OPCState State
        {
            get
            {
                return state;
            }
        }
        public string ServerName
        {
            get
            {
                return serverName;
            }
        }

        public OPCSimaticNet(SingleEventLog eventLog)
        {
            log = eventLog;
            timer = new System.Timers.Timer(1000d);
            timer.Enabled = false;
            timer.Elapsed += Tick;
        }

        ~OPCSimaticNet()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (State != OPCState.Disconnected) Disconnect();
                }
                if (groupItems != null)
                {
                    Marshal.ReleaseComObject(groupItems);
                    groupItems = null;
                }
                if (groupTriggers != null)
                {
                    Marshal.ReleaseComObject(groupTriggers);
                    groupTriggers = null;
                }
                if (serverObj != null)
                {
                    Marshal.ReleaseComObject(serverObj);
                    serverObj = null;
                }
            }
            disposed = true;
        }

        private void OPCDataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                if (QualityGood(Qualities.GetValue(i)))
                {
                    if (DataChanged != null)
                    {
                        DataChanged(this, new OPCDataEventArgs((int)ClientHandles.GetValue(i), ItemValues.GetValue(i)));
                    }
                }

            }
        }
        private void OPCShutDown(string Reason)
        {            
            timer.Stop();
            state = GetOPCserverState(serverObj);
            log.WriteEntry(serverName + ". " + Reason);            
            if (StateChange != null) StateChange(this, new OPCStateEventArgs(state));
        }
        private void Tick(object sender, ElapsedEventArgs e)
        {
            OPCState getstate = GetOPCserverState(serverObj);
            if (state != getstate)
            {
                if (state == OPCState.Running && getstate != OPCState.Running)
                {
                    Disconnect();
                }
                else
                {
                    state = getstate;
                    if (StateChange != null) StateChange(this, new OPCStateEventArgs(state));                
                }                
            }
        }

        private OPCState GetOPCserverState(OPCServer server)
        {
            if (server == null) return OPCState.Unknown;

            switch (server.ServerState)
            {
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCDisconnected:
                    return OPCState.Disconnected;
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCFailed:
                    return OPCState.Failed;
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCNoconfig:
                    return OPCState.Noconfig;
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCRunning:
                    return OPCState.Running;
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCSuspended:
                    return OPCState.Suspended;
                case (int)OPCSiemensDAAutomation.OPCServerState.OPCTest:
                    return OPCState.Test;
                default:
                    return OPCState.Unknown;
            }
        }
        public bool Connect(string nodeName, int updateRate)
        {
            try
            {
                if (state != OPCState.Running)
                {
                    serverObj = new OPCServer();
                    serverObj.ServerShutDown += OPCShutDown;
                    serverObj.Connect(serverName, nodeName);
                    
                    OPCState getstate = GetOPCserverState(serverObj);
                    if (getstate == OPCState.Running)
                    {
                        serverObj.OPCGroups.DefaultGroupIsActive = false;
                        if (state != getstate)
                        {
                            state = getstate;
                            if (StateChange != null) StateChange(this, new OPCStateEventArgs(state));
                        }
                        timer.Start();
                    }
                    else
                    {
                        serverObj.Disconnect();
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                log.WriteEntry(serverName + ". " + e.Message);
                return false;
            }

            this.updateRate = updateRate;
            return true;
        }
        public void Disconnect()
        {
            timer.Stop();

            if (groupItems != null)
            {
                try
                {
                    groupItems.IsSubscribed = false;
                }
                catch
                {

                }
            }
            if (groupTriggers != null)
            {
                try
                {
                    groupTriggers.IsSubscribed = false;
                }
                catch
                {

                }
            }

            try
            {
                if (serverObj.OPCGroups.Count > 0) serverObj.OPCGroups.RemoveAll();                
                
                OPCState getstate = GetOPCserverState(serverObj);

                if (getstate == OPCState.Running)
                {
                    try
                    {
                        serverObj.ServerShutDown -= OPCShutDown;
                        serverObj.Disconnect();
                    }
                    catch
                    {

                    }
                    getstate = GetOPCserverState(serverObj);
                }                

                if (state != getstate)
                {
                    state = getstate;
                    if (StateChange != null) StateChange(this, new OPCStateEventArgs(state));
                }
            }
            catch (Exception e)
            {
                log.WriteEntry(serverName + " disconnect error! " + e.Message);
            }
        }
        public static Exception TestConnection(string nodeName)
        {
            OPCServer testServer = new OPCServer();

            try
            {
                testServer.Connect(serverName, nodeName);
                testServer.Disconnect();
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public OPCItem AddTrigger(string connection, string address)
        {
            if (State == OPCState.Disconnected) return null;
            string itemID = "S7:[" + connection + "]" + address;

            try
            {
                if (groupTriggers == null)
                {
                    groupTriggers = serverObj.OPCGroups.Add(null);
                    groupTriggers.UpdateRate = updateRate;
                    groupTriggers.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(OPCDataChange);
                }
                return groupTriggers.OPCItems.AddItem("S7:[" + connection + "]" + address, clientHandle++);
            }
            catch (Exception ex)
            {
                log.WriteEntry("Error of addition of the item " + itemID + ". " + ex.Message);
                return null;
            }
        }
        public OPCItem AddItem(string connection, string address)
        {
            if (State == OPCState.Disconnected) return null;
            string itemID = "S7:[" + connection + "]" + address;
            try
            {
                if (groupItems == null)
                {
                    groupItems = serverObj.OPCGroups.Add(null);
                }
                return groupItems.OPCItems.AddItem(itemID, clientHandle++);
            }
            catch (Exception ex)
            {
                log.WriteEntry("Error of addition of the item " + itemID + ". " + ex.Message);
                return null;
            }
        }
        public bool QualityGood(object quality)
        {
            if (quality is short)
            {
                return (short)quality == (short)OPCQuality.Good ? true : false;
            }
            else
            {
                if (quality is int)
                {
                    return (int)quality == (int)OPCQuality.Good ? true : false;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ReadDateTimeItem(OPCDataSource source, OPCItem item, out DateTime dt)
        {
            if (State == OPCState.Running)
            {
                object value;
                object quality;
                object timestamp;

                try
                {
                    item.Read((short)source, out value, out quality, out timestamp);
                    if (!QualityGood(quality))
                    {
                        dt = DateTime.MinValue;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    log.WriteEntry(serverName + " read error! " + e.Message);
                    dt = DateTime.MinValue;
                    return false;
                }

                if (value is DateTime)
                {
                    dt = (DateTime)value;
                    return true;
                }
                else
                {
                    dt = DateTime.MinValue;
                    return false;
                }
            }
            else
            {
                dt = DateTime.MinValue;
                return false;
            }
        }
        public bool ReadDintItem(OPCDataSource source, OPCItem item, out int value)
        {
            if (State == OPCState.Running)
            {
                object val;
                object quality;
                object timestamp;

                try
                {
                    item.Read((short)source, out val, out quality, out timestamp);
                    if (!QualityGood(quality))
                    {
                        value = 0;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    log.WriteEntry(serverName + " read error! " + e.Message);
                    value = 0;
                    return false;
                }

                if (val is int)
                {
                    value = (int)val;
                    return true;
                }
                else
                {
                    value = 0;
                    return false;
                }
            }
            else
            {
                value = 0;
                return false;
            }
        }
        public bool ReadRealItem(OPCDataSource source, OPCItem item, out float value)
        {
            if (State == OPCState.Running)
            {
                object val;
                object quality;
                object timestamp;

                try
                {
                    item.Read((short)source, out val, out quality, out timestamp);
                    if (!QualityGood(quality))
                    {
                        value = 0f;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    log.WriteEntry(serverName + " read error! " + e.Message);
                    value = 0f;
                    return false;
                }

                if (val is float)
                {
                    value = (float)val;
                    return true;
                }
                else
                {
                    value = 0f;
                    return false;
                }

            }
            else
            {
                value = 0f;
                return false;
            }
        }
        public bool SyncRead(OPCDataSource source, Dictionary<OPCItem, object> opcItems)
        {
            if (opcItems.Count == 0) return true;

            int count = opcItems.Count;
            List<OPCItem> items = new List<OPCItem>(opcItems.Keys);

            Array serverHandles = Array.CreateInstance(typeof(int), new int[] { count }, new int[] { 1 });
            for (int i = 0; i < count; i++) serverHandles.SetValue(items[i].ServerHandle, i + 1);
            
            Array itemValues;
            Array errors;
            object qualities;
            object timeStamp;

            try
            {
                groupItems.SyncRead((short)source, count, ref serverHandles, out itemValues, out errors, out qualities, out timeStamp);
            }
            catch (Exception ex)
            {
                log.WriteEntry("Error of synchronous reading. " + ex.Message);
                return false;
            }

            // Check errors
            if (errors == null)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid error codes values");
                return false;
            }
            if (errors.Length != count)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid error codes counts");
                return false;
            }            
            for (int i = 1; i <= count; i++)
            {
                if (errors.GetValue(i) is int)
                {
                    int code = (int)errors.GetValue(i);
                    if (code != 0)
                    {
                        log.WriteEntry("Error of the synchronous reading tag " + items[i - 1].ItemID + ". " + serverObj.GetErrorString(code));
                        return false;
                    }
                }
                else
                {
                    log.WriteEntry("Error of the synchronous reading tag " + items[i - 1].ItemID + ". Invalid code error");
                    return false;
                }
            }

            // Check qualities
            Array qa = qualities is Array ? (Array)qualities : null;
            if (qa == null)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid quality values");
                return false;
            }
            if (qa.Length != count)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid quality counts");
                return false;
            }
            for (int i = 1; i <= count; i++)
            {
                object quality = qa.GetValue(i);
                if (!QualityGood(quality))
                {
                    if (quality is int)
                    {
                        log.WriteEntry("Error of the synchronous reading tag " + items[i - 1].ItemID + ". Bad quality is " + (int)qa.GetValue(i));
                    }
                    else
                    {
                        log.WriteEntry("Error of the synchronous reading tag " + items[i - 1].ItemID + ". Bad quality");
                    }
                    return false;
                }
            }

            // Check itemValues
            if (itemValues == null)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid item values");
                return false;
            }
            if (itemValues.Length != count)
            {
                log.WriteEntry("Error of the synchronous reading. Invalid item counts");
                return false;
            }
            for (int i = 1; i <= count; i++)
            {
                if (itemValues.GetValue(i) == null)
                {
                    log.WriteEntry("Error of the synchronous reading tag " + items[i - 1].ItemID + ". Null item value");
                    return false;
                }
            }

            OPCItem item;
            for (int i = 0; i < count; i++)
            {
                item = items[i];
                if (opcItems.ContainsKey(item))
                {
                    opcItems[item] = itemValues.GetValue(i + 1);
                }
            }
            return true;
        }
    }

    public class ODBCConnector : IDisposable
    {
        private bool disposed = false;
        private SingleEventLog log;
        private OdbcConnection conn;
        private OdbcCommand cmd;
        private DataTable dt;

        public event StateChangeEventHandler StateChange;

        public ConnectionState State
        {
            get
            {
                return conn.State;
            }
        }

        public ODBCConnector(SingleEventLog eventLog)
        {
            log = eventLog;
            conn = new OdbcConnection();
            conn.StateChange += ConnectionStateChange;
        }
        ~ODBCConnector()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (conn.State != ConnectionState.Closed) Disconnect();
                    conn.Dispose();
                }
            }
            disposed = true;
        }
        private void ConnectionStateChange(object sender, StateChangeEventArgs e)
        {
            if (StateChange != null) StateChange(this, e);
        }

        public void Connect(string dsn, string uid, string pwd)
        {
            if (conn.State == ConnectionState.Closed)
            {
                OdbcConnectionStringBuilder connStringBuilder = new OdbcConnectionStringBuilder();
                connStringBuilder.Dsn = dsn;
                connStringBuilder.Add("Uid", uid);
                connStringBuilder.Add("Pwd", pwd);

                conn.ConnectionString = connStringBuilder.ConnectionString;

                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    log.WriteEntry(e.Message);
                }
            }
        }
        public void Disconnect()
        {
            if (conn.State != ConnectionState.Closed)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    log.WriteEntry(e.Message);
                }
            }
        }
        public static Exception TestConnection(string dsn, string uid, string pwd)
        {
            OdbcConnectionStringBuilder connStringBuilder = new OdbcConnectionStringBuilder();
            connStringBuilder.Dsn = dsn;
            connStringBuilder.Add("Uid", uid);
            connStringBuilder.Add("Pwd", pwd);

            OdbcConnection testConn = new OdbcConnection(connStringBuilder.ConnectionString);

            try
            {
                testConn.Open();                
            }
            catch (Exception e)
            {
                return e;
            }
            finally
            {
                if (testConn.State == ConnectionState.Open) testConn.Close();
            }
            return null;
        }
        public bool GenerateCommand(string tableName, string fTranDT, string fCtrlDT, string fParID, string fParVal)
        {
            StringBuilder fullTableName = new StringBuilder();

            if (tableName.Contains("."))
            {
                string name;
                string[] split = tableName.Split('.');
                int length = split.Length;

                for (int i = 0; i < length; i++)
                {
                    name = split[i];
                    if (name.Contains("[") || name.Contains("]"))
                    {
                        if (i == 0) fullTableName.Append(name); else fullTableName.Append("." + name);
                    }
                    else
                    {
                        if (i == 0) fullTableName.Append("[" + name + "]"); else fullTableName.Append(".[" + name + "]");
                    }
                }
            }
            else
            {
                if (tableName.Contains("]") || tableName.Contains("["))
                {
                    fullTableName.Append(tableName);
                }
                else
                {
                    fullTableName.Append("[" + tableName + "]");
                }
            }

            dt = new DataTable(fullTableName.ToString());
            StringBuilder sqlIns = new StringBuilder("Insert into " + fullTableName.ToString() + " (");
            StringBuilder sqlVal = new StringBuilder(" Values (");
            List<OdbcParameter> parameters = new List<OdbcParameter>();
            bool prevPar = false;

            if (fTranDT != "")
            {
                sqlIns.Append(fTranDT);
                sqlVal.Append("?");
                OdbcParameter parameter = new OdbcParameter();
                parameter.ParameterName = "@tdt";
                parameter.OdbcType = OdbcType.DateTime;
                parameter.SourceColumn = fTranDT;
                parameters.Add(parameter);
                dt.Columns.Add(fTranDT, System.Type.GetType("System.DateTime"));
                prevPar = true;
            }
            if (fCtrlDT != "")
            {
                if (prevPar)
                {
                    sqlIns.Append(", " + fCtrlDT);
                    sqlVal.Append(", ?");
                }
                else
                {
                    sqlIns.Append(fCtrlDT);
                    sqlVal.Append("?");
                }
                OdbcParameter parameter = new OdbcParameter();
                parameter.ParameterName = "@dt";
                parameter.OdbcType = OdbcType.DateTime;
                parameter.SourceColumn = fCtrlDT;
                parameters.Add(parameter);
                dt.Columns.Add(fCtrlDT, System.Type.GetType("System.DateTime"));
                prevPar = true;
            }
            if (fParID != "")
            {
                if (prevPar)
                {
                    sqlIns.Append(", " + fParID);
                    sqlVal.Append(", ?");
                }
                else
                {
                    sqlIns.Append(fParID);
                    sqlVal.Append("?");
                }
                OdbcParameter parameter = new OdbcParameter();
                parameter.ParameterName = "@id";
                parameter.OdbcType = OdbcType.Int;
                parameter.SourceColumn = fParID;
                parameters.Add(parameter);
                dt.Columns.Add(fParID, System.Type.GetType("System.Int32"));
                prevPar = true;
            }
            if (fParVal != "")
            {
                if (prevPar)
                {
                    sqlIns.Append(", " + fParVal);
                    sqlVal.Append(", ?");
                }
                else
                {
                    sqlIns.Append(fParVal);
                    sqlVal.Append("?");
                }
                OdbcParameter parameter = new OdbcParameter();
                parameter.ParameterName = "@val";
                parameter.OdbcType = OdbcType.Real;
                parameter.SourceColumn = fParVal;
                parameters.Add(parameter);
                dt.Columns.Add(fParVal, System.Type.GetType("System.Single"));
            }
            sqlIns.Append(")");
            sqlVal.Append(")");

            if (parameters.Count > 0)
            {
                cmd = new OdbcCommand(sqlIns.ToString() + sqlVal.ToString(), conn);
                foreach (OdbcParameter par in parameters) cmd.Parameters.Add(par);
                return true;
            }
            else
            {
                cmd = null;
                return false;
            }                  
        }

        private void LogInvalidRecord(Record rec, object dt, object id, object val)
        {
            if (!rec.valid)
            {
                string message = "Record was dropped. ";

                if (rec.dtValid)
                {
                    message += "Timestamp " + dt + ". ";
                }
                else
                {
                    message += "Timestamp invalid. ";
                }
                if (rec.idValid)
                {
                    message += "ID #" + id + ". ";
                }
                else
                {
                    message += "ID invalid. ";
                }
                if (rec.valValid)
                {
                    message += "Value is " + val;
                }
                else
                {
                    message += "Value invalid";
                }

                log.WriteEntry(message);
            }
        }
        public bool MakeTransaction(Transaction tran)
        {
            if (conn.State == ConnectionState.Open && tran.opcConn.State == OPCState.Running)
            {
                int count;
                object objVal;                
                DateTime dtVal = DateTime.MinValue;
                int idVal = 0;               
                float floatVal = 0F;

                if (tran == null) return false;
                if (tran.records == null) return false;
                if (tran.records.Count == 0) return false;
                if (cmd == null) return false;

                if (!tran.opcConn.ReadDintItem(OPCDataSource.OPCCache, tran.tagCount, out count)) return false;
                if (count > tran.Size) count = tran.Size;

                // Synchronous reading OPC items
                Record rec;
                Dictionary<OPCItem, object> cache = new Dictionary<OPCItem, object>(count);

                for (int i = 0; i < count; i++)
                {
                    rec = tran.records[i];
                    cache.Add(rec.dt, null);
                    cache.Add(rec.id, null);
                    cache.Add(rec.val, null);
                }
                if (!tran.opcConn.SyncRead(OPCDataSource.OPCDevice, cache))
                {
                    return false;
                }

                // Validating                
                for (int i = 0; i < count; i++)
                {
                    rec = tran.records[i];

                    // PLC timestamp
                    if (cache.ContainsKey(rec.dt))
                    {
                        objVal = cache[rec.dt];
                        if (objVal != null)
                        {
                            if (objVal is DateTime)
                            {
                                dtVal = (DateTime)objVal;
                                rec.dtValid = true;
                            }
                            else
                            {
                                rec.dtValid = false;
                            }  
                        }
                        else
                        {
                            rec.dtValid = false;
                        }  
                    }
                    else
                    {
                        rec.dtValid = false;
                    }

                    // ID
                    if (cache.ContainsKey(rec.id))
                    {
                        objVal = cache[rec.id];
                        if (objVal != null)
                        {
                            if (objVal is int)
                            {
                                idVal = (int)objVal;
                                rec.idValid = true;
                            }
                            else
                            {
                                rec.idValid = false;
                            }
                        }
                        else
                        {
                            rec.idValid = false;
                        }
                    }
                    else
                    {
                        rec.idValid = false;
                    }

                    // Value
                    if (cache.ContainsKey(rec.val))
                    {
                        objVal = cache[rec.val];
                        if (objVal != null)
                        {
                            if (objVal is float)
                            {
                                floatVal = (float)objVal;
                                if (float.IsNaN(floatVal) || float.IsInfinity(floatVal))
                                {
                                    rec.valValid = false;
                                }
                                else
                                {
                                    rec.valValid = true;
                                }
                            }
                            else
                            {
                                rec.valValid = false;
                            }
                        }
                        else
                        {
                            rec.valValid = false;
                        }
                    }
                    else
                    {
                        rec.valValid = false;
                    }

                    rec.valid = rec.dtValid && rec.idValid && rec.valValid;
                    if (!rec.valid) LogInvalidRecord(rec, dtVal, idVal, floatVal);
                }

                bool isValid = false;
                for (int i = 0; i < count; i++)
                {
                    if (tran.records[i].valid)
                    {
                        isValid = true;
                        break;
                    }
                }
                // Not valid transactions
                if (!isValid)
                {
                    try
                    {
                        tran.tagCount.Write(0);
                    }
                    catch (Exception ex)
                    {
                        log.WriteEntry(ex.Message);
                    }
                    return false;
                }

                // Start a local transaction
                OdbcDataAdapter da = new OdbcDataAdapter();
                OdbcTransaction transaction;
                DateTime dtNow = DateTime.Now;

                try
                {
                    transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    da.InsertCommand = cmd;
                }
                catch (Exception e)
                {
                    // A transaction is currently active. 
                    // Parallel transactions are not supported
                    log.WriteEntry(e.Message);
                    return false;
                }

                DataTable newRecords = dt.Copy();
                DataRow newRow;

                for (int i = 0; i < count; i++)
                {
                    rec = tran.records[i];
                    if (rec.valid)
                    {
                        newRow = newRecords.NewRow();

                        foreach (OdbcParameter par in cmd.Parameters)
                        {
                            switch (par.ParameterName)
                            {
                                case "@tdt":
                                    newRow[par.SourceColumn] = dtNow;
                                    break;
                                case "@dt":
                                    if (cache.ContainsKey(rec.dt))
                                    {
                                        objVal = cache[rec.dt];
                                        if (objVal is DateTime)
                                        {
                                            newRow[par.SourceColumn] = (DateTime)objVal;
                                            break;
                                        }
                                    }
                                    // Attempt to roll back the transaction.
                                    transaction.Rollback();
                                    cmd.Transaction = null;
                                    return false;

                                case "@id":
                                    if (cache.ContainsKey(rec.id))
                                    {
                                        objVal = cache[rec.id];
                                        if (objVal is int)
                                        {
                                            newRow[par.SourceColumn] = (int)objVal;
                                            break;
                                        }
                                    }
                                    // Attempt to roll back the transaction.
                                    transaction.Rollback();
                                    cmd.Transaction = null;
                                    return false;

                                case "@val":
                                    if (cache.ContainsKey(rec.val))
                                    {
                                        objVal = cache[rec.val];
                                        if (objVal is float)
                                        {
                                            newRow[par.SourceColumn] = (float)objVal;
                                            break;
                                        }
                                    }
                                    // Attempt to roll back the transaction.
                                    transaction.Rollback();
                                    cmd.Transaction = null;
                                    return false;
                            }
                        }
                        newRecords.Rows.Add(newRow);
                    }
                }

                if (newRecords.Rows.Count > 0)
                {
                    try
                    {
                        da.Update(newRecords);
                    }
                    catch (Exception e)
                    {
                        log.WriteEntry(e.Message);
                        try
                        {
                            // Attempt to roll back the transaction.
                            transaction.Rollback();
                            cmd.Transaction = null;
                            return false;
                        }
                        catch (Exception ex)
                        {
                            log.WriteEntry(ex.Message);
                            cmd.Transaction = null;
                            return false;
                        }
                    }

                    // Commit the transaction.
                    try
                    {
                        transaction.Commit();
                        cmd.Transaction = null;
                        tran.tagCount.Write(0);
                    }
                    catch (Exception ex)
                    {
                        log.WriteEntry(ex.Message);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class Record
    {
        public OPCItem dt;
        public OPCItem id;
        public OPCItem val;
        public bool valid;
        public bool dtValid;
        public bool idValid;
        public bool valValid;
    }

    public class Statistics
    {
        private ulong total = 0UL;
        private ulong passed = 0UL;
        private ulong failed = 0UL;

        public Statistics()
        {
        }
        public Statistics(Statistics stat)
        {
            total = stat.Total;
            passed = stat.Passed;
            failed = stat.Failed;
        }

        public void Clear()
        {
            total = 0UL;
            passed = 0UL;
            failed = 0UL;
        }
        public void Pass()
        {
            if (total == ulong.MaxValue) Clear();
            passed++;
            total++;            
        }
        public void Fail()
        {
            if (total == ulong.MaxValue) Clear();
            failed++;
            total++;
        }

        public ulong Failed
        {
            get
            {
                return failed;
            }
        }
        public ulong Passed
        {
            get
            {
                return passed;
            }
        }
        public float Percent
        {
            get
            {
                return total > 0UL ? (float)(100D * (double)passed / (double)total) : 0f;
            }
        }
        public ulong Total
        {
            get
            {
                return total;
            }
        }
    }
        
    public class Transaction
    {
        private int size = 0;
        private SingleEventLog log;
        private BackgroundWorker bgwOPCConn;
        private BackgroundWorker bgwODBCConn;
        private BackgroundWorker bgwTransact;

        public Statistics stat;
        public OPCSimaticNet opcConn;
        public ODBCConnector odbcConn;
        public OPCItem tagSize = null;
        public OPCItem tagCount = null;
        public string tranName = "";
        public string S7ConnName = "";
        public int S7DbNumber = 0;
        public bool active = false;
        public bool error = false;
        private bool disconnectOPC = false;
        public List<Record> records;

        public event StateChangeEventHandler ODBCConnStateChange;
        public event OPCStateEventHandler OPConnStateChange;
        public event StatisticsEventHandler Statistics;

        public bool IsBusy
        {
            get
            {
                return bgwOPCConn.IsBusy || bgwODBCConn.IsBusy || bgwTransact.IsBusy;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }

        public Transaction(SingleEventLog eventLog)
        {
            log = eventLog;
            
            stat = new Statistics();
            
            odbcConn = new ODBCConnector(log);
            odbcConn.StateChange += ODBCStateChange;

            opcConn = new OPCSimaticNet(log);
            opcConn.DataChanged += OPCDataChanged;
            opcConn.StateChange += OPCStateChange;

            bgwOPCConn = new BackgroundWorker();
            bgwOPCConn.DoWork += OPCConnecting;
            bgwOPCConn.RunWorkerCompleted += OPCConnected;
            bgwOPCConn.WorkerSupportsCancellation = true;
            
            bgwODBCConn = new BackgroundWorker();
            bgwODBCConn.DoWork += ODBCConnecting;
            bgwODBCConn.RunWorkerCompleted += ODBCConnected;
            bgwODBCConn.WorkerSupportsCancellation = true;

            bgwTransact = new BackgroundWorker();
            bgwTransact.DoWork += MakeTransactions;
            bgwTransact.WorkerSupportsCancellation = true;
        }
        public void ConnectToODBC()
        {
            if (!(odbcConn.State == ConnectionState.Open || odbcConn.State == ConnectionState.Connecting || bgwODBCConn.IsBusy))
            {
                bgwODBCConn.RunWorkerAsync();
            }
        }
        public void DisconnectFromODBC()
        {
            if (bgwODBCConn.IsBusy)
            {
                bgwODBCConn.CancelAsync();
                while (bgwODBCConn.IsBusy) Application.DoEvents();
            }
            if (odbcConn.State != ConnectionState.Closed) odbcConn.Disconnect();
        }
        public void ConnectToOPC()
        {
            disconnectOPC = false;
            if (opcConn.State != OPCState.Running)
            {
                active = false;
                if (bgwTransact.IsBusy)
                {
                    bgwTransact.CancelAsync();
                    while (bgwTransact.IsBusy) Application.DoEvents();
                }
                if (!bgwOPCConn.IsBusy) bgwOPCConn.RunWorkerAsync();
            }
        }
        public void DisconnectFromOPC()
        {
            disconnectOPC = true;
            StopTransact();
            if (bgwOPCConn.IsBusy)
            {
                bgwOPCConn.CancelAsync();
                while (bgwOPCConn.IsBusy) Application.DoEvents();
            }
            tagSize = null;
            tagCount = null;
            if (records != null)
            {
                records.Clear();
                records = null;
            }
            opcConn.Disconnect();
        }
        public void StopTransact()
        {
            active = false;
            if (bgwTransact.IsBusy)
            {
                bgwTransact.CancelAsync();
                while (bgwTransact.IsBusy) Application.DoEvents();
            }
        }

        private void OPCConnecting(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (opcConn.State != OPCState.Running)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    opcConn.Connect(Config.Sets.Primary_OPC_Node, Config.Sets.UpdateRate);
                }
                catch (Exception ex)
                {
                    log.WriteEntry(ex.Message);
                }
                if (opcConn.State != OPCState.Running)
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        Application.DoEvents();
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            Thread.Sleep(100);
                        }
                    }                
                }
            }
        }
        private void OPCConnected(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled || disconnectOPC))
            {
                bool result = false;

                tagSize = opcConn.AddItem(S7ConnName, "DB" + S7DbNumber + ",DINT0");
                tagCount = opcConn.AddTrigger(S7ConnName, "DB" + S7DbNumber + ",DINT4");
                if (tagSize == null || tagCount == null)
                {
                    if (!disconnectOPC)
                    {
                        opcConn.Disconnect();
                        if (!bgwOPCConn.IsBusy) bgwOPCConn.RunWorkerAsync();
                    }
                    return;
                }

                // Reading of the clipboard size
                for (int i = 0; i < 10; i++)
                {
                    result = opcConn.ReadDintItem(OPCDataSource.OPCDevice, tagSize, out size);
                    if (result)
                    {
                        break;
                    }
                    else
                    {
                        Application.DoEvents();
                        Thread.Sleep(1000);
                    }
                }
                // Error of reading of the clipboard size
                if (!result)
                {
                    return;
                }
                // Creation of records for the clipboard
                if (size > 0)
                {
                    bool error = false;
                    records = new List<Record>(size);
                    for (int i = 0; i < size; i++)
                    {
                        Record rec = new Record();
                        rec.dt = opcConn.AddItem(S7ConnName, "DB" + S7DbNumber + ",DT" + (8 + 16 * i));
                        if (rec.dt != null)
                        {
                            rec.id = opcConn.AddItem(S7ConnName, "DB" + S7DbNumber + ",DINT" + (16 + 16 * i));
                            if (rec.id != null)
                            {
                                rec.val = opcConn.AddItem(S7ConnName, "DB" + S7DbNumber + ",REAL" + (20 + 16 * i));
                                if (rec.val != null)
                                {
                                    records.Add(rec);
                                }
                                else
                                {
                                    error = true;
                                    break;
                                }
                            }
                            else
                            {
                                error = true;
                                break;
                            }
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }
                    if (error)
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                opcConn.IsSubscribed = true;
                //bgwTransact.RunWorkerAsync();
            }
            else
            {
                if (opcConn.State != OPCState.Disconnected)
                {
                    try
                    {
                        opcConn.Disconnect();
                    }
                    catch (Exception ex)
                    {
                        log.WriteEntry(ex.Message);
                    }
                }
            }
        }
        private void ODBCConnecting(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (odbcConn.State != ConnectionState.Open)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                try
                {
                    String dsn = Config.Sets.Primary_ODBC_DSN;
                    String uid = Config.Sets.Primary_ODBC_User;
                    String pwd = Config.Sets.Primary_ODBC_Pass;
                    odbcConn.Connect(dsn, uid, pwd);
                }
                catch (Exception ex)
                {
                    log.WriteEntry(ex.Message);
                }
                if (odbcConn.State != ConnectionState.Open)
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        if (worker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            Application.DoEvents();
                            Thread.Sleep(100);
                        }
                    }
                }
            }

        }
        private void ODBCConnected(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                try
                {
                    if (odbcConn.State != ConnectionState.Closed) odbcConn.Disconnect();
                }
                catch (Exception ex)
                {
                    log.WriteEntry(ex.Message);
                }
            }
        }
        private void MakeTransactions(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            bool resultOK;
            while (active && !worker.CancellationPending)
            {
                Application.DoEvents();
                if (odbcConn.State == ConnectionState.Open)
                {
                    if (error) Thread.Sleep(1000);
                    if (worker.CancellationPending) break;
                    try
                    {
                        resultOK = odbcConn.MakeTransaction(this);
                    }
                    catch
                    {
                        resultOK = false;
                    }
                    if (resultOK)
                    {
                        active = false;
                        error = false;
                        stat.Pass();
                    }
                    else
                    {
                        error = true;
                        stat.Fail();
                    }
                    if (Statistics != null) Statistics(this, new ConfigStatisticsEventArgs(this));
                }
                else
                {
                    if (!worker.CancellationPending) ConnectToODBC();
                    Thread.Sleep(1000);
                }
            }
        }

        // Events
        private void OPCDataChanged(object sender, OPCDataEventArgs e)
        {
            int count = e.Value is int ? (int)e.Value : 0;
            if (count > 0)
            {
                active = true;
                if (!bgwTransact.IsBusy) bgwTransact.RunWorkerAsync();
            }
        }
        private void OPCStateChange(object sender, OPCStateEventArgs e)
        {
            if (e.State != OPCState.Running) active = false;
            if (OPConnStateChange != null) OPConnStateChange(this, e);
            if (Statistics != null) Statistics(this, new ConfigStatisticsEventArgs(this));
        }        
        private void ODBCStateChange(object sender, StateChangeEventArgs e)
        {
            if (ODBCConnStateChange != null) ODBCConnStateChange(this, e);
            if (Statistics != null) Statistics(this, new ConfigStatisticsEventArgs(this));
        }
    }

    public class OPCUA
    {
        ////////////////////////////////////////////////////////////////////// OPCUA //////////////////////////////////////////////////////////////////////

        #region Fields
        private Session mySession;
        private UAClientHelperAPI myClientHelperAPI;
        private UAClientHelperAPI newMyClientHelperAPI;
        private EndpointDescription mySelectedEndpoint;
        public EndpointDescriptionCollection edcEndpoints;
        private static bool processExe = false;
        private string savedServers = null;
        private OdbcConnectionStringBuilder connStringBuilder = new OdbcConnectionStringBuilder();
        private static BackgroundWorker BGW_OPCUA = null;
        private static BackgroundWorker BGW_AutoConnect = null;
        private List<string[]> myStructList;

        private static ConfigConnectStateOPCUA connectStateOPCUA = ConfigConnectStateOPCUA.Connecting;
        public delegate void ConfigConnectStateOPCUAEventHandler(object sender, ConfigConnectStateOPCUAEventArgs e);
        public static event ConfigConnectStateOPCUAEventHandler ConnectStateChangeOPCUA;
        public static ConfigConnectStateOPCUA ConnectStateOPCUA
        {
            get
            {
                return connectStateOPCUA;
            }
        }
        #endregion
        private void BGW_AutoConnect_DoWork(object sender_DW, DoWorkEventArgs e_DW)
        {
            while (true)
            {
                if (Config.Sets.Running_OPCUA)
                {
                    searchEndpoint(Config.Sets.Primary_OPCUA_Node);
                }
                Thread.Sleep(5000);
            }   
        }

        public void searchEndpoint(string discoveryUrl)
        {
            /// ClientHelperAPI
            //myClientHelperAPI = new UAClientHelperAPI();
            newMyClientHelperAPI = new UAClientHelperAPI();
            try
            {
                Console.WriteLine("TryToSearchEndpoint");
                
                ApplicationDescriptionCollection servers = newMyClientHelperAPI.FindServers(discoveryUrl);

                if (!(savedServers == servers.ElementAt(0).DiscoveryUrls.ElementAt(0).ToString()))
                {
                    savedServers = servers.ElementAt(0).DiscoveryUrls.ElementAt(0).ToString();
                    if (savedServers == null)
                    {
                        //ToDo
                    }
                    else
                    {
                        foreach (ApplicationDescription ad in servers)
                        {
                            foreach (string url in ad.DiscoveryUrls)
                            {
                                EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(url);
                                edcEndpoints = endpoints;
                                mySelectedEndpoint = endpoints.ElementAt(0);
                                connectToServer();
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                connectStateOPCUA = ConfigConnectStateOPCUA.Connecting;
                if (ConnectStateChangeOPCUA != null) ConnectStateChangeOPCUA(null, new ConfigConnectStateOPCUAEventArgs(connectStateOPCUA));
                disConnectFromServer();
                Console.WriteLine("searchEndpoint : Error message:" + ex.Message);
            }
        }

        public void connectToServer()
        {
            if (mySession != null && !mySession.Disposed)
            {
                //ToDo
            }
            else
            {
                try
                {
                    //Register mandatory events (cert and keep alive)
                    myClientHelperAPI.KeepAliveNotification += new KeepAliveEventHandler(Notification_KeepAlive);
                    myClientHelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(Notification_ServerCertificate);

                    //Check for a selected endpoint
                    if (mySelectedEndpoint != null)
                    {
                        //Call connect
                        myClientHelperAPI.Connect(mySelectedEndpoint, false, "", "");
                        //Extract the session object for further direct session interactions
                        mySession = myClientHelperAPI.Session;
                        
                        if (Config.Sets.Primary_ODBC_DSN != "")
                        {
                            connStringBuilder.Dsn = Config.Sets.Primary_ODBC_DSN;
                            connStringBuilder.Add("Uid", Config.Sets.Primary_ODBC_User);
                            connStringBuilder.Add("Pwd", Config.Sets.Primary_ODBC_Pass);
                        }
                        connectStateOPCUA = ConfigConnectStateOPCUA.ConnectEstablish;
                        if (ConnectStateChangeOPCUA != null) ConnectStateChangeOPCUA(null, new ConfigConnectStateOPCUAEventArgs(connectStateOPCUA));
                        Console.WriteLine("ConnectToServer Is Done");
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Error");
                    Console.WriteLine("connectToServer : Error message:" + ex.Message);
                }
            } 
        }

        public void disConnectFromServer()
        {
            //Check if sessions exists; If yes > delete subscriptions and disconnect
            try 
            {
                if (mySession != null && !mySession.Disposed)
                {
                    //myClientHelperAPI.Disconnect();
                    savedServers = null;
                    myStructList = null;
                    mySession = myClientHelperAPI.Session;
                    Console.WriteLine("DisconnectFromServer Is Done");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
                Console.WriteLine("disConnectFromServer : Error message:" + ex.Message);
            }

        }

        public void start_BGW_OPCUA()
        {
            if (!processExe)
            {
                string processName = "DataLogger";
                processExe = Process.GetProcesses().Any(p => p.ProcessName == processName);

                BGW_OPCUA = new BackgroundWorker();
                BGW_OPCUA.WorkerReportsProgress = true;
                BGW_OPCUA.WorkerSupportsCancellation = true;
                BGW_OPCUA.DoWork += BGW_OPCUA_DoWork;
                BGW_OPCUA.RunWorkerCompleted += BGW_OPCUA_RunWorkerCompleted;

                BGW_AutoConnect = new BackgroundWorker();
                BGW_AutoConnect.WorkerReportsProgress = true;
                BGW_AutoConnect.WorkerSupportsCancellation = true;
                BGW_AutoConnect.DoWork += BGW_AutoConnect_DoWork;
                
                if (!BGW_AutoConnect.IsBusy)
                {
                    BGW_AutoConnect.RunWorkerAsync();
                }
            }
            try
            {
                myClientHelperAPI = new UAClientHelperAPI();

                if (!BGW_OPCUA.IsBusy)
                {
                    BGW_OPCUA.RunWorkerAsync();
                }
                else
                {
                    Config.Log.WriteEntry("The configuration OPCUA was started already");
                    Console.WriteLine("The configuration OPCUA was started already");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void stop_BGW_OPCUA()
        {
            savedServers = null;

            if (BGW_OPCUA.IsBusy)
            {
                BGW_OPCUA.CancelAsync();
            }
            else
            {
                Config.Log.WriteEntry("The configuration OPCUA wasn't started");
                Console.WriteLine("The configuration OPCUA wasn't started");
            }
        }


        private void BGW_OPCUA_DoWork(object sender_DW, DoWorkEventArgs e_DW)
        {
        while (true)
            {
                int count = Decimal.ToInt32(Config.Sets.Primary_SQL_NumberOfRec);
                myStructList = new List<string[]>();
                List<String> values = new List<string>();
                List<String> nodeIdStrings = new List<string>();
                try
                {
                    if (BGW_OPCUA.CancellationPending)
                    {
                        e_DW.Cancel = true;
                        return;
                    }
                    if ((connectStateOPCUA == ConfigConnectStateOPCUA.ConnectEstablish) && !e_DW.Cancel)
                    {
                        try
                        {
                            myStructList = myClientHelperAPI.ReadStructUdt("ns=3;s=\"" + Config.Sets.Primary_S7_DBName + "\".\"" + Config.Sets.Primary_OPCUA_RecArray + "\"");
                        }
                        catch (Exception ex)
                        {
                            if (BGW_OPCUA.IsBusy) BGW_OPCUA.CancelAsync();
                            Config.StopOPCUA();
                            Config.Save();
                            MessageBox.Show(ex.Message, "Error");
                        }

                        if (count > myStructList.Count / 5)
                        {
                            count = myStructList.Count / 5;
                            //numericRecordsCount.Invoke(new Action(() => numericRecordsCount.Maximum = count));
                        }
                        string[] row = new string[3 * count];
                        for (int j = 0; j < count; j++)
                        {
                            row[3 * j] = myStructList[j * 5 + 3].ElementAt(1);
                            row[3 * j + 1] = myStructList[j * 5 + 4].ElementAt(1);
                            row[3 * j + 2] = myStructList[j * 5 + 2].ElementAt(1);
                        }
                        
                        InsertRow(count, row);
                        
                        // Обнуление счётчика
                        values.Clear();
                        values.Add("0");
                        nodeIdStrings.Clear();
                        nodeIdStrings.Add("ns=3;s=\"" + Config.Sets.Primary_S7_DBName + "\".\"" + Config.Sets.Primary_OPCUA_RecResetCount + "\"");
                        try
                        {
                            myClientHelperAPI.WriteValues(values, nodeIdStrings);
                        }
                        catch (Exception ex)
                        {
                            Config.StopOPCUA();
                            Config.Save();
                            MessageBox.Show(ex.Message, "Error");
                        }
                        Thread.Sleep(200);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BGW_OPCUA_DoWork exception:" + ex.Message);
                    Config.StopOPCUA();
                    Config.Save();
                    MessageBox.Show(ex.Message, "Error");
                }
            }
               
        }

        private void BGW_OPCUA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e_RWC)
        {
            if (e_RWC.Cancelled)
                Console.WriteLine("Работа BackgroundWorker была прервана пользователем!");
            else if (e_RWC.Error != null)
                MessageBox.Show("Worker exception: " + e_RWC.Error);
            else
                Console.WriteLine("Работа закончена успешно.");
            Config.StopOPCUA();
            Config.Save();
        }
        
        private void InsertRow(int count, string[] row)
        {
            try
            {
                StringBuilder queryString = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    queryString.Append("INSERT INTO " + Config.Sets.Primary_SQL_TableName + " (" + Config.Sets.Primary_SQL_IDColName + ", " + Config.Sets.Primary_SQL_ValColName + ", " + Config.Sets.Primary_SQL_DATColName + ") Values(" + row[3 * i] + ", " + row[3 * i + 1] + ", '" + row[3 * i + 2] + "')");
                }

                OdbcCommand command = new OdbcCommand(queryString.ToString());

                using (OdbcConnection connection = new OdbcConnection(connStringBuilder.ToString()))
                {
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    // The connection is automatically closed at the end of the Using block.
                }
                queryString.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertRow exception:" + ex.Message);
                Config.StopOPCUA();
                Config.Save();
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #region OpcEventHandlers
        public void Notification_ServerCertificate(CertificateValidator cert, CertificateValidationEventArgs e)
        {
            //Handle certificate here
            //To accept a certificate manually move it to the root folder (Start > mmc.exe > add snap-in > certificates)
            //Or handle via UAClientCertForm
            /*
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CertificateValidationEventHandler(Notification_ServerCertificate), cert, e);
                return;
            }
            */
            try
            {
                //Search for the server's certificate in store; if found -> accept
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509CertificateCollection certCol = store.Certificates.Find(X509FindType.FindByThumbprint, e.Certificate.Thumbprint, true);
                store.Close();
                if (certCol.Capacity > 0)
                {
                    e.Accept = true;
                }
                //Show cert dialog if cert hasn't been accepted yet
                else
                {
                    /*
                    if (!e.Accept & myCertForm == null)
                    {
                        myCertForm = new UAClientCertForm(e);
                        myCertForm.ShowDialog();
                    }
                    */
                }
            }
            catch
            {
                ;
            }
        }

        public void Notification_MonitoredItem(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            /*
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MonitoredItemNotificationEventHandler(Notification_MonitoredItem), monitoredItem, e);
                return;
            }
            */
            MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;
            if (notification == null)
            {
                return;
            }
        }

        public void Notification_KeepAlive(Session sender, KeepAliveEventArgs e)
        {
            /*
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new KeepAliveEventHandler(Notification_KeepAlive), sender, e);
                return;
            }
            */

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(sender, mySession))
                {
                    return;
                }

                // check for disconnected session.
                if (!ServiceResult.IsGood(e.Status))
                {
                    // try reconnecting using the existing session state
                    mySession.Reconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion
    }
}