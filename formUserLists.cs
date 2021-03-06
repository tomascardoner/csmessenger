﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    public partial class formUserLists : Form
    {
        private byte mCompanyID;
        private byte mCompanyCount;
        private short mUserID;
        private ListView mlistviewFavorites;
        private CSMessengerContext mdbContext = new CSMessengerContext();

        public formUserLists(byte companyID, short userID)
        {
            mCompanyID = companyID;
            mUserID = userID;

            InitializeComponent();

            SetAppearance();

            // Add the user image to list
            imagelistMain.Images.Add(CSMessenger.Properties.Resources.IMAGE_USER_CHAT_32);

            // Create Companies Controls
            UserListFunctions ListsOfUsers = new UserListFunctions();
            mlistviewFavorites = ListsOfUsers.AddControlsToTabPage("listviewFavorites", ref tabpageFavorites, ref contextmenuFavorites, UserListDoubleClick);
            ListsOfUsers.CreateCompanyControlsAndLoadUsers(mdbContext, mCompanyID, mUserID, ref tabUsers, ref contextmenuMain, UserListDoubleClick);
            ListsOfUsers = null;
            mCompanyCount = Convert.ToByte(tabUsers.TabPages.Count - 1);

            // Load Favorites Users
            mlistviewFavorites.Sorting = System.Windows.Forms.SortOrder.Ascending;
            //if (UserFavorite.LoadFavoritesToList(ref mlistviewFavorites, mCompanyID, mUserID, mCompanyCount) == false)
            //{
            //    System.Environment.Exit(1);
            //}

        }

        private void SetAppearance()
        {
            Form theForm = this;
            CS_Form.FitHeightToScreen(ref theForm);
            CS_Form.SetOnRightSideOfScreen(ref theForm);
            theForm = null;
        }

        private void UserListDoubleClick(object sender, EventArgs e)
        {
            ListView listViewSource = sender as ListView;

            this.Tag = listViewSource.SelectedItems[0].Name;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AddUserToFavoritesMenuClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            if (GetUserInfoFromContextMenuClick(sender, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                UserFavoriteFunctions.FavoriteAdd(mCompanyID, mUserID, itemCompanyID, itemUserID, mCompanyCount);

                // Add item to Favorites List control for not to need to reload the entire list
                //TODO: UserFavoriteFunctions.FavoriteAddListItem(ref listviewFavorites, favoriteCompanyID, companyAbbreviation, favoriteUserID, userName, companyCount);

                Cursor.Current = Cursors.Default;
            }
        }

        private void RemoveUserFromFavoritesClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            if (GetUserInfoFromContextMenuClick(sender, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                UserFavoriteFunctions.FavoriteRemove(mCompanyID, mUserID, itemCompanyID, itemUserID);

                // Remove item from Favorites List control for not to need to reload the entire list
                //listiviewFavorites.Items[CS_Constants.KeyStringer + favoriteCompanyID + CS_Constants.KeyDelimiter + favoriteUserID].Remove();

                Cursor.Current = Cursors.Default;
            }
        }

        private void ChatWithUserMenuClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            if (GetUserInfoFromContextMenuClick(sender, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                //UserChatFunctions.ChatWithUser(ref panelUserInfoAndMessageListAndMessageNew, ref mMessageListControlCurrent, itemCompanyID, itemUserID, itemUserName, mMessageFunctions);

                Cursor.Current = Cursors.Default;
            }
        }

        #region Extra stuff

        private bool GetUserInfoFromContextMenuClick(object sender, out byte companyID, out short userID, out string userName)
        {
            // Gets the source ListView of the ContextMenu
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    ListView listViewSource = owner.SourceControl as ListView;

                    if (UserListFunctions.GetUserInfoFromListViewItem(ref listViewSource, out companyID, out userID, out userName))
                    {
                        return true;
                    }
                }
            }
            companyID = 0;
            userID = 0;
            userName = "";
            return false;
        }

        #endregion
    }
}
