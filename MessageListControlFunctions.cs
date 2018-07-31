using System;
using System.Windows.Forms;
using System.Linq;

namespace CSMessenger
{
    class MessageListControlFunctions
    {

        static public Controls.MessageList GetMessageListControl(ref Panel panelMessageList, byte companyID, short userID)
        {
            Controls.MessageList MessageListLastUpdated = null;

            // Find if there is a Control created for this User
            foreach (Controls.MessageList MessageListCurrent in panelMessageList.Controls)
            {
                // Save the Last Updated control
                if (MessageListLastUpdated == null)
                {
                    MessageListLastUpdated = MessageListCurrent;
                }
                else if (MessageListCurrent.LastUpdate.CompareTo(MessageListLastUpdated.LastUpdate) > 0)
                {
                    MessageListLastUpdated = MessageListCurrent;
                }

                if ((MessageListCurrent.CompanyID == companyID) && (MessageListCurrent.UserID == userID))
                {
                    // Control exist
                    return MessageListCurrent;
                }
            }

            // There is not Control created for this User
            if (panelMessageList.Controls.Count < My.Settings.MessageList_OnMemoryMaxCount)
            {
                // Create a new Control to hold the messages for this User
                return CreateMessageListControl(ref panelMessageList, companyID, userID);
            }
            else
            { 
                // Reuse one of the created Controls
                if (panelMessageList.Controls.Count > 0)
                {
                    MessageListLastUpdated.CompanyID = companyID;
                    MessageListLastUpdated.UserID = userID;
                    MessageListLastUpdated.panelMessages.Controls.Clear();
                    return MessageListLastUpdated;
                }
                else
                {
                    // The "MessageList_OnMemoryMaxCount" setting is apparently equal to 0
                    return null;
                }
            }
        }

        static Controls.MessageList CreateMessageListControl(ref Panel panelMessageList, byte companyID, short userID)
        {
            Controls.MessageList MessageListCurrent = new Controls.MessageList(companyID, userID);
            panelMessageList.Controls.Add(MessageListCurrent);

            // Set appearance
            MessageListCurrent.BackColor = My.Settings.MessageList_BackColor;
            MessageListCurrent.Dock = DockStyle.Fill;

            return MessageListCurrent;
        }

        static public void AppendSentMessage(ref Controls.MessageList messageListControl, Message messageSent)
        {
            Controls.MessageItemSent NewMessageItemSent = new Controls.MessageItemSent(messageSent);

            messageListControl.panelMessages.Controls.Add(NewMessageItemSent);
            NewMessageItemSent.Dock = DockStyle.Top;
        }

        static public void AppendReceivedMessage(ref Controls.MessageList messageListControl, Message messageReceived)
        {
            Controls.MessageItemReceived NewMessageItemReceived = new Controls.MessageItemReceived(messageReceived);

            messageListControl.panelMessages.Controls.Add(NewMessageItemReceived);
            NewMessageItemReceived.Dock = DockStyle.Top;
        }
    }
}
