using System;
using System.Collections.Generic;
using DBBroker;

namespace DBControllers
{
    public enum TotalStoryCriteria
    {
        cTotal = 31
    }

    public enum StoryCriteria
    {
        cID = 0, cSUBMITTERFIRSTNAME = 1, cPHOTOID = 2, cSTORYTITLE = 3, cSTORYPLOT = 4, cROLEINSTORY = 5,
        cAGE = 6, cSTORYDATE = 7, cDONATIONTRANSPLANT = 8, cAUTHORIZATIONTEXT = 9, cAUTHORIZED = 10,
        cSUBMITTED = 11, cCONFIRMATIONID = 12, cSTORYSTATUS = 13, cHEARTH = 14, cLUNG = 15, cLIVER = 16, cKIDNEY = 17,
        cPANCREAS = 18, cINTESTINES = 19, cCORNEAS = 20, cMIDDLEEAR = 21, cBLOODVESSELS = 22, 
        cBONE = 23, cSKIN = 24, cOTHERORGAN = 25, cORGANDESCRIPTION = 26, cORGANIZATIONDESCRIPTION = 27, cEMAIL = 28,
        cISPUBLIC = 29, cRELATIONSHIP = 30
    }

    public class DBCls_Stories
    {
        private DBCls_DBConnection oConnection;

        private const int cCRITERIAKEY = 0;
        private const int cCRITERIAVALUE = 1;

        public DBCls_Stories()
        {
            oConnection = new DBCls_DBConnection();
        }

        public String[,] SearchStory(String pStrID)
        {
            String[,] ArrStories;
            String mStrSQL = "";            

            mStrSQL = "SELECT ID, SUBMITTERFIRSTNAME, PHOTOID, STORYTITLE, STORYPLOT, ROLEINSTORY, AGE, "+
                             "STORYDATE, DONATIONTRANSPLANT, AUTHORIZATIONTEXT, AUTHORIZED, SUBMITTED, "+
                             "CONFIRMATIONID, STORYSTATUS, HEARTH, LUNG, LIVER, KIDNEY, PANCREAS, "+
                             "INTESTINES, CORNEAS, MIDDLEEAR, BLOODVESSELS, BONE, SKIN, OTHERORGAN, "+
                             "ORGANDESCRIPTION, ORGANIZATIONDESCRIPTION, EMAIL, ISPUBLIC, RELATIONSHIP "+
                      "FROM STORIES WHERE ID=" + pStrID; 
            try
            {
                oConnection.OpenConnection();
                ArrStories = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrStories;
        }

        public int InsertStory(String[] pArrStory)
        {
            String mStrSQL = ""; 
            int mIntLastID = -1;

            mStrSQL = "INSERT INTO STORIES( " +
                             "SUBMITTERFIRSTNAME, PHOTOID, STORYTITLE, STORYPLOT, ROLEINSTORY, AGE, "+
                             "STORYDATE, DONATIONTRANSPLANT, AUTHORIZATIONTEXT, AUTHORIZED, SUBMITTED, "+
                             "CONFIRMATIONID, STORYSTATUS, HEARTH, LUNG, LIVER, KIDNEY, PANCREAS, "+
                             "INTESTINES, CORNEAS, MIDDLEEAR, BLOODVESSELS, BONE, SKIN, OTHERORGAN, "+
                             "ORGANDESCRIPTION, ORGANIZATIONDESCRIPTION, EMAIL, ISPUBLIC, RELATIONSHIP) " +
                      "VALUES (" +
                            "'" + pArrStory[(int)StoryCriteria.cSUBMITTERFIRSTNAME] + "', " +
                                  pArrStory[(int)StoryCriteria.cPHOTOID] + ", " +
                            "'" + pArrStory[(int)StoryCriteria.cSTORYTITLE] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cSTORYPLOT] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cROLEINSTORY] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cAGE] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cSTORYDATE] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cDONATIONTRANSPLANT] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cAUTHORIZATIONTEXT] + "', " +
                                  pArrStory[(int)StoryCriteria.cAUTHORIZED] + ", " +
                                  pArrStory[(int)StoryCriteria.cSUBMITTED] + ", " +
                            "'" + pArrStory[(int)StoryCriteria.cCONFIRMATIONID] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cSTORYSTATUS] + "', " +
                                  pArrStory[(int)StoryCriteria.cHEARTH] + ", " +
                                  pArrStory[(int)StoryCriteria.cLUNG] + ", " +
                                  pArrStory[(int)StoryCriteria.cLIVER] + ", " +
                                  pArrStory[(int)StoryCriteria.cKIDNEY] + ", " +
                                  pArrStory[(int)StoryCriteria.cPANCREAS] + ", " +
                                  pArrStory[(int)StoryCriteria.cINTESTINES] + ", " +
                                  pArrStory[(int)StoryCriteria.cCORNEAS] + ", " +
                                  pArrStory[(int)StoryCriteria.cMIDDLEEAR] + ", " +
                                  pArrStory[(int)StoryCriteria.cBLOODVESSELS] + ", " +                                  
                                  pArrStory[(int)StoryCriteria.cBONE] + ", " +
                                  pArrStory[(int)StoryCriteria.cSKIN] + ", " +
                                  pArrStory[(int)StoryCriteria.cOTHERORGAN] + ", " +
                            "'" + pArrStory[(int)StoryCriteria.cORGANDESCRIPTION] + "', " +                                  
                            "'" + pArrStory[(int)StoryCriteria.cORGANIZATIONDESCRIPTION] + "', " +
                            "'" + pArrStory[(int)StoryCriteria.cEMAIL] + "', " +
                                  pArrStory[(int)StoryCriteria.cISPUBLIC] + ", " +
                            "'" + pArrStory[(int)StoryCriteria.cRELATIONSHIP] + "')";            
            try
            {
                oConnection.OpenConnection();
                oConnection.UpdateSQL(mStrSQL,null);
                mIntLastID = GetLastStoryIDInserted();
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

        public bool UpdateStory(String[] pArrStory)
        {
            String mStrSQL = "";
            bool mBoolSuccess = false;
            mStrSQL = "UPDATE STORIES SET " +
                              "SUBMITTERFIRSTNAME = '" + pArrStory[(int)StoryCriteria.cSUBMITTERFIRSTNAME] + "', " +
                              "PHOTOID = " + pArrStory[(int)StoryCriteria.cPHOTOID] + ", " +
                              "STORYTITLE = '" + pArrStory[(int)StoryCriteria.cSTORYTITLE] + "', " +
                              "STORYPLOT = '" + pArrStory[(int)StoryCriteria.cSTORYPLOT] + "', " +
                              "ROLEINSTORY = '" + pArrStory[(int)StoryCriteria.cROLEINSTORY] + "', " +
                              "AGE = '" + pArrStory[(int)StoryCriteria.cAGE] + "', " +
                              "STORYDATE = '" + pArrStory[(int)StoryCriteria.cSTORYDATE] + "', " +
                              "DONATIONTRANSPLANT = '" + pArrStory[(int)StoryCriteria.cDONATIONTRANSPLANT] + "', " +
                              "AUTHORIZATIONTEXT = '" + pArrStory[(int)StoryCriteria.cAUTHORIZATIONTEXT] + "', " +
                              "AUTHORIZED = " + pArrStory[(int)StoryCriteria.cAUTHORIZED] + ", " +
                              "SUBMITTED = " + pArrStory[(int)StoryCriteria.cSUBMITTED] + ", " +
                              "CONFIRMATIONID = '" + pArrStory[(int)StoryCriteria.cCONFIRMATIONID] + "', " +
                              "STORYSTATUS = '" + pArrStory[(int)StoryCriteria.cSTORYSTATUS] + "', " +
                              "HEARTH = " + pArrStory[(int)StoryCriteria.cHEARTH] + ", " +
                              "LUNG = " + pArrStory[(int)StoryCriteria.cLUNG] + ", " +
                              "LIVER = " + pArrStory[(int)StoryCriteria.cLIVER] + ", " +
                              "KIDNEY = " + pArrStory[(int)StoryCriteria.cKIDNEY] + ", " +
                              "PANCREAS = " + pArrStory[(int)StoryCriteria.cPANCREAS] + ", " +
                              "INTESTINES = " + pArrStory[(int)StoryCriteria.cINTESTINES] + ", " +
                              "CORNEAS = " + pArrStory[(int)StoryCriteria.cCORNEAS] + ", " +
                              "MIDDLEEAR = " + pArrStory[(int)StoryCriteria.cMIDDLEEAR] + ", " +
                              "BLOODVESSELS = " + pArrStory[(int)StoryCriteria.cBLOODVESSELS] + ", " +                              
                              "BONE = " + pArrStory[(int)StoryCriteria.cBONE] + ", " +
                              "SKIN = " + pArrStory[(int)StoryCriteria.cSKIN] + ", " +
                              "OTHERORGAN = " + pArrStory[(int)StoryCriteria.cOTHERORGAN] + ", " +
                              "ORGANDESCRIPTION = '" + pArrStory[(int)StoryCriteria.cORGANDESCRIPTION] + "', " +                              
                              "ORGANIZATIONDESCRIPTION = '" + pArrStory[(int)StoryCriteria.cORGANIZATIONDESCRIPTION] + "', " +
                              "EMAIL = '" + pArrStory[(int)StoryCriteria.cEMAIL] + "', " +
                              "ISPUBLIC = " + pArrStory[(int)StoryCriteria.cISPUBLIC] + ", " +
                              "RELATIONSHIP = '" + pArrStory[(int)StoryCriteria.cRELATIONSHIP] + "' " +
                    "WHERE ID=" + pArrStory[(int)StoryCriteria.cID];
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

        public bool EliminateStory(StoryCriteria pCriteriaKey, String pCriteriaValue)
        {
            bool mBoolSuccess = false;
            String mStrSQL = "";            
            String[] ArrCriteria = GetDBFieldByCriteria(pCriteriaKey, pCriteriaValue);

            mStrSQL = "DELETE FROM STORIES " +
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

        public String[,] ListStories()
        {
            String[,] ArrStories;
            String mStrSQL = "";

            mStrSQL = "SELECT ID, SUBMITTERFIRSTNAME, PHOTOID, STORYTITLE, STORYPLOT, ROLEINSTORY, AGE, " +
                             "STORYDATE, DONATIONTRANSPLANT, AUTHORIZATIONTEXT, AUTHORIZED, SUBMITTED, " +
                             "CONFIRMATIONID, STORYSTATUS, HEARTH, LUNG, LIVER, KIDNEY, PANCREAS, " +
                             "INTESTINES, CORNEAS, MIDDLEEAR, BLOODVESSELS, BONE, SKIN, OTHERORGAN, " +
                             "ORGANDESCRIPTION, ORGANIZATIONDESCRIPTION, EMAIL, ISPUBLIC, RELATIONSHIP " +
                      "FROM STORIES";
            try
            {
                oConnection.OpenConnection();
                ArrStories = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrStories;
        }

        public String[,] ListStoriesByCriteria(StoryCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[,] ArrStories;
            String[] ArrCriteria = GetDBFieldByCriteria(pCriteriaKey, pCriteriaValue);
            String mStrSQL = "";

            mStrSQL = "SELECT ID, SUBMITTERFIRSTNAME, PHOTOID, STORYTITLE, STORYPLOT, ROLEINSTORY, AGE, " +
                             "STORYDATE, DONATIONTRANSPLANT, AUTHORIZATIONTEXT, AUTHORIZED, SUBMITTED, " +
                             "CONFIRMATIONID, STORYSTATUS, HEARTH, LUNG, LIVER, KIDNEY, PANCREAS, " +
                             "INTESTINES, CORNEAS, MIDDLEEAR, BLOODVESSELS, BONE, SKIN, OTHERORGAN, " +
                             "ORGANDESCRIPTION, ORGANIZATIONDESCRIPTION, EMAIL, ISPUBLIC, RELATIONSHIP " +
                      "WHERE " + ArrCriteria[cCRITERIAKEY] + " = " +
                                 ArrCriteria[cCRITERIAVALUE];
            try
            {
                oConnection.OpenConnection();
                ArrStories = oConnection.QuerySQLResultFlatArray(mStrSQL);
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
            return ArrStories;
        }

        private String[] GetDBFieldByCriteria(StoryCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[] ArrCriteriaField = new String[2];
            switch (pCriteriaKey)
            {
                case StoryCriteria.cID : ArrCriteriaField[cCRITERIAKEY] = "ID";
			        ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cSUBMITTERFIRSTNAME : ArrCriteriaField[cCRITERIAKEY] = "SUBMITTERFIRSTNAME";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue+ "'";
                         break;
                case StoryCriteria.cPHOTOID : ArrCriteriaField[cCRITERIAKEY] = "PHOTOID";
			 ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                         break;
                case StoryCriteria.cSTORYTITLE : ArrCriteriaField[cCRITERIAKEY] = "STORYTITLE";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cSTORYPLOT : ArrCriteriaField[cCRITERIAKEY] = "STORYPLOT";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cROLEINSTORY : ArrCriteriaField[cCRITERIAKEY] = "ROLEINSTORY";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;                
                case StoryCriteria.cAGE : ArrCriteriaField[cCRITERIAKEY] = "AGE";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cSTORYDATE : ArrCriteriaField[cCRITERIAKEY] = "STORYDATE";
           	          ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                      break;
                case StoryCriteria.cDONATIONTRANSPLANT : ArrCriteriaField[cCRITERIAKEY] = "DONATIONSTRANSPLANT";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;                
                case StoryCriteria.cAUTHORIZATIONTEXT : ArrCriteriaField[cCRITERIAKEY] = "AUTHORIZATIONTEXT";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cAUTHORIZED : ArrCriteriaField[cCRITERIAKEY] = "AUTHORIZED";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cSUBMITTED: ArrCriteriaField[cCRITERIAKEY] = "SUBMITTED";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cCONFIRMATIONID : ArrCriteriaField[cCRITERIAKEY] = "CONFIRMATIONID";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cSTORYSTATUS : ArrCriteriaField[cCRITERIAKEY] = "STORYSTATUS";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cHEARTH: ArrCriteriaField[cCRITERIAKEY] = "HEARTH";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cLUNG: ArrCriteriaField[cCRITERIAKEY] = "LUNG";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cLIVER: ArrCriteriaField[cCRITERIAKEY] = "LIVER";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cKIDNEY: ArrCriteriaField[cCRITERIAKEY] = "KIDNEY";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cPANCREAS: ArrCriteriaField[cCRITERIAKEY] = "PANCREAS";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cINTESTINES: ArrCriteriaField[cCRITERIAKEY] = "INTESTINES";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cCORNEAS: ArrCriteriaField[cCRITERIAKEY] = "CORNEAS";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cMIDDLEEAR: ArrCriteriaField[cCRITERIAKEY] = "MIDDLEEAR";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cBLOODVESSELS: ArrCriteriaField[cCRITERIAKEY] = "BLOODVESSELS";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;                
                case StoryCriteria.cBONE: ArrCriteriaField[cCRITERIAKEY] = "BONE";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cSKIN: ArrCriteriaField[cCRITERIAKEY] = "SKIN";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cOTHERORGAN: ArrCriteriaField[cCRITERIAKEY] = "OTHERORGAN";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cORGANDESCRIPTION: ArrCriteriaField[cCRITERIAKEY] = "ORGANDESCRIPTION";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;                
                case StoryCriteria.cORGANIZATIONDESCRIPTION: ArrCriteriaField[cCRITERIAKEY] = "ORGANIZATIONDESCRIPTION";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cEMAIL: ArrCriteriaField[cCRITERIAKEY] = "EMAIL";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
                case StoryCriteria.cISPUBLIC: ArrCriteriaField[cCRITERIAKEY] = "ISPUBLIC";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                default: ArrCriteriaField[cCRITERIAKEY] = "";
                    ArrCriteriaField[cCRITERIAVALUE] = pCriteriaValue;
                    break;
                case StoryCriteria.cRELATIONSHIP: ArrCriteriaField[cCRITERIAKEY] = "RELATIONSHIP";
                    ArrCriteriaField[cCRITERIAVALUE] = "'" + pCriteriaValue + "'";
                    break;
            }
            return ArrCriteriaField;
        }

        public int GetLastStoryIDInserted()
        {
            int intLastID = -1;
            String strLastID = "";

            try
            {
                oConnection.OpenConnection();
                strLastID = oConnection.GetLastIDInserted("STORIES");
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

        public String EscapeValue(String pValue)
        {
            return oConnection.EscapeValue(pValue);
        }
    }
}