// <copyright file="IHttpBasicCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;

    /// <summary>
    /// Authentication configuration interface for HttpBasic.
    /// </summary>
    public interface IHttpBasicCredentials
    {
        /// <summary>
        /// Gets string value for username.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Gets string value for passwprd.
        /// </summary>
        string Passwprd { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="username"> The string value for credentials.</param>
        /// <param name="passwprd"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string username, string passwprd);
    }
}