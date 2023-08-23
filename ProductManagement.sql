USE [master]
GO
/****** Object:  Database [ProjectManagement]    Script Date: 8/17/2023 3:25:46 AM ******/
CREATE DATABASE [ProjectManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProjectManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ProjectManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProjectManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjectManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProjectManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProjectManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](225) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](255) NOT NULL,
	[Topic] [nvarchar](100) NOT NULL,
	[Description] [text] NULL,
	[FinishDate] [date] NULL,
	[isFinished] [bit] NULL,
	[Grade] [tinyint] NULL,
	[TeamId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[MSSV] [varchar](10) NOT NULL,
	[StudentName] [nvarchar](255) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[CMND] [varchar](12) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[AccountId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentTeam]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTeam](
	[TeamId] [int] NOT NULL,
	[MSSV] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[MSSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 8/17/2023 3:25:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](225) NOT NULL,
	[NumberOfMember] [tinyint] NULL,
	[Leader] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 
GO
INSERT [dbo].[Account] ([AccountId], [Email], [Password], [RoleId]) VALUES (1, N'abcxyz@gmail.com', N'123456', 2)
GO
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [Topic], [Description], [FinishDate], [isFinished], [Grade], [TeamId]) VALUES (1, N'ProjectOne', N'ProjectManager', N'ProjectManager', CAST(N'2023-08-08' AS Date), 0, 0, 2)
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [Topic], [Description], [FinishDate], [isFinished], [Grade], [TeamId]) VALUES (2, N'ProjectTwo', N'OnlineShop', N'OnlineShop', CAST(N'2023-08-08' AS Date), 0, 0, 1002)
GO
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (1, N'Teacher')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (2, N'Student')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Student] ([MSSV], [StudentName], [BirthDate], [CMND], [Address], [PhoneNumber], [AccountId]) VALUES (N'HE180000', N'StudentOne', CAST(N'2002-02-02' AS Date), N'12345678910', N'HaNoi', N'0123456789', 1)
GO
INSERT [dbo].[Student] ([MSSV], [StudentName], [BirthDate], [CMND], [Address], [PhoneNumber], [AccountId]) VALUES (N'HE180001', N'StudentTwo', CAST(N'2002-02-02' AS Date), N'12345678910', N'HaNoi', N'0123456789', NULL)
GO
INSERT [dbo].[Student] ([MSSV], [StudentName], [BirthDate], [CMND], [Address], [PhoneNumber], [AccountId]) VALUES (N'HE180002', N'StudentThree', CAST(N'2002-02-02' AS Date), N'12345678910', NULL, NULL, NULL)
GO
INSERT [dbo].[Student] ([MSSV], [StudentName], [BirthDate], [CMND], [Address], [PhoneNumber], [AccountId]) VALUES (N'HE180003', N'StudentFour', CAST(N'2002-02-02' AS Date), N'12345678910', NULL, NULL, NULL)
GO
INSERT [dbo].[StudentTeam] ([TeamId], [MSSV]) VALUES (2, N'HE180000')
GO
INSERT [dbo].[StudentTeam] ([TeamId], [MSSV]) VALUES (2, N'HE180001')
GO
INSERT [dbo].[StudentTeam] ([TeamId], [MSSV]) VALUES (1002, N'HE180002')
GO
INSERT [dbo].[StudentTeam] ([TeamId], [MSSV]) VALUES (1002, N'HE180003')
GO
SET IDENTITY_INSERT [dbo].[Team] ON 
GO
INSERT [dbo].[Team] ([TeamId], [TeamName], [NumberOfMember], [Leader]) VALUES (2, N'TeamOne', 2, N'HE180000')
GO
INSERT [dbo].[Team] ([TeamId], [TeamName], [NumberOfMember], [Leader]) VALUES (1002, N'TeamTwo', 2, N'HE180002')
GO
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Account__A9D105342AEADFE7]    Script Date: 8/17/2023 3:25:47 AM ******/
ALTER TABLE [dbo].[Account] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT ((0)) FOR [isFinished]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[StudentTeam]  WITH CHECK ADD FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[StudentTeam]  WITH CHECK ADD FOREIGN KEY([MSSV])
REFERENCES [dbo].[Student] ([MSSV])
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD FOREIGN KEY([Leader])
REFERENCES [dbo].[Student] ([MSSV])
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD CHECK  (([NumberOfMember]<(5)))
GO
USE [master]
GO
ALTER DATABASE [ProjectManagement] SET  READ_WRITE 
GO
