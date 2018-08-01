namespace CSMessenger
{
    partial class formUserLists
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
            this.tabUsers = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabpageRecents = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabpageFavorites = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.imagelistMain = new System.Windows.Forms.ImageList(this.components);
            this.contextmenuFavorites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemFavoritesChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemFavoritesRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextmenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuitemMainChat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemMainAddFavorite = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tabUsers)).BeginInit();
            this.tabUsers.SuspendLayout();
            this.contextmenuFavorites.SuspendLayout();
            this.contextmenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUsers
            // 
            this.tabUsers.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabUsers.ActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabUsers.BeforeTouchSize = new System.Drawing.Size(405, 527);
            this.tabUsers.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabUsers.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabUsers.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Controls.Add(this.tabpageRecents);
            this.tabUsers.Controls.Add(this.tabpageFavorites);
            this.tabUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUsers.InActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabUsers.Location = new System.Drawing.Point(0, 0);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.tabUsers.ShowSeparator = false;
            this.tabUsers.Size = new System.Drawing.Size(405, 527);
            this.tabUsers.TabGap = 10;
            this.tabUsers.TabIndex = 5;
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
            this.tabpageRecents.Size = new System.Drawing.Size(362, 524);
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
            this.tabpageFavorites.Size = new System.Drawing.Size(362, 524);
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
            // 
            // menuitemFavoritesRemove
            // 
            this.menuitemFavoritesRemove.Name = "menuitemFavoritesRemove";
            this.menuitemFavoritesRemove.Size = new System.Drawing.Size(174, 22);
            this.menuitemFavoritesRemove.Text = "Quitar de Favoritos";
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
            // 
            // menuitemMainAddFavorite
            // 
            this.menuitemMainAddFavorite.Image = global::CSMessenger.Properties.Resources.IMAGE_FAVORITES_32;
            this.menuitemMainAddFavorite.Name = "menuitemMainAddFavorite";
            this.menuitemMainAddFavorite.Size = new System.Drawing.Size(176, 22);
            this.menuitemMainAddFavorite.Text = "Agregar a Favoritos";
            // 
            // formUserLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 527);
            this.Controls.Add(this.tabUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formUserLists";
            this.Text = "Seleccione el Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.tabUsers)).EndInit();
            this.tabUsers.ResumeLayout(false);
            this.contextmenuFavorites.ResumeLayout(false);
            this.contextmenuMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabUsers;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabpageRecents;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabpageFavorites;
        private System.Windows.Forms.ImageList imagelistMain;
        private System.Windows.Forms.ContextMenuStrip contextmenuFavorites;
        private System.Windows.Forms.ToolStripMenuItem menuitemFavoritesChat;
        private System.Windows.Forms.ToolStripMenuItem menuitemFavoritesRemove;
        private System.Windows.Forms.ContextMenuStrip contextmenuMain;
        private System.Windows.Forms.ToolStripMenuItem menuitemMainChat;
        private System.Windows.Forms.ToolStripMenuItem menuitemMainAddFavorite;
    }
}