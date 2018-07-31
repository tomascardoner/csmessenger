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
            this.contextmenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemMainChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemMainAddFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.splitcontainerMain = new System.Windows.Forms.SplitContainer();
            this.tabUsers = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabpageRecents = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabpageFavorites = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.imagelistMain = new System.Windows.Forms.ImageList(this.components);
            this.panelUserInfoAndMessageListAndMessageNew = new System.Windows.Forms.TableLayoutPanel();
            this.panelUserInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.datetimeDate = new System.Windows.Forms.DateTimePicker();
            this.panelMessageList = new System.Windows.Forms.Panel();
            this.panelMessageNew = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMessageSend = new System.Windows.Forms.Button();
            this.textboxMessageNew = new System.Windows.Forms.TextBox();
            this.contextmenuFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemFavoritesChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemFavoritesRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextmenuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerMain)).BeginInit();
            this.splitcontainerMain.Panel1.SuspendLayout();
            this.splitcontainerMain.Panel2.SuspendLayout();
            this.splitcontainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabUsers)).BeginInit();
            this.tabUsers.SuspendLayout();
            this.panelUserInfoAndMessageListAndMessageNew.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.panelMessageNew.SuspendLayout();
            this.contextmenuFavorites.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextmenuMain
            // 
            this.contextmenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemMainChat,
            this.menuitemMainAddFavorite});
            this.contextmenuMain.Name = "contextmenustripMain";
            this.contextmenuMain.Size = new System.Drawing.Size(177, 48);
            // 
            // menuitemMainChat
            // 
            this.menuitemMainChat.Image = global::CSMessenger.Properties.Resources.IMAGE_USER_CHAT_32;
            this.menuitemMainChat.Name = "menuitemMainChat";
            this.menuitemMainChat.Size = new System.Drawing.Size(176, 22);
            this.menuitemMainChat.Text = "Conversar";
            this.menuitemMainChat.Click += new System.EventHandler(this.ChatWithUserMenuClick);
            // 
            // menuitemMainAddFavorite
            // 
            this.menuitemMainAddFavorite.Image = global::CSMessenger.Properties.Resources.IMAGE_FAVORITES_32;
            this.menuitemMainAddFavorite.Name = "menuitemMainAddFavorite";
            this.menuitemMainAddFavorite.Size = new System.Drawing.Size(176, 22);
            this.menuitemMainAddFavorite.Text = "Agregar a Favoritos";
            this.menuitemMainAddFavorite.Click += new System.EventHandler(this.AddUserToFavoritesMenuClick);
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
            this.splitcontainerMain.Panel1.Controls.Add(this.tabUsers);
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
            // tabUsers
            // 
            this.tabUsers.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabUsers.ActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabUsers.BeforeTouchSize = new System.Drawing.Size(233, 499);
            this.tabUsers.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabUsers.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabUsers.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Controls.Add(this.tabpageRecents);
            this.tabUsers.Controls.Add(this.tabpageFavorites);
            this.tabUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUsers.ImageList = this.imagelistMain;
            this.tabUsers.InActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Location = new System.Drawing.Point(0, 0);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.tabUsers.ShowSeparator = false;
            this.tabUsers.Size = new System.Drawing.Size(233, 499);
            this.tabUsers.TabGap = 10;
            this.tabUsers.TabIndex = 4;
            this.tabUsers.TabPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(216)))), ((int)(((byte)(237)))));
            this.tabUsers.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererOffice2007);
            // 
            // tabpageRecents
            // 
            this.tabpageRecents.Image = global::CSMessenger.Properties.Resources.IMAGE_RECENT_32;
            this.tabpageRecents.ImageSize = new System.Drawing.Size(32, 32);
            this.tabpageRecents.Location = new System.Drawing.Point(41, 1);
            this.tabpageRecents.Name = "tabpageRecents";
            this.tabpageRecents.ShowCloseButton = true;
            this.tabpageRecents.Size = new System.Drawing.Size(190, 496);
            this.tabpageRecents.TabIndex = 1;
            this.tabpageRecents.Text = "Recientes";
            this.tabpageRecents.ThemesEnabled = false;
            // 
            // tabpageFavorites
            // 
            this.tabpageFavorites.Image = global::CSMessenger.Properties.Resources.IMAGE_FAVORITES_32;
            this.tabpageFavorites.ImageSize = new System.Drawing.Size(32, 32);
            this.tabpageFavorites.Location = new System.Drawing.Point(41, 1);
            this.tabpageFavorites.Name = "tabpageFavorites";
            this.tabpageFavorites.ShowCloseButton = true;
            this.tabpageFavorites.Size = new System.Drawing.Size(190, 496);
            this.tabpageFavorites.TabIndex = 2;
            this.tabpageFavorites.Text = "Favoritos";
            this.tabpageFavorites.ThemesEnabled = false;
            // 
            // imagelistMain
            // 
            this.imagelistMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imagelistMain.ImageSize = new System.Drawing.Size(16, 16);
            this.imagelistMain.TransparentColor = System.Drawing.Color.Transparent;
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
            this.panelUserInfo.ColumnCount = 3;
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelUserInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelUserInfo.Controls.Add(this.labelUserName, 1, 0);
            this.panelUserInfo.Controls.Add(this.datetimeDate, 2, 0);
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
            this.labelUserName.Size = new System.Drawing.Size(348, 24);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datetimeDate
            // 
            this.datetimeDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.datetimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimeDate.Location = new System.Drawing.Point(382, 3);
            this.datetimeDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.datetimeDate.MinDate = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.datetimeDate.Name = "datetimeDate";
            this.datetimeDate.Size = new System.Drawing.Size(91, 20);
            this.datetimeDate.TabIndex = 1;
            this.datetimeDate.ValueChanged += new System.EventHandler(this.DateChanged);
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
            // contextmenuFavorites
            // 
            this.contextmenuFavorites.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemFavoritesChat,
            this.menuitemFavoritesRemove});
            this.contextmenuFavorites.Name = "contextmenuFavorites";
            this.contextmenuFavorites.Size = new System.Drawing.Size(175, 48);
            // 
            // menuitemFavoritesChat
            // 
            this.menuitemFavoritesChat.Image = global::CSMessenger.Properties.Resources.IMAGE_USER_CHAT_32;
            this.menuitemFavoritesChat.Name = "menuitemFavoritesChat";
            this.menuitemFavoritesChat.Size = new System.Drawing.Size(174, 22);
            this.menuitemFavoritesChat.Text = "Conversar";
            this.menuitemFavoritesChat.Click += new System.EventHandler(this.ChatWithUserMenuClick);
            // 
            // menuitemFavoritesRemove
            // 
            this.menuitemFavoritesRemove.Name = "menuitemFavoritesRemove";
            this.menuitemFavoritesRemove.Size = new System.Drawing.Size(174, 22);
            this.menuitemFavoritesRemove.Text = "Quitar de Favoritos";
            this.menuitemFavoritesRemove.Click += new System.EventHandler(this.RemoveUserFromFavoritesClick);
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
            this.contextmenuMain.ResumeLayout(false);
            this.splitcontainerMain.Panel1.ResumeLayout(false);
            this.splitcontainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitcontainerMain)).EndInit();
            this.splitcontainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabUsers)).EndInit();
            this.tabUsers.ResumeLayout(false);
            this.panelUserInfoAndMessageListAndMessageNew.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.panelMessageNew.ResumeLayout(false);
            this.panelMessageNew.PerformLayout();
            this.contextmenuFavorites.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextmenuMain;
        private System.Windows.Forms.ToolStripMenuItem menuitemMainChat;
        private System.Windows.Forms.ToolStripMenuItem menuitemMainAddFavorite;
        private System.Windows.Forms.SplitContainer splitcontainerMain;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabUsers;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabpageRecents;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabpageFavorites;
        private System.Windows.Forms.ImageList imagelistMain;
        private System.Windows.Forms.ContextMenuStrip contextmenuFavorites;
        private System.Windows.Forms.ToolStripMenuItem menuitemFavoritesChat;
        private System.Windows.Forms.ToolStripMenuItem menuitemFavoritesRemove;
        private System.Windows.Forms.TableLayoutPanel panelUserInfoAndMessageListAndMessageNew;
        private System.Windows.Forms.Panel panelMessageList;
        private System.Windows.Forms.TableLayoutPanel panelMessageNew;
        private System.Windows.Forms.Button buttonMessageSend;
        private System.Windows.Forms.TextBox textboxMessageNew;
        private System.Windows.Forms.TableLayoutPanel panelUserInfo;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.DateTimePicker datetimeDate;
    }
}

