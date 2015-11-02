<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Consuming Web Services
##  Using Different C# APIs
<div class="signature">
    <p class="signature-course">Web Services and Cloud</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>


<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents
* Consuming Web Services
* Performing GET requests
  * The WebClient class
* Performing ANY requests
  * Using `System.Net.WebRequest` and `HttpWebRequest`
* Working with JSON and XML POST data
  * JSON.NET and XDocument


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# JSON.NET


<!-- attr: { showInPresentation:true, style:'' } -->
# JSON.NET
* JSON.NET is a popular open source .NET framework for working with JSON data
* JSON.NET supports:
  * Serializing .NET objects into JSON objects
  * Deserializing JSON objects into .NET objects
  * LINQ to JSON
  * Converting JSON data to and from XML
* JSON.NET is included in many projects, like:
  * ASP.NET Web API for serialization
  * ASP.NET SignalR


<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Working with JSON.NET


<!-- attr: { showInPresentation:true, style:'' } -->
# Serializing and Deserializing .NET Objects
* Serialization and deserialization of objects is done using methods of the `JsonConvert` class

```cs
var person = new Person()
    { FirstName = "Doncho", LastName = "Minkov", Age = 24 };
var personJSON = JsonConvert.SerializeObject(person);
Console.WriteLine(personJSON);
// out: {"FirstName":"Doncho","LastName":"Minkov","Age":24}

Person personDeserialized = JsonConvert
    .DeserializeObject<Person>(personJSON);
Console.WriteLine(personDeserialized.FullName);
// out: Doncho Minkov
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Consuming Web Services with `C#`


<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# Consuming Web Services
* Using `WebClient`
  * One-line-of-code GET and POST HTTP requests
  * Kind of strange for the other HTTP requests
* Using `HttpWebRequest`
  * More configurable than WebClient
  * Nice way of performing ANY HTTP requests
* Using `HttpClient` with `HttpRequestMessage`
  * Look like a native HTTP request
  * Obsoletes `HttpWebRequest` in .NET 4.5
    * Better async operations

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# WebClient

<!-- attr: { showInPresentation:true, style:'' } -->
# WebClient
* `WebClient` is a C# class used for communication with web services/resources
  * Works for ANY HTTP requests methods
    * Yet works best for GET and POST
  * One-line-of-code requests

```cs
var webClient = new WebClient();

//perform GET HTTP request on serviceUrl
webClient.DownloadString(serviceUrl);

//perform POST HTTP request with data on serviceUrl
//data should be serialized to string
webClient.UploadString(serviceUrl, data);

```

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Simple WebClient Requests -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuration of WebClient
* `WebClient` can be configured to work with the full power of REST services
  * ANY HTTP requests
    * GET, POST, PUT, DELETE, etc…
  * Adding HTTP Headers
    * ContentType, Accept, Cache, etc…
  * Sync and async calls
  * Authentication credentials

<!-- attr: { showInPresentation:true, style:'' } -->
<!-- # Configuration of WebClient -->
* `WebClient` supports ANY HTTP request types
  * `DownloadString()` for GET
  * `UploadString()` for others

```cs
var webClient = new WebClient();

//perform GET HTTP request on serviceUrl
webClient.DownloadString(serviceUrl);

//perform POST HTTP request with data on serviceUrl
//data should be serialized to string
webClient.UploadString(serviceUrl, data);

//perform DELETE HTTP request with data on serviceUrl
//data should be empty
webClient.UploadString(serviceUrl, "DELETE", "");
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Making Requests with WebClient -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# The HttpWebRequest Class

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# HttpWebRequest
* WebClient is good, but kind of hard to play with REST
* `HttpWebRequest` is a class that can access the full power of REST in an easy-to-use way
  * Much more easily configurable than `WebClient`

```cs
//create the HTTP request
var req = WebRequest.Create(resourceUrl) as HttpWebRequest;
//configure the HTTP request
req.ContentType = "application/json";
req.Method = "GET";
//send the request
var response = req.GetResponse();
//read the response body
```
<div class="fragments balloon" style="width:200px; top:68%; left:65%">Needs a cast to HttpWebRequest</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Performing a Request with HttpWebRequest -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Working with HttpWebRequest 
* How does `HttpWebRequest` work?
  * The client (the C# app) builds a HTTP request object
    * Wrapped in a `HttpWebRequest` object
  * The client sends the HTTP request to the server
    * Through the `GetResponse()` method
  * Then the server returns a response
    * Wrapped in a `WebResponse` object
  * Accessing the request/response body happens through a `Stream`

<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# Request/Response body access
* `HttpWebRequest `& `WebResponse` have bodies
  * Data sent to/received from the server
    * e.g. in a POST request
  * `GetRequestStream()`/`GetResponseStream()`
* A `Stream` can be read/written with a `StreamReader`/`StreamWriter`

```cs
...
var writer = new StreamWriter(request.GetRequestStream());
writer.Write(dataString);
writer.Close(); //or put the writer in a using directive
var response = request.GetResponse();
var reader = new StreamReader(response.GetResponseStream());
Console.WriteLine(reader.ReadToEnd());
reader.Close(); //or put the reader in a using directive
```


<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# GET with HttpWebRequest
* Making GET requests
  * Set the requested content type
    * e.g. "application/json"
  * Set the request method to `GET`
  * Call `GetResponse()` and process the data
    * E.g. use JSON.NET to deserialize to an object

```cs
public static void Get(string resUrl)
{
  var request = WebRequest.Create(resUrl) as HttpWebRequest;
  request.ContentType = "application/json";
  request.Method = "GET";
  request.GetResponse();
  ...
}
```
<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# POST with HttpWebRequest
* POST request – similar to GET request, except
  * Different method ("`POST`")
  * Set request body (write to the request stream)

```cs
public static void Post(string resUrl, object data)
{
  var request = WebRequest.Create(resUrl) as HttpWebRequest;
  request.ContentType = "application/json";
  request.Method = "POST";
  var jsonData = JsonConvert.SerializeObject(data);
  using (StreamWriter writer = 
      new StreamWriter(request.GetRequestStream()))
  {
    writer.Write(jsonData);
  }
  request.GetResponse();
  ...
}
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Class for  GET and POST HTTP Requests -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# HttpClient and HttpRequestMessage
##  The new APIs in .NET


<!-- attr: { showInPresentation:true, style:'' } -->
# HttpClient
* Modern HTTP client for .NET
* Flexible API for accessing HTTP resources
* Has ONLY async methods
  * Using the new async APIs
* Sends and receives HTTP requests and responses
  * `HttpRequestMessage`, `HttpResponseMessage`
  * Responses/requests are accessed ONLY async
* Can have defaults configured for requests


<!-- attr: { showInPresentation:true, style:'font-size:0.9em' } -->
<!-- # HttpClient -->
* Methods for directly sending GET, POST, PUT and DELETE requests
  * For commonly used requests
  * No need to construct the request from scratch

```cs
static async void PrintStudents(HttpClient httpClient)
{
  var response = await httpClient.GetAsync("students");
  Console.WriteLine(await response.Content.ReadAsStringAsync());
}
static void Main(string[] args)
{
  var httpClient = new HttpClient();
  httpClient.BaseAddress = new Uri("http://localhost:7232/api/");
  PrintStudents(httpClient);
  Console.WriteLine("Press Enter to exit");
  Console.ReadLine();
}
```


<!-- attr: { showInPresentation:true, style:'' } -->
# HttpContent
* `HttpContent` defines the request/response
  * Contains the body
  * Contains the `ContentType` header
  * Can be set with several content classes
    * **StringContent**, **StreamContent**, **BlockContent**…
  * Essential for POST and similar requests

```cs
HttpContent postContent = new
  StringContent(JsonConvert.SerializeObject(theStudent));

postContent.Headers.ContentType = new System.Net.Http
  .Headers.MediaTypeHeaderValue("application/json");
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Simple HttpClient Requests -->
##  [Demo]()


<!-- attr: { showInPresentation:true, style:'' } -->
# HttpRequestMessage
* Full flexibility of defining an HTTP request
* Basically access to low-level request options
* Sent by an `HttpClient`
  * `SendAsync()` method


<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Complex Requests with HttpClient & HttpRequestMessage -->
##  [Demo]()


<!-- section start -->
<!-- attr: { id:'questions', class:'slide-section', showInPresentation:true } -->
<!-- # Questions -->
## Consuming Web Services
[link to Telerik Academy Forum](http://telerikacademy.com/Forum/Category/58/web-services-and-cloud)

