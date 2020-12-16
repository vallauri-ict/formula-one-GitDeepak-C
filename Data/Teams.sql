CREATE TABLE [dbo].[Teams] (
  [id] int PRIMARY KEY NOT Null,
  [name] varchar(30),
  [fullTeamName] varchar(255),
  [base] varchar(255),
  [extCountry] varchar(2),
  [teamChief] varchar(64),
  [technicalChief] varchar(64),
  [powerUnit] varchar(64),
  [chassis] varchar(10),
  [firstTeamEntry] date,
  [worldChampionships] int,
  [extFirstDriver] int,
  [extSecondDriver] int,
  [imgLogo] varchar(512),
  [imgCar] varchar(512)
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Teams] ON;
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (1, N'Alfa Romeo', N'Alfa Romeo Racing', N'CH', N'Ferrari', N'Jan Monchaux', N'C38', 14, 16, N'https://www.formula1.com/content/fom-website/en/teams/Alfa-Romeo-Racing/_jcr_content/logo.img.jpg/1582650443223.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/alfa-romeo-racing.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (2, N'Ferrari', N'Scuderia Ferrari Mission Winnow', N'IT', N'Ferrari', N'Mattia Binotto', N'SF90', 3, 5, N'https://www.formula1.com/content/fom-website/en/teams/Ferrari/_jcr_content/logo.img.jpg/1521797345005.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/ferrari.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (3, N'Red Bull', N'Aston Martin Red Bull Racing', N'GB', N'Honda', N'Pierre Waché', N'RB15', 7, 8, N'https://www.formula1.com/content/fom-website/en/teams/Red-Bull-Racing/_jcr_content/logo.img.jpg/1514762875081.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/red-bull-racing.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (4, N'Haas', N'Haas F1 Team', N'US', N'Ferrari', N'Rob Taylor', N'VF-19', 18, 17, N'https://www.formula1.com/content/fom-website/en/teams/Haas-F1-Team/_jcr_content/logo.img.png/1568040720597.png', N'https://www.formula1.com/content/dam/fom-website/teams/2020/haas-f1-team.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (5, N'McLaren', N'McLaren F1 Team', N'GB', N'Renault', N'James Key', N'MCL34', 9, 10, N'https://www.formula1.com/content/fom-website/en/teams/McLaren/_jcr_content/logo.img.jpg/1515152671364.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/mclaren.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (6, N'Mercedes', N'Mercedes AMG Petronas Motorsport', N'GB', N'Mercedes', N'James Allison', N'W10', 1, 2, N'https://www.formula1.com/content/fom-website/en/teams/Mercedes/_jcr_content/logo.img.jpg/1582638375557.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/mercedes.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (7, N'Toro Rosso', N'Red Bull Toro Rosso Honda', N'IT', N'Honda', N'Jody Eggington', N'STR14', 4, 20, N'https://www.formula1.it/admin/foto/Scuderie/Scuderia_173.gif.png', N'https://www.formula1.com/content/dam/fom-website/teams/2020/alphatauri.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (8, N'Racing Point', N'SportPesa Racing Point F1 Team', N'GB', N'BWT Mercedes', N'Andrew Green', N'RP19', 12, 15, N'https://www.formula1.com/content/fom-website/en/teams/Racing-Point/_jcr_content/logo.img.jpg/1582650505746.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/racing-point.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (9, N'Williams', N'ROKiT Williams Racing', N'GB', N'Mercedes', N'TBC', N'FW42', 13, 19, N'https://www.formula1.com/content/fom-website/en/teams/Williams/_jcr_content/logo.img.png/1551261665481.png', N'https://www.formula1.com/content/dam/fom-website/teams/2020/williams.png.transform/2col/image.png');
INSERT INTO [dbo].[Teams] ([id], [name], [fullTeamName], [extCountry], [powerUnit], [technicalChief], [chassis], [extFirstDriver], [extSecondDriver], [logo], [img]) VALUES (10, N'Renault', N'Renault F1 Team', N'GB', N'Renault', N'Nick Chester', N'R.S.19', 6, 11, N'https://www.formula1.com/content/fom-website/en/teams/Renault/_jcr_content/logo.img.jpg/1584017512684.jpg', N'https://www.formula1.com/content/dam/fom-website/teams/2020/renault.png.transform/2col/image.png');
SET IDENTITY_INSERT [dbo].[Teams] OFF;