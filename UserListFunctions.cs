using System;
using System.Linq;
using Syncfusion.Windows.Forms.Tools;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserListFunctions
    {
        // Internal variables
        private CSMessengerContext mdbContext = new CSMessengerContext();

        public void CreateCompanyControlsAndLoadUsers(byte companyID, short userID, ref TabControlAdv tabUsers, ref ContextMenuStrip contextmenuControl, EventHandler DoubleClickEventHandler)
        {
            foreach (UserCompany UserCompanyCurrent in mdbContext.UserCompany.Where(uc => uc.CompanyID == companyID && uc.UserID == userID).OrderBy(uc => uc.CompanyGranted.Name))
            {
                // Add a new Tab Page to the Tab control
                TabPageAdv tabpageNew = new TabPageAdv(UserCompanyCurrent.CompanyGranted.Name);
                tabUsers.TabPages.Add(tabpageNew);

                // Add a ListView to the TabPage
                ListView ListViewNew = AddControlsToTabPage(Constants.ListView_Company_Prefix + UserCompanyCurrent.CompanyID, ref tabpageNew, ref contextmenuControl, DoubleClickEventHandler);

                // Load Users
                LoadUsersOfCompany(companyID, userID, UserCompanyCurrent.AccessCompanyID, ref ListViewNew);
            }
        }

        public ListView AddControlsToTabPage(string controlName, ref TabPageAdv tabPageControl, ref ContextMenuStrip contextmenuControl, EventHandler DoubleClickEventHandler)
        {
            ListView listviewNew = new ListView();
            listviewNew.Name = controlName;
            listviewNew.View = View.Tile;
            listviewNew.Dock = DockStyle.Fill;
            listviewNew.ContextMenuStrip = contextmenuControl;
            listviewNew.DoubleClick += new System.EventHandler(DoubleClickEventHandler);
            tabPageControl.Controls.Add(listviewNew);

            return listviewNew;
        }

        private void LoadUsersOfCompany(byte companyID, short userID, byte usersCompanyID, ref ListView listviewCurrent)
        {
            listviewCurrent.SuspendLayout();

            foreach (User UserCurrent in mdbContext.User.Where(u => u.CompanyID == usersCompanyID).OrderBy(u => u.Name))
            {
                if (!(UserCurrent.UserID == Constants.UserID_Administrator || (usersCompanyID == companyID && UserCurrent.UserID == userID)))
                {
                    listviewCurrent.Items.Add(CS_Constants.KeyStringer + UserCurrent.CompanyID + CS_Constants.KeyDelimiter + UserCurrent.UserID, UserCurrent.Name, "");
                }
            }

            listviewCurrent.ResumeLayout();
        }
    }
}
