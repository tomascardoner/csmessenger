﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    public partial class formMain : Form
    {
        #region Declarations

        private byte mCompanyID;
        private byte mCompanyCount;
        private short mUserID;
        private string mUserName;
        private ListView mlistviewFavorites;
        private Controls.MessageList mMessageListControlCurrent;
        private MessageFunctions mMessageFunctions;

        #endregion

        #region Form routines

        public formMain(string[] args)
        {
            InitializeComponent();

            // Resize and locate the window
            Form theForm = this;
            CS_Form.FitHeightToScreen(ref theForm);
            CS_Form.SetOnRightSideOfScreen(ref theForm);
            theForm = null;

            Cursor.Current = Cursors.WaitCursor;

            // Check if CompanyID and UserID are specified in command-line arguments
            if (args.Length == 2)
            {
                // Check if first command-line argument is a byte number
                if (!byte.TryParse(args[0], out mCompanyID))
                {
                    MessageBox.Show("El primer parámetro especificado en la línea de comandos, no es un número de tipo byte (CompanyID).", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                }

                // Check if second command-line argument is a short number
                if (!short.TryParse(args[1], out mUserID))
                {
                    MessageBox.Show("El segundo parámetro especificado en la línea de comandos, no es un número de tipo short (UserID).", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                }
            }
            else
            {
                MessageBox.Show("No se han especificado los parámetros (CompanyID y UserID) en la línea de comandos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            // Check Company and User in Databases
            UserFunctions UserForCheck = new UserFunctions();
            if (UserForCheck.CheckCompany(mCompanyID) == false)
            {
                System.Environment.Exit(1);
            }
            if (UserForCheck.CheckUser(mUserID, out mUserName) == false)
            {
                System.Environment.Exit(1);
            }
            UserForCheck = null;

            SetAppearance();

            // Create Companies Controls
            UserListFunctions ListsOfUsers = new UserListFunctions();
            ListsOfUsers.AddControlsToTabPage("listviewRecents", ref tabpageRecents, ref contextmenuMain, UserListDoubleClick);
            mlistviewFavorites = ListsOfUsers.AddControlsToTabPage("listviewFavorites", ref tabpageFavorites, ref contextmenuFavorites, UserListDoubleClick);
            ListsOfUsers.CreateCompanyControlsAndLoadUsers(mCompanyID, mUserID, ref tabUsers, ref contextmenuMain, UserListDoubleClick);
            ListsOfUsers = null;
            mCompanyCount = Convert.ToByte(tabUsers.TabPages.Count - 2);

            // Load Favorites Users
            mlistviewFavorites.Sorting = System.Windows.Forms.SortOrder.Ascending;
            if (UserFavoriteFunctions.LoadFavoritesToList(ref mlistviewFavorites, mCompanyID, mUserID, mCompanyCount) == false)
            {
                System.Environment.Exit(1);
            }

            mMessageFunctions = new MessageFunctions(mCompanyID, mUserID);

            Cursor.Current = Cursors.Default;
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea salir de la aplicación?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Destroy objects
            if (mlistviewFavorites != null)
            {
                mlistviewFavorites.Dispose();
                mlistviewFavorites = null;
            }

            if (mMessageListControlCurrent != null)
            {
                mMessageListControlCurrent.Dispose();
                mMessageListControlCurrent = null;
            }

            mMessageFunctions = null;

            foreach (Controls.MessageList messageListCurrent in panelMessageList.Controls)
            {
                panelMessageList.Controls.Remove(messageListCurrent);
                messageListCurrent.Dispose();
            }
        }

        private void SetAppearance()
        {
            this.Text = My.Application.Info.Title + " - " + mUserName;

            // Add the user image to list
            imagelistMain.Images.Add(CSMessenger.Properties.Resources.IMAGE_USER_CHAT_32);

            labelUserName.Font = My.Settings.UserInfo_Font;
            textboxMessageNew.Font = My.Settings.MessageNew_Font;
        }

        #endregion

        #region EventHandlers
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

                UserChatFunctions.ChatWithUser(ref panelUserInfoAndMessageListAndMessageNew, ref mMessageListControlCurrent, itemCompanyID, itemUserID, itemUserName, mMessageFunctions, datetimeDate.Value.Date);

                Cursor.Current = Cursors.Default;
            }
        }

        private void UserListDoubleClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            ListView listViewSource = sender as ListView;
            if (GetUserInfoFromListViewItem(ref listViewSource, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                UserChatFunctions.ChatWithUser(ref panelUserInfoAndMessageListAndMessageNew, ref mMessageListControlCurrent, itemCompanyID, itemUserID, itemUserName, mMessageFunctions, datetimeDate.Value.Date);

                Cursor.Current = Cursors.Default;
            }

        }


        private void DateChanged(object sender, EventArgs e)
        {
            if (mMessageFunctions.LoadMessagesForUser(ref mMessageListControlCurrent, datetimeDate.Value.Date))
            {
            }
        }

        private void textboxMessageNew_GotFocus(object sender, EventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void textboxMessageNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonMessageSend.Enabled = (textboxMessageNew.Text.Trim().Length > 0);
        }

        private void textboxMessageNew_TextChanged(object sender, EventArgs e)
        {
            //Size newSize = TextRenderer.MeasureText(textboxMessageNew.Text, textboxMessageNew.Font);
            //panelMessageNew.Height = newSize.Height + panelMessageNew.Margin.Top + panelMessageNew.Margin.Bottom;
        }

        private void buttonMessageSend_Click(object sender, EventArgs e)
        {
            if (textboxMessageNew.Text.Trim().Length > 0)
            {
                if (datetimeDate.Value.CompareTo(DateTime.Now.Date) != 0)
                {
                    datetimeDate.Value = DateTime.Now.Date;
                }
                if (mMessageFunctions.SendMessage(ref mMessageListControlCurrent, textboxMessageNew.Text.Trim()) == true)
                {
                    textboxMessageNew.Text = "";
                }
            }
        }

        #endregion

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

                    if (GetUserInfoFromListViewItem(ref listViewSource, out companyID, out userID, out userName))
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

        private bool GetUserInfoFromListViewItem(ref ListView ListViewSource, out byte companyID, out short userID, out string userName)
        {
            if (ListViewSource.SelectedItems.Count > 0)
            {
                string[] Keys = ListViewSource.SelectedItems[0].Name.Substring(CS_Constants.KeyStringer.Length).Split(Convert.ToChar(CS_Constants.KeyDelimiter));
                companyID = Convert.ToByte(Keys[0]);
                userID = Convert.ToInt16(Keys[1]);
                userName = ListViewSource.SelectedItems[0].Text;
                return true;
            }
            companyID = 0;
            userID = 0;
            userName = "";
            return false;
        }

        #endregion
    }
}
