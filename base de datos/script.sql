USE master
go


------ Creacion de una base de datos -------------------------------------------------------------------------
IF exists(SELECT * FROM SysDataBases WHERE name='EjemploExtraBD')
BEGIN
	DROP DATABASE EjemploExtraBD
END
go

CREATE DATABASE EjemploExtraBD
go

------- Creacion de Tablas-------------------------------------------------------------------------------------
USE EjemploExtraBD
go

CREATE TABLE UnaTabla(
	IdID int not null Identity Primary Key,
	Campo2 Varchar(10) not null,
	Campo3 datetime not null,
	Campo4 datetime not null,
	check(Campo3<campo4) -- ejemplo de check que compara dos o mas campos
)
go

------- SP-----------------------------------------------------------------------------------------------------
CREATE PROCEDURE CreoUsuario @nomU varchar(20), @passU varchar(10) AS
Begin
	Declare @VarSentencia varchar(200)
	
	--valido que no exista un usuario con el mismo nombre
	if (exists(select * from sys.server_principals where name = @nomU AND type='U'))
	   return -1
	   
	-- Multiples acciones - TRN
	Begin TRAN
	
		--primero creo el usuario de logueo
		Set @VarSentencia = 'CREATE LOGIN [' +  @nomU + '] WITH PASSWORD = ' + QUOTENAME(@passU, '''')
		Exec (@VarSentencia)
		
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -2
		end
		
		---segundo creo usuario bd
		Set @VarSentencia = 'Create User [' +  @nomU + '] From Login [' + @nomU + ']'
		Exec (@VarSentencia)
		
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -3
		end

	Commit TRAN
		
	--asigno rol de servidor al usuario recien creado
		Exec sp_addsrvrolemember @loginame=@nomU, @rolename='securityAdmin'
		
	-- asigno rol de bd al usuario recien creado
		Exec sp_addrolemember @rolename='db_owner', @membername=@nomU

End
go


---------Seccion Nuevo -------------------------------------------------------

---- SP creo usuario comun ------------- 
CREATE PROCEDURE CreoUsuarioComun @nomU varchar(20), @passU varchar(10) AS
Begin
	Declare @VarSentencia varchar(200)
	
  
	-- Multiples acciones - TRN
	Begin TRAN
	
		--primero creo el usuario de logueo
		Set @VarSentencia = 'CREATE LOGIN [' +  @nomU + '] WITH PASSWORD = ' + QUOTENAME(@passU, '''')
		Exec (@VarSentencia)
		
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -2
		end
		
		---segundo creo usuario bd
		Set @VarSentencia = 'Create User [' +  @nomU + '] From Login [' + @nomU + ']'
		Exec (@VarSentencia)
		
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -3
		end

		---segundo creo usuario bd
		Set @VarSentencia = 'GRANT EXECUTE TO [' +  @nomU + ']'
		Exec (@VarSentencia)
		
		if (@@ERROR <> 0)
		Begin
			Rollback TRAN
			return -3
		end

	Commit TRAN
		

End
go

-----SP prueba mantenimiento con usuario comun -----------
CREATE PROCEDURE AltaTabla AS
Begin
	
	INSERT into UnaTabla(Campo2,Campo3,Campo4) 
	            Values('Un Texto', DateAdd(yy,-1,GETDATE()), GETDATE())
End



go

--creo un usuario de seguridad
exec CreoUsuario 'NuevoAdmin', '1234'
go
 
