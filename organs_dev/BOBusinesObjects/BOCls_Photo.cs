using System;
using System.Collections.Generic;
using DBControllers;

namespace BOBusinessObjects
{
    #region Enumerations
    public enum PhotoStatus
    {
        New = 0,
        Modified = 1,
        NotModified = 2,
        MarkedForDeletion = 3
    }
    #endregion

    public class BOCls_Photo
    {
        #region PrivateProperties
        private String ID;
        private Byte[] PhotoSRC;        
        private DBCls_Photos oDBPhotoController;
        private int ObjectStatus;
        #endregion

        #region PublicProperties
        public String GetID
        {
            get { return ID; }
        }

        public Byte[] GetPhoto
        {
            get { return PhotoSRC; }
        }

        public Byte[] SetPhoto
        {
            set
            {
                ObjectStatus = (int)PhotoStatus.Modified;
                PhotoSRC = value;
            }
        }

        public int GetStatus
        {
            get { return ObjectStatus; }
        }
        #endregion

        #region Constructors
        public BOCls_Photo()
        {
            oDBPhotoController = new DBCls_Photos();
            ID = "";            
            PhotoSRC = new Byte[0];
            ObjectStatus = (int)UserStatus.New;
        }

        public BOCls_Photo(String PhotoID)
        {
            oDBPhotoController = new DBCls_Photos();
            GetPhotoByID(PhotoID);
            ObjectStatus = (int)PhotoStatus.NotModified;
        }

        public BOCls_Photo(Object[] pArrPhoto)
        {
            oDBPhotoController = new DBCls_Photos();
            FillInPhoto(pArrPhoto);
            ObjectStatus = (int)PhotoStatus.NotModified;
        }
        #endregion

        #region SearchUtilities
        public bool GetPhotoByID(String PhotoID)
        {
            try
            {
                oDBPhotoController = new DBCls_Photos();
                Object[,] mArrPhoto = oDBPhotoController.SearchPhoto(PhotoID);
                if (mArrPhoto != null)
                {
                    ID = Convert.ToString(mArrPhoto[0,(int)PhotoCriteria.cID]);
                    PhotoSRC = (Byte[])mArrPhoto[0,(int)PhotoCriteria.cPHOTO];
                }
                oDBPhotoController = null;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region PhotoManipulation
        public bool SavePhoto()
        {
            try
            {
                List<Object> ArrPhoto = FillInArrayWithProperties();
                if (ID.Trim() == "")
                {
                    ObjectStatus = (int)PhotoStatus.New;
                }

                switch (ObjectStatus)
                {
                    case (int)PhotoStatus.New: ID = Convert.ToString(oDBPhotoController.InsertPhoto(ArrPhoto));
                        break;
                    case (int)PhotoStatus.Modified: oDBPhotoController.UpdatePhoto(ArrPhoto);
                        break;
                    case (int)PhotoStatus.MarkedForDeletion: oDBPhotoController.EliminatePhoto(PhotoCriteria.cID, ID);
                        break;
                }
                ObjectStatus = (int)PhotoStatus.NotModified;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected bool PhotoUser()
        {
            try
            {
                ObjectStatus = (int)PhotoStatus.MarkedForDeletion;
                SavePhoto();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region FillInOutProperties
        private List<Object> FillInArrayWithProperties()
        {
            List<Object> mArrProperties = new List<Object>();
            mArrProperties.Add(ID);
            mArrProperties.Add(PhotoSRC);
            return mArrProperties;
        }

        private void FillInPhoto(Object[] pPhoto)
        {
            ID = (String)pPhoto[(int)PhotoCriteria.cID];
            PhotoSRC = (Byte[])pPhoto[(int)PhotoCriteria.cPHOTO];
        }
        #endregion
    }
}