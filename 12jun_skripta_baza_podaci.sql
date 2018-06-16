USE [master]
GO
/****** Object:  Database [12jun]    Script Date: 6/13/2018 3:24:45 AM ******/
CREATE DATABASE [12jun]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'12jun', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\12jun.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'12jun_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\12jun_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [12jun] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [12jun].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [12jun] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [12jun] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [12jun] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [12jun] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [12jun] SET ARITHABORT OFF 
GO
ALTER DATABASE [12jun] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [12jun] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [12jun] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [12jun] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [12jun] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [12jun] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [12jun] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [12jun] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [12jun] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [12jun] SET  ENABLE_BROKER 
GO
ALTER DATABASE [12jun] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [12jun] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [12jun] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [12jun] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [12jun] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [12jun] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [12jun] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [12jun] SET RECOVERY FULL 
GO
ALTER DATABASE [12jun] SET  MULTI_USER 
GO
ALTER DATABASE [12jun] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [12jun] SET DB_CHAINING OFF 
GO
ALTER DATABASE [12jun] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [12jun] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [12jun] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'12jun', N'ON'
GO
ALTER DATABASE [12jun] SET QUERY_STORE = OFF
GO
USE [12jun]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [12jun]
GO
/****** Object:  Table [dbo].[AutorizacijskiToken]    Script Date: 6/13/2018 3:24:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutorizacijskiToken](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IpAdresa] [nvarchar](max) NULL,
	[KorisnikId] [int] NOT NULL,
	[Vrijednost] [nvarchar](max) NULL,
	[VrijemeEvidentiranja] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AutorizacijskiToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Casovi]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casovi](
	[CasId] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[Naslov] [nvarchar](max) NULL,
	[NastavnikId] [int] NOT NULL,
	[Opis] [nvarchar](max) NULL,
 CONSTRAINT [PK_Casovi] PRIMARY KEY CLUSTERED 
(
	[CasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Izostanci]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Izostanci](
	[IzostanakId] [int] IDENTITY(1,1) NOT NULL,
	[CasId] [int] NOT NULL,
	[Komentar] [nvarchar](max) NULL,
	[Razlog] [nvarchar](max) NULL,
	[UcenikId] [int] NOT NULL,
 CONSTRAINT [PK_Izostanci] PRIMARY KEY CLUSTERED 
(
	[IzostanakId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnici]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Aktivan] [bit] NOT NULL,
	[DatumRodjenja] [datetime2](7) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[JMBG] [nvarchar](max) NULL,
	[KorisnickoIme] [nvarchar](max) NULL,
	[LozinkaHash] [nvarchar](max) NULL,
	[LozinkaSalt] [nvarchar](max) NULL,
	[MjestoRodjenja] [nvarchar](max) NULL,
	[Prebivaliste] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[Spol] [nvarchar](max) NULL,
	[DatumIzboraUZvanje] [datetime2](7) NULL,
	[GodinaZaposlenja] [int] NULL,
	[NaucnaOblast] [nvarchar](max) NULL,
	[Zvanje] [nvarchar](max) NULL,
	[GodinaUpisa] [int] NULL,
	[ImeRoditelja] [nvarchar](max) NULL,
	[NazivOsnovneSkole] [nvarchar](max) NULL,
	[ProsjekOcjenaOsnovnaSkola] [float] NULL,
	[SmjerId] [int] NULL,
 CONSTRAINT [PK_Korisnici] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KorisniciUloge]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorisniciUloge](
	[KorisniciUlogeId] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[UlogaID] [int] NOT NULL,
 CONSTRAINT [PK_KorisniciUloge] PRIMARY KEY CLUSTERED 
(
	[KorisniciUlogeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KorisnikKontakt]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorisnikKontakt](
	[KorisnikKontaktId] [int] NOT NULL,
	[Adresa] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Grad] [nvarchar](max) NULL,
	[Opstina] [nvarchar](max) NULL,
	[Telefon] [nvarchar](max) NULL,
 CONSTRAINT [PK_KorisnikKontakt] PRIMARY KEY CLUSTERED 
(
	[KorisnikKontaktId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materijali]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materijali](
	[MaterijalId] [int] IDENTITY(1,1) NOT NULL,
	[Fajl] [varbinary](max) NULL,
	[Napomena] [nvarchar](max) NULL,
	[NastavnikId] [int] NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[SkolskaGodinaId] [int] NOT NULL,
 CONSTRAINT [PK_Materijali] PRIMARY KEY CLUSTERED 
(
	[MaterijalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obavijesti]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obavijesti](
	[ObavijestId] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[KorisnikId] [int] NOT NULL,
	[Naslov] [nvarchar](max) NULL,
	[Tekst] [nvarchar](max) NULL,
 CONSTRAINT [PK_Obavijesti] PRIMARY KEY CLUSTERED 
(
	[ObavijestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predaje]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predaje](
	[PredajeId] [int] IDENTITY(1,1) NOT NULL,
	[NastavnikId] [int] NOT NULL,
	[SkolskaGodinaId] [int] NOT NULL,
	[SmjerPredmetId] [int] NOT NULL,
 CONSTRAINT [PK_Predaje] PRIMARY KEY CLUSTERED 
(
	[PredajeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Predmet]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Predmet](
	[PredmetId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Oznaka] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Predmet] PRIMARY KEY CLUSTERED 
(
	[PredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Razred]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Razred](
	[RazredId] [int] IDENTITY(1,1) NOT NULL,
	[Odjeljenje] [nvarchar](max) NULL,
	[Oznaka] [nvarchar](max) NULL,
	[RazredBrojcano] [int] NOT NULL,
	[RazrednikId] [int] NOT NULL,
	[SkolskaGodinaId] [int] NOT NULL,
	[SmjerId] [int] NOT NULL,
 CONSTRAINT [PK_Razred] PRIMARY KEY CLUSTERED 
(
	[RazredId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkolskaGodina]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkolskaGodina](
	[SkolskaGodinaId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
 CONSTRAINT [PK_SkolskaGodina] PRIMARY KEY CLUSTERED 
(
	[SkolskaGodinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SmjerPredmet]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmjerPredmet](
	[SmjerPredmetId] [int] IDENTITY(1,1) NOT NULL,
	[BrojCasova] [int] NOT NULL,
	[PredmetId] [int] NOT NULL,
	[SmjerId] [int] NOT NULL,
 CONSTRAINT [PK_SmjerPredmet] PRIMARY KEY CLUSTERED 
(
	[SmjerPredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Smjerovi]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Smjerovi](
	[SmjerId] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[Opis] [nvarchar](max) NULL,
	[SkolskaGodinaId] [int] NOT NULL,
 CONSTRAINT [PK_Smjerovi] PRIMARY KEY CLUSTERED 
(
	[SmjerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UceniciCasovi]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UceniciCasovi](
	[UcenikCasoviId] [int] IDENTITY(1,1) NOT NULL,
	[CasId] [int] NOT NULL,
	[UcenikId] [int] NOT NULL,
 CONSTRAINT [PK_UceniciCasovi] PRIMARY KEY CLUSTERED 
(
	[UcenikCasoviId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UceniciOcjene]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UceniciOcjene](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[Napomena] [nvarchar](max) NULL,
	[PredajeId] [int] NOT NULL,
	[TipOcjene] [nvarchar](max) NULL,
	[UcenikId] [int] NOT NULL,
	[Vrijednost] [int] NOT NULL,
 CONSTRAINT [PK_UceniciOcjene] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UceniciRazredi]    Script Date: 6/13/2018 3:24:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UceniciRazredi](
	[UcenikRazrediId] [int] IDENTITY(1,1) NOT NULL,
	[RazredId] [int] NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[SkolskaGodina] [nvarchar](max) NULL,
	[UcenikId] [int] NOT NULL,
 CONSTRAINT [PK_UceniciRazredi] PRIMARY KEY CLUSTERED 
(
	[UcenikRazrediId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uloge]    Script Date: 6/13/2018 3:24:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uloge](
	[UlogaId] [int] IDENTITY(1,1) NOT NULL,
	[Administrator] [bit] NOT NULL,
	[Nastavnik] [bit] NOT NULL,
	[Naziv] [nvarchar](max) NULL,
	[Roditelj] [bit] NOT NULL,
	[SuperAdministrator] [bit] NOT NULL,
	[Ucenik] [bit] NOT NULL,
 CONSTRAINT [PK_Uloge] PRIMARY KEY CLUSTERED 
(
	[UlogaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/13/2018 3:24:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AutorizacijskiToken] ON 

INSERT [dbo].[AutorizacijskiToken] ([Id], [IpAdresa], [KorisnikId], [Vrijednost], [VrijemeEvidentiranja]) VALUES (4, NULL, 1, N'93e69504-5636-4eea-9b48-d806a9d4b847', CAST(N'2018-06-13T01:51:24.9248176' AS DateTime2))
INSERT [dbo].[AutorizacijskiToken] ([Id], [IpAdresa], [KorisnikId], [Vrijednost], [VrijemeEvidentiranja]) VALUES (5, NULL, 1, N'a6ee2ff3-c661-4e44-b7df-180b83d4f23e', CAST(N'2018-06-13T01:57:07.8554544' AS DateTime2))
SET IDENTITY_INSERT [dbo].[AutorizacijskiToken] OFF
SET IDENTITY_INSERT [dbo].[Korisnici] ON 

INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (1, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Korisnik', N'admin', NULL, N'admin', N'82aeb2ca37120bab4e7433d643aee16be7e5ab9d53e86ca12520db63eacb3e35', N'AZodTEbgc5PCpxusIszmJw==', NULL, NULL, N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (2, 1, CAST(N'1997-01-01T00:00:00.0000000' AS DateTime2), N'Nastavnik', N'Denis', N'01029971234567', N'denis', N'dc726daa283b34bae4a1f45dea1fad29eeb09e2b317ec17c1f7789bc1c4b1153', N'GtZZfN3CnwdmIrrKvaGEig==', N'Mostar', N'Mostar, Zalik', N'Mušić', N'M', CAST(N'2013-01-01T00:00:00.0000000' AS DateTime2), 2005, N'Softverski Inzinjering', N'doc.dr', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (3, 1, CAST(N'2003-01-01T00:00:00.0000000' AS DateTime2), N'Ucenik', N'Bakir', N'0101003123456', N'bakir', N'966fb1433dc7a1dc480d92ec58e9097a4a63e9fdeb1c11551e4693e06ec4d79e', N'trmuRA5V4bnVzFkpC0n/UQ==', N'Mostar', N'Mostar, Zalik', N'Omercausevic', N'M', NULL, NULL, NULL, NULL, 2018, N'Ime', N'Osnovna škola "Zalik", Mostar', 4.7, 5)
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (4, 1, CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2), N'Nastavnik', N'Jasmin', N'010100312345', N'jasmin', N'b9dafb7c7110af89d72d7e6388a99d3907796919a7cf37c916cad512c8d06bcd', N'Hg+WCYegGJ/+r1/nOBu6/A==', N'Mostar', N'Mostar, Zalik', N'Azemovic', N'M', CAST(N'2014-01-01T00:00:00.0000000' AS DateTime2), 2003, N'Baze podataka', N'prof.dr', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (7, 1, CAST(N'2003-01-01T00:00:00.0000000' AS DateTime2), N'Ucenik', N'Bakir', N'0102997123456', N'bakir.vezic', N'eccd0e3eb3f88347ef662a34cdd5e76e5a184889cf5e49bb8b3cf4d7147fe1ad', N'XZFrXhvcjC1QDOvDfwVm+g==', N'Mostar', N'Mostar, Zalik', N'Vežić', N'M', NULL, NULL, NULL, NULL, 2018, N'Hehe', N'Osnovna škola "Zalik", Mostar', 4.64, 5)
SET IDENTITY_INSERT [dbo].[Korisnici] OFF
SET IDENTITY_INSERT [dbo].[KorisniciUloge] ON 

INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (1, 1, 4)
INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (2, 2, 2)
INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (3, 4, 2)
SET IDENTITY_INSERT [dbo].[KorisniciUloge] OFF
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (2, N'Zalik', N'denis@test.fit.ba', N'Mostar', N'Mostar', N'123-456-789')
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (3, N'Zalik', N'bakir@hotmail.com', N'Mostar', N'Mostar', N'123-456-789')
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (4, N'Zalik', N'haris@fit.ba', N'Mostar', N'Mostar', N'123-123-123')
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (7, N'Zalik', N'bakir.vezic@test.fit.ba', N'Mostar', N'Mostar', N'061-123-456')
SET IDENTITY_INSERT [dbo].[Predmet] ON 

INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (1, N'Matemtika I', N'MAT I')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (2, N'Matematika II', N'MAT II')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (3, N'Engleski jezik', N'EJ')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (4, N'Njemacki jezik', N'NJ')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (5, N'Bosanski jezik', N'BJ')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (6, N'Informatika', N'INF')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (7, N'Algoritmi i strukture podataka', N'ASP')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (8, N'Geografija', N'GEO')
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (9, N'Historija', N'HIS')
SET IDENTITY_INSERT [dbo].[Predmet] OFF
SET IDENTITY_INSERT [dbo].[Razred] ON 

INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (2, N'a', N'1-a', 1, 2, 3, 4)
INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (3, N'b', N'1-b', 1, 4, 3, 5)
SET IDENTITY_INSERT [dbo].[Razred] OFF
SET IDENTITY_INSERT [dbo].[SkolskaGodina] ON 

INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (1, N'2015/16')
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (2, N'2016/17')
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (3, N'2017/18')
SET IDENTITY_INSERT [dbo].[SkolskaGodina] OFF
SET IDENTITY_INSERT [dbo].[SmjerPredmet] ON 

INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (1, 0, 1, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (2, 0, 2, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (3, 0, 3, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (4, 0, 4, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (5, 0, 5, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (6, 0, 6, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (7, 0, 7, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (8, 0, 8, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (9, 0, 9, 4)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (10, 0, 1, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (11, 0, 3, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (12, 0, 4, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (13, 0, 5, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (14, 0, 6, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (15, 0, 7, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (16, 0, 8, 5)
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (17, 0, 9, 5)
SET IDENTITY_INSERT [dbo].[SmjerPredmet] OFF
SET IDENTITY_INSERT [dbo].[Smjerovi] ON 

INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (4, N'Matematika-Informatika', N'Matematičko informatički smjer', 3)
INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (5, N'Informatika', N'Informaticki smjer', 3)
SET IDENTITY_INSERT [dbo].[Smjerovi] OFF
SET IDENTITY_INSERT [dbo].[UceniciRazredi] ON 

INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (1, 2, 1, N'2017/18', 3)
INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (3, 3, 1, N'2017/18', 7)
SET IDENTITY_INSERT [dbo].[UceniciRazredi] OFF
SET IDENTITY_INSERT [dbo].[Uloge] ON 

INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (1, 1, 0, N'Administrator', 0, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (2, 0, 1, N'Nastavnik', 0, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (3, 0, 0, N'Roditelj', 1, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (4, 1, 1, N'SuperAdministrator', 1, 1, 1)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (5, 0, 0, N'Ucenik', 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Uloge] OFF
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180612193245_12jun', N'2.0.1-rtm-125')
/****** Object:  Index [IX_AutorizacijskiToken_KorisnikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_AutorizacijskiToken_KorisnikId] ON [dbo].[AutorizacijskiToken]
(
	[KorisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Casovi_NastavnikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Casovi_NastavnikId] ON [dbo].[Casovi]
(
	[NastavnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Izostanci_CasId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Izostanci_CasId] ON [dbo].[Izostanci]
(
	[CasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Izostanci_UcenikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Izostanci_UcenikId] ON [dbo].[Izostanci]
(
	[UcenikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Korisnici_SmjerId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Korisnici_SmjerId] ON [dbo].[Korisnici]
(
	[SmjerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KorisniciUloge_KorisnikID]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_KorisniciUloge_KorisnikID] ON [dbo].[KorisniciUloge]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_KorisniciUloge_UlogaID]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_KorisniciUloge_UlogaID] ON [dbo].[KorisniciUloge]
(
	[UlogaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Materijali_NastavnikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Materijali_NastavnikId] ON [dbo].[Materijali]
(
	[NastavnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Materijali_SkolskaGodinaId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Materijali_SkolskaGodinaId] ON [dbo].[Materijali]
(
	[SkolskaGodinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Obavijesti_KorisnikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Obavijesti_KorisnikId] ON [dbo].[Obavijesti]
(
	[KorisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Predaje_NastavnikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Predaje_NastavnikId] ON [dbo].[Predaje]
(
	[NastavnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Predaje_SkolskaGodinaId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Predaje_SkolskaGodinaId] ON [dbo].[Predaje]
(
	[SkolskaGodinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Predaje_SmjerPredmetId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Predaje_SmjerPredmetId] ON [dbo].[Predaje]
(
	[SmjerPredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Razred_RazrednikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Razred_RazrednikId] ON [dbo].[Razred]
(
	[RazrednikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Razred_SkolskaGodinaId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Razred_SkolskaGodinaId] ON [dbo].[Razred]
(
	[SkolskaGodinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Razred_SmjerId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Razred_SmjerId] ON [dbo].[Razred]
(
	[SmjerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SmjerPredmet_PredmetId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_SmjerPredmet_PredmetId] ON [dbo].[SmjerPredmet]
(
	[PredmetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SmjerPredmet_SmjerId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_SmjerPredmet_SmjerId] ON [dbo].[SmjerPredmet]
(
	[SmjerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Smjerovi_SkolskaGodinaId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_Smjerovi_SkolskaGodinaId] ON [dbo].[Smjerovi]
(
	[SkolskaGodinaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciCasovi_CasId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciCasovi_CasId] ON [dbo].[UceniciCasovi]
(
	[CasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciCasovi_UcenikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciCasovi_UcenikId] ON [dbo].[UceniciCasovi]
(
	[UcenikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciOcjene_PredajeId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciOcjene_PredajeId] ON [dbo].[UceniciOcjene]
(
	[PredajeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciOcjene_UcenikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciOcjene_UcenikId] ON [dbo].[UceniciOcjene]
(
	[UcenikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciRazredi_RazredId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciRazredi_RazredId] ON [dbo].[UceniciRazredi]
(
	[RazredId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UceniciRazredi_UcenikId]    Script Date: 6/13/2018 3:24:47 AM ******/
CREATE NONCLUSTERED INDEX [IX_UceniciRazredi_UcenikId] ON [dbo].[UceniciRazredi]
(
	[UcenikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AutorizacijskiToken]  WITH CHECK ADD  CONSTRAINT [FK_AutorizacijskiToken_Korisnici_KorisnikId] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AutorizacijskiToken] CHECK CONSTRAINT [FK_AutorizacijskiToken_Korisnici_KorisnikId]
GO
ALTER TABLE [dbo].[Casovi]  WITH CHECK ADD  CONSTRAINT [FK_Casovi_Korisnici_NastavnikId] FOREIGN KEY([NastavnikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Casovi] CHECK CONSTRAINT [FK_Casovi_Korisnici_NastavnikId]
GO
ALTER TABLE [dbo].[Izostanci]  WITH CHECK ADD  CONSTRAINT [FK_Izostanci_Casovi_CasId] FOREIGN KEY([CasId])
REFERENCES [dbo].[Casovi] ([CasId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Izostanci] CHECK CONSTRAINT [FK_Izostanci_Casovi_CasId]
GO
ALTER TABLE [dbo].[Izostanci]  WITH CHECK ADD  CONSTRAINT [FK_Izostanci_Korisnici_UcenikId] FOREIGN KEY([UcenikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[Izostanci] CHECK CONSTRAINT [FK_Izostanci_Korisnici_UcenikId]
GO
ALTER TABLE [dbo].[Korisnici]  WITH CHECK ADD  CONSTRAINT [FK_Korisnici_Smjerovi_SmjerId] FOREIGN KEY([SmjerId])
REFERENCES [dbo].[Smjerovi] ([SmjerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Korisnici] CHECK CONSTRAINT [FK_Korisnici_Smjerovi_SmjerId]
GO
ALTER TABLE [dbo].[KorisniciUloge]  WITH CHECK ADD  CONSTRAINT [FK_KorisniciUloge_Korisnici_KorisnikID] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KorisniciUloge] CHECK CONSTRAINT [FK_KorisniciUloge_Korisnici_KorisnikID]
GO
ALTER TABLE [dbo].[KorisniciUloge]  WITH CHECK ADD  CONSTRAINT [FK_KorisniciUloge_Uloge_UlogaID] FOREIGN KEY([UlogaID])
REFERENCES [dbo].[Uloge] ([UlogaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KorisniciUloge] CHECK CONSTRAINT [FK_KorisniciUloge_Uloge_UlogaID]
GO
ALTER TABLE [dbo].[KorisnikKontakt]  WITH CHECK ADD  CONSTRAINT [FK_KorisnikKontakt_Korisnici_KorisnikKontaktId] FOREIGN KEY([KorisnikKontaktId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KorisnikKontakt] CHECK CONSTRAINT [FK_KorisnikKontakt_Korisnici_KorisnikKontaktId]
GO
ALTER TABLE [dbo].[Materijali]  WITH CHECK ADD  CONSTRAINT [FK_Materijali_Korisnici_NastavnikId] FOREIGN KEY([NastavnikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materijali] CHECK CONSTRAINT [FK_Materijali_Korisnici_NastavnikId]
GO
ALTER TABLE [dbo].[Materijali]  WITH CHECK ADD  CONSTRAINT [FK_Materijali_SkolskaGodina_SkolskaGodinaId] FOREIGN KEY([SkolskaGodinaId])
REFERENCES [dbo].[SkolskaGodina] ([SkolskaGodinaId])
GO
ALTER TABLE [dbo].[Materijali] CHECK CONSTRAINT [FK_Materijali_SkolskaGodina_SkolskaGodinaId]
GO
ALTER TABLE [dbo].[Obavijesti]  WITH CHECK ADD  CONSTRAINT [FK_Obavijesti_Korisnici_KorisnikId] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Obavijesti] CHECK CONSTRAINT [FK_Obavijesti_Korisnici_KorisnikId]
GO
ALTER TABLE [dbo].[Predaje]  WITH CHECK ADD  CONSTRAINT [FK_Predaje_Korisnici_NastavnikId] FOREIGN KEY([NastavnikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Predaje] CHECK CONSTRAINT [FK_Predaje_Korisnici_NastavnikId]
GO
ALTER TABLE [dbo].[Predaje]  WITH CHECK ADD  CONSTRAINT [FK_Predaje_SkolskaGodina_SkolskaGodinaId] FOREIGN KEY([SkolskaGodinaId])
REFERENCES [dbo].[SkolskaGodina] ([SkolskaGodinaId])
GO
ALTER TABLE [dbo].[Predaje] CHECK CONSTRAINT [FK_Predaje_SkolskaGodina_SkolskaGodinaId]
GO
ALTER TABLE [dbo].[Predaje]  WITH CHECK ADD  CONSTRAINT [FK_Predaje_SmjerPredmet_SmjerPredmetId] FOREIGN KEY([SmjerPredmetId])
REFERENCES [dbo].[SmjerPredmet] ([SmjerPredmetId])
GO
ALTER TABLE [dbo].[Predaje] CHECK CONSTRAINT [FK_Predaje_SmjerPredmet_SmjerPredmetId]
GO
ALTER TABLE [dbo].[Razred]  WITH CHECK ADD  CONSTRAINT [FK_Razred_Korisnici_RazrednikId] FOREIGN KEY([RazrednikId])
REFERENCES [dbo].[Korisnici] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Razred] CHECK CONSTRAINT [FK_Razred_Korisnici_RazrednikId]
GO
ALTER TABLE [dbo].[Razred]  WITH CHECK ADD  CONSTRAINT [FK_Razred_SkolskaGodina_SkolskaGodinaId] FOREIGN KEY([SkolskaGodinaId])
REFERENCES [dbo].[SkolskaGodina] ([SkolskaGodinaId])
GO
ALTER TABLE [dbo].[Razred] CHECK CONSTRAINT [FK_Razred_SkolskaGodina_SkolskaGodinaId]
GO
ALTER TABLE [dbo].[Razred]  WITH CHECK ADD  CONSTRAINT [FK_Razred_Smjerovi_SmjerId] FOREIGN KEY([SmjerId])
REFERENCES [dbo].[Smjerovi] ([SmjerId])
GO
ALTER TABLE [dbo].[Razred] CHECK CONSTRAINT [FK_Razred_Smjerovi_SmjerId]
GO
ALTER TABLE [dbo].[SmjerPredmet]  WITH CHECK ADD  CONSTRAINT [FK_SmjerPredmet_Predmet_PredmetId] FOREIGN KEY([PredmetId])
REFERENCES [dbo].[Predmet] ([PredmetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SmjerPredmet] CHECK CONSTRAINT [FK_SmjerPredmet_Predmet_PredmetId]
GO
ALTER TABLE [dbo].[SmjerPredmet]  WITH CHECK ADD  CONSTRAINT [FK_SmjerPredmet_Smjerovi_SmjerId] FOREIGN KEY([SmjerId])
REFERENCES [dbo].[Smjerovi] ([SmjerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SmjerPredmet] CHECK CONSTRAINT [FK_SmjerPredmet_Smjerovi_SmjerId]
GO
ALTER TABLE [dbo].[Smjerovi]  WITH CHECK ADD  CONSTRAINT [FK_Smjerovi_SkolskaGodina_SkolskaGodinaId] FOREIGN KEY([SkolskaGodinaId])
REFERENCES [dbo].[SkolskaGodina] ([SkolskaGodinaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Smjerovi] CHECK CONSTRAINT [FK_Smjerovi_SkolskaGodina_SkolskaGodinaId]
GO
ALTER TABLE [dbo].[UceniciCasovi]  WITH CHECK ADD  CONSTRAINT [FK_UceniciCasovi_Casovi_CasId] FOREIGN KEY([CasId])
REFERENCES [dbo].[Casovi] ([CasId])
GO
ALTER TABLE [dbo].[UceniciCasovi] CHECK CONSTRAINT [FK_UceniciCasovi_Casovi_CasId]
GO
ALTER TABLE [dbo].[UceniciCasovi]  WITH CHECK ADD  CONSTRAINT [FK_UceniciCasovi_Korisnici_UcenikId] FOREIGN KEY([UcenikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[UceniciCasovi] CHECK CONSTRAINT [FK_UceniciCasovi_Korisnici_UcenikId]
GO
ALTER TABLE [dbo].[UceniciOcjene]  WITH CHECK ADD  CONSTRAINT [FK_UceniciOcjene_Korisnici_UcenikId] FOREIGN KEY([UcenikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[UceniciOcjene] CHECK CONSTRAINT [FK_UceniciOcjene_Korisnici_UcenikId]
GO
ALTER TABLE [dbo].[UceniciOcjene]  WITH CHECK ADD  CONSTRAINT [FK_UceniciOcjene_Predaje_PredajeId] FOREIGN KEY([PredajeId])
REFERENCES [dbo].[Predaje] ([PredajeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UceniciOcjene] CHECK CONSTRAINT [FK_UceniciOcjene_Predaje_PredajeId]
GO
ALTER TABLE [dbo].[UceniciRazredi]  WITH CHECK ADD  CONSTRAINT [FK_UceniciRazredi_Korisnici_UcenikId] FOREIGN KEY([UcenikId])
REFERENCES [dbo].[Korisnici] ([Id])
GO
ALTER TABLE [dbo].[UceniciRazredi] CHECK CONSTRAINT [FK_UceniciRazredi_Korisnici_UcenikId]
GO
ALTER TABLE [dbo].[UceniciRazredi]  WITH CHECK ADD  CONSTRAINT [FK_UceniciRazredi_Razred_RazredId] FOREIGN KEY([RazredId])
REFERENCES [dbo].[Razred] ([RazredId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UceniciRazredi] CHECK CONSTRAINT [FK_UceniciRazredi_Razred_RazredId]
GO
USE [master]
GO
ALTER DATABASE [12jun] SET  READ_WRITE 
GO
