
namespace Modrinth.Models.Errors;

/// <summary>
///     An error response returned by the API
/// </summary>
public class ResponseError
{
    /// <summary>
    ///     The name of the error
    /// </summary>
    public string Error { get; set; } = null!;

    /// <summary>
    ///     The contents of the error
    /// </summary>
    public string Description { get; set; } = null!;
    /// <summary>
    ///     idk
    /// </summary>
    public static implicit operator ResponseError(string v)
    {
        throw new NotImplementedException();
    }
}