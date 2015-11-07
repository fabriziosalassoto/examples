using System;
using System.Collections.Generic;
using DBControllers;

namespace BOBusinessObjects
{
    public class BOCls_Stories : List<BOCls_Story>
    {
        #region PrivateProperties
        private DBCls_Stories oDBStoryController;
        #endregion

        #region Constructors
        public BOCls_Stories()
        {
            oDBStoryController = new DBCls_Stories();
        }

        public BOCls_Stories(String[,] pArrStories)
        {
            oDBStoryController = new DBCls_Stories();
            FillList(pArrStories);

        }
        #endregion

        #region SearchMethods
        public bool GetStories()
        {
            String[,] mArrStories = oDBStoryController.ListStories();
            FillList(mArrStories);
            return true;
        }

        public bool GetStoriesByCriteria(StoryCriteria pCriteriaKey, String pCriteriaValue)
        {
            String[,] mArrStories = oDBStoryController.ListStoriesByCriteria(pCriteriaKey, pCriteriaValue);
            FillList(mArrStories);
            return true;
        }
        #endregion

        #region ManipulationMethods
        public bool SaveAllRoles()
        {
            foreach (BOCls_Story oStory in this)
            {
                oStory.SaveStory();
            }
            return true;
        }
        #endregion

        #region PrivateMethods
        private void FillList(String[,] pArrStories)
        {
            String[] mArrStory = null;
            for (int x = 0; x < pArrStories.GetLength(0); x++)
            {
                mArrStory = new String[(int)TotalStoryCriteria.cTotal];
                for (int y = 0; y < pArrStories.GetLength(1); y++)
                {
                    mArrStory[y] = pArrStories[x, y];
                }
                BOCls_Story oStory = new BOCls_Story(mArrStory);
                this.Add(oStory);
            }
        }
        #endregion
    }
}