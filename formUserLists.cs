using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSMessenger
{
    public partial class formUserLists : Form
    {
        private byte mCompanyID;
        private byte mCompanyCount;
        private short mUserID;
        private ListView mlistviewFavorites;

        public formUserLists()
        {
            InitializeComponent();

            // Add the user image to list
            imagelistMain.Images.Add(CSMessenger.Properties.Resources.IMAGE_USER_CHAT_32);
        }

        private void AddUserToFavoritesMenuClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            if (GetUserInfoFromContextMenuClick(sender, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                UserFavoriteFunctions.FavoriteAdd(ref mlistviewFavorites, mCompanyID, mUserID, itemCompanyID, itemUserID, mCompanyCount);

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

                UserFavoriteFunctions.FavoriteRemove(ref mlistviewFavorites, mCompanyID, mUserID, itemCompanyID, itemUserID);

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
