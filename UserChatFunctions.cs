using System;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserChatFunctions
    {
        static public void ChatWithUser(TableLayoutPanel panelUserInfoAndMessageListAndMessageNew, ref Controls.MessageList messageListControlCurrent, Label labelUserName, Panel panelMessageList, byte companyID, short userID, string userName, ChatMessageList chatMessageListCurrent)
        {
            if (panelUserInfoAndMessageListAndMessageNew.Visible == false)
            {
                panelUserInfoAndMessageListAndMessageNew.Visible = true;
            }

            if (messageListControlCurrent != null)
            {
                messageListControlCurrent.Visible = false;
            }

            labelUserName.Text = userName;

            messageListControlCurrent = MessageListControlFunctions.GetMessageListControl(ref panelMessageList, companyID, userID);
            messageListControlCurrent.Visible = true;

            if (chatMessageListCurrent.LoadMessagesForUser(messageListControlCurrent))
            {
            }
        }


    }
}
