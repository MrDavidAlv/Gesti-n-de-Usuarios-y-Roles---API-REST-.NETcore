USE [PruebaTecnicaAspNetCore]
GO
/****** Object:  Schema [par]    Script Date: 22/06/2024 1:27:26 p. m. ******/
CREATE SCHEMA [par]
GO
/****** Object:  Schema [usuario]    Script Date: 22/06/2024 1:27:26 p. m. ******/
CREATE SCHEMA [usuario]
GO
/****** Object:  Table [par].[ciudad]    Script Date: 22/06/2024 1:27:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [par].[ciudad](
	[idCiudad] [int] IDENTITY(1,1) NOT NULL,
	[nombreCiudad] [varchar](100) NULL,
	[idPais] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[idCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [par].[pais]    Script Date: 22/06/2024 1:27:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [par].[pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombrePais] [varchar](100) NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [par].[roles]    Script Date: 22/06/2024 1:27:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [par].[roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombreRol] [varchar](100) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [usuario].[datosUsuario]    Script Date: 22/06/2024 1:27:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [usuario].[datosUsuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NOT NULL,
	[apellidos] [varchar](100) NOT NULL,
	[tipoDocumento] [int] NOT NULL,
	[documento] [int] NOT NULL,
	[fechaNacimiento] [datetime] NULL,
	[email] [varchar](150) NOT NULL,
	[password] [varchar](250) NOT NULL,
	[idCiudad] [int] NULL,
	[idPais] [int] NULL,
	[idRol] [int] NULL,
 CONSTRAINT [PK_datosUsuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [par].[ciudad] ON 
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (1, N'Ciudad de México', 1)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (2, N'Guadalajara', 1)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (3, N'Monterrey', 1)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (4, N'Buenos Aires', 2)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (5, N'Córdoba', 2)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (6, N'Rosario', 2)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (7, N'Bogotá', 3)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (8, N'Medellín', 3)
GO
INSERT [par].[ciudad] ([idCiudad], [nombreCiudad], [idPais]) VALUES (9, N'Cali', 3)
GO
SET IDENTITY_INSERT [par].[ciudad] OFF
GO
SET IDENTITY_INSERT [par].[pais] ON 
GO
INSERT [par].[pais] ([idPais], [nombrePais]) VALUES (1, N'México')
GO
INSERT [par].[pais] ([idPais], [nombrePais]) VALUES (2, N'Argentina')
GO
INSERT [par].[pais] ([idPais], [nombrePais]) VALUES (3, N'Colombia')
GO
SET IDENTITY_INSERT [par].[pais] OFF
GO
SET IDENTITY_INSERT [par].[roles] ON 
GO
INSERT [par].[roles] ([idRol], [nombreRol]) VALUES (1, N'admin')
GO
INSERT [par].[roles] ([idRol], [nombreRol]) VALUES (2, N'support')
GO
INSERT [par].[roles] ([idRol], [nombreRol]) VALUES (3, N'client')
GO
INSERT [par].[roles] ([idRol], [nombreRol]) VALUES (4, N'user')
GO
INSERT [par].[roles] ([idRol], [nombreRol]) VALUES (5, N'developer')
GO
SET IDENTITY_INSERT [par].[roles] OFF
GO
ALTER TABLE [par].[ciudad]  WITH CHECK ADD  CONSTRAINT [FK_ciudad_pais] FOREIGN KEY([idPais])
REFERENCES [par].[pais] ([idPais])
GO
ALTER TABLE [par].[ciudad] CHECK CONSTRAINT [FK_ciudad_pais]
GO
ALTER TABLE [usuario].[datosUsuario]  WITH CHECK ADD  CONSTRAINT [FK_datosUsuario_ciudad] FOREIGN KEY([idCiudad])
REFERENCES [par].[ciudad] ([idCiudad])
GO
ALTER TABLE [usuario].[datosUsuario] CHECK CONSTRAINT [FK_datosUsuario_ciudad]
GO
ALTER TABLE [usuario].[datosUsuario]  WITH CHECK ADD  CONSTRAINT [FK_datosUsuario_roles] FOREIGN KEY([idRol])
REFERENCES [par].[roles] ([idRol])
GO
ALTER TABLE [usuario].[datosUsuario] CHECK CONSTRAINT [FK_datosUsuario_roles]
GO
