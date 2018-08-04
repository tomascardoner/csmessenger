namespace CSMessenger
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.splitcontainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listviewUsers = new System.Windows.Forms.ListView();
            this.buttonNewChat = new System.Windows.Forms.Button();
            this.panelUserInfoAndMessageListAndMessageNew = new System.Windows.Forms.TableLayoutPanel();
            this.panelUserInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.panelMessageList = new System.Windows.Forms.Panel();
            this.panelMessageNew = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMessageSend = new System.Windows.Forms.Button();
            this.textboxMessageNew = new System.Windows.Forms.TextBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerMain)).BeginInit();
            this.splitcontainerMain.Panel1.SuspendLayout();
            this.splitcontainerMain.Panel2.SuspendLayout();
            this.splitcontainerMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelUserInfoAndMessageListAndMessageNew.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.panelMessageNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitcontainerMain
            // 
            this.splitcontainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitcontainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitcontainerMain.IsSplitterFixed = true;
            this.splitcontainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitcontainerMain.Name = "splitcontainerMain";
            // 
            // splitcontainerMain.Panel1
            // 
            this.splitcontainerMain.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitcontainerMain.Panel1MinSize = 100;
            // 
            // splitcontainerMain.Panel2
            // 
            this.splitcontainerMain.Panel2.Controls.Add(this.panelUserInfoAndMessageListAndMessageNew);
            this.splitcontainerMain.Panel2MinSize = 100;
            this.splitcontainerMain.Size = new System.Drawing.Size(725, 499);
            this.splitcontainerMain.SplitterDistance = 233;
            this.splitcontainerMain.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listviewUsers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonNewChat, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 499);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listviewUsers
            // 
            this.listviewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listviewUsers.Location = new System.Drawing.Point(3, 33);
            this.listviewUsers.Name = "listviewUsers";
            this.listviewUsers.Size = new System.Drawing.Size(227, 463);
            this.listviewUsers.TabIndex = 1;
            this.listviewUsers.UseCompatibleStateImageBehavior = false;
            this.listviewUsers.View = System.Windows.Forms.View.Tile;
            this.listviewUsers.Click += new System.EventHandler(this.UserChatClick);
            // 
            // buttonNewChat
            // 
            this.buttonNewChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewChat.Location = new System.Drawing.Point(3, 3);
            this.buttonNewChat.Name = "buttonNewChat";
            this.buttonNewChat.Size = new System.Drawing.Size(227, 24);
            this.buttonNewChat.TabIndex = 2;
            this.buttonNewChat.Text = "Nuevo chat...";
            this.buttonNewChat.UseVisualStyleBackColor = true;
            this.buttonNewChat.Click += new System.EventHandler(this.NewChat);
            // 
            // panelUserInfoAndMessageListAndMessageNew
            // 
            this.panelUserInfoAndMessageListAndMessageNew.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.panelUserInfoAndMessageListAndMessageNew.ColumnCount = 1;
            this.panelUserInfoAndMessageListAndMessageNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelUserInfoAndMessageListAndMessageNew.Controls.Add(this.panelUserInfo, 0, 0);
            this.panelUserInfoAndMessageListAndMessageNew.Controls.Add(this.panelMessageList, 0, 1);
            this.panelUserInfoAndMessageListAndMessageNew.Controls.Add(this.panelMessageNew, 0, 2);
            this.panelUserInfoAndMessageListAndMessageNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserInfoAndMessageListAndMessageNew.Location = new System.Drawing.Point(0, 0);
            this.panelUserInfoAndMessageListAndMessageNew.Name = "panelUserInfoAndMessageListAndMessageNew";
            this.panelUserInfoAndMessageListAndMessageNew.RowCount = 3;
            this.panelUserInfoAndMessageListAndMessageNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelUserInfoAndMessageListAndMessageNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelUserInfoAndMessageListAndMessageNew.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelUserInfoAndMessageListAndMessageNew.Size = new System.Drawing.Size(488, 499);
            this.panelUserInfoAndMessageListAndMessageNew.TabIndex = 0;
            this.panelUserInfoAndMessageListAndMessageNew.Visible = false;
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.ColumnCount = 2;
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelUserInfo.Controls.Add(this.labelUserName, 1, 0);
            this.panelUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUserInfo.Location = new System.Drawing.Point(6, 6);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.RowCount = 1;
            this.panelUserInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelUserInfo.Size = new System.Drawing.Size(476, 24);
            this.panelUserInfo.TabIndex = 4;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserName.Location = new System.Drawing.Point(28, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(445, 24);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMessageList
            // 
            this.panelMessageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageList.Location = new System.Drawing.Point(6, 39);
            this.panelMessageList.Name = "panelMessageList";
            this.panelMessageList.Size = new System.Drawing.Size(476, 405);
            this.panelMessageList.TabIndex = 3;
            // 
            // panelMessageNew
            // 
            this.panelMessageNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMessageNew.ColumnCount = 2;
            this.panelMessageNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelMessageNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelMessageNew.Controls.Add(this.buttonMessageSend, 1, 0);
            this.panelMessageNew.Controls.Add(this.textboxMessageNew, 0, 0);
            this.panelMessageNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageNew.Location = new System.Drawing.Point(6, 453);
            this.panelMessageNew.MinimumSize = new System.Drawing.Size(0, 36);
            this.panelMessageNew.Name = "panelMessageNew";
            this.panelMessageNew.RowCount = 1;
            this.panelMessageNew.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelMessageNew.Size = new System.Drawing.Size(476, 40);
            this.panelMessageNew.TabIndex = 2;
            // 
            // buttonMessageSend
            // 
            this.buttonMessageSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMessageSend.Location = new System.Drawing.Point(407, 5);
            this.buttonMessageSend.Name = "buttonMessageSend";
            this.buttonMessageSend.Size = new System.Drawing.Size(66, 29);
            this.buttonMessageSend.TabIndex = 0;
            this.buttonMessageSend.Text = "Enviar";
            this.buttonMessageSend.UseVisualStyleBackColor = true;
            this.buttonMessageSend.Click += new System.EventHandler(this.buttonMessageSend_Click);
            // 
            // textboxMessageNew
            // 
            this.textboxMessageNew.AcceptsReturn = true;
            this.textboxMessageNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxMessageNew.Location = new System.Drawing.Point(3, 3);
            this.textboxMessageNew.Multiline = true;
            this.textboxMessageNew.Name = "textboxMessageNew";
            this.textboxMessageNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxMessageNew.Size = new System.Drawing.Size(398, 34);
            this.textboxMessageNew.TabIndex = 1;
            this.textboxMessageNew.TextChanged += new System.EventHandler(this.textboxMessageNew_TextChanged);
            this.textboxMessageNew.Enter += new System.EventHandler(this.textboxMessageNew_GotFocus);
            this.textboxMessageNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxMessageNew_KeyPress);
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.TimerTick);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 499);
            this.Controls.Add(this.splitcontainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Title";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMain_FormClosed);
            this.splitcontainerMain.Panel1.ResumeLayout(false);
            this.splitcontainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerMain)).EndInit();
            this.splitcontainerMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelUserInfoAndMessageListAndMessageNew.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.panelMessageNew.ResumeLayout(false);
            this.panelMessageNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitcontainerMain;
        private System.Windows.Forms.TableLayoutPanel panelUserInfoAndMessageListAndMessageNew;
        private System.Windows.Forms.Panel panelMessageList;
        private System.Windows.Forms.TableLayoutPanel panelMessageNew;
        private System.Windows.Forms.Button buttonMessageSend;
        private System.Windows.Forms.TextBox textboxMessageNew;
        private System.Windows.Forms.TableLayoutPanel panelUserInfo;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listviewUsers;
        private System.Windows.Forms.Button buttonNewChat;
        private System.Windows.Forms.Timer timerMain;
    }
}

