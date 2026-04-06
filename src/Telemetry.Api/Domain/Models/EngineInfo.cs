using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Telemetry.Api.JsonConverters;

namespace Telemetry.Api.Domain.Models
{
    /// <summary>
    ///     Script engine information.
    /// </summary>
    public class EngineInfo
    {
        /// <summary>
        ///     Engine type name.
        ///     <br /><a href="https://pyrevitlabs.notion.site/Engines-7973ca3328c34fd1a95462f5c655475b">Engine types</a>.
        /// </summary>
        [MaxLength(100)]
        public required string Type { get; init; }

        /// <summary>
        ///     Engine version.
        ///     <br /> <a href="https://pyrevitlabs.notion.site/Engines-7973ca3328c34fd1a95462f5c655475b">Engines list</a>.
        /// </summary>
        [MaxLength(100)]
        public required string Version { get; init; }

        /// <summary>
        ///     System paths using by script.
        /// </summary>
        public string[]? SysPaths { get; init; }

        /// <summary>
        ///     Dynamic script configs data.
        /// </summary>
        [MaxLength(8000)]
        public string? Configs { get; init; }
    }
}