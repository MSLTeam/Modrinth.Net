﻿using Newtonsoft.Json;
using Modrinth.Models.Enums;

#pragma warning disable CS8618
namespace Modrinth.Models;

/// <summary>
///     The data for a user's payout
/// </summary>
public class PayoutData
{
    /// <summary>
    ///     The payout balance available for the user to withdraw (note, you cannot modify this in a PATCH request)
    /// </summary>
    public double Balance { get; set; }

    /// <summary>
    ///     The wallet that the user has selected
    /// </summary>
    [JsonProperty("payout_wallet")]
    public PayoutWallet PayoutWallet { get; set; }

    /// <summary>
    ///     The type of the user's wallet
    /// </summary>
    [JsonProperty("payout_wallet_type")]
    public PayoutWalletType PayoutWalletType { get; set; }

    /// <summary>
    ///     The user's payout address
    /// </summary>
    [JsonProperty("payout_address")]
    public string PayoutAddress { get; set; }
}