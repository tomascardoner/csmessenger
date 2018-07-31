namespace CSMessenger.Controls
{
    partial class MessageList
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
            this.panelMessages = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panelMessages
            // 
            this.panelMessages.ColumnCount = 1;
            this.panelMessages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessages.Location = new System.Drawing.Point(0, 0);
            this.panelMessages.Name = "panelMessages";
            this.panelMessages.RowCount = 1;
            this.panelMessages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMessages.Size = new System.Drawing.Size(300, 67);
            this.panelMessages.TabIndex = 0;
            // 
            // MessageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMessages);
            this.Name = "MessageList";
            this.Size = new System.Drawing.Size(300, 67);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel panelMessages;






    }
}
