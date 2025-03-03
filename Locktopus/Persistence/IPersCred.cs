using System;
using System.Collections.Generic;
using Locktopus.Domain;

namespace Locktopus.Persistence;

/// <summary>
/// Credential sets persistence interface
/// </summary>
/// <typeparam name="ID">Type of credetial set Id</typeparam>
public interface IPersCred<ID> : IDisposable
{
    /// <summary>
    /// Creates a credential set instance
    /// </summary>
    /// <param name="mstPwd">Master password</param>
    /// <param name="id">Credential set unique id</param>
    /// <param name="pwd">Credential set password</param>
    /// <param name="usr">Credential set username</param>
    /// <param name="email">Credential set e-mail</param>
    /// <param name="freeTxt">credential set free text field</param>
    /// <param name="lbls">Credential set labels</param>
    void Create(string mstPwd, ID id, string pwd, string? usr, string? email, string? freeTxt, List<string>? lbls);
    
    /// <summary>
    /// Searches for a credential set with the specified Id
    /// </summary>
    /// <param name="id">Id to search for</param>
    /// <returns>Returns a credential set with the given Id, if exists</returns>
    ICredSet<ID> Read(ID id);
    
    /// <summary>
    /// Searches for any credential set that contains a specified string within its Id, Username or E-mail fields
    /// </summary>
    /// <param name="src">String to search for</param>
    /// <returns>Returns a list of credential sets that match the search criteria, if they exist</returns>
    List<ICredSet<ID>> Read(string src);

    /// <summary>
    /// Updates the content of a credential set, given its Id
    /// </summary>
    /// <param name="mstPwd">Master password</param>
    /// <param name="id">Id of the credential set to update</param>
    /// <param name="pwd">Credential set password</param>
    /// <param name="usr">Credential set username</param>
    /// <param name="email">Credential set e-mail</param>
    /// <param name="freeTxt">credential set free text field</param>
    /// <param name="lbls">Credential set labels</param>
    void Update(string mstPwd, ID id, string pwd, string? usr, string? email, string? freeTxt, List<string>? lbls);

    /// <summary>
    /// Deletes a credential set, given its Id
    /// </summary>
    /// <param name="mstPwd">Master password</param>
    /// <param name="id">Id of the credential set to delete</param>
    void Delete(string mstPwd, ID id);

    /// <summary>
    /// Retrieves all stored credential sets
    /// </summary>
    /// <returns>Returns a list of all stored credential sets</returns>
    List<ICredSet<ID>> ListAll();

    /// <summary>
    /// Imports a list of credential sets and replaces the existing stored data
    /// </summary>
    /// <param name="lc">List of credential sets to be imported</param>
    /// <remarks>
    /// The imported list will overwrite the currently persisted data.
    /// </remarks>
    void LoadCreds(List<ICredSet<ID>> lc);

    /// <summary>
    /// Searches for any expired credential set
    /// </summary>
    /// <returns>Returns a list of expired credential sets, if they exist</returns>
    List<ICredSet<ID>> CheckExpired();

    /// <summary>
    /// Searches for any non-expiring credential set
    /// </summary>
    /// <returns>Returns a list of non-expiring credential sets, if they exist</returns>
    List<ICredSet<ID>> CheckNonExpiring();

}
