using Sage.CRM.Rest.Api.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sage.CRM.Rest.Api.Interface
{
    public class SageCRMBuilder
    {
        public const string DEFAULT_BASE_URL = "http://localhost/sdata/crmj/sagecrm2/-/";
        private string _baseUrl = "";
        private string _username = "";
        private string _password = "";
        private string _sessionId = "";
        public SageCRMBuilder()
        {

        }

        public SageCRMBuilder SetBaseUrl(string baseUrl)
        {
            _baseUrl = baseUrl;
            return this;
        }

        public SageCRMBuilder SetLoginCredentials(string username, string password)
        {
            _username = username;
            _password = password;
            return this;
        }

        public SageCRMBuilder SetSessionID(string sessionId)
        {
            _sessionId = sessionId;
            return this;
        }

        public SageCRMImplementation Build()
        {
            if (string.IsNullOrEmpty(_baseUrl))
                _baseUrl = DEFAULT_BASE_URL;

            SageCRMImplementation sageCRMImplementation = new SageCRMImplementation(_baseUrl, _username, _password);
            return sageCRMImplementation;
        }
    }
}
