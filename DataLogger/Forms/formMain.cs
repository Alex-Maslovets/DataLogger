using System;
using System.Data;
using System.Windows.Forms;
using DataLogger.Properties;
using DataManager;
using Tools;

namespace DataLogger
{
    delegate void NewStatisticsCallback(Form form, DataTable dt, ConfigStatisticsEventArgs e);
    
    public partial class formMain : Form
    {
        private bool closing = false;
        
        public formMain()
        {
            InitializeComponent();
        }        

        private void frmMain_Load(object sender, EventArgs e)
        {
            hide();
            UpdateConfigState(Config.State);
            UpdateConfigStateOPCUA(Config.StateOPCUA);
            Config.StateChange += ConfigStateChange;
            Config.StateChangeOPCUA += ConfigStateChangeOPCUA;
            OPCUA.ConnectStateChangeOPCUA += ConfigConnectStateChangeOPCUA;
            savedInfoGridView_Update();
            Config.Statistics += ConfigStatistics;
        }

        private void ConfigStateChange(object sender, ConfigStateEventArgs e)
        {
            UpdateConfigState(e.State);
        }

        private void ConfigStateChangeOPCUA(object sender, ConfigStateOPCUAEventArgs e)
        {
            UpdateConfigStateOPCUA(e.State);
        }

        private void ConfigConnectStateChangeOPCUA(object sender, ConfigConnectStateOPCUAEventArgs e)
        {
            UpdateConfigConnectStateOPCUA(e.State);
        }

        private void UpdateRowStatistics(DataRow row, ConfigStatisticsEventArgs e)
        {
            row["OPC"] = e.OPCConnState;
            row["ODBC"] = e.ODBCConnState;
            row["Total"] = e.TransactionStatistics.Total;
            row["Passed"] = e.TransactionStatistics.Passed;
            row["Failed"] = e.TransactionStatistics.Failed;
            row["% Passed"] = e.TransactionStatistics.Percent;
        }
        
        private void NewStatistics(Form form, DataTable dt, ConfigStatisticsEventArgs e)
        {
            if (form.InvokeRequired)
            {
                NewStatisticsCallback callback = new NewStatisticsCallback(NewStatistics);
                form.Invoke(callback, form, dt, e);
            }
            else
            {
                DataRow[] foundRows = dt.Select("Transaction = '" + e.TransactionName + "'");
                if (foundRows.Length > 0)
                {
                    foreach (DataRow row in foundRows) UpdateRowStatistics(row, e);
                }
                else
                {
                    DataRow row = dt.NewRow();
                    row["Transaction"] = e.TransactionName;
                    UpdateRowStatistics(row, e);
                    dt.Rows.Add(row);                    
                }
            }
        }
        
        private void ConfigStatistics(object sender, ConfigStatisticsEventArgs e)
        {
            NewStatistics(this, dtTransaction, e);
        }

        private void UpdateConfigState(ConfigState state)
        {
            trayNotifyIcon.Text = Application.ProductName + " - " + state.ToString();            

            SafeThread.SetTextStripItem(statusbar, statusConfigLabel, "Configuration state: " + state.ToString());
            switch (state)
            {
                case ConfigState.Starting:
                    trayNotifyIcon.Icon = Properties.Resources.servicepaused;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Pause);
                    SafeThread.SetEnableStripItem(toolbar, startButton, false);
                    SafeThread.SetEnableStripItem(menu, startMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, startTrayMenuItem, false);
                    SafeThread.SetEnableStripItem(toolbar, stopButton, true);
                    SafeThread.SetEnableStripItem(menu, stopMenuItem, true);
                    SafeThread.SetEnableStripItem(trayMenu, stopTrayMenuItem, true);
                    break;
                case ConfigState.Started:
                    trayNotifyIcon.Icon = Properties.Resources.servicerunning;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Run);
                    SafeThread.SetEnableStripItem(toolbar, startButton, false);
                    SafeThread.SetEnableStripItem(menu, startMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, startTrayMenuItem, false);
                    SafeThread.SetEnableStripItem(toolbar, stopButton, true);
                    SafeThread.SetEnableStripItem(menu, stopMenuItem, true);
                    SafeThread.SetEnableStripItem(trayMenu, stopTrayMenuItem, true);
                    break;
                case ConfigState.Stopping:
                    trayNotifyIcon.Icon = Properties.Resources.servicepaused;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Pause);
                    SafeThread.SetEnableStripItem(toolbar, startButton, false);
                    SafeThread.SetEnableStripItem(menu, startMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, startTrayMenuItem, false);
                    SafeThread.SetEnableStripItem(toolbar, stopButton, false);
                    SafeThread.SetEnableStripItem(menu, stopMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, stopTrayMenuItem, false);
                    break;
                case ConfigState.Stopped:
                    trayNotifyIcon.Icon = Properties.Resources.servicestopped;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Stop);
                    if (Config.Ready)
                    {
                        SafeThread.SetEnableStripItem(toolbar, startButton, true);
                        SafeThread.SetEnableStripItem(menu, startMenuItem, true);
                        SafeThread.SetEnableStripItem(trayMenu, startTrayMenuItem, true);
                    }
                    else
                    {
                        SafeThread.SetEnableStripItem(toolbar, startButton, false);
                        SafeThread.SetEnableStripItem(menu, startMenuItem, false);
                        SafeThread.SetEnableStripItem(trayMenu, startTrayMenuItem, false);
                    }
                    SafeThread.SetEnableStripItem(toolbar, stopButton, false);
                    SafeThread.SetEnableStripItem(menu, stopMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, stopTrayMenuItem, false);
                    break;
            }
        }

        private void UpdateConfigStateOPCUA(ConfigStateOPCUA state)
        {
            trayNotifyIcon.Text = Application.ProductName + " - " + state.ToString();
            SafeThread.SetTextStripItem(statusbar, statusConfigLabel, "Configuration state: " + state.ToString());
            switch (state)
            {
                case ConfigStateOPCUA.Started:
                    trayNotifyIcon.Text = Application.ProductName + " - OPCUA" + " - " + state.ToString();
                    trayNotifyIcon.Icon = Properties.Resources.servicerunning;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Run);
                    SafeThread.SetEnableStripItem(toolbar, startOPCUAButton, false);
                    SafeThread.SetEnableStripItem(menu, startOPCUAMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, startOPCUATrayMenuItem, false);
                    SafeThread.SetEnableStripItem(toolbar, stopOPCUAButton, true);
                    SafeThread.SetEnableStripItem(menu, stopOPCUAMenuItem, true);
                    SafeThread.SetEnableStripItem(trayMenu, stopOPCUATrayMenuItem, true);
                    break;
                case ConfigStateOPCUA.Stopped:
                    trayNotifyIcon.Text = Application.ProductName + " - OPCUA" + " - " + state.ToString();
                    trayNotifyIcon.Icon = Properties.Resources.servicestopped;
                    SafeThread.SetImageStripItem(statusbar, statusConfigLabel, Resources.Stop);
                    if (Config.ReadyOPCUA)
                    {
                        SafeThread.SetEnableStripItem(toolbar, startOPCUAButton, true);
                        SafeThread.SetEnableStripItem(menu, startOPCUAMenuItem, true);
                        SafeThread.SetEnableStripItem(trayMenu, startOPCUATrayMenuItem, true);
                    }
                    else
                    {
                        SafeThread.SetEnableStripItem(toolbar, startOPCUAButton, false);
                        SafeThread.SetEnableStripItem(menu, startOPCUAMenuItem, false);
                        SafeThread.SetEnableStripItem(trayMenu, startOPCUATrayMenuItem, false);
                    }
                    SafeThread.SetEnableStripItem(toolbar, stopOPCUAButton, false);
                    SafeThread.SetEnableStripItem(menu, stopOPCUAMenuItem, false);
                    SafeThread.SetEnableStripItem(trayMenu, stopOPCUATrayMenuItem, false);
                    break;
            }
        }

        private void UpdateConfigConnectStateOPCUA(ConfigConnectStateOPCUA state)
        {
            switch (state)
            {
                case ConfigConnectStateOPCUA.ConnectEstablish:
                    SafeThread.SetImageStripItem(statusbar, statusConnectOPCUALabel, Resources.OK);
                    break;
                case ConfigConnectStateOPCUA.Connecting:
                    SafeThread.SetImageStripItem(statusbar, statusConnectOPCUALabel, Resources.Critical_Blink);
                    break;
            }
        }

        public void savedInfoGridView_Update()
        {
            try
            {
                savedInfoGridView.Rows.Clear();
                string[] row1 = new string[] { "S7. OPCUA Server Name", Config.Sets.Primary_OPCUA_Node };
                string[] row2 = new string[] { "S7. Data Block Name", Config.Sets.Primary_S7_DBName };
                string[] row3 = new string[] { "S7. Record Array Name", Config.Sets.Primary_OPCUA_RecArray };
                string[] row4 = new string[] { "S7. Reset Tag Name", Config.Sets.Primary_OPCUA_RecResetCount };
                string[] row5 = new string[] { "S7. Number of Records", Config.Sets.Primary_SQL_NumberOfRec.ToString() };
                string[] row6 = new string[] { "SQL Table Name", Config.Sets.Primary_SQL_TableName };
                string[] row7 = new string[] { "SQL. ID Column Name", Config.Sets.Primary_SQL_IDColName };
                string[] row8 = new string[] { "SQL. Value Column Name", Config.Sets.Primary_SQL_ValColName };
                string[] row9 = new string[] { "SQL. Time Column Name", Config.Sets.Primary_SQL_DATColName };

                object[] savedRows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9 };
                foreach (string[] rowArray in savedRows)
                {
                    savedInfoGridView.Rows.Add(rowArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void defineOPC()
        {
            formDefineOPC form = new formDefineOPC();
            form.ShowDialog(this);
        }

        private void defineOPCUA()
        {
            formDefineOPCUA form = new formDefineOPCUA();
            form.ShowDialog(this);
            checkStartOPCUAPossibility();
        }

        private void defineODBC()
        {
            formDefineODBC form = new formDefineODBC();
            form.ShowDialog(this);            
            checkStartPossibility();
        }

        private void defineTransaction()
        {
            formDefineTran form = new formDefineTran();
            form.ShowDialog(this);
            checkStartPossibility();
        }

        private void about()
        {
            formAbout form = new formAbout();
            form.ShowDialog(this);
        }

        private void checkStartPossibility()
        {
            if (!Config.Sets.Running)
            {
                if (Config.Ready)
                {
                    startButton.Enabled = true;
                    startMenuItem.Enabled = true;
                    startTrayMenuItem.Enabled = true;
                }
                else
                {
                    startButton.Enabled = false;
                    startMenuItem.Enabled = false;
                    startTrayMenuItem.Enabled = false;
                }
            }
        }

        private void checkStartOPCUAPossibility()
        {
            if (!Config.Sets.Running_OPCUA)
            {
                if (Config.ReadyOPCUA)
                {
                    startOPCUAButton.Enabled = true;
                    startOPCUAMenuItem.Enabled = true;
                    startOPCUATrayMenuItem.Enabled = true;
                }
                else
                {
                    startOPCUAButton.Enabled = false;
                    startOPCUAMenuItem.Enabled = false;
                    startOPCUATrayMenuItem.Enabled = false;
                }
            }
        }

        private void start(bool saving)
        {
            Config.Start();
            if (saving) Config.Save();
        }

        private void stop(bool saving)
        {
            Config.Stop();
            if (saving) Config.Save();
        }

        private void startOPCUA(bool saving)
        {
            Config.StartOPCUA();
            if (saving) Config.Save();
        }

        private void stopOPCUA(bool saving)
        {
            Config.StopOPCUA();
            if (saving) Config.Save();
        }

        private void exit()
        {
            DialogResult result = MessageBox.Show("Application will be closed. You sure?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                closing = true;
                Close();
            }
        }

        private void hide()
        {
            foreach (Form form in OwnedForms) form.Close();
            this.Hide();
            hideTrayMenuItem.Visible = false;
            restoreTrayMenuItem.Visible = true;
        }

        private void restore()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            hideTrayMenuItem.Visible = true;
            restoreTrayMenuItem.Visible = false;
        }

        private void opcConnectorMenuItem_Click(object sender, EventArgs e)
        {
            defineOPC();
        }

        private void opcConnectorButton_Click(object sender, EventArgs e)
        {
            defineOPC();
        }

        private void odbcConnectorMenuItem_Click(object sender, EventArgs e)
        {
            defineODBC();
        }

        private void odbcConnectorButton_Click(object sender, EventArgs e)
        {
            defineODBC();
        }

        private void transactionMenuItem_Click(object sender, EventArgs e)
        {
            defineTransaction();
        }

        private void transactionButton_Click(object sender, EventArgs e)
        {
            defineTransaction();
        }

        private void OPCUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defineOPCUA();
        }
        private void OPCUAConnectorButton_Click(object sender, EventArgs e)
        {
            defineOPCUA();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            start(true);
        }

        private void startOPCUAButton_Click(object sender, EventArgs e)
        {
            startOPCUA(true);
        }

        private void startMenuItem_Click(object sender, EventArgs e)
        {
            start(true);
        }

        private void startOPCUAMenuItem_Click(object sender, EventArgs e)
        {
            startOPCUA(true);
        }

        private void startTrayMenuItem_Click(object sender, EventArgs e)
        {
            start(true);
        }

        private void startOPCUATrayMenuItem_Click(object sender, EventArgs e)
        {
            startOPCUA(true);
        }
    
        private void stopButton_Click(object sender, EventArgs e)
        {
            stop(true);
        }

        private void stopOPCUAButton_Click(object sender, EventArgs e)
        {
            stopOPCUA(true);
        }

        private void stopMenuItem_Click(object sender, EventArgs e)
        {
            stop(true);
        }
        
        private void stopOPCUAMenuItem_Click(object sender, EventArgs e)
        {
            stopOPCUA(true);
        }

        private void stopTrayMenuItem_Click(object sender, EventArgs e)
        {
            stop(true);
        }

        private void stopOPCUATrayMenuItem_Click(object sender, EventArgs e)
        {
            stopOPCUA(true);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void exitTrayMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            about();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            about();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (this.Visible) hide();
            }
        }

        private void trayNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                {
                    hide();
                }
                else
                {
                    restore();
                }
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {           
            if (e.CloseReason == CloseReason.UserClosing && !closing)
            {
                if (this.Visible) hide();
                e.Cancel = true;
            }
            else
            {
                Config.Statistics -= ConfigStatistics;
                Config.StateChange -= ConfigStateChange;
                Config.Dispose();
                while (!Config.IsDisposed) Application.DoEvents();
            }
        }

        private void restoreTrayMenuItem_Click(object sender, EventArgs e)
        {
            restore();
        }

        private void hideTraMenuItem_Click(object sender, EventArgs e)
        {
            hide();
        }
    }
}
