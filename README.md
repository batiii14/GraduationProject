# Dormitory Management System Project 

This project is a graduation project aiming to create a dormitory management system. The project is developed using N-layered architecture, with the backend written in C# language and utilizing EntityFramework.


# About the Project

Dormitory Management System is designed to facilitate the management of student dormitories. It allows CRUD and various operations such as student registration, room assignments etc. to be carried out seamlessly within the system.


# File Structure

The project's file structure is as follows:

-	Entities: Contains classes representing database tables.
-	DataAccess: The layer responsible for database operations. Data operations are performed using EntityFramework.
-	Business: This layer contains the business logic. Data processing and business rules are implemented here.
-	API: The layer responsible for communication with the outside world. API endpoints are defined here and requests are handled.


# Branching Strategy

In the project, a new branch is created for each major change. After testing and approval, these changes will be merged into the master branch.



# Installation

You can follow the steps below to run the project:

1. Clone the repository to your computer:

   	git clone https://github.com/batiii14/GraduationProject.git
  
2. Open the project with Visual Studio (or your preferred IDE).

3. Restore the necessary NuGet packages.

4. Edit the database connection and perform migration operations.

5. Compile and run the project files.


# Contributing

-	If you identify any issues with the project or have any improvement suggestions, please open an issue.
-	You can contribute to the project by creating a pull request. Ensure that your pull requests adhere to the project standards.



