using System;
using System.Linq;
using Syncfusion.Windows.Forms.Tools;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserListFunctions
    {
        static public bool LoadListOfFavorites(ref ListView listviewFavorites, byte companyID, short userID, byte companyCount)
        {
            CSMessengerContext dbContext = new CSMessengerContext();

            listviewFavorites.SuspendLayout();

            listviewFavorites.Items.Clear();

            try
            {
                foreach (var item in dbContext.usp_User_ListFavorites(companyID, userID))
                {
                    //UserFavoriteFunctions.FavoriteAdd(ref listviewFavorites, item.CompanyID, item.CompanyAbbreviation, item.UserID, item.UserName, companyCount);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(string.Format("No se pudo cargar la lista de Favoritos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                listviewFavorites.ResumeLayout();
                return false;
            }

            listviewFavorites.ResumeLayout();
            return true;
        }

        private void AddUserItemToList(byte companyID, short userID, string userName, ref ListView listviewCurrent)
        {
            listviewCurrent.Items.Add(CS_Constants.KeyStringer + companyID + CS_Constants.KeyDelimiter + userID, userName, "");
        }

        public void CreateCompanyControlsAndLoadUsers(CSMessengerContext dbContext, byte companyID, short userID, ref TabControlAdv tabUsers, ref ContextMenuStrip contextmenuControl, EventHandler DoubleClickEventHandler)
        {
            foreach (UserCompany UserCompanyCurrent in dbContext.UserCompany.Where(uc => uc.CompanyID == companyID && uc.UserID == userID).OrderBy(uc => uc.CompanyGranted.Name))
            {
                // Add a new Tab Page to the Tab control
                TabPageAdv tabpageNew = new TabPageAdv(UserCompanyCurrent.CompanyGranted.Name);
                tabUsers.TabPages.Add(tabpageNew);

                // Add a ListView to the TabPage
                ListView ListViewNew = AddControlsToTabPage(Constants.ListView_Company_Prefix + UserCompanyCurrent.CompanyID, ref tabpageNew, ref contextmenuControl, DoubleClickEventHandler);

                // Load Users
                LoadUsersOfCompany(dbContext, companyID, userID, UserCompanyCurrent.AccessCompanyID, ref ListViewNew);
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

        private void LoadUsersOfCompany(CSMessengerContext dbContext, byte companyID, short userID, byte usersCompanyID, ref ListView listviewCurrent)
        {
            listviewCurrent.SuspendLayout();

            foreach (User UserCurrent in dbContext.User.Where(u => u.CompanyID == usersCompanyID).OrderBy(u => u.Name))
            {
                if (!(UserCurrent.UserID == Constants.UserID_Administrator || (usersCompanyID == companyID && UserCurrent.UserID == userID)))
                {
                    listviewCurrent.Items.Add(CS_Constants.KeyStringer + UserCurrent.CompanyID + CS_Constants.KeyDelimiter + UserCurrent.UserID, UserCurrent.Name, "");
                }
            }

            listviewCurrent.ResumeLayout();
        }

        static public bool GetUserInfoFromListViewItem(ref ListView ListViewSource, out byte companyID, out short userID, out string userName)
        {
            if (ListViewSource.SelectedItems.Count > 0)
            {
                string[] Keys = ListViewSource.SelectedItems[0].Name.Substring(CS_Constants.KeyStringer.Length).Split(Convert.ToChar(CS_Constants.KeyDelimiter));
                companyID = Convert.ToByte(Keys[0]);
                userID = Convert.ToInt16(Keys[1]);
                userName = ListViewSource.SelectedItems[0].Text;
                return true;
            }
            else
            {
                companyID = 0;
                userID = 0;
                userName = "";
                return false;
            }
        }

    }
}
