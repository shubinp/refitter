﻿using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Refitter.Core;

/// <summary>
/// Provide settings for Refit generator.
/// </summary>
[ExcludeFromCodeCoverage]
public class RefitGeneratorSettings
{
    /// <summary>
    /// Gets or sets the path to the Open API.
    /// </summary>
    [JsonPropertyName("openApiPath")]
    [JsonProperty("openApiPath")]
    public string OpenApiPath { get; set; } = null!;

    /// <summary>
    /// Gets or sets the namespace for the generated code. (default: GeneratedCode)
    /// </summary>
    [JsonPropertyName("namespace")]
    [JsonProperty("namespace")]
    public string Namespace { get; set; } = "GeneratedCode";

    /// <summary>
    /// Gets or sets the naming settings.
    /// </summary>
    [JsonPropertyName("naming")]
    [JsonProperty("naming")]
    public NamingSettings Naming { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether contracts should be generated.
    /// </summary>
    [JsonPropertyName("generateContracts")]
    [JsonProperty("generateContracts")]
    public bool GenerateContracts { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether XML doc comments should be generated.
    /// </summary>
    [JsonPropertyName("generateXmlDocCodeComments")]
    [JsonProperty("generateXmlDocCodeComments")]
    public bool GenerateXmlDocCodeComments { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add auto-generated header.
    /// </summary>
    [JsonPropertyName("addAutoGeneratedHeader")]
    [JsonProperty("addAutoGeneratedHeader")]
    public bool AddAutoGeneratedHeader { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to return <c>IApiResponse</c> objects.
    /// </summary>
    [JsonPropertyName("returnIApiResponse")]
    [JsonProperty("returnIApiResponse")]
    public bool ReturnIApiResponse { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to generate operation headers.
    /// </summary>
    [JsonPropertyName("generateOperationHeaders")]
    [JsonProperty("generateOperationHeaders")]
    public bool GenerateOperationHeaders { get; set; } = true;

    /// <summary>
    /// Gets or sets the generated type accessibility. (default: Public)
    /// </summary>
    [JsonPropertyName("typeAccessibility")]
    [JsonProperty("typeAccessibility")]
    public TypeAccessibility TypeAccessibility { get; set; } = TypeAccessibility.Public;

    /// <summary>
    /// Enable or disable the use of cancellation tokens.
    /// </summary>
    [JsonPropertyName("useCancellationTokens")]
    [JsonProperty("useCancellationTokens")]
    public bool UseCancellationTokens { get; set; }

    /// <summary>
    /// Set to <c>true</c> to explicitly format date query string parameters
    /// in ISO 8601 standard date format using delimiters (for example: 2023-06-15)
    /// </summary>
    [JsonPropertyName("useIsoDateFormat")]
    [JsonProperty("useIsoDateFormat")]
    public bool UseIsoDateFormat { get; set; }

    /// <summary>
    /// Add additional namespace to generated types
    /// </summary>
    [JsonPropertyName("additionalNamespaces")]
    [JsonProperty("additionalNamespaces")]
    public string[] AdditionalNamespaces { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Set to <c>true</c> to Generate a Refit interface for each endpoint
    /// </summary>
    [JsonPropertyName("multipleInterfaces")]
    [JsonProperty("multipleInterfaces")]
    public bool UseMultipleInterfaces { get; set; }
}

/// <summary>
/// Configurable settings for naming in the client API
/// </summary>
[ExcludeFromCodeCoverage]
public class NamingSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether the OpenApi title should be used. Default is true.
    /// </summary>
    [JsonPropertyName("useOpenApiTitle")]
    [JsonProperty("useOpenApiTitle")]
    public bool UseOpenApiTitle { get; set; } = true;

    /// <summary>
    /// Gets or sets the name of the Interface. Default is "ApiClient".
    /// </summary>
    [JsonPropertyName("interfaceName")]
    [JsonProperty("interfaceName")]
    public string InterfaceName { get; set; } = "ApiClient";
}

/// <summary>
/// Specifies the accessibility of a type.
/// </summary>
public enum TypeAccessibility
{
    /// <summary>
    /// Indicates that the type is accessible by any assembly that references it.
    /// </summary>
    Public,

    /// <summary>
    /// Indicates that the type is only accessible within its own assembly.
    /// </summary>
    Internal
}