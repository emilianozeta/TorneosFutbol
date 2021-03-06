USE [master]
GO
CREATE DATABASE [TORNEOS_FUTBOL]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TORNEOS_FUTBOL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ARITHABORT OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET  MULTI_USER 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TORNEOS_FUTBOL]
GO
/****** Object:  Table [dbo].[contacto]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contacto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[email] [nvarchar](250) NOT NULL,
	[comentario] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_contacto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipo]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[montoabonado] [int] NULL,
	[torneo_id] [int] NULL,
 CONSTRAINT [PK_equipo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genero]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genero](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_genero] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jugador]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jugador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[apellido] [nvarchar](250) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[fecha_nac] [date] NOT NULL,
	[provincia_id] [int] NOT NULL,
	[localidad_id] [int] NOT NULL,
	[domicilio] [nvarchar](200) NULL,
	[genero_id] [int] NOT NULL,
	[equipo_id] [int] NOT NULL,
	[edad] [int] NOT NULL,
 CONSTRAINT [PK_jugador] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidad]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[provincia_id] [int] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_localidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_provincia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[torneo]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[torneo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NOT NULL,
	[flag_activo] [bit] NOT NULL,
	[provincia_id] [int] NOT NULL,
	[localidad_id] [int] NOT NULL,
 CONSTRAINT [PK_torneo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 28/10/2018 16:51:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[usuario] [nvarchar](20) NOT NULL,
	[contraseña] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[genero] ON 

INSERT [dbo].[genero] ([id], [descripcion]) VALUES (1, N'Femenino')
INSERT [dbo].[genero] ([id], [descripcion]) VALUES (2, N'Masculino')
SET IDENTITY_INSERT [dbo].[genero] OFF
SET IDENTITY_INSERT [dbo].[localidad] ON 

INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (1, 1, N'Morón')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (2, 1, N'Ituzaingó')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (3, 1, N'La Matanza')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (4, 2, N'Antofagasta')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (5, 2, N'San Fernando del Valle de Catamarca')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (6, 3, N'Resistencia')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (7, 4, N'Rawson')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (8, 5, N'CABA')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (9, 6, N'Córdoba')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (10, 6, N'Villa Carlos Paz')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (11, 7, N'Corrientes')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (12, 8, N'Paraná')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (13, 8, N'Gualeguaychú')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (14, 9, N'Formosa')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (15, 10, N'San Salvador de Jujuy')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (16, 10, N'Tilcara')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (19, 11, N'Santa Rosa')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (21, 12, N'La Rioja')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (22, 12, N'Sanagasta')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (23, 13, N'Mendoza')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (24, 13, N'San Rafael')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (25, 14, N'Posadas')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (26, 14, N'Iguazú')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (27, 15, N'Neuquén')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (28, 16, N'Río Negro')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (29, 16, N'Bariloche')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (30, 17, N'Salta')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (31, 18, N'San Juan')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (32, 19, N'San Luis')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (33, 19, N'Merlo')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (34, 20, N'Río Gallegos')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (35, 21, N'Rosario')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (36, 21, N'Santa Fe')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (37, 22, N'Santiago del Estero')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (38, 23, N'Ushuaia')
INSERT [dbo].[localidad] ([id], [provincia_id], [descripcion]) VALUES (39, 24, N'Tucumán')
SET IDENTITY_INSERT [dbo].[localidad] OFF
SET IDENTITY_INSERT [dbo].[provincia] ON 

INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (2, N'Catamarca')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (3, N'Chaco')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (4, N'Chubut')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (5, N'Ciudad Autónoma de Buenos Aires')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (6, N'Córdoba')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (7, N'Corrientes')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (8, N'Entre Ríos')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (9, N'Formosa')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (10, N'Jujuy')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (11, N'La Pampa')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (12, N'La Rioja')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (13, N'Mendoza')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (14, N'Misiones')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (15, N'Neuquén')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (16, N'Río Negro')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (17, N'Salta')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (18, N'San Juan')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (19, N'San Luis')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (20, N'Santa Cruz')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (21, N'Santa Fe')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (22, N'Santiago del Estero')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (23, N'Tierra del Fuego, Antártida e Islas del Atlántico Sur')
INSERT [dbo].[provincia] ([id], [descripcion]) VALUES (24, N'Tucumán')
SET IDENTITY_INSERT [dbo].[provincia] OFF
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([id], [nombre], [apellido], [usuario], [contraseña]) VALUES (1, N'Administrador', N'Administrador', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[usuario] OFF
ALTER TABLE [dbo].[torneo] ADD  CONSTRAINT [DF_torneo_flag_activo]  DEFAULT ((0)) FOR [flag_activo]
GO
ALTER TABLE [dbo].[equipo]  WITH CHECK ADD  CONSTRAINT [FK_equipo_torneo] FOREIGN KEY([torneo_id])
REFERENCES [dbo].[torneo] ([id])
GO
ALTER TABLE [dbo].[equipo] CHECK CONSTRAINT [FK_equipo_torneo]
GO
ALTER TABLE [dbo].[jugador]  WITH CHECK ADD  CONSTRAINT [FK_jugador_equipo] FOREIGN KEY([equipo_id])
REFERENCES [dbo].[equipo] ([id])
GO
ALTER TABLE [dbo].[jugador] CHECK CONSTRAINT [FK_jugador_equipo]
GO
ALTER TABLE [dbo].[jugador]  WITH CHECK ADD  CONSTRAINT [FK_jugador_genero] FOREIGN KEY([genero_id])
REFERENCES [dbo].[genero] ([id])
GO
ALTER TABLE [dbo].[jugador] CHECK CONSTRAINT [FK_jugador_genero]
GO
ALTER TABLE [dbo].[jugador]  WITH CHECK ADD  CONSTRAINT [FK_jugador_localidad] FOREIGN KEY([localidad_id])
REFERENCES [dbo].[localidad] ([id])
GO
ALTER TABLE [dbo].[jugador] CHECK CONSTRAINT [FK_jugador_localidad]
GO
ALTER TABLE [dbo].[jugador]  WITH CHECK ADD  CONSTRAINT [FK_jugador_provincia] FOREIGN KEY([provincia_id])
REFERENCES [dbo].[provincia] ([id])
GO
ALTER TABLE [dbo].[jugador] CHECK CONSTRAINT [FK_jugador_provincia]
GO
ALTER TABLE [dbo].[torneo]  WITH CHECK ADD  CONSTRAINT [FK_torneo_localidad] FOREIGN KEY([localidad_id])
REFERENCES [dbo].[localidad] ([id])
GO
ALTER TABLE [dbo].[torneo] CHECK CONSTRAINT [FK_torneo_localidad]
GO
ALTER TABLE [dbo].[torneo]  WITH CHECK ADD  CONSTRAINT [FK_torneo_provincia] FOREIGN KEY([provincia_id])
REFERENCES [dbo].[provincia] ([id])
GO
ALTER TABLE [dbo].[torneo] CHECK CONSTRAINT [FK_torneo_provincia]
GO
USE [master]
GO
ALTER DATABASE [TORNEOS_FUTBOL] SET  READ_WRITE 
GO
