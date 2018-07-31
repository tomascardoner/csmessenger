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
                using (SqlConnection sqlconn = new SqlConnection())
                {
                    // Get DB connection properties and create ConnectionString
                    CS_Database_SQL objDatabase = new CS_Database_SQL();
                    objDatabase.applicationName = My.Application.Info.Title;
                    objDatabase.datasource = CSMessenger.Properties.Settings.Default.DBConnection_Datasource;
                    objDatabase.initialCatalog = mCompany.DatabaseName;
                    objDatabase.userID = CSMessenger.Properties.Settings.Default.DBConnection_UserID;
                    // Unencrypt database connection password
                    CS_Encrypt_TripleDES PasswordDecrypter = new CS_Encrypt_TripleDES(CS_Constants.EncryptionPassword);
                    objDatabase.password = PasswordDecrypter.Decrypt(CSMessenger.Properties.Settings.Default.DBConnection_Password);
                    PasswordDecrypter = null;
                    objDatabase.MultipleActiveResultsets = true;
                    objDatabase.workstationID = Environment.MachineName;
                    objDatabase.CreateConnectionString();

                    // Create SQL Connection
                    sqlconn.ConnectionString = objDatabase.connectionString;
                    sqlconn.Open();

                    // Create SQL Command
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "usp_Usuario_Data";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add(new SqlParameter("@IDUsuario", userID));

                    // Create SQL DataReader
                    SqlDataReader sqldatrdr;
                    sqldatrdr = sqlcmd.ExecuteReader();

                    if (sqldatrdr.Read())
                    {
                        mUserNameOnCompanyDB = sqldatrdr["Nombre"].ToString();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario especificado en la línea de comandos, no existe en la base de datos de la Compañía.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error leyendo los datos del Usuario desde la base de datos de la Compañía.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        static public bool SetUserSemaphoreOnCompanyDatabase(byte companyID, short userID)
        {
            try
            {
                using (SqlConnection sqlconn = new SqlConnection())
                {
                    // Get DB connection properties and create ConnectionString
                    CS_Database_SQL objDatabase = new CS_Database_SQL();
                    objDatabase.applicationName = My.Application.Info.Title;
                    objDatabase.datasource = CSMessenger.Properties.Settings.Default.DBConnection_Datasource;
                    //objDatabase.initialCatalog = mCompany.DatabaseName;
                    objDatabase.userID = CSMessenger.Properties.Settings.Default.DBConnection_UserID;
                    // Unencrypt database connection password
                    CS_Encrypt_TripleDES PasswordDecrypter = new CS_Encrypt_TripleDES(CS_Constants.EncryptionPassword);
                    objDatabase.password = PasswordDecrypter.Decrypt(CSMessenger.Properties.Settings.Default.DBConnection_Password);
                    PasswordDecrypter = null;
                    objDatabase.MultipleActiveResultsets = true;
                    objDatabase.workstationID = Environment.MachineName;
                    objDatabase.CreateConnectionString();

                    // Create SQL Connection
                    sqlconn.ConnectionString = objDatabase.connectionString;
                    sqlconn.Open();

                    // Create SQL Command
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlconn;
                    sqlcmd.CommandText = "usp_Usuario_Semaforo_Update";
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Add(new SqlParameter("@IDUsuario", userID));
                    sqlcmd.ExecuteNonQuery();

                    return true;
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(string.Format("Error al enviar la notificación al Usuario de Destino en la base de datos de la Compañía.{0}{0}Error #{1}: {2}", System.Environment.NewLine, e.HResult, e.Message), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
