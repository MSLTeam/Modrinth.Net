using Newtonsoft.Json;

namespace Modrinth.Models.Enums;

/// <summary>
///     The type of a notification
/// </summary>
public enum NotificationType
{
    /// <summary>
    ///     The project was updates
    /// </summary>
    [JsonProperty("project_update")] ProjectUpdate,

    /// <summary>
    ///     A team invite received
    /// </summary>
    [JsonProperty("team_invite")] TeamInvite,

    /// <summary>
    ///     Project status update
    /// </summary>
    [JsonProperty("status_change")] StatusChange,

    /// <summary>
    ///     Moderator message
    /// </summary>
    [JsonProperty("moderator_message")]
    ModeratorMessage
}