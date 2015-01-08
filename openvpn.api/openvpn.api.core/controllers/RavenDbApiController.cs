using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace openvpn.api.core.controllers
{
    /// <summary>
    /// http://ravendb.net/docs/article-page/2.0/csharp/samples/web-api/createaspnetwebapiproject
    /// </summary>
    public abstract class RavenDbApiController : ApiController
    {
        public IDocumentStore Store
        {
            get { return _documentStore.Value; }
        }

        public IAsyncDocumentSession Session { get; set; }

        private readonly Lazy<IDocumentStore> _documentStore = new Lazy<IDocumentStore>(() =>
        {           

            var docStore = new DocumentStore
            {
                Url = ConfigurationManager.AppSettings["RavenDbDocumentStoreUrl"],
                DefaultDatabase = ConfigurationManager.AppSettings["RavenDbDefaultDatabase"]
            };

            docStore.Initialize();
            return docStore;
        });

        

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            using (Session = Store.OpenAsyncSession())
            {
                var result = await base.ExecuteAsync(controllerContext, cancellationToken);
                await Session.SaveChangesAsync();

                return result;
            }
        }
    }
}
