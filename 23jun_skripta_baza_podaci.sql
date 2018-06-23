SET IDENTITY_INSERT [dbo].[SkolskaGodina] ON 

INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (1, N'2015/16')
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (2, N'2016/17')
INSERT [dbo].[SkolskaGodina] ([SkolskaGodinaId], [Naziv]) VALUES (3, N'2017/18')
SET IDENTITY_INSERT [dbo].[SkolskaGodina] OFF
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
SET IDENTITY_INSERT [dbo].[Smjerovi] ON 

INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (4, N'Matematika-Informatika', N'Matematičko informatički smjer', 3)
INSERT [dbo].[Smjerovi] ([SmjerId], [Naziv], [Opis], [SkolskaGodinaId]) VALUES (5, N'Informatika', N'Informaticki smjer', 3)
SET IDENTITY_INSERT [dbo].[Smjerovi] OFF
SET IDENTITY_INSERT [dbo].[Razred] ON 

INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (2, N'a', N'1-a', 1, 2, 3, 4)
INSERT [dbo].[Razred] ([RazredId], [Odjeljenje], [Oznaka], [RazredBrojcano], [RazrednikId], [SkolskaGodinaId], [SmjerId]) VALUES (3, N'b', N'1-b', 1, 4, 3, 5)
SET IDENTITY_INSERT [dbo].[Razred] OFF


SET IDENTITY_INSERT [dbo].[Uloge] ON 

INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (1, 1, 0, N'Administrator', 0, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (2, 0, 1, N'Nastavnik', 0, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (3, 0, 0, N'Roditelj', 1, 0, 0)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (4, 1, 1, N'SuperAdministrator', 1, 1, 1)
INSERT [dbo].[Uloge] ([UlogaId], [Administrator], [Nastavnik], [Naziv], [Roditelj], [SuperAdministrator], [Ucenik]) VALUES (5, 0, 0, N'Ucenik', 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Uloge] OFF
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

SET IDENTITY_INSERT [dbo].[UceniciRazredi] ON 

INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (1, 2, 1, N'2017/18', 3)
INSERT [dbo].[UceniciRazredi] ([UcenikRazrediId], [RazredId], [RedniBroj], [SkolskaGodina], [UcenikId]) VALUES (3, 3, 1, N'2017/18', 7)
SET IDENTITY_INSERT [dbo].[UceniciRazredi] OFF
