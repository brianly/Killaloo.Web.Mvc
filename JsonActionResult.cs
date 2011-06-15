using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Killaloo.Web.Mvc
{
    public class JsonActionResult : ActionResult
    {
        public Object ObjectToSerialize { get; set; }
        public bool FormatResult { get; set; }
        public bool UseIsoDateFormat { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var serializerSettings = new JsonSerializerSettings();

            if (UseIsoDateFormat)
            {
                serializerSettings.Converters.Add(new IsoDateTimeConverter());
            }


            string serialized = JsonConvert.SerializeObject(ObjectToSerialize, FormatResult ? Formatting.Indented : Formatting.None, serializerSettings);

            context.HttpContext.Response.Output.Write(serialized);
        }
    }
}
