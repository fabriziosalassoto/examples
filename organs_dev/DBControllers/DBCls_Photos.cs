using System;
using System.Collections.Generic;
using DBBroker;

namespace DBControllers
{
    public enum TotalPhotoCriteria
    {
        cTotal = 2
    }

    public enum PhotoCriteria
    {
        cID = 0,
        cPHOTO = 1        
    }

    public class DBCls_Photos
    {
        private DBCls_DBConnection oConnection;
        private const int cCRITERIAKEY = 0;
        private const int cCRITERIAVALUE = 1;

        public DBCls_Photos()
        {
            oConnection = new DBCls_DBConnection();
        }

        public Object[,] SearchPhoto(Object pStrID)
        {
            Object[,] ArrPhotos;
            String mStrSQL = "";

            mStrSQL = "SELECT ID, PHOTOSRC " +
                      "FROM USERS WHERE ID=" + Convert.ToString(pStrID);
            try
            {
                oConnection.OpenConnection();
                ArrPhotos = oConnection.QuerySQLResultList(mStrSQL);
                //oConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return ArrPhotos;
        }

        public int InsertPhoto(List<Object> pArrPhoto)
        {
            String mStrSQL = "";
            int mIntLastID = -1;
            List<Object> mArrPhoto = null;

            mStrSQL = "INSERT INTO PHOTOS(PHOTOSRC) " +
                      "VALUES (@img)";

            try
            {
                oConnection.OpenConnection();
                if (pArrPhoto != null) {
                    mArrPhoto = new List<Object>();
                    mArrPhoto.Add("@img");
                    mArrPhoto.Add(pArrPhoto[cCRITERIAVALUE]);
                }
                oConnection.UpdateSQL(mStrSQL,mArrPhoto);
                mIntLastID = GetLastPhotoIDInserted();
                //oConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return mIntLastID;
        }

        public void UpdatePhoto(List<Object> pArrPhoto)
        {
            String mStrSQL = "";
            List<Object> mArrPhoto = null;
            mStrSQL = "UPDATE PHOTOS SET PHOTOSRC=@img " +
                      "WHERE ID=" + Convert.ToString(pArrPhoto[(int)PhotoCriteria.cID]);
            try
            {
                oConnection.OpenConnection();
                if (pArrPhoto != null)
                {
                    mArrPhoto = new List<Object>();
                    mArrPhoto.Add("@img");
                    mArrPhoto.Add(pArrPhoto[cCRITERIAVALUE]);
                }
                oConnection.UpdateSQL(mStrSQL,mArrPhoto);
                //oConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
        }

        public bool EliminatePhoto(PhotoCriteria pCriteriaKey, String pCriteriaValue)
        {
            bool mBoolSuccess = false;
            String mStrSQL = "";
            List<Object> ArrCriteria = GetDBFieldByCriteria(pCriteriaKey, pCriteriaValue);

            
            mStrSQL = "DELETE FROM PHOTOS " +
                      "WHERE " + Convert.ToString(ArrCriteria[cCRITERIAKEY]) + " = ";
            
            if (pCriteriaKey == PhotoCriteria.cID)
            {
                mStrSQL += Convert.ToString(ArrCriteria[cCRITERIAVALUE]);
            } else {
                mStrSQL += (byte[])(ArrCriteria[cCRITERIAVALUE]);
            }
            try
            {
                oConnection.OpenConnection();
                oConnection.UpdateSQL(mStrSQL,null);
                mBoolSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return mBoolSuccess;
        }

        public Object[,] ListPhotos()
        {
            Object[,] ArrPhotos;
            String mStrSQL = "";

            mStrSQL = "SELECT ID, PHOTOSRC " +
                      "FROM PHOTOS";
            try
            {
                oConnection.OpenConnection();
                ArrPhotos = oConnection.QuerySQLResultList(mStrSQL);
                oConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return ArrPhotos;
        }

        public Object[,] ListPhotosByCriteria(PhotoCriteria pCriteriaKey, Object pCriteriaValue)
        {
            Object[,] ArrPhotos;
            List<Object> ArrCriteria = GetDBFieldByCriteria(pCriteriaKey, pCriteriaValue);
            String mStrSQL = "";

            mStrSQL = "SELECT ID, PHOTOSRC " +
                      "FROM PHOTOS " +
                      "WHERE " + ArrCriteria[cCRITERIAKEY] + " = " +
                                 ArrCriteria[cCRITERIAVALUE];
            try
            {
                oConnection.OpenConnection();
                ArrPhotos = oConnection.QuerySQLResultList(mStrSQL);
                //oConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return ArrPhotos;
        }

        private List<Object> GetDBFieldByCriteria(PhotoCriteria pCriteriaKey, Object pCriteriaValue)
        {
            List<Object> ArrCriteriaField = new List<Object>();
            switch (pCriteriaKey)
            {
                case PhotoCriteria.cID: ArrCriteriaField[cCRITERIAKEY] = "ID";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case PhotoCriteria.cPHOTO: ArrCriteriaField[cCRITERIAKEY] = "PHOTOSRC";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;                
                default: ArrCriteriaField[cCRITERIAKEY] = "";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
            }
            return ArrCriteriaField;
        }

        public int GetLastPhotoIDInserted()
        {
            int intLastID = -1;
            String strLastID = "";

            try
            {
                oConnection.OpenConnection();
                strLastID = oConnection.GetLastIDInserted("PHOTOS");
                oConnection.CloseConnection();
                intLastID = int.Parse(strLastID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConnection.CloseConnection();
            }
            return intLastID;
        }

        private String EncryptField(String pFieldValue)
        {
            // here it will go encryption
            return "";
        }

        private String DecryptField(String pFieldValue)
        {
            // here it will go decryption
            return "";
        }
    }
}