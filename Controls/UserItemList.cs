using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class UserItemList : UserControl
    {
        private Controls.UserItem mSelectedItem = null;

        public event EventHandler SelectedItemChanged;

        public Controls.UserItem SelectedItem
        {
            get
            {
                return mSelectedItem;
            }
            set
            {
                // Unselect the previous item
                if (mSelectedItem != null)
                {
                    mSelectedItem.Selected = false;
                }

                mSelectedItem = value;
                OnSelectedItemChanged(EventArgs.Empty);
            }
        }

        public UserItemList()
        {
            InitializeComponent();

            panelMain.BackColor = My.Settings.UserList_BackColor;
        }

        public ControlCollection Items => panelMain.Controls;

        public void Add(byte companyID, short userID, string userName, bool newMessages)
        {
            UserItem NewUserItem = new Controls.UserItem(companyID, userID, userName, newMessages);

            NewUserItem.Name = "userItem_" + (panelMain.Controls.Count + 1);
            NewUserItem.Margin = new Padding(0);

            panelMain.Controls.Add(NewUserItem);
            SetupAnchors();
        }

        protected virtual void OnSelectedItemChanged(EventArgs e)
        {
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(this, e);
            }
        }

        private void SetupAnchors()
        {
            if (panelMain.Controls.Count > 0)
            {
                for (int i = 0; i <= panelMain.Controls.Count - 1; i++)
                {
                    UserItem ContactItemCurrent = (UserItem)panelMain.Controls[i];

                    if (i == 0)
                    {
                        // Its the first control, all subsequent controls follow
                        // the anchor behavior of this control.
                        if (panelMain.VerticalScroll.Visible == true)
                        {
                            ContactItemCurrent.Width = panelMain.Width - SystemInformation.VerticalScrollBarWidth;
                        }
                        else
                        {
                            ContactItemCurrent.Width = panelMain.Width;
                        }
                        ContactItemCurrent.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
                    }
                    else
                    {
                        // It is not the first control. Set its anchor to
                        // copy the width of the first control in the list.
                        ContactItemCurrent.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                    }
                }
            }
        }
    }
}
