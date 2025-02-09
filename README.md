# Mohamed Bin Zayed Univerity For Humatities - Assessment

A robust API/UI solution built with **.NET 8** to manage books crud operations.

## Technologies
	- **NET 8**
	- **Entity Framework Core**
	- **SQL Server** / **In-Memory Database**
	- **Fluent Validation**
	- **Auto Mapper**
	- **JQeury**

## Features
	- Ability to configure the app to use either sql server database or in-memory database.
	- Ability to optionally seed some data on startup.
	- Swagger APIs to Create/Update/GetAll geners.
	- Swagger APIs to Create/Update/Delete (Hard)/GetById/Get(Filtered And Paged) books.
	- UI page to List/Search/Paginate/Create/Update/Delete books (For Genre you can use swagger to add).
	- Inputs spaces sanitization
	  - Trimming(Remove start and trailing spaces).
	  - Remove extra spaces (Ex: 'Book      Name' will be sanitized to 'Book Name').
	- Inputs validations (Listed below).
	- Bussiness validations (Listed below).
	- Log any book successfull update trasnaction into a txt file (Called "modificationslogs.txt" exists in the API project root).

## Inputs Validations
  - Genre
	- Id: Not to be null and not less than 1 (While update).
	- Name: Not to be null or empty and not to exceed 100 char.
  - Book
	- Id: Not to be null or empty guid (While Update).
	- Title: Not to be null or empty and not to exceed 200 char.
	- Author: Not to be null or empty and not to exceed 200 char.
	- ISBN: Length to be 10:13 numbers only.
	- PublicationYear: Value to be in range of 1900:9999;
	- Genre: Not to be null or empty and not to exceed 100 char (From Swagger use genre name not id).
	
## Bussiness Validations
  - Genre
	- Not to duplicate genre names.
  - Book
	- Not to duplicate all book together.
	
## Database Notes
	- Intentioned to make the PK of Genre table int while PK of Book table Guid.
	
## Swagger Notes
	- While Create/Update book, Use genre name in the genre property (Not genre id).
	- Beside the inputs fluent validation, some validation happens as per the datatypes (Int, Guid),
		But if you prefer to make thos field strings and validate their datatype in the fluent validation that's easy.
	
## Service Layer Notes
	- Many codes (Specially in project Application folder "Common") can be moved to a shared project, which can be helpful if we have more than one service,
		But as we have only single service and for easy readability I let them there.
	- Logging
		- Logging is stored in txt file called "modificationslogs.txt" exists in the API project root.
		- As per requested, Logging is working while updating book only (Easy to enable it globally or for some specific other transactions).
		- Practically in the real life, If we will use files for logging, It should generate file daily (at max), 
			I just let it be txt single txt file for your easy readability.
	
## UI Notes
	- In the UI project, I didn't used any C# or any of the razor pages powered capabilities in order to simulate SPA behaviour (Angular/REACT).
	- The logic exists in wwwroot/js/index.js
	- I kept the apis base url static here just for readability (It's easy to move it to appsettings).
	- Validated ISBN length, While intentioned to skip validating its format (only numbers), It still will return a validation message as per the
		backend fluent validations (Intentioned to skip it, just to hightlight that even any UI validation forgotten, backend validation still there).
	- Of course that js file can be enhanced and some codes can be centralized into helper files, Just let it here for easy readability, Also that's why I didn't minified it.
	- Used the default browser alerts and confrimation boxes

## Out of scope
	- Authentication and authorization.
	- Localization.
	- API gateway (Upstreaming and downstreaming).
	- Unit testing.
	- Sorting.

## How to Run  
1. Clone the repository from https://github.com/AhmedAboelata/Mbzuh.Assessment
2. Open the solution by Visual studio (Or whatever code editor you prefers).
3. Open the appsetting.json file of the API project
	3.1 Set the value of **UseInMemoryDatabase** to **true** (already defaulted) if you want the solution to use In-Memory database, while set it to **false** If you 
		want it to use SQL database, And in that case please set you valid sql instance connection string in key **ConnectionStrings:DefaultConnection** in the same file.
	3.2 Set the value of **SeedDataOnStart** to **true** (already defaulted) if you want to seed some data on start. otherwise set it **false**.
		To check the data that will be seeded look at class **Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext.ApplicationDbContextDataSeeding.cs**
4. **Run** and wait few seconds, 2 console pages will open (default of .NET 8) and **2 web pages will be appears (Swagger, and UI books listing page)**.
	4.1 Sometimes with the first run, the UI listing bookd data not loading due to API project still not up and running, Just refresh the page or press button Search
		(In real life deployments API projects will be up and running before UI projects).
