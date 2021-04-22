# Samle .NET-Core API
This is a Sample .NET Core API Project using ASP.NET Core API with EF Core and SQL Server as the database. The project also has Swagger UI for documentation.

**Scenario/Use case**: There are two main entities: Employee and SIG (Special Interest Group). An employee can join many SIG and also a SIG can be joined multiple employees.
The relationship is many to many. Design a simple API to perform CRUD functionalities for both Employee and SIG. Furthermore, add the functionalities for interaction 
between SIG and Employee.

**Database structure/ER Diagram**

## Code Structure + Set up

### Model Layer

There will be three main models that will be used: Employee, Enrollment and SIG. The model layer contains the architecture for each of the entity, including attributes and relationship between entities.

**Example: SIG Model**

```c#
 public class SIG
  {
      public int Id { get; set; }
      
      [Required]
      public string Name { get; set; }
      
      public string Description { get; set; }
      
      [JsonIgnore]
      public List<Enrollment> EmployeeEnrollment { get; set; }
  }
```
  
The Enrollment model in this scenario was created because of the many to many relationship. The relationship between entities is set up in this layer: one to one, one to many, many to many, using Entity Framework Core. More instruction on how to set up the relation ship can be found in this link [Entity Framework Tutorial](https://www.entityframeworktutorial.net/efcore/conventions-in-ef-core.aspx).

Besides, there are some additional configuration with each entity that you can set up: specifying the key attributes, changing table/column names, preventing one attribute from mapping, specifying the foreign key and many more. All of these configuration can also be found in the [Entity Framework Annotation](https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx).

### Data Access Layer

The purpose of this layer is setting up the connection between the API and the database. There will be three main steps in the data access layer that we have to do: 
- Create the DbContext for the project. (The DbContext serves the purpose of the database itself).
- Perform Migration the structure into the actual database (Migration will create a script based on the structure in the DbContext and the desired database. It will apply that script to the database directly).
- Create the Repository for Entites. (These repositories will perform solely the CRUD operation).
 
