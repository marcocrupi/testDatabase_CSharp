# testDatabase_CSharp

Questo repository contiene il progetto `testDatabase_CSharp`, un'applicazione console C# che dimostra l'interazione con un database SQL Server. L'applicazione utilizza Dapper, un micro ORM, per eseguire operazioni di inserimento e recupero dei dati dalla tabella `Computer`.

## Funzionalità

L'applicazione è in grado di:

- Connettersi a un database SQL Server locale.
- Inserire nuovi record nella tabella `Computer`.
- Recuperare e visualizzare i record inseriti.

## Prerequisiti

Prima di eseguire questa applicazione, assicurati di avere:

- .NET 8.0 SDK installato sul tuo sistema.
- SQL Server in esecuzione localmente.
- Un database denominato `testDatabase` creato e configurato secondo lo schema fornito.

## Configurazione

Per configurare il progetto:

1. Clona il repository: git clone [URL del repository]
2. Naviga nella cartella del progetto clonato.
3. Assicurati che la stringa di connessione nel file `Program.cs` corrisponda alla configurazione del tuo ambiente di database.

## Esecuzione dell'applicazione

Per eseguire l'applicazione:

1. Apri un terminale o una console di comando.
2. Naviga nella directory del progetto.
3. Esegui il comando: dotnet run


## Schema del Database

Il database utilizzato dall'applicazione segue questo schema:

```sql
CREATE DATABASE testDatabase
GO

USE testDatabase
GO

CREATE SCHEMA testAppSchema
GO

CREATE TABLE testAppSchema.Computer(
 ComputerId INT IDENTITY(1,1) PRIMARY KEY,
 Motherboard NVARCHAR(50),
 CPUCores INT,
 HasWifi BIT,
 HasLTE BIT,
 ReleaseDate DATE,
 Price DECIMAL(18,4),
 VideoCard NVARCHAR(50)
);
