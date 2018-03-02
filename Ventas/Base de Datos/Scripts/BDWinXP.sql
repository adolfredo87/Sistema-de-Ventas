USE [master]
GO

/****** Object:  Database [DemoWinForm]    Script Date: 02/24/2018 01:45:11 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'DemoWinForm')
DROP DATABASE [DemoWinForm]
GO

USE [master]
GO

/****** Object:  Database [DemoWinForm]    Script Date: 30/11/2017 02:00:09 p.m. ******/
CREATE DATABASE [DemoWinForm] ON  PRIMARY 
( NAME = N'DemoWinForm', FILENAME = N'C:\Archivos de programa\Microsoft SQL Server\MSSQL10.SQLSERVER2008\MSSQL\DATA\DemoWinForm.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DemoWinForm_log', FILENAME = N'C:\Archivos de programa\Microsoft SQL Server\MSSQL10.SQLSERVER2008\MSSQL\DATA\DemoWinForm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [DemoWinForm] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoWinForm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DemoWinForm] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DemoWinForm] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DemoWinForm] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DemoWinForm] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DemoWinForm] SET ARITHABORT OFF 
GO

ALTER DATABASE [DemoWinForm] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DemoWinForm] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [DemoWinForm] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DemoWinForm] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DemoWinForm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DemoWinForm] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DemoWinForm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DemoWinForm] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DemoWinForm] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DemoWinForm] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DemoWinForm] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DemoWinForm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DemoWinForm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DemoWinForm] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DemoWinForm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DemoWinForm] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DemoWinForm] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DemoWinForm] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DemoWinForm] SET RECOVERY FULL 
GO

ALTER DATABASE [DemoWinForm] SET  MULTI_USER 
GO

ALTER DATABASE [DemoWinForm] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DemoWinForm] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DemoWinForm] SET  READ_WRITE 
GO

USE [DemoWinForm]
GO

/****** Object:  Table [dbo].[ventasitems]    Script Date: 10/25/2016 15:51:36 ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [DemoWinForm].[dbo].[ventasitems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDVenta] [int] NOT NULL,
	[IDProducto] [int] NOT NULL,
	[PrecioUnitario] [float] NULL,
	[Cantidad] [float] NULL,
	[PrecioTotal] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ventas]    Script Date: 10/25/2016 15:51:36 ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [DemoWinForm].[dbo].[ventas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Total] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[productos]    Script Date: 10/25/2016 15:51:36 ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [DemoWinForm].[dbo].[productos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Precio] [float] NULL,
	[Categoria] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[clientes]    Script Date: 10/25/2016 15:51:36 ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [DemoWinForm].[dbo].[clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](255) NOT NULL,
	[Telefono] [varchar](255) NULL,
	[Correo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_INCCLIENTE]    Script Date: 02/23/2018 16:11:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INCCLIENTE]
( 
  @VCLIENTE AS VARCHAR(100), @VTELEFONO AS VARCHAR(50), @VCORREO AS VARCHAR(200)
 )
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

  IF EXISTS (
              SELECT *
              FROM [DemoWinForm].[dbo].[clientes] WITH (NOLOCK)
              WHERE [Correo] = @VCORREO
            )
    BEGIN
    
      SET @ERRORMESSAGE = 'El correo que esta intentando registrar ya se encuentra asignado a otro cliente'
      SET @ERRORSEVERITY = 16 
      SET @ERRORSTATE = 1     
      GOTO ERROR
    
    END
    
  ELSE
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoWinForm].[dbo].[clientes]
          (Cliente, Telefono, Correo)
        VALUES
          (@VCLIENTE, @VTELEFONO, @VCORREO)
      
      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_MODCLIENTE]    Script Date: 02/23/2018 16:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_MODCLIENTE]
( 
  @ICLIENTE AS INT, @VCLIENTE AS VARCHAR(100), @VTELEFONO AS VARCHAR(50), @VCORREO AS VARCHAR(200)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET A1.Cliente = @VCLIENTE,
          A1.Telefono = @VTELEFONO,
          A1.Correo = @VCORREO
      FROM [DemoWinForm].[dbo].[clientes] A1
      WHERE A1.ID = @ICLIENTE
    
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_INCPRODUCTO]    Script Date: 02/23/2018 17:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_INCPRODUCTO]
(           
  @VNOMBRE AS VARCHAR(40), @FPRECIO AS FLOAT, @VCATEGORIA AS VARCHAR(100)
)          
AS          
          
SET NOCOUNT ON                  
DECLARE @ERRORMESSAGE NVARCHAR(4000)          
DECLARE @ERRORSEVERITY INT          
DECLARE @ERRORSTATE INT      
          
BEGIN TRY          
          
  IF EXISTS (          
              SELECT *          
              FROM [DemoWinForm].[dbo].[productos] WITH (NOLOCK)          
              WHERE Nombre = @VNOMBRE        
            )          
    BEGIN          
            
      SET @ERRORMESSAGE = 'El nombre o descripcion del producto que esta intentando registrar ya se encuentra en uso'          
      SET @ERRORSEVERITY = 16         
      SET @ERRORSTATE = 1             
      GOTO ERROR              
              
    END
  ELSE
  
    BEGIN
    
      BEGIN TRAN
      
        INSERT INTO [DemoWinForm].[dbo].[productos]
          (Nombre, Precio, Categoria)
        VALUES
          (@VNOMBRE, @FPRECIO, @VCATEGORIA)
      
      COMMIT TRAN
    
    END
    
END TRY          
          
BEGIN CATCH          
              
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()          
  SET @ERRORSEVERITY = ERROR_SEVERITY()            
  SET @ERRORSTATE = ERROR_STATE()        
  GOTO ERROR          
          
END CATCH          
          
SET NOCOUNT OFF          
          
RETURN        
ERROR:        
  IF XACT_STATE() <> 0 ROLLBACK TRAN        
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_MODPRODUCTO]    Script Date: 02/23/2018 16:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_MODPRODUCTO]
( 
  @IDPRODUCTO AS INT, @VNOMBRE AS VARCHAR(40), @FPRECIO AS FLOAT, @VCATEGORIA AS VARCHAR(100)
)
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT  

BEGIN TRY

    BEGIN
    
      BEGIN TRAN
      
      UPDATE A1
      SET A1.Nombre = @VNOMBRE,
          A1.Precio = @FPRECIO,
          A1.Categoria = @VCATEGORIA
      FROM [DemoWinForm].[dbo].[productos] A1
      WHERE A1.ID = @IDPRODUCTO
      
      COMMIT TRAN
      
    END

END TRY

BEGIN CATCH

  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR
  
END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_DETVENTA]    Script Date: 02/23/2018 18:34:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO  
CREATE PROCEDURE [dbo].[USP_DETVENTA]
(   
  @VENTAS AS XML, @ID AS INT
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 

BEGIN TRY 

CREATE TABLE #VENTAS
(
	IDVenta INT, IPORDUCTO INT, FPRECIO FLOAT, ICANTIDAD INT, NMONTO FLOAT
)

INSERT INTO #VENTAS
SELECT DISTINCT
IDVenta = R.x.value('@IDVenta[1]', 'INT'),
IPORDUCTO = R.x.value('@IPORDUCTO[1]', 'INT'),
FPRECIO = R.x.value('@FPRECIO[1]', 'FLOAT'),
ICANTIDAD = R.x.value('@ICANTIDAD[1]', 'INT'),
NMONTO = R.x.value('@NMONTO[1]', 'FLOAT')
FROM
@VENTAS.nodes('VENTAS/DETALLE') AS R(x)

BEGIN TRAN

	DECLARE @INUMERO INT 
	DECLARE @IDVenta INT
	DECLARE @IPORDUCTO INT
	DECLARE @FPRECIO FLOAT
	DECLARE @ICANTIDAD INT
	DECLARE @NMONTO FLOAT
	
	IF (@ID != 0) 
	BEGIN
		DELETE [DemoWinForm].[dbo].[ventasitems] WHERE IDVenta = @ID
	END
	
    DECLARE VENTAS_CURSOR CURSOR FOR 
	SELECT IDVenta,IPORDUCTO,FPRECIO,ICANTIDAD,NMONTO FROM #VENTAS
	OPEN VENTAS_CURSOR  
    FETCH NEXT FROM VENTAS_CURSOR INTO @IDVenta,@IPORDUCTO,@FPRECIO,@ICANTIDAD,@NMONTO
    WHILE @@FETCH_STATUS = 0  
    BEGIN
		
		INSERT INTO [DemoWinForm].[dbo].[ventasitems] 
			(IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) 
		VALUES
			(@IDVenta, @IPORDUCTO, @FPRECIO, @ICANTIDAD, @NMONTO)

	    FETCH NEXT FROM VENTAS_CURSOR INTO @IDVenta,@IPORDUCTO,@FPRECIO,@ICANTIDAD,@NMONTO
    END  
    CLOSE VENTAS_CURSOR 
    DEALLOCATE VENTAS_CURSOR  
COMMIT TRAN

END TRY  
  
BEGIN CATCH  
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()  
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()    
  GOTO ERROR  
  
END CATCH  
  
SET NOCOUNT OFF  
  
RETURN  
ERROR:  
  IF XACT_STATE() <> 0 ROLLBACK TRAN  
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_INCVENTA]    Script Date: 02/23/2018 17:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
CREATE PROCEDURE [dbo].[USP_INCVENTA] 
(   
  @ICLIENTE AS INT, @DFECHA AS DATETIME, @DTOTAL AS NUMERIC(19,2), @VENTAS AS XML
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @INUMERO INT  

BEGIN TRY  
  
    BEGIN  
      
      BEGIN TRAN
      
		INSERT INTO [DemoWinForm].[dbo].[ventas]
          (IDCliente, Fecha, Total)
        VALUES  
          (@ICLIENTE, @DFECHA, @DTOTAL) 
        
        SET @INUMERO = (SELECT TOP 1 ID FROM [DemoWinForm].[dbo].[ventas] ORDER BY ID DESC)
		
		--REGISTRA EL DETALLE 
		EXEC USP_DETVENTA @VENTAS, @INUMERO

      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
/****** Object:  StoredProcedure [dbo].[USP_MODVENTA]    Script Date: 02/23/2018 17:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO 
CREATE PROCEDURE [dbo].[USP_MODVENTA] 
(   
  @ID AS INT, @ICLIENTE AS INT, @DFECHA AS DATETIME, @DTOTAL AS FLOAT, @VENTAS AS XML
)
AS

SET NOCOUNT ON  
DECLARE @ERRORMESSAGE NVARCHAR(4000)  
DECLARE @ERRORSEVERITY INT  
DECLARE @ERRORSTATE INT 
DECLARE @INUMERO INT  

BEGIN TRY  
  
    BEGIN  
      
      BEGIN TRAN
          
        UPDATE [DemoWinForm].[dbo].[ventas]
		SET [IDCliente] = @ICLIENTE,
			[Fecha] = @DFECHA,
			[Total] = @DTOTAL
		WHERE [ID] = @ID
        
        SET @INUMERO = @ID
		
		--REGISTRA EL DETALLE 
		EXEC USP_DETVENTA @VENTAS, @INUMERO

      COMMIT TRAN
    
    END

END TRY

BEGIN CATCH
    
  SET @ERRORMESSAGE = 'ERROR ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '. LINEA ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '. ' + ERROR_MESSAGE()
  SET @ERRORSEVERITY = ERROR_SEVERITY()  
  SET @ERRORSTATE = ERROR_STATE()  
  GOTO ERROR  

END CATCH

SET NOCOUNT OFF

RETURN
ERROR:
  IF XACT_STATE() <> 0 ROLLBACK TRAN
  RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
GO

GO
INSERT INTO [DemoWinForm].[dbo].[clientes] ([Cliente],[Telefono],[Correo])
VALUES	('Pedro Gonzalez','0234-2313098','pedrogonz@gmail.com'), 
		('Wilmer Pacheco','0424-5308590','wilpac@hotmail.com'), 
		('Rafael Briceño','0254-8004554','rafael_brice54@gmail.com')
GO

INSERT INTO [DemoWinForm].[dbo].[productos] ([Nombre],[Precio],[Categoria])
VALUES	('Salsa de Tomate', 10, '2'), ('Leche', 50, '3'), ('Ajo', 6, '1'), 
		('Lechuga', 5, '1'), ('Brocoli', 7, '1'), 
		('Suero', 40, '3'), ('Queso', 35, '3'), 
		('Salsa Inglesa', 9, '2'), ('Salsa Soya', 8, '2')

GO

INSERT INTO [DemoWinForm].[dbo].[ventas]([IDCliente],[Fecha],[Total])
VALUES	(1, GETDATE(), 30), (2, GETDATE(), 100), (3, GETDATE(), 145)

GO

INSERT INTO [DemoWinForm].[dbo].[ventasitems] ([IDVenta],[IDProducto],[PrecioUnitario],[Cantidad],[PrecioTotal])
VALUES	(1, 1, 10, 3, 30), (2, 2, 50, 2, 100), 
		(3, 6, 40, 1, 40), (3, 7, 35, 3, 105)

GO