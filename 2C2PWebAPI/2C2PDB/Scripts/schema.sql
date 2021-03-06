
/****** Object:  Database [2C2PDB]    Script Date: 1/15/2019 07:54:30 PM ******/
CREATE DATABASE [2C2PDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'2C2PDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\2C2PDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'2C2PDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\2C2PDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [2C2PDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [2C2PDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [2C2PDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [2C2PDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [2C2PDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [2C2PDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [2C2PDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [2C2PDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [2C2PDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [2C2PDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [2C2PDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [2C2PDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [2C2PDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [2C2PDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [2C2PDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [2C2PDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [2C2PDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [2C2PDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [2C2PDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [2C2PDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [2C2PDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [2C2PDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [2C2PDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [2C2PDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [2C2PDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [2C2PDB] SET  MULTI_USER 
GO
ALTER DATABASE [2C2PDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [2C2PDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [2C2PDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [2C2PDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [2C2PDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [2C2PDB] SET QUERY_STORE = OFF
GO
USE [2C2PDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/15/2019 07:54:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[ContactEmail] [nvarchar](25) NOT NULL,
	[MobileNo] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 1/15/2019 07:54:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[ID] [int] NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[CustomerFK] [int] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[CurrencyCode] [nvarchar](10) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[ModifiedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer]    Script Date: 1/15/2019 07:54:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Customer] ON [dbo].[Customer]
(
	[ContactEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY([CustomerFK])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer]
GO
USE [master]
GO
ALTER DATABASE [2C2PDB] SET  READ_WRITE 
GO
