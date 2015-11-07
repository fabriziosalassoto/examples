using System;
using System.Collections.Generic;
using DBControllers;

namespace BOBusinessObjects
{
    public class BOCls_Photos : List<BOCls_Photo>
    {
        #region PrivateProperties
        private DBCls_Photos oDBPhotoController;
        #endregion

        #region Constructors
        public BOCls_Photos()
        {
            oDBPhotoController = new DBCls_Photos();
        }

        public BOCls_Photos(Object[,] pArrPhotos)
        {
            oDBPhotoController = new DBCls_Photos();
            FillList(pArrPhotos);

        }
        #endregion

        #region SearchMethods
        public bool GetPhotos()
        {
            Object[,] mArrPhotos = oDBPhotoController.ListPhotos();
            FillList(mArrPhotos);
            return true;
        }

        public bool GetPhotosByCriteria(PhotoCriteria pCriteriaKey, String pCriteriaValue)
        {
            Object[,] mArrPhotos = oDBPhotoController.ListPhotosByCriteria(pCriteriaKey, pCriteriaValue);
            FillList(mArrPhotos);
            return true;
        }
        #endregion

        #region ManipulationMethods
        public bool SaveAllPhotos()
        {
            foreach (BOCls_Photo oPhoto in this)
            {
                oPhoto.SavePhoto();
            }
            return true;
        }
        #endregion

        #region PrivateMethods
        private void FillList(Object[,] pArrPhotos)
        {
            Object[] mArrPhoto = null;
            for (int x = 0; x < pArrPhotos.GetLength(0); x++)
            {
                mArrPhoto = new String[(int)TotalPhotoCriteria.cTotal];
                for (int y = 0; y < pArrPhotos.GetLength(1); y++)
                {
                    mArrPhoto[y] = pArrPhotos[x, y];
                }
                BOCls_Photo oPhoto = new BOCls_Photo(mArrPhoto);
                this.Add(oPhoto);
            }
        }
        #endregion
    }
}