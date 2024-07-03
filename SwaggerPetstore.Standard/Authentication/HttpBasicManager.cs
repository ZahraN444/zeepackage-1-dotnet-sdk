// <copyright file="HttpBasicManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using SwaggerPetstore.Standard.Http.Request;
    using APIMatic.Core.Authentication;

    /// <summary>
    /// HttpBasicManager Class.
    /// </summary>
    internal class HttpBasicManager : AuthManager, IHttpBasicCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpBasicManager"/> class.
        /// </summary>
        /// <param name="httpBasic"> HttpBasicModel.</param>
        internal HttpBasicManager(HttpBasicModel basicAuth)
        {
            Username = basicAuth?.Username;
            Passwprd = basicAuth?.Passwprd;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("Authorization", GetBasicAuthHeader()).Required()));
        }

        /// <summary>
        /// Gets string value for username.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets string value for passwprd.
        /// </summary>
        public string Passwprd { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="username"> The string value for credentials.</param>
        /// <param name="passwprd"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string username, string passwprd)
        {
            return username.Equals(this.Username)
                    && passwprd.Equals(this.Passwprd);
        }

        private string GetBasicAuthHeader()
        {
            if (this.Username == null || this.Passwprd == null)
                return null;

            string authCredentials = this.Username + ":" + this.Passwprd;
            byte[] data = Encoding.ASCII.GetBytes(authCredentials);
            return "Basic " + Convert.ToBase64String(data);
        }
    }

    public sealed class HttpBasicModel
    {
        internal HttpBasicModel()
        {
        }

        internal string Username { get; set; }

        internal string Passwprd { get; set; }

        /// <summary>
        /// Creates an object of the HttpBasicModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(Username, Passwprd);
        }

        /// <summary>
        /// Builder class for HttpBasicModel.
        /// </summary>
        public class Builder
        {
            private string username;
            private string passwprd;

            public Builder(string username, string passwprd)
            {
                this.username = username ?? throw new ArgumentNullException(nameof(username));
                this.passwprd = passwprd ?? throw new ArgumentNullException(nameof(passwprd));
            }

            /// <summary>
            /// Sets Username.
            /// </summary>
            /// <param name="username">Username.</param>
            /// <returns>Builder.</returns>
            public Builder Username(string username)
            {
                this.username = username ?? throw new ArgumentNullException(nameof(username));
                return this;
            }


            /// <summary>
            /// Sets Passwprd.
            /// </summary>
            /// <param name="passwprd">Passwprd.</param>
            /// <returns>Builder.</returns>
            public Builder Passwprd(string passwprd)
            {
                this.passwprd = passwprd ?? throw new ArgumentNullException(nameof(passwprd));
                return this;
            }


            /// <summary>
            /// Creates an object of the HttpBasicModel using the values provided for the builder.
            /// </summary>
            /// <returns>HttpBasicModel.</returns>
            public HttpBasicModel Build()
            {
                return new HttpBasicModel()
                {
                    Username = this.username,
                    Passwprd = this.passwprd
                };
            }
        }
    }
}