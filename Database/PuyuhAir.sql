USE [master]
GO
/****** Object:  Database [PuyuhAir]    Script Date: 6/17/2020 12:06:25 AM ******/
CREATE DATABASE [PuyuhAir]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PuyuhAir', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PuyuhAir.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PuyuhAir_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PuyuhAir_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PuyuhAir] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PuyuhAir].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PuyuhAir] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PuyuhAir] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PuyuhAir] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PuyuhAir] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PuyuhAir] SET ARITHABORT OFF 
GO
ALTER DATABASE [PuyuhAir] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PuyuhAir] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PuyuhAir] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PuyuhAir] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PuyuhAir] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PuyuhAir] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PuyuhAir] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PuyuhAir] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PuyuhAir] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PuyuhAir] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PuyuhAir] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PuyuhAir] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PuyuhAir] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PuyuhAir] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PuyuhAir] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PuyuhAir] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PuyuhAir] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PuyuhAir] SET RECOVERY FULL 
GO
ALTER DATABASE [PuyuhAir] SET  MULTI_USER 
GO
ALTER DATABASE [PuyuhAir] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PuyuhAir] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PuyuhAir] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PuyuhAir] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PuyuhAir] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PuyuhAir', N'ON'
GO
USE [PuyuhAir]
GO
/****** Object:  Table [dbo].[Penerbangan]    Script Date: 6/17/2020 12:06:26 AM ******/
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
ALTER DATABASE [PuyuhAir] SET  READ_WRITE 
GO
