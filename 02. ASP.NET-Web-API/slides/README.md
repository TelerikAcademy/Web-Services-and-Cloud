<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# ASP.NET Web API
<div class="signature">
    <p class="signature-course">Telerik Software Academy</p>
    <p class="signature-initiative">http://academy.telerik.com </p>
    <a href = "Web Services and Cloud" class="signature-link">Web Services and Cloud</a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* What is ASP.NET Web API?
  * Web API Features
  * Demo: Default Project Template
* Web API Controllers
  * Routes
  * Demo: Create API Controller
  * OData queries
* Web API Clients
  * Demo: Consuming Web API

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# What is ASP.NET Web API?

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# ASP.NET Web API
* Framework that makes it easy to build HTTP services for browsers and mobile devices
* Platform for building RESTful applications on the .NET Framework using ASP.NET stack

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# ASP.NET Web API Role
* Data storage
* Data Layer (EF)
* ASP.NET Web API
* HTTP PUT, POST, DELETE
* JSON
* HTTP GET
* JSON
* Models
* XML
* XML

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Web API Features
* Modern HTTP programming model
  * Access to strongly typed HTTP object model
  * HttpClient API – same programming model
* Content negotiation
  * Client and server work together to determine the right format for data
  * Provide default support for JSON, XML and Form URL-encoded formats
  * We can add own formats and change content negotiation strategy

<!-- attr: { showInPresentation:true, style:'' } -->
# Web API Features (2)
* Query composition
  * Support automatic paging and sorting
  * Support querying via the OData URL conventions when we return IQueryable<T> 
* Model binding and validation
  * Combine HTTP data in POCO models
  * Data validation via attributes
  * Supports the same model binding and validation infrastructure as ASP.NET MVC 

<!-- attr: { showInPresentation:true, style:'' } -->
# Web API Features (3)
* Routes (mapping between URIs and code)
  * Full set of routing capabilities supported within ASP.NET (MVC)
* Filters
  * Easily decorates Web API with additional validation (authorization, CORS, etc.)
* Testability
* IoC and dependency injection support
* Flexible hosting (IIS, Azure, self-hosting)

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web API Features (4)
* Visual Studio IDE (+templates and scaffolding)
* Reuse of C# knowledge (+task-based async)
* Custom help pages, tracing, etc.

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# ASP.NET Web API 2
* Attribute routing
* OData improvements: $select, $expand, $batch, $value and improved extensibility
* Request batching
* Portable ASP.NET Web API Client
* Improved testability
* CORS (Cross-origin resource sharing)
* Authentication filters
* OWIN support and integration (owin.org)

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# WCF vs. ASP.NET Web API
* WCF is also a good framework for building HTTP based services

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Demo: Creating ASP.NET Web API Project
##  Default ASP.NET Web API project template

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web API Controllers

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Web API Controllers
* A controller is an object that handles HTTP requests
  * All API controllers derive from ApiController
* By default ASP.NET Web API will map HTTP requests to specific methods called actions

<!-- attr: { showInPresentation:true, style:'' } -->
# Web API Default Behavior
* Web Request
* Match a Route
* API Controller Responds

```cs
http://localhost:1337/api/posts
```

```cs
public class PostsController : ApiController
{
    public string Get()
    {
        return "Some data";    }
}
```
* HTTP GET Request
* 1
* 2
* 3
* Controller Name

<!-- attr: { showInPresentation:true, style:'' } -->
# Routing
* Routing is how ASP.NET Web API matches a URI to a controller and an action
* Web APIs support the full set of routing capabilities from ASP.NET (MVC)
  * Route parameters
  * Constraints (using regular expressions)
  * Extensible with own conventions
  * Attribute routing is available in version 2

<!-- attr: { showInPresentation:true, style:'' } -->
# Default Route
* Web API also provides smart conventions by default
  * We can create classes that implement Web APIs without having to explicitly write code
  * HTTP Verb is mapped to an action name

```cs
routes.MapHtpRoute(name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RoutesParameter.Optional });
```

```cs
http://localhost:1337/api/posts
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Model Binding & Formatters
* By default the Web API will bind incoming data to POCO (CLR) types
  * Will look in body, header and query string
  * ASP.NET MVC has similar model binder
* MediaTypeFormatters are used to bind both input and output
  * Mapped to content types
* Validation attributes can also be used
* To go down further into the HTTP (set headers, etc.) we can use HttpRequestMessage and HttpResponseMessage

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Demo: Create API Controller

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Return Different HTTP Code
* By default when everything is OK, we return HTTP status code 200
* Sometimes we need to return error

```cs
public HttpResponseMessage Get(int id)
{
   if (dataExists)
   {
      return Request.CreateResponse(         HttpStatusCode.OK, data);
   }   else
   {
      return Request.CreateErrorResponse(         HttpStatusCode.NotFound, "Item not found!");
   }}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# OData Query Syntax
* OData (http://odata.org) is a open specification written by Microsoft
  * Provide a standard query syntax on resources
* Implemented by WCF Data Services
* ASP.NET Web API includes automatic support for this syntax
  * Return IQueryable<T> instead of IEnumerable<T>

<!-- attr: { showInPresentation:true, style:'' } -->
# OData Query Syntax
* To enable OData queries uncomment "`config.EnableQuerySupport();`" line
* Then we can make OData queries like: "`http://localhost/Posts?$top=2&$skip=2`"

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web API Clients

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# HttpClient Model
* HttpClient is a modern HTTP client for .NET
  * Flexible and extensible API for accessing HTTP
* Has the same programming model as the ASP.NET Web API server side
  * HttpRequestMessage / HttpResponseMessage
* Uses Task pattern from .NET 4.0
  * Can use async and await keywords in .NET 4.5
* Installs with ASP.NET MVC 4
  * Can be retrieved via NuGet

<!-- attr: { showInPresentation:true, style:'' } -->
# HttpClient Example

```cs
var client = new HttpClient {
    BaseAddress = new Uri("http://localhost:28670/") };
client.DefaultRequestHeaders.Accept.Add(new
    MediaTypeWithQualityHeaderValue("application/json"));
HttpResponseMessage response =
    client.GetAsync("api/posts").Result;
if (response.IsSuccessStatusCode)
{
    var products = response.Content
        .ReadAsAsync<IEnumerable<Post>>().Result;
    foreach (var p in products)
    {
        Console.WriteLine("{0,4} {1,-20} {2}",
            p.Id, p.Title, p.CreatedOn);
    }
}
else
    Console.WriteLine("{0} ({1})",
        (int)response.StatusCode, response.ReasonPhrase);
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Demo: Consume Web API from Console Application

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Consuming Web API from JS
* Web APIs can be consumed using JavaScript via HTTP AJAX request
  * Example with jQuery:

```cs
<ol id="posts"></ol>
<script>
   $.ajax({
      url: '/api/posts',
      success: function (posts) {
         var list = $('#posts');
         for (var i = 0; i < posts.length; i++) {
            var post = posts[i];
            list.append('<li>' + post.title + '</li>');
         }
      }
   });
</script>
```
<div class="fragment balloon" style="width:250px; top:60%; left:10%">Should be encoded</div>

<!-- attr: { showInPresentation:true, style:'' } -->
# ASP.NET Web API
* http://academy.telerik.com

<!-- attr: { showInPresentation:true, style:'' } -->
# Homework
* Using ASP.NET Web API create REST services for the Student System demo from Code First presentation in the Databases course.Use high-quality code, use Repository pattern and create services for all available models.Do not use scaffolding.

<!-- attr: { showInPresentation:true, style:'' } -->
# Homework
* Using ASP.NET Web API and Entity Framework (database first or code first) create a database and web services with full CRUD (create, read, update, delete) operations for hierarchy of following classes:
  * Artists (Name, Country, DateOfBirth, etc.)
  * Albums (Title, Year, Producer, etc.)
  * Songs (Title, Year, Genre, etc.)
  * Every album has a list of artists
  * Every song has artist
  * Every album has list of songs

<!-- attr: { showInPresentation:true, style:'' } -->
# Homework (2)
* Create console application and demonstrate the use of all service operations using the HttpClient class (with both JSON and XML)
* x Create JavaScript-based single page application and consume the service to display user interface for:
  * Creating, updating and deleting artists, songs and albums (with cascade deleting)
  * Show pageable, sortable and filterable artists, songs and albums using OData

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Free Trainings @ Telerik Academy
* C# Programming @ Telerik Academy
    * csharpfundamentals.telerik.com
  * Telerik Software Academy
    * academy.telerik.com
  * Telerik Academy @ Facebook
    * facebook.com/TelerikAcademy
  * Telerik Software Academy Forums
    * forums.academy.telerik.com

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

