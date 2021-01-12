# TimetableApi written in .Net Core
 This is a API to manage timetables for school. This contains mainly two user levels called Teachers and Students. Teachers and Students can see their timetable. Teachers can request leave and  Need to allocate another teacher all the subjects. 
 


## Technology stack 
* .NET Core 3.1 on Visual Studio 2019
* Microsoft Entity Framework Core 
* xUnit to write the unit testing for the solution
* Faker for Seeding realistic 


## Structure of the solution
### API
There is only one API solution in this projected called TimetableAPI. This will atuomatically create database and run the seeder once you build the project.To represent the API I used  swagger as the starup.

### Test Project
Test are written in xUnitTest and it will start run the API project as "Testing" environment. This project will mainly validating the response.

 ![Database Architecture Diagram](https://github.com/macorera/TimetableApi/blob/main/Diagrams/swagger.PNG?raw=true)


## In Future
* Teacher and Student classes need extends from User class. Then no need of have two request types for timetable request.

## Database Design
You can find the database diagram below.

 ![Database Architecture Diagram](https://github.com/macorera/TimetableApi/blob/main/Diagrams/db_diagram.png?raw=true)



