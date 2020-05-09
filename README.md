# dotnet-core-angular-template

## Installation steps

#### Angular installation steps
Open the `cmd` inside `Voluntariat/ClientApp` then run the following commands:
* `npm install`
* `ng build`

#### Web app installation steps
Open the `cmd` inside repository **root** then run the following commands:
 * `dotnet build`
 * `dotnet ef database update`
 * `dotnet run`

#### Technology stack
 * ASP.NET Core
 * MsSql Server
 * Entity Framework Core
 * Angular 9
 * Angular Material Design 9
 
 
## Useful commands/templates
 
**Azure MsSQL connection string**

`Data Source=tcp:{server}.database.windows.net,1433;Initial Catalog={database_name};User ID={username}@{server};Password={password}`

**Angular build & watch for changes(during development)**

`ng build --watch`

**Angular build in Production mode**

`ng build --prod`

**Publish ASP.NET Core App to specific folder(don't forget to build the Angular app first)**

`dotnet publish --configuration release --output output`

**Start ASP.NET Core App after publish to specific folder**

`dotnet run output/Voluntariat.dll`

**Start ASP.NET Core App in Production mode**

`dotnet run --environment "Production"`

## Docker commands

**Remove images without tag**

``docker rmi $(docker images --filter “dangling=true” -q --no-trunc)``

**Build dockerfile**

``docker build -t core-api .``

**Run docker image**

``docker run --name core-api --env ASPNETCORE_ENVIRONMENT=Development -p 8080:80 core-api:latest``

## Docker compose commands
**Build docker compose**

``docker-compose build``

**Run docker compose**

``docker-compose up``
