# Manuale utente MyCMS

Scritto da [Manuele Bagnolini](https://github.com/manuelebagnolini/)

Questo documento tratta di tutto quello che avresti sempre voluto sapere su [MyCMS](https://github.com/manuelebagnolini/MyCMS) e i relativi tool.

Questo manuale è disponbile anche in altre lingue, vedere il [README](/docs/README.md) per una lista completa.

# Indice

- [Introduzione](#toc-introduction)
- [Che cos'è un CMS headless?](#toc-what-is-headless)
- [Iniziare con MyCMS](#toc-setting-up-mycms)
  - [Requisiti](#toc-mycms-requirements)
  - [Scaricare il codice](#toc-mycms-code)
  - [Avviare MyCMS](#toc-mycms-run)
    - [Avviare da riga di comando](#toc-mycms-run-cmd)
    - [Avviare in Visual Studio](#toc-mycms-run-vs)
- [Configurare MyCMS](#toc-configuring-mycms)
  - [`appsettings.json`](#toc-appsettings)
  - [`DBSettings`](#toc-mycms-dbsettings)
    - [`DataProviderType`](#toc-mycms-dataprovidertype)
    - [`ConnectionString`](#toc-mycms-connectionstring)
- [Definire i contenuti in MyCMS](#toc-mycms-content)
- [MyCMS Supporto](#toc-mycms-support)
  - [MyCMS Issues](#toc-mycms-issues)

# <a id="toc-introduction"></a>Introduzione

MyCMS è un CMS headless semplice, leggero e interrogabile tramite un unico endpoint GraphQL.

E' basato su un database relazionale, la cui struttura permette di creare qualsiasi tipo di contenuto definendo degli attributi custom all'intermo del tuo progetto.

MyCMS è basato su [.NET6](https://docs.microsoft.com/it-it/dotnet/core/whats-new/dotnet-6) web framework, utilizza [EF Core](https://docs.microsoft.com/ef/core/) per l'accesso al database e [Hot Chocolate](https://chillicream.com/docs/hotchocolate/get-started) come server GraphQL.

In questo manuale imparerai come configurare e utilizzare MyCMS per organizzare i tuoi contenuti all'interno della struttura del database.

----

# <a id="toc-what-is-headless"></a>Che cos'è un CMS headless?

Un Content Management System headless (Sistema di gestione dei contenuti), o CMS headless, è un sistema di gestione dei contenuti solo back-end che agisce principalmente come repository dei contenuti. Un CMS headless permette di accedere ai contenuti tramite una API per permettere di visualizzarli su qualsiasi dispositivo senza uno specifico front-end o livello di presentazione. Il termine "headless" indica il concetto di tagliare la "testa" (il front end) dal "corpo" (il back end).

![context](/docs/c4/png/context.png)

# <a id="toc-setting-up-mycms"></a>Iniziare con MyCMS

Non esiste un eseguibile di installazione per MyCMS, devi scaricare il codice sorgente direttamente dal repository e compilarlo localmente sulla tua macchina.

## <a id="toc-mycms-requirements"></a>Requisiti

Per compilare MyCMS devi scaricare l'ultima versione di [.NET6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), puoi avviare la compilazione direttamente da riga di comando o puoi fartlo utilizzando [Visual Studio](https://visualstudio.microsoft.com/).

## <a id="toc-mycms-code"></a>Scaricare il codice

Clona il repository utilizzando il comando `git clone https://github.com/manuelebagnolini/MyCMS.git` e fai il checkout sul branch principale (main).

## <a id="toc-mycms-run"></a>Avviare MyCMS

Prima di avviare MyCMS devi compilare il il progetto `MyCMS.Web.Api` e poi lanciarlo. Puoi farlo da riga di comando o utilizzando Visual Studio.

### <a id="toc-mycms-run-cmd"></a>Avviare da riga di comando
- Naviga fino alla cartella `MyCMS.Web.API`.
- Esegui `dotnet build`.
- Esegui `dotnet run` (or `dotnet watch` for live coding)
- Apri nel tuo browser l'URL `https://localhost:7040/graphql/` per testare l'endpoint GraphQL.

### <a id="toc-mycms-run-vs"></a>Avviare in Visual Studio
- Apri `MyCMS.sln` e aspetta che Visual Studio finisca il ripristino dei pacchetti Nuget
- Assicurati che `MyCMS.Web.API` sia impostato come il progetto di avvio 
- Seleziona `Compila soluzione` dal menà contestuale della soluzione
- Avvia il progetto

# <a id="toc-configuring-mycms"></a>Configurare MyCMS

Puoi configurare MyCMS modificando il file `appsettings.json`

## <a id="toc-appsettings"></a>`appsettings.json`

Il file `appsettings.json` si trova all'interno della cartella del progetto `MyCMS.Web.API`.

E' il file di configurazione principale dell'applicazione .NET e contiente anche settaggi specifici per MyCMS.

## <a id="toc-mycms-dbsettings"></a>`DBSettings`

Puoi modificare questo parametro in modo da cambiare il database provider e la stringa di connessione al tuo database di preferenza. Come default MyCMS utilizza un database [SQLite](https://www.sqlite.org/) il cui file è posizionato all'interno della cartella `TestData` del progetto `MyCMS.Data`.

```json
...
"DBSettings": {
  "DataProviderType": "SQLite",
  "ConnectionString": "Filename=C:\\dev\\GitHub\\MyCMS\\MyCMS.Data\\TestData\\MyCMS.db"
}
...
```

### <a id="toc-mycms-dataprovidertype"></a>`DataProviderType`
⚠️Al momento l'unico database provider disponibile è solo quello per SQLite!

Utilizzando il parametro `DataProviderType` puoi cambiare il database da utilizzare per la tua istanza di MyCMS.

I valori accettati sono quelli presenti nel file enum `MyCMS.Data.DataProviderType`:
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

Con questo parametro puoi fornire la specifica stringa di connessione alla tua istanza del database. Il valore di default è la locazione del file SQLite di test.

# <a id="toc-mycms-content"></a>Definire i contenuti in MyCMS
⚠️ L'interfaccia grafica (UI) di MyCMS non è ancora disponibile, devi popolare manualmente le tabelle del database!

In MyCMS tutti i contenuti vengono salvati in una singola tabella chiamata `Content`, ogni record di questa tabella appartiente a uno specifico tipo definito all'interno della tabella `ContentType`.

Il contenuto di uno specifico record può essere esteso aggiungendo degli attributi custom tramite la tabella `ContentAttribute`. Questi attributi non sono strettamente legati al tipo di contenuto specificato per il record.

Gli attributi disponibili sono salvati nella tabella `Attribute`, i tipi di attributo supportati sono:
 - Text
 - Number
 - Date
 - Select (le opzioni disponibili vanno salvate nella tabella `AttributeOption`)

I contenuti possono essere relazionati fra loro tramite la tabella `ContentRelation`, ogni istanza di questa tabella è associata ad un particolare tipo di relazione definito nella tabella `ContentRelationType`.

Per esempio, un contenuto di tipo "Immagine" può essere associato ad un contenuto di tipo "Articolo" tramite una relazione di tipo "Immagine di default".

# <a id="toc-mycms-support"></a>Supporto MyCMS

⚠️ MyCMS non è ancora finito e non è pensato per essere utilizzato in produzione ma solo come finalità di studio.

Se vuoi contribuire a MyCMS puoi farlo tramite i seguenti canali.

## <a id="toc-mycms-issues"></a>My CMS Issues

MyCMS utilizza l'issue tracker messo a disposizione da GitHub
[Github](http://github.com).

Puoi vedere tutte le issue aperte e chiuse su
[Github](https://github.com/manuelebagnolini/MyCMS/issues).

Se vuoi aprire una nuova issue:

- [Cerca una issue esistente](https://github.com/manuelebagnolini/MyCMS/issues)
- [Riporta un bug](https://github.com/manuelebagnolini/MyCMS/issues/new)
  o [Richiedi una nuova funzionalità](https://github.com/manuelebagnolini/MyCMS/issues/new)