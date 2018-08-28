using System;
using System.Data.Entity.Core.Objects;
using System.Windows.Forms;

namespace CSMessenger
{
    class ChatUserList
    {
        // Internal variables
        private CSMessengerContext mdbContext = new CSMessengerContext();
        private DateTime mPreviousRead = new DateTime(2018, 1, 1);

        public void RefreshListUsers(byte companyID, short userID, Controls.UserItemList userItemListCurrent)
        {
            Cursor.Current = Cursors.WaitCursor;

            userItemListCurrent.SuspendLayout();

            ObjectParameter currentReadDateTime = new System.Data.Entity.Core.Objects.ObjectParameter("CurrentReadDateTime", typeof(DateTime));
            ObjectResult<CSMessenger.usp_User_ListByLastMessage_Result> result = mdbContext.usp_User_ListByLastMessage(companyID, userID, mPreviousRead, currentReadDateTime);

            if (userItemListCurrent.Items.Count == 0)
            {
                // Load Users for the first time
                foreach (CSMessenger.usp_User_ListByLastMessage_Result userCurrent in result)
                {
                    if (userCurrent.LastMessageReceivedOn <= mPreviousRead)
                    {
                        // Old messages
                        userItemListCurrent.Add(userCurrent.CompanyID, userCurrent.UserID, userCurrent.UserName, false);
                    }
                    else
                    {
                        // New messages
                        userItemListCurrent.Add(userCurrent.CompanyID, userCurrent.UserID, userCurrent.UserName, true);
                    }
                }
            }
            else
            {
                foreach (CSMessenger.usp_User_ListByLastMessage_Result userCurrent in result)
                {
                    // TODO: Reorder user items

                    // Check if the User already exists in the List
                    if (userItemListCurrent.Items.ContainsKey(GetUserKey(companyID, userID)))
                    {
                        // Already exists, so reorder
                    }
                    else
                    {
                        // Doesn't exists, so add it
                        if (userCurrent.LastMessageReceivedOn <= mPreviousRead)
                        {
                            // Old messages
                            AddUserItemToList(userItemListCurrent, userCurrent.CompanyID, userCurrent.UserID, userCurrent.UserName, false);
                        }
                        else
                        {
                            // New messages
                            AddUserItemToList(userItemListCurrent, userCurrent.CompanyID, userCurrent.UserID, userCurrent.UserName, true);
                        }
                    }
                }
            }

            userItemListCurrent.ResumeLayout();

            mPreviousRead = Convert.ToDateTime(currentReadDateTime.Value);

            Cursor.Current = Cursors.Default;
        }

        private void AddUserItemToList(Controls.UserItemList userItemListCurrent, byte companyID, short userID, string userName, bool newMessages)
        {
            userItemListCurrent.Add(companyID, userID, userName, newMessages);
        }

        private string GetUserKey(byte companyID, short userID)
        {
            return CS_Constants.KeyStringer + companyID + CS_Constants.KeyDelimiter + userID;
        }
    }
}
