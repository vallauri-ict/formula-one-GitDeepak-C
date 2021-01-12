CREATE TABLE [dbo].[Teams] (
  [id] int NOT Null,
  [name] varchar(30),
  [fullTeamName] varchar(255),
  [base] varchar(255),
  [extCountry] varchar(2),
  [teamChief] varchar(64),
  [technicalChief] varchar(64),
  [powerUnit] varchar(64),
  [chassis] varchar(10),
  [firstTeamEntry] int,
  [worldChampionships] int,
  [extFirstDriver] int,
  [extSecondDriver] int,
  [imgLogo] varchar(512),
  [imgCar] varchar(512),
  PRIMARY KEY ([id])
);

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (1, N'Alfa Romeo', N'Alfa Romeo Racing ORLEN', N'Hinwil, Switzerland', N'CH', N'Frédéric Vasseur', N'Jan Monchaux', N'Ferrari', N'C39', 1993, 0, 7, 99, N'https://www.formula1.com/content/fom-website/en/teams/Alfa-Romeo-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/alfa-romeo-racing.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (2, N'Ferrari', N'Scuderia Ferrari Mission Winnow', N'Maranello, Italy', N'IT', N'Mattia Binotto', N'Simone Resta', N'Ferrari', N'SF1000', 1950, 16, 5, 16, N'https://www.formula1.com/content/fom-website/en/teams/Ferrari/_jcr_content/logo.img.jpg/1521797345005.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/ferrari.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (3, N'Red Bull', N'Aston Martin Red Bull Racing', N'Milton Keynes, United Kingdom', N'GB', N'Christian Horner', N'Pierre Waché', N'Honda', N'RB16', 1997, 4, 33, 23, N'https://www.formula1.com/content/fom-website/en/teams/Red-Bull-Racing/_jcr_content/logo.img.jpg/1514762875081.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/red-bull-racing.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (4, N'Haas', N'Haas F1 Team', N'Kannapolis, United States', N'US', N'Guenther Steiner', N'Rob Taylor', N'Ferrari', N'VF-20', 2016, 0, 8, 20, N'https://www.formula1.com/content/fom-website/en/teams/Haas-F1-Team/_jcr_content/logo.img.jpg/1593435807209.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/haas-f1-team.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (5, N'McLaren', N'McLaren F1 Team', N'Woking, United Kingdom', N'GB', N'Andreas Seidl', N'James Key', N'Renault', N'MCL35', 1966, 8, 55, 4, N'https://www.formula1.com/content/fom-website/en/teams/McLaren/_jcr_content/logo.img.jpg/1515152671364.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/mclaren.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (6, N'Mercedes', N'Mercedes-AMG Petronas F1 Team', N'Brackley, United Kingdom', N'GB', N'Toto Wolff', N'James Allison', N'Mercedes', N'W11', 1970, 7, 44, 77, N'https://www.formula1.com/content/fom-website/en/teams/Mercedes/_jcr_content/logo.img.jpg/1582638375557.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/mercedes.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (7, N'AlphaTauri', N'Scuderia AlphaTauri Honda', N'Faenza, Italy', N'IT', N'Franz Tost', N'Jody Eggington', N'Honda', N'AT01', 1985, 0, 26, 10, N'https://www.formula1.com/content/fom-website/en/teams/AlphaTauri/_jcr_content/logo.img.jpg/1582650480954.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/alphatauri.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (8, N'Racing Point', N'BWT Racing Point F1 Team', N'Silverstone, United Kingdom', N'GB', N'Otmar Szafnauer', N'Andrew Green', N'BWT Mercedes', N'RP20', 0, 0, 11, 18, N'https://www.formula1.com/content/fom-website/en/teams/Racing-Point/_jcr_content/logo.img.jpg/1582650505746.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/racing-point.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (9, N'Williams', N'Williams Racing', N'Grove, United Kingdom', N'GB', N'Simon Roberts', N'TBC', N'Mercedes', N'FW43', 1978, 9, 63, 6, N'https://www.formula1.com/content/fom-website/en/teams/Williams/_jcr_content/logo.img.jpg/1590743675531.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/williams.png.transform/2col/image.png');

INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [base], [extCountry], [teamChief], [technicalChief], [powerUnit], [chassis], [firstTeamEntry], [worldChampionships], [extFirstDriver], [extSecondDriver], [imgLogo], [imgCar]) 
VALUES (10, N'Renault', N'Renault DP World F1 Team', N'Enstone, United Kingdom', N'GB', N'Cyril Abiteboul', N'TBC', 'Renault', N'	R.S.20', 1986, 2, 3, 31, N'https://www.formula1.com/content/fom-website/en/teams/Renault/_jcr_content/logo.img.jpg/1584017512684.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/renault.png.transform/2col/image.png');