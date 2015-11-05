<!-- section start -->

<!-- attr: { class:'slide-title', hasScriptWrapper:true, } -->
#   Windows Communication Foundation (WCF)
##  Creating web services

<div class="signature">
    <p class="signature-course">Telerik Software Academy</p>
    <p class="signature-initiative">http://academy.telerik.com </p>
    <a href = "Web Services and Cloud" class="signature-link">Web Services and Cloud</a>
</div>

<!-- section start -->

#   Table of Contents

*   WCF - Quick Introduction
    *   Creating a WCF Service
    *   Creating a Service Contract
    *   Implementing the Service Contract
    *   Configuring the Service
*   Hosting WCF Services (Self-Hosting and in IIS)
*   WCF RESTful Services

<!-- section start -->

<!-- attr: {class:"slide-section"} -->
#   Windows Communication Foundation (WCF)
##  Quick Introduction

#   Channel Model

*   Data Formats
    *   (RSS, JSON, XML,…)
*   Data Transports
    *   (HTTP, TCP, MSMQ, …)
*   Protocols
    *   (SOAP, HTTP, Open Data Protocol, …)
*   Service Model
    *   Data Contracts
    *   Service Contracts
    *   Service  Behaviors

#   Channel Model

*   Programming Model
    *   Core Services
    *   Web HTTP Services
    *   Data Services
    *   RIA Services
    *   Workflow Services
*   Windows Communication Foundation (WCF)

#   WCF Structure: Contracts

*   Service contract
    *   Describes the service methods, parameters, and returned result

    ```cs
    [ServiceContract]
    public interface ISumator
    {
      [OperationContract]
      int Sum(int a, int b);
    }
    ```

#   WCF Structure: Contracts

*   Data contract
    *   Describe the data types used in the contract and their members

    ```cs
    [DataContract]
    public class Person
    {
      [DataMember]
      string Name {get; set;}
    }
    ```

#   WCF Structure: Bindings and Addressing

*   Binding
    *   Transport - HTTP, TCP, MSMQ, …
    *   Channel type - one-way, duplex, request-reply
    *   Encoding - XML, JSON, binary, MTOM
    *   WS-* protocols - WS-Security, WS-Addressing, WS-ReliableMessaging, WS-Transaction, …
    *   Addressing:
        ```cs
        http://someURI
        net.tcp://someOtherURI
        net.msmq://stillAnotherURI
        ```

<!-- section start -->

<!-- attr: {class:"slide-section"} -->
#   Creating a WCF Service
##  Step by Step

#   Using WCF: Creating and Consuming Services

*   WCF is а powerful Microsoft technology stack for the SOA world
*   Three steps to use WCF:
    1.   Create a WCF Service
      *   Service contract, data contract, implementation
    2.   Host the WCF Service
      *   Several hosting options: IIS, standalone, …
    3.   Consume (use, invoke) the WCF service from a client application

#   Creating a WCF Service

*   To create a WCF Web Service use one of the following VS templates:
    *   WCF Service Application
    *   WCF Service Library
*   Three steps to create WCF services:
    1.   Define one or more interfaces describing what our service can do (operations)
    2.   Implement those interfaces in one or more classes (implementation)
    3.   Configure the service (XML configuration file)

<!-- attr: {class:"slide-section"} -->
#   Defining a Service Contract
##  Step 1 of creating a WCF Service

#   Defining a Service Contract

*   In order for a WCF service to be used you have to define a service contract
    *   Defines the functionality offered by the service to the outside world
    *   Describes to potential users how they communicate with the service
*   The WSDL description of the service depends on the service contract
*   To define a contract create an interface marked with the `[ServiceContract]` attribute

#   Defining a Service Contract

*   WCF uses attributes extensively:
    *   `[ServiceContract]` - for the exposed service interface
    *   `[OperationContract]` - for the contract methods that a client can see and use
    *   `[DataContract]` - for any classes used as parameters in a method or returned as a result from a method
    *   `[DataMember]` - the properties of those classes visible to the clients

#   Defining a Service Contract - Example

*  _Example_ creating a servie that returns data
    *   The service contract:

    ```cs
    [ServiceContract]
    public interface IServiceTest
    {
      [OperationContract]
      string GetData(int value);

      [OperationContract]
      CompositeType GetDataUsingDataContract(CompositeType composite);
    }
    ```

#   Defining a Service Contract - Example

*  _Example_ creating a servie that returns data
  * The data contract

    ```cs
    [DataContract]
    public class CompositeType
    {
      bool boolValue = true;
      string stringValue = "Hello";      
    }
    ```

<!-- attr: {class:"slide-section"} -->
#   Implementing the Service Contract
##  Step 2 of creating a WCF service

#   Implementing a WCF Service

*   Once a contract is created, the functionality offered by the service has to be implemented
    *   We need a class that implements the interface that defines the contract
    *   _Example:_

    ```cs
    public class ServiceTest : IServiceTest
    {
      public string GetData(int value)
      {
        return string.Format("You entered: {0}", value);
      }
    }
    ```

<!-- attr: {class:"slide-section"} -->
#   Configuring the Service
##  Step 3 of creating a WCF service

#   Configuring Endpoints

*   WCF services are visible to the outside world through the so called **endpoints**
*   Each endpoint consists of three parts:
    *   **Address** - the URL of the endpoint
        *   Can be relative to the base address
    *   **Binding** - the protocol over which the communication with the service is made
    *   **Contract** - which service contract is visible through this endpoint

<!-- attr: {hasScriptWrapper: true} -->
#   Configuring Endpoints

*   Configure endpoints in two ways
    *   In the application settings
        *   `Web.config` / `App.config`
        *   In a section `<system.serviceModel>` in the application configuration file
        *   The most frequently used approach
    *   By C#   code:

    ```cs
    selfHost.AddServiceEndpoint(typeof(ICalculator),
                              new WSHttpBinding(),
                              "CalculatorService")
    ```

#   Configuring Endpoints in Config Files

*   The `&lt;system.serviceModel>` contains many configuration options
*   There are two very important elements for WCF:
    *   `&lt;services>` - defines **services** and **endpoints**
    *   `&lt;service>` elements are configured by their `behaviorConfiguration` attribute
        *   Points to an existing behavior
        *   They have endpoint elements
        *   The endpoints are configured through attributes

<!-- attr: {hasScriptWrapper: true} -->
#   Configuring Endpoints in Config Files - Example

*   _Example_ confuring endpoints:

```xml
<system.serviceModel>
  <services>
    <service name="WcfServiceTest.ServiceTest" behaviorConfiguration="WcfServiceTest.ServiceTestBehavior">
      <endpoint address="" binding="wsHttpBinding" contract="WcfServiceTest.IServiceTest">  
        <identity>
          <dns value="localhost"/>
        </identity>
      </endpoint>
      <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>
    </service>
  </services>
```

#   Configuring Services in Config Files

*   The `serviceBehaviors` section defines behaviors (configurations) for services:
*   Services are configured by specifying which behavior they use
*   Many sub-elements
    *   `serviceMetadata` - metadata options
    *   `serviceDebug` - debug options
    *   `dataContractSerializer` - controls the way data contracts are serialized

<!-- attr: { hasScriptWrapper: true} -->
#   Configuring Services in Config Files - Example

*   _Example_ configuring services

```xml
<serviceBehaviors>
  <behavior name="WcfServiceTest.ServiceTestBehavior">
    <serviceMetadata httpGetEnabled="true"/>
    <serviceDebug includeExceptionDetailInFaults="false"/>
  </behavior>
</serviceBehaviors>
```

<!-- section start -->

<!-- attr: {class:"slide-section"} -->
#   Hosting WCF Service
##  Self-hosted, IIS

#   Hosting WCF Service

*   The WCF model has many hosting options
    *   Self hosting
        *   In a console application, Windows Forms or WPF application
        *   Mainly for development and testing
    *   Windows Service
    *   In IIS 5.1 (or later), 6.0 or 7.0
        *   Used in production environment
*   Windows Process Activation Service (WAS)

#   Hosting a WCF Service in IIS

*   Hosting WCF services in IIS is a typical scenario
    *   IIS itself handles creation and initialization of the ServiceHost class
    *   We need a SVC file to host in IIS
    *   Base content of the .svc file:

```xml
<%@ServiceHost Language="C#" Debug="true" Service="WcfServiceTest.ServiceTest" %>
```

*   It has the ServiceHost directive
*   Tells IIS in what language is used for the service and the main class of the service

#   Hosting a WCF Service in IIS

*   The code for the service (the contract and the class implementing it) can be stationed in three places
    *   Inline - following the ServiceHost directive
    *   In an assembly in the Bin directory
    *   As CS files in the `App_Code` directory
*   You must set the necessary permissions in order for IIS to have access to your files

<!-- section start -->

<!-- attr: {class:"slide-section"} -->
#   RESTful WCF Services
##  Creating and Consuming RESTful WCF Services

<!-- attr: {hasScriptWrapper: true, style: 'font-size: 40px'} -->
#   RESTful WCF Services

*   To make a WCF Service RESTful, follow the steps:
    *   Add service behavior in `<system.serviceModel>`:      

    ```xml
    <serviceBehaviors>
       <behavior name="restfulServiceBehavior">
         <serviceMetadata httpGetEnabled="true"/>
         <serviceDebug includeExceptionDetailInFaults="true" />
       </behavior>
     </serviceBehaviors>
    ```

    *   Add endpoint behavior in `<system.serviceModel>`:

    ```xml
    <endpointBehaviors>
     <behavior name="restfulEndpointBehavior">
       <webHttp />
     </behavior>
    </endpointBehaviors>
   ```

<!-- attr: {hasScriptWrapper: true} -->
#   RESTful WCF Services

*   To make a WCF Service RESTful, follow the steps:
     *    Add a service with these behaviors:

```xml
<service name="Research_Wcf.BookService" behaviorConfiguration="restfulServiceBehavior">
 <endpoint address=""
           behaviorConfiguration="restfulEndpointBehavior"
           binding="webHttpBinding"
           bindingConfiguration=""
           contract="Research_Wcf.IBooksService" />
 <host>
   <baseAddresses>
     <add baseAddress="http://localhost/bookservice"/>
   </baseAddresses>
 </host>
</service>
```

#   RESTful WCF Services

*   To make a WCF Service RESTful, follow the steps:
    *    Use URL mapping in the service contract

```cs
[OperationContract]
[WebInvoke(Method = "GET", UriTemplate = "Category/{categoryID}")]
Category FindCategoryByID(string categoryID);
```

*   Each service must be registered in `Web.config`

<!-- attr: {class: "slide-section"} -->
#   RESTful WCF Services
##  [Demo](http://)

<!-- attr: {class: "slide-questions"} -->
#   Windows Communication Foundation (WCF)
##  Questions?
