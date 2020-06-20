USE [master]
GO
/****** Object:  Database [PinguinAir]    Script Date: 6/17/2020 12:05:49 AM ******/
CREATE DATABASE [PinguinAir]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PinguinAir', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PinguinAir.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PinguinAir_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PinguinAir_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PinguinAir] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PinguinAir].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PinguinAir] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PinguinAir] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PinguinAir] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PinguinAir] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PinguinAir] SET ARITHABORT OFF 
GO
ALTER DATABASE [PinguinAir] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PinguinAir] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PinguinAir] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PinguinAir] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PinguinAir] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PinguinAir] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PinguinAir] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PinguinAir] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PinguinAir] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PinguinAir] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PinguinAir] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PinguinAir] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PinguinAir] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PinguinAir] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PinguinAir] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PinguinAir] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PinguinAir] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PinguinAir] SET RECOVERY FULL 
GO
ALTER DATABASE [PinguinAir] SET  MULTI_USER 
GO
ALTER DATABASE [PinguinAir] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PinguinAir] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PinguinAir] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PinguinAir] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PinguinAir] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PinguinAir', N'ON'
GO
USE [PinguinAir]
GO
/****** Object:  Table [dbo].[Penerbangan]    Script Date: 6/17/2020 12:05:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Penerbangan](
	[PenerbanganID] [int] NOT NULL,
	[Pesawat] [varchar](10) NULL,
	[JlhKursi] [int] NULL,
	[Harga] [int] NULL,
	[Asal] [varchar](25) NULL,
	[Tujuan] [varchar](25) NULL,
	[Terbang] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PenerbanganID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [PinguinAir] SET  READ_WRITE 
GO
