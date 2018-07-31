using System;
using System.Windows.Forms;

namespace CSMessenger.Controls
{
    public partial class ContactItemList : UserControl
    {
        public ContactItemList()
        {
            InitializeComponent();
        }

        public void Add(string name, bool unread)
        {
            ContactItem NewContactItem = new ContactItem();

            NewContactItem.Name = "item" + (flowlayoutpanelMain.Controls.Count + 1);
            NewContactItem.Margin = new Padding(0);

            flowlayoutpanelMain.Controls.Add(NewContactItem);
            SetupAnchors();
        }

        private void SetupAnchors()
        {
            if (flowlayoutpanelMain.Controls.Count > 0)
                {
                    for (int i = 0; i <= flowlayoutpanelMain.Controls.Count; i++)
                    {
                        ContactItem ContactItemCurrent = (ContactItem)flowlayoutpanelMain.Controls[i];

                        if (i == 0)
                        {
                            // Its the first control, all subsequent controls follow
                            // the anchor behavior of this control.
                            ContactItemCurrent.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
                            ContactItemCurrent.Width = flowlayoutpanelMain.Width - SystemInformation.VerticalScrollBarWidth;
                        }
                        else
                        {
                            // It is not the first control. Set its anchor to
                            // copy the width of the first control in the list.
                            ContactItemCurrent.Anchor = (AnchorStyles.Left | AnchorStyles.Right);
                        }
                    }
                }

        }

    }
}
