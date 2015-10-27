<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Building a Server Application with WebAPI
- Telerik Software Academy
- http://academy.telerik.com 
- Web Services and Cloud


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents
- Application Layers
- Database Layer
- Data Layer
- Services Layer
- The repository pattern
- Creating repositories to unify database interactions
- Inversion of Control and dependency Injection
- Using DependencyResolver


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# a


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repository Pattern


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repository Pattern
- The repository pattern wraps the access to data stores (like databases, XML, services…)
- Exposes only interfaces to interact with a data store
- Used for higher code-reusability and testability
- The app's business layer contains a single instance of a repository
- Used to perform CRUD operations over the data store


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repository Pattern: Example
- public interface IRepository<T>
- {
-   T Add(T item);
-   IEnumerable<T> GetAll(); 
-   …
- }
- public interface IPlacesRepository : IRepository<PlaceDto>
- { }
- public class DbPlacesRepository: IPlacesRepository
- {
-   public PlaceDto Add(PlaceDto Add){ … }
-   public IEnumerable<PlaceDto> GetAll(){ … }   }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repository Pattern
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Why These Repositories?
- Repository pattern has the f0llowing features:
- Testability of the application
- When the testing of the repositories is done, they can be mocked to test the business layer
- Reusability or the repositories
- When creating a new business layer working with the same Database (like admin panel)
- Extensibility of the business layer
- In need of more repositories, they can be easily produced


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Repository Pattern in WebAPI


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Repository Pattern in WebAPI
- To use the repository pattern in WebAPI just create an instance of the IRepository<T> interface inside the controller
- And use the repository to interact with the DB
- public class PlacesController : ApiController
- {
-   private IPlacesRepository repository;
-   public PlacesController()
-   {
-     this.repository = new DbPlacesRepository();
-   }  
-   public IEnumerable<PlaceDto> GetAll()
-   {
-     return this.repository.GetAll();
-   }
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Repository Pattern in WebAPI (2)
- Yet in the example the controller instantiates the repository
- The controller is tightly coupled with the DbPlacesRepository class
- This can be fixed using Inversion of Control and Dependency Injection 


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Repository Pattern in WebAPI
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Inversion of Control (IoC)


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Inversion of Control (IoC)
- Inversion of Control is a way to loosen the coupling between components
- Makes testing easier
- Makes extensibility easier
- IoC is a technique that allows coupling of objects at run time, instead of compile time
- IoC gives objects the dependencies they need
- If the controller expects an instance of the IRepository<PlaceDto> interface, the IoC gives it a suitable instance


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# IoC Implementations
- There are many ways to implement IoC:
- Factory design pattern
- Service locator pattern
- Dependency injection
- Template method design pattern
- Strategy design pattern
- Etc…
- WebAPI has built-in dependency injection for controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Dependency Injection
- Dependency injection removes the hard-coded dependencies between objects and allows changing them run time
- The primary idea behind DI is selection of single implementation of interface between many present
- Decide run time which of the many implementations of IRepository<PlaceDto> to use for the controller


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Dependency Injection in WebAPI
- WebAPI has by default a dependency injector for controllers, called DependencyResolver
- Instantiates controllers with their default constructor
- Yet this can be changed to instantiate another constructor 
- Each WebAPI application has a DependecyResolver, deciding how to initialize controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# DependencyResolver
- The dependency resolver of a WebAPI app can be changed with a custom implementation
- Create a class that inherits from IDependencyResolver and implement its GetService() method:
- public class DbDependencyResolver: IDependencyResolver
- {
-   static IRepository<Place> placesRep = new DbPlacesRepository();
-   public object GetService(Type serviceType)
-   {
-     if (serviceType == typeof(PlacesController))
-       return new PlacesController(placesRepository);
-     else
-       return null;
-   }
-   …
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Inversion of Control (IoC)
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Application Layers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Application Layers
- A server application is build from three layers
- A data layer contains
- Access to the data source (database, XML, etc…)
- EntityFramework DbContext, XDocument, etc…
- A repositories layer contains
- Repositories with CRUD operations over a DB
- A service layer contains
- A reference to a repositories layer
- A reference to the data layer
- Controllers with actions for a REST API


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Application Layers
- The Data Source
- Data Layer
- Repositories
- Services Layer(Business layer)
- MS SQL, MySQL, XML, Web services
- Entity Framework, OpenAccess, Linq-to-XML
- WebAPI controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Places Database
- Creating a Sample Application


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Places Database
- Develop an application to store places of interest
- Each place has coordinates, name, a set of categories and optional description
- Every user can leave a comment or vote for a place
- The user needs to type in their username
- No user authentication required
- Categories have a name and set of places


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Database


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Database
- Create a database for the application
- i.e. using MS SQL Server
- Create tables, relations, schema, etc…
- Create store procedures and indexes
- Create everything needed for an app database


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating The Database
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Data Layer


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Data Layer
- The data layer contains a way to connect to the database
- Entity Framework
- Database-first or Code-first
- ADO.NET
- LINQ-to-SQL
- LINQ-to-XML
- Etc…


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating the Data Layer
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repositories Layer


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Repositories Layer
- The repository layer exposes repositories to work with the Database
- Using the Repository Pattern
- The repositories introduce methods to perform CRUD operations over the data store
- In our case over the Places database


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Creating the Repositories Layer
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Services Layer


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Services Layer
- The Services layer is the layer that contains the business logic
- It uses the repositories for data interactions
- Yet has no direct dependency over the data store
- The Services layer contains all the controllers that are used by the Service Consumer
- Handles computing and error handling


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# The Services Layer
- The Services Layer is the place where ASP.NET WebAPI steps in
- It is the only layer that is dependent to the WebAPI framework
- The Services layers uses the repositories to interact with the Data store and WebAPI to communicate with the Consumers
- Each controller has a repository instance for data store interactions
- The repository instances are received by IoC


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Building a Server Application with WebAPI


