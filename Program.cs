﻿using System;
using System.Windows.Forms;

namespace CSMessenger
{
    static class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            System.Windows.Forms.Cursor.Current = Cursors.AppStarting;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Get DB connection properties and create ConnectionString
            CS_Database_SQL pDatabase = new CS_Database_SQL();
            pDatabase.applicationName = My.Application.Info.Title;
            pDatabase.datasource = CSMessenger.Properties.Settings.Default.DBConnection_Datasource;
            pDatabase.initialCatalog = CSMessenger.Properties.Settings.Default.DBConnection_Database;
            pDatabase.userID = CSMessenger.Properties.Settings.Default.DBConnection_UserID;
            // Unencrypt database connection password
            CS_Encrypt_TripleDES PasswordDecrypter = new CS_Encrypt_TripleDES(CS_Constants.UserEncryptionPassword);
            string tempPassword = "";
            if (PasswordDecrypter.Decrypt(CSMessenger.Properties.Settings.Default.DBConnection_Password, ref tempPassword) == false)
            {
                MessageBox.Show("La contraseña encriptada del usuario de conexión a la base de datos es incorrecta.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pDatabase = null;
                PasswordDecrypter = null;
                return;
            }
            pDatabase.password = tempPassword;
            PasswordDecrypter = null;
            pDatabase.MultipleActiveResultsets = true;
            pDatabase.workstationID = Environment.MachineName;
            pDatabase.CreateConnectionString();
            CSMessengerContext.CreateConnectionString(CSMessenger.Properties.Settings.Default.DBConnection_Provider, pDatabase.connectionString);

            Application.Run(new formMain(args));
        }
    }
}
