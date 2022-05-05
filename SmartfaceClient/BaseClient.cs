using InnovatricsDemo.Core.Helpers;
using NLog;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;

namespace SmartfaceClient
{
    public class BaseClient
    {
        private readonly string _endpoitUrl;
        protected readonly RestClient _client;
        protected readonly Logger _logger;

        public BaseClient(Logger logger)
        {
            _logger = logger;
            _logger.Trace("BaseClient - ctor");

            _endpoitUrl = ConfigurationHelper.GetStrValue("Endpoint");

            if (!ValidateUrl(_endpoitUrl)) {
                _logger.Error("Invalid endpooint url in appsettings");

                throw new Exception("Invalid endpooint url in appsettings");
            }

            _logger.Debug("Using enpoit url {endpoint}", _endpoitUrl);

            _client = new RestClient(_endpoitUrl);
            _client.UseNewtonsoftJson();
        }

        private bool ValidateUrl(string url)
        {
            _logger.Trace("ValidateUrl - call");

            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
