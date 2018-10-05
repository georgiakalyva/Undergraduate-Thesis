using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace ThesisWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true, "application/json"));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
    //public class JsonNetFormatter : MediaTypeFormatter
    //{
    //    private JsonSerializerSettings _jsonSerializerSettings;

    //    public JsonNetFormatter(JsonSerializerSettings jsonSerializerSettings)
    //    {
    //        _jsonSerializerSettings = jsonSerializerSettings ?? new JsonSerializerSettings();

    //        // Fill out the mediatype and encoding we support
    //        SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
    //        Encoding = new UTF8Encoding(false, true);
    //    }

    //    public  override bool CanReadType(Type type)
    //    {
    //        if (type == typeof(IKeyValueModel))
    //        {
    //            return false;
    //        }
    //        return true;
    //    }

    //    public override bool CanWriteType(Type type)
    //    {
    //        return true;
    //    }

    //    public override Task<object> OnReadFromStreamAsync(Type type, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext)
    //    {
    //        // Create a serializer
    //        JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);

    //        // Create task reading the content
    //        return Task.Factory.StartNew(() =>
    //        {
    //            using (StreamReader streamReader = new StreamReader(stream, Encoding))
    //            {
    //                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
    //                {
    //                    return serializer.Deserialize(jsonTextReader, type);
    //                }
    //            }
    //        });
    //    }
    //    public override Task OnWriteToStreamAsync(Type type, object value, Stream stream, HttpContentHeaders contentHeaders, FormatterContext formatterContext, TransportContext transportContext)
    //    {
    //        // Create a serializer
    //        JsonSerializer serializer = JsonSerializer.Create(_jsonSerializerSettings);

    //        // Create task writing the serialized content
    //        return Task.Factory.StartNew(() =>
    //        {
    //            using (JsonTextWriter jsonTextWriter = new JsonTextWriter(new StreamWriter(stream, Encoding)) { CloseOutput = false })
    //            {
    //                serializer.Serialize(jsonTextWriter, value);
    //                jsonTextWriter.Flush();
    //            }
    //        });
    //    }
    //}
}
