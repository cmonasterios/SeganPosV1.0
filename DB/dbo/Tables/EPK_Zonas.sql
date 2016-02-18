CREATE TABLE [dbo].[EPK_Zonas] (
    [IdRegion]       INT          NOT NULL,
    [IdZona]         SMALLINT     NOT NULL,
    [Descripcion]    VARCHAR (50) NULL,
    [Intervalos]     VARCHAR (56) NULL,
    [LunesHoraE]     TIME (7)     NULL,
    [LunesHoraS]     TIME (7)     NULL,
    [MartesHoraE]    TIME (7)     NULL,
    [MartesHoraS]    TIME (7)     NULL,
    [MiercolesHoraE] TIME (7)     NULL,
    [MiercolesHoraS] TIME (7)     NULL,
    [JuevesHoraE]    TIME (7)     NULL,
    [JuevesHoraS]    TIME (7)     NULL,
    [ViernesHoraE]   TIME (7)     NULL,
    [ViernesHoraS]   TIME (7)     NULL,
    [SabadoHoraE]    TIME (7)     NULL,
    [SabadoHoraS]    TIME (7)     NULL,
    [DomingoHoraE]   TIME (7)     NULL,
    [DomingoHoraS]   TIME (7)     NULL,
    [TStamp]         ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Zonas] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdZona] ASC),
    CONSTRAINT [FK_EPK_Zonas_EPK_Region] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO

-- ===================================================================================
-- Author:		Sderkoyorikian
-- Create date: 23/04/2013
-- Description:	Actualiza los campos HoraE y HoraS de cada día según el Intervalo 
-- ===================================================================================
CREATE TRIGGER [dbo].[EPK_Zonas_U]
   ON  [dbo].[EPK_Zonas]
   AFTER UPDATE 
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF (SELECT COUNT (1)
		FROM INSERTED I
		INNER JOIN DELETED D 
			ON I.IdZona = D.IdZona
		WHERE I.Intervalos <> D.Intervalos)>0
		
		BEGIN
	
		UPDATE Z
		SET DomingoHoraE = CAST ((SUBSTRING (I.Intervalos,1,2) +':'+ SUBSTRING (I.Intervalos,3,2))  AS  TIME(7)),
			DomingoHoraS = CAST ((SUBSTRING (I.Intervalos,5,2) +':'+ SUBSTRING (I.Intervalos,7,2))  AS  TIME(7)),
			LunesHoraE = CAST ((SUBSTRING (I.Intervalos,9,2) +':'+ SUBSTRING (I.Intervalos,11,2))  AS  TIME(7)),
			LunesHoraS = CAST ((SUBSTRING (I.Intervalos,13,2) +':'+ SUBSTRING (I.Intervalos,15,2))  AS  TIME(7)),
			MartesHoraE = CAST ((SUBSTRING (I.Intervalos,17,2) +':'+ SUBSTRING (I.Intervalos,19,2))  AS  TIME(7)),
			MartesHoraS = CAST ((SUBSTRING (I.Intervalos,21,2) +':'+ SUBSTRING (I.Intervalos,23,2))  AS  TIME(7)),
			MiercolesHoraE = CAST ((SUBSTRING (I.Intervalos,25,2) +':'+ SUBSTRING (I.Intervalos,27,2))  AS  TIME(7)),
			MiercolesHoraS = CAST ((SUBSTRING (I.Intervalos,29,2) +':'+ SUBSTRING (I.Intervalos,31,2))  AS  TIME(7)),
			JuevesHoraE = CAST ((SUBSTRING (I.Intervalos,33,2) +':'+ SUBSTRING (I.Intervalos,35,2))  AS  TIME(7)),
			JuevesHoraS = CAST ((SUBSTRING (I.Intervalos,37,2) +':'+ SUBSTRING (I.Intervalos,39,2))  AS  TIME(7)),
			ViernesHoraE = CAST ((SUBSTRING (I.Intervalos,41,2) +':'+ SUBSTRING (I.Intervalos,43,2))  AS  TIME(7)),
			ViernesHoraS = CAST ((SUBSTRING (I.Intervalos,45,2) +':'+ SUBSTRING (I.Intervalos,47,2))  AS  TIME(7)),
			SabadoHoraE = CAST ((SUBSTRING (I.Intervalos,49,2) +':'+ SUBSTRING (I.Intervalos,51,2))  AS  TIME(7)),
			SabadoHoraS = CAST ((SUBSTRING (I.Intervalos,53,2) +':'+ SUBSTRING (I.Intervalos,55,2))  AS  TIME(7))
		FROM EPK_Zonas		AS Z
		INNER JOIN inserted AS I 
			ON z.IdZona = I.IdZona
			and z.IdRegion = i.IdRegion 
		END
END
GO

-- ===================================================================================
-- Author:		Sderkoyorikian
-- Create date: 23/04/2013
-- Description:	Actualiza los campos HoraE y HoraS de cada día según el Intervalo 
-- ===================================================================================
CREATE TRIGGER [dbo].[EPK_Zonas_I]
   ON  [dbo].[EPK_Zonas]
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE Z
	SET DomingoHoraE = CAST ((SUBSTRING (I.Intervalos,1,2) +':'+ SUBSTRING (I.Intervalos,3,2))  AS  TIME(7)),
		DomingoHoraS = CAST ((SUBSTRING (I.Intervalos,5,2) +':'+ SUBSTRING (I.Intervalos,7,2))  AS  TIME(7)),
		LunesHoraE = CAST ((SUBSTRING (I.Intervalos,9,2) +':'+ SUBSTRING (I.Intervalos,11,2))  AS  TIME(7)),
		LunesHoraS = CAST ((SUBSTRING (I.Intervalos,13,2) +':'+ SUBSTRING (I.Intervalos,15,2))  AS  TIME(7)),
		MartesHoraE = CAST ((SUBSTRING (I.Intervalos,17,2) +':'+ SUBSTRING (I.Intervalos,19,2))  AS  TIME(7)),
		MartesHoraS = CAST ((SUBSTRING (I.Intervalos,21,2) +':'+ SUBSTRING (I.Intervalos,23,2))  AS  TIME(7)),
		MiercolesHoraE = CAST ((SUBSTRING (I.Intervalos,25,2) +':'+ SUBSTRING (I.Intervalos,27,2))  AS  TIME(7)),
		MiercolesHoraS = CAST ((SUBSTRING (I.Intervalos,29,2) +':'+ SUBSTRING (I.Intervalos,31,2))  AS  TIME(7)),
		JuevesHoraE = CAST ((SUBSTRING (I.Intervalos,33,2) +':'+ SUBSTRING (I.Intervalos,35,2))  AS  TIME(7)),
		JuevesHoraS = CAST ((SUBSTRING (I.Intervalos,37,2) +':'+ SUBSTRING (I.Intervalos,39,2))  AS  TIME(7)),
		ViernesHoraE = CAST ((SUBSTRING (I.Intervalos,41,2) +':'+ SUBSTRING (I.Intervalos,43,2))  AS  TIME(7)),
		ViernesHoraS = CAST ((SUBSTRING (I.Intervalos,45,2) +':'+ SUBSTRING (I.Intervalos,47,2))  AS  TIME(7)),
		SabadoHoraE = CAST ((SUBSTRING (I.Intervalos,49,2) +':'+ SUBSTRING (I.Intervalos,51,2))  AS  TIME(7)),
		SabadoHoraS = CAST ((SUBSTRING (I.Intervalos,53,2) +':'+ SUBSTRING (I.Intervalos,55,2))  AS  TIME(7))
	FROM EPK_Zonas		AS Z
	INNER JOIN inserted AS I 
		ON z.IdZona = I.IdZona
		and z.IdRegion = i.IdRegion 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Zonas] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Zonas] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Zonas] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Zonas] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Zonas] TO PUBLIC
    AS [dbo];

