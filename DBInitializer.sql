USE [12jun]


--Uloge
INSERT INTO [dbo].[Uloge]
           ([Administrator]
           ,[Nastavnik]
           ,[Naziv]
           ,[Roditelj]
           ,[SuperAdministrator]
           ,[Ucenik])
     VALUES
           (1,0, 'Administrator',0, 0,0),
           (0,1, 'Nastavnik',0, 0,0),
           (0,0, 'Roditelj',1, 0,0),
           (1,1, 'Super Administrator',1, 1,1),
           (0,0, 'Ucenik',0, 0,1)
GO

--Predmeti 
SET IDENTITY_INSERT dbo.Predmet ON
GO
INSERT INTO [dbo].[Predmet]
			(PredmetId,Naziv,Oznaka)
     VALUES
	 (1,'Matemtika I', 'MAT I'),
	 (2,'Matematika II', 'MAT II'),
	 (3,'Engleski jezik', 'EJ'),
	 (4,'Njemacki jezik', 'NJ'),
	 (5,'Bosanski jezik', 'BJ'),
	 (6,'Informatika', 'INF'),
	 (7,'Algoritmi i strukture podataka', 'ASP'),
	 (8,'Geografija', 'GEO'),
	 (9,'Historija', 'HIS')
GO
SET IDENTITY_INSERT dbo.Predmet OFF
GO
SET IDENTITY_INSERT dbo.SkolskaGodina ON
INSERT INTO SkolskaGodina (SkolskaGodinaId,Naziv)
	VALUES 
			(1,'2015/16'),
			(2,'2016/17'),
			(3,'2017/18')
GO
SET IDENTITY_INSERT dbo.SkolskaGodina OFF
--Smjerovi
INSERT INTO [dbo].[Smjerovi]
           ([Naziv]
           ,[Opis]
           ,[SkolskaGodinaId])
     VALUES
           ('Matematika-Informatika', 'Matematičko informatički smjer', 1),
           ('Informatika', 'Informatički smjer', 2)
GO
