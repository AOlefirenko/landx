using System.Web;
using System.Web.Mvc;

namespace MarcoPolo.Landing
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}