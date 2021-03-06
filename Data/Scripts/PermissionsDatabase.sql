USE [master]
GO

CREATE DATABASE [PermissionsCatalog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PermissionsCatalog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.NANOINSTANCE\MSSQL\DATA\PermissionsCatalog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PermissionsCatalog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.NANOINSTANCE\MSSQL\DATA\PermissionsCatalog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PermissionsCatalog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PermissionsCatalog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PermissionsCatalog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET ARITHABORT OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PermissionsCatalog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PermissionsCatalog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PermissionsCatalog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PermissionsCatalog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PermissionsCatalog] SET  MULTI_USER 
GO
ALTER DATABASE [PermissionsCatalog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PermissionsCatalog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PermissionsCatalog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PermissionsCatalog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PermissionsCatalog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PermissionsCatalog] SET QUERY_STORE = OFF
GO
USE [PermissionsCatalog]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[DateOfPermission] [datetime2](7) NOT NULL,
	[TypePermissionId] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePermissions](
	[TypePermissionId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TypePermissions] PRIMARY KEY CLUSTERED 
(
	[TypePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Permissions_TypePermissionId] ON [dbo].[Permissions]
(
	[TypePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_TypePermissions_TypePermissionId] FOREIGN KEY([TypePermissionId])
REFERENCES [dbo].[TypePermissions] ([TypePermissionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_TypePermissions_TypePermissionId]
GO
USE [master]
GO
ALTER DATABASE [PermissionsCatalog] SET  READ_WRITE 
GO
