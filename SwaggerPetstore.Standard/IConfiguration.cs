// <copyright file="IConfiguration.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard
{
    using System;
    using System.Net;
    using SwaggerPetstore.Standard.Authentication;
    using SwaggerPetstore.Standard.Models;

    /// <summary>
    /// IConfiguration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets This is a test header
        /// </summary>
        string TestHeader { get; }

        /// <summary>
        /// Gets Current API environment.
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets the credentials to use with ApiKey.
        /// </summary>
        IApiKeyCredentials ApiKeyCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with ApiKey.
        /// </summary>
        ApiKeyModel ApiKeyModel { get; }

        /// <summary>
        /// Gets the credentials to use with HttpBasic.
        /// </summary>
        IHttpBasicCredentials HttpBasicCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with HttpBasic.
        /// </summary>
        HttpBasicModel HttpBasicModel { get; }

        /// <summary>
        /// Gets the credentials to use with PetstoreAuth.
        /// </summary>
        IPetstoreAuthCredentials PetstoreAuthCredentials { get; }

        /// <summary>
        /// Gets the credentials model to use with PetstoreAuth.
        /// </summary>
        PetstoreAuthModel PetstoreAuthModel { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        string GetBaseUri(Server alias = Server.Default);
    }
}