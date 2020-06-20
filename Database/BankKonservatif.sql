create database BankKonservatif
USE [BankKonservatif]
GO
/****** Object:  Table [dbo].[nasabah]    Script Date: 07/06/2020 13:14:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nasabah](
	[no_rekening] [varchar](50) NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[alamat] [varchar](50) NULL,
	[no_ktp] [varchar](50) NULL,
	[password] [varchar](50) NOT NULL,
	[saldo] [float] NULL,
 CONSTRAINT [PK_nasabah] PRIMARY KEY CLUSTERED 
(
	[no_rekening] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pembayaran]    Script Date: 07/06/2020 13:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pembayaran](
	[invoice_number] [char](10) NOT NULL,
	[waktu_pemesanan] [datetime] NOT NULL,
	[waktu_pembayaran] [datetime] NULL,
	[nominal] [float] NOT NULL,
	[status_bayar] [int] NOT NULL,
	[norek_bayar] [varchar](50) NULL,
 CONSTRAINT [PK_Pembayaran] PRIMARY KEY CLUSTERED 
(
	[invoice_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Pembayaran]  WITH NOCHECK ADD  CONSTRAINT [FK_Pembayaran_nasabah] FOREIGN KEY([norek_bayar])
REFERENCES [dbo].[nasabah] ([no_rekening])
GO
ALTER TABLE [dbo].[Pembayaran] CHECK CONSTRAINT [FK_Pembayaran_nasabah]
GO
