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

        // User
        User mUser;
        int mUserSemaphore;

        // UserNotification
        List<UserNotification> mUserNotifications;

        // Company
        int mCompanySemaphore;

        public Semaphores(byte companyID, short userID)
        {
            mdbContext = new CSMessengerContext();

            mUser = mdbContext.User.Find(companyID, userID);
            mUserSemaphore = mUser.Semaphore;

            mUserNotifications = mdbContext.UserNotification.Where(un => un.DestinationCompanyID == companyID && un.DestinationUserID == userID).ToList();
        }

        public bool UserChanged()
        {
            mdbContext.Entry(mUser).Reload();
            if (mUserSemaphore != mUser.Semaphore)
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
