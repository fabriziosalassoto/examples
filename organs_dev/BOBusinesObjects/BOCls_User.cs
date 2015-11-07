using System;
using System.Collections.Generic;
using DBControllers;

namespace BOBusinessObjects
{
    #region Enumerations
    public enum UserStatus
    {
        New = 0,
        Modified = 1,
        NotModified = 2,
        MarkedForDeletion = 3
    }
    #endregion

    public class BOCls_User
    {
        #region PrivateProperties
        private String ID;
        private String FirstName;
        private String LastName;
        private String RoleName;
        private String ReadPermission;
        private String WritePermission;
        private String EditPermission;
        private String SearchPermission;
        private DBCls_Users oDBUserController;
        private int ObjectStatus;
        #endregion

        #region PublicProperties
        public String GetID
        {
            get { return ID; }
        }

        public String GetRoleName
        {
            get { return RoleName; }
        }

        public String SetRoleName
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                RoleName = value;
            }
        }

        public String GetFirstName
        {
            get { return FirstName; }
        }

        public String SetFirstName
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                FirstName = value;
            }
        }

        public String GetReadPermission
        {
            get { return ReadPermission; }
        }
        public String SetReadPermission
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                ReadPermission = value;
            }
        }

        public String GetWritePermission
        {
            get { return WritePermission; }
        }
        public String SetWritePermission
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                WritePermission = value;
            }
        }

        public String GetEditPermission
        {
            get { return EditPermission; }
        }
        public String SetEditPermission
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                EditPermission = value;
            }
        }

        public String GetSearchPermission
        {
            get { return SearchPermission; }
        }
        public String SetSearchPermission
        {
            set
            {
                ObjectStatus = (int)UserStatus.Modified;
                SearchPermission = value;
            }
        }

        public int GetStatus
        {
            get { return ObjectStatus; }
        }
        #endregion

        #region Constructors
        public BOCls_User()
        {
            oDBUserController = new DBCls_Users();
            ID = "";
            FirstName = "";
            LastName = "";
            RoleName = "";
            ReadPermission = "";
            WritePermission = "";
            EditPermission = "";
            SearchPermission = "";
            ObjectStatus = (int)UserStatus.New;
        }

        public BOCls_User(String UserID)
        {
            oDBUserController = new DBCls_Users();
            GetUserByID(UserID);
            ObjectStatus = (int)UserStatus.NotModified;
        }

        public BOCls_User(String[] ArrUser)
        {
            oDBUserController = new DBCls_Users();
            FillInUser(ArrUser);
            ObjectStatus = (int)UserStatus.NotModified;
        }
        #endregion

        #region SearchUser
        public bool GetUserByID(String UserID)
        {
            try
            {
                oDBUserController = new DBCls_Users();
                String[,] ArrUser = oDBUserController.SearchUser(UserID);
                if (ArrUser != null)
                {
                    ID = ArrUser[0, (int)UserCriteria.cID];
                    RoleName = ArrUser[0, (int)UserCriteria.cROLEDESCRIPTION];
                    ReadPermission = ArrUser[0, (int)UserCriteria.cREAD];
                    WritePermission = ArrUser[0, (int)UserCriteria.cWRITE];
                    EditPermission = ArrUser[0, (int)UserCriteria.cEDIT];
                    SearchPermission = ArrUser[0, (int)UserCriteria.cSEARCH];
                }
                oDBUserController = null;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region StoryManipulation
        public bool SaveUser()
        {
            try
            {
                String[] ArrUser = FillInArrayWithProperties();
                if (ID.Trim() == "")
                {
                    ObjectStatus = (int)UserStatus.New;
                }

                switch (ObjectStatus)
                {
                    case (int)UserStatus.New: ID = Convert.ToString(oDBUserController.InsertUser(ArrUser));
                        break;
                    case (int)UserStatus.Modified: oDBUserController.UpdateUser(ArrUser);
                        break;
                    case (int)UserStatus.MarkedForDeletion: oDBUserController.EliminateUser(UserCriteria.cID, ID);
                        break;
                }
                ObjectStatus = (int)UserStatus.NotModified;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected bool DeleteUser()
        {
            try
            {
                ObjectStatus = (int)UserStatus.MarkedForDeletion;
                SaveUser();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region FillInOutProperties
        private String[] FillInArrayWithProperties()
        {
            String[] mArrProperties = new String[(int)TotalUserCriteria.cTotal];
            mArrProperties[(int)UserCriteria.cID] = ID;
            mArrProperties[(int)UserCriteria.cFIRSTNAME] = FirstName;
            mArrProperties[(int)UserCriteria.cLASTNAME] = LastName;
            mArrProperties[(int)UserCriteria.cROLEDESCRIPTION] = RoleName;
            mArrProperties[(int)UserCriteria.cREAD] = ReadPermission;
            mArrProperties[(int)UserCriteria.cWRITE] = WritePermission;
            mArrProperties[(int)UserCriteria.cEDIT] = EditPermission;
            mArrProperties[(int)UserCriteria.cSEARCH] = SearchPermission;
            return mArrProperties;
        }

        private void FillInUser(String[] pUser)
        {
            ID = pUser[(int)UserCriteria.cID];
            FirstName = pUser[(int)UserCriteria.cROLEDESCRIPTION];
            LastName = pUser[(int)UserCriteria.cROLEDESCRIPTION];
            RoleName = pUser[(int)UserCriteria.cROLEDESCRIPTION];
            ReadPermission = pUser[(int)UserCriteria.cREAD];
            WritePermission = pUser[(int)UserCriteria.cWRITE];
            EditPermission = pUser[(int)UserCriteria.cEDIT];
            SearchPermission = pUser[(int)UserCriteria.cSEARCH];
        }
        #endregion
    }
}