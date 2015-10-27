<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Windows Communication Foundation (WCF)
- Telerik Software Academy
- http://academy.telerik.com 
- Web Services & Cloud


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents
- WCF – Quick Introduction
- Creating a WCF Service
- Creating a Service Contract
- Implementing the Service Contract
- Configuring the Service
- Hosting WCF Services (Self-Hosting and in IIS)
- Consuming WCF Services Through Proxies
- Generating Proxies with the svcutil.exe
- Adding Service Reference in Visual Studio
- 2


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents (2)
- The WCF Test Client (WcfTestClient.exe)
- Asynchronous Calls to WCF Services
- WCF RESTful Services
- 3


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Windows Communication Foundation (WCF)
- Quick Introduction


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Channel Model
- Data Formats
- (RSS, JSON, XML,…)
- Data Transports
- (HTTP, TCP, MSMQ, …)
- Protocols
- (SOAP, HTTP, Open Data Protocol, …)
- Service Model
- Data Contracts
- Service Contracts
- Service  Behaviors
- Programming Model
- Core Services
- Web HTTP Services
- Data Services
- RIA Services
- Workflow Services
- Windows Communication Foundation (WCF)
- 5


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# WCF Structure: Contracts
- Service contract
- Describes the service methods, parameters, and returned result
- Data contract
- Describe the data types used in the contract and their members
- 6
- [ServiceContract]
- public interface ISumator
- {
-   [OperationContract]
-   int Sum(int a, int b);
- }
- [DataContract]
- public class Person
- {
-   [DataMember]
-   string Name {get; set;}
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# WCF Structure: Bindings and Addressing
- Binding
- Transport – HTTP, TCP, MSMQ, …
- Channel type – one-way, duplex, request-reply
- Encoding – XML, JSON, binary, MTOM
- WS-* protocols – WS-Security, WS-Addressing, WS-ReliableMessaging, WS-Transaction, …
- Addressing
- http://someURI
- net.tcp://someOtherURI
- net.msmq://stillAnotherURI
- 7


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating a WCF Service
- Step by Step


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Using WCF: Creating and Consuming Services
- WCF is а powerful Microsoft technology stack for the SOA world
- Three steps to use WCF:
- Create a WCF Service
- Service contract, data contract, implementation
- Host the WCF Service
- Several hosting options: IIS, standalone, …
- Consume (use, invoke) the WCF service from a client application
- 9


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating a WCF Service
- To create a WCF Web Service use one of the following VS templates:
- WCF Service Application
- WCF Service Library
- Three steps to create WCF services:
- Define one or more interfaces describing what our service can do (operations)
- Implement those interfaces in one or more classes (implementation)
- Configure the service (XML configuration file)
- 10


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating a WCF Service
- Step 1: Defining a Service Contract


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Defining a Service Contract
- In order for a WCF service to be used you have to define a service contract
- Defines the functionality offered by the service to the outside world
- Describes to potential users how they communicate with the service 
- The WSDL description of the service depends on the service contract
- To define a contract create an interface marked with the [ServiceContract] attribute
- 12


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Defining a Service Contract (2)
- Extensive use of attributes:
- ServiceContractAttribute – for the exposed service interface
- OperationContractAttribute – for the contract methods that a client can see and use
- DataContractAttribute – for any classes used as parameters in a method or returned as a result from a method
- DataMemberAttribute – the properties of those classes visible to the clients
- 13


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Defining a Service Contract – Example
- 14
- [ServiceContract]
- public interface IServiceTest
- {
-   [OperationContract]
-   string GetData(int value);
-   [OperationContract]
-   CompositeType GetDataUsingDataContract(
-     CompositeType composite);
- }
- [DataContract]
- public class CompositeType
- {
-   bool boolValue = true;
-   string stringValue = "Hello";
-   …
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating a WCF Service
- Step 2: Implementing the Service Contract


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Implementing a WCF Service
- Once a contract is created, the functionality offered by the service has to be implemented
- We need a class that implements the interface that defines the contract 
- For example:
- 16
- public class ServiceTest : IServiceTest
- {
-   public string GetData(int value)
-   {
-     return string.Format("You entered: {0}", value);
-   }
-   …
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating a WCF Service
- Step 3: Configuring the Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Endpoints
- WCF services are visible to the outside world through the so called endpoints
- Each endpoint consists of three parts:
- Address – the URL of the endpoint
- Can be relative to the base address
- Binding – the protocol over which the communication with the service is made
- Contract – which service contract is visible through this endpoint
- 18


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Endpoints (2)
- Configure endpoints in two ways
- In the application settings
- By a special section <system.serviceModel> in the application configuration file
- Web.config / App.config
- The most frequently used approach
- By C# code:
- 19
- selfHost.AddServiceEndpoint(typeof(ICalculator),
-   new WSHttpBinding(), "CalculatorService"); 


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Endpoints in Config Files
- The <system.serviceModel> contains many configuration options
- Two very important elements:
- <services> – defines services and endpoints
- <service> elements are configured by their behaviorConfiguration attribute
- Points to an existing behavior
- They have endpoint elements
- The endpoints are configured through attributes
- 20


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Endpoints in Config Files – Example
- 21
- <system.serviceModel>
-   <services>
-     <service name="WcfServiceTest.ServiceTest"
-      behaviorConfiguration=
-       "WcfServiceTest.ServiceTestBehavior">
-       <endpoint address="" binding="wsHttpBinding"   
-        contract="WcfServiceTest.IServiceTest">  
-         <identity>
-           <dns value="localhost"/>
-         </identity>
-       </endpoint>
-       <endpoint address="mex" 					binding="mexHttpBinding" 				contract="IMetadataExchange"/>
-   </service>
- </services>


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Services in Config Files
- The serviceBehaviors section defines behaviors (configurations) for services
- Services are configured by specifying which behavior they use
- Many sub-elements
- serviceMetadata – metadata options
- serviceDebug – debug options
- dataContractSerializer – controls the way data contracts are serialized
- …
- 22


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring Services in Config Files – Example
- 23
- <serviceBehaviors>
-   <behavior
-     name="WcfServiceTest.ServiceTestBehavior">
-       <serviceMetadata httpGetEnabled="true"/>
-       <serviceDebug
-         includeExceptionDetailInFaults="false"/>
-   </behavior>
- </serviceBehaviors>


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating andConfiguring a WCF Service
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Hosting a WCF Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Hosting WCF Service
- The WCF model has many hosting options
- Self hosting
- In a console application, Windows Forms or WPF application
- Mainly for development and testing 
- Windows Service
- In IIS 5.1 (or later), 6.0 or 7.0
- Used in production environment
- Windows Process Activation Service (WAS)
- 26


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Hosting a WCF Service in IIS
- Hosting WCF services in IIS is a typical scenario
- IIS itself handles creation and initialization of the ServiceHost class
- We need a *.svc file to host in IIS
- Base content of the .svc file:
- It has the ServiceHost directive
- Tells IIS in what language is the service written and the main class of the service
- 27
- <%@ServiceHost Language="C#" Debug="true"
-   Service="WcfServiceTest.ServiceTest" %>


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Hosting a WCF Service in IIS (2)
- The code for the service (the contract and the class implementing it) can be stationed in three places
- Inline – following the ServiceHost directive
- In an assembly in the Bin directory
- As .cs files in the App_Code directory
- You must set the necessary permissions in order for IIS to have access to your files
- 28


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Hosting WCF Services in IIS
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The ServiceHost Class
- Hosting of the service is managed by the ServiceHost class
- Located in System.ServiceModel namespace
- You must have reference the System.ServiceModel.dll assembly
- In self-hosting scenarios we initialize and start the host ourselves
- 30
- ServiceHost selfHost = new ServiceHost(
-   typeof(CalculatorService), 
-   new Uri("http://localhost:1234/service"));
- selfHost.Open(); 


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Self-Hosting a WCF Service
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Using the WCF Test Client
- The WCF Test Client is a GUI tool for playing with WCF services
- Enables users to input test parameters, submit that input to the service, and view the response
- WCF Test Client (WcfTestClient.exe) is part of Visual Studio
- Can be started from the VS Command Prompt
- Typical location:
- Starts on [F5] in VS for WCF Service Libraries
- 32
- C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# WCF Test Client
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Consuming a WCF Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Consuming WCF Services
- To consume a WCF service we make use of the so called proxy classes
- Those look like normal classes in the code
- When you call a method of the proxy it makes a SOAP request to the service
- When the service returns the SOAP result the proxy transforms it to a .NET type
- 35
- Client
- Proxy
- WCF Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Generating a Proxy Class
- Proxy classes can be generated using the  svcutil.exe tool
- The simplest form (from the command line):
- The service must be configured to allow getting its metadata
- Via WS-Metadata-Exchange or Disco
- The result is the AddService.cs class and the output.config file
- 36
- svcutil http://localhost:8080/ServiceCalculator.svc


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Generating a Proxy Class (2)
- There are many options to this command line
- You can set the names of the generated files
- You can set the namespace
- Asynchronous methods generation
- The AddService.cs must be visible in our project
- The contents of the output.config must be merged with the app.config / web.config 
- No automerging is supported
- 37


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Generating a Proxy Class in VS
- In Visual Studio you can also use the "Add Service Reference" option in a project
- It's a wrapper around svcutil.exe
- A set of XML config files is generated
- 38


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Generating a Proxy Class in VS (2)
- When adding a service reference
- Entries are added to the web.config or app.config respectively
- Don't manipulate those entries manually unless you know what you're doing
- 39


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Using a Proxy Class
- Using proxy classes is identical to using normal classes but produces remote calls
- You instantiate the proxy class
- Then call its methods
- Call the Close() method of the proxy
- If the interface of the service changes you have to regenerate the proxy class
- 40
- AddServiceClient addSevice =
-   new AddServiceClient();
- int sum = addService.Add(5, 6);


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Consuming a WCF Service in Visual Studio
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Asynchronous Calls to a WCF Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Calling a WCF Service Asynchronously
- Sometimes a service call takes too long and we don't need the result immediately
- We can make asynchronous calls in two ways
- By using a delegate
- The delegate has this functionality built-in
- By generating the proxy class with the "svcutil /async" option
- Creates asynchronous methods as well
- When adding a service reference in Visual Studio there is an option under Advanced Settings
- 43


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Calling a WCF Service Asynchronously (2)
- When the proxy class is generated to support asynchronous calls we get few new methods
- For every OperationContract method we get the BeginXXX() and EndXXX() methods
- You can make use of the callback method
- 44
- public void static Main() {
-   AsyncCallback cb = new AsyncCallback(CallFinished);
-   service.BeginLongProcess(params, cb, service);
- }
- private void CallFinished(IAsyncResult asyncResult) {
-   Console.WriteLine("Async call completed.");
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Asynchronous WCF Calls
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# RESTful WCF Services
- Creating and Consuming RESTful WCF Services


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# RESTful WCF Services
- In the .svc file add the following:
- Use special binding in Web.config:
- Use URL mapping in the service contract
- 47
- <%@ ServiceHost Language="C#" Service="…" CodeBehind="…" Factory="System.ServiceModel.Activation.WebServiceHostFactory" %>
- <system.serviceModel> <standardEndpoints> <webHttpEndpoint>
- <standardEndpoint defaultOutgoingResponseFormat="Json" 
-   helpEnabled="true" />
- </webHttpEndpoint> </standardEndpoints> </system.serviceModel>
- [OperationContract]
- [WebInvoke(Method = "GET",
-   UriTemplate = "Category/{categoryID}")]
- Category FindCategoryByID(string categoryID);


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# RESTful WCF Services
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Windows Communication Foundation (WCF)
- Questions?
- ?
- ?
- ?
- ?
- ?
- ?
- ?
- ?
- ?
- ?


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Exercises
- Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string. Test it with the integrated WCF client.
- Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
- Create a Web service library which accepts two string as parameters. It should return the number of times the second string contains the first string. Test it with the integrated WCF client.
- Host the latter service in IIS.
- Create a console client for the WCF service above. Use the svcutil.exe tool to generate the proxy classes.
- 50


