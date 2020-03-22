﻿namespace DataLogger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.configurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcConnectorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odbcConnectorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opcConnectorButton = new System.Windows.Forms.ToolStripButton();
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
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMonitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTransaction)).BeginInit();
            this.statusbar.SuspendLayout();
            this.trayMenu.SuspendLayout();
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
            this.menu.Size = new System.Drawing.Size(545, 24);
            this.menu.TabIndex = 0;
            // 
            // configurationMenuItem
            // 
            this.configurationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuItem,
            this.stopMenuItem,
            this.toolStripMenuItem2,
            this.exitMenuItem});
            this.configurationMenuItem.Name = "configurationMenuItem";
            this.configurationMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationMenuItem.Text = "Configuration";
            // 
            // startMenuItem
            // 
            this.startMenuItem.Enabled = false;
            this.startMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startMenuItem.Name = "startMenuItem";
            this.startMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startMenuItem.Text = "Start";
            this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Enabled = false;
            this.stopMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.stopMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::DataLogger.Properties.Resources.Critical;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // defineMenuItem
            // 
            this.defineMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcConnectorMenuItem,
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
            this.opcConnectorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opcConnectorMenuItem.Text = "OPC Connector";
            this.opcConnectorMenuItem.Click += new System.EventHandler(this.opcConnectorMenuItem_Click);
            // 
            // odbcConnectorMenuItem
            // 
            this.odbcConnectorMenuItem.Image = global::DataLogger.Properties.Resources.VSProject_database;
            this.odbcConnectorMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.odbcConnectorMenuItem.Name = "odbcConnectorMenuItem";
            this.odbcConnectorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.odbcConnectorMenuItem.Text = "ODBC Connector";
            this.odbcConnectorMenuItem.Click += new System.EventHandler(this.odbcConnectorMenuItem_Click);
            // 
            // transactionMenuItem
            // 
            this.transactionMenuItem.Image = global::DataLogger.Properties.Resources.Control_DataNavigator;
            this.transactionMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transactionMenuItem.Name = "transactionMenuItem";
            this.transactionMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transactionMenuItem.Text = "Transaction";
            this.transactionMenuItem.Click += new System.EventHandler(this.transactionMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Image = global::DataLogger.Properties.Resources.Help;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.stopButton,
            this.toolStripSeparator1,
            this.opcConnectorButton,
            this.odbcConnectorButton,
            this.transactionButton,
            this.toolStripSeparator2,
            this.aboutButton});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(545, 25);
            this.toolbar.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Enabled = false;
            this.startButton.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "Start configuration";
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
            this.stopButton.Text = "Stop configuration";
            this.stopButton.ToolTipText = "Stop configuration";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // opcConnectorButton
            // 
            this.opcConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.opcConnectorButton.Image = global::DataLogger.Properties.Resources.Control_DataConnector;
            this.opcConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opcConnectorButton.Name = "opcConnectorButton";
            this.opcConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.opcConnectorButton.Text = "Define OPC Connector";
            this.opcConnectorButton.ToolTipText = "Define OPC Connector";
            this.opcConnectorButton.Click += new System.EventHandler(this.opcConnectorButton_Click);
            // 
            // odbcConnectorButton
            // 
            this.odbcConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.odbcConnectorButton.Image = global::DataLogger.Properties.Resources.VSProject_database;
            this.odbcConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.odbcConnectorButton.Name = "odbcConnectorButton";
            this.odbcConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.odbcConnectorButton.Text = "Define ODBC Connector";
            this.odbcConnectorButton.ToolTipText = "Define ODBC Connector";
            this.odbcConnectorButton.Click += new System.EventHandler(this.odbcConnectorButton_Click);
            // 
            // transactionButton
            // 
            this.transactionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transactionButton.Image = global::DataLogger.Properties.Resources.Control_DataNavigator;
            this.transactionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transactionButton.Name = "transactionButton";
            this.transactionButton.Size = new System.Drawing.Size(23, 22);
            this.transactionButton.Text = "Define transaction";
            this.transactionButton.ToolTipText = "Define transaction";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dataGridMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridMonitor.Location = new System.Drawing.Point(0, 49);
            this.dataGridMonitor.Name = "dataGridMonitor";
            this.dataGridMonitor.ReadOnly = true;
            this.dataGridMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMonitor.Size = new System.Drawing.Size(545, 474);
            this.dataGridMonitor.TabIndex = 3;
            // 
            // transactionDataGridViewTextBoxColumn
            // 
            this.transactionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.transactionDataGridViewTextBoxColumn.DataPropertyName = "Transaction";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.transactionDataGridViewTextBoxColumn.HeaderText = "Transaction";
            this.transactionDataGridViewTextBoxColumn.Name = "transactionDataGridViewTextBoxColumn";
            this.transactionDataGridViewTextBoxColumn.ReadOnly = true;
            this.transactionDataGridViewTextBoxColumn.Width = 88;
            // 
            // oPCDataGridViewTextBoxColumn
            // 
            this.oPCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oPCDataGridViewTextBoxColumn.DataPropertyName = "OPC";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oPCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.oPCDataGridViewTextBoxColumn.HeaderText = "OPC";
            this.oPCDataGridViewTextBoxColumn.Name = "oPCDataGridViewTextBoxColumn";
            this.oPCDataGridViewTextBoxColumn.ReadOnly = true;
            this.oPCDataGridViewTextBoxColumn.Width = 54;
            // 
            // oDBCDataGridViewTextBoxColumn
            // 
            this.oDBCDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oDBCDataGridViewTextBoxColumn.DataPropertyName = "ODBC";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oDBCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.oDBCDataGridViewTextBoxColumn.HeaderText = "ODBC";
            this.oDBCDataGridViewTextBoxColumn.Name = "oDBCDataGridViewTextBoxColumn";
            this.oDBCDataGridViewTextBoxColumn.ReadOnly = true;
            this.oDBCDataGridViewTextBoxColumn.Width = 62;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 56;
            // 
            // passedDataGridViewTextBoxColumn
            // 
            this.passedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.passedDataGridViewTextBoxColumn.DataPropertyName = "Passed";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.passedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.passedDataGridViewTextBoxColumn.HeaderText = "Passed";
            this.passedDataGridViewTextBoxColumn.Name = "passedDataGridViewTextBoxColumn";
            this.passedDataGridViewTextBoxColumn.ReadOnly = true;
            this.passedDataGridViewTextBoxColumn.Width = 67;
            // 
            // failedDataGridViewTextBoxColumn
            // 
            this.failedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.failedDataGridViewTextBoxColumn.DataPropertyName = "Failed";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.failedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.failedDataGridViewTextBoxColumn.HeaderText = "Failed";
            this.failedDataGridViewTextBoxColumn.Name = "failedDataGridViewTextBoxColumn";
            this.failedDataGridViewTextBoxColumn.ReadOnly = true;
            this.failedDataGridViewTextBoxColumn.Width = 60;
            // 
            // passedDataGridViewTextBoxColumn1
            // 
            this.passedDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.passedDataGridViewTextBoxColumn1.DataPropertyName = "% Passed";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.passedDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
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
            this.statusConfigLabel});
            this.statusbar.Location = new System.Drawing.Point(0, 496);
            this.statusbar.Name = "statusbar";
            this.statusbar.Size = new System.Drawing.Size(545, 27);
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
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.ContextMenuStrip = this.trayMenu;
            this.trayNotifyIcon.Visible = true;
            this.trayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayNotifyIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideTrayMenuItem,
            this.restoreTrayMenuItem,
            this.toolStripSeparator3,
            this.startTrayMenuItem,
            this.stopTrayMenuItem,
            this.toolStripSeparator4,
            this.exitTrayMenuItem});
            this.trayMenu.Name = "trayContextMenu";
            this.trayMenu.Size = new System.Drawing.Size(114, 126);
            // 
            // hideTrayMenuItem
            // 
            this.hideTrayMenuItem.Name = "hideTrayMenuItem";
            this.hideTrayMenuItem.Size = new System.Drawing.Size(113, 22);
            this.hideTrayMenuItem.Text = "Hide";
            this.hideTrayMenuItem.Click += new System.EventHandler(this.hideTraMenuItem_Click);
            // 
            // restoreTrayMenuItem
            // 
            this.restoreTrayMenuItem.Name = "restoreTrayMenuItem";
            this.restoreTrayMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreTrayMenuItem.Text = "Restore";
            this.restoreTrayMenuItem.Click += new System.EventHandler(this.restoreTrayMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(110, 6);
            // 
            // startTrayMenuItem
            // 
            this.startTrayMenuItem.Image = global::DataLogger.Properties.Resources.PlayHS;
            this.startTrayMenuItem.Name = "startTrayMenuItem";
            this.startTrayMenuItem.Size = new System.Drawing.Size(113, 22);
            this.startTrayMenuItem.Text = "Start";
            this.startTrayMenuItem.Click += new System.EventHandler(this.startTrayMenuItem_Click);
            // 
            // stopTrayMenuItem
            // 
            this.stopTrayMenuItem.Image = global::DataLogger.Properties.Resources.StopHS;
            this.stopTrayMenuItem.Name = "stopTrayMenuItem";
            this.stopTrayMenuItem.Size = new System.Drawing.Size(113, 22);
            this.stopTrayMenuItem.Text = "Stop";
            this.stopTrayMenuItem.Click += new System.EventHandler(this.stopTrayMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(110, 6);
            // 
            // exitTrayMenuItem
            // 
            this.exitTrayMenuItem.Name = "exitTrayMenuItem";
            this.exitTrayMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitTrayMenuItem.Text = "Exit";
            this.exitTrayMenuItem.Click += new System.EventHandler(this.exitTrayMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 523);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn transactionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oDBCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn failedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passedDataGridViewTextBoxColumn1;

    }
}
