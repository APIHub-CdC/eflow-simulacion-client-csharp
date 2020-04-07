# Estimador de ingresos Eflow Perú - Simulación

Es una solución que produce ingresos puntuales de una persona natural.

## Requisitos para Windows

- .NET Core 3.1 SDK [vea como instalar][1]
- MonoDevelop [vea como instalar][2]
- Microsoft .NET Framework 4.8 Developer Pack [vea como instalar][3]

### Requisitos para linux/MacOs
- Se debe contar con las siguientes dependencias para SO linux:
    - nuget
    - mono-devel
    - mono-xbuild

```sh
#ejemplo para instalar las dependencias adicionales
apt install nuget
apt install mono-devel
apt install mono-xbuild
```

## Guía de inicio

### Paso 1. Agregar el producto a la aplicación

Al iniciar sesión seguir os siguientes pasos:

 1. Dar clic en la sección "**Mis aplicaciones**".
 2. Seleccionar la aplicación.
 3. Ir a la pestaña de "**Editar '@tuApp**' ".
    <p align="center">
      <img src="https://github.com/APIHub-CdC/imagenes-cdc/blob/master/edit_applications.jpg" width="900">
    </p>
 4. Al abrirse la ventana emergente, seleccionar el producto.
 5. Dar clic en el botón "**Guardar App**":
    <p align="center">
      <img src="https://github.com/APIHub-CdC/imagenes-cdc/blob/master/selected_product.jpg" width="400">
    </p>

### Paso 2. Capturar los datos de la petición

Los siguientes datos a modificar se encuentran en ***IO.EflowPeruSimulacion.Test/Api/EFLOWApiTests.cs***

Es importante contar con el método Init() que se encargará de inicializar la url. Modificar la URL ***('the_url')*** de la petición de la variable ***basePath***, como se muestra en el siguiente fragmento de código:

```csharp

[SetUp]
public void Init()
{
    string basePath = "the_url";
    this.xApiKey = "your_api_key";
    this.api = new EFLOWApi(basePath);
}  

/**
* Este es el método que se será ejecutado en la prueba unitaria, ubicado en path/to/repository/src/IO.EflowPeruSimulacion.Test/Api/EFLOWApiTests.cs 

*/
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
```
## Pruebas unitarias

Para ejecutar las pruebas unitarias con windows:
```sh
# Compilación
build.bat
dotnet msbuild IO.EflowPeruSimulacion.sln
# Ejecución
"packages/NUnit.Runners.2.6.4/tools/nunit-console.exe" src/IO.EflowPeruSimulacion.Test/bin/Debug/IO.EflowPeruSimulacion.Test.dll

```

Para ejecutar las pruebas unitarias con linux:

```sh
# Compilación
sh build.sh
# Ejecución
sh mono_nunit_test.sh
# También puede probar con el siguiente comando
msbuild IO.EflowPeruSimulacion.sln && \
    mono .bin/IO.EflowPeruSimulacion.Test/bin/Debug/IO.EflowPeruSimulacion.Test.dll

```

[1]: https://dotnet.microsoft.com/download
[2]: https://www.mono-project.com/download/stable/#download-win
[3]: https://www.microsoft.com/es-mx/download/details.aspx?id=30653
