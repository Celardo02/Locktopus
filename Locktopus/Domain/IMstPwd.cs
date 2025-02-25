using System;

namespace Locktopus.Domain;

/// <summary>
/// Master password class interface
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
