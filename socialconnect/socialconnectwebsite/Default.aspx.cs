using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialConnectWCFServiceRef;
using System.Data;
using System.Data.Common;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SocialConnectWCFClient s1 = new SocialConnectWCFClient();
        DataSet ds = s1.GetWallStoryByUserId(1);

        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
        storyListContainer.InnerHtml = StoryManager.CreateWallPost(ds.Tables[0]);
        s1.Close();
    }
}
