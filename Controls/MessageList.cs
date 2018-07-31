using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class MessageList : UserControl
    {
        public byte CompanyID { get; set; }
        public short UserID { get; set; }
        public DateTime LastUpdate { get; set; }

        public MessageList(byte newCompanyID, short newUserID)
        {
            CompanyID = newCompanyID;
            UserID = newUserID;

            InitializeComponent();
        }
    }
}
