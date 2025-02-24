using System;

namespace Locktopus.Domain;

/// <summary>
/// Interfaces that represents a master password class
/// </summary>
public interface IMstPwd
{
    /// <summary>
    /// Base64-encoded master password hash
    /// </summary>
    string Hash {get; set;}
    /// <summary>
    /// Base64-encoded salt for <c>Hash</c> field computation
    /// </summary>
    string Salt {get; set;}
    /// <summary>
    /// Expiration date
    /// </summary>
    DateOnly Exp {get; set;}
}
