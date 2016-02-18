CREATE TABLE [dbo].[EPK_ActualizacionTienda] (
    [IdActualizacion] INT        NOT NULL,
    [IdTienda]        INT        NOT NULL,
    [FechaEnvio]      DATETIME   NULL,
    [FechaRecepcion]  DATETIME   NULL,
    [FechaProceso]    DATETIME   NULL,
    [TStamp]          ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_ActualizacionTienda_1] PRIMARY KEY CLUSTERED ([IdActualizacion] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_ActualizacionTienda_EPK_ActualizacionEncabezado] FOREIGN KEY ([IdActualizacion]) REFERENCES [dbo].[EPK_ActualizacionEncabezado] ([IdActualizacion]),
    CONSTRAINT [FK_EPK_ActualizacionTienda_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER TRG_EPK_ActualizacionTienda_I
   ON  EPK_ActualizacionTienda
   AFTER INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @IDStatus INT 
	SELECT	@IDStatus = DBO.fn_ObtenerParametroEntero ('ACTRecepcion',GETDATE(),1)
	
    UPDATE A
    SET A.IdEstatus =@IDStatus
    FROM EPK_ActualizacionEncabezado A
    INNER JOIN (SELECT DISTINCT IdActualizacion FROM inserted) I
		ON A.IdActualizacion = I.IdActualizacion 
	
	UPDATE A
    SET A.FechaRecepcion = GETDATE ()
    FROM EPK_ActualizacionTienda  A
    INNER JOIN (SELECT DISTINCT IdActualizacion FROM inserted) I
		ON A.IdActualizacion = I.IdActualizacion 


END