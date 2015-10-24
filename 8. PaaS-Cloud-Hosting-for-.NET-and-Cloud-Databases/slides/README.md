<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor
- .NET Cloud Development Made Easy
- Telerik Software Academy
- http://academy.telerik.com 
- Web Services and Cloud
- .NET Cloud
- AppHarbor Public Cloud


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents
- What is AppHarbor?
- “Control panel” overview
- AppHarbor architecture
- Deployment process
- Runtime
- Pricing
- Prices
- Resources
- 2


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Table of Contents (2)
- Application deployment
- Git crash-course
- Sample application deployment
- Service hooks
- Configuration variables and Add-ons
- Configuration variables
- Mailgun
- Shared SQL Server 
- MongoLab
- SVNSailor
- 3


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# What is AppHarbor?
- .NET Platform as a Service


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# What is AppHarbor?
- Fully hosted .NET PaaS
- Supports ASP.NET (Web Forms & MVC), WCF, WWF, ADO.NET Entity Framework, etc.
- Runs on Amazon EC2
- Automatic load balancing
- Easy application deployment 
- Through Git
- Through  Bitbucket, CodePlex or GitHub
- Through SVN (with add-on)
- 5


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# What is AppHarbor? (2)
- Automatic build
- Code compilation
- Unit tests execution
- Rich set of add-ons
- Provide additional functionality for applications
- Shared Microsoft SQL Server, Airbrake, MongoHQ, StillAlive, Mailgun, Blitline, etc.
- Forum, support and knowledgebase
- 6


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# “UI” Overview
- A Quick Look over the “Application Dashboard”


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor Architecture
- Deployment process, Runtime environment


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor Architecture
- 9
- Managed SQL Server / MySQL
- MongoDB, CouchDB
- Visual Studio + Git
- AppHarbor Applications Management Console
- Load Balancer (Nginx)
- Background workers
- Web worker instances
- Managed IIS environment
- C# / ASP.NET MVC / Web Forms / WCF
- Managed Windows environment
- C# code
- IronMQ, RabitMQ
- Other AppHarbor Add-On Services


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor Architecture (2)
- Deployment process
- User pushes (sends) .NET code
- Code is built by a platform build server 
- If code compiles, unit tests are run
- Results appear on the application dashboard
- Service hooks are called
- Application deployed to the AppHarbor application servers. 
- AppHarbor scales application when needed
- 10


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor Architecture (3)
- Application runtime environment
- Load balancing is automatic
- SSL connections, HTML compression, etc. are handled
- Everything runs on AWS and is managed by AppHarbor
- Cloud resources are consumed through add-ons
- More info: https://appharbor.com/page/how-it-works
- 11


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Pricing
- Plans and Resources


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Pricing and Resources
- AppHarbor worker
- Process which can have multiple threads
- Limited in resources
- 2 workers always on different machines
- Resource limit per worker 
- Network Bandwidth: 100GB/month – Soft
- RAM usage: 512MB - Soft; 1024MB – Hard
- CPU resources: ~600MHz – Hard
- Requests Queue limit: 500 Requests
- Request timeout: 30 seconds - Soft; 120 seconds - Hard
- 13


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Pricing and Resources (2)
- AppHarbor background worker
- Regular .NET console application
- .exe’s produced on compilation
- Used for
- Recurring tasks
- Schedules
- Etc.
- 14


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Plans (Canoe)
- Canoe plan
- 0$ per month
- 1 worker
- apphb.com hostname
- Piggyback SSL
- 15


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Plans (Catamaran)
- Catamaran plan
- 49$ per month
- 2 workers
- Custom hostnames
- SNI SSL
- 16


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Plans (Yacht)
- Yacht plan
- 199$ per month
- 4 workers
- Custom hostnames
- IP-based SSL
- 17


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git Crash Course
- Only What You Need to Know to Use AppHarbor


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git Crash Course
- Git
- Source-control system
- Can work with local and remote repositories
- Git Bash – command line interface for Git
- Free
- Has Windows version (msysgit)
- http://code.google.com/p/msysgit/downloads/detail?name=Git-1.7.10-preview20120409.exe&can=3&q=
- 19


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git Crash Course (2)
- Installation – 
- “next, next, next” does the trick
- Options to select (they should be selected by default)
- “Use Git Bash only”
- “Checkout Windows-style, commit Unix-style endings”
- Note: this concerns only beginners
- 20


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git Crash Course (3)
- Using Git Bash
- Standard command prompt with added features
- Creating a local repository
- git init
- Preparing (adding/choosing) files for a commit
- git add [filename]       (“git add .” adds everything)
- Committing to a local repository
- git commit –m “your message here”
- 21


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git Crash Course (4)
- Using Git Bash (2)
- Git “remote”– name for a repository URL
- Git “master” – the current local branch (think of it as “where you have committed”)
- Creating a remote
- git add remote [remote name] [remote url]
- Pushing to a remote (sending to a remote repository)
- git push [remote name] master
- 22


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Using Git Bash
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Application Deployment
- Deploying your Application to AppHarbor


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Application Deployment
- Getting your code to AppHarbor
- Through Git
- AppHarbor provides Repository URL
- Use Git to push to that URL
- Other source-control systems – commit to some integrated with AppHarbor repository
- Through Bitbucket, Codeplex, GitHub
- Have integration with AppHarbor
- Can push code to AppHarbor’s repository
- 25


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git and AppHarbor
- AppHarbor “requirements”
- Submit a .NET Solution with
- All project files
- All code files, libraries, etc.
- All other resources
- Solution must be a web application
- If there is more than ONE solution file
- AppHarbor compiles the one named “AppHarbor.sln”
- 26


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git and AppHarbor
- First deployment to AppHarbor with Git
- Initialize a repository where your solution is
- Add the relevant files to be committed
- Commit to local repository
- Create a remote to AppHarbor repository (get the URL from your application’s “dashboard”)
- Push to the remote you created for AppHarbor
- …and that’s everything!
- 27


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Git and AppHarbor
- Next deployments to AppHarbor
- Add the relevant files to be committed
- Either all the files from before or only the ones you modified
- Commit to local repository
- Repository was created in the “First deployment”
- Push to the remote for AppHarbor
- We created this the first time too
- Your application dashboard now has a history!
- 28


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Deploying to AppHarbor
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor Service Hooks
- URLs to which AppHarbor POSTs build info
- After a build is deployed (or failed deploying)
- Can be your own service or, e.g. TweetHarbor
- Format of the POST body:
- 30
- { "application": { "name": "Foo", "slug": "foo", "url": "https://appharbor.com/applications/foo" }, "build": { "id": "bar", "branch" : { "name" : "baz", "commit" : { 
- "id" : "77d991fe61187d205f329ddf9387d118a09fadcd", "message" : "Implement foobar" } }, "status": "succeeded", "url": "https://appharbor.com/applications/foo/builds/bar" } }


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# ConfigurationVariables and Add-ons
- Customizing and Enriching Your Application


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuration variables
- Key-value pairs
- Correspond to <appSettings> in Web.config
- Overwritten on deployment in AppHarbor
- Used to change the behavior of your application on AppHarbor
- e.g. variable telling your app it's on AppHarbor
- Added by user
- Added by add-ons
- Connection strings, logins, other add-on data
- 32


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuration variables
- Adding a configuration variable in AppHarbor
- Go to Application dashboard >> Configuration variables >> New configuration variable
- 33


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuration variables
- Adding and editing configuration variables
- In your application config file (e.g. Web.config)
- Accessing configuration variables through C#
- Stored in the ConfigurationManager class
- AppSettings property (dictionary)
- using System.Configuration;
- …
- string myValue = 
-     ConfigurationManager.AppSettings["my key"];
- <appSettings>
-   <add key = “my key” value = “my string value”/>
-   ...
- </appSettings>


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Configuration Variables
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Add-ons
- Add-ons allow you to consume cloud resources
- Added from add-on catalogue
- Each application has its independent add-ons
- Each add-on has a “control page”
- Various settings, controls, etc.
- From Application Dashboard click the add-on, then “Go to [add-on name]”
- Use configuration variables for interaction with your application
- Most have free versions
- 36


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Mailgun
- Mailgun add-on provides e-mail services 
- Analysis and statistics tools
- SMTP, POP3, IMAP
- Has a C# API
- Gives you hostname, login, password
- Through configuration variables
- Free – 300 messages/day, temp storage
- 19$/month – 50000 messages/month, 20GB
- Configuration variables:
- MAILGUN_SMTP_LOGIN, MAILGUN_SMTP_SERVER, MAILGUN_API_KEY, MAILGUN_SMTP_PORT, MAILGUN_SMTP_PASSWORD
- 37


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Mailgun
- Using Mailgun with C#
- NuGet package "mnailgun" (not a type-o):
- Can use SmtpClient for lower-level access
- using Typesafe.Mailgun
- …
- var domain = "app14337.mailgun.org"; //No exact config varaible
- var key = ConfigurationManager.AppSettings["MAILGUN_API_KEY"];
- var from = "mail@example.com"; //note: can send from any address
-                                //note 2: don't!
- var to = "me@example.com";
- var mail = new System.Net.Mail.MailMessage(from, to)
-     {
-         Subject = "Example mail",
-         Body = "The quick brown fox jumps over the lazy dog"
-     };
- var mailClient = new MailgunClient(domain, key);
- mailClient.SendMail(mail);


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Mailgun Add-On
- Live Demo
- http://mailsender-1.apphb.com/


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# MongoLab
- Managed MongoDb in the cloud
- Hosted on Amazon EC2
- REST API
- Works fine with 10gen C# driver
- Good administration tools
- Free: 0.5 GB instance
- Paid plan: 1 – 20 GB instance, $10 – $65 / month
- + automatic backups, + monitoring
- Configuration variables:
- MONGOLAB_URI
- 40


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# MongoLab
- "Go To MongoLab"
- Redirects to MongoLab
- Full-featured administration (CRUD, settings, stats, tools)


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# MongoLab
- Using MongoLab with C#
- With NuGet 10gen driver package
- using MongoDB.Driver;
- using MongoDB.Driver.Linq;
- …
- var mongoUrl = ConfigurationManager.AppSettings["MONGOLAB_URI"];
- MongoClient client = new MongoClient(mongoUrl);
- var server = client.GetServer();
- var db = server.GetDatabase(mongoDatabase);
- var posts = db.GetCollection("posts");
- posts.Insert(...);
- var query = from p in posts.AsQueryable<PostModel>()
-             select p;
- foreach(PostModel post in query) {...}


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# MongoLab Add-On
- Live Demo
- http://posted.apphb.com 


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Shared SQL Server
- Shared SQL Server
- Provides a SQL Database 
- Gives you a server URI, username and password
- Gives you a connection string
- Configuration variable with alias
- Free – 20 MB
- Shared DB processing: 200ms/s CPU time – Soft
- 10$/month – 10 GB
- Configuration variables
- SQLSERVER_CONNECTION_STRING, SQLSERVER_CONNECTION_STRING_ALIAS, SQLSERVER_URI
- 44


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Shared SQL Server
- "Go To SQLServer"
- Connectionstring
- Database name
- Alias editing
- Hostname
- Username
- Password


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Shared SQL Server
- Using SQLServer with C#
- Same as you would a regular SQL database
- Create an entity model through Visual Studio
- Use Hostname, Username and Password from the add-on's page
- 46


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# SQL Server Add-On
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# SVNSailor
- SVNSailor enables SVN commit support
- Connects to a SVN repository (e.g. in Google Code) by given:
- Url, Username, Password
- On commit to the SVN repository:
- Builds the code
- Deploys it on AppHarbor
- Free – first 5 commits
- Paid – 5$/month – unlimitted commits
- 48


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# SVN Sailor Add-On
- Live Demo


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Other Add-Ons
- Airbrake (error logging)
- Blitz (performance monitoring)
- CloudAMQP (RabbitMQ)
- Cloudant (CouchDB)
- CloudMailin (incoming email)
- Dedicated SQL Server
- JustOneDB (NoSLQ database)
- Logentries (log management)
- 50


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor: Add-Ons (2)
- Memcacher (in-memory caching)
- MongoHQ (managed MongoDB)
- MySQL (shared MySQL DB)
- RavenHQ (NoSQL database)
- Redis To Go (key-value store)
- SendGrid (email delivery)
- StillAlive (app monitoring)
- 51


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# AppHarbor
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
- ?


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Exercises
- Write a "code jewels*" service. The service should enable POSTing a code jewel, GETing all code jewels and searching for code jewels by source code and by category (and retrieving them). The service should also enable voting for and against a code jewel (+ and -). Code jewels with very low scores should be deleted from the database.A code jewel has a category (e.g. "C#", "JavaScript", ...), an author's mail (e.g. me@itgeorge.net), a rating and source code.Deploy the service to AppHarbor. Implement deactivating the POSTing of code jewels through the AppHarbor interface.*A code jewel is any relatively short, but useful piece of code (e.g. checking a bit's value, recursively deleting files, etc.)


<!-- attr: { id:'', class:'', showInPresentation:true, hasScriptWrapper:true, style:'font-size:1em' } -->
# Exercises
- Develop a service hook, which maintains a list of e-mails, to which it sends an e-mail with the hooked app's name as a subject and the commit message as a body.The list of e-mails should be stored in a database, to which only the administrator has access.Upload the service to AppHarbor and hook the Code Jewels application to it.


