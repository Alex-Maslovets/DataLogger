namespace DataLogger
{
    partial class formDefineOPCUA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.connectPage = new System.Windows.Forms.TabPage();
            this.textBoxSQLDATColName = new System.Windows.Forms.TextBox();
            this.textBoxSQLValColName = new System.Windows.Forms.TextBox();
            this.textBoxSQLIDColName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSQLTableName = new System.Windows.Forms.TextBox();
            this.discoveryTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionGridView = new System.Windows.Forms.DataGridView();
            this.attributeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.nodeTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUri = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pwTextBox = new System.Windows.Forms.TextBox();
            this.userAnonButton = new System.Windows.Forms.RadioButton();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.userPwButton = new System.Windows.Forms.RadioButton();
            this.epConnectServerButton = new System.Windows.Forms.Button();
            this.endpointListView = new System.Windows.Forms.ListView();
            this.Endpoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endpointButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxS7DBName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.buttonTestConfig = new System.Windows.Forms.Button();
            this.textBoxS7RecArrayName = new System.Windows.Forms.TextBox();
            this.textBoxS7RecResetCountName = new System.Windows.Forms.TextBox();
            this.numericS7RecordsCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.opcTabControl = new System.Windows.Forms.TabControl();
            this.button2 = new System.Windows.Forms.Button();
            this.connectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericS7RecordsCount)).BeginInit();
            this.opcTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectPage
            // 
            this.connectPage.Controls.Add(this.textBoxSQLDATColName);
            this.connectPage.Controls.Add(this.textBoxSQLValColName);
            this.connectPage.Controls.Add(this.textBoxSQLIDColName);
            this.connectPage.Controls.Add(this.label10);
            this.connectPage.Controls.Add(this.label9);
            this.connectPage.Controls.Add(this.label8);
            this.connectPage.Controls.Add(this.label7);
            this.connectPage.Controls.Add(this.textBoxSQLTableName);
            this.connectPage.Controls.Add(this.discoveryTextBox);
            this.connectPage.Controls.Add(this.label3);
            this.connectPage.Controls.Add(this.descriptionGridView);
            this.connectPage.Controls.Add(this.label2);
            this.connectPage.Controls.Add(this.nodeTreeView);
            this.connectPage.Controls.Add(this.label1);
            this.connectPage.Controls.Add(this.labelUri);
            this.connectPage.Controls.Add(this.groupBox1);
            this.connectPage.Controls.Add(this.endpointListView);
            this.connectPage.Controls.Add(this.endpointButton);
            this.connectPage.Controls.Add(this.groupBox2);
            this.connectPage.Location = new System.Drawing.Point(4, 22);
            this.connectPage.Name = "connectPage";
            this.connectPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectPage.Size = new System.Drawing.Size(616, 383);
            this.connectPage.TabIndex = 0;
            this.connectPage.Text = "OPCUA Connection Parameters";
            this.connectPage.UseVisualStyleBackColor = true;
            // 
            // textBoxSQLDATColName
            // 
            this.textBoxSQLDATColName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSQLDATColName.Location = new System.Drawing.Point(442, 353);
            this.textBoxSQLDATColName.Name = "textBoxSQLDATColName";
            this.textBoxSQLDATColName.Size = new System.Drawing.Size(80, 20);
            this.textBoxSQLDATColName.TabIndex = 116;
            this.textBoxSQLDATColName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSQLValColName
            // 
            this.textBoxSQLValColName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSQLValColName.Location = new System.Drawing.Point(442, 327);
            this.textBoxSQLValColName.Name = "textBoxSQLValColName";
            this.textBoxSQLValColName.Size = new System.Drawing.Size(80, 20);
            this.textBoxSQLValColName.TabIndex = 115;
            this.textBoxSQLValColName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSQLIDColName
            // 
            this.textBoxSQLIDColName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSQLIDColName.Location = new System.Drawing.Point(442, 300);
            this.textBoxSQLIDColName.Name = "textBoxSQLIDColName";
            this.textBoxSQLIDColName.Size = new System.Drawing.Size(80, 20);
            this.textBoxSQLIDColName.TabIndex = 114;
            this.textBoxSQLIDColName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 113;
            this.label10.Text = "SQL. Time Column name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(305, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 112;
            this.label9.Text = "SQL. Value Column name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "SQL. ID Column name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "SQL. Table name:";
            // 
            // textBoxSQLTableName
            // 
            this.textBoxSQLTableName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSQLTableName.Location = new System.Drawing.Point(442, 274);
            this.textBoxSQLTableName.Name = "textBoxSQLTableName";
            this.textBoxSQLTableName.Size = new System.Drawing.Size(80, 20);
            this.textBoxSQLTableName.TabIndex = 105;
            this.textBoxSQLTableName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // discoveryTextBox
            // 
            this.discoveryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discoveryTextBox.Location = new System.Drawing.Point(6, 7);
            this.discoveryTextBox.Name = "discoveryTextBox";
            this.discoveryTextBox.Size = new System.Drawing.Size(255, 20);
            this.discoveryTextBox.TabIndex = 22;
            this.discoveryTextBox.Text = "opc.tcp://";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Selected node\'s information:";
            // 
            // descriptionGridView
            // 
            this.descriptionGridView.AllowUserToAddRows = false;
            this.descriptionGridView.AllowUserToDeleteRows = false;
            this.descriptionGridView.AllowUserToResizeColumns = false;
            this.descriptionGridView.AllowUserToResizeRows = false;
            this.descriptionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.descriptionGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.descriptionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attributeColumn,
            this.valueColumn});
            this.descriptionGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.descriptionGridView.Location = new System.Drawing.Point(313, 134);
            this.descriptionGridView.Name = "descriptionGridView";
            this.descriptionGridView.RowHeadersVisible = false;
            this.descriptionGridView.Size = new System.Drawing.Size(295, 125);
            this.descriptionGridView.TabIndex = 28;
            // 
            // attributeColumn
            // 
            this.attributeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.attributeColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.attributeColumn.HeaderText = "Attribute";
            this.attributeColumn.Name = "attributeColumn";
            // 
            // valueColumn
            // 
            this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.valueColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Browse the server\'s nodes:";
            // 
            // nodeTreeView
            // 
            this.nodeTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nodeTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.nodeTreeView.Location = new System.Drawing.Point(8, 134);
            this.nodeTreeView.Name = "nodeTreeView";
            this.nodeTreeView.Size = new System.Drawing.Size(291, 125);
            this.nodeTreeView.TabIndex = 26;
            this.nodeTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.NodeTreeView_BeforeExpand);
            this.nodeTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.NodeTreeView_BeforeSelect);
            this.nodeTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeTreeView_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(272, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 24;
            // 
            // labelUri
            // 
            this.labelUri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUri.AutoSize = true;
            this.labelUri.Location = new System.Drawing.Point(272, 254);
            this.labelUri.Name = "labelUri";
            this.labelUri.Size = new System.Drawing.Size(0, 13);
            this.labelUri.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pwTextBox);
            this.groupBox1.Controls.Add(this.userAnonButton);
            this.groupBox1.Controls.Add(this.userTextBox);
            this.groupBox1.Controls.Add(this.userPwButton);
            this.groupBox1.Controls.Add(this.epConnectServerButton);
            this.groupBox1.Location = new System.Drawing.Point(378, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 96);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User authentication";
            // 
            // pwTextBox
            // 
            this.pwTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pwTextBox.Enabled = false;
            this.pwTextBox.Location = new System.Drawing.Point(110, 37);
            this.pwTextBox.Name = "pwTextBox";
            this.pwTextBox.PasswordChar = '*';
            this.pwTextBox.Size = new System.Drawing.Size(110, 20);
            this.pwTextBox.TabIndex = 16;
            this.pwTextBox.Text = "Password";
            this.pwTextBox.UseSystemPasswordChar = true;
            // 
            // userAnonButton
            // 
            this.userAnonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userAnonButton.AutoSize = true;
            this.userAnonButton.Checked = true;
            this.userAnonButton.Location = new System.Drawing.Point(6, 17);
            this.userAnonButton.Name = "userAnonButton";
            this.userAnonButton.Size = new System.Drawing.Size(80, 17);
            this.userAnonButton.TabIndex = 13;
            this.userAnonButton.TabStop = true;
            this.userAnonButton.Text = "Anonymous";
            this.userAnonButton.UseVisualStyleBackColor = true;
            this.userAnonButton.CheckedChanged += new System.EventHandler(this.UserAnonButton_CheckedChanged);
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userTextBox.Enabled = false;
            this.userTextBox.Location = new System.Drawing.Point(110, 14);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(110, 20);
            this.userTextBox.TabIndex = 15;
            this.userTextBox.Text = "User name";
            // 
            // userPwButton
            // 
            this.userPwButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userPwButton.AutoSize = true;
            this.userPwButton.Location = new System.Drawing.Point(6, 40);
            this.userPwButton.Name = "userPwButton";
            this.userPwButton.Size = new System.Drawing.Size(98, 17);
            this.userPwButton.TabIndex = 14;
            this.userPwButton.Text = "User/Password";
            this.userPwButton.UseVisualStyleBackColor = true;
            this.userPwButton.CheckedChanged += new System.EventHandler(this.UserPwButton_CheckedChanged);
            // 
            // epConnectServerButton
            // 
            this.epConnectServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.epConnectServerButton.BackColor = System.Drawing.Color.Transparent;
            this.epConnectServerButton.Location = new System.Drawing.Point(6, 67);
            this.epConnectServerButton.Name = "epConnectServerButton";
            this.epConnectServerButton.Size = new System.Drawing.Size(214, 23);
            this.epConnectServerButton.TabIndex = 5;
            this.epConnectServerButton.Text = "Connect to selected Endpoint";
            this.epConnectServerButton.UseVisualStyleBackColor = false;
            this.epConnectServerButton.Click += new System.EventHandler(this.EpConnectServerButton_Click);
            // 
            // endpointListView
            // 
            this.endpointListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endpointListView.BackColor = System.Drawing.SystemColors.Window;
            this.endpointListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Endpoints});
            this.endpointListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.endpointListView.HideSelection = false;
            this.endpointListView.Location = new System.Drawing.Point(6, 32);
            this.endpointListView.MultiSelect = false;
            this.endpointListView.Name = "endpointListView";
            this.endpointListView.Size = new System.Drawing.Size(366, 82);
            this.endpointListView.TabIndex = 4;
            this.endpointListView.UseCompatibleStateImageBehavior = false;
            this.endpointListView.View = System.Windows.Forms.View.Details;
            this.endpointListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.EndpointListView_ItemSelectionChanged);
            // 
            // Endpoints
            // 
            this.Endpoints.Text = "Found Endpoints";
            this.Endpoints.Width = 900;
            // 
            // endpointButton
            // 
            this.endpointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endpointButton.Location = new System.Drawing.Point(267, 7);
            this.endpointButton.Name = "endpointButton";
            this.endpointButton.Size = new System.Drawing.Size(105, 20);
            this.endpointButton.TabIndex = 21;
            this.endpointButton.Text = "Get Endpoints";
            this.endpointButton.UseVisualStyleBackColor = true;
            this.endpointButton.Click += new System.EventHandler(this.EndpointButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBoxS7DBName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonSaveConfig);
            this.groupBox2.Controls.Add(this.buttonTestConfig);
            this.groupBox2.Controls.Add(this.textBoxS7RecArrayName);
            this.groupBox2.Controls.Add(this.textBoxS7RecResetCountName);
            this.groupBox2.Controls.Add(this.numericS7RecordsCount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(8, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 120);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 120;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBoxS7DBName
            // 
            this.textBoxS7DBName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxS7DBName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxS7DBName.Location = new System.Drawing.Point(137, 13);
            this.textBoxS7DBName.Name = "textBoxS7DBName";
            this.textBoxS7DBName.ReadOnly = true;
            this.textBoxS7DBName.Size = new System.Drawing.Size(80, 20);
            this.textBoxS7DBName.TabIndex = 118;
            this.textBoxS7DBName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 119;
            this.label11.Text = "S7. DB name:";
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSaveConfig.Location = new System.Drawing.Point(533, 94);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(61, 20);
            this.buttonSaveConfig.TabIndex = 102;
            this.buttonSaveConfig.Text = "SAVE";
            this.buttonSaveConfig.UseVisualStyleBackColor = false;
            this.buttonSaveConfig.Click += new System.EventHandler(this.ButtonSaveConfig_Click);
            // 
            // buttonTestConfig
            // 
            this.buttonTestConfig.BackColor = System.Drawing.Color.Transparent;
            this.buttonTestConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonTestConfig.Location = new System.Drawing.Point(533, 13);
            this.buttonTestConfig.Name = "buttonTestConfig";
            this.buttonTestConfig.Size = new System.Drawing.Size(61, 20);
            this.buttonTestConfig.TabIndex = 101;
            this.buttonTestConfig.Text = "TEST";
            this.buttonTestConfig.UseVisualStyleBackColor = false;
            this.buttonTestConfig.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // textBoxS7RecArrayName
            // 
            this.textBoxS7RecArrayName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxS7RecArrayName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxS7RecArrayName.Location = new System.Drawing.Point(137, 40);
            this.textBoxS7RecArrayName.Name = "textBoxS7RecArrayName";
            this.textBoxS7RecArrayName.ReadOnly = true;
            this.textBoxS7RecArrayName.Size = new System.Drawing.Size(80, 20);
            this.textBoxS7RecArrayName.TabIndex = 103;
            this.textBoxS7RecArrayName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxS7RecResetCountName
            // 
            this.textBoxS7RecResetCountName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxS7RecResetCountName.Location = new System.Drawing.Point(137, 67);
            this.textBoxS7RecResetCountName.Name = "textBoxS7RecResetCountName";
            this.textBoxS7RecResetCountName.ReadOnly = true;
            this.textBoxS7RecResetCountName.Size = new System.Drawing.Size(80, 20);
            this.textBoxS7RecResetCountName.TabIndex = 104;
            this.textBoxS7RecResetCountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericS7RecordsCount
            // 
            this.numericS7RecordsCount.BackColor = System.Drawing.SystemColors.Window;
            this.numericS7RecordsCount.Location = new System.Drawing.Point(137, 93);
            this.numericS7RecordsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericS7RecordsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericS7RecordsCount.Name = "numericS7RecordsCount";
            this.numericS7RecordsCount.Size = new System.Drawing.Size(80, 20);
            this.numericS7RecordsCount.TabIndex = 102;
            this.numericS7RecordsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericS7RecordsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "S7. Number of Records:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "S7. Records Array name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "S7. Reset Counter name:";
            // 
            // opcTabControl
            // 
            this.opcTabControl.Controls.Add(this.connectPage);
            this.opcTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opcTabControl.Location = new System.Drawing.Point(0, 0);
            this.opcTabControl.Name = "opcTabControl";
            this.opcTabControl.SelectedIndex = 0;
            this.opcTabControl.Size = new System.Drawing.Size(624, 409);
            this.opcTabControl.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 121;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // formDefineOPCUA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 409);
            this.Controls.Add(this.opcTabControl);
            this.Name = "formDefineOPCUA";
            this.Text = "OPCUA Connection";
            this.Load += new System.EventHandler(this.FormDefineOPCUA_Load);
            this.connectPage.ResumeLayout(false);
            this.connectPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericS7RecordsCount)).EndInit();
            this.opcTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage connectPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSQLTableName;
        private System.Windows.Forms.TextBox textBoxS7RecResetCountName;
        private System.Windows.Forms.TextBox textBoxS7RecArrayName;
        private System.Windows.Forms.TextBox discoveryTextBox;
        private System.Windows.Forms.NumericUpDown numericS7RecordsCount;
        private System.Windows.Forms.Button buttonTestConfig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView descriptionGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView nodeTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUri;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pwTextBox;
        private System.Windows.Forms.RadioButton userAnonButton;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.RadioButton userPwButton;
        private System.Windows.Forms.Button epConnectServerButton;
        private System.Windows.Forms.ListView endpointListView;
        private System.Windows.Forms.Button endpointButton;
        private System.Windows.Forms.TabControl opcTabControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Endpoints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSQLValColName;
        private System.Windows.Forms.TextBox textBoxSQLIDColName;
        private System.Windows.Forms.TextBox textBoxSQLDATColName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveConfig;
        private System.Windows.Forms.TextBox textBoxS7DBName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}