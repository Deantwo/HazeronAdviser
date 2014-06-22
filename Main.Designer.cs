namespace HazeronAdviser
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbxShip = new System.Windows.Forms.TextBox();
            this.splitContainerShip = new System.Windows.Forms.SplitContainer();
            this.dgvShip = new System.Windows.Forms.DataGridView();
            this.ColumnShipIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnShipIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.splitContainerCity = new System.Windows.Forms.SplitContainer();
            this.dgvCity = new System.Windows.Forms.DataGridView();
            this.ColumnCityIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCitySelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCityIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityMorale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityAbandonment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityPopulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityLivingConditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlCity = new System.Windows.Forms.TabControl();
            this.tabCityStatistics = new System.Windows.Forms.TabPage();
            this.splitContainerCityStatistics = new System.Windows.Forms.SplitContainer();
            this.pCityStatisticsPop = new System.Windows.Forms.Panel();
            this.pCityStatisticsMorale = new System.Windows.Forms.Panel();
            this.tabCityMail = new System.Windows.Forms.TabPage();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tabShip = new System.Windows.Forms.TabPage();
            this.tabPageOfficer = new System.Windows.Forms.TabPage();
            this.splitContainerOfficer = new System.Windows.Forms.SplitContainer();
            this.dgvOfficer = new System.Windows.Forms.DataGridView();
            this.ColumnOfficerIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOfficerIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnOfficerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxOfficer = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbCharFilter = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).BeginInit();
            this.splitContainerShip.Panel1.SuspendLayout();
            this.splitContainerShip.Panel2.SuspendLayout();
            this.splitContainerShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShip)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).BeginInit();
            this.splitContainerCity.Panel1.SuspendLayout();
            this.splitContainerCity.Panel2.SuspendLayout();
            this.splitContainerCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).BeginInit();
            this.tabControlCity.SuspendLayout();
            this.tabCityStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCityStatistics)).BeginInit();
            this.splitContainerCityStatistics.Panel1.SuspendLayout();
            this.splitContainerCityStatistics.Panel2.SuspendLayout();
            this.splitContainerCityStatistics.SuspendLayout();
            this.tabCityMail.SuspendLayout();
            this.tabShip.SuspendLayout();
            this.tabPageOfficer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOfficer)).BeginInit();
            this.splitContainerOfficer.Panel1.SuspendLayout();
            this.splitContainerOfficer.Panel2.SuspendLayout();
            this.splitContainerOfficer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficer)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Scan HMails";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripProgressBar2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(790, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripProgressBar2
            // 
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // tbxShip
            // 
            this.tbxShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxShip.Location = new System.Drawing.Point(0, 0);
            this.tbxShip.Multiline = true;
            this.tbxShip.Name = "tbxShip";
            this.tbxShip.ReadOnly = true;
            this.tbxShip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxShip.Size = new System.Drawing.Size(416, 410);
            this.tbxShip.TabIndex = 0;
            this.tbxShip.WordWrap = false;
            // 
            // splitContainerShip
            // 
            this.splitContainerShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerShip.Location = new System.Drawing.Point(3, 3);
            this.splitContainerShip.Name = "splitContainerShip";
            // 
            // splitContainerShip.Panel1
            // 
            this.splitContainerShip.Panel1.Controls.Add(this.dgvShip);
            // 
            // splitContainerShip.Panel2
            // 
            this.splitContainerShip.Panel2.Controls.Add(this.tbxShip);
            this.splitContainerShip.Size = new System.Drawing.Size(752, 410);
            this.splitContainerShip.SplitterDistance = 332;
            this.splitContainerShip.TabIndex = 5;
            // 
            // dgvShip
            // 
            this.dgvShip.AllowUserToAddRows = false;
            this.dgvShip.AllowUserToDeleteRows = false;
            this.dgvShip.AllowUserToOrderColumns = true;
            this.dgvShip.AllowUserToResizeRows = false;
            this.dgvShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvShip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnShipIndex,
            this.ColumnShipSelection,
            this.ColumnShipIcon,
            this.ColumnShipName,
            this.ColumnShipFuel,
            this.ColumnShipDamage,
            this.ColumnShipDate});
            this.dgvShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShip.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvShip.EnableHeadersVisualStyles = false;
            this.dgvShip.Location = new System.Drawing.Point(0, 0);
            this.dgvShip.MultiSelect = false;
            this.dgvShip.Name = "dgvShip";
            this.dgvShip.ReadOnly = true;
            this.dgvShip.RowHeadersVisible = false;
            this.dgvShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShip.Size = new System.Drawing.Size(332, 410);
            this.dgvShip.TabIndex = 2;
            this.dgvShip.SelectionChanged += new System.EventHandler(this.dgvShip_SelectionChanged);
            // 
            // ColumnShipIndex
            // 
            this.ColumnShipIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnShipIndex.FillWeight = 20F;
            this.ColumnShipIndex.Frozen = true;
            this.ColumnShipIndex.HeaderText = "# Index";
            this.ColumnShipIndex.MinimumWidth = 20;
            this.ColumnShipIndex.Name = "ColumnShipIndex";
            this.ColumnShipIndex.ReadOnly = true;
            this.ColumnShipIndex.Visible = false;
            this.ColumnShipIndex.Width = 20;
            // 
            // ColumnShipSelection
            // 
            this.ColumnShipSelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnShipSelection.FillWeight = 20F;
            this.ColumnShipSelection.Frozen = true;
            this.ColumnShipSelection.HeaderText = "Selection";
            this.ColumnShipSelection.MinimumWidth = 20;
            this.ColumnShipSelection.Name = "ColumnShipSelection";
            this.ColumnShipSelection.ReadOnly = true;
            this.ColumnShipSelection.Visible = false;
            this.ColumnShipSelection.Width = 20;
            // 
            // ColumnShipIcon
            // 
            this.ColumnShipIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnShipIcon.FillWeight = 20F;
            this.ColumnShipIcon.Frozen = true;
            this.ColumnShipIcon.HeaderText = "Icon";
            this.ColumnShipIcon.MinimumWidth = 20;
            this.ColumnShipIcon.Name = "ColumnShipIcon";
            this.ColumnShipIcon.ReadOnly = true;
            this.ColumnShipIcon.Width = 20;
            // 
            // ColumnShipName
            // 
            this.ColumnShipName.Frozen = true;
            this.ColumnShipName.HeaderText = "Name";
            this.ColumnShipName.Name = "ColumnShipName";
            this.ColumnShipName.ReadOnly = true;
            // 
            // ColumnShipFuel
            // 
            this.ColumnShipFuel.HeaderText = "Fuel";
            this.ColumnShipFuel.Name = "ColumnShipFuel";
            this.ColumnShipFuel.ReadOnly = true;
            // 
            // ColumnShipDamage
            // 
            this.ColumnShipDamage.HeaderText = "Damage";
            this.ColumnShipDamage.Name = "ColumnShipDamage";
            this.ColumnShipDamage.ReadOnly = true;
            // 
            // ColumnShipDate
            // 
            this.ColumnShipDate.FillWeight = 107F;
            this.ColumnShipDate.HeaderText = "Last Updated";
            this.ColumnShipDate.Name = "ColumnShipDate";
            this.ColumnShipDate.ReadOnly = true;
            this.ColumnShipDate.Width = 107;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabCity);
            this.tabControlMain.Controls.Add(this.tabShip);
            this.tabControlMain.Controls.Add(this.tabPageOfficer);
            this.tabControlMain.Location = new System.Drawing.Point(12, 41);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(766, 442);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabCity
            // 
            this.tabCity.Controls.Add(this.splitContainerCity);
            this.tabCity.Location = new System.Drawing.Point(4, 22);
            this.tabCity.Name = "tabCity";
            this.tabCity.Padding = new System.Windows.Forms.Padding(3);
            this.tabCity.Size = new System.Drawing.Size(758, 416);
            this.tabCity.TabIndex = 0;
            this.tabCity.Text = "Cities";
            this.tabCity.UseVisualStyleBackColor = true;
            // 
            // splitContainerCity
            // 
            this.splitContainerCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCity.Location = new System.Drawing.Point(3, 3);
            this.splitContainerCity.Name = "splitContainerCity";
            // 
            // splitContainerCity.Panel1
            // 
            this.splitContainerCity.Panel1.Controls.Add(this.dgvCity);
            // 
            // splitContainerCity.Panel2
            // 
            this.splitContainerCity.Panel2.Controls.Add(this.tabControlCity);
            this.splitContainerCity.Size = new System.Drawing.Size(752, 410);
            this.splitContainerCity.SplitterDistance = 331;
            this.splitContainerCity.TabIndex = 6;
            // 
            // dgvCity
            // 
            this.dgvCity.AllowUserToAddRows = false;
            this.dgvCity.AllowUserToDeleteRows = false;
            this.dgvCity.AllowUserToOrderColumns = true;
            this.dgvCity.AllowUserToResizeRows = false;
            this.dgvCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCityIndex,
            this.ColumnCitySelection,
            this.ColumnCityIcon,
            this.ColumnCityName,
            this.ColumnCityMorale,
            this.ColumnCityAbandonment,
            this.ColumnCityPopulation,
            this.ColumnCityLivingConditions,
            this.ColumnCityDate});
            this.dgvCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCity.EnableHeadersVisualStyles = false;
            this.dgvCity.Location = new System.Drawing.Point(0, 0);
            this.dgvCity.MultiSelect = false;
            this.dgvCity.Name = "dgvCity";
            this.dgvCity.ReadOnly = true;
            this.dgvCity.RowHeadersVisible = false;
            this.dgvCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCity.Size = new System.Drawing.Size(331, 410);
            this.dgvCity.TabIndex = 2;
            this.dgvCity.SelectionChanged += new System.EventHandler(this.dgvCity_SelectionChanged);
            // 
            // ColumnCityIndex
            // 
            this.ColumnCityIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCityIndex.FillWeight = 20F;
            this.ColumnCityIndex.Frozen = true;
            this.ColumnCityIndex.HeaderText = "# Index";
            this.ColumnCityIndex.MinimumWidth = 20;
            this.ColumnCityIndex.Name = "ColumnCityIndex";
            this.ColumnCityIndex.ReadOnly = true;
            this.ColumnCityIndex.Visible = false;
            this.ColumnCityIndex.Width = 20;
            // 
            // ColumnCitySelection
            // 
            this.ColumnCitySelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCitySelection.FillWeight = 20F;
            this.ColumnCitySelection.Frozen = true;
            this.ColumnCitySelection.HeaderText = "Selection";
            this.ColumnCitySelection.MinimumWidth = 20;
            this.ColumnCitySelection.Name = "ColumnCitySelection";
            this.ColumnCitySelection.ReadOnly = true;
            this.ColumnCitySelection.Visible = false;
            this.ColumnCitySelection.Width = 20;
            // 
            // ColumnCityIcon
            // 
            this.ColumnCityIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCityIcon.FillWeight = 20F;
            this.ColumnCityIcon.Frozen = true;
            this.ColumnCityIcon.HeaderText = "Icon";
            this.ColumnCityIcon.MinimumWidth = 20;
            this.ColumnCityIcon.Name = "ColumnCityIcon";
            this.ColumnCityIcon.ReadOnly = true;
            this.ColumnCityIcon.Width = 20;
            // 
            // ColumnCityName
            // 
            this.ColumnCityName.Frozen = true;
            this.ColumnCityName.HeaderText = "Name";
            this.ColumnCityName.Name = "ColumnCityName";
            this.ColumnCityName.ReadOnly = true;
            // 
            // ColumnCityMorale
            // 
            this.ColumnCityMorale.FillWeight = 112F;
            this.ColumnCityMorale.HeaderText = "Morale";
            this.ColumnCityMorale.Name = "ColumnCityMorale";
            this.ColumnCityMorale.ReadOnly = true;
            this.ColumnCityMorale.Width = 112;
            // 
            // ColumnCityAbandonment
            // 
            this.ColumnCityAbandonment.FillWeight = 80F;
            this.ColumnCityAbandonment.HeaderText = "Abandonment";
            this.ColumnCityAbandonment.Name = "ColumnCityAbandonment";
            this.ColumnCityAbandonment.ReadOnly = true;
            this.ColumnCityAbandonment.Width = 80;
            // 
            // ColumnCityPopulation
            // 
            this.ColumnCityPopulation.FillWeight = 118F;
            this.ColumnCityPopulation.HeaderText = "Population";
            this.ColumnCityPopulation.Name = "ColumnCityPopulation";
            this.ColumnCityPopulation.ReadOnly = true;
            this.ColumnCityPopulation.Width = 118;
            // 
            // ColumnCityLivingConditions
            // 
            this.ColumnCityLivingConditions.FillWeight = 112F;
            this.ColumnCityLivingConditions.HeaderText = "Living Conditions";
            this.ColumnCityLivingConditions.Name = "ColumnCityLivingConditions";
            this.ColumnCityLivingConditions.ReadOnly = true;
            this.ColumnCityLivingConditions.Width = 112;
            // 
            // ColumnCityDate
            // 
            this.ColumnCityDate.FillWeight = 107F;
            this.ColumnCityDate.HeaderText = "Last Updated";
            this.ColumnCityDate.Name = "ColumnCityDate";
            this.ColumnCityDate.ReadOnly = true;
            this.ColumnCityDate.Width = 107;
            // 
            // tabControlCity
            // 
            this.tabControlCity.Controls.Add(this.tabCityStatistics);
            this.tabControlCity.Controls.Add(this.tabCityMail);
            this.tabControlCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCity.Location = new System.Drawing.Point(0, 0);
            this.tabControlCity.Name = "tabControlCity";
            this.tabControlCity.SelectedIndex = 0;
            this.tabControlCity.Size = new System.Drawing.Size(417, 410);
            this.tabControlCity.TabIndex = 1;
            // 
            // tabCityStatistics
            // 
            this.tabCityStatistics.Controls.Add(this.splitContainerCityStatistics);
            this.tabCityStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabCityStatistics.Name = "tabCityStatistics";
            this.tabCityStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabCityStatistics.Size = new System.Drawing.Size(409, 384);
            this.tabCityStatistics.TabIndex = 0;
            this.tabCityStatistics.Text = "Statistics";
            this.tabCityStatistics.UseVisualStyleBackColor = true;
            // 
            // splitContainerCityStatistics
            // 
            this.splitContainerCityStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCityStatistics.Location = new System.Drawing.Point(3, 3);
            this.splitContainerCityStatistics.Name = "splitContainerCityStatistics";
            this.splitContainerCityStatistics.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCityStatistics.Panel1
            // 
            this.splitContainerCityStatistics.Panel1.Controls.Add(this.pCityStatisticsPop);
            // 
            // splitContainerCityStatistics.Panel2
            // 
            this.splitContainerCityStatistics.Panel2.Controls.Add(this.pCityStatisticsMorale);
            this.splitContainerCityStatistics.Size = new System.Drawing.Size(403, 378);
            this.splitContainerCityStatistics.SplitterDistance = 263;
            this.splitContainerCityStatistics.TabIndex = 1;
            this.splitContainerCityStatistics.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainerCityStatistics_SplitterMoved);
            // 
            // pCityStatisticsPop
            // 
            this.pCityStatisticsPop.BackColor = System.Drawing.Color.LightGray;
            this.pCityStatisticsPop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCityStatisticsPop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCityStatisticsPop.Location = new System.Drawing.Point(0, 0);
            this.pCityStatisticsPop.Name = "pCityStatisticsPop";
            this.pCityStatisticsPop.Size = new System.Drawing.Size(403, 263);
            this.pCityStatisticsPop.TabIndex = 0;
            this.toolTip1.SetToolTip(this.pCityStatisticsPop, resources.GetString("pCityStatisticsPop.ToolTip"));
            this.pCityStatisticsPop.Paint += new System.Windows.Forms.PaintEventHandler(this.pCityStatistics_Paint);
            // 
            // pCityStatisticsMorale
            // 
            this.pCityStatisticsMorale.BackColor = System.Drawing.Color.LightGray;
            this.pCityStatisticsMorale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCityStatisticsMorale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCityStatisticsMorale.Location = new System.Drawing.Point(0, 0);
            this.pCityStatisticsMorale.Name = "pCityStatisticsMorale";
            this.pCityStatisticsMorale.Size = new System.Drawing.Size(403, 111);
            this.pCityStatisticsMorale.TabIndex = 1;
            this.toolTip1.SetToolTip(this.pCityStatisticsMorale, "Blue - Morale\r\nYellow - Morale Modifier total\r\nGreen - sum of Positive Morale Mod" +
                    "ifiers\r\nRed - sum of Negative Morale Modifiers");
            this.pCityStatisticsMorale.Paint += new System.Windows.Forms.PaintEventHandler(this.pCityStatisticsMorale_Paint);
            // 
            // tabCityMail
            // 
            this.tabCityMail.Controls.Add(this.tbxCity);
            this.tabCityMail.Location = new System.Drawing.Point(4, 22);
            this.tabCityMail.Name = "tabCityMail";
            this.tabCityMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabCityMail.Size = new System.Drawing.Size(409, 384);
            this.tabCityMail.TabIndex = 1;
            this.tabCityMail.Text = "Raw Mail";
            this.tabCityMail.UseVisualStyleBackColor = true;
            // 
            // tbxCity
            // 
            this.tbxCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCity.Location = new System.Drawing.Point(3, 3);
            this.tbxCity.Multiline = true;
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.ReadOnly = true;
            this.tbxCity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxCity.Size = new System.Drawing.Size(403, 378);
            this.tbxCity.TabIndex = 0;
            this.tbxCity.WordWrap = false;
            // 
            // tabShip
            // 
            this.tabShip.Controls.Add(this.splitContainerShip);
            this.tabShip.Location = new System.Drawing.Point(4, 22);
            this.tabShip.Name = "tabShip";
            this.tabShip.Padding = new System.Windows.Forms.Padding(3);
            this.tabShip.Size = new System.Drawing.Size(758, 416);
            this.tabShip.TabIndex = 1;
            this.tabShip.Text = "Ships";
            this.tabShip.UseVisualStyleBackColor = true;
            // 
            // tabPageOfficer
            // 
            this.tabPageOfficer.Controls.Add(this.splitContainerOfficer);
            this.tabPageOfficer.Location = new System.Drawing.Point(4, 22);
            this.tabPageOfficer.Name = "tabPageOfficer";
            this.tabPageOfficer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOfficer.Size = new System.Drawing.Size(758, 416);
            this.tabPageOfficer.TabIndex = 2;
            this.tabPageOfficer.Text = "Officers";
            this.tabPageOfficer.UseVisualStyleBackColor = true;
            // 
            // splitContainerOfficer
            // 
            this.splitContainerOfficer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOfficer.Location = new System.Drawing.Point(3, 3);
            this.splitContainerOfficer.Name = "splitContainerOfficer";
            // 
            // splitContainerOfficer.Panel1
            // 
            this.splitContainerOfficer.Panel1.Controls.Add(this.dgvOfficer);
            // 
            // splitContainerOfficer.Panel2
            // 
            this.splitContainerOfficer.Panel2.Controls.Add(this.tbxOfficer);
            this.splitContainerOfficer.Size = new System.Drawing.Size(752, 410);
            this.splitContainerOfficer.SplitterDistance = 332;
            this.splitContainerOfficer.TabIndex = 6;
            // 
            // dgvOfficer
            // 
            this.dgvOfficer.AllowUserToAddRows = false;
            this.dgvOfficer.AllowUserToDeleteRows = false;
            this.dgvOfficer.AllowUserToOrderColumns = true;
            this.dgvOfficer.AllowUserToResizeRows = false;
            this.dgvOfficer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOfficer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOfficerIndex,
            this.ColumnOfficerSelection,
            this.ColumnOfficerIcon,
            this.ColumnOfficerName,
            this.ColumnOfficerHome,
            this.ColumnOfficerLocation,
            this.ColumnOfficerDate});
            this.dgvOfficer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOfficer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOfficer.EnableHeadersVisualStyles = false;
            this.dgvOfficer.Location = new System.Drawing.Point(0, 0);
            this.dgvOfficer.MultiSelect = false;
            this.dgvOfficer.Name = "dgvOfficer";
            this.dgvOfficer.ReadOnly = true;
            this.dgvOfficer.RowHeadersVisible = false;
            this.dgvOfficer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficer.Size = new System.Drawing.Size(332, 410);
            this.dgvOfficer.TabIndex = 2;
            this.dgvOfficer.SelectionChanged += new System.EventHandler(this.dgvOfficer_SelectionChanged);
            // 
            // ColumnOfficerIndex
            // 
            this.ColumnOfficerIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOfficerIndex.FillWeight = 20F;
            this.ColumnOfficerIndex.Frozen = true;
            this.ColumnOfficerIndex.HeaderText = "# Index";
            this.ColumnOfficerIndex.MinimumWidth = 20;
            this.ColumnOfficerIndex.Name = "ColumnOfficerIndex";
            this.ColumnOfficerIndex.ReadOnly = true;
            this.ColumnOfficerIndex.Visible = false;
            this.ColumnOfficerIndex.Width = 20;
            // 
            // ColumnOfficerSelection
            // 
            this.ColumnOfficerSelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOfficerSelection.FillWeight = 20F;
            this.ColumnOfficerSelection.Frozen = true;
            this.ColumnOfficerSelection.HeaderText = "Selection";
            this.ColumnOfficerSelection.MinimumWidth = 20;
            this.ColumnOfficerSelection.Name = "ColumnOfficerSelection";
            this.ColumnOfficerSelection.ReadOnly = true;
            this.ColumnOfficerSelection.Visible = false;
            this.ColumnOfficerSelection.Width = 20;
            // 
            // ColumnOfficerIcon
            // 
            this.ColumnOfficerIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOfficerIcon.FillWeight = 20F;
            this.ColumnOfficerIcon.Frozen = true;
            this.ColumnOfficerIcon.HeaderText = "Icon";
            this.ColumnOfficerIcon.MinimumWidth = 20;
            this.ColumnOfficerIcon.Name = "ColumnOfficerIcon";
            this.ColumnOfficerIcon.ReadOnly = true;
            this.ColumnOfficerIcon.Width = 20;
            // 
            // ColumnOfficerName
            // 
            this.ColumnOfficerName.Frozen = true;
            this.ColumnOfficerName.HeaderText = "Name";
            this.ColumnOfficerName.Name = "ColumnOfficerName";
            this.ColumnOfficerName.ReadOnly = true;
            // 
            // ColumnOfficerHome
            // 
            this.ColumnOfficerHome.Frozen = true;
            this.ColumnOfficerHome.HeaderText = "Home";
            this.ColumnOfficerHome.Name = "ColumnOfficerHome";
            this.ColumnOfficerHome.ReadOnly = true;
            // 
            // ColumnOfficerLocation
            // 
            this.ColumnOfficerLocation.HeaderText = "Location";
            this.ColumnOfficerLocation.Name = "ColumnOfficerLocation";
            this.ColumnOfficerLocation.ReadOnly = true;
            // 
            // ColumnOfficerDate
            // 
            this.ColumnOfficerDate.FillWeight = 107F;
            this.ColumnOfficerDate.HeaderText = "Last Updated";
            this.ColumnOfficerDate.Name = "ColumnOfficerDate";
            this.ColumnOfficerDate.ReadOnly = true;
            this.ColumnOfficerDate.Width = 107;
            // 
            // tbxOfficer
            // 
            this.tbxOfficer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxOfficer.Location = new System.Drawing.Point(0, 0);
            this.tbxOfficer.Multiline = true;
            this.tbxOfficer.Name = "tbxOfficer";
            this.tbxOfficer.ReadOnly = true;
            this.tbxOfficer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxOfficer.Size = new System.Drawing.Size(416, 410);
            this.tbxOfficer.TabIndex = 0;
            this.tbxOfficer.WordWrap = false;
            // 
            // cmbCharFilter
            // 
            this.cmbCharFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCharFilter.Enabled = false;
            this.cmbCharFilter.FormattingEnabled = true;
            this.cmbCharFilter.Items.AddRange(new object[] {
            "Show all"});
            this.cmbCharFilter.Location = new System.Drawing.Point(93, 14);
            this.cmbCharFilter.Name = "cmbCharFilter";
            this.cmbCharFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbCharFilter.TabIndex = 3;
            this.cmbCharFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCharFilter_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 508);
            this.Controls.Add(this.cmbCharFilter);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Hazeron Adviser";
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerShip.Panel1.ResumeLayout(false);
            this.splitContainerShip.Panel2.ResumeLayout(false);
            this.splitContainerShip.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).EndInit();
            this.splitContainerShip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShip)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabCity.ResumeLayout(false);
            this.splitContainerCity.Panel1.ResumeLayout(false);
            this.splitContainerCity.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).EndInit();
            this.splitContainerCity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).EndInit();
            this.tabControlCity.ResumeLayout(false);
            this.tabCityStatistics.ResumeLayout(false);
            this.splitContainerCityStatistics.Panel1.ResumeLayout(false);
            this.splitContainerCityStatistics.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCityStatistics)).EndInit();
            this.splitContainerCityStatistics.ResumeLayout(false);
            this.tabCityMail.ResumeLayout(false);
            this.tabCityMail.PerformLayout();
            this.tabShip.ResumeLayout(false);
            this.tabPageOfficer.ResumeLayout(false);
            this.splitContainerOfficer.Panel1.ResumeLayout(false);
            this.splitContainerOfficer.Panel2.ResumeLayout(false);
            this.splitContainerOfficer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOfficer)).EndInit();
            this.splitContainerOfficer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbxShip;
        private System.Windows.Forms.SplitContainer splitContainerShip;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabCity;
        private System.Windows.Forms.TabPage tabShip;
        private System.Windows.Forms.SplitContainer splitContainerCity;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.DataGridView dgvShip;
        private System.Windows.Forms.DataGridView dgvCity;
        private System.Windows.Forms.TabPage tabPageOfficer;
        private System.Windows.Forms.SplitContainer splitContainerOfficer;
        private System.Windows.Forms.DataGridView dgvOfficer;
        private System.Windows.Forms.TextBox tbxOfficer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnShipSelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnShipIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOfficerSelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnOfficerIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerDate;
        private System.Windows.Forms.TabControl tabControlCity;
        private System.Windows.Forms.TabPage tabCityStatistics;
        private System.Windows.Forms.TabPage tabCityMail;
        private System.Windows.Forms.Panel pCityStatisticsPop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCitySelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCityIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityMorale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityAbandonment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityPopulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityLivingConditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainerCityStatistics;
        private System.Windows.Forms.Panel pCityStatisticsMorale;
        private System.Windows.Forms.ComboBox cmbCharFilter;
    }
}

