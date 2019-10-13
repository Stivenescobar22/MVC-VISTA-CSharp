CREATE TABLE TblContacto(
    Id int NOT NULL PRIMARY KEY,
	Nombre varchar(50) null,
	Telefono varchar(20) null 

    
)

 INSERT into dbo.TblContacto (Id, Nombre, Telefono)
	 values (1,'juana de Arco','1234567')

	 SELECT * FROM dbo.TblContacto

	CREATE PROC SPContacto
	@opc INT,
	@Id INT = null,
	@Nombre VARCHAR(50) = NULL,
	@Telefono VARCHAR(20) = NULL
	AS

	IF @opc = 1 
	BEGIN 
	    SELECT * FROM TblContacto
    END
	GO