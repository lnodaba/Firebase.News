# Firebase.News

It's a simple template project for the Firebase Labs it contains (hopefully) all the necessary samples,
based on them you will be able to create your very own project.
  
## Contains:
 
  - A newly created **.NET MVC** ( **API** template is also included) project, this project will be the **frontend of the application**
  - The template project which is having an example for all the **CRUD** (Create/Read/Update/Delete) operations 
  this includes the methods for the **controllers** and also the **views** for them. 
  You can find the dinosaur controller inside the controller folder and the associated views for them inside the Views/Dinosaur folder.
  
  - **Firebase.News.Tests** the Unit tests for the **public API** of the third party libraries we're going to use during the labs. 
  Namely : **FirebaseDatabase.net, FirebaseStorage.net and FirebaseAuthentication.net**
  More info in the Third party libraries section of this document
  
 
 ## Third party libraries:
 
 - [FirebaseDatabase.net](https://github.com/step-up-labs/firebase-database-dotnet) 
 - [FirebaseStorage.net](https://github.com/step-up-labs/firebase-storage-dotnet)
 - [FirebaseAuthentication.net](https://github.com/step-up-labs/firebase-authentication-dotnet)
 
## Pre requirements (Firebase setup):

1. Create a firebase project with your google account through the [Console](https://console.firebase.google.com) 
2. In the online platform, under development section you can create a new database NOTE: check no strickt mode.
3. On the same panel you can start to have storage ready as well. 
4. Navigate to the Rules tab of the Storage and remove the if statemenf from the JSON from the line which is starting with `allow read, write`
 
## How to create a project similar to this.
