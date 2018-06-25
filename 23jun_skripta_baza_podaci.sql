USE [SrednjeSkoleApp]
GO
SET IDENTITY_INSERT [dbo].[Predmet] ON 
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (1, N'Matemtika I', N'MAT I')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (2, N'Matematika II', N'MAT II')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (3, N'Engleski jezik', N'EJ')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (4, N'Njemacki jezik', N'NJ')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (5, N'Bosanski jezik', N'BJ')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (6, N'Informatika', N'INF')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (7, N'Algoritmi i strukture podataka', N'ASP')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (8, N'Geografija', N'GEO')
GO
INSERT [dbo].[Predmet] ([PredmetId], [Naziv], [Oznaka]) VALUES (9, N'Historija', N'HIS')
GO
SET IDENTITY_INSERT [dbo].[Predmet] OFF
GO
SET IDENTITY_INSERT [dbo].[SkolskaGodina] ON 
GO
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (1, N'2015/16')
GO
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (2, N'2016/17')
GO
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (3, N'2017/18')
GO
SET IDENTITY_INSERT [dbo].[SkolskaGodina] OFF
GO
SET IDENTITY_INSERT [dbo].[Smjerovi] ON 
GO
INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (4, N'Matematika-Informatika', N'Matematičko informatički smjer', 3)
GO
INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (5, N'Informatika', N'Informaticki smjer', 3)
GO
SET IDENTITY_INSERT [dbo].[Smjerovi] OFF
GO
SET IDENTITY_INSERT [dbo].[SmjerPredmet] ON 
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (1, 0, 1, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (2, 0, 2, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (3, 0, 3, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (4, 0, 4, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (5, 0, 5, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (6, 0, 6, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (7, 0, 7, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (8, 0, 8, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (9, 0, 9, 4)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (10, 0, 1, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (11, 0, 3, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (12, 0, 4, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (13, 0, 5, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (14, 0, 6, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (15, 0, 7, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (16, 0, 8, 5)
GO
INSERT [dbo].[SmjerPredmet] ([SmjerPredmetId], [BrojCasova], [PredmetId], [SmjerId]) VALUES (17, 0, 9, 5)
GO
SET IDENTITY_INSERT [dbo].[SmjerPredmet] OFF
GO
SET IDENTITY_INSERT [dbo].[Korisnici] ON 
GO
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (1, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Korisnik', N'admin', NULL, N'admin', N'82aeb2ca37120bab4e7433d643aee16be7e5ab9d53e86ca12520db63eacb3e35', N'AZodTEbgc5PCpxusIszmJw==', NULL, NULL, N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (2, 1, CAST(N'0101-01-01T00:00:00.0000000' AS DateTime2), N'Nastavnik', N'Adil', N'1234567890123', N'adil', N'29f4fd1af2a5985ce86016f66b401b3039e6fd47928073be87b23d36f2c2b939', N'mdExbj1CA7B5DZ8i1VeFjw==', N'Mostar', N'Mostar, Zalik', N'Joldić', N'M', CAST(N'1010-01-01T02:00:00.0000000' AS DateTime2), 2003, N'Softverski Inžinjering', N'mr. sc.', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (5, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Nastavnik', N'Denis', N'0123456789012', N'denis', N'de0e86a463042fd057108c4cc749ca76bf4728461a0c359a8a2630e9fc6dc548', N'g+Ws7qccWoOoNWOKbA/cXw==', N'Mostar', N'Mostar, Zalik', N'Mušić', N'M', CAST(N'2005-01-01T00:00:00.0000000' AS DateTime2), 2001, N'Softverski inzinjering', N'doc. dr', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (6, 1, CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'Ucenik', N'Haris', N'1234567890123', N'haris', N'34a95530dc674e033b3eb243d21f9556ed3938bb1986a44d37bac1bd37541bbb', N'En03mfTYExQfkqObuBEWKA==', N'Mostar', N'Mostar', N'Omerčaušević', N'M', NULL, NULL, NULL, NULL, 2018, N'Emir', N'Osnovna škola "Zalik", Mostar', 4.6, 5)
GO
INSERT [dbo].[Korisnici] ([Id], [Aktivan], [DatumRodjenja], [Discriminator], [Ime], [JMBG], [KorisnickoIme], [LozinkaHash], [LozinkaSalt], [MjestoRodjenja], [Prebivaliste], [Prezime], [Spol], [DatumIzboraUZvanje], [GodinaZaposlenja], [NaucnaOblast], [Zvanje], [GodinaUpisa], [ImeRoditelja], [NazivOsnovneSkole], [ProsjekOcjenaOsnovnaSkola], [SmjerId]) VALUES (7, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'Ucenik', N'Amar', N'0101996150221', N'amar', N'ae468bf1997963708fcec3c72b0f282aeae91267a460d1bde70cde47203ba20d', N'8TyIRN5bBC6TrciCYfFsKA==', N'mostar', N'Mostar', N'Maslo', N'M', NULL, NULL, NULL, NULL, 2018, N'hehe', N'Osnovna škola "Zalik", Mostar', 4.6, 5)
GO
SET IDENTITY_INSERT [dbo].[Korisnici] OFF
GO
SET IDENTITY_INSERT [dbo].[Materijali] ON 
GO
INSERT [dbo].[Materijali] ([MaterijalId], [DateCreated], [NastavnikId], [Naziv], [PredmetId], [Url], [BlobName]) VALUES (1, CAST(N'2018-06-25T19:54:48.8519317' AS DateTime2), 2, N'_forma za finalnu ocjenu 2018_public.xlsx', 1, N'http://srednjeskole.blob.core.windows.net/srednjeskole/24210860-fbc5-48a0-a1ec-e7d2d6a3663f', N'24210860-fbc5-48a0-a1ec-e7d2d6a3663f')
GO
INSERT [dbo].[Materijali] ([MaterijalId], [DateCreated], [NastavnikId], [Naziv], [PredmetId], [Url], [BlobName]) VALUES (2, CAST(N'2018-06-25T20:37:54.4021069' AS DateTime2), 5, N'_forma za finalnu ocjenu 2018_public.xlsx', 1, N'http://srednjeskole.blob.core.windows.net/srednjeskole/dbdde73a-1664-4baf-ba96-11544300468f', N'dbdde73a-1664-4baf-ba96-11544300468f')
GO
SET IDENTITY_INSERT [dbo].[Materijali] OFF
GO
SET IDENTITY_INSERT [dbo].[Razred] ON 
GO
INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (4, N'a', N'1-a', 1, 2, 3, 4)
GO
INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (5, N'b', N'1-b', 1, 5, 3, 5)
GO
SET IDENTITY_INSERT [dbo].[Razred] OFF
GO
SET IDENTITY_INSERT [dbo].[Uloge] ON 
GO
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (1, 1, 0, N'Administrator', 0, 0, 0)
GO
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (2, 0, 1, N'Nastavnik', 0, 0, 0)
GO
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (3, 0, 0, N'Roditelj', 1, 0, 0)
GO
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (4, 1, 1, N'SuperAdministrator', 1, 1, 1)
GO
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (5, 0, 0, N'Ucenik', 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Uloge] OFF
GO
SET IDENTITY_INSERT [dbo].[KorisniciUloge] ON 
GO
INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (1, 1, 4)
GO
INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (2, 2, 2)
GO
INSERT [dbo].[KorisniciUloge] ([KorisniciUlogeId], [KorisnikID], [UlogaID]) VALUES (3, 5, 2)
GO
SET IDENTITY_INSERT [dbo].[KorisniciUloge] OFF
GO
SET IDENTITY_INSERT [dbo].[UceniciRazredi] ON 
GO
INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (1, 4, 1, N'2017/18', 6)
GO
INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (3, 5, 1, N'2017/18', 7)
GO
SET IDENTITY_INSERT [dbo].[UceniciRazredi] OFF
GO
SET IDENTITY_INSERT [dbo].[AutorizacijskiToken] ON 
GO
INSERT [dbo].[AutorizacijskiToken] ([Id], [IpAdresa], [KorisnikId], [Vrijednost], [VrijemeEvidentiranja]) VALUES (7, NULL, 1, N'3a1c52d2-7ee1-44f7-b56a-271205fc96d6', CAST(N'2018-06-25T20:43:03.2954885' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[AutorizacijskiToken] OFF
GO
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (2, N'Zalik', N'adil@edu.fit.ba', N'Mostar', N'Mostar', N'123-456-789')
GO
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (5, N'Zalik', N'haris@edu.fit.ba', N'Mostar', N'Mostar', N'123-456-781')
GO
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (6, N'Zalik ', N'haris.omercausevic@edu.fit.ba', N'Mostar', N'Mostar', N'123-456-789')
GO
INSERT [dbo].[KorisnikKontakt] ([KorisnikKontaktId], [Adresa], [Email], [Grad], [Opstina], [Telefon]) VALUES (7, N'Zalik', N'nekimail@asdkhjk.com', N'Mostar', N'Mostar', N'123-456-789')
GO
SET IDENTITY_INSERT [dbo].[Obavijesti] ON 
GO
INSERT [dbo].[Obavijesti] ([ObavijestId], [Datum], [KorisnikId], [Naslov], [Tekst]) VALUES (1, CAST(N'2018-06-25T19:55:40.6607377' AS DateTime2), 2, N'Upis na FIT', N'Upis na FIT ce se vrsiti od 22.6 do 6.7')
GO
INSERT [dbo].[Obavijesti] ([ObavijestId], [Datum], [KorisnikId], [Naslov], [Tekst]) VALUES (2, CAST(N'2018-06-25T19:56:25.5750034' AS DateTime2), 5, N'prijemni ispit', N'    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.')
GO
SET IDENTITY_INSERT [dbo].[Obavijesti] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180623194925_23jun_materijali', N'2.0.1-rtm-125')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180623222530_materijali_blobname_naziv', N'2.0.1-rtm-125')
GO
