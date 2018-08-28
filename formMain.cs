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

        private bool mPerformingTasks = false;

        private Semaphores mSemaphores;
        private ChatUserList mChatUserList;

        private Controls.MessageList mMessageListControlCurrent;
        private ChatMessageList mChatMessageList;
        private ChatMessage mChatMessage;

        private formUserLists mformUserLists;

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

            mChatUserList = new ChatUserList();
            mChatMessageList = new ChatMessageList(mCompanyID, mUserID);
            mChatMessage = new ChatMessage(mCompanyID, mUserID);
            mSemaphores = new Semaphores(mCompanyID, mUserID);

            timerMain.Interval = My.Settings.RefreshTimer_IntervalInMilliseconds;
            timerMain.Enabled = true;
            TimerTick(timerMain, new EventArgs());

            Cursor.Current = Cursors.Default;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea salir de la aplicación?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Destroy objects
            if (mMessageListControlCurrent != null)
            {
                mMessageListControlCurrent.Dispose();
                mMessageListControlCurrent = null;
            }

            mSemaphores = null;
            mChatUserList = null;
            mChatMessageList = null;
            mChatMessage = null;

            if (mMessageListControlCurrent != null)
            {
                mformUserLists.Dispose();
                mformUserLists = null;
            }

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

        private void TimerTick(object sender, EventArgs e)
        {
            if (mPerformingTasks == false)
            {
                mPerformingTasks = true;

                // Check Company Sempahore for changes
                if (mSemaphores.IsCompanyChanged())
                {
                    // Refresh User List for Company
                }

                // Check User Semaphore for changes
                if (mSemaphores.IsUserChanged())
                {
                    // Refresh Users list after check UserNotification table
                    mChatUserList.RefreshListUsers(mCompanyID, mUserID, useritemlistMain);

                    // Refresh MessageList
                }

                mPerformingTasks = false;
            }
        }

        private void UserChatClick(object sender, EventArgs e)
        {
            if (useritemlistMain.SelectedItem != null)
            {
                Cursor.Current = Cursors.WaitCursor;

                UserChatFunctions.ChatWithUser(panelUserInfoAndMessageListAndMessageNew, ref mMessageListControlCurrent,labelUserName,panelMessageList, useritemlistMain.SelectedItem.CompanyID, useritemlistMain.SelectedItem.UserID, useritemlistMain.SelectedItem.UserName, mChatMessageList);

                Cursor.Current = Cursors.Default;
            }
        }


        private void TextboxMessageNew_GotFocus(object sender, EventArgs e)
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
                if (mChatMessage.SendMessage(mMessageListControlCurrent, textboxMessageNew.Text.Trim()) == true)
                {
                    // mChatUserList.SetUserOnTop(mMessageListControlCurrent.CompanyID, mMessageListControlCurrent.UserID);
                    textboxMessageNew.Text = "";
                }
            }
        }

        #endregion

        private void NewChat(object sender, EventArgs e)
        {
            if (mformUserLists == null)
            {
                mformUserLists = new formUserLists(mCompanyID, mUserID);
            }

            if (mformUserLists.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            { 

            }
        }

    }
}
