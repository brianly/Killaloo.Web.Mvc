using System;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Killaloo.Web.Mvc
{
    public class JsonActionResult : ActionResult
    {
        public Object ObjectToSerialize { get; set; }
        public bool FormatResult { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            string serialized;

            if (FormatResult)
            {
                serialized = JsonConvert.SerializeObject(ObjectToSerialize, Formatting.Indented);
            }
            else
            {
                serialized = JsonConvert.SerializeObject(ObjectToSerialize, Formatting.None);
            }

            context.HttpContext.Response.Output.Write(serialized);
        }
    }
}
