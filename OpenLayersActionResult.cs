using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Killaloo.Web.Mvc
{
    public class OpenLayersActionResult : ActionResult
    {
        public List<MapPoint> Points { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";

            var sb = new StringBuilder();

            // Add standard headers with new line
            sb.AppendLine("point\ttitle\tdescription\ticonSize\ticon");

            // Add all data points for the map
            foreach (var mapPoint in Points)
            {
                sb.AppendLine(FormatPoint(mapPoint));
            }

            context.HttpContext.Response.Output.Write(sb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapPoint"></param>
        /// <returns></returns>
        private static string FormatPoint(MapPoint mapPoint)
        {
            const string format = "{0}\t{1}\t{2}\t{3}\t{4}";
            return string.Format(format, mapPoint.LatLon, mapPoint.Title, 
                                         mapPoint.Description, mapPoint.IconSize, 
                                         mapPoint.Icon);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MapPoint
    {
        public string LatLon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconSize { get; set; }
        public string Icon { get; set; }
    }
}
