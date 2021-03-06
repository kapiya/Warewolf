/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using Dev2.Runtime.WebServer.Controllers;
using Dev2.Runtime.WebServer.Handlers;
using Dev2.Services.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.Security;

namespace Dev2.Runtime.WebServer.Tests
{
    [TestClass]
    public class AbstractControllerTests
    {
        [TestMethod]
        [TestCategory(nameof(AbstractController))]
        [Owner("Rory McGuire")]
        public void AbstractController_ProcessRequest_GivenNotAuthenticated_ExpectUnauthorized()
        {
            var controller = new AbstractControllerForTesting
            {
                Request = new HttpRequestMessage(HttpMethod.Get, "/token/Hello%20World.json?Name=")
            };
            var response = controller.TestProcessRequest<AssertNotExecutedRequestHandlerForTesting>(false);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);
            Assert.AreEqual(response.ReasonPhrase, "Unauthorized");
        }

        [TestMethod]
        [TestCategory(nameof(AbstractController))]
        [Owner("Rory McGuire")]
        public void AbstractController_ProcessRequest_GivenTokenEmptyNotAuthenticated_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost/token/Hello%20World.json?Name=")
            {
                Headers = { {"Authorization", "bearer "}},
                Content = new StringContent("Some content"),
            };
            var controller = new AbstractControllerForTesting
            {
                Request = request
            };

            var response = controller.TestProcessRequest<AssertNotExecutedRequestHandlerForTesting>(true);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.TokenNotAuthorizedToExecuteOuterWorkflowException, response.ReasonPhrase);
        }

        [TestMethod]
        [TestCategory(nameof(AbstractController))]
        [Owner("Rory McGuire")]
        public void AbstractController_ProcessRequest_GivenTokenNotAuthenticated_ExpectUnauthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost/token/Hello%20World.json?Name=")
            {
                Headers = { {"Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9hdXRoZW50aWNhdGlvbiI6InsnVXNlckdyb3Vwcyc6IFt7J05hbWUnOiAncHVibGljJyB9XX0iLCJuYmYiOjE1OTExOTcyMDEsImV4cCI6MTU5MTE5ODQwMSwiaWF0IjoxNTkxMTk3MjAxfQ.1zo2d8Z7yxDvGZGVXbCf8zQKh7WZeyGx7BfWu4drt4g"}},
                Content = new StringContent("Some content"),
            };
            var controller = new AbstractControllerForTesting
            {
                Request = request
            };
            var response = controller.TestProcessRequest<AssertNotExecutedRequestHandlerForTesting>(true);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.TokenNotAuthorizedToExecuteOuterWorkflowException, response.ReasonPhrase);
        }
    }

    internal class AbstractControllerForTesting : AbstractController
    {
        public HttpResponseMessage TestProcessRequest<TRequestHandler>(bool isUrlWithTokenPrefix) where TRequestHandler : class, IRequestHandler, new()
        {
            var vars = new NameValueCollection();
            return ProcessRequest<TRequestHandler>(vars, isUrlWithTokenPrefix);
        }
    }

    internal class AssertNotExecutedRequestHandlerForTesting : IRequestHandler
    {
        public void ProcessRequest(ICommunicationContext ctx)
        {
            throw new Exception("not expected to be executed");
        }
    }

    internal class RequestHandlerForTesting : IRequestHandler
    {
        public void ProcessRequest(ICommunicationContext ctx)
        {

        }
    }
}
