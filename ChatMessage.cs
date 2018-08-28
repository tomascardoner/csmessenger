using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    public class ChatMessage
    {
        // Internal variables
        private CSMessengerContext mdbContext;
        private User mUser;

        public ChatMessage(byte companyID, short userID)
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

        public bool SendMessage(Controls.MessageList messageListControl, string text)
        {
            try
            {
                // Add the message to the database, update the destination user semaphore and gets the new message ID (all in the stored procedure)
                ObjectParameter outputMessageID = new System.Data.Entity.Core.Objects.ObjectParameter("MessageID", typeof(Int32));
                mdbContext.usp_Message_Send(mUser.CompanyID, mUser.UserID, messageListControl.CompanyID, messageListControl.UserID, text, outputMessageID);
                int messageID = Convert.ToInt32(outputMessageID.Value);

                // Load current message from database
                // TODO: Use the message from memory
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

    }
}
