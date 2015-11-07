using System;
using System.Collections.Generic;
using BOBusinessObjects;

namespace DFControllers
{
    public class DFCls_StoryForm
    {
        BOCls_Story oStory;

        public DFCls_StoryForm(){
            
        }

        public DFCls_StoryForm(String pXML)
        {
            oStory = new BOCls_Story();
            oStory.LoadStoryFromXML(pXML);
            oStory.SaveStory();
        }
        
    }
}