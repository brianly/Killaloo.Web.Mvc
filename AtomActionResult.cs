using System.Xml;
using System.Web.Mvc;
using System.ServiceModel.Syndication;

namespace Killaloo.Web.Mvc
{
    public class AtomActionResult : ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/atom+xml";

            var rssFormatter = new Atom10FeedFormatter(Feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(writer);
            }
        }
    }
}
