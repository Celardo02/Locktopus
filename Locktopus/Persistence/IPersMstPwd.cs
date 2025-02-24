using System;
using System.Collections.Generic;
using Locktopus.Domain;

namespace Locktopus.Persistence;

public interface IPersMstPwd : IPersRAM
{
    /// <summary>
    /// Checks whether a provided string matches the stored master password hash
    /// </summary>
    /// <param name="pwd">The password to compare against the master password hash</param>
    /// <returns>Returns <c>true</c> if the password matches the master password hash; otherwise, <c>false</c></returns>
    bool CheckPwd(string pwd);

    /// <summary>
    /// Checks whether the master password is expired or not
    /// </summary>
    /// <returns>Returns <c>true</c> it the master password is expired; otherwise, <c>false</c></returns>
    bool IsMasterPwdExp();

    /// <summary>
    /// Sets new master password
    /// </summary>
    /// <param name="oldPwd">Current master password</param>
    /// <param name="newPwd">New master password</param>
    /// <remarks>New master password must differ from previous master passwords</remarks>
    void SetNewPwd(string oldPwd, string newPwd);

    /// <summary>
    /// Current master password object
    /// </summary>
    IMstPwd MasterPwd {get; set;}

    /// <summary>
    /// List with old master paswords
    /// </summary>
    List<string>? OldMstPwd {get; set;}
}
