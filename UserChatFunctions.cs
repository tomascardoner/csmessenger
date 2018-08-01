using System;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserChatFunctions
    {
        static public void ChatWithUser(ref TableLayoutPanel panelUserInfoAndMessageListAndMessageNew, ref Controls.MessageList messageListControlCurrent, byte companyID, short userID, string userName, MessageFunctions messageFunctionsCurrent)
        {
            if (panelUserInfoAndMessageListAndMessageNew.Visible == false)
            {
                panelUserInfoAndMessageListAndMessageNew.Visible = true;
            }

            if (messageListControlCurrent != null)
            {
                messageListControlCurrent.Visible = false;
            }

            panelUserInfoAndMessageListAndMessageNew.Controls["panelUserInfo"].Controls["labelUserName"].Text = userName;
            Panel panelMessageList = panelUserInfoAndMessageListAndMessageNew.Controls["panelMessageList"] as Panel;

            messageListControlCurrent = MessageListControlFunctions.GetMessageListControl(ref panelMessageList, companyID, userID);
            messageListControlCurrent.Visible = true;

            if (messageFunctionsCurrent.LoadMessagesForUser(ref messageListControlCurrent))
            {
            }
        }


    }
}
