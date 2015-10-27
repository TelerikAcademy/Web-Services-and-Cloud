Web Services and Cloud Technologies – Practical Teamwork Project 2014
=====================================================================

Project Description
-------------------

Design and implement a RESTful API, host it in the cloud and develop a client application.

General Requirements
--------------------

Please define and implement the following assets in your project:

### Requirements for the RESTful API

-   Use **ASP.NET WebAPI**

    -   Your application must be implemented using ASP.NET WebAPI

-   Provide a **RESTful API**

    -   The endpoints should provide CRUD operations: POST, GET, PUT and DELETE

-   Host the application in the cloud

    -   Use **AppHarbor**

-   Use a **file storage cloud API**

    -   **Dropbox**, **Google Drive** or other

-   Use a **cloud database**

    -   **MS SQL**, **MySQL**, **MongoDB**, **Redis** or other

-   Implement notifications functionality

    -   Use **PubNub** or other

### Requirements for the Client application

-   The client application can be one of the following:

    -   **Web SPA** application using JavaScript

    -   **iOS mobile** application

    -   **Android mobile** application

    -   **Windows 8/Windows Phone 8 mobile** application

    -   **Cross-platform mobile application** using Apache Cordova, Xamarin or other

    -   **Windows desktop application** using WPF, Windows Forms or the console

-   The **client application** must send **HTTP** **requests** to the RESTful API

Additional Requirements
-----------------------

-   Follow the **best practices for OO design**: use data encapsulation, use exception handling properly, use inheritance, abstraction and polymorphism properly and follow the principles of strong cohesion and loose coupling

-   Create a **solid validation** on both the Web services application and on the client application

-   Use a source control system by choice

Optional Requirements
---------------------

If you have a chance, time and a suitable situation, you might add some of the following to your project:

-   Usage of **message queues**

-   **Unit** and/or **integration** testing

Deliverables
------------

Put the following in a **ZIP archive** and submit it (each team member submits the same file):

-   The complete **source code**

-   Add **webservices.teamwork@gmail.com** as a collaborator to your project in AppHarbor

-   Brief **documentation** of your project (2-3 pages). It should provide the following information (in brief):

    -   Team name and list of team members

    -   Project purpose – what problem do you solve?

    -   Class diagram of your types

    -   The URL of your source control repository

    -   Any other information (optionally)

-   Optionally provide a **PowerPoint presentation** designed for the project defense

Public Project Defense
----------------------

Each team will have to deliver a **public defense** of its work to the other students and trainers. You will have **only 5 minutes** for the following:

-   **Demonstrate** the application (very shortly)

-   Show the **class diagram** (just a glance)

-   Show the **source code** in the source control system code browser

-   Show the **commits logs** to confirm that team member have contributed

-   Optionally you might prepare a PowerPoint presentation (3-4 slides)

Please be **strict in timing**! Be **well prepared** for presenting maximum of your work for minimum time. Bring your own laptop. Test it preliminary with the multimedia projector. Open the project assets beforehand to save time. You have **5 minutes**, no more.

Give Feedback about Your Teammates
----------------------------------

You will be invited to **provide feedback** about all your teammates, their attitude to this project, their technical skills, their team working skills, their contribution to the project, etc. The feedback is important part of the project evaluation so **take it seriously** and be honest.


Sample Projects:
----------------

Your application can be one of the following:

-   **Web chat** application

    -   Users send messages between each other

    -   Users can send files

    -   Users can have a profile picture

    -   Users receive notifications when another user sends them a message

-   **Foursquare-like** application

    -   Users can see a set of predefined places with coordinates

    -   Users can check-in at a place near them

    -   Users can post a comment about a place

    -   Users can upload an image of the place

    -   Users can create a place

    -   Users receive notifications about people, checking in the place they are in

-   **Image gallery** application

    -   Users can own a gallery

    -   The gallery can have albums

    -   The albums can have sub albums

    -   Users can upload images in the gallery or in any of the albums

    -   Images have title

    -   Users can leave a comment about an image

    -   Users receive notifications when somebody comments an image of theirs

-   **Chess** game

    -   Users can join a random game

        -   The engine decides which two players to start the game

    -   Users can perform moves in a started game

    -   Users can have a profile picture

    -   Users receive notifications when a user in a game of theirs has made their move

-   **Crowd-sourced** **news** application

    -   Users can publish a news article containing images

    -   Users can comment news articles

        -   Comments can be nested

    -   Users can vote for and against news articles

    -   Users receive notifications when a new news article is published

-   **Recipe** application

    -   Users can upload recipes containing images and preparation steps

        -   Preparation steps have completion time (e.g. bake potatoes for 5 minutes at 200 degrees)

    -   Users can like and comment a recipe

    -   Users can start cooking a recipe

        -   Notifications are delivered when a preparation step's time has elapsed

-   **Another application** by your choice

    -   The only condition is to follow the Requirements
