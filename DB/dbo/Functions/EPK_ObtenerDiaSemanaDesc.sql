
-- =================================================================================
-- Author:		
-- Create date: 16/05/2013
-- Description:	Obtiene el nombre del día según indique el valor del parámetro.
-- =================================================================================
CREATE FUNCTION [dbo].[EPK_ObtenerDiaSemanaDesc]
(
  @DIA    INT
 )
RETURNS VARCHAR(15)
AS
BEGIN
DECLARE @RESULTADO VARCHAR(15)

SET @RESULTADO=
(
  CASE @DIA 
  WHEN 1 THEN
   'Lunes'
  WHEN 2 THEN
   'Martes'
  WHEN 3 THEN
   'Miercoles'
  WHEN 4 THEN
   'Jueves'
  WHEN 5 THEN
   'Viernes'
  WHEN 6 THEN
   'Sabado'
  WHEN 7 THEN
   'Domingo'
  ELSE
   'NE'END
 )
 RETURN @RESULTADO

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ObtenerDiaSemanaDesc] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_ObtenerDiaSemanaDesc] TO PUBLIC
    AS [dbo];

