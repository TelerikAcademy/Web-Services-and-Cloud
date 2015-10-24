<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ASP.NET Web API
- Telerik Software Academy
- http://academy.telerik.com 
- Web Services and Cloud


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents
- What is ASP.NET Web API?
- Web API Features
- Demo: Default Project Template
- Web API Controllers
- Routes
- Demo: Create API Controller
- OData queries
- Web API Clients
- Demo: Consuming Web API
- 2


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# What is ASP.NET Web API?


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ASP.NET Web API
- Framework that makes it easy to build HTTP services for browsers and mobile devices
- Platform for building RESTful applications on the .NET Framework using ASP.NET stack
- 4


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ASP.NET Web API Role
- 5
- Data storage
- Data Layer (EF)
- ASP.NET Web API
- HTTP PUT, POST, DELETE
- JSON
- HTTP GET
- JSON
- Models
- XML
- XML


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Features
- Modern HTTP programming model
- Access to strongly typed HTTP object model
- HttpClient API – same programming model
- Content negotiation
- Client and server work together to determine the right format for data
- Provide default support for JSON, XML and Form URL-encoded formats
- We can add own formats and change content negotiation strategy
- 6


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Features (2)
- Query composition
- Support automatic paging and sorting
- Support querying via the OData URL conventions when we return IQueryable<T> 
- Model binding and validation
- Combine HTTP data in POCO models
- Data validation via attributes
- Supports the same model binding and validation infrastructure as ASP.NET MVC 
- 7


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Features (3)
- Routes (mapping between URIs and code)
- Full set of routing capabilities supported within ASP.NET (MVC)
- Filters
- Easily decorates Web API with additional validation (authorization, CORS, etc.)
- Testability
- IoC and dependency injection support
- Flexible hosting (IIS, Azure, self-hosting)
- 8


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Features (4)
- Visual Studio IDE (+templates and scaffolding)
- Reuse of C# knowledge (+task-based async)
- Custom help pages, tracing, etc.
- 9


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ASP.NET Web API 2
- Attribute routing
- OData improvements: $select, $expand, $batch, $value and improved extensibility
- Request batching
- Portable ASP.NET Web API Client
- Improved testability
- CORS (Cross-origin resource sharing)
- Authentication filters
- OWIN support and integration (owin.org)
- 10


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# WCF vs. ASP.NET Web API
- WCF is also a good framework for building HTTP based services
- 11


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Demo: Creating ASP.NET Web API Project
- Default ASP.NET Web API project template


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Controllers
- A controller is an object that handles HTTP requests
- All API controllers derive from ApiController
- By default ASP.NET Web API will map HTTP requests to specific methods called actions
- Action
- HTTP method
- Relative URI
- Method
- Get a list of all posts
- GET
- /api/posts
- Get()
- Get a post by ID
- GET
- /api/posts/id
- Get(int id)
- Create a new post
- POST
- /api/posts
- Post(PostModel value)
- Update a post
- PUT
- /api/posts/id
- Put(int id, PostModel value)
- Delete a post
- DELETE
- /api/posts/id
- Delete(int id)
- Get a post by category
- GET
- /api/posts?category=category
- Get(string category)
- 14


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Default Behavior
- 15
- Web Request
- Match a Route
- API Controller Responds
- http://localhost:1337/api/posts
- public class PostsController : ApiController
- {
-     public string Get()
-     {
-         return "Some data";    }
- }
- HTTP GET Request
- 1
- 2
- 3
- Controller Name


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Routing
- Routing is how ASP.NET Web API matches a URI to a controller and an action
- Web APIs support the full set of routing capabilities from ASP.NET (MVC)
- Route parameters
- Constraints (using regular expressions)
- Extensible with own conventions
- Attribute routing is available in version 2
- 16


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Default Route
- Web API also provides smart conventions by default
- We can create classes that implement Web APIs without having to explicitly write code
- HTTP Verb is mapped to an action name
- 17
- routes.MapHtpRoute(name: "DefaultApi",
-     routeTemplate: "api/{controller}/{id}",
-     defaults: new { id = RoutesParameter.Optional });
- http://localhost:1337/api/posts


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Model Binding & Formatters
- By default the Web API will bind incoming data to POCO (CLR) types
- Will look in body, header and query string
- ASP.NET MVC has similar model binder
- MediaTypeFormatters are used to bind both input and output
- Mapped to content types
- Validation attributes can also be used
- To go down further into the HTTP (set headers, etc.) we can use HttpRequestMessage and HttpResponseMessage
- 18


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Demo: Create API Controller


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Return Different HTTP Code
- By default when everything is OK, we return HTTP status code 200
- Sometimes we need to return error
- 20
- public HttpResponseMessage Get(int id)
- {
-    if (dataExists)
-    {
-       return Request.CreateResponse(         HttpStatusCode.OK, data);
-    }   else
-    {
-       return Request.CreateErrorResponse(         HttpStatusCode.NotFound, "Item not found!");
-    }}


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# OData Query Syntax
- OData (http://odata.org) is a open specification written by Microsoft
- Provide a standard query syntax on resources
- Implemented by WCF Data Services
- ASP.NET Web API includes automatic support for this syntax
- Return IQueryable<T> instead of IEnumerable<T>
- 21


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# OData Query Syntax
- To enable OData queries uncomment "config.EnableQuerySupport();" line
- Then we can make OData queries like: "http://localhost/Posts?$top=2&$skip=2"
- 22
- Option
- Description
- $filter
- Filters the results, based on a Boolean condition.
- $inlinecount
- Tells the server to include the total count of matching entities in the response. (Useful for server-side paging.)
- $orderby
- Sorts the results.
- $skip
- Skips the first n results.
- $top
- Returns only the first n the results.


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web API Clients


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# HttpClient Model
- HttpClient is a modern HTTP client for .NET
- Flexible and extensible API for accessing HTTP
- Has the same programming model as the ASP.NET Web API server side
- HttpRequestMessage / HttpResponseMessage
- Uses Task pattern from .NET 4.0
- Can use async and await keywords in .NET 4.5
- Installs with ASP.NET MVC 4
- Can be retrieved via NuGet
- 24


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# HttpClient Example
- 25
- var client = new HttpClient {
-     BaseAddress = new Uri("http://localhost:28670/") };
- client.DefaultRequestHeaders.Accept.Add(new
-     MediaTypeWithQualityHeaderValue("application/json"));
- HttpResponseMessage response =
-     client.GetAsync("api/posts").Result;
- if (response.IsSuccessStatusCode)
- {
-     var products = response.Content
-         .ReadAsAsync<IEnumerable<Post>>().Result;
-     foreach (var p in products)
-     {
-         Console.WriteLine("{0,4} {1,-20} {2}",
-             p.Id, p.Title, p.CreatedOn);
-     }
- }
- else
-     Console.WriteLine("{0} ({1})",
-         (int)response.StatusCode, response.ReasonPhrase);


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Demo: Consume Web API from Console Application


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Consuming Web API from JS
- Web APIs can be consumed using JavaScript via HTTP AJAX request
- Example with jQuery:
- <ol id="posts"></ol>
- <script>
-    $.ajax({
-       url: '/api/posts',
-       success: function (posts) {
-          var list = $('#posts');
-          for (var i = 0; i < posts.length; i++) {
-             var post = posts[i];
-             list.append('<li>' + post.title + '</li>');
-          }
-       }
-    });
- </script>
- 27
- Should be encoded


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ASP.NET Web API
- http://academy.telerik.com


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Homework
- Using ASP.NET Web API create REST services for the Student System demo from Code First presentation in the Databases course.Use high-quality code, use Repository pattern and create services for all available models.Do not use scaffolding.
- 29


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Homework
- Using ASP.NET Web API and Entity Framework (database first or code first) create a database and web services with full CRUD (create, read, update, delete) operations for hierarchy of following classes:
- Artists (Name, Country, DateOfBirth, etc.)
- Albums (Title, Year, Producer, etc.)
- Songs (Title, Year, Genre, etc.)
- Every album has a list of artists
- Every song has artist
- Every album has list of songs
- 30


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Homework (2)
- Create console application and demonstrate the use of all service operations using the HttpClient class (with both JSON and XML)
- * Create JavaScript-based single page application and consume the service to display user interface for:
- Creating, updating and deleting artists, songs and albums (with cascade deleting)
- Show pageable, sortable and filterable artists, songs and albums using OData
- 31


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Free Trainings @ Telerik Academy
- C# Programming @ Telerik Academy
- csharpfundamentals.telerik.com
- Telerik Software Academy
- academy.telerik.com
- Telerik Academy @ Facebook
- facebook.com/TelerikAcademy
- Telerik Software Academy Forums
- forums.academy.telerik.com
- 32


