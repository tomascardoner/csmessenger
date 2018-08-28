using System;
using System.Linq;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserFavoriteFunctions
    {
        static public void FavoriteAdd(byte companyID, short userID, byte favoriteCompanyID, short favoriteUserID, byte companyCount)
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
                }
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
            }
        }

        static public void FavoriteRemove(byte companyID, short userID, byte favoriteCompanyID, short favoriteUserID)
        {
            try
            {
                CSMessengerContext dbContext = new CSMessengerContext();
                UserFavorite UserFavoriteToRemove = dbContext.UserFavorite.Find(companyID, userID, favoriteCompanyID, favoriteUserID);
                dbContext.UserFavorite.Remove(UserFavoriteToRemove);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al quitar el Contacto a la lista de Favoritos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
