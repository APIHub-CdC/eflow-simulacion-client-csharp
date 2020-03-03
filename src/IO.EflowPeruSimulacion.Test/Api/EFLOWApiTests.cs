using NUnit.Framework;
using IO.EflowPeruSimulacion.Api;
using IO.EflowPeruSimulacion.Model;

namespace IO.EflowPeruSimulacion.Test
{
    [TestFixture]
    public class EFLOWApiTests
    {
        private EFLOWApi api;
        private string xApiKey;
        
        [SetUp]
        public void Init()
        {
            string basePath = "the_url";
            this.xApiKey = "your_api_key";
            this.api = new EFLOWApi(basePath);
        }

        [Test]
        public void EflowTest()
        {
            Peticion request = new Peticion();
            request.Folio = "XXXXXXXX";
            request.TipoDocumento = "X";
            request.NumeroDocumento = "XXXXXXXX";
            var response = this.api.Eflow(this.xApiKey, request);
            Assert.IsInstanceOf<Respuesta> (response, "response is Respuesta");
        }
    }
}