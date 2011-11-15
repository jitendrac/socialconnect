using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
/// <summary>
/// Summary description for StoryManager
/// </summary>
public class StoryManager
{
    private const string strUserProfileLink = "profile.aspx";
    private const string strGroupProfileLink = "group.aspx";
    public StoryManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string CreateWallPost(DataTable StoryTable)
    {
        string result="";
        foreach (DataRow dr in StoryTable.Rows)
        { 
            string story = "";
            string strPostOwner="";
            if (dr["PostTypeName"].Equals("user"))
            {
                strPostOwner = strUserProfileLink;
            }
            else if (dr["PostTypeName"].ToString().Equals("group"))
            {
                strPostOwner = strGroupProfileLink;
            }
            string strPostOwnerName = dr["CreatorName"].ToString();
            string strPostOwnerId = dr["CreatorName"].ToString();
            string strStoryContent = dr["Contents"].ToString();
           
            story += "<div class=\"story_wrapper\" >"+"<a href=\""+strPostOwner+"?id="+strPostOwnerId+"\" ><img src=\"\" class=\"actorPhoto\" alt=\"\" /> </a>";
            story += "<div class=\"story_container\">" + "<div class=\"actorName\"><a href =\"" + strPostOwner + "?id=" + strPostOwnerId + "\" >"+strPostOwnerName +"</a></div>";
            story += "<span class=\"messageBody\" >"+strStoryContent+"</span>";
            story += "</div></div>";
            result += story;
        }
        return result;
    }
}
