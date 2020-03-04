using System;
using RestSharp;

namespace IO.EflowPeruSimulacion.Client
{
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}
