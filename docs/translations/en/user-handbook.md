# MyCMS User Handbook

Written by [Manuele Bagnolini](https://github.com/manuelebagnolini/)

This document covers everything you ever wanted to know about using [MyCMS](https://github.com/manuelebagnolini/MyCMS) and related tooling.

This handbook is available in other languages, see the [README](/docs/README.md) for a complete list.

# Table of Contents

- [Introduction](#toc-introduction)
- [What is an headless CMS?](#toc-what-is-headless)
- [Setting up MyCMS](#toc-setting-up-mycms)
  - [Requirements](#toc-mycms-requirements)
  - [Getting the code](#toc-mycms-code)
  - [Run MyCMS](#toc-mycms-run)
    - [Run via command line](#toc-mycms-run-cmd)
    - [Run in Visual Studio](#toc-mycms-run-vs)
- [Configuring MyCMS](#toc-configuring-mycms)
  - [`appsettings.json`](#toc-appsettings)
  - [`DBSettings`](#toc-mycms-dbsettings)
    - [`DataProviderType`](#toc-mycms-dataprovidertype)
    - [`ConnectionString`](#toc-mycms-connectionstring)
- [Defining MyCMS content](#toc-mycms-content)
- [MyCMS Support](#toc-mycms-support)
  - [MyCMS Issues](#toc-mycms-issues)

# <a id="toc-introduction"></a>Introduction

MyCMS is a simple, lightweight headless CMS queryable via a single GraphQL endpoint.

It's based on a relational database table structure able to create custom attribute for every type of content defined in your project.

MyCMS is based on [.NET6](https://docs.microsoft.com/it-it/dotnet/core/whats-new/dotnet-6) web framework, it uses [EF Core](https://docs.microsoft.com/ef/core/) for the data layer and [Hot Chocolate](https://chillicream.com/docs/hotchocolate/get-started) as GraphQL server.

In this handbook you will learn how to setup and run MyCMS and how to organize your content inside the MyCMS database structure.

----

# <a id="toc-what-is-headless"></a>What is an headless CMS?
A headless Content Management System, or headless CMS, is a back-end-only content management system that acts primarily as a content repository. A headless CMS makes content accessible via an API for display on any device without a built-in, front-end or presentation layer. The term “headless” comes from the concept of chopping the “head” (the front end) off the “body” (the back end).

![context](/docs/c4/png/context.png)

# <a id="toc-setting-up-mycms"></a>Setting up MyCMS

There's not an installer for MyCMS, you need to checkout the code directly from the repository and built it locally on your machine.

## <a id="toc-mycms-requirements"></a>Requirements
In order to build MyCMS you need the latest version of [.NET6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), you can build and run it directly from command line or you can use [Visual Studio](https://visualstudio.microsoft.com/).

## <a id="toc-mycms-code"></a>Getting the code

Clone the repository using the command `git clone https://github.com/manuelebagnolini/MyCMS.git` and checkout the main branch.

## <a id="toc-mycms-run"></a>Run MyCMS

Before running MyCMS you have to build the `MyCMS.Web.Api` project and then run it. You can do it via command line or using Visual Studio.

### <a id="toc-mycms-run-cmd"></a>Run via command line
- Navigate to the `MyCMS.Web.API` folder.
- Call `dotnet build`.
- Call `dotnet run` (or `dotnet watch` for live coding)
- Then open the `https://localhost:7040/graphql/` URL in your browser to test the GraphQL endpoint.

### <a id="toc-mycms-run-vs"></a>Run in Visual Studio
- Open `MyCMS.sln` and wait for Visual Studio to restore all Nuget packages
- Ensure `MyCMS.Web.API` is the startup project
- Select `Build solution` from the solution context menu
- Run the project

# <a id="toc-configuring-mycms"></a>Configuring MyCMS

You can configure MyCMS by changing the `appsettings.json`.

## <a id="toc-appsettings"></a>`appsettings.json`

The `appsettings.json` is located in `MyCMS.Web.API` project directory.

It's the main configuration file of the .NET application and contains specific settings defined for MyCMS.

## <a id="toc-mycms-dbsettings"></a>`DBSettings`

You can change this setting in order to change the database provider and the connection string to your database of preference. As a default MyCMS uses a [SQLite](https://www.sqlite.org/) database located inside the `TestData` folder of the `MyCMS.Data` project.

```json
...
"DBSettings": {
  "DataProviderType": "SQLite",
  "ConnectionString": "Filename=C:\\dev\\GitHub\\MyCMS\\MyCMS.Data\\TestData\\MyCMS.db"
}
...
```

### <a id="toc-mycms-dataprovidertype"></a>`DataProviderType`
⚠️At the moment the only available provider is the SQLite one!

With the DataProviderType setting you can change the Database to use for your MyCMS instance.

The accepted values are the ones defined in the `MyCMS.Data.DataProviderType` enum file:
```csharp
namespace MyCMS.Data
{
    public enum DataProviderType
    {
        SQLite,
        MySQL,
        SQLServer,
        PostgreSQL,
        Oracle
    }
}
```

### <a id="toc-mycms-connectionstring"></a>`ConnectionString`

With this setting you can provide the specific connection string to connect to your database instance. The default value is the SQLite file location used for testing.

# <a id="toc-mycms-content"></a>Defining MyCMS content
⚠️ MyCMS UI is not yet available so you need to populate the database manually!

In MyCMS all the contents are stored in a single table called `Content`, a content record belongs to a specificy content type defined in the `ContentType` table.

The content of a specific content record could be extended by adding attributes via the `ContentAttribute` table. Those attributes are not strictly related to the selected content type of the content record.

Attributes are stored in the `Attribute` table and this is the list of supported types:
 - Text
 - Number
 - Date
 - Select (options are defined in the `AttributeOption` table)

 Content could be related to other content via the `ContentRelation` table, every relation instance is related to a relation type stored in the `ContentRelationType`.

 For example, a content of type "Image" could be related to a content of type "Article" by a relation of type "default image".

# <a id="toc-mycms-support"></a>MyCMS Support

⚠️ MyCMS is not finished and it's not intended for a production release but just for study purpose.

If you want to contribute to MyCMS you can do it by the following channels.

## <a id="toc-mycms-issues"></a>My CMS Issues

MyCMS uses the issue tracker provided by
[Github](http://github.com).

You can see all the open and closed issues on
[Github](https://github.com/manuelebagnolini/MyCMS/issues).

If you want to open a new issue:

- [Search for an existing issue](https://github.com/manuelebagnolini/MyCMS/issues)
- [Create a new bug report](https://github.com/manuelebagnolini/MyCMS/issues/new)
  or [request a new feature](https://github.com/manuelebagnolini/MyCMS/issues/new)