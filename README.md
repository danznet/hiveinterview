# Hive Interview

## Notes & Improvements

##### Data Store
- Most of the data access logic can be found inside the /Data folder
- Made use of repository pattern to allow for interchangeable data store. There are currently 3 data repositories for this demo:
  - **LocationTestRepository.cs** for dummy data
  - **LocationJsonRepository.cs** for json data (converted from .csv to .json)
  - **LocationSQLRepository.cs** for data stored in Azure SQL Server database. I spun this database up in my personal Azure instance, and the connection string is checked in. It's never ideal to checkin connection strings, this is just for demo purposes. In order to improve this I would make use of the secrets.json file.
- Made use of EntityFramework migrations for setting up the database. The data was seeded by converting the .csv file provided into a .json file, and then reading & deserialising the file into a cs model. The OnModelCreating method gets overridden in the **HideInterviewContext** class, and a migration is created with the data from that json file. This is done by calling the update-database command from within the package manager console window. The manual conversion from .csv to .json isn't really necessary, but due to the time restrictions on this demo I elected not to write code to parse the .csv file. Working with json is much easier!
- The **Startup.cs** file controls which repository is to be used via dependency injection. This can be interchanged by choosing which line to uncomment between 43 and 45. A better way of doing this would be to add a factory class which determines which repository to use based on an application setting. The current code is using the SQL data store.

##### Architecture Improvements
Due to this being a quick demo I elected to use ASP.Net MVC and combine both the frontend and backend code in the same project. For a production application I would probably separate this out, and have an ASP.Net Restful Web API for the backend, along with a static frontend. The frontend could utilize webpack for module bundling, Vue single file components, axios for http requests, CSS pre-processors, Babel for javascript compilation, Vue routing and a VueX store. It would obviously depend on the application's requirements for which ones of these to implement, as it can be an easy trap to fall into optimising too early. The Vue/js code for this demo can be found in the **/Views/Home/Index.cshtml** file. The vue application isn't currently split out into reusable components, but that is an improvement I would make early on. For instance I would probably have **LocationsList, LocationsListItem & LocationsMap** as separate components. Another improvement I would make is to ensure that entities are never returned to the client application, and instead create appropriate view models. It's typically bad practice to return your database schema to the client.

##### Filtering of data
Due to the limited number of locations for this demo, I elected to return all of the data in a single request, and then filter on the clientside. If a larger dataset was expected, I would consider doing the filtering/paging on the serverside instead. The number of rows shown is limited by a configuration setting in the **appsettings.json** file.

##### Testing
I haven't added many unit tests to this project, due to the simplicity of the code. But there are a couple of initial tests for the **HomeController Index** method. To improve this, I would add more tests as the complexity grows, and probably utilise a mocking framework such as **moq** for mocking repositories.

##### Google API Key
A valid API key has been added to make Google Maps run without the errors. I know this was not necessary for the demo but the errors were bugging me! Typically speaking, I would never check an API key in to source control for production code. I would also lock down the API key so that only certain applications/IP addresses could use it.
