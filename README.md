# Samle .NET-Core API
This is a Sample .NET Core API Project using ASP.NET Core API with EF Core and SQL Server as the database. The project also has Swagger UI for documentation.

**Scenario/Use case**: There are two main entities: Employee and SIG (Special Interest Group). An employee can join many SIG and also a SIG can be joined multiple employees.
The relationship is many to many. Design a simple API to perform CRUD functionalities for both Employee and SIG. Furthermore, add the functionalities for interaction 
between SIG and Employee.

**Database structure/ER Diagram**

## Code Structure + Set up

### Model Layer

There will be three main models that will be used: Employee, Enrollment and SIG. The model layer contains the architecture for each of the entity, including attributes and 
relationship between entities.
