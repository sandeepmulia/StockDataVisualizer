namespace StockDataVisualizer
{
    partial class StockAnalyzer
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputStockText = new System.Windows.Forms.TextBox();
            this.Display = new System.Windows.Forms.Button();
            this.recommendationView = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.recommendationView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stock Symbol";
            // 
            // InputStockText
            // 
            this.InputStockText.Location = new System.Drawing.Point(136, 30);
            this.InputStockText.Name = "InputStockText";
            this.InputStockText.Size = new System.Drawing.Size(109, 20);
            this.InputStockText.TabIndex = 2;
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(291, 30);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(94, 23);
            this.Display.TabIndex = 3;
            this.Display.Text = "Display";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Display_Click);
            // 
            // recommendationView
            // 
            this.recommendationView.AllowUserToAddRows = false;
            this.recommendationView.AllowUserToDeleteRows = false;
            this.recommendationView.AllowUserToOrderColumns = true;
            this.recommendationView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recommendationView.Location = new System.Drawing.Point(37, 84);
            this.recommendationView.Name = "recommendationView";
            this.recommendationView.ReadOnly = true;
            this.recommendationView.Size = new System.Drawing.Size(542, 84);
            this.recommendationView.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 248);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "Status";
            // 
            // StockAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 270);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.recommendationView);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.InputStockText);
            this.Controls.Add(this.label1);
            this.Name = "StockAnalyzer";
            this.Text = "Stock Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.recommendationView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputStockText;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.DataGridView recommendationView;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}