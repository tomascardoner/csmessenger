using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CSMessenger
{
    class Semaphores
    {
        CSMessengerContext mdbContext;

        // Company
        private Company mCompany;
        private int mCompanySemaphore;

        // User
        private User mUser;
        private int mUserSemaphore;

        public Semaphores(byte companyID, short userID)
        {
            mdbContext = new CSMessengerContext();

            mCompany = mdbContext.Company.Find(companyID);
            mCompanySemaphore = mCompany.Semaphore;

            mUser = mdbContext.User.Find(companyID, userID);
            mUserSemaphore = mUser.Semaphore;
        }

        public bool IsCompanyChanged()
        {
            mdbContext.Entry(mCompany).Reload();
            if (mCompanySemaphore != mCompany.Semaphore)
            {
                mCompanySemaphore = mCompany.Semaphore;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserChanged()
        {
            mdbContext.Entry(mUser).Reload();
            if (mUserSemaphore == 0 || mUserSemaphore != mUser.Semaphore)
            {
                mUserSemaphore = mUser.Semaphore;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
