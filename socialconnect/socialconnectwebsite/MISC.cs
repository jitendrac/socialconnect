using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MISC
{
    /// <summary>
    /// This Function verfies the string against contains numbers only constraint
    /// </summary>
    /// <param name="chkString"></param>
    /// <returns>Returns true if string contains numbers only otherwise false</returns>
    public static Boolean checkNumberOnly(string chkString)//++JitendraShah 
    {
        char[] charArray = chkString.Trim().ToCharArray();
        for (int i = 0; i < chkString.Length; i++)
        {
            if (!(charArray[i] <= '9' && charArray[i] >= '0'))
            {
                return false;
            }

        }

        return true;
    }
    
    /// <summary>
    /// This Function verfies the string against contains characters only constraint
    /// </summary>
    /// <param name="chkString"></param>
    /// <returns>Returns true if string contains characters only otherwise false</returns>
    public static Boolean checkCharacterOnly(string chkString)//
    {
        char[] charArray = chkString.Trim().ToCharArray();
        for (int i = 0; i < chkString.Length; i++)
        {
            if (!((charArray[i] >= 'a' && charArray[i] <= 'z') || (charArray[i] >= 'A' && charArray[i] <= 'Z')))
            {
                return false;
            }

        }

        return true;
    }


}
