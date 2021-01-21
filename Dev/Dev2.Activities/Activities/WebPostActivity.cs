﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.TO;
using Dev2.Diagnostics;
using Dev2.Interfaces;
using Dev2.Runtime.ServiceModel;
using Dev2.Runtime.ServiceModel.Data;
using Newtonsoft.Json;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Core;
using Warewolf.Data.Options;
using Warewolf.Options;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;

namespace Dev2.Activities
{

    [ToolDescriptorInfo("WebMethods", "POST", ToolType.Native, "6AEB1038-6332-46F9-8BDD-752DE4EA038E", "Dev2.Activities", "1.0.0.0", "Legacy", "HTTP Web Methods", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_WebMethod_Post")]
    public class WebPostActivity : DsfActivity, IEquatable<WebPostActivity>
    {
        public IList<INameValue> Headers { get; set; }
        public bool IsFormDataChecked { get; set; }
        public bool IsNoneChecked { get; set; }
        public IList<FormDataConditionExpression> Conditions { get; set; }
        public FormDataOptions FormDataOptions { get; set; }
        public string QueryString { get; set; }
        public IOutputDescription OutputDescription { get; set; }
        public IResponseManager ResponseManager { get; set; }
        public string PostData { get; set; }

        public WebPostActivity()
        {
            Type = "POST Web Method";
            DisplayName = "POST Web Method";

            if (FormDataOptions is null)
            {
                FormDataOptions = new FormDataOptions();
            }
        }

        public override enFindMissingType GetFindMissingType() => enFindMissingType.DataGridActivity;

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            if (env == null)
            {
                return _debugInputs;
            }

            base.GetDebugInputs(env, update);

            var (head, parameters, _) = GetEnvironmentInputVariables(env, update);

            var url = ResourceCatalog.GetResource<WebSource>(Guid.Empty, SourceId);
            var headerString=string.Empty;
            if (head != null)
            {
                headerString = string.Join(" ", head.Select(a => a.Name + " : " + a.Value));
            }

            var debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "URL"), debugItem);
            AddDebugItem(new DebugEvalResult(url.Address, "", env, update), debugItem);
            _debugInputs.Add(debugItem);
            debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "Query String"), debugItem);
            AddDebugItem(new DebugEvalResult(QueryString, "", env, update), debugItem);
            _debugInputs.Add(debugItem);

            if (IsNoneChecked)
            {
                debugItem = new DebugItem();
                AddDebugItem(new DebugItemStaticDataParams("", "Post Data"), debugItem);
                AddDebugItem(new DebugEvalResult(PostData, "", env, update), debugItem);
                _debugInputs.Add(debugItem);
            }

            debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", nameof(Headers)), debugItem);
            AddDebugItem(new DebugEvalResult(headerString, "", env, update), debugItem);
            _debugInputs.Add(debugItem);

            if (IsFormDataChecked)
            {
                AddDebugFormDataInputs();
            }

            return _debugInputs;
        }


        private void AddDebugFormDataInputs()
        {
            var allErrors = new ErrorResultTO();

            try
            {
                var dds = Conditions.GetEnumerator();
                var text = new StringBuilder();
                if (dds.MoveNext() && dds.Current.Cond.MatchType != enFormDataTableType.Choose)
                {
                    dds.Current.RenderDescription(text);
                }
                while (dds.MoveNext())
                {
                    var conditionExpression = dds.Current;
                    if (conditionExpression.Cond.MatchType == enFormDataTableType.Choose)
                    {
                        continue;
                    }

                    text.Append("\n ");
                    conditionExpression.RenderDescription(text);
                }

                var debugItem = new DebugItem();
                var s = text.ToString();
                AddDebugItem(new DebugItemStaticDataParams(s, "Parameters"), debugItem);
                _debugInputs.Add(debugItem);
            }
            catch (JsonSerializationException e)
            {
                Dev2Logger.Warn(e.Message, "Warewolf Warn");
            }
            catch (Exception e)
            {
                allErrors.AddError(e.Message);
            }
            finally
            {
                if (allErrors.HasErrors())
                {
                    var serviceName = GetType().Name;
                    DisplayAndWriteError(serviceName, allErrors);
                }
            }
        }


        protected override void ExecutionImpl(IEsbChannel esbChannel, IDSFDataObject dataObject, string inputs, string outputs, out ErrorResultTO tmpErrors, int update)
        {
            tmpErrors = new ErrorResultTO();

            var (head, query, postData) = GetEnvironmentInputVariables(dataObject.Environment, update);

            var url = ResourceCatalog.GetResource<WebSource>(Guid.Empty, SourceId);
            var webRequestResult = string.Empty;
            if (IsFormDataChecked)
            { 
                //webRequestResult = PerformFormDataWebPostRequest(head, parameters, query, url, postData);
            }
            else if (IsNoneChecked)
            {
                webRequestResult = PerformManualWebPostRequest(head, query, url, postData);
            }

            tmpErrors.MergeErrors(_errorsTo);

            var bytes = webRequestResult.Base64StringToByteArray();
            var response = bytes.ReadToString();

            ResponseManager = new ResponseManager 
            { 
                OutputDescription = OutputDescription, 
                Outputs = Outputs, 
                IsObject = IsObject, 
                ObjectName = ObjectName 
            };
            ResponseManager.PushResponseIntoEnvironment(response, update, dataObject);

        }

        private (IEnumerable<INameValue> head, string query, string data) GetEnvironmentInputVariables(IExecutionEnvironment environment, int update)
        {
            IEnumerable<INameValue> head = null;
            if (Headers != null)
            {
                head = Headers.Select(a => new NameValue(ExecutionEnvironment.WarewolfEvalResultToString(environment.Eval(a.Name, update)), ExecutionEnvironment.WarewolfEvalResultToString(environment.Eval(a.Value, update))));
            }
            var query = string.Empty;
            if (QueryString != null)
            {
                query = ExecutionEnvironment.WarewolfEvalResultToString(environment.Eval(QueryString, update));
            }
            var postData = string.Empty;
            if (PostData != null && IsNoneChecked)
            {
                postData = ExecutionEnvironment.WarewolfEvalResultToString(environment.Eval(PostData, update));
            }

            return (head, query, postData);
        }

        
        protected virtual string PerformManualWebPostRequest(IEnumerable<INameValue> head, string query, IWebSource source, string postData)
        {
            return WebSources.Execute(source, WebRequestMethod.Post, query, postData, true, out _errorsTo, head.Select(h => h.Name + ":" + h.Value).ToArray());
        }

        protected virtual string PerformFormDataWebPostRequest(IEnumerable<INameValue> head, IEnumerable<INameValue> parameters, string query, IWebSource source, string postData)
        {
            return WebSources.Execute(source, WebRequestMethod.Post, query, postData, true, out _errorsTo, head.Select(h => h.Name + ":" + h.Value).ToArray(), parameters);
        }

        public static WebClient CreateClient(IEnumerable<INameValue> head, string query, WebSource source)
        {
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => true;
            var webclient = new WebClient();
            if (head != null)
            {
                foreach (var nameValue in head)
                {
                    if (!string.IsNullOrEmpty(nameValue.Name) && !String.IsNullOrEmpty(nameValue.Value))
                    {
                        webclient.Headers.Add(nameValue.Name, nameValue.Value);
                    }
                }
            }

            if (source.AuthenticationType == AuthenticationType.User)
            {
                webclient.Credentials = new NetworkCredential(source.UserName, source.Password);
            }

            webclient.Headers.Add("user-agent", GlobalConstants.UserAgentString);
            var address = source.Address;
            if (query != null)
            {
                address += query;
            }
            webclient.BaseAddress = address;
            return webclient;
        }

        public bool Equals(WebPostActivity other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other) && Equals(Headers, other.Headers) &&
                   string.Equals(QueryString, other.QueryString) &&
                   Equals(OutputDescription, other.OutputDescription) &&
                   string.Equals(PostData, other.PostData) &&
                   Equals(IsNoneChecked, other.IsNoneChecked) &&
                   Equals(IsFormDataChecked, other.IsFormDataChecked);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((WebPostActivity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Headers != null ? Headers.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QueryString != null ? QueryString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OutputDescription != null ? OutputDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PostData != null ? PostData.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IsNoneChecked.GetHashCode());
                hashCode = (hashCode * 397) ^ (IsFormDataChecked.GetHashCode());
                return hashCode;
            }
        }
    }
}