using System;
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
        private short mUserID;
        private string mUserName;

        private Controls.MessageList mMessageListControlCurrent;
        private UserListFunctions mUserListFunctions;
        private MessageFunctions mMessageFunctions;

        #endregion

        #region Form routines

        public formMain(string[] args)
        {
            InitializeComponent();

            SetAppearance();

            // Check if CompanyID and UserID are specified in command-line arguments
            if (CheckCommandLineArguments(args) == false)
            { 
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

            // Load List of Recent Users
            mUserListFunctions = new UserListFunctions();
            mUserListFunctions.LoadListOfRecentUsers(mCompanyID, mUserID, ref listviewUsers);

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
            this.Text = My.Application.Info.Title;

            Form theForm = this;
            CS_Form.FitHeightToScreen(ref theForm);
            CS_Form.SetOnRightSideOfScreen(ref theForm);
            theForm = null;

            labelUserName.Font = My.Settings.UserInfo_Font;
            textboxMessageNew.Font = My.Settings.MessageNew_Font;
        }

        private bool CheckCommandLineArguments(string[] args)
        {
            if (args.Length == 2)
            {
                // Check if first command-line argument is a byte number
                if (!byte.TryParse(args[0], out mCompanyID))
                {
                    MessageBox.Show("El primer parámetro especificado en la línea de comandos, no es un número de tipo byte (CompanyID).", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Check if second command-line argument is a short number
                if (!short.TryParse(args[1], out mUserID))
                {
                    MessageBox.Show("El segundo parámetro especificado en la línea de comandos, no es un número de tipo short (UserID).", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            else
            {
                MessageBox.Show("No se han especificado los parámetros (CompanyID y UserID) en la línea de comandos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region EventHandlers

        private void UserChatClick(object sender, EventArgs e)
        {
            byte itemCompanyID;
            short itemUserID;
            string itemUserName;
            ListView listViewSource = sender as ListView;
            if (UserListFunctions.GetUserInfoFromListViewItem(ref listViewSource, out itemCompanyID, out itemUserID, out itemUserName))
            {
                Cursor.Current = Cursors.WaitCursor;

                UserChatFunctions.ChatWithUser(ref panelUserInfoAndMessageListAndMessageNew, ref mMessageListControlCurrent, itemCompanyID, itemUserID, itemUserName, mMessageFunctions);

                Cursor.Current = Cursors.Default;
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
                if (mMessageFunctions.SendMessage(ref mMessageListControlCurrent, textboxMessageNew.Text.Trim()) == true)
                {
                    textboxMessageNew.Text = "";
                }
            }
        }

        #endregion

        private void NewChat(object sender, EventArgs e)
        {
            //// Create Companies Controls
            //UserListFunctions ListsOfUsers = new UserListFunctions();
            ////ListsOfUsers.AddControlsToTabPage("listviewRecents", ref tabpageRecents, ref contextmenuMain, UserListDoubleClick);
            ////mlistviewFavorites = ListsOfUsers.AddControlsToTabPage("listviewFavorites", ref tabpageFavorites, ref contextmenuFavorites, UserListDoubleClick);
            ////ListsOfUsers.CreateCompanyControlsAndLoadUsers(mCompanyID, mUserID, ref tabUsers, ref contextmenuMain, UserListDoubleClick);
            ////ListsOfUsers = null;
            ////mCompanyCount = Convert.ToByte(tabUsers.TabPages.Count - 2);

            //// Load Favorites Users
            //mlistviewFavorites.Sorting = System.Windows.Forms.SortOrder.Ascending;
            //if (UserFavoriteFunctions.LoadFavoritesToList(ref mlistviewFavorites, mCompanyID, mUserID, mCompanyCount) == false)
            //{
            //    System.Environment.Exit(1);
            //}
        }

    }
}
