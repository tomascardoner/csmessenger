using System;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserFavoriteFunctions
    {
        static public bool LoadFavoritesToList(ref ListView listviewFavorites, byte companyID, short userID, byte companyCount)
        {
            CSMessengerContext dbContext = new CSMessengerContext();

            listviewFavorites.SuspendLayout();

            listviewFavorites.Items.Clear();

            try
            {
                foreach (var item in dbContext.usp_User_ListFavorites(companyID, userID))
                {
                    FavoriteAddListItem(ref listviewFavorites, item.CompanyID, item.CompanyAbbreviation, item.UserID, item.UserName, companyCount);
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

        static public void FavoriteAdd(ref ListView listviewFavorites, byte companyID, short userID, byte favoriteCompanyID, short favoriteUserID, byte companyCount)
        {
            try
            {
                using (CSMessengerContext dbContext = new CSMessengerContext())
                {
                    UserFavorite NewUserFavorite = new UserFavorite();
                    NewUserFavorite.CompanyID = companyID;
                    NewUserFavorite.UserID = userID;
                    NewUserFavorite.FavoriteCompanyID = favoriteCompanyID;
                    NewUserFavorite.FavoriteUserID = favoriteUserID;

                    dbContext.UserFavorite.Add(NewUserFavorite);
                    dbContext.SaveChanges();

                    string companyAbbreviation = dbContext.Company.Find(favoriteCompanyID).Abbreviation;
                    string userName = dbContext.User.Find(favoriteCompanyID, favoriteUserID).Name;

                    // Add item to Favorites List control for not to need to reload the entire list
                    FavoriteAddListItem(ref listviewFavorites, favoriteCompanyID, companyAbbreviation, favoriteUserID, userName, companyCount);
                }
                return;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.HResult == -2146232060)
                {
                    MessageBox.Show("Este Contacto ya está en la lista de Favoritos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show(string.Format("Error al agregar el Contacto a la lista de Favoritos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }

        static private void FavoriteAddListItem(ref ListView listviewFavorites, byte companyID, string companyAbbreviation, short userID, string userName, byte companyCount)
        {
            if (companyCount > 1)
            {
                listviewFavorites.Items.Add(CS_Constants.KeyStringer + companyID + CS_Constants.KeyDelimiter + userID, companyAbbreviation + " --> " + userName, "");
            }
            else
            {
                listviewFavorites.Items.Add(CS_Constants.KeyStringer + companyID + CS_Constants.KeyDelimiter + userID, userName, "");
            }
        }

        static public void FavoriteRemove(ref ListView listiviewFavorites, byte companyID, short userID, byte favoriteCompanyID, short favoriteUserID)
        {
            try
            {
                CSMessengerContext dbContext = new CSMessengerContext();
                UserFavorite UserFavoriteToRemove = dbContext.UserFavorite.Find(companyID, userID, favoriteCompanyID, favoriteUserID);
                dbContext.UserFavorite.Remove(UserFavoriteToRemove);
                dbContext.SaveChanges();

                // Remove item from Favorites List control for not to need to reload the entire list
                listiviewFavorites.Items[CS_Constants.KeyStringer + favoriteCompanyID + CS_Constants.KeyDelimiter + favoriteUserID].Remove();

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al quitar el Contacto a la lista de Favoritos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
