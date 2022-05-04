# MyCMS
[![build](https://github.com/manuelebagnolini/MyCMS/actions/workflows/build-test.yml/badge.svg?branch=main)](https://github.com/manuelebagnolini/MyCMS/actions/workflows/build-test.yml)
[![issues](https://img.shields.io/github/issues/manuelebagnolini/MyCMS)](https://github.com/manuelebagnolini/MyCMS/issues)
[![license](https://img.shields.io/github/license/manuelebagnolini/MyCMS)](https://github.com/manuelebagnolini/MyCMS/blob/main/LICENSE)

MyCMS is a simple, lightweight headless CMS queryable via a single GraphQL endpoint.

It's based on a relational database table structure able to create custom attribute for every type of content defined in your project.

### Status
- ⚠️This software is not finished and currently in development so it should not be used in production enviroments!
- ⚠️The UI application is not yet implemented!
- ⚠️Only SQLite database is currently supported!

## Getting Started
- Clone the repository using the command `git clone https://github.com/manuelebagnolini/MyCMS.git` and checkout the `main` branch.

### Command line
- Install the latest version of the .NET SDK from this page <https://dotnet.microsoft.com/download>
- Next, navigate to the `MyCMS.Web.API` folder.
- Call `dotnet build`.
- Call `dotnet run` (or `dotnet watch` for live coding)
- Then open the `https://localhost:7040/graphql/` URL in your browser to test the GraphQL endpoint.

### Visual Studio
- Download Visual Studio 2022 (any edition) from https://www.visualstudio.com/downloads/
- Open `MyCMS.sln` and wait for Visual Studio to restore all Nuget packages
- Ensure `MyCMS.Web.API` is the startup project
- Select `Build solution` from the solution context menu
- Run the project

## Load test fake data
If you run the project with `dotnet watch` via command line or in debug mode in Visual Studio you will see the swagger index by hitting the `https://localhost:7040/` URL.

If you select the `/api/Test/ImportTestData` API you can define a value for the `numArticles` input field for the number of articles to create in the database test structure.

Select `Try it out` to call the api and populate the test database.

## Sample project
Inside the solution you will find a sample frontend project written in Blazor WebAssembly to show an example of MyCMS usage by a frontend application

### Run the project via command line
- Navigate to the `MyCMS.Web.Sample` folder.
- Call `dotnet build`.
- Call `dotnet run` (or `dotnet watch` for live coding)
- Then open the `https://localhost:7058/` URL in your browser (if you run `dotnet watch` the browser will open automatically).

### Run the project in Visual Studio
- Open the contextual menu for the `MyCMS.Web.Sample`
- Next go to the `debug` sub menu
- Now select one from `Start new instance` and `Start without debugging`
- The browser will automatically open on `https://localhost:7058/` URL

## License
See the [LICENSE](./LICENSE) file for licensing information.
