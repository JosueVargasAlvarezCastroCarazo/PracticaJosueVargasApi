USE [master]
GO
/****** Object:  Database [materialadministration]    Script Date: 02/08/2023 6:20:02 ******/
CREATE DATABASE [materialadministration]

GO
ALTER DATABASE [materialadministration] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [materialadministration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [materialadministration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [materialadministration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [materialadministration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [materialadministration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [materialadministration] SET ARITHABORT OFF 
GO
ALTER DATABASE [materialadministration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [materialadministration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [materialadministration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [materialadministration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [materialadministration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [materialadministration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [materialadministration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [materialadministration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [materialadministration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [materialadministration] SET  ENABLE_BROKER 
GO
ALTER DATABASE [materialadministration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [materialadministration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [materialadministration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [materialadministration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [materialadministration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [materialadministration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [materialadministration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [materialadministration] SET RECOVERY FULL 
GO
ALTER DATABASE [materialadministration] SET  MULTI_USER 
GO
ALTER DATABASE [materialadministration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [materialadministration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [materialadministration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [materialadministration] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [materialadministration] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [materialadministration] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'materialadministration', N'ON'
GO
ALTER DATABASE [materialadministration] SET QUERY_STORE = ON
GO
ALTER DATABASE [materialadministration] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [materialadministration]
GO
/****** Object:  Table [dbo].[ConstructionStatus]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConstructionStatus](
	[ConstructionStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConstructionStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[MaterialId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Notes] [varchar](255) NOT NULL,
	[Amount] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
	[ConstructionStatusId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Identification] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](255) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
	[UserRolId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Construction]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Construction](
	[UserConstructionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ConstructionId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserConstructionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRol]    Script Date: 02/08/2023 6:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRol](
	[UserRolId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConstructionStatus] ON 

INSERT [dbo].[ConstructionStatus] ([ConstructionStatusId], [Code], [Name], [Description], [Active]) VALUES (1, N'01', N'En Progreso', N'Edificacion en progreso', 1)
INSERT [dbo].[ConstructionStatus] ([ConstructionStatusId], [Code], [Name], [Description], [Active]) VALUES (2, N'02', N'Finalizado', N'Proyecto finalizado', 1)
INSERT [dbo].[ConstructionStatus] ([ConstructionStatusId], [Code], [Name], [Description], [Active]) VALUES (3, N'03', N'Fase de diseño', N'Fase inicial en la cual se estudia el proyecto', 1)
SET IDENTITY_INSERT [dbo].[ConstructionStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([LocationId], [Name], [Description], [Active]) VALUES (13, N'Ferreteria Palmares', N'Frente al parque', 1)
INSERT [dbo].[Location] ([LocationId], [Name], [Description], [Active]) VALUES (14, N'En destino final', N'En la zona de construccion', 1)
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([MaterialId], [Name], [Description], [Notes], [Amount], [Active], [ProjectId], [LocationId]) VALUES (10, N'Cemento', N'Cemento cemex', N'NA', 5, 1, 7, 14)
INSERT [dbo].[Material] ([MaterialId], [Name], [Description], [Notes], [Amount], [Active], [ProjectId], [LocationId]) VALUES (11, N'Puertas', N'', N'', 1, 1, 7, 14)
SET IDENTITY_INSERT [dbo].[Material] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [Name], [Description], [Active], [ConstructionStatusId], [UserId]) VALUES (7, N'Apartamento palmares', N'Apartamento en palmares de esquipulas', 1, 3, 2)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Identification], [Email], [Name], [PhoneNumber], [Address], [Password], [Active], [UserRolId]) VALUES (2, N'207610379', N'josuevargasalvarez@gmail.com', N'Josue Vargas Alvarez', N'86672823', N'Casas de Maros Varga', N'6790d5cb3091049295f6663a1ae8aff4525d6263577266ed2508f00929b2b16b', 1, 1)
INSERT [dbo].[User] ([UserId], [Identification], [Email], [Name], [PhoneNumber], [Address], [Password], [Active], [UserRolId]) VALUES (1006, N'207610378', N'Carlos@gmail.com', N'Carlos', N'86672821', N'San ramon centro', N'6790d5cb3091049295f6663a1ae8aff4525d6263577266ed2508f00929b2b16b', 1, 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[User_Construction] ON 

INSERT [dbo].[User_Construction] ([UserConstructionId], [UserId], [ConstructionId]) VALUES (1018, 1006, 7)
SET IDENTITY_INSERT [dbo].[User_Construction] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRol] ON 

INSERT [dbo].[UserRol] ([UserRolId], [Name], [Description], [Active]) VALUES (1, N'Admin', N'Administrador', 1)
INSERT [dbo].[UserRol] ([UserRolId], [Name], [Description], [Active]) VALUES (2, N'Regular', N'Usuario Regular de sistema', 1)
SET IDENTITY_INSERT [dbo].[UserRol] OFF
GO
ALTER TABLE [dbo].[ConstructionStatus] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Location] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Material] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[UserRol] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FKMaterial642557] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FKMaterial642557]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FKMaterial67942] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FKMaterial67942]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FKProject222525] FOREIGN KEY([ConstructionStatusId])
REFERENCES [dbo].[ConstructionStatus] ([ConstructionStatusId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FKProject222525]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FKProject341042] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FKProject341042]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FKUser873388] FOREIGN KEY([UserRolId])
REFERENCES [dbo].[UserRol] ([UserRolId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FKUser873388]
GO
ALTER TABLE [dbo].[User_Construction]  WITH CHECK ADD  CONSTRAINT [FKUser_Const221166] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User_Construction] CHECK CONSTRAINT [FKUser_Const221166]
GO
ALTER TABLE [dbo].[User_Construction]  WITH CHECK ADD  CONSTRAINT [FKUser_Const831572] FOREIGN KEY([ConstructionId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[User_Construction] CHECK CONSTRAINT [FKUser_Const831572]
GO
USE [master]
GO
ALTER DATABASE [materialadministration] SET  READ_WRITE 
GO
