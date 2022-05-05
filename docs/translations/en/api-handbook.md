# MyCMS API Handbook

Written by [Manuele Bagnolini](https://github.com/manuelebagnolini/)

This document covers everything you ever wanted to know about using [MyCMS](https://github.com/manuelebagnolini/MyCMS) as the CMS of your front-end application.

This handbook is available in other languages, see the [README](/docs/README.md) for a complete list.

# Table of Contents

- [Introduction](#toc-introduction)
- [MyCMS headless architecture](#toc-mycms-architecture)
- [What is GraphQL?](#toc-what-is-graphql)
- [Installing a GraphQL client](#toc-graphql-client)
- [Banana Cake Pop](#toc-banana-cake-pop)
- [Content Schema](#toc-content-schema)
- [ContentQuery](#toc-content-query)
    - [Cursor pagination](#toc-cursor-pagination)

# <a id="toc-introduction"></a>Introduction
MyCMS is a simple, lightweight headless CMS queryable via a single GraphQL endpoint.

It's based on a relational database table structure able to create custom attribute for every type of content defined in your project.

MyCMS is based on [.NET6](https://docs.microsoft.com/it-it/dotnet/core/whats-new/dotnet-6) web framework, it uses [EF Core](https://docs.microsoft.com/ef/core/) for the data layer and [Hot Chocolate](https://chillicream.com/docs/hotchocolate/get-started) as GraphQL server.

In this handbook you will learn how to connect your front-end application to the MyCMS GraphQL endpoint.

# <a id="toc-mycms-architecture"></a>MyCMS headless architecture
The main core of MyCMS is the API service that exposes the `/graphql` endpoint.

Using this endpoint you can query all the contents inside the MyCMS database in the desired format that you need using the full potential of GraphQL technology.

![context](/docs/c4/png/container.png)

# <a id="toc-what-is-graphql"></a>What is GraphQL?
GraphQL is a query language for APIs and a runtime for fulfilling those queries with your existing data. GraphQL provides a complete and understandable description of the data in your API, gives clients the power to ask for exactly what they need and nothing more, makes it easier to evolve APIs over time, and enables powerful developer tools.

You can learn more about GraphQL [here](https://graphql.org/).

# <a id="toc-graphql-client"></a>Installing a GraphQL client
In order to connect and interact with the GraphQL endpoint you need to install and setup a GraphQL client in your front-end application setting the host, port and endpoint of the MyCMS instance (default endpoint in `/graphql`)

Once configured properly it will download the schema from the server and create the object types that you can use to build your queries.

In the `MyCMS.Web.Sample` we used [Strawberry Shake](https://chillicream.com/docs/strawberryshake) but you can use whatever client library that you prefer.

# <a id="toc-banana-cake-pop"></a>Banana Cake Pop
Hot Chocolate server includes a Web App called Banana Cake Pop that let's you inspect the GraphQL schema of MyCMS and create and test queries directly in the web app before you include them in you front-end application.

To use Banana Cake Pop simply open the `/graphql/` endpoint via browser and confirm MyCMS graphql endpoint settings.

# <a id="toc-content-schema"></a>Content Schema
MyCMS content schema is based on the `Content` entity.

The `Content` entity could represent everything in MyCMS domain, it can be an article, a page, an image, a comment or whatever it's defined by the `ContentType` entity related to the content.

Contents could be related to other contents by the `contents` relation and the `referencedBy` relation. The first one is used to "compose" a main content with a list of referred content, the second is used to load the parent container of the refferred content.

Contents fields could be extended by adding "attributes" instances to them, you can navigate the `attributes` field in order to select the `ContentAttribute` that contains the attribute name, type and the value of the attribute for the content.

```graphql
type Content {
  attributes(
    where: ContentAttributeFilterInput
    order: [ContentAttributeSortInput!]
  ): [ContentAttribute]
  contents(
    where: ContentRelationFilterInput
    order: [ContentRelationSortInput!]
  ): [ContentRelation]
  referencedBy(
    where: ContentRelationFilterInput
    order: [ContentRelationSortInput!]
  ): [ContentRelation]
  title: String
  body: String
  url: String
  contentTypeId: Int!
  createUserId: Int!
  createDatetime: DateTime!
  modifyUserId: Int!
  modifyDatetime: DateTime!
  contentType: ContentType
  createUser: User
  modifyUser: User
  id: Int!
}

type ContentAttribute {
  contentId: Int!
  attributeId: Int!
  valueText: String
  valueNumber: Int
  valueDate: DateTime
  attributeOptionId: Int
  content: Content
  attribute: Attribute
  attributeOption: AttributeOption
  id: Int!
}

type ContentRelation {
  contentRelationId: Int!
  containerContentId: Int!
  referredContentId: Int!
  contentRelationTypeId: Int!
  containerContent: Content
  referredContent: Content
  contentRelationType: ContentRelationType
  id: Int!
}

type ContentType {
  name: String
  description: String
  id: Int!
}

type ContentRelationType {
  name: String
  description: String
  id: Int!
}

type Attribute {
  name: String
  description: String
  attributeType: AttributeTypes!
  options: [AttributeOption]
  id: Int!
}

enum AttributeTypes {
  TEXT
  NUMBER
  DATE
  SELECT
}

type AttributeOption {
  attributeId: Int!
  value: String
  attribute: Attribute
  id: Int!
}

type User {
  username: String
  name: String
  surname: String
  email: String
  id: Int!
}

```


# <a id="toc-content-query"></a>ContentQuery
The `ContentQuery` is the main query that the endpoint exposes. 

With this query you can:
- **select** only the fields you need to retrieve for the content
- **filter** content on specific field values
- **sort** content result on specific fields
- **paginate** content result based on your front-end pagination

For further detail on the GraphQL syntax specific for MyCMS you can check the Hot Chocolate documentation [here](https://chillicream.com/docs/hotchocolate/fetching-data)

In this example you can create a query that:
- filter only content that is of content type "Article"
- sort the results taking the new articles first
- select content body text and title, author name, attributes with values, and the "Header" image filtering the `Contents` relation.

```graphql
query GetArticle() {
  content(
    where: { 
      contentType: { name : { eq: "Article" }
    }
  }
  order: { 
    createDatetime: DESC 
  }) {
    nodes {
      title
      body
      createDatetime
      createUser {
        username
      }
      attributes {
        attribute {
          name
          attributeType
        }
        attributeOption {
          value
        }
        valueText
        valueDate
        valueNumber
      }
      headerImages: contents(where: {
        and: [
          { contentRelationType: { name: { eq: "Header"} }},
          { referredContent: { contentType: { name: { eq: "Image" } } } }
        ] 
      }) {
        referredContent {
          title
          url
        }
      }
    }
  }
}
```

## <a id="toc-cursor-pagination"></a>Cursor pagination
MyCMS implements by default cursor pagination defined in Hot Chocolate.

In this example you can add pagination filtering to the previous query by:
- passing parameters to the query in order to filter the result based on the current page
- include `pageInfo` object field to the list of selected fields
- nest the content recordset in the `edges` node in order to include the `cursor` of the content

```graphql
query GetArticles($first: Int, $last: Int, $after: String, $before: String) {
  content(
    first: $first
    last: $last
    after: $sfter,
    before: $before
    where: { 
    contentType: { 
      name : { 
        eq: "Article" 
      }
    }
  }
  order: { 
    createDatetime: DESC 
  }) {
    pageInfo {
      hasNextPage
      hasPreviousPage
      startCursor
      endCursor
    }
    edges {
      cursor
      node {
        title
        body
        createDatetime
        createUser {
          username
        }
        attributes {
          attribute {
            name
            attributeType
          }
          attributeOption {
            value
          }
          valueText
          valueDate
          valueNumber
        }
        headerImages: contents(where:
        {
          and: [
            { contentRelationType: { name: { eq: "Header"} }},
            { referredContent: { contentType: { name: { eq: "Image" } } } }
          ] 
        }) {
          referredContent {
            title
            url
          }
        }
      }
    }
  }
}
```

With this query you can save in the state of your front-end application the cursor of every item you downloaded from MyCMS and show the `Prev` and `Next` buttons based on the info you retrived from the `pageInfo` object.

When the user selects the next or the previous page pass this parameters to the query:
- **Next**: `first` = elements per page, `after` = cursor of the **last** article in the current page
- **Prev**: `last` = elements per page, `before` = cursor of the **first** article in the current page

You can find a complete implementation example of cursor pagination in the `MyCMS.Web.Sample` project.