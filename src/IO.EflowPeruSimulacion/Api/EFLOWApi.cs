using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.EflowPeruSimulacion.Client;
using IO.EflowPeruSimulacion.Model;

namespace IO.EflowPeruSimulacion.Api
{
    public interface IEFLOWApi : IApiAccessor
    {
        #region Synchronous Operations
        Respuesta Eflow(string xApiKey, Peticion request);
        ApiResponse<Respuesta> EflowWithHttpInfo(string xApiKey, Peticion request);
        #endregion Synchronous Operations
    }
    public partial class EFLOWApi : IEFLOWApi
    {
        private IO.EflowPeruSimulacion.Client.ExceptionFactory _exceptionFactory = (name, response) => null;
        public EFLOWApi(String basePath)
        {
            this.Configuration = new IO.EflowPeruSimulacion.Client.Configuration(basePath);
            ExceptionFactory = IO.EflowPeruSimulacion.Client.Configuration.DefaultExceptionFactory;
        }
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
        }
        public IO.EflowPeruSimulacion.Client.Configuration Configuration { get; set; }
        public IO.EflowPeruSimulacion.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }
        public Respuesta Eflow(string xApiKey, Peticion request)
        {
            ApiResponse<Respuesta> localVarResponse = EflowWithHttpInfo(xApiKey, request);
            return localVarResponse.Data;
        }
        public ApiResponse<Respuesta> EflowWithHttpInfo(string xApiKey, Peticion request)
        {
            if (xApiKey == null)
                throw new ApiException(400, "Missing required parameter 'xApiKey' when calling EFLOWApi->Eflow");
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling EFLOWApi->Eflow");
            var localVarPath = "";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);
            if (xApiKey != null) localVarHeaderParams.Add("x-api-key", this.Configuration.ApiClient.ParameterToString(xApiKey));
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(request);
            }
            else
            {
                localVarPostBody = request;
            }
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);
            int localVarStatusCode = (int)localVarResponse.StatusCode;
            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Eflow", localVarResponse);
                if (exception != null) throw exception;
            }
            return new ApiResponse<Respuesta>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Respuesta)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Respuesta)));
        }
    }
}
