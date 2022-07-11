CREATE TABLE [dbo].classifica
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome_giocatore] VARCHAR(50) NOT NULL, 
    [punteggio] INT NOT NULL, 
    [numero_partite] INT NOT NULL, 
    [data_partita] DATETIME NOT NULL
)