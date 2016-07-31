
using E3.XrmProxy;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Umbraco.e3Portal.Models.AdminArea;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;
namespace Umbraco.e3Portal.Controllers
{
    [IsBackOffice]
    public class CampaignApiController : UmbracoApiController
    {
        [HttpGet]
        public IEnumerable<CampaignModel> GetAll()
        {
            return E3.XrmProxy.CrmServiceProxy.GetPackageCampaigns(true).Select(x => new CampaignModel { Id = x.Id, Name = x.Name });
        }
    }
}