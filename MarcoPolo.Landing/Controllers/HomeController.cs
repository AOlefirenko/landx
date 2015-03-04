using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MarcoPolo.Landing.Controllers
{
    public class HomeController : Controller
    {
        private MongoCollection<BsonDocument> _collection;
        //
        // GET: /Home/
        private int _count = 1242;
        private int _totalCount = 5683;

        public ActionResult Index()
        {
            return View(GetName(Request.Url.Host));
        }

        private string GetName(string host)
        {
            if (host.Contains("family"))
                return "Family";
            if (host.Contains("active"))
                return "Active";
            if (host.Contains("business"))
                return "Business";
            if (host.Contains("friends"))
                return "Friends";
            return string.Empty;
        }
        public ActionResult Terms()
        {
            return View();
        }
        private void InitDB()
        {
            var client = new MongoClient("mongodb://xmen:xmen@ds061360.mongolab.com:61360/heybro");
            var server = client.GetServer();
            var db = server.GetDatabase("heybro");
            var name = GetName(Request.Url.Host);
            if (name == string.Empty) name = "XMEusers";
            _collection = db.GetCollection(name);
        }
        [HttpPost]
        public ActionResult SignUp()
        {
            InitDB();
            var email = Request.Form.Get("email");
            _collection.Insert(new BsonDocument { { "email", email } });
            if (Request.Url.Host.Contains("family")) 
                return RedirectToAction("Welcome");
            return new EmptyResult();
        }
        
        public ActionResult Welcome()
        {
            InitDB();
            var count = _collection.Count();
            ViewBag.count = _count + count;
            ViewBag.total = _totalCount - count;
            return View("Family_step2");
        }
        public ActionResult Thanx()
        {
            return View("Thanks_family");
        }
    }
}
