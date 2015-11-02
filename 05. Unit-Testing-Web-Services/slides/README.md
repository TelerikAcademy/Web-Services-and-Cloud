<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Web Service Testing
##  Unit testing of the Services
<div class="signature">
  <p class="signature-course">Web Services and Cloud</p>
  <p class="signature-initiative">Telerik Software Academy</p>
  <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>


<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents
* Ways of web service testing
  * Unit Testing
  * Integration Testing
* Complete Testing of Web Services
  * Unit testing the data layer
  * Unit testing the repositories layer
  * Unit testing the controllers
  * Integration testing the web services


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Web Service Testing


<!-- attr: { showInPresentation:true, style:'' } -->
# Web Service Testing
* Web service unit testing is much like regular unit testing
  * Writing test methods to test methods etc..
* Yet a service is build from many more components than POCO objects
  * There are the objects, service routing, media types, HTTP Status codes, etc…


<!-- attr: { showInPresentation:true, style:'' } -->
<!-- # Web Service Testing -->
* When a web service is ready for test, the testing itself is performed in the following steps:
  * Write Unit Tests to test the C# objects
    * Test all objects, their constructors, their methods
  * Write the Integration Testing
    * Test the application as if a user tests it


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Unit Testing
##  Testing the Work of the Controllers

<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing
* The core idea of Unit testing is to test small components of an application
  * Test a single behavior (a method, property, constructor, etc…)
* Unit tests cover all C# components of the app
  * Models and data layer
    * Like repositories and DB/XML read/write
  * Business layer
    * Controllers and their actions


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Unit Testing the Data Layer


<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Unit Testing the Data Layer
* The data layer is the one thing that most of the time does not need testing
  * The idea of the data layer is to reference a data store with a ready-to-use framework
    * EntityFramework, NHibernate, OpenAccess
    * They are already tested enough
  * No point of testing `dbContext.Set<T>.Add()`, right?


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Unit Testing the Repositories


<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing the Repositories
* It is essential to test the implementations of our repositories
  * The repositories contain the data store logic
    * All custom (developer) logic must be tested
  * A missing `dbContext.SaveChanges()` can cause a lot of pain

<!-- attr: { showInPresentation:true, style:'' } -->
<!-- # Unit Testing the Repositories -->
* How to test the data store logic?
  * Writing and deleting the original (production) database is not quite a good option
    * Imagine a failed test that leaves 100k test records in the database

<!-- attr: { showInPresentation:true, style:'' } -->
# Ways to Unit Test a Data Store
* A few ways exist to unit test a data store
  * Manually create a copy of the data store and work on the copy
  * Backup the original data store, work on the original, and restore the backup when the tests are over
  * Use transactions, to prevent commit to the data store

<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing with Transactions
* When testing with transactions, the changes done are not really applied to the data store
  * Whatever commited, if `tran.Complete()` is not called, the transaction logic is rolled back
* How to use transactions in unit tests?
  * Create a static `TransactionScope` instance
  * Initialize the transaction in `TestInitialize()`
  * Dispose the transaction in `TestCleanup()`

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Unit Testing with Transactions -->
##  [Demo]()

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# How should the repositories<br/> be tested?
* What parts of the repositories should our tests cover?
  * Test for correct behavior
    * Add, Delete, Get, All, etc…
  * Test for incorrect behavior
    * Test Add with Category that has NULL name

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Unit Testing the Repositories -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Unit Testing the Services

<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing the Services
* Testing the services layers actually means testing the controllers and the REST API
  * Test if controllers work correctly as C# objects
    * Using mocking or fake repositories
  * Test if the endpoints of the REST services work correctly
    * Check the StatusCode and Content

<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing of the Controllers
* The Unit testing of the controllers is not much of a big deal
  * Test them as regular C# classes
  * Instantiate an object, and test its methods (actions)
  * The repositories can be mocked/faked for easier testing
    * If not mocked, the transaction technique should be used again

<!-- attr: { showInPresentation:true, style:'font-size:0.9em' } -->
# Unit Testing Controllers with Fake Repositories
* To test the controllers, repositories should be faked
  * i.e. create a in-memory repository that implements the `IRepository<T>` interface

```cs
class FakeRepository<T> : IRepository<T> where T:class {        
  IList<T> entities = new List<T>();
  public T Add(T entity) {
    this.entities.Add(entity);
    return entity;
  }
  public T Get(int id)
  {
    return this.entities[id];
  } 
  …
}
```


<!-- attr: { showInPresentation:true, style:'font-size:0.9em' } -->
<!-- # Unit Testing Controllers with Fake Repositories -->
* With the Fake Repository present, controllers can be tested by passing their constructor a fake rep

```cs
public void GetAll_OneCategoryInRepository_ReturnOneCategory()
{  //arrange
  var repository = new FakeRepository<Category>();
  var categoryToAdd = new Category(){ Name = "Test category" };
  repository.Add(categoryToAdd);
  var controller = new CategoriesController(repository);  
  //act
  var categoriesModels = controller.GetAll();  
  //assert
  Assert.IsTrue(categoriesModels.Count() == 1);
  Assert.AreEqual(categoryToAdd.Name,  
                  categoriesModels.First().Name);
}
```


<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em' } -->
<!-- # Unit Testing Controllers with Fake Repositories -->
* With the Fake Repository present, controllers can be tested by passing their constructor a fake rep

```cs
public void GetAll_OneCategoryInRepository_ReturnOneCategory()
{  //arrange
  var repository = new FakeRepository<Category>();
  var categoryToAdd = new Category(){ Name = "Test category" };
  repository.Add(categoryToAdd);
  var controller = new CategoriesController(repository);  
  //act
  var categoriesModels = controller.GetAll();  
  //assert
  Assert.IsTrue(categoriesModels.Count() == 1);
  Assert.AreEqual(categoryToAdd.Name,  
                  categoriesModels.First().Name);
}
```
<div class="fragment balloon" style="width:240px; top:45%; left:71%">Prepare the repository</div>
<div class="fragment balloon" style="width:250px; top:57%; right:-8%">Pass it to the controller</div>
<div class="fragment balloon" style="width:220px; top:66%; left:65%">Act on the controller</div>
<div class="fragment balloon" style="width:180px; top:82%; left:5%">Assert the result</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Unit Testing with Fake Repositories -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Unit Testing with JustMock
* Creating fake repository for each and every unit test is kind of boring
* Here comes the mocking
  * Provide objects that mimic some functionality
* `JustMock/Moq` provide mocking functionality
  * Creates a fake instance of an interface and implement only the functionality needed

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Unit Testing with JustMock -->

```cs
[TestMethod]
public void GetAll_SingleCategoryInRepo_ReturnsTheCategory()
{
 //arrange
  var repository = Mock.Create<IRepository<Category>>();
  var categoryToAdd = GetTestCategory();  
  IList<Category> entities = new List<Category>()
    { categoryToAdd };
  Mock.Arrange(() => repository.All())
	.Returns(() => entities.AsQueryable());
  var controller = new CategoriesController(repository);
  //act
  var categoryModels = controller.GetAll();
  //assert
  Assert.IsTrue(categoryModels.Count() == 1);
  Assert.AreEqual(categoryToAdd.Name,   
                  categoryModels.First().Name);
}
```
<div class="fragments balloon" style="width:250px; top:27%; right:15%">Create the mock object</div>
<div class="fragments balloon" style="width:270px; top:48%; right:7%">Mock the `All()` behavior</div>
<div class="fragments balloon" style="width:220px; top:67%; right:5%">Act on the controller</div>
<div class="fragments balloon" style="width:180px; top:84%; left:9%">Assert the result</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Unit Testing With JustMock -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# More About Controllers Unit Testing
* GET actions are easy to test
  * They return POCO objects
* How to test POST actions?
  * They return `HttpResponseMessage`
* Unfortunately POST actions require additional configuration due to the `Request` object they use

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Configuring POST Actions
* A simple POST action:

```cs
public HttpResponseMessage Post(CategoryModel model)
{
  var entity = this.categoriesRepository.Add(model);
  var response = Request.CreateResponse<CategoryModel>(
                                HttpStatusCode.Created,
                                entity);
  var resourceLink = Url.Link("DefaultApi", 
                                new { id = entity.Id });
  response.Headers.Location = new Uri(resourceLink);
  return response;
}
```
<div class="fragment balloon" style="width:270px; top:42%; left:10%">Run in unit test, `Request` has a value of null</div>
* If a controller is invoked outside of WebAPI environment, the Request object is not set

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em' } -->
<!-- # Configuring POST Actions -->
* To have a non-null value of the Request object, it must be set up manually

```cs
private void SetupController(ApiController controller)
{
  var request = new HttpRequestMessage()
    { RequestUri = new Uri("http://test-url.com")};
  controller.Request = request;
  var config = new HttpConfiguration();
  config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional });
  controller.Configuration = config;
  controller.RequestContext.RouteData = new HttpRouteData(
    route: new HttpRoute(),
    values: new HttpRouteValueDictionary { 
      { "controller", "categories" } 
    });
}
```
<div class="fragment balloon" style="width:250px; top:36%; right:12%">Create a Request object</div>
<div class="fragment balloon" style="width:170px; top:49%; right:21%">Create a config</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Unit Testing POST Actions -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Integration Testing

<!-- attr: { showInPresentation:true, style:'' } -->
# Integration Testing
* Integration testing aims to cover the work of the whole application
  * Not small components like unit testing
* Integration tests should work like a user
  * Test what a user sees in combination of all application components mixed together

<!-- attr: { showInPresentation:true, style:'' } -->
# Integration Testing WebAPI
* When integration testing WebAPI, controllers and their actions are assumed to be working correctly
* In WebAPI, integration tests should cover:
  * The endpoints of the RESTful services
    * Test if the endpoint reaches the correct action
  * Test the serialization of the data
    * Does it work with JSON/XML
    * Is the data serialized correctly

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Integration Testing WebAPI -->
* Integration testing a GET request:

```cs
[TestMethod]
public void GetAll_SingleCategory_StatusCodeOkAndNotNullContent()
{
  var mockRepository = Mock.Create<IRepository<Category>>();
  var models = new List<Category>();
  models.Add(new Category() { Name = "Test Cat" });
  Mock.Arrange(() => mockRepository.All())
      .Returns(() => models.AsQueryable());
  var server = new InMemoryHttpServer<Category>(
    "http://localhost/", mockRepository);
  var response = server.CreateGetRequest("api/categories");
  Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
  Assert.IsNotNull(response.Content);
}
```
<div class="fragments balloon" style="width:310px; top:56%; right:-10%">Fake in-memory server, that hosts the WebAPI controllers</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Integration Testing -->
##  [Demo]()

<!-- attr: { id:'questions', class:'slide-section', showInPresentation:true, style:'' } -->
<!-- # Questions -->
## Unit Testing Web Services
[link to Telerik Academy Forum]()


