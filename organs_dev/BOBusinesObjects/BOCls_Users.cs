using System;
using System.Collections.Generic;
using DBControllers;

namespace BOBusinessObjects
{
    public class BOCls_Users : List<BOCls_User>
    {
        #region PrivateProperties
        private DBCls_Users oDBUserController;
        #endregion

        #region Constructors
        public BOCls_Users()
        {
            oDBUserController = new DBCls_Users();
        }

        public BOCls_Users(String[,] pArrUsers)
        {
            oDBUserController = new DBCls_Users();
            FillList(pArrUsers);

        }
        #endregion

        #region SearchMethods
        public bool GetUsers()
        {
            String[,] mArrUsers = oDBUserController.ListUsers();
            FillList(mArrUsers);
            return true;
        }

        public bool GetUsersByCriteria(UserCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[,] mArrUsers = oDBUserController.ListUsersByCriteria(pCriteriaKey, pCriteriaValue);
            FillList(mArrUsers);
            return true;
        }
        #endregion

        #region ManipulationMethods
        public bool SaveAllRoles()
        {
            foreach (BOCls_User oUser in this)
            {
                oUser.SaveUser();
            }
            return true;
        }
        #endregion

        #region PrivateMethods
        private void FillList(String[,] pArrUsers)
        {
            String[] mArrUser = null;
            for (int x = 0; x < pArrUsers.GetLength(0); x++)
            {
                mArrUser = new String[(int)TotalUserCriteria.cTotal];
                for (int y = 0; y < pArrUsers.GetLength(1); y++)
                {
                    mArrUser[y] = pArrUsers[x, y];
                }
                BOCls_User oUser = new BOCls_User(mArrUser);
                this.Add(oUser);
            }
        }
        #endregion
    }
}