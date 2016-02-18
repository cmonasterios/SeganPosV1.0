CREATE TABLE [dbo].[EPK_EfectivoRemanenteDetalle] (
    [IdEfectivoR]       INT        NOT NULL,
    [IdDenominacion]    TINYINT    NOT NULL,
    [CantidadAlivio]    INT        NOT NULL,
    [CantidadDeposito]  INT        NOT NULL,
    [CantidadRemanente] INT        NOT NULL,
    [CantidadActual]    INT        NOT NULL,
    [tStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_EfectivoRemanenteDetalle] PRIMARY KEY CLUSTERED ([IdEfectivoR] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_EfectivoRemanenteDetalle_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion]),
    CONSTRAINT [FK_EPK_EfectivoRemanenteDetalle_EPK_EfectivoRemanente] FOREIGN KEY ([IdEfectivoR]) REFERENCES [dbo].[EPK_EfectivoRemanenteEncabezado] ([IdEfectivoR])
);






GO

-- ========================================================================
-- Author:		Silvia Derkoyorikian
-- Create date: 10/09/2013
-- Description:	trigger para actualizar el campo CantidadRemanente.
-- ========================================================================
CREATE TRIGGER [dbo].[trg_EPK_EfectivoRemanenteDetalle_IU]
   ON  [dbo].[EPK_EfectivoRemanenteDetalle] 
   AFTER INSERT, UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE ERD
	SET CantidadActual  = ERD.CantidadRemanente + ERD.CantidadAlivio-ERD.CantidadDeposito
	FROM EPK_EfectivoRemanenteDetalle  ERD
	INNER JOIN inserted I
		ON	ERD.IdEfectivoR = I.IdEfectivoR 
		AND	ERD.IdDenominacion= I.IdDenominacion

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteDetalle] TO PUBLIC
    AS [dbo];

