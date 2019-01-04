namespace StockDataVisualizer
{
    partial class StockDataVisualizer
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
            this.stockgroupbox = new System.Windows.Forms.GroupBox();
            this.stockTickerGrid = new System.Windows.Forms.DataGridView();
            this.startbtn = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            this.FindStkPerf = new System.Windows.Forms.Button();
            this.FindPerf = new System.Windows.Forms.Button();
            this.perfgrpBox = new System.Windows.Forms.GroupBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.startTip = new System.Windows.Forms.ToolTip(this.components);
            this.bestTip = new System.Windows.Forms.ToolTip(this.components);
            this.intradayTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stockgroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockTickerGrid)).BeginInit();
            this.perfgrpBox.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockgroupbox
            // 
            this.stockgroupbox.Controls.Add(this.stockTickerGrid);
            this.stockgroupbox.Location = new System.Drawing.Point(12, 12);
            this.stockgroupbox.Name = "stockgroupbox";
            this.stockgroupbox.Size = new System.Drawing.Size(783, 356);
            this.stockgroupbox.TabIndex = 0;
            this.stockgroupbox.TabStop = false;
            this.stockgroupbox.Text = "Stock";
            // 
            // stockTickerGrid
            // 
            this.stockTickerGrid.AllowUserToAddRows = false;
            this.stockTickerGrid.AllowUserToDeleteRows = false;
            this.stockTickerGrid.AllowUserToOrderColumns = true;
            this.stockTickerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockTickerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockTickerGrid.Location = new System.Drawing.Point(3, 16);
            this.stockTickerGrid.Name = "stockTickerGrid";
            this.stockTickerGrid.ReadOnly = true;
            this.stockTickerGrid.Size = new System.Drawing.Size(777, 337);
            this.stockTickerGrid.TabIndex = 0;
            // 
            // startbtn
            // 
            this.startbtn.Location = new System.Drawing.Point(27, 403);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(99, 23);
            this.startbtn.TabIndex = 1;
            this.startbtn.Text = "Start Tick";
            this.startTip.SetToolTip(this.startbtn, "Starts the ticker");
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // stopbtn
            // 
            this.stopbtn.Location = new System.Drawing.Point(144, 403);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(91, 23);
            this.stopbtn.TabIndex = 2;
            this.stopbtn.Text = "Stop Tick";
            this.ToolTip.SetToolTip(this.stopbtn, "Stops the ticker");
            this.stopbtn.UseVisualStyleBackColor = true;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // FindStkPerf
            // 
            this.FindStkPerf.Location = new System.Drawing.Point(17, 59);
            this.FindStkPerf.Name = "FindStkPerf";
            this.FindStkPerf.Size = new System.Drawing.Size(199, 23);
            this.FindStkPerf.TabIndex = 3;
            this.FindStkPerf.Text = "Find Intraday Performance";
            this.intradayTip.SetToolTip(this.FindStkPerf, "Find Intraday performance(Compare with Market Open Price)");
            this.FindStkPerf.UseVisualStyleBackColor = true;
            this.FindStkPerf.Click += new System.EventHandler(this.FindStkPerf_Click);
            // 
            // FindPerf
            // 
            this.FindPerf.Location = new System.Drawing.Point(17, 19);
            this.FindPerf.Name = "FindPerf";
            this.FindPerf.Size = new System.Drawing.Size(199, 23);
            this.FindPerf.TabIndex = 4;
            this.FindPerf.Text = "Find Best/Worst Performer";
            this.bestTip.SetToolTip(this.FindPerf, "Find Best/Worst Performing stocks (Compare current price with Yesterdays Market C" +
        "lose price)");
            this.FindPerf.UseVisualStyleBackColor = true;
            this.FindPerf.Click += new System.EventHandler(this.FindPerf_Click);
            // 
            // perfgrpBox
            // 
            this.perfgrpBox.Controls.Add(this.FindPerf);
            this.perfgrpBox.Controls.Add(this.FindStkPerf);
            this.perfgrpBox.Location = new System.Drawing.Point(444, 374);
            this.perfgrpBox.Name = "perfgrpBox";
            this.perfgrpBox.Size = new System.Drawing.Size(286, 100);
            this.perfgrpBox.TabIndex = 5;
            this.perfgrpBox.TabStop = false;
            this.perfgrpBox.Text = "Performance Analyzer";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 496);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(825, 22);
            this.statusBar.TabIndex = 6;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // StockDataVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 518);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.perfgrpBox);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.stockgroupbox);
            this.Name = "StockDataVisualizer";
            this.Text = "Stock Ticker";
            this.stockgroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockTickerGrid)).EndInit();
            this.perfgrpBox.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox stockgroupbox;
        private System.Windows.Forms.DataGridView stockTickerGrid;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Button stopbtn;
        private System.Windows.Forms.Button FindStkPerf;
        private System.Windows.Forms.Button FindPerf;
        private System.Windows.Forms.GroupBox perfgrpBox;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ToolTip startTip;
        private System.Windows.Forms.ToolTip bestTip;
        private System.Windows.Forms.ToolTip intradayTip;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}

