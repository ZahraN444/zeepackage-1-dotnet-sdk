// <copyright file="UserController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstore.Standard;
    using SwaggerPetstore.Standard.Exceptions;
    using SwaggerPetstore.Standard.Http.Client;
    using SwaggerPetstore.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// UserController.
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        internal UserController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Required parameter: List of user object.</param>
        public void CreateUsersWithArrayInput(
                List<Models.User> body)
            => CoreHelper.RunVoidTask(CreateUsersWithArrayInputAsync(body));

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Required parameter: List of user object.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CreateUsersWithArrayInputAsync(
                List<Models.User> body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/user/createWithArray")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: name that need to be updated.</param>
        /// <param name="body">Required parameter: Updated user object.</param>
        public void UpdateUser(
                string username,
                Models.UserRequest body)
            => CoreHelper.RunVoidTask(UpdateUserAsync(username, body));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: name that need to be updated.</param>
        /// <param name="body">Required parameter: Updated user object.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdateUserAsync(
                string username,
                Models.UserRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/user/{username}")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("username", username))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid user supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("User not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Required parameter: List of user object.</param>
        public void CreateUsersWithListInput(
                List<Models.User> body)
            => CoreHelper.RunVoidTask(CreateUsersWithListInputAsync(body));

        /// <summary>
        /// Creates list of users with given input array.
        /// </summary>
        /// <param name="body">Required parameter: List of user object.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CreateUsersWithListInputAsync(
                List<Models.User> body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/user/createWithList")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        public void LogoutUser()
            => CoreHelper.RunVoidTask(LogoutUserAsync());

        /// <summary>
        /// Logs out current logged in user session.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task LogoutUserAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/logout"))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Required parameter: The user name for login.</param>
        /// <param name="password">Required parameter: The password for login in clear text.</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string LoginUser(
                string username,
                string password)
            => CoreHelper.RunTask(LoginUserAsync(username, password));

        /// <summary>
        /// Logs user into the system.
        /// </summary>
        /// <param name="username">Required parameter: The user name for login.</param>
        /// <param name="password">Required parameter: The password for login in clear text.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> LoginUserAsync(
                string username,
                string password,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<string>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/login")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("username", username))
                      .Query(_query => _query.Setup("password", password))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username/password supplied", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public Models.User GetUserByName(
                string username)
            => CoreHelper.RunTask(GetUserByNameAsync(username));

        /// <summary>
        /// Get user by user name.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be fetched. Use user1 for testing..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.User response from the API call.</returns>
        public async Task<Models.User> GetUserByNameAsync(
                string username,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.User>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/user/{username}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("username", username))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("User not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="body">Required parameter: Created user object.</param>
        public void CreateUser(
                Models.UserRequest body)
            => CoreHelper.RunVoidTask(CreateUserAsync(body));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="body">Required parameter: Created user object.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task CreateUserAsync(
                Models.UserRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/user")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be deleted.</param>
        public void DeleteUser(
                string username)
            => CoreHelper.RunVoidTask(DeleteUserAsync(username));

        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">Required parameter: The name that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteUserAsync(
                string username,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/user/{username}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("username", username))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid username supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("User not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}