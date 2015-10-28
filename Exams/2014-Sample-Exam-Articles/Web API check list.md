**Web API check list**

-   **Projects**: \[Project\].Models, .Data, .Web, .WCF

-   **DbContext**: \[Project\]DbContext.cs with all DbSets

-   **Migrations**:

    -   package manager &gt; enable\_migrations (for \[Project\].Data)

    -   Configuration() &gt; this.AutomaticMigrationDataLossAllowed = true;

<!-- -->

-   **Repositories**

    -   All, Find, Add, Update, Delete(T), Delete(id), int SaveChanges

    -   ChangeState(T entity, EntityState state)

<!-- -->

-   **UoW**

    -   private context, dictionary, all repos

    -   GetRepository&lt;T&gt;()

-   **BaseController**

> protected IArticlesData data;
>
> public BaseApiController(IArticlesData data)
>
> {
>
> this.data = data;
>
> }

-   **IoC**: Ninject.web.webapi OWIN

    -   GitHub link: <https://github.com/ninject/Ninject.Web.Common/wiki/Setting-up-a-OWIN-WebApi-application>

    -   Add namespaces:

> using Ninject;
>
> using Ninject.Web.Common.OwinHost;
>
> using Ninject.Web.WebApi.OwinHost;

-   Startup.cs &gt;

> app.UseNinjectMiddleware(CreateKernel)
>
> .UseNinjectWebApi(GlobalConfiguration.Configuration);

-   RegisterMappings(kernel)

    -   kernel.Bind&lt;IData&gt;().To&lt;Data&gt;().WithConstructorArgument("context", c =&gt; new DbContext());

<!-- -->

-   **Routing**: WebApiConfig.cs &gt; for routings

-   **CORS** for Web API 2.2

    -   WebApiConfig.cd &gt; config.EnableCors(new EnableCorsAttribute("\*", "\*", "\*"));

    -   Global.asax &gt;

> protected void Application\_BeginRequest(object sender, EventArgs e)
>
> {
>
> Response.Headers.Add("Access-Control-Allow-Origin", "\*");
>
> }

**WCF Check list**

-   **\[Service\].svc**

> Factory="System.ServiceModel.Activation.WebServiceHostFactory"

-   **\[ServiceInterface\]**

> \[WebGet(UriTemplate="")\]

-   **Web.config**

> &lt;system.serviceModel&gt;
>
> &lt;standardEndpoints&gt;
>
> &lt;webHttpEndpoint&gt;
>
> &lt;standardEndpoint helpEnabled="true" defaultOutgoingResponseFormat="Json" /&gt;
>
> &lt;/webHttpEndpoint&gt;
>
> &lt;/standardEndpoints&gt;
>
> &lt;/system.serviceModel&gt;
