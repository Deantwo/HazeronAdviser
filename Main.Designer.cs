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
            this.lbxShip = new System.Windows.Forms.ListBox();
            this.splitContainerShip = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.splitContainerCity = new System.Windows.Forms.SplitContainer();
            this.lbxCity = new System.Windows.Forms.ListBox();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tabShip = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).BeginInit();
            this.splitContainerShip.Panel1.SuspendLayout();
            this.splitContainerShip.Panel2.SuspendLayout();
            this.splitContainerShip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).BeginInit();
            this.splitContainerCity.Panel1.SuspendLayout();
            this.splitContainerCity.Panel2.SuspendLayout();
            this.splitContainerCity.SuspendLayout();
            this.tabShip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test";
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
            this.tbxShip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxShip.Location = new System.Drawing.Point(3, 3);
            this.tbxShip.Multiline = true;
            this.tbxShip.Name = "tbxShip";
            this.tbxShip.ReadOnly = true;
            this.tbxShip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxShip.Size = new System.Drawing.Size(406, 398);
            this.tbxShip.TabIndex = 0;
            this.tbxShip.WordWrap = false;
            // 
            // lbxShip
            // 
            this.lbxShip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxShip.FormattingEnabled = true;
            this.lbxShip.Location = new System.Drawing.Point(3, 3);
            this.lbxShip.Name = "lbxShip";
            this.lbxShip.Size = new System.Drawing.Size(324, 394);
            this.lbxShip.TabIndex = 4;
            this.lbxShip.SelectedIndexChanged += new System.EventHandler(this.lbxShip_SelectedIndexChanged);
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
            this.splitContainerShip.Panel1.Controls.Add(this.lbxShip);
            // 
            // splitContainerShip.Panel2
            // 
            this.splitContainerShip.Panel2.Controls.Add(this.tbxShip);
            this.splitContainerShip.Size = new System.Drawing.Size(746, 404);
            this.splitContainerShip.SplitterDistance = 330;
            this.splitContainerShip.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCity);
            this.tabControl1.Controls.Add(this.tabShip);
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
            this.splitContainerCity.Panel1.Controls.Add(this.lbxCity);
            // 
            // splitContainerCity.Panel2
            // 
            this.splitContainerCity.Panel2.Controls.Add(this.tbxCity);
            this.splitContainerCity.Size = new System.Drawing.Size(746, 404);
            this.splitContainerCity.SplitterDistance = 330;
            this.splitContainerCity.TabIndex = 6;
            // 
            // lbxCity
            // 
            this.lbxCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxCity.FormattingEnabled = true;
            this.lbxCity.Location = new System.Drawing.Point(3, 3);
            this.lbxCity.Name = "lbxCity";
            this.lbxCity.Size = new System.Drawing.Size(324, 394);
            this.lbxCity.TabIndex = 4;
            this.lbxCity.SelectedIndexChanged += new System.EventHandler(this.lbxCity_SelectedIndexChanged);
            // 
            // tbxCity
            // 
            this.tbxCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxCity.Location = new System.Drawing.Point(3, 3);
            this.tbxCity.Multiline = true;
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.ReadOnly = true;
            this.tbxCity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxCity.Size = new System.Drawing.Size(406, 398);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Hazeron Mayor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainerShip.Panel1.ResumeLayout(false);
            this.splitContainerShip.Panel2.ResumeLayout(false);
            this.splitContainerShip.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShip)).EndInit();
            this.splitContainerShip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCity.ResumeLayout(false);
            this.splitContainerCity.Panel1.ResumeLayout(false);
            this.splitContainerCity.Panel2.ResumeLayout(false);
            this.splitContainerCity.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCity)).EndInit();
            this.splitContainerCity.ResumeLayout(false);
            this.tabShip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox tbxShip;
        private System.Windows.Forms.ListBox lbxShip;
        private System.Windows.Forms.SplitContainer splitContainerShip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCity;
        private System.Windows.Forms.TabPage tabShip;
        private System.Windows.Forms.SplitContainer splitContainerCity;
        private System.Windows.Forms.ListBox lbxCity;
        private System.Windows.Forms.TextBox tbxCity;
    }
}

