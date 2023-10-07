/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 16.0 		*/
/*  Created On : 07-oct.-2023 5:50:00 p. m. 				*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_DetallesFactura_EncabezadoFacturas]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [DetallesFactura] DROP CONSTRAINT [FK_DetallesFactura_EncabezadoFacturas]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_DetallesFactura_Productos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [DetallesFactura] DROP CONSTRAINT [FK_DetallesFactura_Productos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_EncabezadoFacturas_TiposPago]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [EncabezadoFacturas] DROP CONSTRAINT [FK_EncabezadoFacturas_TiposPago]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_EncabezadoFacturas_Usuarios]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [EncabezadoFacturas] DROP CONSTRAINT [FK_EncabezadoFacturas_Usuarios]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Usuarios_TipoUsuario]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Usuarios] DROP CONSTRAINT [FK_Usuarios_TipoUsuario]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ValoracionProducto_Productos]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ValoracionProducto] DROP CONSTRAINT [FK_ValoracionProducto_Productos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_ValoracionProducto_Usuarios]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [ValoracionProducto] DROP CONSTRAINT [FK_ValoracionProducto_Usuarios]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Categorias]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Categorias]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[DetallesFactura]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [DetallesFactura]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[EncabezadoFacturas]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [EncabezadoFacturas]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ProductoCategorias]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ProductoCategorias]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Productos]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Productos]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TiposPago]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [TiposPago]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TipoUsuario]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [TipoUsuario]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Usuarios]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Usuarios]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[ValoracionProducto]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [ValoracionProducto]
GO

/* Create Tables */

CREATE TABLE [Categorias]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[nombre] varchar(50) NOT NULL,
	[imagen] varchar(max) NULL,
	[identificador] varchar(50) NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [DetallesFactura]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[idEncabezadoFactura] int NOT NULL,
	[idProducto] int NOT NULL,
	[valorUnitarioProducto] money NOT NULL,
	[cantidadProductos] int NOT NULL,
	[valorTotalProductos] money NOT NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [EncabezadoFacturas]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[idUsuario] int NOT NULL,
	[fechaFactura] datetime NOT NULL,
	[totalSinImpuesto] money NOT NULL,
	[totalConImpuesto] money NOT NULL,
	[impuesto] money NOT NULL,
	[direccionEnvio] varchar(300) NULL,
	[direccionFactura] varchar(300) NULL,
	[idTipoPago] int NOT NULL,
	[fechaCreacion] int NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [ProductoCategorias]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[idProducto] int NOT NULL,
	[idCategoria] int NOT NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [Productos]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[nombre] varchar(50) NOT NULL,
	[imagen] varchar(max) NULL,
	[precioUnitario] money NOT NULL,
	[descuento] int NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [TiposPago]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[nombre] varchar(50) NOT NULL,
	[descripcion] varchar(100) NULL,
	[imagen] varchar(max) NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NULL
)
GO

CREATE TABLE [TipoUsuario]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[nombre] varchar(50) NOT NULL,
	[descripcion] varchar(50) NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [Usuarios]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[nombre] varchar(100) NOT NULL,
	[correo] varchar(200) NOT NULL,
	[password] varchar(max) NOT NULL,
	[idTipoUsuario] int NOT NULL,
	[imagen] varchar(max) NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

CREATE TABLE [ValoracionProducto]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[idProducto] int NOT NULL,
	[idUsuario] int NOT NULL,
	[valoracion] int NOT NULL,
	[fechaCreacion] datetime NOT NULL,
	[activo] bit NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Categorias] 
 ADD CONSTRAINT [PK_Categorias]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [DetallesFactura] 
 ADD CONSTRAINT [PK_DetallesFactura]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_DetallesFactura_EncabezadoFacturas] 
 ON [DetallesFactura] ([idEncabezadoFactura] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_DetallesFactura_Productos] 
 ON [DetallesFactura] ([idProducto] ASC)
GO

ALTER TABLE [EncabezadoFacturas] 
 ADD CONSTRAINT [PK_EncabezadoFacturas]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_EncabezadoFacturas_TiposPago] 
 ON [EncabezadoFacturas] ([idTipoPago] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_EncabezadoFacturas_Usuarios] 
 ON [EncabezadoFacturas] ([idUsuario] ASC)
GO

ALTER TABLE [ProductoCategorias] 
 ADD CONSTRAINT [PK_ProductoCategorias]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ProductoCategorias_Categorias] 
 ON [ProductoCategorias] ([idCategoria] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ProductoCategorias_Productos] 
 ON [ProductoCategorias] ([idProducto] ASC)
GO

ALTER TABLE [Productos] 
 ADD CONSTRAINT [PK_Productos]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [TiposPago] 
 ADD CONSTRAINT [PK_TiposPago]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [TipoUsuario] 
 ADD CONSTRAINT [PK_TipoUsuario]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [Usuarios] 
 ADD CONSTRAINT [PK_Usuarios]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Usuarios_TipoUsuario] 
 ON [Usuarios] ([idTipoUsuario] ASC)
GO

ALTER TABLE [ValoracionProducto] 
 ADD CONSTRAINT [PK_ValoracionProducto]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ValoracionProducto_Productos] 
 ON [ValoracionProducto] ([idProducto] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_ValoracionProducto_Usuarios] 
 ON [ValoracionProducto] ([idUsuario] ASC)
GO

/* Create Foreign Key Constraints */

ALTER TABLE [DetallesFactura] ADD CONSTRAINT [FK_DetallesFactura_EncabezadoFacturas]
	FOREIGN KEY ([idEncabezadoFactura]) REFERENCES [EncabezadoFacturas] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [DetallesFactura] ADD CONSTRAINT [FK_DetallesFactura_Productos]
	FOREIGN KEY ([idProducto]) REFERENCES [Productos] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [EncabezadoFacturas] ADD CONSTRAINT [FK_EncabezadoFacturas_TiposPago]
	FOREIGN KEY ([idTipoPago]) REFERENCES [TiposPago] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [EncabezadoFacturas] ADD CONSTRAINT [FK_EncabezadoFacturas_Usuarios]
	FOREIGN KEY ([idUsuario]) REFERENCES [Usuarios] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Usuarios] ADD CONSTRAINT [FK_Usuarios_TipoUsuario]
	FOREIGN KEY ([idTipoUsuario]) REFERENCES [TipoUsuario] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [ValoracionProducto] ADD CONSTRAINT [FK_ValoracionProducto_Productos]
	FOREIGN KEY ([idProducto]) REFERENCES [Productos] ([id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [ValoracionProducto] ADD CONSTRAINT [FK_ValoracionProducto_Usuarios]
	FOREIGN KEY ([idUsuario]) REFERENCES [Usuarios] ([id]) ON DELETE No Action ON UPDATE No Action
GO