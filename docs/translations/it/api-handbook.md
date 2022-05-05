# Manuale API MyCMS

Scritto da [Manuele Bagnolini](https://github.com/manuelebagnolini/)

Questo manuale parla di tutto quello che avresti sempre voluto sapere approposito di usare [MyCMS](https://github.com/manuelebagnolini/MyCMS) come CMS collegato alla tua applicazione front-end.

Questo manuale è disponibile anche in altre lingue, vedere il [README](/docs/README.md) per una lista completa

# Indice

- [Introduzione](#toc-introduction)
- [Architettura headless in MyCMS](#toc-mycms-architecture)
- [Che cos'è GraphQL?](#toc-what-is-graphql)
- [Installare un client GraphQL](#toc-graphql-client)
- [Banana Cake Pop](#toc-banana-cake-pop)
- [Content Schema](#toc-content-schema)
- [ContentQuery](#toc-content-query)
    - [Cursor pagination](#toc-cursor-pagination)

# <a id="toc-introduction"></a>Introduzione
MyCMS è un CMS headless semplice, leggero e interrogabile tramite un unico endpoint GraphQL.

E' basato su un database relazionale, la cui struttura permette di creare qualsiasi tipo di contenuto definendo degli attributi custom all'intermo del tuo progetto.

MyCMS è basato su [.NET6](https://docs.microsoft.com/it-it/dotnet/core/whats-new/dotnet-6) web framework, utilizza [EF Core](https://docs.microsoft.com/ef/core/) per l'accesso al database e [Hot Chocolate](https://chillicream.com/docs/hotchocolate/get-started) come server GraphQL.

In questo manuale imparerai come connettere la tua applicazione front-end all'endpoint GraphQL esposto da MyCMS.

# <a id="toc-mycms-architecture"></a>Architettura headless in MyCMS
Il cuore di MyCMS è il servizio API che espone l'endpoint `/graphql`.

Usando questo endpoint puoi interrogare e recuperare i contenuti all'interno di MyCMS nel formato desiderato che ti serve utilizzando tutto il potenziale di GraphQL.

![context](/docs/c4/png/container.png)

# <a id="toc-what-is-graphql"></a>Che cos'è GraphQL?
GraphQL è un linguaggio di interrogazione per API e un runtime per soddisfare quelle interrogazioni con i tuoi dati esistenti. 

GraphQL fornisce una descrizione completa e comprensibile dei dati della tua API, forisce ai client il potere di chiedere al server esattamente quello di cui hanno bisogno e nient'altro, rendendo pià facile evolvere le API nel tempo e fornendo potenti tool di sviluppo.

Puoi imparare di più su GraphQL [qui](https://graphql.org/).

# <a id="toc-graphql-client"></a>Installare un client GraphQL
Per connettere la tua applicazione ed interagire con l'endpoint GraphQL devi installare e configurare un client GraphQL, impostando il server, la porta e l'endpoint dell'istanza MyCMS (l'endpoint di default è `/graphql`)

Una volta configurato scaricherà lo schema dal server e creerà i gli oggetti che ti permetteranno di costruire le tue query.

Nel progetto `MyCMS.Web.Sample` abbiamo utilizzato [Strawberry Shake](https://chillicream.com/docs/strawberryshake) ma puoi utilizzare qualsiasi libreria client preferisci.

# <a id="toc-banana-cake-pop"></a>Banana Cake Pop
Il server Hot Chocolate include la Web App chiamata Banana Cake Pop che ti permette di ispezionare lo schema GraphQL di MyCMS e creare e testare le tue query direttamente sulla web app prima di includerle nella tua applicazione front-end.

Per utilizzare Banana Cake Pop apri semplicemente l'endpoint `/graphql/` tramite il browser e conferma le impostazioni dell'endpoint di MyCMS.

# <a id="toc-content-schema"></a>Content Schema
L'entità `Content` è quella su cui si basa lo schema dei contenuti di MyCMS.

L'entità `Content` può rappresentare qualsiasi cosa nel dominio di MyCMS, può essere un articolo, una pagina, un commento o qualsiasi cosa sia definito dall'entità `ContentType` associata al contenuto.

I contenuti possono essere relazionati fra loro tramite le relazioni `contents` e `referencedBy`.
La prima è usata per "comporre" un contenuto principale con una lista di contenuti correlati, la seconda per caricare il contenuto principale che contiene il riferito.

I campi di un contenuto possono essere estesi aggiungendovi delle istanze di "attributi", puoi proiettare la relazione `attributes` in modo da selezionare i vari `ContentAttribute` associati al contenuto che all'interno contengono il nome dell'attributo, il tipo e i valori specifici per il contenuto.

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
`ContentQuery` è la query princiale esposta dall'endpoint.

Utilizzando questa query puoi:
- **selezionare** solo i campi che ti serve recuperare dai contenuti
- **filtrare** i contenuti in base ai valori di specifici campi
- **ordinare** i contenuti su specifici campi
- **paginare** i risultati in base alla paginazione richiesta dal front-end

Per ulteriori dettagli sulla sintassi GraphQL specifica per MyCMS puoi consultare la documentazione di Hot Chocolate [qui](https://chillicream.com/docs/hotchocolate/fetching-data)

In questo esempio puoi creare una query che:
- filtri solo i contenuti di tipo "Article"
- ordini i risultati prendendo prima gli articoli più nuovi
- selezioni titolo e testo del contenuto, l'autore, gli attributi con i relativi valori, e l'immagine "Header" filtrando la relazione `Contents` in base al tipo di relazione e al tipo di contenuto riferito.

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
MyCMS implementa di default la cursor pagination definita in Hot Chocolate.

In questo esempio puoi aggiungere il filtro paginazione alla query precedente facendo: 
- passare i parametri di paginazione alla query in modo da filtrare i contenuti basandosi sulla pagina corrente
- includere l'oggetto `pageInfo` alla lista dei campi selezionati
- annidare content all'interno del nodo `edges` in modo da includere il `cursor` relativo al contenuto

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

Con questa query puoi salvare nello stato della tua applicazione front-end il cursore di ogni contenuto scaricato da MyCMS e mostrare i pulsanti `Prev` e `Next` basandoti sui valori presenti nell'oggetto `pageInfo`.

Quando l'utente seleziona la prossima pagina o la precedente passa questi parametri alla query:
- **Next**: `first` = numero di elementi per pagina, `after` = cursore dell'**ultimo** articolo presente nella pagina corrente
- **Prev**: `last` = numero di elementi per pagina, `before` = cursore del **primo** articolo presente nella pagina corrente

Puoi trovare una completa implementazione di esempio di cursor pagination nel progetto `MyCMS.Web.Sample`.