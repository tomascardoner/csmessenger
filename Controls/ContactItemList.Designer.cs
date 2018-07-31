namespace CSMessenger.Controls
{
    partial class ContactItemList
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
            this.flowlayoutpanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowlayoutpanelMain
            // 
            this.flowlayoutpanelMain.AutoScroll = true;
            this.flowlayoutpanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowlayoutpanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowlayoutpanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowlayoutpanelMain.Name = "flowlayoutpanelMain";
            this.flowlayoutpanelMain.Size = new System.Drawing.Size(148, 148);
            this.flowlayoutpanelMain.TabIndex = 0;
            this.flowlayoutpanelMain.WrapContents = false;
            // 
            // ContactItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowlayoutpanelMain);
            this.Name = "ContactItemList";
            this.Size = new System.Drawing.Size(148, 148);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowlayoutpanelMain;
    }
}
