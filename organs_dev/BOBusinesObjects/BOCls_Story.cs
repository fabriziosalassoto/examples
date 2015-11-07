using System;
using System.Collections.Generic;
using DBControllers;
using BOLibrary;

namespace BOBusinessObjects
{
    #region enumerations
    public enum StoryStatus
    {
        New = 0,
        Modified = 1,
        NotModified = 2,
        MarkedForDeletion = 3
    }
    #endregion

    public class BOCls_Story
    {
        #region PrivateProperties

        private String ID;
        private String SubmitterFirstName;
        private String PhotoID;
        private String StoryTitle;
        private String StoryPlot;
        private String RoleInStory;
        private String Age;
        private String StoryDate;
        private String DonationTransplant;
        private String AuthorizationText;
        private String Authorized;
        private String Submitted;
        private String ConfirmationID;
        private String StoryState;
        private String Hearth;
        private String Lung;
        private String Liver;
        private String Kidney;
        private String Pancreas;
        private String Intestines;
        private String Corneas;
        private String MiddleEar;
        private String BloodVessels;        
        private String Bone;
        private String Skin;
        private String OtherOrgan;
        private String OrganDescription;
        private String OrganizationDescription;
        private String Email;
        private String IsPublic;
        private String Relationship;               
        private DBCls_Stories oDBStoryController;
        private int ObjectStatus;

        #endregion

        #region PublicProperties 
        public String GetID
        {
            get { return ID; }
        }

        public String GetSubmitterFirstName
        {
            get { return SubmitterFirstName; }
        }

        public String SetSubmitterFirstName
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                SubmitterFirstName = value;
            }
        }

        public String GetPhotoID
        {
            get { return PhotoID; }
        }

        public String SetPhotoID
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                PhotoID = value;
            }
        }

        public String GetStoryTitle
        {
            get { return StoryTitle; }
        }

        public String SetStoryTitle
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                StoryTitle = value;
            }
        }

        public String GetStoryPlot
        {
            get { return StoryPlot; }
        }

        public String SetStoryPlot
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                StoryPlot = value;
            }
        }

        public String GetRoleInStory
        {
            get { return RoleInStory; }
        }

        public String SetRoleInStory
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                RoleInStory = value;
            }
        }

        public String GetAge
        {
            get { return Age; }
        }

        public String SetAge
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Age = value;
            }
        }

        public String GetStoryDate
        {
            get { return StoryDate; }
        }

        public String SetStoryDate
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                StoryDate = value;
            }
        }

        public String GetDonationTransplant
        {
            get { return DonationTransplant; }
        }

        public String SetDonationTransplant
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                DonationTransplant = value;
            }
        }

        public String GetAuthorizationText
        {
            get { return AuthorizationText; }
        }

        public String SetAuthorizationText
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                AuthorizationText = value;
            }
        }

        public String GetIsAuthorized
        {
            get { return Authorized; }
        }

        public String SetIsAuthorized
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Authorized = value;
            }
        }

        public String GetIsSubmitted
        {
            get { return Submitted; }
        }

        public String SetIsSubmitted
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Submitted = value;
            }
        }

        public String GetConfirmationID
        {
            get { return ConfirmationID; }
        }

        public String SetConfirmationID
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                ConfirmationID = value;
            }
        }

        public String GetStoryStatus
        {
            get { return StoryState; }
        }

        public String SetStoryStatus
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                StoryState = value;
            }
        }

        public String GetHearth
        {
            get { return Hearth; }
        }

        public String SetHearth
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Hearth = value;
            }
        }

        public String GetLung
        {
            get { return Lung; }
        }

        public String SetLung
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Lung = value;
            }
        }

        public String GetLiver
        {
            get { return Liver; }
        }

        public String SetLiver
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Liver = value;
            }
        }

        public String GetKidney
        {
            get { return Kidney; }
        }

        public String SetKidney
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Kidney = value;
            }
        }

        public String GetPancreas
        {
            get { return Pancreas; }
        }

        public String SetPancreas
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Pancreas = value;
            }
        }

        public String GetIntestines
        {
            get { return Intestines; }
        }

        public String SetIntestines
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Intestines = value;
            }
        }

        public String GetCorneas 
        {
            get { return Corneas; }
        }

        public String SetCorneas
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Corneas = value;
            }
        }

        public String GetMiddleEar
        {
            get { return MiddleEar; }
        }

        public String SetMiddleEar
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                MiddleEar = value;
            }
        }

        public String GetBloodVessels
        {
            get { return BloodVessels; }
        }

        public String SetBloodVessels
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                BloodVessels = value;
            }
        }       

        public String GetBone
        {
            get { return Bone; }
        }

        public String SetBone
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Bone = value;
            }
        }

        public String GetSkin
        {
            get { return Skin; }
        }

        public String SetSkin
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Skin = value;
            }
        }

        public String GetOtherOrgan
        {
            get { return OtherOrgan; }
        }

        public String SetOtherOrgan
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                OtherOrgan = value;
            }
        }

        public String GetOrganDescription
        {
            get { return OrganDescription; }
        }

        public String SetOrganDescription
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                OrganDescription = value;
            }
        }        

        public String GetOrganizationDescription
        {
            get { return OrganizationDescription; }
        }

        public String SetOrganizationDescription
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                OrganizationDescription = value;
            }
        }

        public String GetEmail
        {
            get { return Email; }
        }

        public String SetEmail
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Email = value;
            }
        }

        public String GetIsPublic
        {
            get { return IsPublic; }
        }

        public String SetIsPublic
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                IsPublic = value;
            }
        }

        public String GetRelationship
        {
            get { return Relationship; }
        }

        public String SetRelationship
        {
            set
            {
                ObjectStatus = (int)StoryStatus.Modified;
                Relationship = value;
            }
        }
        
        public int GetStatus
        {
            get { return ObjectStatus; }
        }
        #endregion

        #region Constructors
        public BOCls_Story()
        {
            oDBStoryController = new DBCls_Stories();
            ID = "";
            
            ObjectStatus = (int)StoryStatus.New;
        }      

        public BOCls_Story(String StoryID)
        {
            oDBStoryController = new DBCls_Stories();
            GetStoryByID(StoryID);
            ObjectStatus = (int)StoryStatus.NotModified;
        }        

        public BOCls_Story(String[] ArrStory)
        {
            oDBStoryController = new DBCls_Stories();
            FillInStory(ArrStory);
            ObjectStatus = (int)StoryStatus.NotModified;
        }
        #endregion        

        #region SearchMethods
        public bool GetStoryByID(String StoryID)
        {
            try
            {
                oDBStoryController = new DBCls_Stories();
                String[,] ArrStory = oDBStoryController.SearchStory(StoryID);
                if (ArrStory != null)
                {
                    ID = ArrStory[0, (int)StoryCriteria.cID];
                    SubmitterFirstName = ArrStory[0, (int)StoryCriteria.cSUBMITTERFIRSTNAME];
                    PhotoID = ArrStory[0, (int)StoryCriteria.cPHOTOID];
                    StoryTitle = ArrStory[0, (int)StoryCriteria.cSTORYTITLE];
                    StoryPlot = ArrStory[0, (int)StoryCriteria.cSTORYPLOT];
                    RoleInStory = ArrStory[0, (int)StoryCriteria.cROLEINSTORY];
                    Age = ArrStory[0, (int)StoryCriteria.cAGE];
                    StoryDate = ArrStory[0, (int)StoryCriteria.cSTORYDATE];
                    DonationTransplant = ArrStory[0, (int)StoryCriteria.cDONATIONTRANSPLANT];
                    AuthorizationText = ArrStory[0, (int)StoryCriteria.cAUTHORIZATIONTEXT];
                    Authorized = ArrStory[0, (int)StoryCriteria.cAUTHORIZED];
                    Submitted = ArrStory[0, (int)StoryCriteria.cSUBMITTED];
                    ConfirmationID = ArrStory[0, (int)StoryCriteria.cCONFIRMATIONID];
                    StoryState = ArrStory[0, (int)StoryCriteria.cSTORYSTATUS];
                    Hearth = ArrStory[0, (int)StoryCriteria.cHEARTH];
                    Lung = ArrStory[0, (int)StoryCriteria.cLUNG];
                    Liver = ArrStory[0, (int)StoryCriteria.cLIVER];
                    Kidney = ArrStory[0, (int)StoryCriteria.cKIDNEY];
                    Pancreas = ArrStory[0, (int)StoryCriteria.cPANCREAS];
                    Intestines = ArrStory[0, (int)StoryCriteria.cINTESTINES];
                    Corneas = ArrStory[0, (int)StoryCriteria.cCORNEAS];
                    MiddleEar = ArrStory[0, (int)StoryCriteria.cMIDDLEEAR];
                    BloodVessels = ArrStory[0, (int)StoryCriteria.cBLOODVESSELS];                    
                    Bone = ArrStory[0, (int)StoryCriteria.cBONE];
                    Skin = ArrStory[0, (int)StoryCriteria.cSKIN];
                    OtherOrgan = ArrStory[0, (int)StoryCriteria.cOTHERORGAN];
                    OrganDescription = ArrStory[0, (int)StoryCriteria.cORGANDESCRIPTION];
                    OrganizationDescription = ArrStory[0, (int)StoryCriteria.cORGANIZATIONDESCRIPTION];
                    Email = ArrStory[0, (int)StoryCriteria.cEMAIL];
                    IsPublic = ArrStory[0, (int)StoryCriteria.cISPUBLIC];
                    Relationship = ArrStory[0, (int)StoryCriteria.cRELATIONSHIP];                    
                }
                oDBStoryController = null;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region StoryManipulation
        public bool LoadStoryFromXML(String pXML)
        {
            try
            {
                oDBStoryController = new DBCls_Stories();
                FillStoryWithXML(pXML);
                ObjectStatus = (int)StoryStatus.NotModified;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool SaveStory()
        {
            try
            {
                String[] ArrStory = FillInArrayWithProperties();
                if (ID.Trim() == "")
                {
                    ObjectStatus = (int)StoryStatus.New;
                }

                switch (ObjectStatus)
                {
                    case (int)StoryStatus.New: ID = Convert.ToString(oDBStoryController.InsertStory(ArrStory));
                        break;
                    case (int)StoryStatus.Modified: oDBStoryController.UpdateStory(ArrStory);
                        break;
                    case (int)StoryStatus.MarkedForDeletion: oDBStoryController.EliminateStory(StoryCriteria.cID, ID);
                        break;
                }
                ObjectStatus = (int)StoryStatus.NotModified;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected bool DeleteStory()
        {
            try
            {
                ObjectStatus = (int)StoryStatus.MarkedForDeletion;
                SaveStory();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Fill_IN_OUT_PROPERTIES
        private String[] FillInArrayWithProperties()
        {
            String[] mArrProperties = new String[(int)TotalStoryCriteria.cTotal];
            mArrProperties[(int)StoryCriteria.cID] = ID;
            mArrProperties[(int)StoryCriteria.cSUBMITTERFIRSTNAME] = SubmitterFirstName;
            mArrProperties[(int)StoryCriteria.cPHOTOID] = PhotoID;
            mArrProperties[(int)StoryCriteria.cSTORYTITLE] = StoryTitle;
            mArrProperties[(int)StoryCriteria.cSTORYPLOT] = StoryPlot;
            mArrProperties[(int)StoryCriteria.cROLEINSTORY] = RoleInStory;
            mArrProperties[(int)StoryCriteria.cAGE] = Age;
            mArrProperties[(int)StoryCriteria.cSTORYDATE] = StoryDate;
            mArrProperties[(int)StoryCriteria.cDONATIONTRANSPLANT] = DonationTransplant;
            mArrProperties[(int)StoryCriteria.cAUTHORIZATIONTEXT] = AuthorizationText;
            mArrProperties[(int)StoryCriteria.cAUTHORIZED] = Authorized;
            mArrProperties[(int)StoryCriteria.cSUBMITTED] = Submitted;
            mArrProperties[(int)StoryCriteria.cCONFIRMATIONID] = ConfirmationID;
            mArrProperties[(int)StoryCriteria.cSTORYSTATUS] = StoryState;
            mArrProperties[(int)StoryCriteria.cHEARTH] = Hearth;
            mArrProperties[(int)StoryCriteria.cLUNG] = Lung;
            mArrProperties[(int)StoryCriteria.cLIVER] = Liver;
            mArrProperties[(int)StoryCriteria.cKIDNEY] = Kidney;
            mArrProperties[(int)StoryCriteria.cPANCREAS] = Pancreas;
            mArrProperties[(int)StoryCriteria.cINTESTINES] = Intestines;
            mArrProperties[(int)StoryCriteria.cCORNEAS] = Corneas;
            mArrProperties[(int)StoryCriteria.cMIDDLEEAR] = MiddleEar;
            mArrProperties[(int)StoryCriteria.cBLOODVESSELS] = BloodVessels;            
            mArrProperties[(int)StoryCriteria.cBONE] = Bone;
            mArrProperties[(int)StoryCriteria.cSKIN] = Skin;
            mArrProperties[(int)StoryCriteria.cOTHERORGAN] = OtherOrgan;
            mArrProperties[(int)StoryCriteria.cORGANDESCRIPTION] = OrganDescription;
            mArrProperties[(int)StoryCriteria.cORGANIZATIONDESCRIPTION] = OrganizationDescription;
            mArrProperties[(int)StoryCriteria.cEMAIL] = Email;
            mArrProperties[(int)StoryCriteria.cISPUBLIC] = IsPublic;
            mArrProperties[(int)StoryCriteria.cRELATIONSHIP] = Relationship;
            return mArrProperties;
        }

        private void FillStoryWithXML(String pXML)
        {
            //String x = "";
            BOCls_XMLReader oXMLReader = new BOCls_XMLReader(pXML);
            oXMLReader.LookForParents("Story");
            this.SetSubmitterFirstName = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("FirstName"));
            this.SetEmail = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("Email"));
            this.SetRelationship = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("Relationship"));
            this.StoryTitle =  oDBStoryController.EscapeValue(oXMLReader.LookForChildren("StoryTitle"));
            this.RoleInStory = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("Role"));
            this.Age = oXMLReader.LookForChildren("Age");
            this.Hearth = oXMLReader.LookForChildren("Hearth");
            this.Lung = oXMLReader.LookForChildren("Lung");
            this.Liver = oXMLReader.LookForChildren("Liver");
            this.Kidney = oXMLReader.LookForChildren("Kidney");
            this.Pancreas = oXMLReader.LookForChildren("Pancreas");
            this.Intestines = oXMLReader.LookForChildren("Intestines");
            this.Corneas = oXMLReader.LookForChildren("Corneas");
            this.MiddleEar = oXMLReader.LookForChildren("MiddleEar");
            this.BloodVessels = oXMLReader.LookForChildren("BloodVessels");
            this.Bone = oXMLReader.LookForChildren("Bone");
            this.Skin = oXMLReader.LookForChildren("Skin");
            this.OtherOrgan = oXMLReader.LookForChildren("OtherOrgan");
            this.OrganDescription = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("OrganDescription"));
            this.StoryDate = oXMLReader.LookForChildren("Date");
            this.OrganizationDescription = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("Organization"));
            this.StoryPlot = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("StoryPlot"));
            this.AuthorizationText = oDBStoryController.EscapeValue(oXMLReader.LookForChildren("AuthorizationText"));
            this.Authorized = oXMLReader.LookForChildren("Authorized");
            this.Submitted = oXMLReader.LookForChildren("Submitted");
            this.PhotoID = "0";
            this.IsPublic = "1";
        }

        private void FillInStory(String[] pStory)
        {
            ID = pStory[(int)StoryCriteria.cID];
            SubmitterFirstName = pStory[(int)StoryCriteria.cSUBMITTERFIRSTNAME];
            PhotoID = pStory[(int)StoryCriteria.cPHOTOID];
            StoryTitle = pStory[(int)StoryCriteria.cSTORYTITLE];
            StoryPlot = pStory[(int)StoryCriteria.cSTORYPLOT];
            RoleInStory = pStory[(int)StoryCriteria.cROLEINSTORY];
            Age = pStory[(int)StoryCriteria.cAGE];
            StoryDate = pStory[(int)StoryCriteria.cSTORYDATE];
            DonationTransplant = pStory[(int)StoryCriteria.cDONATIONTRANSPLANT];
            AuthorizationText = pStory[(int)StoryCriteria.cAUTHORIZATIONTEXT];
            Authorized = pStory[(int)StoryCriteria.cAUTHORIZED];
            Submitted = pStory[(int)StoryCriteria.cSUBMITTED];
            ConfirmationID = pStory[(int)StoryCriteria.cCONFIRMATIONID];
            StoryState = pStory[(int)StoryCriteria.cSTORYSTATUS];
            Hearth = pStory[(int)StoryCriteria.cHEARTH];
            Lung = pStory[(int)StoryCriteria.cLUNG];
            Liver = pStory[(int)StoryCriteria.cLIVER];
            Kidney = pStory[(int)StoryCriteria.cKIDNEY];
            Pancreas = pStory[(int)StoryCriteria.cPANCREAS];
            Intestines = pStory[(int)StoryCriteria.cINTESTINES];
            Corneas = pStory[(int)StoryCriteria.cCORNEAS];
            MiddleEar = pStory[(int)StoryCriteria.cMIDDLEEAR];
            BloodVessels = pStory[(int)StoryCriteria.cBLOODVESSELS];            
            Bone = pStory[(int)StoryCriteria.cBONE];
            Skin = pStory[(int)StoryCriteria.cSKIN];
            OtherOrgan = pStory[(int)StoryCriteria.cOTHERORGAN];
            OrganDescription = pStory[(int)StoryCriteria.cORGANDESCRIPTION];            
            OrganizationDescription = pStory[(int)StoryCriteria.cORGANIZATIONDESCRIPTION];
            Email = pStory[(int)StoryCriteria.cEMAIL];
            IsPublic = pStory[(int)StoryCriteria.cISPUBLIC];
            Relationship = pStory[(int)StoryCriteria.cRELATIONSHIP];
        }
        #endregion
    }
}