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
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbxShip = new System.Windows.Forms.TextBox();
            this.splitContainerShip = new System.Windows.Forms.SplitContainer();
            this.dgvShip = new System.Windows.Forms.DataGridView();
            this.ColumnShipSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnShipIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipDamage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.splitContainerCity = new System.Windows.Forms.SplitContainer();
            this.dgvCity = new System.Windows.Forms.DataGridView();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tabShip = new System.Windows.Forms.TabPage();
            this.tabPageOfficer = new System.Windows.Forms.TabPage();
            this.splitContainerOfficer = new System.Windows.Forms.SplitContainer();
            this.dgvOfficer = new System.Windows.Forms.DataGridView();
            this.ColumnOfficerSelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnOfficerIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnOfficerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerHome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOfficerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbxOfficer = new System.Windows.Forms.TextBox();
            this.ColumnCitySelection = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCityIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnCityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityMorale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityPopulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityLivingConditions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).BeginInit();
            this.splitContainerShip.Panel1.SuspendLayout();
            this.splitContainerShip.Panel2.SuspendLayout();
            this.splitContainerShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShip)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).BeginInit();
            this.splitContainerCity.Panel1.SuspendLayout();
            this.splitContainerCity.Panel2.SuspendLayout();
            this.splitContainerCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).BeginInit();
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
            this.tbxShip.Size = new System.Drawing.Size(412, 404);
            this.tbxShip.TabIndex = 0;
            this.tbxShip.WordWrap = false;
            // 
            // splitContainerShip
            // 
            this.splitContainerShip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerShip.Location = new System.Drawing.Point(6, 6);
            this.splitContainerShip.Name = "splitContainerShip";
            // 
            // splitContainerShip.Panel1
            // 
            this.splitContainerShip.Panel1.Controls.Add(this.dgvShip);
            // 
            // splitContainerShip.Panel2
            // 
            this.splitContainerShip.Panel2.Controls.Add(this.tbxShip);
            this.splitContainerShip.Size = new System.Drawing.Size(746, 404);
            this.splitContainerShip.SplitterDistance = 330;
            this.splitContainerShip.TabIndex = 5;
            // 
            // dgvShip
            // 
            this.dgvShip.AllowUserToAddRows = false;
            this.dgvShip.AllowUserToDeleteRows = false;
            this.dgvShip.AllowUserToOrderColumns = true;
            this.dgvShip.AllowUserToResizeRows = false;
            this.dgvShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvShip.RowHeadersVisible = false;
            this.dgvShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShip.Size = new System.Drawing.Size(330, 404);
            this.dgvShip.TabIndex = 0;
            this.dgvShip.SelectionChanged += new System.EventHandler(this.dgvShip_SelectionChanged);
            // 
            // ColumnShipSelection
            // 
            this.ColumnShipSelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnShipSelection.FillWeight = 20F;
            this.ColumnShipSelection.Frozen = true;
            this.ColumnShipSelection.HeaderText = "Selection";
            this.ColumnShipSelection.MinimumWidth = 20;
            this.ColumnShipSelection.Name = "ColumnShipSelection";
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
            this.ColumnShipIcon.Width = 20;
            // 
            // ColumnShipName
            // 
            this.ColumnShipName.Frozen = true;
            this.ColumnShipName.HeaderText = "Name";
            this.ColumnShipName.Name = "ColumnShipName";
            // 
            // ColumnShipFuel
            // 
            this.ColumnShipFuel.Frozen = true;
            this.ColumnShipFuel.HeaderText = "Fuel";
            this.ColumnShipFuel.Name = "ColumnShipFuel";
            // 
            // ColumnShipDamage
            // 
            this.ColumnShipDamage.Frozen = true;
            this.ColumnShipDamage.HeaderText = "Damage";
            this.ColumnShipDamage.Name = "ColumnShipDamage";
            // 
            // ColumnShipDate
            // 
            this.ColumnShipDate.Frozen = true;
            this.ColumnShipDate.HeaderText = "Last Updated";
            this.ColumnShipDate.Name = "ColumnShipDate";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCity);
            this.tabControl1.Controls.Add(this.tabShip);
            this.tabControl1.Controls.Add(this.tabPageOfficer);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 442);
            this.tabControl1.TabIndex = 1;
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
            this.splitContainerCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerCity.Location = new System.Drawing.Point(6, 6);
            this.splitContainerCity.Name = "splitContainerCity";
            // 
            // splitContainerCity.Panel1
            // 
            this.splitContainerCity.Panel1.Controls.Add(this.dgvCity);
            // 
            // splitContainerCity.Panel2
            // 
            this.splitContainerCity.Panel2.Controls.Add(this.tbxCity);
            this.splitContainerCity.Size = new System.Drawing.Size(746, 404);
            this.splitContainerCity.SplitterDistance = 330;
            this.splitContainerCity.TabIndex = 6;
            // 
            // dgvCity
            // 
            this.dgvCity.AllowUserToAddRows = false;
            this.dgvCity.AllowUserToDeleteRows = false;
            this.dgvCity.AllowUserToOrderColumns = true;
            this.dgvCity.AllowUserToResizeRows = false;
            this.dgvCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCitySelection,
            this.ColumnCityIcon,
            this.ColumnCityName,
            this.ColumnCityMorale,
            this.ColumnCityPopulation,
            this.ColumnCityLivingConditions,
            this.ColumnCityDate});
            this.dgvCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCity.EnableHeadersVisualStyles = false;
            this.dgvCity.Location = new System.Drawing.Point(0, 0);
            this.dgvCity.MultiSelect = false;
            this.dgvCity.Name = "dgvCity";
            this.dgvCity.RowHeadersVisible = false;
            this.dgvCity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCity.Size = new System.Drawing.Size(330, 404);
            this.dgvCity.TabIndex = 2;
            this.dgvCity.SelectionChanged += new System.EventHandler(this.dgvCity_SelectionChanged);
            // 
            // tbxCity
            // 
            this.tbxCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCity.Location = new System.Drawing.Point(0, 0);
            this.tbxCity.Multiline = true;
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.ReadOnly = true;
            this.tbxCity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxCity.Size = new System.Drawing.Size(412, 404);
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
            this.splitContainerOfficer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerOfficer.Location = new System.Drawing.Point(6, 6);
            this.splitContainerOfficer.Name = "splitContainerOfficer";
            // 
            // splitContainerOfficer.Panel1
            // 
            this.splitContainerOfficer.Panel1.Controls.Add(this.dgvOfficer);
            // 
            // splitContainerOfficer.Panel2
            // 
            this.splitContainerOfficer.Panel2.Controls.Add(this.tbxOfficer);
            this.splitContainerOfficer.Size = new System.Drawing.Size(746, 404);
            this.splitContainerOfficer.SplitterDistance = 330;
            this.splitContainerOfficer.TabIndex = 6;
            // 
            // dgvOfficer
            // 
            this.dgvOfficer.AllowUserToAddRows = false;
            this.dgvOfficer.AllowUserToDeleteRows = false;
            this.dgvOfficer.AllowUserToOrderColumns = true;
            this.dgvOfficer.AllowUserToResizeRows = false;
            this.dgvOfficer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvOfficer.RowHeadersVisible = false;
            this.dgvOfficer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfficer.Size = new System.Drawing.Size(330, 404);
            this.dgvOfficer.TabIndex = 0;
            this.dgvOfficer.SelectionChanged += new System.EventHandler(this.dgvOfficer_SelectionChanged);
            // 
            // ColumnOfficerSelection
            // 
            this.ColumnOfficerSelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOfficerSelection.FillWeight = 20F;
            this.ColumnOfficerSelection.Frozen = true;
            this.ColumnOfficerSelection.HeaderText = "Selection";
            this.ColumnOfficerSelection.MinimumWidth = 20;
            this.ColumnOfficerSelection.Name = "ColumnOfficerSelection";
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
            this.ColumnOfficerIcon.Width = 20;
            // 
            // ColumnOfficerName
            // 
            this.ColumnOfficerName.Frozen = true;
            this.ColumnOfficerName.HeaderText = "Name";
            this.ColumnOfficerName.Name = "ColumnOfficerName";
            // 
            // ColumnOfficerHome
            // 
            this.ColumnOfficerHome.Frozen = true;
            this.ColumnOfficerHome.HeaderText = "Home";
            this.ColumnOfficerHome.Name = "ColumnOfficerHome";
            // 
            // ColumnOfficerLocation
            // 
            this.ColumnOfficerLocation.Frozen = true;
            this.ColumnOfficerLocation.HeaderText = "Location";
            this.ColumnOfficerLocation.Name = "ColumnOfficerLocation";
            // 
            // ColumnOfficerDate
            // 
            this.ColumnOfficerDate.Frozen = true;
            this.ColumnOfficerDate.HeaderText = "Last Updated";
            this.ColumnOfficerDate.Name = "ColumnOfficerDate";
            // 
            // tbxOfficer
            // 
            this.tbxOfficer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxOfficer.Location = new System.Drawing.Point(0, 0);
            this.tbxOfficer.Multiline = true;
            this.tbxOfficer.Name = "tbxOfficer";
            this.tbxOfficer.ReadOnly = true;
            this.tbxOfficer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxOfficer.Size = new System.Drawing.Size(412, 404);
            this.tbxOfficer.TabIndex = 0;
            this.tbxOfficer.WordWrap = false;
            // 
            // ColumnCitySelection
            // 
            this.ColumnCitySelection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnCitySelection.FillWeight = 20F;
            this.ColumnCitySelection.Frozen = true;
            this.ColumnCitySelection.HeaderText = "Selection";
            this.ColumnCitySelection.MinimumWidth = 20;
            this.ColumnCitySelection.Name = "ColumnCitySelection";
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
            this.ColumnCityIcon.Width = 20;
            // 
            // ColumnCityName
            // 
            this.ColumnCityName.Frozen = true;
            this.ColumnCityName.HeaderText = "Name";
            this.ColumnCityName.Name = "ColumnCityName";
            // 
            // ColumnCityMorale
            // 
            this.ColumnCityMorale.HeaderText = "Morale";
            this.ColumnCityMorale.Name = "ColumnCityMorale";
            // 
            // ColumnCityPopulation
            // 
            this.ColumnCityPopulation.HeaderText = "Population";
            this.ColumnCityPopulation.Name = "ColumnCityPopulation";
            // 
            // ColumnCityLivingConditions
            // 
            this.ColumnCityLivingConditions.HeaderText = "Living Conditions";
            this.ColumnCityLivingConditions.Name = "ColumnCityLivingConditions";
            this.ColumnCityLivingConditions.ReadOnly = true;
            // 
            // ColumnCityDate
            // 
            this.ColumnCityDate.HeaderText = "Last Updated";
            this.ColumnCityDate.Name = "ColumnCityDate";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Main";
            this.Text = "Hazeron Adviser";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerShip.Panel1.ResumeLayout(false);
            this.splitContainerShip.Panel2.ResumeLayout(false);
            this.splitContainerShip.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).EndInit();
            this.splitContainerShip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShip)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabCity.ResumeLayout(false);
            this.splitContainerCity.Panel1.ResumeLayout(false);
            this.splitContainerCity.Panel2.ResumeLayout(false);
            this.splitContainerCity.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).EndInit();
            this.splitContainerCity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnShipSelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnShipIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShipDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOfficerSelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnOfficerIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOfficerDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCitySelection;
        private System.Windows.Forms.DataGridViewImageColumn ColumnCityIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityMorale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityPopulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityLivingConditions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCityDate;
    }
}

