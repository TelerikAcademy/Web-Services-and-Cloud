<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Windows Communication Foundation (WCF)
<div class="signature">
    <p class="signature-course">Telerik Software Academy</p>
    <p class="signature-initiative">http://academy.telerik.com </p>
    <a href = "Web Services & Cloud" class="signature-link">Web Services & Cloud</a>
</div>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
* WCF – Quick Introduction
* Creating a WCF Service
  * Creating a Service Contract
  * Implementing the Service Contract
  * Configuring the Service
* Hosting WCF Services (Self-Hosting and in IIS)
* Consuming WCF Services Through Proxies
  * Generating Proxies with the `svcutil.exe`
  * Adding Service Reference in Visual Studio

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents (2)
* The WCF Test Client (WcfTestClient.exe)
* Asynchronous Calls to WCF Services
* WCF RESTful Services

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Windows Communication Foundation (WCF)
##  Quick Introduction

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
* Channel Model
* Data Formats
* (RSS, JSON, XML,…)
* Data Transports
* (HTTP, TCP, MSMQ, …)
* Protocols
* (SOAP, HTTP, Open Data Protocol, …)
* Service Model
* Data Contracts
* Service Contracts
* Service  Behaviors
* Programming Model
* Core Services
* Web HTTP Services
* Data Services
* RIA Services
* Workflow Services
# Windows Communication Foundation (WCF)

<!-- attr: { showInPresentation:true, style:'' } -->
# WCF Structure: Contracts
* `Service contract`
  * Describes the service methods, parameters, and returned result
* `Data contract`
  * Describe the data types used in the contract and their members

```cs
[ServiceContract]
public interface ISumator
{
  [OperationContract]
  int Sum(int a, int b);
}
```

```cs
[DataContract]
public class Person
{
  [DataMember]
  string Name {get; set;}
}
```

<!-- attr: { showInPresentation:true, style:'' } -->
# WCF Structure: Bindings and Addressing
* Binding
  * Transport – HTTP, TCP, MSMQ, …
  * Channel type – one-way, duplex, request-reply
  * Encoding – XML, JSON, binary, MTOM
  * WS-x protocols – WS-Security, WS-Addressing, WS-ReliableMessaging, WS-Transaction, …
* Addressing
  * `http://someURI`
  * `net.tcp://someOtherURI`
  * `net.msmq://stillAnotherURI`

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Creating a WCF Service
##  Step by Step

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Using WCF: Creating and Consuming Services
* WCF is а powerful Microsoft technology stack for the SOA world
* Three steps to use WCF:
  * Create a WCF Service
    * Service contract, data contract, implementation
  * Host the WCF Service
    * Several hosting options: IIS, standalone, …
  * Consume (use, invoke) the WCF service from a client application

<!-- attr: { showInPresentation:true, style:'' } -->
# Creating a WCF Service
* To create a WCF Web Service use one of the following VS templates:
  * WCF Service Application
  * WCF Service Library
* Three steps to create WCF services:
  * Define one or more interfaces describing what our service can do (operations)
  * Implement those interfaces in one or more classes (implementation)
  * Configure the service (XML configuration file)

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Creating a WCF Service
##  Step 1: Defining a Service Contract

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Defining a Service Contract
* In order for a WCF service to be used you have to define a `service contract`
  * Defines the functionality offered by the service to the outside world
  * Describes to potential users how they communicate with the service 
* The WSDL description of the service depends on the service contract
* To define a contract create an interface marked with the `[ServiceContract]` attribute

<!-- attr: { showInPresentation:true, style:'' } -->
# Defining a Service Contract (2)
* Extensive use of attributes:
  * `ServiceContractAttribute` – for the exposed service interface
    * `OperationContractAttribute` – for the contract methods that a client can see and use
  * `DataContractAttribute` – for any classes used as parameters in a method or returned as a result from a method
    * `DataMemberAttribute` – the properties of those classes visible to the clients

<!-- attr: { showInPresentation:true, style:'' } -->
# Defining a Service Contract – Example

```cs
[ServiceContract]
public interface IServiceTest
{
  [OperationContract]
  string GetData(int value);
  [OperationContract]
  CompositeType GetDataUsingDataContract(
    CompositeType composite);
}
[DataContract]
public class CompositeType
{
  bool boolValue = true;
  string stringValue = "Hello";
  …
}
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Creating a WCF Service
##  Step 2: Implementing the Service Contract

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Implementing a WCF Service
* Once a contract is created, the functionality offered by the service has to be implemented
* We need a class that implements the interface that defines the contract 
* For example:

```cs
public class ServiceTest : IServiceTest
{
  public string GetData(int value)
  {
    return string.Format("You entered: {0}", value);
  }
  …
}
```

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Creating a WCF Service
##  Step 3: Configuring the Service

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuring Endpoints
* WCF services are visible to the outside world through the so called `endpoints`
* Each endpoint consists of three parts:
  * `Address` – the `URL `of the endpoint
    * Can be relative to the base address
  * `Binding `– the protocol over which the communication with the service is made
  * `Contract `– which service contract is visible through this endpoint

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuring Endpoints (2)
* Configure endpoints in two ways
  * In the application settings
    * By a special section `<system.serviceModel>` in the application configuration file
      * `Web.config` / `App.config`
    * The most frequently used approach
  * By C# code:

```cs
selfHost.AddServiceEndpoint(typeof(ICalculator),
  new WSHttpBinding(), "CalculatorService"); 
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuring Endpoints in Config Files
* The `<system.serviceModel>` contains many configuration options
* Two very important elements:
  * `<services> `– defines services and endpoints
  * `<service>` elements are configured by their `behaviorConfiguration` attribute
    * Points to an existing behavior
  * They have endpoint elements
    * The endpoints are configured through attributes

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuring Endpoints in Config Files – Example

```cs
<system.serviceModel>
  <services>
    <service name="WcfServiceTest.ServiceTest"
     behaviorConfiguration=
      "WcfServiceTest.ServiceTestBehavior">
      <endpoint address="" binding="wsHttpBinding"   
       contract="WcfServiceTest.IServiceTest">  
        <identity>
          <dns value="localhost"/>
        </identity>
      </endpoint>
      <endpoint address="mex" 					binding="mexHttpBinding" 				contract="IMetadataExchange"/>
  </service>
</services>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Configuring Services in Config Files
* The `serviceBehaviors` section defines behaviors (configurations) for services
* Services are configured by specifying which behavior they use
  * Many sub-elements
    * `serviceMetadata `– metadata options
    * `serviceDebug `– debug options
    * `dataContractSerializer `– controls the way data contracts are serialized
    * …

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Configuring Services in Config Files – Example

```cs
<serviceBehaviors>
  <behavior
    name="WcfServiceTest.ServiceTestBehavior">
      <serviceMetadata httpGetEnabled="true"/>
      <serviceDebug
        includeExceptionDetailInFaults="false"/>
  </behavior>
</serviceBehaviors>
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Creating andConfiguring a WCF Service -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Hosting a WCF Service

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Hosting WCF Service
* The WCF model has many hosting options
  * Self hosting
    * In a console application, Windows Forms or WPF application
    * Mainly for development and testing 
  * Windows Service
  * In IIS 5.1 (or later), 6.0 or 7.0
    * Used in production environment
  * Windows Process Activation Service (WAS)

<!-- attr: { showInPresentation:true, style:'' } -->
# Hosting a WCF Service in IIS
* Hosting WCF services in IIS is a typical scenario
  * IIS itself handles creation and initialization of the `ServiceHost` class
* We need a `x.svc` file to host in IIS
* Base content of the `.svc` file:
* It has the `ServiceHost` directive
  * Tells IIS in what language is the service written and the main class of the service

```cs
<%@ServiceHost Language="C#" Debug="true"
  Service="WcfServiceTest.ServiceTest" %>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Hosting a WCF Service in IIS (2)
* The code for the service (the contract and the class implementing it) can be stationed in three places
  * Inline – following the `ServiceHost` directive
  * In an assembly in the `Bin` directory
  * As `.cs` files in the `App_Code `directory
* You must set the necessary permissions in order for IIS to have access to your files

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Hosting WCF Services in IIS -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# The ServiceHost Class
* Hosting of the service is managed by the `ServiceHost` class
  * Located in `System.ServiceModel` namespace
  * You must have reference the `System.ServiceModel.dll` assembly
* In self-hosting scenarios we initialize and start the host ourselves

```cs
ServiceHost selfHost = new ServiceHost(
  typeof(CalculatorService), 
  new Uri("http://localhost:1234/service"));
selfHost.Open(); 
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Self-Hosting a WCF Service -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Using the WCF Test Client
* The WCF Test Client is a GUI tool for playing with WCF services
  * Enables users to input test parameters, submit that input to the service, and view the response
  * WCF Test Client (`WcfTestClient.exe`) is part of Visual Studio
    * Can be started from the VS Command Prompt
  * Typical location:
  * Starts on [F5] in VS for WCF Service Libraries

```cs
C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # WCF Test Client -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Consuming a WCF Service

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Consuming WCF Services
* To consume a WCF service we make use of the so called `proxy` `classes`
* Those look like normal classes in the code
  * When you call a method of the proxy it makes a `SOAP `request to the service
  * When the service returns the `SOAP `result the proxy transforms it to a .`NET `type
* Client
* Proxy
* WCF Service

<!-- attr: { showInPresentation:true, style:'' } -->
# Generating a Proxy Class
* `Proxy` `classes` can be generated using the  `svcutil.exe` tool
  * The simplest form (from the command line):
  * The service must be configured to allow getting its metadata
    * Via `WS-Metadata-Exchange` or `Disco`
  * The result is the `AddService.cs` class and the `output.config` file

```cs
svcutil http://localhost:8080/ServiceCalculator.svc
```

<!-- attr: { showInPresentation:true, style:'' } -->
# Generating a Proxy Class (2)
* There are many options to this command line
  * You can set the names of the generated files
  * You can set the namespace
  * Asynchronous methods generation
* The `AddService.cs` must be visible in our project
* The contents of the `output.config `must be merged with the `app.config` / `web.config` 
* No automerging is supported

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Generating a Proxy Class in VS
* In Visual Studio you can also use the "Add Service Reference" option in a project
  * It's a wrapper around `svcutil.exe`
  * A set of XML config files is generated

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Generating a Proxy Class in VS (2)
* When adding a service reference
  * Entries are added to the `web.config` or `app.config` respectively
  * Don't manipulate those entries manually unless you know what you're doing

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Using a Proxy Class
* Using proxy classes is identical to using normal classes but produces remote calls
  * You instantiate the proxy class
  * Then call its methods
  * Call the `Close()` method of the proxy
* If the interface of the service changes you have to regenerate the proxy class

```cs
AddServiceClient addSevice =
  new AddServiceClient();
int sum = addService.Add(5, 6);
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Consuming a WCF Service in Visual Studio -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Asynchronous Calls to a WCF Service

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Calling a WCF Service Asynchronously
* Sometimes a service call takes too long and we don't need the result immediately
* We can make asynchronous calls in two ways
  * By using a delegate
    * The delegate has this functionality built-in
  * By generating the proxy class with the "`svcutil /async`" option
    * Creates asynchronous methods as well
    * When adding a service reference in `Visual Studio `there is an option under `Advanced Settings`

<!-- attr: { showInPresentation:true, style:'' } -->
# Calling a WCF Service Asynchronously (2)
* When the proxy class is generated to support asynchronous calls we get few new methods
  * For every `OperationContract` method we get the `BeginXXX()` and `EndXXX()` methods
  * You can make use of the callback method

```cs
public void static Main() {
  AsyncCallback cb = new AsyncCallback(CallFinished);
  service.BeginLongProcess(params, cb, service);
}
private void CallFinished(IAsyncResult asyncResult) {
  Console.WriteLine("Async call completed.");
}
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Asynchronous WCF Calls -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# RESTful WCF Services
##  Creating and Consuming RESTful WCF Services

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# RESTful WCF Services
* In the `.svc` file add the following:
* Use special binding in `Web.config`:
* Use URL mapping in the service contract

```cs
<%@ ServiceHost Language="C#" Service="…" CodeBehind="…" Factory="System.ServiceModel.Activation.WebServiceHostFactory" %>
```

```cs
<system.serviceModel> <standardEndpoints> <webHttpEndpoint>
<standardEndpoint defaultOutgoingResponseFormat="Json" 
  helpEnabled="true" />
</webHttpEndpoint> </standardEndpoints> </system.serviceModel>
```

```cs
[OperationContract]
[WebInvoke(Method = "GET",
  UriTemplate = "Category/{categoryID}")]
Category FindCategoryByID(string categoryID);
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # RESTful WCF Services -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Windows Communication Foundation (WCF)
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

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises
* Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string. Test it with the integrated WCF client.
* Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
* Create a Web service library which accepts two string as parameters. It should return the number of times the second string contains the first string. Test it with the integrated WCF client.
* Host the latter service in IIS.
* Create a console client for the WCF service above. Use the `svcutil.exe` tool to generate the proxy classes.

