// <copyright file="StoreController.cs" company="APIMatic">
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
    /// StoreController.
    /// </summary>
    public class StoreController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreController"/> class.
        /// </summary>
        internal StoreController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// <![CDATA[
        /// For valid response try integer IDs with value >= 1 and <= 10. Other values will generated exceptions.
        /// ]]>
        /// </summary>
        /// <param name="orderId">Required parameter: ID of pet that needs to be fetched.</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order GetOrderById(
                long orderId)
            => CoreHelper.RunTask(GetOrderByIdAsync(orderId));

        /// <summary>
        /// <![CDATA[
        /// For valid response try integer IDs with value >= 1 and <= 10. Other values will generated exceptions.
        /// ]]>
        /// </summary>
        /// <param name="orderId">Required parameter: ID of pet that needs to be fetched.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> GetOrderByIdAsync(
                long orderId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/store/order/{orderId}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("orderId", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Order not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Place an order for a pet.
        /// </summary>
        /// <param name="body">Required parameter: order placed for purchasing the pet.</param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public Models.Order PlaceOrder(
                Models.StoreOrderRequest body)
            => CoreHelper.RunTask(PlaceOrderAsync(body));

        /// <summary>
        /// Place an order for a pet.
        /// </summary>
        /// <param name="body">Required parameter: order placed for purchasing the pet.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Order response from the API call.</returns>
        public async Task<Models.Order> PlaceOrderAsync(
                Models.StoreOrderRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Order>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/store/order")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid Order", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public Dictionary<string, int> GetInventory()
            => CoreHelper.RunTask(GetInventoryAsync());

        /// <summary>
        /// Returns a map of status codes to quantities.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Dictionary of string, int response from the API call.</returns>
        public async Task<Dictionary<string, int>> GetInventoryAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Dictionary<string, int>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/store/inventory")
                  .WithAuth("api_key"))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// For valid response try integer IDs with positive integer value. Negative or non-integer values will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        public void DeleteOrder(
                long orderId)
            => CoreHelper.RunVoidTask(DeleteOrderAsync(orderId));

        /// <summary>
        /// For valid response try integer IDs with positive integer value. Negative or non-integer values will generate API errors.
        /// </summary>
        /// <param name="orderId">Required parameter: ID of the order that needs to be deleted.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeleteOrderAsync(
                long orderId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/store/order/{orderId}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("orderId", orderId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Order not found", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}