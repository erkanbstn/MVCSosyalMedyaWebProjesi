USE [master]
GO
/****** Object:  Database [Firma]    Script Date: 18.10.2021 11:48:25 ******/
CREATE DATABASE [Firma]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Firma', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Firma.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Firma_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Firma_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Firma].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Firma] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Firma] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Firma] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Firma] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Firma] SET ARITHABORT OFF 
GO
ALTER DATABASE [Firma] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Firma] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Firma] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Firma] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Firma] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Firma] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Firma] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Firma] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Firma] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Firma] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Firma] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Firma] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Firma] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Firma] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Firma] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Firma] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Firma] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Firma] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Firma] SET  MULTI_USER 
GO
ALTER DATABASE [Firma] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Firma] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Firma] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Firma] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Firma] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Firma]
GO
/****** Object:  UserDefinedDataType [dbo].[barkod_str]    Script Date: 18.10.2021 11:48:25 ******/
CREATE TYPE [dbo].[barkod_str] FROM [nvarchar](50) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[belgeno_str]    Script Date: 18.10.2021 11:48:25 ******/
CREATE TYPE [dbo].[belgeno_str] FROM [nvarchar](50) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[evrakseri_str]    Script Date: 18.10.2021 11:48:25 ******/
CREATE TYPE [dbo].[evrakseri_str] FROM [nvarchar](20) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_maxhesapisimno]    Script Date: 18.10.2021 11:48:25 ******/
CREATE TYPE [dbo].[nvarchar_maxhesapisimno] FROM [nvarchar](90) NULL
GO
/****** Object:  Table [dbo].[Calisanlar]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calisanlar](
	[CalisanNo] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Soyadi] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CalisanNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firmalar]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firmalar](
	[FirmaID] [int] IDENTITY(1,1) NOT NULL,
	[FirmaAd] [varchar](150) NULL,
 CONSTRAINT [PK_Firmalar] PRIMARY KEY CLUSTERED 
(
	[FirmaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAd] [varchar](50) NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriNo] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [varchar](50) NOT NULL,
	[Soyadi] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MusteriNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SatisDetaylar]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatisDetaylar](
	[SatisDetayNo] [int] NOT NULL,
	[Urun] [int] NOT NULL,
	[SatisFiyat] [smallmoney] NULL,
	[Adet] [int] NOT NULL,
 CONSTRAINT [PK_SatisUrunNo] PRIMARY KEY CLUSTERED 
(
	[SatisDetayNo] ASC,
	[Urun] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satislar]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satislar](
	[SatisNo] [int] IDENTITY(1,1) NOT NULL,
	[Musteri] [int] NOT NULL,
	[Calisan] [int] NOT NULL,
	[SatisTarih] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SatisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 18.10.2021 11:48:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunNo] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [varchar](50) NOT NULL,
	[BirimFiyat] [smallmoney] NULL,
	[StokMiktari] [int] NULL,
	[Kategori] [int] NULL,
	[Firma] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UrunNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Calisanlar] ON 

INSERT [dbo].[Calisanlar] ([CalisanNo], [Adi], [Soyadi]) VALUES (1, N'Firdevs', N'SACAN')
INSERT [dbo].[Calisanlar] ([CalisanNo], [Adi], [Soyadi]) VALUES (2, N'Nimet', N'BÜKCÜ')
INSERT [dbo].[Calisanlar] ([CalisanNo], [Adi], [Soyadi]) VALUES (3, N'Sıla', N'YILDIZ')
SET IDENTITY_INSERT [dbo].[Calisanlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Firmalar] ON 

INSERT [dbo].[Firmalar] ([FirmaID], [FirmaAd]) VALUES (1, N'Arena')
INSERT [dbo].[Firmalar] ([FirmaID], [FirmaAd]) VALUES (2, N'Genpa')
SET IDENTITY_INSERT [dbo].[Firmalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategoriler] ON 

INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd]) VALUES (1, N'RAM')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd]) VALUES (2, N'Ekran Kartı')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd]) VALUES (3, N'Kasa')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd]) VALUES (4, N'İşlemci')
INSERT [dbo].[Kategoriler] ([KategoriID], [KategoriAd]) VALUES (5, N'WebCam')
SET IDENTITY_INSERT [dbo].[Kategoriler] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([MusteriNo], [Adi], [Soyadi]) VALUES (1, N'Emir', N'YALÇIN')
INSERT [dbo].[Musteriler] ([MusteriNo], [Adi], [Soyadi]) VALUES (2, N'Erkan', N'BOSTAN')
INSERT [dbo].[Musteriler] ([MusteriNo], [Adi], [Soyadi]) VALUES (3, N'Emre', N'AYGÜN')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
GO
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (1, 1, 4000.0000, 1)
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (1, 2, 350.0000, 1)
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (1, 3, 90.0000, 1)
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (2, 2, 350.0000, 1)
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (2, 3, 98.0000, 3)
INSERT [dbo].[SatisDetaylar] ([SatisDetayNo], [Urun], [SatisFiyat], [Adet]) VALUES (3, 1, 4000.0000, 1)
GO
SET IDENTITY_INSERT [dbo].[Satislar] ON 

INSERT [dbo].[Satislar] ([SatisNo], [Musteri], [Calisan], [SatisTarih]) VALUES (1, 1, 1, CAST(N'2021-10-11T18:20:00' AS SmallDateTime))
INSERT [dbo].[Satislar] ([SatisNo], [Musteri], [Calisan], [SatisTarih]) VALUES (2, 2, 2, CAST(N'2021-10-11T18:22:00' AS SmallDateTime))
INSERT [dbo].[Satislar] ([SatisNo], [Musteri], [Calisan], [SatisTarih]) VALUES (3, 3, 3, CAST(N'2021-10-11T18:22:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Satislar] OFF
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [BirimFiyat], [StokMiktari], [Kategori], [Firma]) VALUES (1, N'Laptop', 4000.0000, 5, 1, 1)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [BirimFiyat], [StokMiktari], [Kategori], [Firma]) VALUES (2, N'L.Çantası', 350.0000, 25, 2, 1)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [BirimFiyat], [StokMiktari], [Kategori], [Firma]) VALUES (3, N'Mouse', 90.0000, 5, 3, 2)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
GO
ALTER TABLE [dbo].[Satislar] ADD  DEFAULT (getdate()) FOR [SatisTarih]
GO
ALTER TABLE [dbo].[SatisDetaylar]  WITH CHECK ADD  CONSTRAINT [FK_SatisNo] FOREIGN KEY([SatisDetayNo])
REFERENCES [dbo].[Satislar] ([SatisNo])
GO
ALTER TABLE [dbo].[SatisDetaylar] CHECK CONSTRAINT [FK_SatisNo]
GO
ALTER TABLE [dbo].[SatisDetaylar]  WITH CHECK ADD  CONSTRAINT [FK_Urun] FOREIGN KEY([Urun])
REFERENCES [dbo].[Urunler] ([UrunNo])
GO
ALTER TABLE [dbo].[SatisDetaylar] CHECK CONSTRAINT [FK_Urun]
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Calisan] FOREIGN KEY([Calisan])
REFERENCES [dbo].[Calisanlar] ([CalisanNo])
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Calisan]
GO
ALTER TABLE [dbo].[Satislar]  WITH CHECK ADD  CONSTRAINT [FK_Musteri] FOREIGN KEY([Musteri])
REFERENCES [dbo].[Musteriler] ([MusteriNo])
GO
ALTER TABLE [dbo].[Satislar] CHECK CONSTRAINT [FK_Musteri]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Firmalar] FOREIGN KEY([Firma])
REFERENCES [dbo].[Firmalar] ([FirmaID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Firmalar]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Kategoriler] FOREIGN KEY([Kategori])
REFERENCES [dbo].[Kategoriler] ([KategoriID])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Kategoriler]
GO
USE [master]
GO
ALTER DATABASE [Firma] SET  READ_WRITE 
GO
