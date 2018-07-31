namespace CSMessenger.Controls
{
    partial class MessageItemSent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelSentTime = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.ColumnCount = 4;
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelMain.Controls.Add(this.labelSentTime, 1, 0);
            this.panelMain.Controls.Add(this.labelText, 2, 0);
            this.panelMain.Controls.Add(this.labelStatus, 3, 0);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.RowCount = 1;
            this.panelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMain.Size = new System.Drawing.Size(300, 23);
            this.panelMain.TabIndex = 0;
            // 
            // labelSentTime
            // 
            this.labelSentTime.AutoSize = true;
            this.labelSentTime.Location = new System.Drawing.Point(43, 3);
            this.labelSentTime.Margin = new System.Windows.Forms.Padding(3);
            this.labelSentTime.Name = "labelSentTime";
            this.labelSentTime.Size = new System.Drawing.Size(34, 13);
            this.labelSentTime.TabIndex = 1;
            this.labelSentTime.Text = "00:00";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.SystemColors.Window;
            this.labelText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelText.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelText.Location = new System.Drawing.Point(83, 3);
            this.labelText.Margin = new System.Windows.Forms.Padding(3);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(174, 15);
            this.labelText.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStatus.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelStatus.Location = new System.Drawing.Point(263, 3);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(3);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(34, 17);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageItemSent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelMain);
            this.Name = "MessageItemSent";
            this.Size = new System.Drawing.Size(300, 23);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panelMain;
        private System.Windows.Forms.Label labelSentTime;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelStatus;

    }
}
