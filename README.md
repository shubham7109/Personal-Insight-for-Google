Shubham Sharma

COMS 490

Summer 2019

# Independent Study Report     

**Overview:**

Over the summer I had the opportunity to develop an app to display analytical information on the data collected by Google from the user. The app called **Personal Insight** is a Windows Presentation Foundation ([WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)) application built on C# using the .NET library.

**Project Proposal:**

Google is known to keep track of their user&#39;s data. Unfortunately, your activities on the internet and sometimes personal information is sold to advertisers on the cost of your privacy. Legally Google is required to disclose all the data they acquire on you, but they make sure package them in a way, that any regular user will not understand.

My proposal is to develop an application which will parse through the files provided from Google and display analytical information of what exactly Google collects on the user. For the users, this application is intended to:

- Provide a deeper insight to user users of how far Google can reach in term of user data
- Give the user a better understanding of the importance of personal privacy
- Direct users on how to better keep their data more private.

**Project Description:**

The application is a WPF application runs on .NET which is compatible with any Windows platform machine. It is developed using Visual Studio, and utilized the Material Design In XAML Toolkit, [link](http://materialdesigninxaml.net/).

The project uses standard programming practices, takes advantage of object oriented concepts like inheritance, polymorphism and data encapsulation. The program is built using the same approach of a Model View Controller Architecture design (MVC).

The brains of the whole project is divided into 3 main parts:

1. Pages: This package consists the XAML and C# code responsible for displaying all the view objects and handling interactions with the view models, such as a click.
2. Models: This package consists of all the Model classes which represents a specific data object. One of the most used model classes in this project is GoogleProductModel.cs, which keeps track of the essentials like the Google Product&#39;s name, path, image, size etc.
3. ComputeProduct: This package contains all the data parsing algorithms which scan through each Google Product and serializes to configurable JSON data structures.

The app also is built to handle all sorts of unexpected errors. For example, if a user tries to import a Google Product that is not yet supported by the program, it will gracefully let the user know and handle the situation appropriately.

**Project Features:**

The app consists of various features shown below:

- Advanced recursive parsing algorithms which scans through multiple gigabytes worth of data in seconds.
- Assisted logging information for debugging purposes, and for user satisfaction of program awareness.
- Convenient directions to get started with the program.
- Handy &#39;open folder&#39; which will open the relevant Google Products path in the file explorer.
- Displays analytical information like, number of files scanned, and Google Product size.
- Displays a data grid of the information scanned in a more readable format than the file provided by Google.

**Room for Improvement:**

A lot of progress has been made to the application but there are some additional functionality that could be added in the future:

- Implementation of Google Analytics
- Experiment with time remaining for the data scan
- Additional animations for the application
- Acquiring Microsoft&#39;s developer certificate to publishing as an independent software product

**Conclusion:**

The point of this app is to help make users aware of the level of outreach Google has on their users, and it is safe to say that **Personal Insight** is shaping to be such an app. With more time to come this app will have additional features and could definitely be showcased as a reputable resource on privacy.

This independent research study has given me the opportunity to learn the programming practices of desktop grade applications, and given me an outlook on the technicality for developing products on a large scale.

I would also like to thank, Professor Simanta Mitra to have given me this opportunity!



Shubham Sharma

------------------------------------------------------

Computer Engineering | Iowa State University

Director of IT | Student Government

Android Developer | MyState

Project Chair at IEEE

(847)-943-7754

shubham@iastate.edu