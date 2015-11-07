using System;
using System.Collections.Generic;
using DBBroker;

namespace DBControllers
{
    public enum TotalUserCriteria{
        cTotal = 8
    }

    public enum UserCriteria
    {
        cID = 0,
        cFIRSTNAME = 1,
        cLASTNAME = 2,
        cROLEDESCRIPTION = 3,
        cREAD = 4,
        cWRITE = 5,
        cEDIT = 6,
        cSEARCH = 7
    }    

    public class DBCls_Users
    {
        private DBCls_DBConnection oConnection;

        private const int cCRITERIAKEY = 0;
        private const int cCRITERIAVALUE = 1;

        public DBCls_Users()
        {
            oConnection = new DBCls_DBConnection();
        }

        public String[,] SearchUser(String pStrID)
        {
            String[,] ArrUsers;
            String mStrSQL = "";

            mStrSQL = "SELECT ID, FIRSTNAME, LASTNAME, ROLEDESCRIPTION, R, W, E, S " +
                      "FROM USERS WHERE ID=" + pStrID;
            try
            {
                oConnection.OpenConnection();
                ArrUsers = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrUsers;
        }

        public int InsertUser(String[] pArrUser)
        {
            String mStrSQL = ""; 
            int mIntLastID = -1;

            mStrSQL = "INSERT INTO USERS(FIRSTNAME,LASTNAME,ROLEDESCRIPTION,R,W,E,S) " +
                      "VALUES ('" + pArrUser[(int)UserCriteria.cFIRSTNAME] + "','" +
                                    pArrUser[(int)UserCriteria.cLASTNAME] + "','" +
                                    pArrUser[(int)UserCriteria.cROLEDESCRIPTION] + "'," +
                                    pArrUser[(int)UserCriteria.cREAD] +
                                    pArrUser[(int)UserCriteria.cWRITE] +
                                    pArrUser[(int)UserCriteria.cEDIT] +
                                    pArrUser[(int)UserCriteria.cSEARCH] + ")";
            try{
                oConnection.OpenConnection();
                oConnection.UpdateSQL(mStrSQL,null);
                mIntLastID = GetLastUserIDInserted();
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

        public bool UpdateUser(String[] pArrUser)
        {
            String mStrSQL = "";
            bool mBoolSuccess = false;

            mStrSQL = "UPDATE USERS SET FIRSTNAME='" + pArrUser[(int)UserCriteria.cFIRSTNAME] + "'," +
                                       "LASTNAME='" + pArrUser[(int)UserCriteria.cLASTNAME] + "'," +
                                       "ROLEDESCRIPTION='" + pArrUser[(int)UserCriteria.cROLEDESCRIPTION] + "'," +
                                       "R=" + pArrUser[(int)UserCriteria.cREAD] +
                                       "W=" + pArrUser[(int)UserCriteria.cWRITE] +
                                       "E=" + pArrUser[(int)UserCriteria.cEDIT] +
                                       "S=" + pArrUser[(int)UserCriteria.cSEARCH] + 
                      " WHERE ID=" + pArrUser[(int)UserCriteria.cID];
            try
            {
                oConnection.OpenConnection();
                oConnection.UpdateSQL(mStrSQL,null);
                mBoolSuccess = true;
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
            return mBoolSuccess;
        }

        public bool EliminateUser(UserCriteria pCriteriaKey, String pCriteriaValue)
        {
            bool mBoolSuccess = false;
            String mStrSQL = "";
            String[] ArrCriteria = GetDBFieldByCriteria(pCriteriaKey, pCriteriaValue);
                  
            mStrSQL = "DELETE FROM USERS " +
                      "WHERE " + ArrCriteria[cCRITERIAKEY] + " = " +
                                 ArrCriteria[cCRITERIAVALUE];            

            try
            {
                oConnection.OpenConnection();
                oConnection.UpdateSQL(mStrSQL,null);
                mBoolSuccess = true;
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
            return mBoolSuccess;
        }

        public String[,] ListUsers()
        {
            String[,] ArrUsers;
            String mStrSQL = "";

            mStrSQL = "SELECT ID, FIRSTNAME, LASTNAME, ROLEDESCRIPTION, R, W, E, S " +
                      "FROM USERS";
            try
            {
                oConnection.OpenConnection();
                ArrUsers = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrUsers;
        }

        public String[,] ListUsersByCriteria(UserCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[,] ArrUsers;
            String[] ArrCriteria = GetDBFieldByCriteria(pCriteriaKey,pCriteriaValue);
            String mStrSQL = "";            

            mStrSQL = "SELECT ID, FIRSTNAME, LASTNAME, ROLEID, R, W, E, S " +
                      "FROM USERS " +
                      "WHERE " + ArrCriteria[cCRITERIAKEY] + " = " +
                                 ArrCriteria[cCRITERIAVALUE];
            try
            {
                oConnection.OpenConnection();
                ArrUsers = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrUsers;
        }

        private String[] GetDBFieldByCriteria(UserCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[] ArrCriteriaField = new String[2];
            switch (pCriteriaKey) {
                case UserCriteria.cID : ArrCriteriaField[cCRITERIAKEY] = "ID";
                                        ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                        break;
                case UserCriteria.cFIRSTNAME : ArrCriteriaField[cCRITERIAKEY] = "FIRSTNAME";
                                               ArrCriteriaField[cCRITERIAVALUE] = "'"+pCriteriaValue+"'";
                                               break;
                case UserCriteria.cLASTNAME : ArrCriteriaField[cCRITERIAKEY] = "LASTNAME";
                                              ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                                               break;
                case UserCriteria.cROLEDESCRIPTION: ArrCriteriaField[cCRITERIAKEY] = "ROLEDESCRIPTION";
                                               ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                                               break;                
                case UserCriteria.cREAD: ArrCriteriaField[cCRITERIAKEY] = "R";
                                           ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                               break;
                case UserCriteria.cWRITE: ArrCriteriaField[cCRITERIAKEY] = "W";
                                               ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                               break;
                case UserCriteria.cEDIT: ArrCriteriaField[cCRITERIAKEY] = "E";
                                               ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                               break;
                case UserCriteria.cSEARCH: ArrCriteriaField[cCRITERIAKEY] = "S";
                                               ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                               break;                
                default: ArrCriteriaField[cCRITERIAKEY] = "";
                         ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                                               break;                           
            }
            return ArrCriteriaField;
        }

        public int GetLastUserIDInserted()
        {
            int intLastID = -1;
            String strLastID = "";

            try
            {
                oConnection.OpenConnection();
                strLastID = oConnection.GetLastIDInserted("USERS");
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