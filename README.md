# Cards 
This is an educational project, it allows to users making a personalised set of word cards and to remember them easily by repeating within a short period of time. Word cards can be sorted by language, type and repeated period. The projects is built based on ASP.NET Core WEB API, Angular 8, Docker and MSSQL Server technologies. It consists of three solutions: Cards.API, Cards.Core and Cards.SPA. Cards.API is responsible for working with http requests and responses, when Cards.Core implements Services, Repositories, Authentication and all other functionalitites. The Cards.SPA solution contains a Single Page Web application in Angular 8. The project architecture developed in a way that allows easy scalability.

### A step by step instruction to run the project on a local machine
First, ensure that MSSQL server, 'nodejs' and 'npm' are installed in a local machine.The MSSQL databse can be installed on a local machine directly or by using Docker. Please remind that a database connection credentials should be cheked in the file appsettings.json in Cards.Core project. Then, in Cards.Core project the following commands should be executed to create a databse. Entity Framework does it automatically:

```
/Cards.Core
dotnet restore
dotnet ef database update -s ../Cards.Api
```

Second, the API needs to be run by executing follong commands in Cards.API folder:

```
/Cards.API 
dotnet restore
dotnet run
```

Finally, the client application should be launched from Cards.SPA folder:

```
/Cards.SPA 
npm update
npm run
```

Done! Now our project can be opened on any browser by link:

```
http://localhost:4200/
```
