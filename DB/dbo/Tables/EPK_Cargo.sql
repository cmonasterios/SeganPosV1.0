CREATE TABLE [dbo].[EPK_Cargo] (
    [IdCargo]            INT            IDENTITY (1, 1) NOT NULL,
    [CodCargo]           CHAR (21)      NULL,
    [NombreCargo]        VARCHAR (50)   NOT NULL,
    [IdNivel]            TINYINT        NULL,
    [ComisionTotal]      BIT            NULL,
    [PorcentajeComision] NUMERIC (8, 6) NULL,
    [FechaCreacion]      DATETIME       CONSTRAINT [DF_EPK_Cargo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [CargoComision]      VARCHAR (5)    NULL,
    [TStamp]             ROWVERSION     NOT NULL,
    CONSTRAINT [PK_EPK_Cargo] PRIMARY KEY CLUSTERED ([IdCargo] ASC)
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Cargo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Cargo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Cargo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Cargo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Cargo] TO PUBLIC
    AS [dbo];

