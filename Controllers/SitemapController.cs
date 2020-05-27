using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;

namespace ASPNETCoreSEOTemplate.Controllers
{
    public class SitemapController : Controller
    {
        public ActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
        {
            new SitemapNode(Url.Action("Index","Home")),
            new SitemapNode(Url.Action("Privacy","Home")),
            new SitemapNode(Url.Action("Index","Products")),
            new SitemapNode(Url.Action("ProductExample","Products")),
            //other nodes
        };

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
