using System;

namespace Locktopus.Persistence;

/// <summary>
/// RAM persistence layer interface
/// </summary>
public interface IPersRAM
{
    /// <summary>
    /// Removes all data stored in the persistence class
    /// </summary>
    void Clear();
}
