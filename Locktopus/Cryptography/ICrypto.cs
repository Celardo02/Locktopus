using System;
using System.Collections.Generic;

namespace Locktopus.Cryptography;

/// <summary>
/// Cryptographyc module interface
/// </summary>
public interface ICrypto : IDisposable
{

    /// <summary>
    /// Generates a random number in a specified range (inclusive)
    /// </summary>
    /// <param name="min">Minimum value of the range</param>
    /// <param name="max">Maximum value of the range</param>
    /// <returns>Returns a random number in a specified range</returns>
    int Rng(int min, int max);

    /// <summary>
    /// Computes the hash of the input string using a randomly generated salt
    /// </summary>
    /// <param name="str">
    /// Input string whose hash is to be computed
    /// </param>
    /// <param name="hashLen">
    /// Desired length of the resulting hash in bytes
    /// </param>
    /// <returns>
    /// Returns a tuple containing:
    /// <list type="bullet">
    /// <item><description>Item1: base64-encoded hash string</description></item>
    /// <item><description>Item2: base64-encoded salt value used</description></item>
    /// </list>
    /// </returns>
    Tuple<string, string> ComputeHash(string str, int hashLen);

    /// <summary>
    /// Compares the hash of an input string with a precomputed hash to determine whether they are equal or not
    /// </summary>
    /// <param name="str">Input string whose hash is to be computed and compared</param>
    /// <param name="hash">Precomputed hash to compare against</param>
    /// <param name="salt">Salt used to compute <c>hash</c></param>
    /// <returns>Returns <c>true</c> if <c>str</c> hash matches <c>hash</c>; otherwise, false</returns>
    bool CheckHash(string str, string hash, string salt);

    /// <summary>
    /// Encrypts a given plaintext using AES
    /// </summary>
    /// <param name="plain">Plaintext to encrypt</param>
    /// <param name="key">AES encryption key</param>
    /// <param name="aad">Base64-encoded AES additional authenticated data</param>
    /// <returns>
    /// Returns a struct containing:
    /// <list type="bullet">
    /// <item><description>computed cyphertext</description></item>
    /// <item><description>base64-encoded salt used by a key derivation algorithm</description></item>
    /// <item><description>base64-encoded AES initialization vector</description></item>
    /// <item><description>base64-encoded AES tag</description></item>
    /// </list>
    /// </returns>
    AESres AESencrypt(string plain, string key, string? aad);

    /// <summary>
    /// Decrypts a given cyphertext using AES
    /// </summary>
    /// <param name="cyph">Cyphertext to decrypt</param>
    /// <param name="key">AES encryption key</param>
    /// <param name="keySalt">Base64-encoded salt used by a key derivation algorithm during encryption process</param>
    /// <param name="iv">Base64-encoded AES initialization vector used during encryption process</param>
    /// <param name="tag">Base64-encoded AES tag produce by the encryption process</param>
    /// <param name="aad">Base64-encoded AES additional authenticated data used during encryption process</param>
    /// <returns>Returns the decryted content of <c>cyph</c></returns>
    string AESdecrypt(string cyph, string key, string keySalt, string iv, string tag, string? aad);

    /// <summary>
    /// Encrypts a given plaintext using a given RSA key
    /// </summary>
    /// <param name="plain">Plaintext to encrypt</param>
    /// <param name="mod">RSA modulus</param>
    /// <param name="exp">RSA exponent</param>
    /// <returns>Returns a string containing the computed cyphertext</returns>
    string RSAencrypt(string plain, string mod, string exp);

    /// <summary>
    /// Decrypts a given cyphertext using user RSA private key
    /// </summary>
    /// <param name="cyph">Cyphertext to decrypt</param>
    /// <returns>Returns the decyphered content of <c>cyph</c></returns>
    string RSAdecrypt(string cyph);

    /// <summary>
    /// Dictionary containing all previously used AES GCM IVs for each encryption key. 
    /// The dictionary key is the hash of the encryption key, while the value is a 
    /// HashSet of IVs that have been used with that specific key. Both dictionary key 
    /// and each IV are stored as base64-encoded strings
    /// </summary>
    Dictionary<string, HashSet<string>> OldIVs {get; set;}

    /// <summary>
    /// List with all previosly used KDFsalts, stored as base64-encoded strings
    /// </summary>
    List<string> OldSalts {get; set;}
}

/// <summary>
/// Struct that contains AES encryption results
/// </summary>
public readonly struct AESres 
{

    public AESres(string cyph, string keySalt, string iv, string tag)
    {
        this.cyph = cyph;
        this.keySalt = keySalt;
        this.iv = iv; 
        this.tag = tag;
    }

    /// <summary>
    /// Cyphertext
    /// </summary>
    readonly string cyph;

    /// <summary>
    /// Base64-encoded salt used by a key derivation algorithm
    /// </summary>
    readonly string keySalt;

    /// <summary>
    /// AES initialization vector
    /// </summary>
    readonly string iv;

    /// <summary>
    /// AES tag
    /// </summary>
    readonly string tag;
}
