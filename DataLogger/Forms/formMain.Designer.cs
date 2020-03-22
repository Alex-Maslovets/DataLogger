namespace DataLogger
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.configurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOPCTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOPCUATextBox = new System.Windows.Forms.ToolStripTextBox();
            this.startOPCUAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopOPCUAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcConnectorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OPCUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odbcConnectorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.textOPCLabel = new System.Windows.Forms.ToolStripLabel();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.textOPCUALabel = new System.Windows.Forms.ToolStripLabel();
            this.startOPCUAButton = new System.Windows.Forms.ToolStripButton();
            this.stopOPCUAButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.opcConnectorButton = new System.Windows.Forms.ToolStripButton();
            this.OPCUAConnectorButton = new System.Windows.Forms.ToolStripButton();
            this.odbcConnectorButton = new System.Windows.Forms.ToolStripButton();
            this.transactionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridMonitor = new System.Windows.Forms.DataGridView();
            this.transactionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oDBCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.failedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMonitor = new System.Data.DataSet();
            this.dtTransaction = new System.Data.DataTable();
            this.dcTransactionName = new System.Data.DataColumn();
            this.dcOPCState = new System.Data.DataColumn();
            this.dcODBCState = new System.Data.DataColumn();
            this.dcTransactionTotal = new System.Data.DataColumn();
            this.dcTransactionPassed = new System.Data.DataColumn();
            this.dcTransactionFailed = new System.Data.DataColumn();
            this.dcPercent = new System.Data.DataColumn();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.statusConfigLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusConnectOPCUALabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.opcTrayTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.startTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.opcUATrayTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.startOPCUATrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopOPCUATrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savedInfoGridView = new System.Windows.Forms.DataGridView();
            this.typeOfInformation_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savedValue_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransaction)).BeginInit();
            this.statusbar.SuspendLayout();
            this.trayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savedInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationMenuItem,
            this.defineMenuItem,
            this.helpMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(544, 24);
            this.menu.TabIndex = 0;
            // 
            // configurationMenuItem
            // 
            this.configurationMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.configurationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOPCTextBox,
            this.startMenuItem,
            this.stopMenuItem,
            this.toolStripMenuItem2,
            this.toolOPCUATextBox,
            this.startOPCUAMenuItem,
            this.stopOPCUAMenuItem,
            this.toolStripSeparator7,
            this.exitMenuItem});
            this.configurationMenuItem.Name = "configurationMenuItem";
            this.configurationMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationMenuItem.Text = "Configuration";
            // 
            // toolOPCTextBox
            // 
            this.toolOPCTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.toolOPCTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolOPCTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolOPCTextBox.Name = "toolOPCTextBox";
            this.toolOPCTextBox.ReadOnly = true;
            this.toolOPCTextBox.Size = new System.Drawing.Size(100, 23);
            this.toolOPCTextBox.Text = "OPC";
            this.toolOPCTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startMenuItem
            // 
            this.startMenuItem.Enabled = false;
            this.startMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startMenuItem.Name = "startMenuItem";
            this.startMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startMenuItem.Text = "Start";
            this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Enabled = false;
            this.stopMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.stopMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(157, 6);
            // 
            // toolOPCUATextBox
            // 
            this.toolOPCUATextBox.BackColor = System.Drawing.SystemColors.Window;
            this.toolOPCUATextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolOPCUATextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolOPCUATextBox.Name = "toolOPCUATextBox";
            this.toolOPCUATextBox.ReadOnly = true;
            this.toolOPCUATextBox.Size = new System.Drawing.Size(100, 23);
            this.toolOPCUATextBox.Text = "OPCUA";
            this.toolOPCUATextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startOPCUAMenuItem
            // 
            this.startOPCUAMenuItem.Enabled = false;
            this.startOPCUAMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startOPCUAMenuItem.Name = "startOPCUAMenuItem";
            this.startOPCUAMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startOPCUAMenuItem.Text = "Start";
            this.startOPCUAMenuItem.Click += new System.EventHandler(this.startOPCUAMenuItem_Click);
            // 
            // stopOPCUAMenuItem
            // 
            this.stopOPCUAMenuItem.Enabled = false;
            this.stopOPCUAMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopOPCUAMenuItem.Name = "stopOPCUAMenuItem";
            this.stopOPCUAMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopOPCUAMenuItem.Text = "Stop";
            this.stopOPCUAMenuItem.Click += new System.EventHandler(this.stopOPCUAMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(157, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::DataLogger.Properties.Resources.Critical;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // defineMenuItem
            // 
            this.defineMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcConnectorMenuItem,
            this.OPCUAToolStripMenuItem,
            this.odbcConnectorMenuItem,
            this.transactionMenuItem});
            this.defineMenuItem.Name = "defineMenuItem";
            this.defineMenuItem.Size = new System.Drawing.Size(53, 20);
            this.defineMenuItem.Text = "Define";
            // 
            // opcConnectorMenuItem
            // 
            this.opcConnectorMenuItem.Image = global::DataLogger.Properties.Resources.Control_DataConnector;
            this.opcConnectorMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opcConnectorMenuItem.Name = "opcConnectorMenuItem";
            this.opcConnectorMenuItem.Size = new System.Drawing.Size(191, 22);
            this.opcConnectorMenuItem.Text = "OPC DA Connection";
            this.opcConnectorMenuItem.Click += new System.EventHandler(this.opcConnectorMenuItem_Click);
            // 
            // OPCUAToolStripMenuItem
            // 
            this.OPCUAToolStripMenuItem.Image = global::DataLogger.Properties.Resources.OPCUA_database;
            this.OPCUAToolStripMenuItem.Name = "OPCUAToolStripMenuItem";
            this.OPCUAToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.OPCUAToolStripMenuItem.Text = "OPC UA Connection";
            this.OPCUAToolStripMenuItem.Click += new System.EventHandler(this.OPCUAToolStripMenuItem_Click);
            // 
            // odbcConnectorMenuItem
            // 
            this.odbcConnectorMenuItem.Image = global::DataLogger.Properties.Resources.VSProject_database;
            this.odbcConnectorMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.odbcConnectorMenuItem.Name = "odbcConnectorMenuItem";
            this.odbcConnectorMenuItem.Size = new System.Drawing.Size(191, 22);
            this.odbcConnectorMenuItem.Text = "ODBC Connection";
            this.odbcConnectorMenuItem.Click += new System.EventHandler(this.odbcConnectorMenuItem_Click);
            // 
            // transactionMenuItem
            // 
            this.transactionMenuItem.Image = global::DataLogger.Properties.Resources.Control_DataNavigator;
            this.transactionMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transactionMenuItem.Name = "transactionMenuItem";
            this.transactionMenuItem.Size = new System.Drawing.Size(191, 22);
            this.transactionMenuItem.Text = "DataLoger Transaction";
            this.transactionMenuItem.Click += new System.EventHandler(this.transactionMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(52, 20);
            this.helpMenuItem.Text = "About";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Image = global::DataLogger.Properties.Resources.Help;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textOPCLabel,
            this.startButton,
            this.stopButton,
            this.toolStripSeparator1,
            this.textOPCUALabel,
            this.startOPCUAButton,
            this.stopOPCUAButton,
            this.toolStripSeparator6,
            this.opcConnectorButton,
            this.OPCUAConnectorButton,
            this.odbcConnectorButton,
            this.transactionButton,
            this.toolStripSeparator2,
            this.aboutButton});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(544, 25);
            this.toolbar.TabIndex = 2;
            // 
            // textOPCLabel
            // 
            this.textOPCLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textOPCLabel.Name = "textOPCLabel";
            this.textOPCLabel.Size = new System.Drawing.Size(31, 22);
            this.textOPCLabel.Text = "OPC";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Enabled = false;
            this.startButton.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "Start OPC configuration";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Enabled = false;
            this.stopButton.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "Stop OPC configuration";
            this.stopButton.ToolTipText = "Stop OPC configuration";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // textOPCUALabel
            // 
            this.textOPCUALabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.textOPCUALabel.Name = "textOPCUALabel";
            this.textOPCUALabel.Size = new System.Drawing.Size(47, 22);
            this.textOPCUALabel.Text = "OPCUA";
            // 
            // startOPCUAButton
            // 
            this.startOPCUAButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startOPCUAButton.Enabled = false;
            this.startOPCUAButton.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startOPCUAButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startOPCUAButton.Name = "startOPCUAButton";
            this.startOPCUAButton.Size = new System.Drawing.Size(23, 22);
            this.startOPCUAButton.Text = "Start OPCUA configuration";
            this.startOPCUAButton.ToolTipText = "Start OPCUA configuration";
            this.startOPCUAButton.Click += new System.EventHandler(this.startOPCUAButton_Click);
            // 
            // stopOPCUAButton
            // 
            this.stopOPCUAButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopOPCUAButton.Enabled = false;
            this.stopOPCUAButton.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopOPCUAButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopOPCUAButton.Name = "stopOPCUAButton";
            this.stopOPCUAButton.Size = new System.Drawing.Size(23, 22);
            this.stopOPCUAButton.Text = "Stop OPCUA configuration";
            this.stopOPCUAButton.ToolTipText = "Stop OPCUA configuration";
            this.stopOPCUAButton.Click += new System.EventHandler(this.stopOPCUAButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // opcConnectorButton
            // 
            this.opcConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.opcConnectorButton.Image = global::DataLogger.Properties.Resources.Control_DataConnector;
            this.opcConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opcConnectorButton.Name = "opcConnectorButton";
            this.opcConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.opcConnectorButton.Text = "Define OPC DA Connection";
            this.opcConnectorButton.ToolTipText = "Define OPC DA Connection";
            this.opcConnectorButton.Click += new System.EventHandler(this.opcConnectorButton_Click);
            // 
            // OPCUAConnectorButton
            // 
            this.OPCUAConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OPCUAConnectorButton.Image = global::DataLogger.Properties.Resources.OPCUA_database;
            this.OPCUAConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OPCUAConnectorButton.Name = "OPCUAConnectorButton";
            this.OPCUAConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.OPCUAConnectorButton.Text = "Define OPC UA Connection";
            this.OPCUAConnectorButton.ToolTipText = "Define OPC UA Connection";
            this.OPCUAConnectorButton.Click += new System.EventHandler(this.OPCUAConnectorButton_Click);
            // 
            // odbcConnectorButton
            // 
            this.odbcConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.odbcConnectorButton.Image = global::DataLogger.Properties.Resources.VSProject_database;
            this.odbcConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.odbcConnectorButton.Name = "odbcConnectorButton";
            this.odbcConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.odbcConnectorButton.Text = "Define ODBC Connection";
            this.odbcConnectorButton.ToolTipText = "Define ODBC Connection";
            this.odbcConnectorButton.Click += new System.EventHandler(this.odbcConnectorButton_Click);
            // 
            // transactionButton
            // 
            this.transactionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transactionButton.Image = global::DataLogger.Properties.Resources.Control_DataNavigator;
            this.transactionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transactionButton.Name = "transactionButton";
            this.transactionButton.Size = new System.Drawing.Size(23, 22);
            this.transactionButton.Text = "Define DataLoger Transaction";
            this.transactionButton.ToolTipText = "Define DataLoger Transaction";
            this.transactionButton.Click += new System.EventHandler(this.transactionButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = global::DataLogger.Properties.Resources.Help;
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(23, 22);
            this.aboutButton.Text = "About";
            this.aboutButton.ToolTipText = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // dataGridMonitor
            // 
            this.dataGridMonitor.AllowUserToAddRows = false;
            this.dataGridMonitor.AllowUserToDeleteRows = false;
            this.dataGridMonitor.AutoGenerateColumns = false;
            this.dataGridMonitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transactionDataGridViewTextBoxColumn,
            this.oPCDataGridViewTextBoxColumn,
            this.oDBCDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.passedDataGridViewTextBoxColumn,
            this.failedDataGridViewTextBoxColumn,
            this.passedDataGridViewTextBoxColumn1});
            this.dataGridMonitor.DataMember = "dtTransaction";
            this.dataGridMonitor.DataSource = this.dsMonitor;
            this.dataGridMonitor.Location = new System.Drawing.Point(0, 65);
            this.dataGridMonitor.Name = "dataGridMonitor";
            this.dataGridMonitor.ReadOnly = true;
            this.dataGridMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMonitor.Size = new System.Drawing.Size(544, 201);
            this.dataGridMonitor.TabIndex = 3;
            // 
            // transactionDataGridViewTextBoxColumn
            // 
            this.transactionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.transactionDataGridViewTextBoxColumn.DataPropertyName = "Transaction";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.transactionDataGridViewTextBoxColumn.HeaderText = "Transaction";
            this.transactionDataGridViewTextBoxColumn.Name = "transactionDataGridViewTextBoxColumn";
            this.transactionDataGridViewTextBoxColumn.ReadOnly = true;
            this.transactionDataGridViewTextBoxColumn.Width = 88;
            // 
            // oPCDataGridViewTextBoxColumn
            // 
            this.oPCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oPCDataGridViewTextBoxColumn.DataPropertyName = "OPC";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oPCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.oPCDataGridViewTextBoxColumn.HeaderText = "OPC";
            this.oPCDataGridViewTextBoxColumn.Name = "oPCDataGridViewTextBoxColumn";
            this.oPCDataGridViewTextBoxColumn.ReadOnly = true;
            this.oPCDataGridViewTextBoxColumn.Width = 54;
            // 
            // oDBCDataGridViewTextBoxColumn
            // 
            this.oDBCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oDBCDataGridViewTextBoxColumn.DataPropertyName = "ODBC";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oDBCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.oDBCDataGridViewTextBoxColumn.HeaderText = "ODBC";
            this.oDBCDataGridViewTextBoxColumn.Name = "oDBCDataGridViewTextBoxColumn";
            this.oDBCDataGridViewTextBoxColumn.ReadOnly = true;
            this.oDBCDataGridViewTextBoxColumn.Width = 62;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 56;
            // 
            // passedDataGridViewTextBoxColumn
            // 
            this.passedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.passedDataGridViewTextBoxColumn.DataPropertyName = "Passed";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.passedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.passedDataGridViewTextBoxColumn.HeaderText = "Passed";
            this.passedDataGridViewTextBoxColumn.Name = "passedDataGridViewTextBoxColumn";
            this.passedDataGridViewTextBoxColumn.ReadOnly = true;
            this.passedDataGridViewTextBoxColumn.Width = 67;
            // 
            // failedDataGridViewTextBoxColumn
            // 
            this.failedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.failedDataGridViewTextBoxColumn.DataPropertyName = "Failed";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.failedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.failedDataGridViewTextBoxColumn.HeaderText = "Failed";
            this.failedDataGridViewTextBoxColumn.Name = "failedDataGridViewTextBoxColumn";
            this.failedDataGridViewTextBoxColumn.ReadOnly = true;
            this.failedDataGridViewTextBoxColumn.Width = 60;
            // 
            // passedDataGridViewTextBoxColumn1
            // 
            this.passedDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.passedDataGridViewTextBoxColumn1.DataPropertyName = "% Passed";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.passedDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle16;
            this.passedDataGridViewTextBoxColumn1.HeaderText = "% Passed";
            this.passedDataGridViewTextBoxColumn1.Name = "passedDataGridViewTextBoxColumn1";
            this.passedDataGridViewTextBoxColumn1.ReadOnly = true;
            this.passedDataGridViewTextBoxColumn1.Width = 78;
            // 
            // dsMonitor
            // 
            this.dsMonitor.DataSetName = "NewDataSet";
            this.dsMonitor.Tables.AddRange(new System.Data.DataTable[] {
            this.dtTransaction});
            // 
            // dtTransaction
            // 
            this.dtTransaction.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcTransactionName,
            this.dcOPCState,
            this.dcODBCState,
            this.dcTransactionTotal,
            this.dcTransactionPassed,
            this.dcTransactionFailed,
            this.dcPercent});
            this.dtTransaction.TableName = "dtTransaction";
            // 
            // dcTransactionName
            // 
            this.dcTransactionName.Caption = "Transaction Name";
            this.dcTransactionName.ColumnName = "Transaction";
            // 
            // dcOPCState
            // 
            this.dcOPCState.ColumnName = "OPC";
            // 
            // dcODBCState
            // 
            this.dcODBCState.ColumnName = "ODBC";
            // 
            // dcTransactionTotal
            // 
            this.dcTransactionTotal.ColumnName = "Total";
            this.dcTransactionTotal.DataType = typeof(long);
            // 
            // dcTransactionPassed
            // 
            this.dcTransactionPassed.ColumnName = "Passed";
            this.dcTransactionPassed.DataType = typeof(long);
            // 
            // dcTransactionFailed
            // 
            this.dcTransactionFailed.ColumnName = "Failed";
            this.dcTransactionFailed.DataType = typeof(long);
            // 
            // dcPercent
            // 
            this.dcPercent.ColumnName = "% Passed";
            this.dcPercent.DataType = typeof(float);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConfigLabel,
            this.statusConnectOPCUALabel});
            this.statusbar.Location = new System.Drawing.Point(0, 514);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(544, 27);
            this.statusbar.TabIndex = 4;
            // 
            // statusConfigLabel
            // 
            this.statusConfigLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusConfigLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusConfigLabel.Image = global::DataLogger.Properties.Resources.Stop;
            this.statusConfigLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusConfigLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statusConfigLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.statusConfigLabel.Name = "statusConfigLabel";
            this.statusConfigLabel.Padding = new System.Windows.Forms.Padding(15, 2, 0, 3);
            this.statusConfigLabel.Size = new System.Drawing.Size(144, 24);
            this.statusConfigLabel.Text = "Configuration state";
            // 
            // statusConnectOPCUALabel
            // 
            this.statusConnectOPCUALabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusConnectOPCUALabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusConnectOPCUALabel.Image = global::DataLogger.Properties.Resources.Critical_Blink;
            this.statusConnectOPCUALabel.ImageTransparentColor = System.Drawing.Color.Red;
            this.statusConnectOPCUALabel.Name = "statusConnectOPCUALabel";
            this.statusConnectOPCUALabel.Size = new System.Drawing.Size(117, 22);
            this.statusConnectOPCUALabel.Text = "Connection state";
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.ContextMenuStrip = this.trayMenu;
            this.trayNotifyIcon.Visible = true;
            this.trayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayNotifyIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.BackColor = System.Drawing.SystemColors.Window;
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideTrayMenuItem,
            this.restoreTrayMenuItem,
            this.toolStripSeparator3,
            this.opcTrayTextBox,
            this.startTrayMenuItem,
            this.stopTrayMenuItem,
            this.toolStripSeparator4,
            this.opcUATrayTextBox,
            this.startOPCUATrayMenuItem,
            this.stopOPCUATrayMenuItem,
            this.toolStripSeparator5,
            this.exitTrayMenuItem});
            this.trayMenu.Name = "trayContextMenu";
            this.trayMenu.Size = new System.Drawing.Size(161, 219);
            // 
            // hideTrayMenuItem
            // 
            this.hideTrayMenuItem.Name = "hideTrayMenuItem";
            this.hideTrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hideTrayMenuItem.Text = "Hide";
            this.hideTrayMenuItem.Click += new System.EventHandler(this.hideTraMenuItem_Click);
            // 
            // restoreTrayMenuItem
            // 
            this.restoreTrayMenuItem.Name = "restoreTrayMenuItem";
            this.restoreTrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.restoreTrayMenuItem.Text = "Restore";
            this.restoreTrayMenuItem.Click += new System.EventHandler(this.restoreTrayMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // opcTrayTextBox
            // 
            this.opcTrayTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.opcTrayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.opcTrayTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opcTrayTextBox.Name = "opcTrayTextBox";
            this.opcTrayTextBox.ReadOnly = true;
            this.opcTrayTextBox.Size = new System.Drawing.Size(100, 16);
            this.opcTrayTextBox.Text = "OPC";
            this.opcTrayTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startTrayMenuItem
            // 
            this.startTrayMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startTrayMenuItem.Name = "startTrayMenuItem";
            this.startTrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startTrayMenuItem.Text = "Start";
            this.startTrayMenuItem.Click += new System.EventHandler(this.startTrayMenuItem_Click);
            // 
            // stopTrayMenuItem
            // 
            this.stopTrayMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.stopTrayMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopTrayMenuItem.Name = "stopTrayMenuItem";
            this.stopTrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopTrayMenuItem.Text = "Stop";
            this.stopTrayMenuItem.Click += new System.EventHandler(this.stopTrayMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // opcUATrayTextBox
            // 
            this.opcUATrayTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.opcUATrayTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.opcUATrayTextBox.Name = "opcUATrayTextBox";
            this.opcUATrayTextBox.ReadOnly = true;
            this.opcUATrayTextBox.Size = new System.Drawing.Size(100, 23);
            this.opcUATrayTextBox.Text = "OPCUA";
            this.opcUATrayTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startOPCUATrayMenuItem
            // 
            this.startOPCUATrayMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startOPCUATrayMenuItem.Name = "startOPCUATrayMenuItem";
            this.startOPCUATrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startOPCUATrayMenuItem.Text = "Start";
            this.startOPCUATrayMenuItem.Click += new System.EventHandler(this.startOPCUATrayMenuItem_Click);
            // 
            // stopOPCUATrayMenuItem
            // 
            this.stopOPCUATrayMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopOPCUATrayMenuItem.Name = "stopOPCUATrayMenuItem";
            this.stopOPCUATrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.stopOPCUATrayMenuItem.Text = "Stop";
            this.stopOPCUATrayMenuItem.Click += new System.EventHandler(this.stopOPCUATrayMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // exitTrayMenuItem
            // 
            this.exitTrayMenuItem.Name = "exitTrayMenuItem";
            this.exitTrayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitTrayMenuItem.Text = "Exit";
            this.exitTrayMenuItem.Click += new System.EventHandler(this.exitTrayMenuItem_Click);
            // 
            // savedInfoGridView
            // 
            this.savedInfoGridView.AllowUserToAddRows = false;
            this.savedInfoGridView.AllowUserToDeleteRows = false;
            this.savedInfoGridView.AllowUserToResizeColumns = false;
            this.savedInfoGridView.AllowUserToResizeRows = false;
            this.savedInfoGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.savedInfoGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.savedInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.savedInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeOfInformation_Column,
            this.savedValue_Column});
            this.savedInfoGridView.Location = new System.Drawing.Point(0, 285);
            this.savedInfoGridView.Name = "savedInfoGridView";
            this.savedInfoGridView.ReadOnly = true;
            this.savedInfoGridView.RowHeadersVisible = false;
            this.savedInfoGridView.Size = new System.Drawing.Size(544, 226);
            this.savedInfoGridView.TabIndex = 112;
            // 
            // typeOfInformation_Column
            // 
            this.typeOfInformation_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeOfInformation_Column.HeaderText = "Type of Information";
            this.typeOfInformation_Column.Name = "typeOfInformation_Column";
            this.typeOfInformation_Column.ReadOnly = true;
            // 
            // savedValue_Column
            // 
            this.savedValue_Column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.savedValue_Column.HeaderText = "Saved Value";
            this.savedValue_Column.Name = "savedValue_Column";
            this.savedValue_Column.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "OPCUA Saved Information:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "OPCDA Transaction Table:";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savedInfoGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.dataGridMonitor);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataLogger";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.formMain_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMonitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransaction)).EndInit();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.trayMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.savedInfoGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripMenuItem configurationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcConnectorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odbcConnectorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.DataGridView dataGridMonitor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel statusConfigLabel;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripButton opcConnectorButton;
        private System.Windows.Forms.ToolStripButton odbcConnectorButton;
        private System.Windows.Forms.ToolStripButton transactionButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem startTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideTrayMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Data.DataSet dsMonitor;
        private System.Data.DataTable dtTransaction;
        private System.Data.DataColumn dcTransactionName;
        private System.Data.DataColumn dcOPCState;
        private System.Data.DataColumn dcODBCState;
        private System.Data.DataColumn dcTransactionTotal;
        private System.Data.DataColumn dcTransactionPassed;
        private System.Data.DataColumn dcTransactionFailed;
        private System.Data.DataColumn dcPercent;
        private System.Windows.Forms.ToolStripMenuItem OPCUAToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton OPCUAConnectorButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oDBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn failedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripTextBox opcTrayTextBox;
        private System.Windows.Forms.ToolStripTextBox opcUATrayTextBox;
        private System.Windows.Forms.ToolStripMenuItem startOPCUATrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopOPCUATrayMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel textOPCLabel;
        private System.Windows.Forms.ToolStripLabel textOPCUALabel;
        private System.Windows.Forms.ToolStripButton startOPCUAButton;
        private System.Windows.Forms.ToolStripButton stopOPCUAButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripTextBox toolOPCTextBox;
        private System.Windows.Forms.ToolStripTextBox toolOPCUATextBox;
        private System.Windows.Forms.ToolStripMenuItem startOPCUAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopOPCUAMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.DataGridView savedInfoGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeOfInformation_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn savedValue_Column;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel statusConnectOPCUALabel;
    }
}

