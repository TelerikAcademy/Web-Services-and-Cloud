<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web Services and SOA
##  Take the code to the Server
<div class="signature">
    <p class="signature-course">Telerik Software Academy</p>
    <p class="signature-initiative">http://academy.telerik.com </p>
    <a href = "Web Services and Cloud" class="signature-link">Web Services and Cloud</a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* The Need for Service-Oriented Applications
* Service-Oriented Architecture (SOA)
* SOA and Web 2.0
* Classical Web Services and Protocols
    * SOAP, WSDL, HTTP, XML
    * WS-MetadataExchange
* RESTful Web Services

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# The Need for Service-Oriented (SOA) Applications

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Distributed Applications
* Most of the modern applications are distributed
  * Consist of several smaller components which interact with each other
* Distributed application models
  * "Client-Server" model
  * "Distributed objects" model
    * DCOM – used in Microsoft Windows
    * CORBA – open standard, very complex
    * Java RMI – based on the Java technology
    * .NET Remoting – used in early .NET Framework
  * "Web services" / "RESTful Web services" model

<!-- attr: { showInPresentation:true, style:'' } -->
# What is a Service?
* In the real world a "`service`" is:
  * A piece of work performed by a service provider
  * Provides a client (consumer) some desired result by some input parameters
    * The requirements and the result are known
  * Easy to use
  * Always available
  * Has quality characteristics (price, execution time, constraints, etc.)

<!-- attr: { showInPresentation:true, style:'' } -->
# Service-Oriented Applications
* `Service-oriented applications` resemble the service-consumer model in the real world
  * Consist of service provider (server side) and service consumer (client part)
    * Typical examples are the RIA
  * `Service providers` provide some service
  * `Service consumers `access the services
  * Standard protocols are used like XML, JSON, SOAP, WSDL, RSS, HTTP, …

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Service-Oriented Architecture (SOA)

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# What is SOA?
* SOA (Service-oriented Architecture) is a concept for development of software systems
  * Using reusable building blocks (components) called "services"
* Services in SOA are:
  * Autonomous
  * Stateless business functions
  * Accept requests and return responses
  * Use well-defined, standard interface

<!-- attr: { showInPresentation:true, style:'' } -->
# SOA Services
* Autonomous
  * Each service operates autonomously
  * Without any awareness that other services exist
* Stateless
  * Have no memory, do not remember state
  * Easy to scale
* Request-response model
  * Client asks, server returns an answer

<!-- attr: { showInPresentation:true, style:'' } -->
# SOA Services (2)
* Communication through standard protocols
  * XML, SOAP, JSON, RSS, ...
  * HTTP, FTP, SMTP, RPC, MSMQ, ...
* Not dependent on OS, platforms, programming languages
* Discoverable
  * Service registries

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# SOA and Web 2.0

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# SOA and Web 2.0
* Moving to a "services model" – global IT trend for both:
  * Internet business
  * Inside an enterprise
* Two main SOA scenarios
  * SOA in Internet
    * Software as service, Web 2.0, RIA, ...
  * SOA inside an enterprise
    * Heavy SOA stacks: WS-x, BPM, BPEL, ESB, ...

<!-- attr: { showInPresentation:true, style:'' } -->
# SOA in Internet
* Internet companies implement `lightweight` `SOA `in Internet
  * Also called WOA (Web-Oriented Architecture)
  * Examples: 
    * Google, Amazon, Facebook, Twitter, ...
  * Tend to provide software as service
  * Based on lightweight Web standards:
    * AJAX and Rich Internet Applications (RIA)
    * REST, XML, RSS, JSON, proprietary APIs

<!-- attr: { showInPresentation:true, style:'' } -->
# SOA in Enterprises
* `Heavyweight SOA `stacks
  * Driven by business processes: BPM, BPMN, BPEL, ...
  * Enterprise application integration (EAI)
  * B2B integration
  * SOA based portals
  * Unified Frameworks: SCA and WCF
  * Enterprise Service Bus (ESB)
  * SOA governance (control)

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web Services Infrastructure
##  SOAP / WSDL / HTTP / XML

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Web Services
* Web services model real life services
  * Program components that can be accessed remotely through the Web
  * Execution model “`request-result`”
    * A `client` `requests`, the service executes the request and `delivers` a `result`
  * Use open communication standards
    * HTTP, XML, JSON and SOAP
  * Describe their interface in `WSDL` language

<!-- attr: { showInPresentation:true, style:'' } -->
# Web Services (2)
* Web services work by exchanging SOAP messages
  * Messages contain structured info: data + metadata
* Independent from the OS, the platform and the programming language
* Loosely coupled

<!-- attr: { showInPresentation:true, style:'' } -->
# Web Services Infrastructure
* The infrastructure of Web Services consists of the following components:
  * Description
    * WSDL – Web Server Definition Language
  * Metadata
    * DISCO and WS-MetadataExchange
  * Wire format
    * SOAP, XML, XSD
    * HTTP

<!-- attr: { showInPresentation:true, style:'' } -->
# WSDL Service Description
* `WSDL `(Web Services Description Language)
  * Describes what a Web service can do
    * Names of the available methods
    * Input and output parameters, returned value
    * Data types used for parameters or result
  * XML based, open standard of W3C
  * ASP.NET Web services return their WSDL when called with `?wsdl` suffix
    * http://localhost/MyService.asmx?wsdl

<!-- attr: { showInPresentation:true, style:'' } -->
# WSDL – Example

```cs
<?xml version="1.0" encoding="utf-8"?>
<definitions
 xmlns:http="http://schemas.xmlsoap.org/wsdl/http/"
 xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/"
 xmlns:s="http://www.w3.org/2001/XMLSchema"
 xmlns:s0="http://www.devbg.org/ws/MathService"
 xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/"
 xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/"
 xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/"
 targetNamespace="http://www.devbg.org/ws/MathService"
 xmlns="http://schemas.xmlsoap.org/wsdl/">
 <types> … </types>
 <message name="AddSoapIn"> … </message>
 <portType name="MathServiceSoap"> … </portType>
 <binding name="MathServiceSoap" … > … </binding>
 <service name="MathService"> … </service>
</definitions>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Discovery of Web Service
* The process of getting the service metadata (description)
* Usually a `URL `is interrogated to retrieve the metadata
* Two protocols for interrogation
  * `DISCO `– old Microsoft protocol to use with the UDDI registry idea
  * `WS-MetadataExchange `– new standardized protocol developed by Microsoft, Sun, SAP, …

<!-- attr: { showInPresentation:true, style:'' } -->
# SOAP – Request/Result Format
* `SOAP `(Simple Object Access Protocol)
  * Open XML based format for sending messages
  * Open standard of W3C
* A `SOAP message `consists of:
  * `SOAP header `– describes the parameters of the message (metadata)
  * `SOAP body `– contains the very message (data – the request or the result)
* Usually `SOAP `messages are sent over `HTTP`
  * They can bypass firewalls that way

<!-- attr: { showInPresentation:true, style:'' } -->
# SOAP Request – Example

```cs
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <CalcDistance xmlns="http://www.devbg.org/Calc">
      <startPoint>
        <x>4</x>
        <y>5</y>
      </startPoint>
      <endPoint>
        <x>7</x>
        <y>-3</y>
      </endPoint>
    </CalcDistance>
  </soap:Body>
</soap:Envelope>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# SOAP Result – Example (2)

```cs
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope
 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
 xmlns:xsd="http://www.w3.org/2001/XMLSchema"
 xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <CalcDistanceResponse
     xmlns="http://www.devbg.org/Calc/">
      <CalcDistanceResult>
        8,54400374531753
      </CalcDistanceResult>
    </CalcDistanceResponse>
  </soap:Body>
</soap:Envelope>
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# RESTful Web Services
##  Lightweight Architecture for Web Services

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# What is REST?
* “Representational state transfer (REST) is a style of software architecture for distributed hypermedia systems such as the World Wide Web.”
* http://en.wikipedia.org/wiki/Representational_State_Transfer
* Application state and functionality are resources 
* Every resource has an URI
* All resources share a uniform interface
* This natively maps to the HTTP protocol

<!-- attr: { showInPresentation:true, style:'' } -->
# RESTful Services
* One URI for a resource, multiple operations
  * Add a new document "`RestTalk`" in category "`Code`"
    * POST http://mysite.com/docs/Code/RestTalk
  * Get the document / some page
    * GET http://mysite.com/docs/Code/RestTalk
    * GET http://mysite.com/docs/Code/RestTalk/pages/3
  * Remove the document
    * DELETE http://mysite.com/docs/Code/RestTalk
  * Retrieve metadata
    * HEAD http://mysite.com/docs/Code/RestTalk

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# XML, JSON, RSS
##  Comparing the Common Service Data Formats

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# XML
* XML is markup-language for encoding documents in machine-readable form
  * Text-based format
  * Consists of tags, attributes and content
  * Provide data and meta-data in the same time

```cs
<?xml version="1.0"?>
<library>
  <book><title>HTML 5</title><author>Bay Ivan</author></book>
  <book><title>WPF 4</title><author>Microsoft</author></book>
  <book><title>WCF 4</title><author>Kaka Mara</author></book>
  <book><title>UML 2.0</title><author>Bay Ali</author></book>
</library>
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# JSON
* JSON (JavaScript Object Notation)
  * Standard for representing simple data structures  and associative arrays
  * Lightweight text-based open standard
  * Derived from the JavaScript language 

```cs
{
  "firstName": "John", "lastName": "Smith", "age": 25,
  "address": { "streetAddress": "33 Alex. Malinov Blvd.",
     "city": "Sofia", "postalCode": "10021" },
  "phoneNumber": [{ "type": "home", "number": "212 555-1234"},
    { "type": "fax", "number": "646 555-4567" }]
},
{ "firstName": "Bay", "lastName": "Ivan", "age": 79 }
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# RSS
* RSS (Really Simple Syndication)
  * Family of Web feed formats for		 publishing frequently updated works
    * E.g. blog entries, news headlines, videos, etc.
  * Based on XML, with standardized XSD schema
* RSS documents (feeds) are list of items
  * Each containing title, author, publish date, summarized text, and metadata
* Atom protocol aimed to enhance / replace RSS

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# RSS – Example

```cs
<?xml version="1.0" encoding="utf-8" ?>
<rss version="2.0">
<channel>
  <title>W3Schools Home Page</title>
  <link>http://www.w3schools.com</link>
  <description>Free web building tutorials</description>
  <item>
    <title>RSS Tutorial</title>
    <link>http://www.w3schools.com/rss</link>
    <description>New RSS tutorial on W3Schools</description>
  </item>
  <item>
    <title>XML Tutorial</title>
    <link>http://www.w3schools.com/xml</link>
    <description>New XML tutorial on W3Schools</description>
  </item>
</channel>
</rss>
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# SOA Architecture

<!-- attr: { showInPresentation:true, style:'' } -->
# Service-oriented Architecture
* SOA is build on the request-response pattern
* Architecture decoupling application's business and UI logic 
  * Business logic on a server 
    * In the form of web services
  * UI logic on the client
    * Web client, desktop client, mobile client
    * Written in JavaScript, C#, Java, PHP, etc…

<!-- attr: { showInPresentation:true, style:'' } -->
* The business logic (app logic) is located on a server
  * The client accesses the business logic by sending a request
  * The server receives the request, computes it and returns to the client a response
  * The client updates its UI based on the server response
# Service-oriented Architecture (2)

<!-- attr: { showInPresentation:true, style:'' } -->
# Service-oriented Architecture (3)

```cs
Server
```

```cs
Auth
```

```cs
Register
```

```cs
Login
```

```cs
Operations
```

```cs
Users
```

```cs
Add User
```

```cs
Remove User
```

```cs
Web Client
```

```cs
$.post("server/register",       credentials, 'json');
```

```cs
$.post("server/login",         credentials, 'json');
```

```cs
$.getJSON("server/users");
```

```cs
Desktop client
```

```cs
httpRequest = 
  HttpRequest.create("server/users");
response = httpRequest.getResponse();
//parse response to C# objects
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Web Service Clients

<!-- attr: { showInPresentation:true, style:'' } -->
# Web Service Clients
* Web service clients can be of any type or in any platform
  * If not explicitly limited
* REST services can be access by JavaScript, C#, Java, Node.js or any other language
* RESTful web services provide a high level of code reusability
  * Code the business logic once, develop clients for different applications

<!-- attr: { showInPresentation:true, style:'' } -->
# Web Services, RESTful Web Services and SOA
* Questions?
* ?
* ?
* `?`
* ?
* ?
* ?
* ?
* ?
* ?
* ?

