using System.Net;
using System.Net.Http;
using System.Web.Http;
using jvmorgutia.Wander.Contract;
using jvmorgutia.Wander.Service;

namespace jvmorgutia.Wander.WebApi.Controllers
{
    public class WanderActivityController : ApiController
    {
        #region String Constants

        private const string NullContractRequestMessage = "The request contract cannot be null.";

        #endregion

        [HttpPost, ActionName("ActivityLookup")]
        public HttpResponseMessage GetLocalActivities(ActivityLookupRequest contract)
        {
            var lookupResponse = new WanderActivityService().GetLocalActivities(contract);

            return contract == null
                ? Request.CreateResponse(HttpStatusCode.BadRequest, NullContractRequestMessage)
                : Request.CreateResponse(HttpStatusCode.OK, lookupResponse);
        }
    }
}

