/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text;

namespace Warewolf.Common.Tests
{
    [TestClass]
    public class WarewolfWebRequestForwarderTests
    {
        [TestMethod]
        public void WarewolfWebRequestForwarder_Consume_Success()
        {
            //---------------------------------Arrange--------------------------------
            var mockHttpClient = new Mock<IHttpClient>();

            var testUrl = "http:0420/test/url";

            var WarewolfWebRequestForwarder = new WarewolfWebRequestForwarder(mockHttpClient.Object, testUrl, "testValueKey");
            //---------------------------------Act------------------------------------
            WarewolfWebRequestForwarder.Consume(Encoding.UTF8.GetBytes("this is a test message"));

            //---------------------------------Assert---------------------------------
            mockHttpClient.Verify(o => o.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}