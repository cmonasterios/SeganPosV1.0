-- =======================================================================================
-- Author:		sderkoyorikian
-- Create date: 06/05/2013
-- Description:	Método que permite actualizar los datos básicos de una terminal biotrack 
--				en la base de datos
-- =======================================================================================
CREATE PROCEDURE [dbo].[EPK_sp_TerminalActualizar]
		 @IdTerminal		INT		=NULL
		,@DireccionIP		VARCHAR(39)	=NULL
		,@Puerto			INT			=NULL
		,@DireccionMAC		VARCHAR(20)	=NULL
		,@VersionFirmware	VARCHAR(50)	=NULL
		,@NumeroDeSerial	VARCHAR(30)	=NULL
		,@Plataforma		VARCHAR(30)	=NULL
		,@CardFun			SMALLINT	=NULL
		,@Estatus			SMALLINT	=NULL
		,@VersionSDK		VARCHAR(50)	=NULL
		,@FechaHoraDispositivo	DATETIME	=NULL
		,@FechaHoraServidor		DATETIME	=NULL
		,@Activo			BIT			=NULL
		,@Modelo			VARCHAR (20)=NULL
		,@CapacidadUsuario	INT	=NULL
		,@CapacidadHuella	INT	=NULL
		,@CantidadLecturas	INT	=NULL
		,@CantidadClaves	INT	=NULL
		,@CantidadHuellas	INT	=NULL
		,@CantidadUsuarios	INT	=NULL
		,@IdRegion			INT =NULL
		,@IdLocalidad		INT =NULL
		,@IdTipoTerminal	SMALLINT	=NULL
		,@Descripcion		VARCHAR(30)	=NULL
		,@Principal			BIT			=NULL
		,@Gateway			VARCHAR(17) =NULL
		,@Mascara			VARCHAR(17)	=NULL
		,@AntiPassback		BIT =NULL 
		--,@IdUsuario			INT         =NULL
		--,@IdAPP				INT
AS
BEGIN
DECLARE @Resultado INT

	BEGIN TRY 
		DECLARE @ChangeResult TABLE (Id INTEGER)
			
		IF (SELECT COUNT (1) FROM EPK_Terminal WHERE DireccionIP = @DireccionIP AND (IdTerminal != @IdTerminal OR @IdTerminal IS NULL))> 0
			BEGIN
				SELECT 'La dirección Ip: '+@DireccionIP+ ' ya está asignada a otro dispositivo' error
				SET @Resultado =0
				RETURN @Resultado
			END  
					
		
		MERGE EPK_Terminal AS target
		USING (SELECT	@IdRegion, @IdLocalidad, @IdTerminal, @IdTipoTerminal, @Descripcion, @DireccionIP, @Puerto, @DireccionMAC,
						@VersionFirmware, @NumeroDeSerial, @VersionSDK, @Plataforma, @CardFun, @Estatus, @FechaHoraDispositivo,
						@FechaHoraServidor, @Activo, @Modelo, @CapacidadUsuario, @CapacidadHuella, @CantidadLecturas, @CantidadClaves,
						@CantidadHuellas, @CantidadUsuarios, @Principal, @Gateway, @Mascara,@AntiPassback) AS source 
						(IdRegion, IdLocalidad, IdTerminal, IdTipoTerminal, Descripcion, DireccionIP, Puerto, DireccionMAC, 
						VersionFirmware, NumeroDeSerial, VersionSDK, Plataforma, CardFun, Estatus, FechaHoraDispositivo,
						FechaHoraServidor, Activo, Modelo, CapacidadUsuario, CapacidadHuella, CantidadLecturas, CantidadClaves,
						CantidadHuellas, CantidadUsuarios, Principal, Gateway, Mascara, AntiPassback)
		ON (target.IdTerminal= source.IdTerminal)
		WHEN MATCHED 
			THEN	UPDATE SET	 IdRegion			= CASE WHEN source.IdRegion		IS NULL	THEN target.IdRegion		ELSE source.IdRegion	END 
								,IdLocalidad		= CASE WHEN source.IdLocalidad	IS NULL	THEN target.IdLocalidad		ELSE source.IdLocalidad	END 
								,Descripcion		= CASE WHEN source.Descripcion	IS NULL	THEN target.Descripcion		ELSE source.Descripcion	END 
								,VersionSDK			= CASE WHEN source.VersionSDK	IS NULL	THEN target.VersionSDK		ELSE source.VersionSDK	END 
								,Plataforma			= CASE WHEN source.Plataforma	IS NULL	THEN target.Plataforma		ELSE source.Plataforma	END 
								,CardFun			= CASE WHEN source.CardFun		IS NULL	THEN target.CardFun			ELSE source.CardFun		END 
								,Estatus			= CASE WHEN source.Estatus		IS NULL	THEN target.Estatus			ELSE source.Estatus		END 
								,Activo				= CASE WHEN source.Activo		IS NULL	THEN target.Activo			ELSE source.Activo		END 
								,Gateway			= CASE WHEN source.Gateway		IS NULL	THEN target.Gateway			ELSE source.Gateway		END 
								,Mascara			= CASE WHEN source.Mascara		IS NULL	THEN target.Mascara			ELSE source.Mascara		END 
								,DireccionMAC		= CASE WHEN source.DireccionMAC		IS NULL	THEN target.DireccionMAC		ELSE source.DireccionMAC		END
								,VersionFirmware	= CASE WHEN source.VersionFirmware	IS NULL	THEN target.VersionFirmware		ELSE  source.VersionFirmware	END 
								,NumeroDeSerial		= CASE WHEN source.NumeroDeSerial	IS NULL	THEN target.NumeroDeSerial		ELSE source.NumeroDeSerial		END  
								,CapacidadUsuario	= CASE WHEN source.CapacidadUsuario IS NULL THEN target.CapacidadUsuario	ELSE source.CapacidadUsuario	END 
								,CapacidadHuella	= CASE WHEN source.CapacidadHuella  IS NULL THEN target.CapacidadHuella		ELSE source.CapacidadHuella		END 
								,CantidadLecturas	= CASE WHEN source.CantidadLecturas IS NULL THEN target.CantidadLecturas	ELSE source.CantidadLecturas	END 
								,CantidadClaves		= CASE WHEN source.CantidadClaves   IS NULL THEN target.CantidadClaves		ELSE source.CantidadClaves		END 
								,CantidadHuellas	= CASE WHEN source.CantidadHuellas  IS NULL THEN target.CantidadHuellas		ELSE source.CantidadHuellas		END 
								,CantidadUsuarios	= CASE WHEN source.CantidadUsuarios IS NULL THEN target.CantidadUsuarios	ELSE source.CantidadUsuarios	END 
								,IdTipoTerminal		= CASE WHEN source.IdTipoTerminal   IS NULL THEN target.IdTipoTerminal		ELSE source.IdTipoTerminal		END 
								,Principal			= CASE WHEN source.Principal		IS NULL	THEN target.Principal			ELSE source.CantidadHuellas		END 
								,AntiPassback		= CASE WHEN source.AntiPassback		IS NULL	THEN target.AntiPassback		ELSE source.AntiPassback		END 
								,FechaHoraDispositivo = CASE WHEN source.FechaHoraDispositivo	IS NULL	THEN (SELECT MAX(FechaLectura) FROM EPK_Lecturas WHERE IdTerminal =@IdTerminal)	ELSE source.FechaHoraDispositivo	END 
								,FechaHoraServidor    = CASE WHEN source.FechaHoraServidor		IS NULL	THEN target.FechaHoraServidor		ELSE source.FechaHoraServidor		END 
		WHEN  NOT MATCHED 
			THEN	INSERT (IdRegion,					IdLocalidad, 
							IdTipoTerminal,				Descripcion, 
							DireccionIP,				Puerto, 
							DireccionMAC,				VersionFirmware, 
							NumeroDeSerial,				VersionSDK, 
							Plataforma,					CardFun, 
							Estatus,					FechaHoraDispositivo,
							FechaHoraServidor,			Activo, 
							Modelo,						CapacidadUsuario, 
							CapacidadHuella,			CantidadLecturas, 
							CantidadClaves,				CantidadHuellas, 
							CantidadUsuarios,			Principal,
							Gateway,					Mascara,
							AntiPassback)
					VALUES (source.IdRegion,			source.IdLocalidad, 
							source.IdTipoTerminal,		source.Descripcion, 
							source.DireccionIP,			source.Puerto, 
							source.DireccionMAC,		source.VersionFirmware, 
							source.NumeroDeSerial,		source.VersionSDK, 
							source.Plataforma,			source.CardFun, 
							source.Estatus,				source.FechaHoraDispositivo,
							source.FechaHoraServidor,	source.Activo, 
							source.Modelo,				source.CapacidadUsuario, 
							source.CapacidadHuella,		source.CantidadLecturas, 
							source.CantidadClaves,		source.CantidadHuellas, 
							source.CantidadUsuarios,	source.Principal,
							source.Gateway,				source.Mascara,
							source.AntiPassback)
		OUTPUT inserted.IdTerminal INTO @ChangeResult;

		SELECT ID FROM @ChangeResult
		
		--IF NOT @IdUsuario IS NULL 
		--	EXEC EPK_sp_AuditoriaActualizar @IdUsuario, @IdAPP             
		--ELSE
		--	BEGIN
		--	SELECT @IdUsuario	 = dbo.fn_ObtenerParametroEntero ('IDAUDITORÍA', getdate ())
		--	EXEC EPK_sp_AuditoriaActualizar @IdUsuario, @IdAPP 
		--	END
		SET @Resultado =1
		RETURN @Resultado
	END TRY 
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		SET @Resultado =0
		RETURN @Resultado
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_TerminalActualizar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_TerminalActualizar] TO PUBLIC
    AS [dbo];

