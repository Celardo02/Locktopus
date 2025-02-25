using System;
using System.Collections.Generic;

namespace Locktopus.Domain;

/// <summary>
/// Credential set class interface
/// </summary>
/// <typeparam name="ID">Type of the field <c>Id</c></typeparam>
public interface ICredSet<ID>
{
    /// <summary>
    /// Unique and user defined Id
    /// </summary>
    ID Id {get; set;}

    /// <summary>
    /// Password 
    /// </summary>
    string Pwd {get; set;}

    /// <summary>
    /// Password expiration date
    /// </summary>
    DateOnly Exp {get; set;}

    /// <summary>
    /// Username
    /// </summary>
    string? Usr {get; set;}

    string? Email {get; set;}

    /// <summary>
    /// Free text. Useful to store general pieces of information
    /// </summary>
    string? FreeTxt {get; set;}

    List<string>? Labels {get; set;}
}
