using System;

namespace Locktopus.Domain;

public class MstPwd : IMstPwd
{
    #region Private Attributes
    private string _hash;
    private string _salt;
    private DateOnly _exp;
    #endregion

    #region Constants
    // expiration time expressed in months
    private const ushort EXP_TIME = 3; 
    #endregion

    #region Constructors
    public MstPwd(string hash, string salt, DateOnly exp)
    {
        this._hash = hash;
        this._salt = salt;
        this._exp = exp;
    }

    public MstPwd(IMstPwd msp)
    {
        this._hash = msp.Hash;
        this._salt = msp.Salt;
        this._exp = msp.Exp;
    }
    #endregion

    #region Getters and Setters
    public string Hash 
    { 
        get => _hash; 
        // setting new expiration date each time a new master password hash is set
        set
        {
            this._hash = value;
            this._exp = DateOnly.FromDateTime(DateTime.Today);
            this._exp = this._exp.AddMonths(EXP_TIME);
        } 
    }
    public string Salt 
    { 
        get => _salt; 
        set => _salt = value; 
    }
    public DateOnly Exp 
    { 
        get => _exp; 
        set => _exp = value; 
    }
    #endregion
}
