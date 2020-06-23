namespace Knight_s_tour
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txbBoardWidth = new System.Windows.Forms.TextBox();
            this.txbBoardHeight = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Укажите ширину и высоту доски:";
            // 
            // txbBoardWidth
            // 
            this.txbBoardWidth.Location = new System.Drawing.Point(16, 54);
            this.txbBoardWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBoardWidth.Name = "txbBoardWidth";
            this.txbBoardWidth.Size = new System.Drawing.Size(132, 22);
            this.txbBoardWidth.TabIndex = 1;
            this.txbBoardWidth.Text = "5";
            // 
            // txbBoardHeight
            // 
            this.txbBoardHeight.Location = new System.Drawing.Point(157, 54);
            this.txbBoardHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbBoardHeight.Name = "txbBoardHeight";
            this.txbBoardHeight.Size = new System.Drawing.Size(132, 22);
            this.txbBoardHeight.TabIndex = 2;
            this.txbBoardHeight.Text = "5";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(263, 118);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 161);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbBoardHeight);
            this.Controls.Add(this.txbBoardWidth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.ShowInTaskbar = false;
            this.Text = "Create New Board";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbBoardWidth;
        private System.Windows.Forms.TextBox txbBoardHeight;
        private System.Windows.Forms.Button btnOK;
    }
}