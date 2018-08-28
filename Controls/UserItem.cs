using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class UserItem : UserControl
    {
        private byte mCompanyID;
        private short mUserID;
        private string mUserName;
        private bool mNewMessages;
        private bool mSelected = false;

        public byte CompanyID { get => mCompanyID; set => mCompanyID = value; }
        public short UserID { get => mUserID; set => mUserID = value; }
        public string UserName { get => mUserName; set => mUserName = value; }
        public bool NewMessages { get => mNewMessages; set => mNewMessages = value; }

        public bool Selected
        {
            get { return mSelected; }
            set
            {
                mSelected = value;

                SetSelectedAppearance();

                if (mSelected == true)
                {
                    Controls.UserItemList userItemListControl = this.Parent.Parent as Controls.UserItemList;
                    userItemListControl.SelectedItem = this;
                }
            }
        }

        public UserItem(byte companyID, short userID, string userName, bool newMessages)
        {
            CompanyID = companyID;
            UserID = userID;
            UserName = userName;
            NewMessages = newMessages;

            InitializeComponent();

            SetAppearance();

            SetInfo();

            SetStatus();
        }

        private void SetAppearance()
        {
            if (mNewMessages == true)
            {
                labelName.Font = My.Settings.UserList_UserWithNewMessages_Font;
                labelName.ForeColor = My.Settings.UserList_UserWithNewMessages_ForeColor;
            }
            else
            {
                labelName.Font = My.Settings.UserList_UserWithOldMessages_Font;
                labelName.ForeColor = My.Settings.UserList_UserWithOldMessages_ForeColor;
            }
        }

        private void SetInfo()
        {
            labelName.Text = UserName;
        }

        private void SetStatus()
        {
            if (NewMessages == true)
            {
                labelStatus.BackColor = My.Settings.UserList_UserWithNewMessages_Status_BackColor;
            }
            else
            {
                labelStatus.BackColor = My.Settings.UserList_UserWithOldMessages_Status_BackColor;
            }
        }

        private void SetSelectedAppearance()
        {
            if (mSelected == true)
            {
                this.BackColor = My.Settings.UserList_ItemSelected_BackColor;
            }
            else
            {
                this.BackColor = My.Settings.UserList_ItemUnselected_BackColor;
            }
        }

        private void UserItemClick(object sender, EventArgs e)
        {
            this.Selected = true;
        }
    }
}
