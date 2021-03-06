USE [master]
GO
/****** Object:  Database [Project_MAL]    Script Date: 29/05/2021 12:00:47 ******/
CREATE DATABASE [Project_MAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Project_MAL', FILENAME = N'C:\Users\jarne\Project_MAL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Project_MAL_log', FILENAME = N'C:\Users\jarne\Project_MAL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Project_MAL] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Project_MAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Project_MAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Project_MAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Project_MAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Project_MAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Project_MAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [Project_MAL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Project_MAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Project_MAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Project_MAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Project_MAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Project_MAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Project_MAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Project_MAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Project_MAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Project_MAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Project_MAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Project_MAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Project_MAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Project_MAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Project_MAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Project_MAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Project_MAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Project_MAL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Project_MAL] SET  MULTI_USER 
GO
ALTER DATABASE [Project_MAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Project_MAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Project_MAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Project_MAL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Project_MAL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Project_MAL] SET QUERY_STORE = OFF
GO
USE [Project_MAL]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Project_MAL]
GO
/****** Object:  Schema [Project_MAL]    Script Date: 29/05/2021 12:00:48 ******/
CREATE SCHEMA [Project_MAL]
GO
/****** Object:  Table [Project_MAL].[Anime]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[Anime](
	[animeId] [int] IDENTITY(1,1) NOT NULL,
	[studioId] [int] NULL,
	[name] [varchar](40) NOT NULL,
	[episodes] [int] NOT NULL,
	[aired] [date] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[duration] [int] NOT NULL,
	[rating] [int] NULL,
	[type] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Anime] PRIMARY KEY CLUSTERED 
(
	[animeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[AnimeCollection]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[AnimeCollection](
	[animeCollectionId] [int] IDENTITY(1,1) NOT NULL,
	[animeId] [int] NULL,
	[collectionId] [int] NULL,
 CONSTRAINT [PK_AnimeCollection] PRIMARY KEY CLUSTERED 
(
	[animeCollectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[AnimeGenre]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[AnimeGenre](
	[animeGenreId] [int] IDENTITY(1,1) NOT NULL,
	[animeId] [int] NOT NULL,
	[genreId] [int] NULL,
 CONSTRAINT [PK_AnimeGenre] PRIMARY KEY CLUSTERED 
(
	[animeGenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[Collection]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[Collection](
	[collectionId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_Collection] PRIMARY KEY CLUSTERED 
(
	[collectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[Genre]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[Genre](
	[genreId] [int] IDENTITY(1,1) NOT NULL,
	[nameGenre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[genreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[Studio]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[Studio](
	[studioId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
	[producer] [varchar](40) NOT NULL,
	[location] [varchar](40) NOT NULL,
 CONSTRAINT [PK_Studio] PRIMARY KEY CLUSTERED 
(
	[studioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Project_MAL].[User]    Script Date: 29/05/2021 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Project_MAL].[User](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[email] [varchar](40) NOT NULL,
	[birthday] [date] NOT NULL,
	[location] [varchar](40) NULL,
	[joined] [date] NOT NULL,
	[familyName] [varchar](40) NOT NULL,
	[userName] [varchar](40) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Project_MAL].[Anime] ON 

INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (1, 1, N'That Time I Got Reincarnated as a Slime', 24, CAST(N'2018-10-02' AS Date), N'finished airing', 23, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (2, 2, N'Overlord', 13, CAST(N'2015-07-07' AS Date), N'finished airing', 24, 7, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (3, 3, N'One Piece', 967, CAST(N'1999-10-20' AS Date), N'airing', 24, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (4, 4, N'Naruto', 220, CAST(N'2002-10-03' AS Date), N'finished airing', 23, 7, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (5, 5, N'Detective Conan', 998, CAST(N'1996-01-08' AS Date), N'airing', 25, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (6, 6, N'Haikyuu', 25, CAST(N'2014-04-06' AS Date), N'finished airing', 24, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (7, 7, N'Yu-Gi-Oh! 5Ds', 154, CAST(N'2008-04-02' AS Date), N'finished airing', 24, 7, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (8, 8, N'Fullmetal Alchemist', 51, CAST(N'2003-10-04' AS Date), N'finished airing', 24, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (9, 9, N'Demon Slayer: Kimetsu no Yaiba', 26, CAST(N'2019-04-06' AS Date), N'finished airing', 23, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (10, 4, N'Bleach', 26, CAST(N'2004-10-05' AS Date), N'finished airing', 24, 7, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (2001, 2001, N'Naruto', 220, CAST(N'2002-10-03' AS Date), N'finished airing', 23, 7, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (2003, 2002, N'Detective Conan', 998, CAST(N'1996-01-08' AS Date), N'airing', 25, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (2004, 2003, N'Demon Slayer: Kimetsu no Yaiba', 26, CAST(N'2019-04-06' AS Date), N'finished airing', 23, 8, N'TV')
INSERT [Project_MAL].[Anime] ([animeId], [studioId], [name], [episodes], [aired], [status], [duration], [rating], [type]) VALUES (2005, NULL, N'Fire Force', 0, CAST(N'2021-05-29' AS Date), N'Going', 10, NULL, N'anime')
SET IDENTITY_INSERT [Project_MAL].[Anime] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[AnimeCollection] ON 

INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (1, 1, 1)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (2, 2, NULL)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (3, 3, NULL)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (4, 4, 4)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (5, 5, 5)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (6, 6, 1)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (7, 7, NULL)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (8, 8, NULL)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (9, 9, 4)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (10, 10, 5)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (1001, NULL, 7002)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (1002, NULL, 7003)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (1003, NULL, 7003)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (1004, NULL, 7002)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (2001, 2001, 8004)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (2002, NULL, 8005)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (2003, 2003, 8005)
INSERT [Project_MAL].[AnimeCollection] ([animeCollectionId], [animeId], [collectionId]) VALUES (2004, 2004, 8004)
SET IDENTITY_INSERT [Project_MAL].[AnimeCollection] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[AnimeGenre] ON 

INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (1, 1, 9)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (2, 2, 10)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (3, 3, 11)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (4, 4, 14)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (5, 5, 12)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (6, 6, 13)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (7, 7, NULL)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (8, 8, 2)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (9, 9, 9)
INSERT [Project_MAL].[AnimeGenre] ([animeGenreId], [animeId], [genreId]) VALUES (10, 10, 6)
SET IDENTITY_INSERT [Project_MAL].[AnimeGenre] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[Collection] ON 

INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (1, 1, N'j')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (4, 4, N'test')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (5, 5, N'test4')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (4001, NULL, N'AnimeList1')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (6001, NULL, N'test400')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (7001, NULL, N'NieuweAnimeLijst1')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (7002, 4, N'test')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (7003, 5, N'test4')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (8001, NULL, N'lijst1')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (8002, NULL, N'hallo')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (8003, NULL, N'test2')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (8004, 4, N'test')
INSERT [Project_MAL].[Collection] ([collectionId], [userId], [name]) VALUES (8005, 5, N'test4')
SET IDENTITY_INSERT [Project_MAL].[Collection] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[Genre] ON 

INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (1, N'Action, Adventure, Martial Arts, Shounen, Super Power')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (2, N'Action, Adventure, Comedy, Drama, Shounen, Military')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (3, N'Action, Comedy, Fantasy, Magic, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (4, N'Action, Adventure, Comedy, Drama, Sci-Fi, Shounen, Supernatural')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (5, N'Action, Adventure, Fantasy, Horror, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (6, N'Action, Adventure, Shounen, Super Power, Supernatural')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (7, N'Action, Demons, Historical, Shounen, Supernatural')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (8, N'Action, Adventure, Comedy, Shounen, Super Power, Supernatural')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (9, N'Fantasy, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (10, N'Action, Adventure, Comedy, Martial Arts, Sci-Fi, Shounen, Super Power')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (11, N'Action, Adventure, Comedy, Martial Arts, Drama, Shounen, Fantasy, Super Power')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (12, N'Adventure, Mystery, Comedy, Police, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (13, N'Comedy, Sport, Drama, School, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (14, N'Action, Adventure, Comedy, Shounen, Super Power, Supernatural')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (15, N'Fantasy, Shounen')
INSERT [Project_MAL].[Genre] ([genreId], [nameGenre]) VALUES (16, N'Action, Adventure, Fantasy, Game, Magic, Supernatural')
SET IDENTITY_INSERT [Project_MAL].[Genre] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[Studio] ON 

INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (1, N'8bit', N'8bit', N'Suginami')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (2, N'Madhouse', N'Masao Maruyama', N'Honcho')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (3, N'Toei Animation', N'Kenzo Masaoka', N'Oizumi')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (4, N'Studio Pierrot', N'Studio Pierrot', N'Mitaka')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (5, N'TMS Entertainment', N'Sega Sammy Holdings', N'Nakano')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (6, N'Production I.G', N'Mitsuhisa Ishikawa', N'Kokubunji')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (7, N'Gallop', N'Akio Wakana', N'Nerima')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (8, N'Bones', N'Masahiko Minami', N' Suginami')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (9, N'Ufotable', N'Hikaru Kondo', N' Nakano')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (1001, N'Studio Pierrot', N'Studio Pierrot', N'Mitaka')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (1002, N'TMS Entertainment', N'Sega Sammy Holdings', N'Nakano')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (1003, N'Ufotable', N'Hikaru Kondo', N' Nakano')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (2001, N'Studio Pierrot', N'Studio Pierrot', N'Mitaka')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (2002, N'TMS Entertainment', N'Sega Sammy Holdings', N'Nakano')
INSERT [Project_MAL].[Studio] ([studioId], [name], [producer], [location]) VALUES (2003, N'Ufotable', N'Hikaru Kondo', N' Nakano')
SET IDENTITY_INSERT [Project_MAL].[Studio] OFF
GO
SET IDENTITY_INSERT [Project_MAL].[User] ON 

INSERT [Project_MAL].[User] ([userId], [name], [email], [birthday], [location], [joined], [familyName], [userName]) VALUES (1, N'Jarne', N'jarne.bauwens@me.com', CAST(N'1998-08-18' AS Date), N'Antwerpen', CAST(N'2020-12-08' AS Date), N'Bauwens', N'Kiritto')
INSERT [Project_MAL].[User] ([userId], [name], [email], [birthday], [location], [joined], [familyName], [userName]) VALUES (2, N'Dennis Luyten', N'dennis.luyten@hotmail.be', CAST(N'2003-02-27' AS Date), N'Mechelen', CAST(N'2016-03-16' AS Date), N'Luyten', N'Kiiro')
INSERT [Project_MAL].[User] ([userId], [name], [email], [birthday], [location], [joined], [familyName], [userName]) VALUES (3, N'John', N'Appleseed32@gmail.com', CAST(N'2000-07-01' AS Date), N'America', CAST(N'2010-11-28' AS Date), N'Appleseed', N'JohnA')
INSERT [Project_MAL].[User] ([userId], [name], [email], [birthday], [location], [joined], [familyName], [userName]) VALUES (4, N'Caroline', N'CarolineGorgo@hotmail.com', CAST(N'1992-05-12' AS Date), N'Spane', CAST(N'2016-07-28' AS Date), N'Gorgonzela', N'CarolineG')
INSERT [Project_MAL].[User] ([userId], [name], [email], [birthday], [location], [joined], [familyName], [userName]) VALUES (5, N'Johanna', N'Grace.Johanna@me.com.be', CAST(N'2003-02-27' AS Date), N'United Kingdom', CAST(N'2014-09-03' AS Date), N'Grace', N'JohannaG')
SET IDENTITY_INSERT [Project_MAL].[User] OFF
GO
ALTER TABLE [Project_MAL].[Anime]  WITH CHECK ADD  CONSTRAINT [FK_Studio] FOREIGN KEY([studioId])
REFERENCES [Project_MAL].[Studio] ([studioId])
GO
ALTER TABLE [Project_MAL].[Anime] CHECK CONSTRAINT [FK_Studio]
GO
ALTER TABLE [Project_MAL].[AnimeCollection]  WITH CHECK ADD  CONSTRAINT [FK_Anime] FOREIGN KEY([animeId])
REFERENCES [Project_MAL].[Anime] ([animeId])
GO
ALTER TABLE [Project_MAL].[AnimeCollection] CHECK CONSTRAINT [FK_Anime]
GO
ALTER TABLE [Project_MAL].[AnimeCollection]  WITH CHECK ADD  CONSTRAINT [FK_Collection] FOREIGN KEY([collectionId])
REFERENCES [Project_MAL].[Collection] ([collectionId])
GO
ALTER TABLE [Project_MAL].[AnimeCollection] CHECK CONSTRAINT [FK_Collection]
GO
ALTER TABLE [Project_MAL].[AnimeGenre]  WITH CHECK ADD  CONSTRAINT [FK_GenreAnime] FOREIGN KEY([animeId])
REFERENCES [Project_MAL].[Anime] ([animeId])
GO
ALTER TABLE [Project_MAL].[AnimeGenre] CHECK CONSTRAINT [FK_GenreAnime]
GO
ALTER TABLE [Project_MAL].[AnimeGenre]  WITH CHECK ADD  CONSTRAINT [FK_GenreGenre] FOREIGN KEY([genreId])
REFERENCES [Project_MAL].[Genre] ([genreId])
GO
ALTER TABLE [Project_MAL].[AnimeGenre] CHECK CONSTRAINT [FK_GenreGenre]
GO
ALTER TABLE [Project_MAL].[Collection]  WITH CHECK ADD  CONSTRAINT [FK_Gebruiker] FOREIGN KEY([userId])
REFERENCES [Project_MAL].[User] ([userId])
GO
ALTER TABLE [Project_MAL].[Collection] CHECK CONSTRAINT [FK_Gebruiker]
GO
USE [master]
GO
ALTER DATABASE [Project_MAL] SET  READ_WRITE 
GO
