using System.Net.Http.Headers;

namespace MovieCollection.SubSource;

/// <summary>
/// The <see cref="SubSourceOptions"/> class.
/// </summary>
public class SubSourceOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SubSourceOptions"/> class.
    /// </summary>
    public SubSourceOptions()
    {
        ApiAddress = "https://api.subsource.net";
        ApiKey = string.Empty;
    }

    /// <summary>
    /// Gets or sets the api address.
    /// </summary>
    public string ApiAddress { get; set; }

    /// <summary>
    /// Gets or sets the api key.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the name (and version) of the product using this library.
    /// </summary>
    public ProductHeaderValue? ProductInformation { get; set; }
}
