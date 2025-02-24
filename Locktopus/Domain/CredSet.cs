using System;
using System.Collections.Generic;

namespace Locktopus.Domain;

public class CredSet : ICredSet<string>
{
    #region Private Attributes
    private string _id;
    private string _pwd; 
    private DateTime _exp;
    private string? _usr;
    private string? _email;
    private string? _freeTxt;
    private List<string>? _labels;
    #endregion

    #region Constants
    // expiration time expressed in months
    private const ushort EXP_TIME = 3;
    #endregion

    #region Constructors
    public CredSet(string id, string pwd, DateTime exp, string? usr = null, string? email = null, string? freeTxt = null, List<string>? labels = null)
    {
        this._id = id;
        this._pwd = pwd;
        this._exp = exp;
        this._usr = usr;
        this._email = email;
        this._freeTxt = freeTxt;
        this._labels = labels;
    }

    public CredSet(ICredSet<string> cs)
    {
        this._id = cs.Id;
        this._pwd = cs.Pwd;
        this._exp = cs.Exp;
        this._usr = cs.Usr;
        this._email = cs.Email;
        this._freeTxt = cs.FreeTxt;
        this._labels = cs.Labels;
    }
    #endregion


    #region Getters and Setters
    public string Id 
    { 
        get => this._id;
        set => this._id = value; 
    }
    public string Pwd 
    { 
        get => this._pwd; 
        // setting new expiration date each time a new password is set
        set {
                this._pwd = value;
                this._exp = DateTime.Today;
                this._exp = this._exp.AddMonths(EXP_TIME);
            }
    }
    public DateTime Exp 
    { 
        get => this._exp; 
        set => this._exp = value; 
    }
    public string? Usr 
    { 
        get => this._usr; 
        set => this._usr = value; 
    }
    public string? Email 
    { 
        get => this._email; 
        set => this._email = value; 
    }
    public string? FreeTxt 
    { 
        get => this._freeTxt; 
        set => this._freeTxt = value; 
    }
    public List<string>? Labels 
    { 
        get => this._labels; 
        set => this._labels = value; 
    }
    #endregion 
}
