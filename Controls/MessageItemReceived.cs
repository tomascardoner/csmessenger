using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class MessageItemReceived : UserControl
    {
        private Message mMessageReceived;

        public MessageItemReceived(Message messageReceived)
        {
            mMessageReceived = messageReceived;

            InitializeComponent();

            SetAppearance();

            SetInfo();

            SetStatus();
        }

        private void SetAppearance()
        {
            labelSentTime.Font = My.Settings.MessageReceived_Time_Font;
            labelSentTime.ForeColor = My.Settings.MessageReceived_Time_ForeColor;

            labelText.Font = My.Settings.MessageReceived_Text_Font;
            labelText.BackColor = My.Settings.MessageReceived_Text_BackColor;
            labelText.ForeColor = My.Settings.MessageReceived_Text_ForeColor;
        }

        private void SetInfo()
        {
            labelSentTime.Text = mMessageReceived.SentDateTime.ToShortTimeString();
            labelText.Text = mMessageReceived.Text;
        }

        private void SetStatus()
        {
            if (mMessageReceived.ReadedDateTime.HasValue)
            {
                // Readed
                labelStatus.Font = My.Settings.MessageReceived_Status_Readed_Font;
                labelStatus.ForeColor = My.Settings.MessageReceived_Status_Readed_ForeColor;
                labelStatus.Text = My.Settings.MessageReceived_Status_Readed_Symbol;
            }
            else
            {
                // Unreaded
                labelStatus.Font = My.Settings.MessageReceived_Status_Unreaded_Font;
                labelStatus.ForeColor = My.Settings.MessageReceived_Status_Unreaded_ForeColor;
                labelStatus.Text = My.Settings.MessageReceived_Status_Unreaded_Symbol;
            }
        }
    }
}
