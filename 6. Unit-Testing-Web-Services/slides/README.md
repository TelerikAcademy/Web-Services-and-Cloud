<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web Service Testing
- Unit testing of the Services
- Telerik Software Academy
- http://academy.telerik.com 
- Web Services and Cloud


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents
- Ways of web service testing
- Unit Testing
- Integration Testing
- Complete Testing of Web Services
- Unit testing the data layer
- Unit testing the repositories layer
- Unit testing the controllers
- Integration testing the web services


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web Service Testing


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Web Service Testing
- Web service unit testing is much like regular unit testing
- Writing test methods to test methods etc..
- Yet a service is build from many more components than POCO objects
- There are the objects, service routing, media types, HTTP Status codes, etc…


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# When a web service is ready for test, the testing itself is performed in the following steps:
- Write Unit Tests to test the C# objects
- Test all objects, their constructors, their methods
- Write the Integration Testing
- Test the application as if a user tests it
- Web Service Testing (2)


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing
- Testing the Work of the Controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing
- The core idea of Unit testing is to test small components of an application
- Test a single behavior (a method, property, constructor, etc…)
- Unit tests cover all C# components of the app
- Models and data layer
- Like repositories and DB/XML read/write
- Business layer
- Controllers and their actions


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Data Layer


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Data Layer
- The data layer is the one thing that most of the time does not need testing
- The idea of the data layer is to reference a data store with a ready-to-use framework
- EntityFramework, NHibernate, OpenAccess
- They are already tested enough
- No point of testing dbContext.Set<T>.Add(), right?


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Repositories


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Repositories
- It is essential to test the implementations of our repositories
- The repositories contain the data store logic
- All custom (developer) logic must be tested
- A missing dbContext.SaveChanges() can cause a lot of pain


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# How to test the data store logic?
- Writing and deleting the original (production) database is not quite a good option
- Imagine a failed test that leaves 100k test records in the database
- Unit Testing the Repositories (2)


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# A few ways exist to unit test a data store
- Manually create a copy of the data store and work on the copy
- Backup the original data store, work on the original, and restore the backup when the tests are over
- Use transactions, to prevent commit to the data store
- Ways to Unit Test a Data Store


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with Transactions
- When testing with transactions, the changes done are not really applied to the data store
- Whatever commited, if tran.Complete() is not called, the transaction logic is rolled back
- How to use transactions in unit tests?
- Create a static TransactionScope instance
- Initialize the transaction in TestInitialize()
- Dispose the transaction in TestCleanup()


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with Transactions
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# How should be tested the repositories?
- What parts of the repositories should our tests cover?
- Test for correct behavior
- Add, Delete, Get, All, etc…
- Test for incorrect behavior
- Test Add with Category that has NULL name


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Repositories
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Services


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing the Services
- Testing the services layers actually means testing the controllers and the REST API
- Test if controllers work correctly as C# objects
- Using mocking or fake repositories
- Test if the endpoints of the REST services work correctly
- Check the StatusCode and Content


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing of the Controllers
- The Unit testing of the controllers is not much of a big deal
- Test them as regular C# classes
- Instantiate an object, and test its methods (actions)
- The repositories can be mocked/faked for easier testing
- If not mocked, the transaction technique should be used again


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories
- To test the controllers, repositories should be faked
- i.e. create a in-memory repository that implements the IRepository<T> interface
- class FakeRepository<T> : IRepository<T> where T:class {        
-   IList<T> entities = new List<T>();
-   public T Add(T entity) {
-     this.entities.Add(entity);
-     return entity;
-   }
-   public T Get(int id)
-   {
-     return this.entities[id];
-   } 
-   …
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories (2)
- With the Fake Repository present, controllers can be tested by passing their constructor a fake rep
- public void GetAll_OneCategoryInRepository_ReturnOneCategory()
- {  //arrange
-   var repository = new FakeRepository<Category>();
-   var categoryToAdd = new Category(){ Name = "Test category" };
-   repository.Add(categoryToAdd);
-   var controller = new CategoriesController(repository);  
-   //act
-   var categoriesModels = controller.GetAll();  
-   //assert
-   Assert.IsTrue(categoriesModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,  
-                   categoriesModels.First().Name);
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories (2)
- With the Fake Repository present, controllers can be tested by passing their constructor a fake rep
- public void GetAll_OneCategoryInRepository_ReturnOneCategory()
- {  //arrange
-   var repository = new FakeRepository<Category>();
-   var categoryToAdd = new Category(){ Name = "Test category" };
-   repository.Add(categoryToAdd);
-   var controller = new CategoriesController(repository);  
-   //act
-   var categoriesModels = controller.GetAll();  
-   //assert
-   Assert.IsTrue(categoriesModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,  
-                   categoriesModels.First().Name);
- }
- Prepare the repository


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories (2)
- With the Fake Repository present, controllers can be tested by passing their constructor a fake rep
- public void GetAll_OneCategoryInRepository_ReturnOneCategory()
- {  //arrange
-   var repository = new FakeRepository<Category>();
-   var categoryToAdd = new Category(){ Name = "Test category" };
-   repository.Add(categoryToAdd);
-   var controller = new CategoriesController(repository);  
-   //act
-   var categoriesModels = controller.GetAll();  
-   //assert
-   Assert.IsTrue(categoriesModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,  
-                   categoriesModels.First().Name);
- }
- Prepare the repository
- Pass it to the controller


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories (2)
- With the Fake Repository present, controllers can be tested by passing their constructor a fake rep
- public void GetAll_OneCategoryInRepository_ReturnOneCategory()
- {  //arrange
-   var repository = new FakeRepository<Category>();
-   var categoryToAdd = new Category(){ Name = "Test category" };
-   repository.Add(categoryToAdd);
-   var controller = new CategoriesController(repository);  
-   //act
-   var categoriesModels = controller.GetAll();  
-   //assert
-   Assert.IsTrue(categoriesModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,  
-                   categoriesModels.First().Name);
- }
- Prepare the repository
- Pass it to the controller
- Act on the controller


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Controllers with Fake Repositories (2)
- With the Fake Repository present, controllers can be tested by passing their constructor a fake rep
- public void GetAll_OneCategoryInRepository_ReturnOneCategory()
- {  //arrange
-   var repository = new FakeRepository<Category>();
-   var categoryToAdd = new Category(){ Name = "Test category" };
-   repository.Add(categoryToAdd);
-   var controller = new CategoriesController(repository);  
-   //act
-   var categoriesModels = controller.GetAll();  
-   //assert
-   Assert.IsTrue(categoriesModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,  
-                   categoriesModels.First().Name);
- }
- Prepare the repository
- Pass it to the controller
- Act on the controller
- Assert the result


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with Fake Repositories
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock
- Creating fake repository for each and every unit test is kind of boring
- Here comes the mocking
- Provide objects that mimic some functionality
- JustMock/Moq provide mocking functionality
- Creates a fake instance of an interface and implement only the functionality needed


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock (2)
- [TestMethod]
- public void GetAll_SingleCategoryInRepository_ReturnsTheCategory()
- {
-  //arrange
-   var repository = Mock.Create<IRepository<Category>>();            
-   var categoryToAdd = GetTestCategory();  
-   IList<Category> entities = new List<Category>(){ categoryToAdd };
-   Mock.Arrange(() => repository.All())
- 	.Returns(() => entities.AsQueryable());
-   var controller = new CategoriesController(repository);
-   //act
-   var categoryModels = controller.GetAll();
-   //assert
-   Assert.IsTrue(categoryModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,   
-                   categoryModels.First().Name);
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock (2)
- [TestMethod]
- public void GetAll_SingleCategoryInRepository_ReturnsTheCategory()
- {
-  //arrange
-   var repository = Mock.Create<IRepository<Category>>();            
-   var categoryToAdd = GetTestCategory();  
-   IList<Category> entities = new List<Category>(){ categoryToAdd };
-   Mock.Arrange(() => repository.All())
- 	.Returns(() => entities.AsQueryable());
-   var controller = new CategoriesController(repository);
-   //act
-   var categoryModels = controller.GetAll();
-   //assert
-   Assert.IsTrue(categoryModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,   
-                   categoryModels.First().Name);
- }
- Create the mock object


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock (2)
- [TestMethod]
- public void GetAll_SingleCategoryInRepository_ReturnsTheCategory()
- {
-  //arrange
-   var repository = Mock.Create<IRepository<Category>>();            
-   var categoryToAdd = GetTestCategory();  
-   IList<Category> entities = new List<Category>(){ categoryToAdd };
-   Mock.Arrange(() => repository.All())
- 	.Returns(() => entities.AsQueryable());
-   var controller = new CategoriesController(repository);
-   //act
-   var categoryModels = controller.GetAll();
-   //assert
-   Assert.IsTrue(categoryModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,   
-                   categoryModels.First().Name);
- }
- Create the mock object
- Mock the All() behavior


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock (2)
- [TestMethod]
- public void GetAll_SingleCategoryInRepository_ReturnsTheCategory()
- {
-  //arrange
-   var repository = Mock.Create<IRepository<Category>>();            
-   var categoryToAdd = GetTestCategory();  
-   IList<Category> entities = new List<Category>(){ categoryToAdd };
-   Mock.Arrange(() => repository.All())
- 	.Returns(() => entities.AsQueryable());
-   var controller = new CategoriesController(repository);
-   //act
-   var categoryModels = controller.GetAll();
-   //assert
-   Assert.IsTrue(categoryModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,   
-                   categoryModels.First().Name);
- }
- Create the mock object
- Mock the All() behavior
- Act on the controller


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing with JustMock (2)
- [TestMethod]
- public void GetAll_SingleCategoryInRepository_ReturnsTheCategory()
- {
-  //arrange
-   var repository = Mock.Create<IRepository<Category>>();            
-   var categoryToAdd = GetTestCategory();  
-   IList<Category> entities = new List<Category>(){ categoryToAdd };
-   Mock.Arrange(() => repository.All())
- 	.Returns(() => entities.AsQueryable());
-   var controller = new CategoriesController(repository);
-   //act
-   var categoryModels = controller.GetAll();
-   //assert
-   Assert.IsTrue(categoryModels.Count() == 1);
-   Assert.AreEqual(categoryToAdd.Name,   
-                   categoryModels.First().Name);
- }
- Create the mock object
- Mock the All() behavior
- Act on the controller
- Assert the result


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing With JustMock
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# More About Controllers Unit Testing
- GET actions are easy to test
- They return POCO objects
- How to test POST actions?
- They return HttpResponseMessage
- Unfortunately POST actions require additional configuration due to the Request object they use


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring POST Actions
- A simple POST action:
- public HttpResponseMessage Post(CategoryModel model)
- {
-   var entity = this.categoriesRepository.Add(model);
-   var response = Request.CreateResponse<CategoryModel>(
-                                 HttpStatusCode.Created,
-                                 entity);
-   var resourceLink = Url.Link("DefaultApi", 
-                                 new { id = entity.Id });
-   response.Headers.Location = new Uri(resourceLink);
-   return response;
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring POST Actions
- A simple POST action:
- public HttpResponseMessage Post(CategoryModel model)
- {
-   var entity = this.categoriesRepository.Add(model);
-   var response = Request.CreateResponse<CategoryModel>(
-                                 HttpStatusCode.Created,
-                                 entity);
-   var resourceLink = Url.Link("DefaultApi", 
-                                 new { id = entity.Id });
-   response.Headers.Location = new Uri(resourceLink);
-   return response;
- }
- Run in unit test, Request has a value of null
- If a controller is invoked outside of WebAPI environment, the Request object is not set


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring POST Actions (2)
- To have a non-null value of the Request object, it must be set up manually
- private void SetupController(ApiController controller)
- {
-   var request = new HttpRequestMessage()
-     { RequestUri = new Uri("http://test-url.com")};
-   controller.Request = request;
-   var config = new HttpConfiguration();
-   config.Routes.MapHttpRoute(
-     name: "DefaultApi",
-     routeTemplate: "api/{controller}/{id}",
-     defaults: new { id = RouteParameter.Optional });
-   controller.Configuration = config;
-   controller.RequestContext.RouteData = new HttpRouteData(
-     route: new HttpRoute(),
-     values: new HttpRouteValueDictionary { 
-       { "controller", "categories" } 
-     });
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring POST Actions (2)
- To have a non-null value of the Request object, it must be set up manually
- private void SetupController(ApiController controller)
- {
-   var request = new HttpRequestMessage()
-     { RequestUri = new Uri("http://test-url.com")};
-   controller.Request = request;
-   var config = new HttpConfiguration();
-   config.Routes.MapHttpRoute(
-     name: "DefaultApi",
-     routeTemplate: "api/{controller}/{id}",
-     defaults: new { id = RouteParameter.Optional });
-   controller.Configuration = config;
-   controller.RequestContext.RouteData = new HttpRouteData(
-     route: new HttpRoute(),
-     values: new HttpRouteValueDictionary { 
-       { "controller", "categories" } 
-     });
- }
- Create a Request object


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuring POST Actions (2)
- To have a non-null value of the Request object, it must be set up manually
- private void SetupController(ApiController controller)
- {
-   var request = new HttpRequestMessage()
-     { RequestUri = new Uri("http://test-url.com")};
-   controller.Request = request;
-   var config = new HttpConfiguration();
-   config.Routes.MapHttpRoute(
-     name: "DefaultApi",
-     routeTemplate: "api/{controller}/{id}",
-     defaults: new { id = RouteParameter.Optional });
-   controller.Configuration = config;
-   controller.RequestContext.RouteData = new HttpRouteData(
-     route: new HttpRoute(),
-     values: new HttpRouteValueDictionary { 
-       { "controller", "categories" } 
-     });
- }
- Create a config
- Create a Request object


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing POST Actions
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing
- Integration testing aims to cover the work of the whole application
- Not small components like unit testing
- Integration tests should work like a user
- Test what a user sees in combination of all application components mixed together


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing WebAPI
- When integration testing WebAPI, controllers and their actions are assumed to be working correctly
- In WebAPI, integration tests should cover:
- The endpoints of the RESTful services
- Test if the endpoint reaches the correct action
- Test the serialization of the data
- Does it work with JSON/XML
- Is the data serialized correctly


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing WebAPI (2)
- Integration testing a GET request:
- [TestMethod]
- public void GetAll_SingleCategory_StatusCodeOkAndNotNullContent()
- {
-   var mockRepository = Mock.Create<IRepository<Category>>();
-   var models = new List<Category>();
-   models.Add(new Category() { Name = "Test Cat" });
-   Mock.Arrange(() => mockRepository.All())
-       .Returns(() => models.AsQueryable());
-   var server = new InMemoryHttpServer<Category>(
-     "http://localhost/",
-     mockRepository);
-   var response = server.CreateGetRequest("api/categories");
-   Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
-   Assert.IsNotNull(response.Content);
- }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing WebAPI (2)
- Integration testing a GET request:
- [TestMethod]
- public void GetAll_SingleCategory_StatusCodeOkAndNotNullContent()
- {
-   var mockRepository = Mock.Create<IRepository<Category>>();
-   var models = new List<Category>();
-   models.Add(new Category() { Name = "Test Cat" });
-   Mock.Arrange(() => mockRepository.All())
-       .Returns(() => models.AsQueryable());
-   var server = new InMemoryHttpServer<Category>(
-     "http://localhost/",
-     mockRepository);
-   var response = server.CreateGetRequest("api/categories");
-   Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
-   Assert.IsNotNull(response.Content);
- }
- Fake in-memory server, that hosts the WebAPI controllers


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Integration Testing
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Unit Testing Web Services
- http://academy.Telerik.com


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Homework
- Develop a REST API for a BugLogger app
- Bugs have status:
- fixed, assigned, for-testing, pending
- Bugs have text and logDate
- Newly added bugs always have status "pending"
- Bugs can be queried – get all bugs, get bugs after a date, get only pending bugs, etc…
- Develop a database in MS SQL Server that keeps the data of the bugs
- Create repositories to work with the bugs database


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Homework (2)
- Provide a REST API to work with the bugs
- Using WebAPI
- Provide the following actions:
- Log new bug
- Get all bugs
- Get bugs after a specific date: 
- Get bugs by status
- Change bug status 
- Write unit tests to test the BugLogger
- Use a mocking framework
- Write integration tests to test the BugLogger
- POST …/bugs
- GET …/bugs
- GET …/bugs?date=22-06-2014
- GET …/bugs?type=pending
- PUT …/bugs/{id}


