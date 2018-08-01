using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    public class MessageFunctions
    {
        // Internal variables
        private CSMessengerContext mdbContext;
        private User mUser;

        public MessageFunctions(byte companyID, short userID)
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

        public bool SendMessage(ref Controls.MessageList messageListControl, string text)
        {
            try
            {
                // Add the message to the database, update the destination user semaphore and gets the new message ID (all in the stored procedure)
                System.Data.Entity.Core.Objects.ObjectParameter outputMessageID = new System.Data.Entity.Core.Objects.ObjectParameter("MessageID", typeof(Int32));
                mdbContext.usp_Message_Send(mUser.CompanyID, mUser.UserID, messageListControl.CompanyID, messageListControl.UserID, text, outputMessageID);
                int messageID = Convert.ToInt32(outputMessageID.Value);

                // Load current message from database
                Message messageSent = mdbContext.Message.Find(messageID);

                // Show the sent message in the MessageList control
                MessageListControlFunctions.AppendSentMessage(ref messageListControl, messageSent);

                return true;
            }
            catch (DbEntityValidationException e)
            {
                MessageBox.Show(string.Format("Error al enviar el Mensaje.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool LoadMessagesForUser(ref Controls.MessageList messageListControl)
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
