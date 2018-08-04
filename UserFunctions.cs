using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSMessenger
{
    class UserFunctions
    {
        // Internal variables
        private CSMessengerContext mdbContext = new CSMessengerContext();
        private Company mCompany;
        private User mUser;
        private string mUserNameOnCompanyDB;

        public bool CheckCompany(byte CompanyID)
        {
            // Check if Company exists
            mCompany = mdbContext.Company.Find(CompanyID);
            if (mCompany == null)
            {
                MessageBox.Show("La compañía especificada en el primer parámetro de la línea de comandos no existe.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckUser(short userID, out string userName)
        {
            // Check if User exists in Company database and gets it's name
            if (GetUserFromCompanyDatabase(userID) == false)
            {
                userName = null;
                return false;
            }

            // Check if User exists in local database
            mUser = mdbContext.User.Find(mCompany.CompanyID, userID);
            if (mUser == null)
            {
                try
                {
                    // Doesn't exist, so add it
                    mUser = new User();
                    mUser.CompanyID = mCompany.CompanyID;
                    mUser.UserID = userID;
                    mUser.Name = mUserNameOnCompanyDB;
                    mUser.Semaphore = 0;
                    mUser.IsActive = true;
                    mdbContext.User.Add(mUser);

                    // Update the Company Semaphore to advice others clients to refresh Company Users list
                    mCompany.Semaphore = DateTime.Now.Millisecond;

                    mdbContext.SaveChanges();

                    userName = mUser.Name;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Error agregando el Usuario a la base de datos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userName = null;
                    return false;
                }
            }
            else
            {
                // Exists, so check data
                if (mUser.Name != mUserNameOnCompanyDB)
                {
                    try
                    {
                        mUser.Name = mUserNameOnCompanyDB;

                        // Update the Company Semaphore to advice others clients to refresh Company Users list
                        mCompany.Semaphore = DateTime.Now.Millisecond;

                        mdbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Error actualizando el Nombre del Usuario a la base de datos.{0}{0}Error #{1}: {2}", System.Environment.NewLine, ex.HResult, ex.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        userName = null;
                        return false;
                    }
                }

                userName = mUser.Name;
                return true;
            }
        }

        private bool GetUserFromCompanyDatabase(short userID)
        {
            try
            {
                System.Data.Entity.Core.Objects.ObjectResult<string> companyUsers = mdbContext.usp_User_GetInfoFromCompanyDB(mCompany.CompanyID, userID);
                foreach (string companyUser in companyUsers)
                {
                    mUserNameOnCompanyDB = companyUser;
                    return true;
                }
                MessageBox.Show("El Usuario especificado en la línea de comandos, no existe en la base de datos de la Compañía.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error leyendo los datos del Usuario desde la base de datos de la Compañía.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.InnerException.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
