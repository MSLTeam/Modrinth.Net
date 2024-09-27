#pragma warning disable CS8618
using Newtonsoft.Json;
using Modrinth.Models.Enums.Project;
using Modrinth.Models.Enums.Version;

namespace Modrinth.Models;

/// <summary>
///     A version of a project
/// </summary>
public class Version
{
    /// <summary>
    ///     The name of this version
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     The version number. Ideally will follow semantic versioning
    /// </summary>
    [JsonProperty   ("version_number")]
    public string VersionNumber { get; set; }

    /// <summary>
    ///     The changelog for this version
    /// </summary>
    public string? Changelog { get; set; }

    /// <summary>
    ///     A list of specific versions of projects that this version depends on
    /// </summary>
    public Dependency[]? Dependencies { get; set; }

    /// <summary>
    ///     A list of versions of Minecraft that this version supports
    /// </summary>
    [JsonProperty("game_versions")]
    public string[] GameVersions { get; set; }

    /// <summary>
    ///     The release channel for this version
    /// </summary>
    [JsonProperty("version_type")]
    public ProjectVersionType ProjectVersionType { get; set; }

    /// <summary>
    ///     The mod loaders that this version supports
    /// </summary>
    public string[] Loaders { get; set; }

    /// <summary>
    ///     Whether the version is featured or not
    /// </summary>
    public bool Featured { get; set; }

    /// <summary>
    ///     The ID of the version, encoded as a base62 string
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     The ID of the project this version is for
    /// </summary>
    [JsonProperty("project_id")]
    public string ProjectId { get; set; }

    /// <summary>
    ///     The ID of the author who published this version
    /// </summary>
    [JsonProperty("author_id")]
    public string AuthorId { get; set; }

    /// <summary>
    ///     The time at which this version was created
    /// </summary>
    [JsonProperty("date_published")]
    public DateTime DatePublished { get; set; }

    /// <summary>
    ///     The number of times this version has been downloaded
    /// </summary>
    public int Downloads { get; set; }

    /// <summary>
    ///     A list of files available for download for this version
    /// </summary>
    public File[] Files { get; set; }

    /// <summary>
    ///     The current status of this version
    /// </summary>
    public VersionStatus Status { get; set; }

    /// <summary>
    ///     The requested status of this version, used when scheduling a version
    /// </summary>
    [JsonProperty("requested_status")]
    public VersionRequestedStatus? RequestedStatus { get; set; }
}