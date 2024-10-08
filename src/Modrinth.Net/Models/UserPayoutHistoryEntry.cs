﻿namespace Modrinth.Models;

/// <summary>
///     Represents a payout history entry
/// </summary>
public class UserPayoutHistoryEntry
{
    /// <summary>
    ///     The date of this transaction
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    ///     The amount of this transaction in USD
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    ///     The status of this transaction
    /// </summary>
    public string Status { get; set; } = null!;
}