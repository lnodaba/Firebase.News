# Firebase.News

It's a simple template project for the Firebase Labs it contains (hopefully) all the necessary samples,
based on them you will be able to create your very own project.
  
## Contains:
 
  - A newly created **.NET MVC** ( **API** template is also included) project, this project will be the **frontend of the application**
  - The template project which is having an example for all the **CRUD** (Create/Read/Update/Delete) operations 
  this includes the methods for the **controllers** and also the **views** for them. 
  You can find the dinosaur controller inside the controller folder and the associated views for them inside the Views/Dinosaur folder.
  
  - **Firebase.News.Tests** the integrations tests for the **public APIs** of the third party libraries we're going to use during the labs. 
  Namely : **FirebaseDatabase.net, FirebaseStorage.net and FirebaseAuthentication.net**
  More info in the Third party libraries section of this document
  
 
 ## Third party libraries:
 
 - [FirebaseDatabase.net](https://github.com/step-up-labs/firebase-database-dotnet) 
 - [FirebaseStorage.net](https://github.com/step-up-labs/firebase-storage-dotnet)
 - [FirebaseAuthentication.net](https://github.com/step-up-labs/firebase-authentication-dotnet)
 
## Pre requirements (Firebase setup):

1. Create a firebase project with your google account through the [Console](https://console.firebase.google.com) 
2. In the online platform, under development section you can create a new database NOTE: check no strict mode.
3. On the same panel you can start to have storage ready as well. 
4. Navigate to the Rules tab of the Storage and remove the if statement from the JSON from the line which is starting with `allow read, write`
 
## How to create a project similar to this:

1. Create a new .NET Web application project and check MVC and Web API. More info on the following [link](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/getting-started).
2. Create a class library which will envelope your domain knowledge. [Info](https://msdn.microsoft.com/en-us/library/cc668164.aspx)
3. Install the third party libraries through NuGet, for both projects, if you willing to have unit tests install the libraries for that project as well. [Info](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio)
4. Create the model classes( [POC](https://stackoverflow.com/questions/250001/poco-definition) for the project inside the class library project. Important to have an ID field for the objects as they are eventually entities.
5. Link the class library to the main MVC project (and also reference it to the Unit test project in case you have it) [Info](https://msdn.microsoft.com/en-us/library/ez524kew.aspx) Add Reference -> Project and check the DLL project jo want to reference to the main project. 
6. Generate the controllers and views for the CRUD operations similar examples can be found under the following links:            
 [info for the controllers](https://www.tutlane.com/tutorial/aspnet-mvc/how-to-create-add-controller-in-asp-net-mvc-application-project) and
 [info for the views](https://msdn.microsoft.com/en-us/library/dd405231(v=vs.98).aspx)

## Quick catch up with C# under [[this]](https://learnxinyminutes.com/docs/csharp/) and [[this]](https://www.tutorialspoint.com/csharp/index.htm) the first one is a cheat sheet ;-)



