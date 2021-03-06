USE [master]
GO
/****** Object:  Database [ManejoExtintores]    Script Date: 23/08/2021 11:42:03 a. m. ******/
CREATE DATABASE [ManejoExtintores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ManejoExtintores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ManejoExtintores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ManejoExtintores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ManejoExtintores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ManejoExtintores] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ManejoExtintores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ManejoExtintores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ManejoExtintores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ManejoExtintores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ManejoExtintores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ManejoExtintores] SET ARITHABORT OFF 
GO
ALTER DATABASE [ManejoExtintores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ManejoExtintores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ManejoExtintores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ManejoExtintores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ManejoExtintores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ManejoExtintores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ManejoExtintores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ManejoExtintores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ManejoExtintores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ManejoExtintores] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ManejoExtintores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ManejoExtintores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ManejoExtintores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ManejoExtintores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ManejoExtintores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ManejoExtintores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ManejoExtintores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ManejoExtintores] SET RECOVERY FULL 
GO
ALTER DATABASE [ManejoExtintores] SET  MULTI_USER 
GO
ALTER DATABASE [ManejoExtintores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ManejoExtintores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ManejoExtintores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ManejoExtintores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ManejoExtintores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ManejoExtintores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ManejoExtintores] SET QUERY_STORE = OFF
GO
USE [ManejoExtintores]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Google] [varchar](500) NULL,
	[Discriminador] [varchar](500) NULL,
	[JoinDate] [datetime2](7) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[DocCliente] [decimal](18, 0) NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Descripcion] [varchar](500) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](30) NULL,
	[Email] [varchar](100) NULL,
	[Nit] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreditoServicios]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditoServicios](
	[IdCreditos] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NULL,
	[Abono] [decimal](18, 4) NULL,
	[Deuda] [decimal](18, 4) NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK_CreditoServicios] PRIMARY KEY CLUSTERED 
(
	[IdCreditos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleExtintorClientes]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleExtintorClientes](
	[IdDetalleCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdClientes] [int] NULL,
	[TipoExtintor] [varchar](100) NULL,
	[Pesoextintor] [varchar](50) NULL,
	[Cantidad] [int] NULL,
	[FechaVencimiento] [datetime] NULL,
	[FechaMantenimiento] [datetime] NULL,
 CONSTRAINT [PK_DetalleExtClientes] PRIMARY KEY CLUSTERED 
(
	[IdDetalleCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleServicioDetalleClientes]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleServicioDetalleClientes](
	[IdDetalle_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[IdDetalleServicios] [int] NULL,
	[IdDetalleExtintorCliente] [int] NULL,
 CONSTRAINT [PK_DetalleServicioDetalleClentes] PRIMARY KEY CLUSTERED 
(
	[IdDetalle_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleServicios]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleServicios](
	[IdDetalleServ] [int] IDENTITY(1,1) NOT NULL,
	[IdServicios] [int] NULL,
	[Descripcion] [varchar](500) NULL,
	[IdTipoExtintor] [int] NULL,
	[IdPesoExtintor] [int] NULL,
	[Valor] [decimal](18, 4) NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](18, 4) NULL,
 CONSTRAINT [PK_DetalleServicios] PRIMARY KEY CLUSTERED 
(
	[IdDetalleServ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleados] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpresa] [int] NULL,
	[Nombre] [varchar](100) NULL,
	[Apellido] [varchar](100) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[IdEmpleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresas]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresas](
	[IdEmpresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[Email] [varchar](150) NULL,
	[Nit] [varchar](50) NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gastos]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gastos](
	[IdGastos] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NULL,
	[Fecha] [datetime] NULL,
	[Cantidad] [int] NULL,
	[Total] [decimal](18, 4) NULL,
 CONSTRAINT [PK_Gastos] PRIMARY KEY CLUSTERED 
(
	[IdGastos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdProductos] [int] NULL,
	[Fecha] [datetime] NULL,
	[Descripcion] [varchar](500) NULL,
	[IdTipoExtintor] [int] NULL,
	[IdPesoExtintor] [int] NULL,
	[Cantidad] [int] NULL,
	[FechaVencimiento] [datetime] NULL,
	[DetalleServId] [int] NULL,
 CONSTRAINT [PK_Inventarios] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PesoExtintors]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PesoExtintors](
	[IdPesoExtintor] [int] IDENTITY(1,1) NOT NULL,
	[PesoXlibras] [int] NULL,
 CONSTRAINT [PK_PesoExtintors] PRIMARY KEY CLUSTERED 
(
	[IdPesoExtintor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Precios]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Precios](
	[IdPrecios] [int] IDENTITY(1,1) NOT NULL,
	[IdProductos] [int] NULL,
	[IdDetalleServ] [int] NULL,
	[Descripcion] [varchar](500) NULL,
	[Valor] [decimal](18, 4) NULL,
	[Iva] [decimal](18, 4) NULL,
 CONSTRAINT [PK_Precios] PRIMARY KEY CLUSTERED 
(
	[IdPrecios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProductos] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoExtintor] [int] NULL,
	[IdPesoExtintor] [int] NULL,
	[TipoProducto] [varchar](200) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProductos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[IdServicios] [int] IDENTITY(1,1) NOT NULL,
	[IdClientes] [int] NULL,
	[IdEmpleados] [int] NULL,
	[FechaServicio] [datetime] NULL,
	[Valor] [decimal](18, 4) NULL,
	[Estado] [varchar](50) NULL,
	[FechaMantenimiento] [datetime] NULL,
	[FechaVencimiento] [datetime] NULL,
	[Abono] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[IdServicios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoExtintors]    Script Date: 23/08/2021 11:42:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoExtintors](
	[IdTipoExtintor] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Extintor] [varchar](100) NULL,
 CONSTRAINT [PK_TipoExtintors] PRIMARY KEY CLUSTERED 
(
	[IdTipoExtintor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'79D83B40-44F2-4C6B-8E9A-206127C25AC1', N'ADMIN', N'ADMIN', N'2021--06-09')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'beaac2ab-91d4-4af0-b629-1273355c0b87', N'79D83B40-44F2-4C6B-8E9A-206127C25AC1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c8d16dd3-8f41-43f1-ace1-3941de81c69d', N'79D83B40-44F2-4C6B-8E9A-206127C25AC1')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Nombres], [Apellidos], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Google], [Discriminador], [JoinDate]) VALUES (N'4e8a42f3-9ef9-466b-a10a-9ef6080e20be', N'Esteban', N'Alvarez', N'juanes', N'JUANES', N'juanes.x777@gmail.com', N'JUANES.X777@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAED+f4QPEMqEzI4RBHOK4BA/UMgpTeFPXCoTM/wkvCwQ8EfUE8IzBey/rzYTHXUGjMQ==', N'VRNJOEVZ4X7PHKYJ4F6BWGNH4VR2NQTK', N'49289124-541f-4d7f-8d1a-f74bddd506a3', NULL, 0, 0, NULL, 1, 0, NULL, N'Usuario', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [Nombres], [Apellidos], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Google], [Discriminador], [JoinDate]) VALUES (N'beaac2ab-91d4-4af0-b629-1273355c0b87', N'Diego', N'Alvarez', N'Diego', N'DIEGO', N'DA@gmail.com', N'DA@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEModMq5I9VhOz1oEenVbcHb4/XLOXf15iPHYdH04+hy4xpVmxEE86fRQdqx+WrcNAg==', N'G3YSDI6ZJ7NZAKWTDNNBZKIYBE73RYRH', N'a1f5d6c9-fddf-4129-b074-ab735264b630', NULL, 0, 0, NULL, 1, 0, NULL, N'Usuario', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [Nombres], [Apellidos], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Google], [Discriminador], [JoinDate]) VALUES (N'c8d16dd3-8f41-43f1-ace1-3941de81c69d', N'juan', N'Rodrigues', N'juane4', N'JUANE4', N'juan@gogle.com', N'JUAN@GOGLE.COM', 0, N'AQAAAAEAACcQAAAAEJHX5Kao85+358mI04AlK4m1u257osfa+0SP+b7/WCV1u6MYiuJDMNplB2sBMU8pvg==', N'2ZLZDQSS76WRC5QWUY43LABQHSFNZUJT', N'e68bbc27-c072-4331-9608-5fc5b7cd89af', NULL, 0, 0, NULL, 1, 0, NULL, N'Usuario', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [DocCliente], [Nombre], [Apellido], [Descripcion], [Direccion], [Telefono], [Email], [Nit]) VALUES (1002, CAST(1038945233 AS Decimal(18, 0)), N'Pancracio', N'Mahorés', N'Propietario vehículo particular', N'parque pueblo nuevo', N'3509875643', N'PM@gmail.com', N'null')
INSERT [dbo].[Clientes] ([IdCliente], [DocCliente], [Nombre], [Apellido], [Descripcion], [Direccion], [Telefono], [Email], [Nit]) VALUES (1005, NULL, N'AGrosanar', N'null', N'Local de productos agricolas', N'calle bolivar', N'3456789', N'sanar@hotmail.com', N'32 3456 789-1')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[CreditoServicios] ON 

INSERT [dbo].[CreditoServicios] ([IdCreditos], [IdServicio], [Abono], [Deuda], [Fecha]) VALUES (2, 23, CAST(10000.0000 AS Decimal(18, 4)), CAST(10000.0000 AS Decimal(18, 4)), CAST(N'2021-06-20T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditoServicios] ([IdCreditos], [IdServicio], [Abono], [Deuda], [Fecha]) VALUES (3, 23, CAST(5000.0000 AS Decimal(18, 4)), CAST(5000.0000 AS Decimal(18, 4)), CAST(N'2021-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditoServicios] ([IdCreditos], [IdServicio], [Abono], [Deuda], [Fecha]) VALUES (4, 26, CAST(80000.0000 AS Decimal(18, 4)), CAST(100000.0000 AS Decimal(18, 4)), CAST(N'2021-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditoServicios] ([IdCreditos], [IdServicio], [Abono], [Deuda], [Fecha]) VALUES (5, 23, CAST(5000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), CAST(N'2021-07-05T00:00:00.000' AS DateTime))
INSERT [dbo].[CreditoServicios] ([IdCreditos], [IdServicio], [Abono], [Deuda], [Fecha]) VALUES (6, 26, CAST(50000.0000 AS Decimal(18, 4)), CAST(50000.0000 AS Decimal(18, 4)), CAST(N'2021-07-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[CreditoServicios] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleServicios] ON 

INSERT [dbo].[DetalleServicios] ([IdDetalleServ], [IdServicios], [Descripcion], [IdTipoExtintor], [IdPesoExtintor], [Valor], [Cantidad], [Total]) VALUES (10, 23, N'Recarga extintor.', 1, 1, CAST(20000.0000 AS Decimal(18, 4)), 1, CAST(20000.0000 AS Decimal(18, 4)))
INSERT [dbo].[DetalleServicios] ([IdDetalleServ], [IdServicios], [Descripcion], [IdTipoExtintor], [IdPesoExtintor], [Valor], [Cantidad], [Total]) VALUES (11, 24, N'Recarga extintor.', 2, 2, CAST(22000.0000 AS Decimal(18, 4)), 1, CAST(22000.0000 AS Decimal(18, 4)))
INSERT [dbo].[DetalleServicios] ([IdDetalleServ], [IdServicios], [Descripcion], [IdTipoExtintor], [IdPesoExtintor], [Valor], [Cantidad], [Total]) VALUES (12, 25, N'Recarga extintor.', 3, 3, CAST(30000.0000 AS Decimal(18, 4)), 1, CAST(30000.0000 AS Decimal(18, 4)))
INSERT [dbo].[DetalleServicios] ([IdDetalleServ], [IdServicios], [Descripcion], [IdTipoExtintor], [IdPesoExtintor], [Valor], [Cantidad], [Total]) VALUES (13, 26, N'Recarga extintores 20 libras.', 2, 3, CAST(180000.0000 AS Decimal(18, 4)), 6, CAST(180000.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[DetalleServicios] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([IdEmpleados], [IdEmpresa], [Nombre], [Apellido], [Direccion], [Telefono], [Email]) VALUES (1, 1, N'Carla', N'Rodriguez', N'Cl 20 #21-31 ', N'3165960032', N'CR@gmail.com')
INSERT [dbo].[Empleados] ([IdEmpleados], [IdEmpresa], [Nombre], [Apellido], [Direccion], [Telefono], [Email]) VALUES (2, 1, N'Diego', N'Palacios', N'Cl 34 #21-34', N'2193456789', N'DP@gmail.com')
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Empresas] ON 

INSERT [dbo].[Empresas] ([IdEmpresa], [Nombre], [Direccion], [Telefono], [Email], [Nit]) VALUES (1, N'Estacion de bomberos de Amalfi', N'El zacatín', N'3209876534', N'EstacionBomberos@gmail.com', N'70 3456 34-90')
INSERT [dbo].[Empresas] ([IdEmpresa], [Nombre], [Direccion], [Telefono], [Email], [Nit]) VALUES (2, N'Los recuerdos de ella', N'Zona roza', N'3216789000', N'Rela@hotmail.com', N'80 4567 890-0')
SET IDENTITY_INSERT [dbo].[Empresas] OFF
GO
SET IDENTITY_INSERT [dbo].[Gastos] ON 

INSERT [dbo].[Gastos] ([IdGastos], [Descripcion], [Fecha], [Cantidad], [Total]) VALUES (1, N'Tanqueo de Camioneta', CAST(N'2021-06-08T00:00:00.000' AS DateTime), 1, CAST(100000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Gastos] ([IdGastos], [Descripcion], [Fecha], [Cantidad], [Total]) VALUES (2, N'Carreras de motocarro', CAST(N'2021-06-08T00:00:00.000' AS DateTime), 5, CAST(20000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Gastos] ([IdGastos], [Descripcion], [Fecha], [Cantidad], [Total]) VALUES (3, N'Compra de Extintores', CAST(N'2021-06-14T00:00:00.000' AS DateTime), 10, CAST(200000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Gastos] ([IdGastos], [Descripcion], [Fecha], [Cantidad], [Total]) VALUES (4, N'Viáticos a  Guadalupe', CAST(N'2021-06-14T00:00:00.000' AS DateTime), 1, CAST(200000.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Gastos] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventarios] ON 

INSERT [dbo].[Inventarios] ([IdInventario], [IdProductos], [Fecha], [Descripcion], [IdTipoExtintor], [IdPesoExtintor], [Cantidad], [FechaVencimiento], [DetalleServId]) VALUES (2, 1, CAST(N'2021-06-19T00:00:00.000' AS DateTime), N'Extintores disponibles.', 1, 1, 10, CAST(N'2022-06-19T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Inventarios] OFF
GO
SET IDENTITY_INSERT [dbo].[PesoExtintors] ON 

INSERT [dbo].[PesoExtintors] ([IdPesoExtintor], [PesoXlibras]) VALUES (1, 5)
INSERT [dbo].[PesoExtintors] ([IdPesoExtintor], [PesoXlibras]) VALUES (2, 10)
INSERT [dbo].[PesoExtintors] ([IdPesoExtintor], [PesoXlibras]) VALUES (3, 20)
SET IDENTITY_INSERT [dbo].[PesoExtintors] OFF
GO
SET IDENTITY_INSERT [dbo].[Precios] ON 

INSERT [dbo].[Precios] ([IdPrecios], [IdProductos], [IdDetalleServ], [Descripcion], [Valor], [Iva]) VALUES (1, 1, NULL, N'Extintores de cinco libras abc', CAST(15000.0000 AS Decimal(18, 4)), CAST(17000.0000 AS Decimal(18, 4)))
INSERT [dbo].[Precios] ([IdPrecios], [IdProductos], [IdDetalleServ], [Descripcion], [Valor], [Iva]) VALUES (2, 2, NULL, N'Precio Extintores 10 libras', CAST(22000.0000 AS Decimal(18, 4)), CAST(24000.0000 AS Decimal(18, 4)))
SET IDENTITY_INSERT [dbo].[Precios] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (1, 1, 1, N'ABC')
INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (2, 1, 2, N'ABC')
INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (3, 1, 3, N'ABC')
INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (4, 2, 1, N'Solkaflán')
INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (5, 2, 3, N'Solkaflán')
INSERT [dbo].[Productos] ([IdProductos], [IdTipoExtintor], [IdPesoExtintor], [TipoProducto]) VALUES (6, 2, 3, N'Solkaflán')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicios] ON 

INSERT [dbo].[Servicios] ([IdServicios], [IdClientes], [IdEmpleados], [FechaServicio], [Valor], [Estado], [FechaMantenimiento], [FechaVencimiento], [Abono]) VALUES (23, 1002, 1, CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(20000.0000 AS Decimal(18, 4)), N'Pendiente', NULL, NULL, NULL)
INSERT [dbo].[Servicios] ([IdServicios], [IdClientes], [IdEmpleados], [FechaServicio], [Valor], [Estado], [FechaMantenimiento], [FechaVencimiento], [Abono]) VALUES (24, 1005, 2, CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(22000.0000 AS Decimal(18, 4)), N'Cancelado', NULL, NULL, NULL)
INSERT [dbo].[Servicios] ([IdServicios], [IdClientes], [IdEmpleados], [FechaServicio], [Valor], [Estado], [FechaMantenimiento], [FechaVencimiento], [Abono]) VALUES (25, 1005, 2, CAST(N'2021-06-19T00:00:00.000' AS DateTime), CAST(30000.0000 AS Decimal(18, 4)), N'Pendiente', NULL, NULL, NULL)
INSERT [dbo].[Servicios] ([IdServicios], [IdClientes], [IdEmpleados], [FechaServicio], [Valor], [Estado], [FechaMantenimiento], [FechaVencimiento], [Abono]) VALUES (26, 1005, 1, CAST(N'2021-07-05T00:00:00.000' AS DateTime), CAST(180000.0000 AS Decimal(18, 4)), N'Pendiente', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Servicios] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoExtintors] ON 

INSERT [dbo].[TipoExtintors] ([IdTipoExtintor], [Tipo_Extintor]) VALUES (1, N'ABC')
INSERT [dbo].[TipoExtintors] ([IdTipoExtintor], [Tipo_Extintor]) VALUES (2, N'Solkaflán')
INSERT [dbo].[TipoExtintors] ([IdTipoExtintor], [Tipo_Extintor]) VALUES (3, N'Satelital')
SET IDENTITY_INSERT [dbo].[TipoExtintors] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inventarios_DetalleServId]    Script Date: 23/08/2021 11:42:05 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_Inventarios_DetalleServId] ON [dbo].[Inventarios]
(
	[DetalleServId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CreditoServicios]  WITH CHECK ADD  CONSTRAINT [fk_Creditos] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicios] ([IdServicios])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditoServicios] CHECK CONSTRAINT [fk_Creditos]
GO
ALTER TABLE [dbo].[DetalleExtintorClientes]  WITH CHECK ADD  CONSTRAINT [FK_DetalleExtClientes_Clientes] FOREIGN KEY([IdClientes])
REFERENCES [dbo].[Clientes] ([IdCliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleExtintorClientes] CHECK CONSTRAINT [FK_DetalleExtClientes_Clientes]
GO
ALTER TABLE [dbo].[DetalleServicioDetalleClientes]  WITH CHECK ADD  CONSTRAINT [FK_DetalleServicioDetalleClientes_DetalleExtintorClientes] FOREIGN KEY([IdDetalleExtintorCliente])
REFERENCES [dbo].[DetalleExtintorClientes] ([IdDetalleCliente])
GO
ALTER TABLE [dbo].[DetalleServicioDetalleClientes] CHECK CONSTRAINT [FK_DetalleServicioDetalleClientes_DetalleExtintorClientes]
GO
ALTER TABLE [dbo].[DetalleServicioDetalleClientes]  WITH CHECK ADD  CONSTRAINT [FK_DetalleServicioDetalleClientes_DetalleServicios] FOREIGN KEY([IdDetalleServicios])
REFERENCES [dbo].[DetalleServicios] ([IdDetalleServ])
GO
ALTER TABLE [dbo].[DetalleServicioDetalleClientes] CHECK CONSTRAINT [FK_DetalleServicioDetalleClientes_DetalleServicios]
GO
ALTER TABLE [dbo].[DetalleServicios]  WITH CHECK ADD  CONSTRAINT [FK_DetalleServicios_PesoExtintors] FOREIGN KEY([IdPesoExtintor])
REFERENCES [dbo].[PesoExtintors] ([IdPesoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DetalleServicios] CHECK CONSTRAINT [FK_DetalleServicios_PesoExtintors]
GO
ALTER TABLE [dbo].[DetalleServicios]  WITH CHECK ADD  CONSTRAINT [FK_DetalleServicios_Servicio] FOREIGN KEY([IdServicios])
REFERENCES [dbo].[Servicios] ([IdServicios])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleServicios] CHECK CONSTRAINT [FK_DetalleServicios_Servicio]
GO
ALTER TABLE [dbo].[DetalleServicios]  WITH CHECK ADD  CONSTRAINT [FK_DetalleServicios_TipoExtintors] FOREIGN KEY([IdTipoExtintor])
REFERENCES [dbo].[TipoExtintors] ([IdTipoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DetalleServicios] CHECK CONSTRAINT [FK_DetalleServicios_TipoExtintors]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [fk_Empleado] FOREIGN KEY([IdEmpresa])
REFERENCES [dbo].[Empresas] ([IdEmpresa])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [fk_Empleado]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [fk_Inventario] FOREIGN KEY([IdProductos])
REFERENCES [dbo].[Productos] ([IdProductos])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [fk_Inventario]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_DetalleServicios] FOREIGN KEY([DetalleServId])
REFERENCES [dbo].[DetalleServicios] ([IdDetalleServ])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_DetalleServicios]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_PesoExtintors] FOREIGN KEY([IdPesoExtintor])
REFERENCES [dbo].[PesoExtintors] ([IdPesoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_PesoExtintors]
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD  CONSTRAINT [FK_Inventarios_TipoExtintors] FOREIGN KEY([IdTipoExtintor])
REFERENCES [dbo].[TipoExtintors] ([IdTipoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Inventarios] CHECK CONSTRAINT [FK_Inventarios_TipoExtintors]
GO
ALTER TABLE [dbo].[Precios]  WITH CHECK ADD  CONSTRAINT [fk_Precios] FOREIGN KEY([IdProductos])
REFERENCES [dbo].[Productos] ([IdProductos])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Precios] CHECK CONSTRAINT [fk_Precios]
GO
ALTER TABLE [dbo].[Precios]  WITH CHECK ADD  CONSTRAINT [fk_Productos_DetalleS] FOREIGN KEY([IdDetalleServ])
REFERENCES [dbo].[DetalleServicios] ([IdDetalleServ])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Precios] CHECK CONSTRAINT [fk_Productos_DetalleS]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [Fk_Productos_Peso] FOREIGN KEY([IdPesoExtintor])
REFERENCES [dbo].[PesoExtintors] ([IdPesoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [Fk_Productos_Peso]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [fk_Productos_Tipo] FOREIGN KEY([IdTipoExtintor])
REFERENCES [dbo].[TipoExtintors] ([IdTipoExtintor])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [fk_Productos_Tipo]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [fk_serviciosC] FOREIGN KEY([IdClientes])
REFERENCES [dbo].[Clientes] ([IdCliente])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [fk_serviciosC]
GO
ALTER TABLE [dbo].[Servicios]  WITH CHECK ADD  CONSTRAINT [fk_serviciosE] FOREIGN KEY([IdEmpleados])
REFERENCES [dbo].[Empleados] ([IdEmpleados])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Servicios] CHECK CONSTRAINT [fk_serviciosE]
GO
USE [master]
GO
ALTER DATABASE [ManejoExtintores] SET  READ_WRITE 
GO
