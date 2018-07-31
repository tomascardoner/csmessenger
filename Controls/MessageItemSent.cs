using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class MessageItemSent : UserControl
    {
        private Message mMessageSent;

        public MessageItemSent(Message messageSent)
        {
            mMessageSent = messageSent;

            InitializeComponent();

            SetAppearance();

            SetInfo();

            SetStatus();
        }

        private void SetAppearance()
        {
            labelSentTime.Font = My.Settings.MessageSent_Time_Font;
            labelSentTime.ForeColor = My.Settings.MessageSent_Time_ForeColor;

            labelText.Font = My.Settings.MessageSent_Text_Font;
            labelText.BackColor = My.Settings.MessageSent_Text_BackColor;
            labelText.ForeColor = My.Settings.MessageSent_Text_ForeColor;
        }

        private void SetInfo()
        {
            labelSentTime.Text = mMessageSent.SentDateTime.ToShortTimeString();
            labelText.Text = mMessageSent.Text;
        }

        private void SetStatus()
        {
            if (mMessageSent.ReadedDateTime.HasValue)
            { 
                // Readed
                labelStatus.Font = My.Settings.MessageSent_Status_Readed_Font;
                labelStatus.ForeColor = My.Settings.MessageSent_Status_Readed_ForeColor;
                labelStatus.Text = My.Settings.MessageSent_Status_Readed_Symbol;
            }
            else if (mMessageSent.ReceivedTime.HasValue)
            {
                // Received
                labelStatus.Font = My.Settings.MessageSent_Status_Received_Font;
                labelStatus.ForeColor = My.Settings.MessageSent_Status_Received_ForeColor;
                labelStatus.Text = My.Settings.MessageSent_Status_Received_Symbol;
            }
            else
            { 
                // Sent
                labelStatus.Font = My.Settings.MessageSent_Status_Sent_Font;
                labelStatus.ForeColor = My.Settings.MessageSent_Status_Sent_ForeColor;
                labelStatus.Text = My.Settings.MessageSent_Status_Sent_Symbol;
            }
        }
    }
}
