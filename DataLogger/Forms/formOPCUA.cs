using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Odbc;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;
using DataManager;

namespace DataLogger
{
    public partial class formDefineOPCUA : Form
    {
        #region Fields
        private Session mySession;
        private readonly UAClientHelperAPI myClientHelperAPI;
        private EndpointDescription mySelectedEndpoint;
        //private readonly List<String> myRegisteredNodeIdStrings;
        private ReferenceDescriptionCollection myReferenceDescriptionCollection;
        private List<string[]> myStructList;
        //private UAClientCertForm myCertForm;
        private readonly OdbcConnectionStringBuilder connStringBuilder = new OdbcConnectionStringBuilder();
        private static BackgroundWorker BGW_OPCUA = null;
        #endregion
        public formDefineOPCUA()
        {
            InitializeComponent();
            myClientHelperAPI = new UAClientHelperAPI();
            //myRegisteredNodeIdStrings = new List<String>();
            BGW_OPCUA = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            BGW_OPCUA.DoWork += BGW_OPCUA_DoWork;
            BGW_OPCUA.RunWorkerCompleted += BGW_OPCUA_RunWorkerCompleted;
        }
        
        private void FormDefineOPCUA_Load(object sender, EventArgs e)
        {
            UpdateConfigStateOPCUA(Config.StateOPCUA);
            Config.StateChangeOPCUA += ConfigStateChangeOPCUA;
        }

        private void ConfigStateChangeOPCUA(object sender, ConfigStateOPCUAEventArgs e)
        {
            UpdateConfigStateOPCUA(e.State);
        }
        private void UpdateConfigStateOPCUA(ConfigStateOPCUA state)
        {
            switch (state)
            {
                case ConfigStateOPCUA.Started:
                    epConnectServerButton.Enabled = false;
                    epConnectServerButton.BackColor = SystemColors.ScrollBar;
                    endpointListView.Enabled = false;
                    endpointListView.BackColor = SystemColors.ScrollBar;
                    groupBox1.BackColor = SystemColors.ScrollBar;
                    userAnonButton.BackColor = SystemColors.ScrollBar;
                    userAnonButton.Enabled = false;
                    userPwButton.BackColor = SystemColors.ScrollBar;
                    userPwButton.Enabled = false;
                    userTextBox.BackColor = SystemColors.ScrollBar;
                    pwTextBox.BackColor = SystemColors.ScrollBar;
                    endpointButton.BackColor = SystemColors.ScrollBar;
                    endpointButton.Enabled = false;
                    discoveryTextBox.BackColor = SystemColors.ScrollBar;
                    discoveryTextBox.Enabled = false;
                    discoveryTextBox.Text = Config.Sets.Primary_OPCUA_Node;
                    buttonTestConfig.BackColor = SystemColors.ScrollBar;
                    buttonTestConfig.Enabled = false;
                    textBoxS7RecArrayName.Enabled = false;
                    textBoxS7RecResetCountName.Enabled = false;
                    buttonSaveConfig.BackColor = SystemColors.ScrollBar;
                    buttonSaveConfig.Enabled = false;

                    descriptionGridView.Enabled = false;
                    descriptionGridView.BackgroundColor = SystemColors.ScrollBar;
                    nodeTreeView.Enabled = false;
                    nodeTreeView.BackColor = SystemColors.ScrollBar;
                    textBoxSQLTableName.Enabled = false;
                    textBoxSQLTableName.BackColor = SystemColors.ScrollBar;
                    numericS7RecordsCount.Enabled = false;
                    numericS7RecordsCount.BackColor = SystemColors.ScrollBar;


                    textBoxS7DBName.Enabled = false;

                    textBoxSQLIDColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLIDColName.Enabled = false;
                    textBoxSQLValColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLValColName.Enabled = false;
                    textBoxSQLDATColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLDATColName.Enabled = false;

                    break;
                case ConfigStateOPCUA.Stopped:
                    epConnectServerButton.Enabled = true;
                    epConnectServerButton.BackColor = Color.Transparent;
                    endpointListView.Enabled = true;
                    endpointListView.BackColor = SystemColors.Window;
                    groupBox1.BackColor = SystemColors.Window;
                    userAnonButton.BackColor = SystemColors.Window;
                    userPwButton.BackColor = SystemColors.Window;
                    userTextBox.BackColor = SystemColors.Window;
                    pwTextBox.BackColor = SystemColors.Window;
                    endpointButton.BackColor = Color.Transparent;
                    endpointButton.Enabled = true;
                    discoveryTextBox.BackColor = SystemColors.Window;
                    discoveryTextBox.Enabled = true;
                    discoveryTextBox.Text = Config.Sets.Primary_OPCUA_Node;
                    buttonTestConfig.BackColor = SystemColors.ScrollBar;
                    buttonTestConfig.Enabled = false;
                    textBoxS7RecArrayName.Enabled = false;
                    textBoxS7RecResetCountName.Enabled = false;
                    buttonSaveConfig.BackColor = SystemColors.ScrollBar;
                    buttonSaveConfig.Enabled = false;

                    descriptionGridView.Enabled = false;
                    descriptionGridView.BackgroundColor = SystemColors.ScrollBar;
                    nodeTreeView.Enabled = false;
                    nodeTreeView.BackColor = SystemColors.ScrollBar;
                    textBoxSQLTableName.Enabled = false;
                    textBoxSQLTableName.BackColor = SystemColors.ScrollBar;
                    numericS7RecordsCount.Enabled = false;
                    numericS7RecordsCount.BackColor = SystemColors.ScrollBar;

                    textBoxS7DBName.Enabled = false;

                    textBoxSQLIDColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLIDColName.Enabled = false;
                    textBoxSQLValColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLValColName.Enabled = false;
                    textBoxSQLDATColName.BackColor = SystemColors.ScrollBar;
                    textBoxSQLDATColName.Enabled = false;

                    break;
            }
        }
        #region UserInteractionHandlers
        private void EndpointButton_Click(object sender, EventArgs e)
        {
            endpointListView.Items.Clear();
            //The local discovery URL for the discovery server
            string discoveryUrl = discoveryTextBox.Text;
            try
            {
                ApplicationDescriptionCollection servers = myClientHelperAPI.FindServers(discoveryUrl);
                foreach (ApplicationDescription ad in servers)
                {
                    foreach (string url in ad.DiscoveryUrls)
                    {
                        EndpointDescriptionCollection endpoints = myClientHelperAPI.GetEndpoints(url);
                        foreach (EndpointDescription ep in endpoints)
                        {
                            string securityPolicy = ep.SecurityPolicyUri.Remove(0, 42);
                            endpointListView.Items.Add("[" + ad.ApplicationName + "] " + " [" + ep.SecurityMode + "] " + " [" + securityPolicy + "] " + " [" + ep.EndpointUrl + "]").Tag = ep;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (BGW_OPCUA.IsBusy)
                {
                    BGW_OPCUA.CancelAsync();
                }
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void EndpointListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            mySelectedEndpoint = (EndpointDescription)e.Item.Tag;
        }
        private void EpConnectServerButton_Click(object sender, EventArgs e)
        {
            var classOPCUA = new OPCUA();
            //Check if sessions exists; If yes > delete subscriptions and disconnect
            if (mySession != null && !mySession.Disposed)
            {
                myClientHelperAPI.Disconnect();
                mySession = myClientHelperAPI.Session;
                ResetUI();
            }
            else
            {
                try
                {
                    //Register mandatory events (cert and keep alive)
                    myClientHelperAPI.KeepAliveNotification += new KeepAliveEventHandler(classOPCUA.Notification_KeepAlive);
                    myClientHelperAPI.CertificateValidationNotification += new CertificateValidationEventHandler(classOPCUA.Notification_ServerCertificate);

                    //Check for a selected endpoint
                    if (mySelectedEndpoint != null)
                    {
                        //Call connect
                        myClientHelperAPI.Connect(mySelectedEndpoint, userPwButton.Checked, userTextBox.Text, pwTextBox.Text);
                        //Extract the session object for further direct session interactions
                        mySession = myClientHelperAPI.Session;

                        //UI settings
                        epConnectServerButton.Text = "Disconnect from server";
                        //myCertForm = null;

                        if (descriptionGridView.Enabled == false)
                        {
                            descriptionGridView.Enabled = true;
                            descriptionGridView.BackgroundColor = SystemColors.Window;
                            nodeTreeView.Enabled = true;
                            nodeTreeView.BackColor = SystemColors.Window;
                            numericS7RecordsCount.Enabled = true;
                            numericS7RecordsCount.BackColor = SystemColors.Window;
                            textBoxSQLTableName.Enabled = true;
                            textBoxSQLTableName.BackColor = SystemColors.Window;

                            textBoxSQLIDColName.BackColor = SystemColors.Window;
                            textBoxSQLIDColName.Enabled = true;
                            textBoxSQLValColName.BackColor = SystemColors.Window;
                            textBoxSQLValColName.Enabled = true;
                            textBoxSQLDATColName.BackColor = SystemColors.Window;
                            textBoxSQLDATColName.Enabled = true;
                        }

                        if (Config.Sets.Primary_ODBC_DSN != "")
                        {
                            connStringBuilder.Dsn = Config.Sets.Primary_ODBC_DSN;
                            connStringBuilder.Add("Uid", Config.Sets.Primary_ODBC_User);
                            connStringBuilder.Add("Pwd", Config.Sets.Primary_ODBC_Pass);
                        }
                        if (Config.Sets.Primary_OPCUA_Node != "")
                        {
                            //discoveryTextBox.Text = Config.Sets.Primary_OPCUA_Node;
                            textBoxS7DBName.Text = Config.Sets.Primary_S7_DBName;
                            textBoxS7RecArrayName.Text = Config.Sets.Primary_OPCUA_RecArray;
                            textBoxS7RecResetCountName.Text = Config.Sets.Primary_OPCUA_RecResetCount;
                        }
                        if (Config.Sets.Primary_SQL_NumberOfRec != 0)
                        {
                            numericS7RecordsCount.Value = Config.Sets.Primary_SQL_NumberOfRec;
                            textBoxSQLTableName.Text = Config.Sets.Primary_SQL_TableName;
                            textBoxSQLIDColName.Text = Config.Sets.Primary_SQL_IDColName;
                            textBoxSQLValColName.Text = Config.Sets.Primary_SQL_ValColName;
                            textBoxSQLDATColName.Text = Config.Sets.Primary_SQL_DATColName;

                            buttonSaveConfig.Enabled = true;
                            buttonSaveConfig.BackColor = Color.Transparent;
                        }

                        if (myReferenceDescriptionCollection == null)
                        {
                            try
                            {
                                myReferenceDescriptionCollection = myClientHelperAPI.BrowseRoot();
                                foreach (ReferenceDescription refDesc in myReferenceDescriptionCollection)
                                {
                                    nodeTreeView.Nodes.Add(refDesc.DisplayName.ToString()).Tag = refDesc;
                                    foreach (TreeNode node in nodeTreeView.Nodes)
                                    {
                                        node.Nodes.Add("");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (BGW_OPCUA.IsBusy)
                                {
                                    BGW_OPCUA.CancelAsync();
                                }
                                MessageBox.Show(ex.Message, "Error");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an endpoint before connecting", "Error");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (BGW_OPCUA.IsBusy)
                    {
                        BGW_OPCUA.CancelAsync();
                    }
                    //myCertForm = null;
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void UserAnonButton_CheckedChanged(object sender, EventArgs e)
        {
            if (userAnonButton.Checked)
            {
                userTextBox.Enabled = false;
                pwTextBox.Enabled = false;
            }
        }

        private void UserPwButton_CheckedChanged(object sender, EventArgs e)
        {
            if (userPwButton.Checked)
            {
                userTextBox.Enabled = true;
                pwTextBox.Enabled = true;
            }
        }

        private void NodeTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            descriptionGridView.Rows.Clear();
            try
            {
                ReferenceDescription refDesc = (ReferenceDescription)e.Node.Tag;
                Node node = myClientHelperAPI.ReadNode(refDesc.NodeId.ToString());
                VariableNode variableNode = new VariableNode();

                string[] row1 = new string[] { "Node Id", refDesc.NodeId.ToString() };
                string[] row2 = new string[] { "Namespace Index", refDesc.NodeId.NamespaceIndex.ToString() };
                string[] row3 = new string[] { "Identifier Type", refDesc.NodeId.IdType.ToString() };
                string[] row4 = new string[] { "Identifier", refDesc.NodeId.Identifier.ToString() };
                string[] row5 = new string[] { "Browse Name", refDesc.BrowseName.ToString() };
                string[] row6 = new string[] { "Display Name", refDesc.DisplayName.ToString() };
                string[] row7 = new string[] { "Node Class", refDesc.NodeClass.ToString() };
                string[] row8 = new string[] { "Description", "null" };
                try { row8 = new string[] { "Description", node.Description.ToString() }; }
                catch { row8 = new string[] { "Description", "null" }; }
                string[] row9 = new string[] { "Type Definition", refDesc.TypeDefinition.ToString() };
                string[] row10 = new string[] { "Write Mask", node.WriteMask.ToString() };
                string[] row11 = new string[] { "User Write Mask", node.UserWriteMask.ToString() };
                if (node.NodeClass == NodeClass.Variable)
                {
                    variableNode = (VariableNode)node.DataLock;
                    List<NodeId> nodeIds = new List<NodeId>();
                    List<string> displayNames = new List<string>();
                    List<ServiceResult> errors = new List<ServiceResult>();
                    NodeId nodeId = new NodeId(variableNode.DataType);
                    nodeIds.Add(nodeId);
                    
                    mySession.ReadDisplayName(nodeIds, out displayNames, out errors);

                    string[] row12 = new string[] { "Data Type", displayNames[0] };
                    string[] row13 = new string[] { "Value Rank", variableNode.ValueRank.ToString() };
                    string[] row14 = new string[] { "Array Dimensions", variableNode.ArrayDimensions.Capacity.ToString() };
                    string[] row15 = new string[] { "Access Level", variableNode.AccessLevel.ToString() };
                    string[] row16 = new string[] { "Minimum Sampling Interval", variableNode.MinimumSamplingInterval.ToString() };
                    string[] row17 = new string[] { "Historizing", variableNode.Historizing.ToString() };

                    object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17 };
                    foreach (string[] rowArray in rows)
                    {
                        descriptionGridView.Rows.Add(rowArray);
                    }
                }
                else
                {
                    object[] rows = new object[] { row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11 };
                    foreach (string[] rowArray in rows)
                    {
                        descriptionGridView.Rows.Add(rowArray);
                    }
                }
                descriptionGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                if (BGW_OPCUA.IsBusy)
                {
                    BGW_OPCUA.CancelAsync();
                }
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void NodeTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (nodeTreeView.SelectedNode.Text == "=Buffer" || nodeTreeView.SelectedNode.Text == "Buffer")
            {
                textBoxS7DBName.Text = nodeTreeView.SelectedNode.Text;
                textBoxS7RecResetCountName.Text = nodeTreeView.SelectedNode.FirstNode.NextNode.Text;
                textBoxS7RecArrayName.Text = nodeTreeView.SelectedNode.LastNode.Text;
            }
            else
            {
                MessageBox.Show("Select wrong Data Block!");
            }
        }

        private void NodeTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            ReferenceDescriptionCollection referenceDescriptionCollection;
            ReferenceDescription refDesc = (ReferenceDescription)e.Node.Tag;

            try
            {
                referenceDescriptionCollection = myClientHelperAPI.BrowseNode(refDesc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }

            foreach (ReferenceDescription tempRefDesc in referenceDescriptionCollection)
            {
                if (tempRefDesc.ReferenceTypeId != ReferenceTypeIds.HasNotifier)
                {
                    e.Node.Nodes.Add(tempRefDesc.DisplayName.ToString()).Tag = tempRefDesc;
                }
            }
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Nodes.Add("");
            }
        }

        bool startRead = false;

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
                if (BGW_OPCUA.IsBusy)
                {
                    BGW_OPCUA.CancelAsync();
                }
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void BGW_OPCUA_DoWork(object sender_DW, DoWorkEventArgs e_DW)
        {
            try
            {
                int count = Decimal.ToInt32(Config.Sets.Primary_SQL_NumberOfRec);
                myStructList = new List<string[]>();
                List<String> values = new List<string>();
                List<String> nodeIdStrings = new List<string>();

                if (BGW_OPCUA.CancellationPending)
                {
                    e_DW.Cancel = true;
                    return;
                }

                if (startRead && !e_DW.Cancel)
                {
                    try
                    {
                        myStructList = myClientHelperAPI.ReadStructUdt("ns=3;s=\"" + Config.Sets.Primary_S7_DBName + "\".\"" + textBoxS7RecArrayName.Text + "\"");
                    }
                    catch (Exception ex)
                    {
                        if (BGW_OPCUA.IsBusy)
                        {
                            BGW_OPCUA.CancelAsync();
                        }
                        MessageBox.Show(ex.Message, "Error");
                    }

                    if (count > myStructList.Count / 5)
                    {
                        count = myStructList.Count / 5;
                        numericS7RecordsCount.Invoke(new Action(() => numericS7RecordsCount.Maximum = count));
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
                    nodeIdStrings.Add("ns=3;s=\"" + Config.Sets.Primary_S7_DBName + "\".\"" + textBoxS7RecResetCountName.Text + "\"");
                    try
                    {
                        myClientHelperAPI.WriteValues(values, nodeIdStrings);
                        MessageBox.Show("Test completed successfully!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);            

                    }
                    catch (Exception ex)
                    {
                        if (BGW_OPCUA.IsBusy)
                        {
                            BGW_OPCUA.CancelAsync();
                        }
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            catch (Exception ex)
            {
                if (BGW_OPCUA.IsBusy)
                {
                    BGW_OPCUA.CancelAsync();
                }
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            Config.Sets.Primary_OPCUA_Node = discoveryTextBox.Text;

            Config.Sets.Primary_S7_DBName = textBoxS7DBName.Text;
            Config.Sets.Primary_OPCUA_RecArray = textBoxS7RecArrayName.Text;
            Config.Sets.Primary_OPCUA_RecResetCount = textBoxS7RecResetCountName.Text;
            Config.Sets.Primary_SQL_NumberOfRec = numericS7RecordsCount.Value;

            Config.Sets.Primary_SQL_TableName = textBoxSQLTableName.Text;
            Config.Sets.Primary_SQL_IDColName = textBoxSQLIDColName.Text;
            Config.Sets.Primary_SQL_ValColName = textBoxSQLValColName.Text;
            Config.Sets.Primary_SQL_DATColName = textBoxSQLDATColName.Text;

            Config.Save();

            if (!BGW_OPCUA.IsBusy)
            {
                startRead = true;
                buttonTestConfig.Text = "Stop";
                BGW_OPCUA.RunWorkerAsync();
            }
            else
            {
                startRead = false;
                buttonTestConfig.Text = "Start";
                BGW_OPCUA.CancelAsync();
            }
        }

        private void ButtonSaveConfig_Click(object sender, EventArgs e)
        {
            Config.Sets.Primary_OPCUA_Node = discoveryTextBox.Text;

            Config.Sets.Primary_S7_DBName = textBoxS7DBName.Text;
            Config.Sets.Primary_OPCUA_RecArray = textBoxS7RecArrayName.Text;
            Config.Sets.Primary_OPCUA_RecResetCount = textBoxS7RecResetCountName.Text;
            Config.Sets.Primary_SQL_NumberOfRec = numericS7RecordsCount.Value;

            Config.Sets.Primary_SQL_TableName = textBoxSQLTableName.Text;
            Config.Sets.Primary_SQL_IDColName = textBoxSQLIDColName.Text;
            Config.Sets.Primary_SQL_ValColName = textBoxSQLValColName.Text;
            Config.Sets.Primary_SQL_DATColName = textBoxSQLDATColName.Text;

            Config.Save();

            buttonTestConfig.Enabled = true;
            buttonTestConfig.BackColor = Color.Transparent;
        }

        private void BGW_OPCUA_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e_RWC)
        {
            if (e_RWC.Cancelled)
                Console.WriteLine("Работа BackgroundWorker была прервана пользователем!");
            else if (e_RWC.Error != null)
                MessageBox.Show("Worker exception: " + e_RWC.Error);
            else
                Console.WriteLine("Работа закончена успешно.");
            
            startRead = false;

            if (BGW_OPCUA.IsBusy)
            {
                BGW_OPCUA.CancelAsync();
            }
        }
        #endregion

        private void ResetUI()
        {
            descriptionGridView.Rows.Clear();
            nodeTreeView.Nodes.Clear();
            myReferenceDescriptionCollection = null;
            myStructList = null;

            epConnectServerButton.Text = "Connect to server";

            descriptionGridView.Enabled = false;
            descriptionGridView.BackgroundColor = SystemColors.ScrollBar;
            nodeTreeView.Enabled = false;
            nodeTreeView.BackColor = SystemColors.ScrollBar;
            textBoxS7RecArrayName.Enabled = false;
            textBoxS7RecArrayName.BackColor = SystemColors.ScrollBar;
            numericS7RecordsCount.Enabled = false;
            numericS7RecordsCount.BackColor = SystemColors.ScrollBar;
            textBoxSQLTableName.Enabled = false;
            textBoxSQLTableName.BackColor = SystemColors.ScrollBar;
            textBoxS7RecResetCountName.Enabled = false;
            textBoxS7RecResetCountName.BackColor = SystemColors.ScrollBar;
            buttonTestConfig.Enabled = false;

            textBoxS7RecArrayName.Text = "";
            textBoxS7RecResetCountName.Text = "";
            textBoxSQLTableName.Text = "";


            opcTabControl.SelectedIndex = 0;
        }
    }
}
