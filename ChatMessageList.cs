using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    class ChatMessageList
    {
        // Internal variables
        private CSMessengerContext mdbContext;
        private User mUser;

        public ChatMessageList(byte companyID, short userID)
        {
            try
            {
                mdbContext = new CSMessengerContext();

                mUser = mdbContext.User.Find(companyID, userID);
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error al inicializar las funciones de Mensajes.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool LoadMessagesForUser(Controls.MessageList messageListControl)
        {
            byte destinationCompanyID = messageListControl.CompanyID;
            short destinationUserID = messageListControl.UserID;

            try

            {
                List<Message> listMessages = (from msgs in mdbContext.Message
                                              where ((msgs.SourceCompanyID == mUser.CompanyID && msgs.SourceUserID == mUser.UserID && msgs.DestinationCompanyID == destinationCompanyID && msgs.DestinationUserID == destinationUserID) || (msgs.SourceCompanyID == destinationCompanyID && msgs.SourceUserID == destinationUserID && msgs.DestinationCompanyID == mUser.CompanyID && msgs.DestinationUserID == mUser.UserID)) && msgs.ReadedDateTime == null
                                              orderby msgs.SentDateTime, msgs.MessageID
                                              select msgs).ToList();

                messageListControl.panelMessages.SuspendLayout();

                messageListControl.panelMessages.Controls.Clear();

                foreach (Message messageCurrent in listMessages)
                {
                    if ((messageCurrent.SourceCompanyID == mUser.CompanyID) && (messageCurrent.SourceUserID == mUser.UserID))
                    {
                        MessageListControlFunctions.AppendSentMessage(ref messageListControl, messageCurrent);
                    }
                    else
                    {
                        MessageListControlFunctions.AppendReceivedMessage(ref messageListControl, messageCurrent);
                    }
                }

                messageListControl.panelMessages.ResumeLayout();

                messageListControl.LastUpdate = DateTime.Now;

                return true;
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error al leer los Mensajes.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
