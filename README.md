# Cloud Sales System - Technical Exercise
This is a solution for Cloud Sales System techical exercise.

## Description
Project owner wants to implement a solution for cloud sales. Project owner has a business partner, a Cloud Computing Provider (called CCP from now on). The CCP offers an API that Customer can use to automate the business.

Solution should provide customers to buy and manage software solutions offered by CCP. Each
purchased software is tied to a single account. Each customer can have multiple accounts.

Purchased software has a name (e.g. Microsoft Office), quantity (number of licenses, e.g. 5), state
(active, etc.) and the valid to date (e.g. software license is valid until 31st of August, 2023.)

Create a Web API that supports following features:
- see the list of its own accounts
- see the list of software services available on CCP (you can mock HTTP calls to CCP and return
hardcoded list of services)
- order software license through CCP (you can mock HTTP calls to CCP and return hardcoded list of
services) for specific account
- see purchased software licenses for each account
- change quantity of service licenses per subscription
- cancel the specific software under any account
- extend the software license valid to date (e.g. 31st August -> 30th September)

## Tech stack
- [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) - Web Api
- [PostgreSQL](https://www.postgresql.org) - Database
- [Docker](https://www.docker.com/) - Containerisation
- [Seq](https://datalust.co/seq) - Platform used for storing logs

### Most important external dependencies
- [Entity Framework](https://learn.microsoft.com/en-us/ef/) - ORM
- [Dapper](https://github.com/DapperLib/Dapper) - Micro ORM
- [MediatR](https://github.com/jbogard/MediatR) - Mediator implementation in .NET
- [Serilog](https://serilog.net/) - .NET logging with fully-structured events
- [AutoMapper](https://docs.automapper.org/en/stable/Getting-started.html) - object-object mapper
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) - Library for building strongly-typed validation rules
- [RichardSzalay.MockHttp](https://github.com/richardszalay/mockhttp) - Testing layer for Microsoft's HttpClient library.
- [FluentAssertions](https://fluentassertions.com/) - Set of extension methods for assertions in testing to make the assertions more readable and easier to understand.
- [FakeItEasy](https://fakeiteasy.github.io/) - dynamic fake framework for creating all types of fake objects, mocks, stubs etc.
- [Testcontainers.PostgreSql](https://testcontainers.com/guides/getting-started-with-testcontainers-for-dotnet/) - Testing library that provides easy and lightweight APIs for bootstrapping integration tests with real services wrapped in Docker containers.
- [NetArchTest.Rules](https://github.com/BenMorris/NetArchTest) - A fluent API for .Net Standard that can enforce architectural rules in unit tests.

## Application Access Data
### [Seq](http://localhost:5341/) - Logs monitoring
### [Swagger API](https://localhost:6992/swagger/index.html) - Swagger representation
### PostgreSQL  
- host: **localhost** 
- port: **5432** 
- dbname: **cloud-sales-system-db** .
- username: **postgres** 
- password: **posgres**

## DB Diagram

### Description
This is a simplified DB representation where we can determine **CustomerId** value for a logged user (**ICurrentUserProvider**).

Customers can have multiple **Accounts**.
Customers can have multiple **Subscriptions** (developers, qa,...).
A **subscription** is just a virtual collection of **Subscription Items**.
**Subscription Item** is a representation of the purchased service from CCP.
**License** is a collection of CCP licenses that are (or were somewhere back in time) tied to some account.

![Cloud Sales System DB Diagram](/Resources/CloudSalesSystemDb.png "Cloud Sales System DB Diagram")

## Technical description
Implementation follows Clean Architecture principles by creating **Api**, **Application**, **Infrastructure**, and **Domain** libs. The idea was to show good practices for organizing the code and handling requests, mappings, validations, errors... 

When the use case requires only **read** operations (**queries**) **Dapper** is used for DB access because the idea behind is that on production we can easily create a DB replica so one database will be used for **read** operations and the second for **write** operations.

Because of that, **Entity Framework** is used for use cases when data manipulation is required (**commands**). For that purpose, **Repository pattern** is implemented with **Unit of Work**.

**Sequential Guid Generator** is implemented so we can guarantee that records will be sorted by Id by default.

**InMemory cache** is used to store CCP values locally.

A big focus was on tests as well, so the solution contains blueprints for: **Domain tests**, **Application tests**, **API tests (integration tests)**, and **Architecture tests**.

## Requirements
To run this project, the only thing that has to be installed on the machine is [Docker](https://www.docker.com/).

## How To

### Start
There are two ways to start the solution, directly from *Visual Studio* or using *Docker Compose*.

#### Visual Studio 2022 (or newer)
- Open this solution using Visual Studio 2022 or newer
- Right-click on the *docker-compose* item in Solution Explorer (follow the blue whale icon 🐋)
- Chose 'Set as Startup project'
- Run the solution (click on the green play button on the top of the Visual Studio window)

#### Docker Compose
- Navigate to the root of the *cloud-sales-system* folder
- Open console
- run `docker-compose -f docker-compose.yml -f docker-compose.override.yml up` command

### Test

The database contains initial data that is seeded when the solution is started.

Seeded identifiers

|Customers|
|---|
|`697EEFC8-CB19-41B0-8302-E91FCA1805BF`|

|Accounts|
|---|
|`E0000B5B-7AD0-4B27-8457-47262FDCF1C7`|
|`E1000B5B-7AD0-4B27-8457-47262FDCF1C7`|
|`E2000B5B-7AD0-4B27-8457-47262FDCF1C7`|

|Subscriptions|
|---|
|`74E083D4-13AE-4AFC-8040-62D226357C56`|
|`75E083D4-13AE-4AFC-8040-62D226357C56`|
|`76E083D4-13AE-4AFC-8040-62D226357C56`|

|SubscriptionItems|
|---|
|`74E083D4-13AE-4AFC-8040-62D226357C56`|
|`75E083D4-13AE-4AFC-8040-62D226357C56`|
|`76E083D4-13AE-4AFC-8040-62D226357C56`|

|Licenses|
|---|
|`426A397F-4D49-4D8C-B775-2EF6DF1D9B61`|
|`436A397F-4D49-4D8C-B775-2EF6DF1D9B61`|
|`446A397F-4D49-4D8C-B775-2EF6DF1D9B61`|

#### Swagger
You can open a Swagger and using the given Guid's you can test the application.

#### Postman

[Download Link](https://github.com/bokunda/cloud-sales-system/blob/main/Resources/cloudSalesSystem.postman) - Postman Collection
Just set {{ host }} environment variable in Postman to `https://localhost:6992` and you can start testing the app.

If download fails, navigate to **Resources** folder and download **cloudSalesSystem.postman** file.

**NOTE:** Initial setup of the collection is with valid data!


## Future Improvements
- Create dedicated libraries for services that can be reused on other projects and publish them on nuget repository.
- Error handling should be improved.
- All tests should be covered.
- Use Polly for API calls
- Restrict healtcheck visibility
- Revisit data transfer objects