USE [master]
GO
/****** Object:  Database [KOK_DATA]    Script Date: 30/08/2016 23:38:25 ******/
CREATE DATABASE [KOK_DATA]
 GO
ALTER DATABASE [KOK_DATA] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KOK_DATA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KOK_DATA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KOK_DATA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KOK_DATA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KOK_DATA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KOK_DATA] SET ARITHABORT OFF 
GO
ALTER DATABASE [KOK_DATA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KOK_DATA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KOK_DATA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KOK_DATA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KOK_DATA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KOK_DATA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KOK_DATA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KOK_DATA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KOK_DATA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KOK_DATA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KOK_DATA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KOK_DATA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KOK_DATA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KOK_DATA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KOK_DATA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KOK_DATA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KOK_DATA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KOK_DATA] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KOK_DATA] SET  MULTI_USER 
GO
ALTER DATABASE [KOK_DATA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KOK_DATA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KOK_DATA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KOK_DATA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [KOK_DATA] SET DELAYED_DURABILITY = DISABLED 
GO
USE [KOK_DATA]
GO
/****** Object:  Table [dbo].[GROUP_MENU]    Script Date: 30/08/2016 23:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GROUP_MENU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_ID] [int] NULL,
	[MENU_ID] [int] NULL,
	[ACTIVE] [bit] NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_GROUP_MENU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_BANNER]    Script Date: 30/08/2016 23:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_BANNER](
	[BANNER_ID] [int] IDENTITY(1,1) NOT NULL,
	[BANNER_DESC] [nvarchar](400) NULL,
	[BANNER_FILE] [nvarchar](1000) NULL,
	[BANNER_LANGUAGE] [int] NULL,
	[BANNER_ORDER] [int] NULL,
	[BANNER_PUBLISHDATE] [datetime] NULL,
	[BANNER_TYPE] [int] NULL,
	[BANNER_WIDTH] [int] NULL,
	[BANNER_HEIGHT] [int] NULL,
	[BANNER_FIELD1] [nvarchar](400) NULL,
	[BANNER_FIELD2] [nvarchar](400) NULL,
	[BANNER_FIELD3] [nvarchar](400) NULL,
	[BANNER_FIELD4] [nvarchar](400) NULL,
	[BANNER_FIELD5] [nvarchar](400) NULL,
	[ACTIVE] [bit] NOT NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
	[BANNER_NAME] [nvarchar](50) NULL,
 CONSTRAINT [PK_KOK_BANNER] PRIMARY KEY CLUSTERED 
(
	[BANNER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_CATEGORIES]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KOK_CATEGORIES](
	[CAT_ID] [int] IDENTITY(1,1) NOT NULL,
	[CAT_CODE] [nvarchar](50) NULL,
	[CAT_NAME] [nvarchar](400) NULL,
	[CAT_DESC] [nvarchar](4000) NULL,
	[CAT_URL] [nvarchar](4000) NULL,
	[CAT_TARGET] [nvarchar](50) NULL,
	[CAT_STATUS] [int] NULL,
	[CAT_ACCESS] [int] NULL,
	[CAT_POSITION] [int] NULL,
	[CAT_SHOWFOOTER] [int] NULL,
	[CAT_ORDER] [int] NULL,
	[CAT_PARENT_ID] [int] NULL CONSTRAINT [DF_KOK_CATEGORIES_CAT_PARENT_ID]  DEFAULT ((0)),
	[CAT_PARENT_PATH] [varchar](400) NULL,
	[CAT_RANK] [int] NULL,
	[CAT_ROWITEM] [int] NULL,
	[CAT_PAGEITEM] [int] NULL,
	[CAT_SHOWITEM] [int] NULL,
	[CAT_PERIOD] [int] NULL,
	[CAT_PERIOD_ORDER] [int] NULL,
	[CAT_TYPE] [int] NULL,
	[CAT_LANGUAGE] [int] NULL,
	[CAT_COUNT] [int] NULL CONSTRAINT [DF_KOK_CATEGORIES_CAT_COUNT]  DEFAULT ((0)),
	[CAT_SEO_TITLE] [nvarchar](400) NULL,
	[CAT_SEO_DESC] [nvarchar](4000) NULL,
	[CAT_SEO_KEYWORD] [nvarchar](4000) NULL,
	[CAT_SEO_URL] [nvarchar](4000) NULL,
	[CAT_IMAGE1] [nvarchar](400) NULL,
	[CAT_IMAGE2] [nvarchar](400) NULL,
	[CAT_HISTORY] [nvarchar](1000) NULL,
	[CAT_FIELD1] [nvarchar](400) NULL,
	[CAT_FIELD2] [nvarchar](400) NULL,
	[CAT_FIELD3] [nvarchar](400) NULL,
	[CAT_FIELD4] [nvarchar](400) NULL,
	[CAT_FIELD5] [nvarchar](400) NULL,
	[CAT_CODE_EN] [nvarchar](50) NULL,
	[CAT_NAME_EN] [nvarchar](400) NULL,
	[CAT_DESC_EN] [nvarchar](4000) NULL,
	[CAT_SEO_TITLE_EN] [nvarchar](400) NULL,
	[CAT_SEO_DESC_EN] [nvarchar](4000) NULL,
	[CAT_SEO_KEYWORD_EN] [nvarchar](4000) NULL,
	[CAT_SEO_URL_EN] [nvarchar](4000) NULL,
	[CAT_IMAGE3] [nvarchar](400) NULL,
	[ACTIVE] [bit] NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[CAT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KOK_CONFIG]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_CONFIG](
	[CONFIG_ID] [int] IDENTITY(1,1) NOT NULL,
	[CONFIG_TITLE] [nvarchar](1000) NULL,
	[CONFIG_KEYWORD] [nvarchar](4000) NULL,
	[CONFIG_DESCRIPTION] [nvarchar](4000) NULL,
	[CONFIG_HITCOUNTER] [int] NULL,
	[CONFIG_FAVICON] [nvarchar](400) NULL,
	[CONFIG_ORDER] [int] NULL,
	[CONFIG_LANGUAGE] [int] NULL,
	[CONFIG_FIELD1] [nvarchar](400) NULL,
	[CONFIG_FIELD2] [nvarchar](400) NULL,
	[CONFIG_FIELD3] [nvarchar](400) NULL,
	[CONFIG_FIELD4] [nvarchar](400) NULL,
	[CONFIG_FIELD5] [nvarchar](400) NULL,
	[CONFIG_TITLE_EN] [nvarchar](1000) NULL,
	[CONFIG_KEYWORD_EN] [nvarchar](4000) NULL,
	[CONFIG_DESCRIPTION_EN] [nvarchar](4000) NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_CONFIG] PRIMARY KEY CLUSTERED 
(
	[CONFIG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_EMAIL]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_EMAIL](
	[EMAIL_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL_STT] [int] NULL,
	[EMAIL_DESC] [nvarchar](255) NULL,
	[EMAIL_FROM] [nvarchar](255) NULL,
	[EMAIL_TO] [nvarchar](255) NULL,
	[EMAIL_CC] [nvarchar](255) NULL,
	[EMAIL_BCC] [nvarchar](255) NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_EMAIL] PRIMARY KEY CLUSTERED 
(
	[EMAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_GROUP]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_GROUP](
	[GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[GROUP_CODE] [nvarchar](50) NULL,
	[GROUP_NAME] [nvarchar](400) NULL,
	[GROUP_TYPE] [int] NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_GROUPS] PRIMARY KEY CLUSTERED 
(
	[GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_NEWS]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KOK_NEWS](
	[NEWS_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [int] NULL,
	[NEWS_CODE] [nvarchar](100) NULL,
	[NEWS_TITLE] [nvarchar](300) NULL,
	[NEWS_DESC] [nvarchar](500) NULL,
	[NEWS_SEO_KEYWORD] [nvarchar](700) NULL,
	[NEWS_SEO_DESC] [nvarchar](500) NULL,
	[NEWS_SEO_URL] [nvarchar](250) NULL,
	[NEWS_SEO_TITLE] [nvarchar](500) NULL,
	[NEWS_FILEHTML] [nvarchar](200) NULL,
	[NEWS_PUBLISHDATE] [datetime] NULL,
	[NEWS_UPDATE] [datetime] NULL CONSTRAINT [DF_KOK_NEWS_NEWS_UPDATE]  DEFAULT (getdate()),
	[NEWS_URL] [nvarchar](400) NULL,
	[NEWS_TARGET] [nvarchar](50) NULL,
	[NEWS_SHOWTYPE] [int] NULL,
	[NEWS_SHOWINDETAIL] [int] NULL,
	[NEWS_FEEDBACKTYPE] [int] NULL,
	[NEWS_TYPE] [int] NULL,
	[NEWS_LANGUAGE] [int] NULL,
	[NEWS_PRINTTYPE] [int] NULL,
	[NEWS_COUNT] [int] NULL,
	[NEWS_PERIOD] [int] NULL,
	[NEWS_ORDER_PERIOD] [int] NULL,
	[NEWS_ORDER] [int] NULL,
	[NEWS_IMAGE1] [nvarchar](400) NULL,
	[NEWS_IMAGE2] [nvarchar](400) NULL,
	[NEWS_IMAGE3] [nvarchar](400) NULL,
	[NEWS_IMAGE4] [nvarchar](400) NULL,
	[NEWS_IMAGE5] [nvarchar](400) NULL,
	[NEWS_FIELD1] [nvarchar](400) NULL,
	[NEWS_FIELD2] [nvarchar](4000) NULL,
	[NEWS_FIELD3] [nvarchar](400) NULL,
	[NEWS_FIELD4] [nvarchar](400) NULL,
	[NEWS_FIELD5] [nvarchar](400) NULL,
	[NEWS_SENDEMAIL] [int] NULL,
	[NEWS_SENDDATE] [datetime] NULL,
	[NEWS_PRICE1] [money] NULL,
	[NEWS_PRICE2] [money] NULL,
	[NEWS_PRICE3] [money] NULL,
	[UNIT_ID1] [int] NULL,
	[UNIT_ID2] [int] NULL,
	[UNIT_ID3] [int] NULL,
	[NEWS_PACKAGE] [nvarchar](200) NULL,
	[NEWS_KEYWORD_ASCII] [varchar](4000) NULL,
	[NEWS_VIDEO_URL] [nvarchar](250) NULL,
	[ACTIVE] [bit] NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
	[POST_HTML] [nvarchar](max) NULL,
 CONSTRAINT [PK_KOK_NEWS_1] PRIMARY KEY CLUSTERED 
(
	[NEWS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KOK_NEWS_ATT]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_NEWS_ATT](
	[NEWS_ATT_ID] [int] IDENTITY(1,1) NOT NULL,
	[NEWS_ATT_NAME] [nvarchar](100) NULL,
	[NEWS_ATT_FILE] [nvarchar](1000) NULL,
	[NEWS_ATT_URL] [nvarchar](1000) NULL,
	[NEWS_ATT_ORDER] [int] NULL,
	[EXT_ID] [int] NULL,
	[NEWS_ID] [int] NULL,
	[NEWS_ATT_FIELD1] [nvarchar](400) NULL,
	[NEWS_ATT_FIELD2] [nvarchar](400) NULL,
	[NEWS_ATT_FIELD3] [nvarchar](400) NULL,
	[NEWS_ATT_FIELD4] [nvarchar](400) NULL,
	[NEWS_ATT_FIELD5] [nvarchar](400) NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_NEWS_ATT] PRIMARY KEY CLUSTERED 
(
	[NEWS_ATT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_NEWS_CAT]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_NEWS_CAT](
	[NEWS_CAT_ID] [int] IDENTITY(1,1) NOT NULL,
	[NEWS_ID] [int] NULL,
	[CAT_ID] [int] NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_KOK_NEWS_CAT] PRIMARY KEY CLUSTERED 
(
	[NEWS_CAT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_NEWS_IMAGE]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KOK_NEWS_IMAGE](
	[NEWS_IMG_ID] [int] IDENTITY(1,1) NOT NULL,
	[NEWS_IMG_IMAGE1] [nvarchar](400) NULL,
	[NEWS_IMG_IMAGE2] [nvarchar](400) NULL,
	[NEWS_IMG_IMAGE3] [nvarchar](400) NULL,
	[NEWS_IMG_DESC] [nvarchar](400) NULL,
	[NEWS_IMG_ORDER] [int] NULL,
	[NEWS_IMG_SHOWTYPE] [int] NULL,
	[NEWS_ID] [int] NULL,
	[ACTIVE] [bit] NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_SHOPASP_PRO_IMAGE] PRIMARY KEY CLUSTERED 
(
	[NEWS_IMG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KOK_PRODUCTS]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KOK_PRODUCTS](
	[NEWS_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [int] NULL,
	[NEWS_CODE] [nvarchar](100) NULL,
	[NEWS_TITLE] [nvarchar](300) NULL,
	[NEWS_DESC] [nvarchar](500) NULL,
	[NEWS_SEO_KEYWORD] [nvarchar](700) NULL,
	[NEWS_SEO_DESC] [nvarchar](500) NULL,
	[NEWS_SEO_URL] [nvarchar](250) NULL,
	[NEWS_SEO_TITLE] [nvarchar](500) NULL,
	[NEWS_FILEHTML] [nvarchar](200) NULL,
	[NEWS_PUBLISHDATE] [datetime] NULL,
	[NEWS_URL] [nvarchar](400) NULL,
	[NEWS_TARGET] [nvarchar](50) NULL,
	[NEWS_SHOWTYPE] [int] NULL,
	[NEWS_SHOWINDETAIL] [int] NULL,
	[NEWS_FEEDBACKTYPE] [int] NULL,
	[NEWS_TYPE] [int] NULL,
	[NEWS_LANGUAGE] [int] NULL,
	[NEWS_PRINTTYPE] [int] NULL,
	[NEWS_COUNT] [int] NULL,
	[NEWS_PERIOD] [int] NULL,
	[NEWS_ORDER_PERIOD] [int] NULL,
	[NEWS_ORDER] [int] NULL,
	[NEWS_IMAGE1] [nvarchar](400) NULL,
	[NEWS_IMAGE2] [nvarchar](400) NULL,
	[NEWS_IMAGE3] [nvarchar](400) NULL,
	[NEWS_IMAGE4] [nvarchar](400) NULL,
	[NEWS_IMAGE5] [nvarchar](400) NULL,
	[NEWS_FIELD1] [nvarchar](400) NULL,
	[NEWS_FIELD2] [nvarchar](4000) NULL,
	[NEWS_FIELD3] [nvarchar](400) NULL,
	[NEWS_FIELD4] [nvarchar](400) NULL,
	[NEWS_FIELD5] [nvarchar](400) NULL,
	[NEWS_SENDEMAIL] [int] NULL,
	[NEWS_SENDDATE] [datetime] NULL,
	[NEWS_PRICE1] [money] NULL,
	[NEWS_PRICE2] [money] NULL,
	[NEWS_PRICE3] [money] NULL,
	[UNIT_ID1] [int] NULL,
	[UNIT_ID2] [int] NULL,
	[UNIT_ID3] [int] NULL,
	[NEWS_PACKAGE] [nvarchar](200) NULL,
	[NEWS_KEYWORD_ASCII] [varchar](4000) NULL,
	[NEWS_VIDEO_URL] [nvarchar](250) NULL,
	[ACTIVE] [bit] NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
	[POST_HTML] [nvarchar](max) NULL,
	[GIA] [float] NULL,
	[THANH_PHAN] [nvarchar](200) NULL,
	[BAO_QUAN] [nvarchar](200) NULL,
	[NOTE] [nvarchar](200) NULL,
	[ANH] [nvarchar](max) NULL,
 CONSTRAINT [PK_KOK_PRODUCTS_1] PRIMARY KEY CLUSTERED 
(
	[NEWS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MENU]    Script Date: 30/08/2016 23:38:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MENU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MENU_NAME] [nvarchar](250) NULL,
	[MENU_LINK] [nvarchar](550) NULL,
	[MENU_RANK] [int] NULL,
	[MENU_PARENT_ID] [int] NULL,
	[MENU_ORDER] [int] NULL,
	[ACTIVE] [bit] NULL DEFAULT ((1)),
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
	[CREATE_USER] [nvarchar](400) NULL,
	[UPDATE_USER] [nvarchar](400) NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[GROUP_MENU] ON 

INSERT [dbo].[GROUP_MENU] ([ID], [GROUP_ID], [MENU_ID], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (1, 1, 1, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[GROUP_MENU] OFF
SET IDENTITY_INSERT [dbo].[KOK_BANNER] ON 

INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (31, N'Mô tả 1 2', N'~/data/img/banner/12523086_981884768514691_1440957196493318580_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:23:10.633' AS DateTime), CAST(N'2016-03-15 00:23:10.633' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (32, N'File Desc', N'~/data/img/banner/12705615_1705075169768487_3248422140137857125_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2016-03-15 00:25:17.563' AS DateTime), CAST(N'2016-08-13 16:24:05.160' AS DateTime), NULL, NULL, N'Lâm')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (33, N'File Desc', N'~/data/img/banner/11822654_904974619539040_993634616223882810_n.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:27:20.813' AS DateTime), CAST(N'2016-03-15 00:27:20.813' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (34, N'File Desc', N'~/data/img/banner/11822654_904974619539040_993634616223882810_n.png', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:27:25.347' AS DateTime), CAST(N'2016-03-15 00:27:25.347' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (35, N'File Desc', N'~/data/img/banner/12800397_620868284718405_2452667845711822797_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:27:41.690' AS DateTime), CAST(N'2016-03-15 00:27:41.690' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (36, N'File Desc', N'~/data/img/banner/12832585_1793471134207183_7085164468931342084_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:28:19.557' AS DateTime), CAST(N'2016-03-15 00:28:19.557' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (37, N'File Desc', N'~/data/img/banner/12809613_1795251600695803_1465699837206828544_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:29:44.953' AS DateTime), CAST(N'2016-03-15 00:29:44.953' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (38, N'File Desc', N'~/data/img/banner/12806170_1680651598890125_5694368415571381610_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:32:37.397' AS DateTime), CAST(N'2016-03-15 00:32:37.397' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (39, N'File Desc', N'~/data/img/banner/1939853_880515145426945_5906893343730478417_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:35:45.947' AS DateTime), CAST(N'2016-03-15 00:35:45.947' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (40, N'File Desc', N'~/data/img/banner/1939853_880515145426945_5906893343730478417_n.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:37:39.920' AS DateTime), CAST(N'2016-03-15 00:37:39.920' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (41, N'File Desc', N'~/data/img/banner/asdf.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:41:10.353' AS DateTime), CAST(N'2016-03-15 00:41:10.353' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (42, N'File Desc', N'~/data/img/banner/tim-hieu-ve-set11.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-03-15 00:43:12.003' AS DateTime), CAST(N'2016-03-15 00:43:12.003' AS DateTime), NULL, NULL, N'File')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (43, N'Lâm', N'~/data/img/banner/task0206.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-10 16:35:41.210' AS DateTime), CAST(N'2016-08-10 16:35:41.210' AS DateTime), NULL, NULL, N'Lâm')
INSERT [dbo].[KOK_BANNER] ([BANNER_ID], [BANNER_DESC], [BANNER_FILE], [BANNER_LANGUAGE], [BANNER_ORDER], [BANNER_PUBLISHDATE], [BANNER_TYPE], [BANNER_WIDTH], [BANNER_HEIGHT], [BANNER_FIELD1], [BANNER_FIELD2], [BANNER_FIELD3], [BANNER_FIELD4], [BANNER_FIELD5], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [BANNER_NAME]) VALUES (44, N'131233', N'~/data/img/banner/doc-dao-cosplay-cuc-dep-gai-gia-trai-trong-dao-mo-but-ky.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-13 17:18:10.037' AS DateTime), CAST(N'2016-08-13 17:18:10.037' AS DateTime), NULL, NULL, N'Lâm123123')
SET IDENTITY_INSERT [dbo].[KOK_BANNER] OFF
SET IDENTITY_INSERT [dbo].[KOK_CATEGORIES] ON 

INSERT [dbo].[KOK_CATEGORIES] ([CAT_ID], [CAT_CODE], [CAT_NAME], [CAT_DESC], [CAT_URL], [CAT_TARGET], [CAT_STATUS], [CAT_ACCESS], [CAT_POSITION], [CAT_SHOWFOOTER], [CAT_ORDER], [CAT_PARENT_ID], [CAT_PARENT_PATH], [CAT_RANK], [CAT_ROWITEM], [CAT_PAGEITEM], [CAT_SHOWITEM], [CAT_PERIOD], [CAT_PERIOD_ORDER], [CAT_TYPE], [CAT_LANGUAGE], [CAT_COUNT], [CAT_SEO_TITLE], [CAT_SEO_DESC], [CAT_SEO_KEYWORD], [CAT_SEO_URL], [CAT_IMAGE1], [CAT_IMAGE2], [CAT_HISTORY], [CAT_FIELD1], [CAT_FIELD2], [CAT_FIELD3], [CAT_FIELD4], [CAT_FIELD5], [CAT_CODE_EN], [CAT_NAME_EN], [CAT_DESC_EN], [CAT_SEO_TITLE_EN], [CAT_SEO_DESC_EN], [CAT_SEO_KEYWORD_EN], [CAT_SEO_URL_EN], [CAT_IMAGE3], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (1, NULL, N'Home', NULL, N'#', NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-28 18:09:13.507' AS DateTime), CAST(N'2016-08-28 18:09:13.510' AS DateTime), N' ', N' ')
INSERT [dbo].[KOK_CATEGORIES] ([CAT_ID], [CAT_CODE], [CAT_NAME], [CAT_DESC], [CAT_URL], [CAT_TARGET], [CAT_STATUS], [CAT_ACCESS], [CAT_POSITION], [CAT_SHOWFOOTER], [CAT_ORDER], [CAT_PARENT_ID], [CAT_PARENT_PATH], [CAT_RANK], [CAT_ROWITEM], [CAT_PAGEITEM], [CAT_SHOWITEM], [CAT_PERIOD], [CAT_PERIOD_ORDER], [CAT_TYPE], [CAT_LANGUAGE], [CAT_COUNT], [CAT_SEO_TITLE], [CAT_SEO_DESC], [CAT_SEO_KEYWORD], [CAT_SEO_URL], [CAT_IMAGE1], [CAT_IMAGE2], [CAT_HISTORY], [CAT_FIELD1], [CAT_FIELD2], [CAT_FIELD3], [CAT_FIELD4], [CAT_FIELD5], [CAT_CODE_EN], [CAT_NAME_EN], [CAT_DESC_EN], [CAT_SEO_TITLE_EN], [CAT_SEO_DESC_EN], [CAT_SEO_KEYWORD_EN], [CAT_SEO_URL_EN], [CAT_IMAGE3], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (2, NULL, N'Banhtrang1', NULL, N'#', NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-28 18:09:38.253' AS DateTime), CAST(N'2016-08-28 18:09:38.253' AS DateTime), N' ', N' ')
INSERT [dbo].[KOK_CATEGORIES] ([CAT_ID], [CAT_CODE], [CAT_NAME], [CAT_DESC], [CAT_URL], [CAT_TARGET], [CAT_STATUS], [CAT_ACCESS], [CAT_POSITION], [CAT_SHOWFOOTER], [CAT_ORDER], [CAT_PARENT_ID], [CAT_PARENT_PATH], [CAT_RANK], [CAT_ROWITEM], [CAT_PAGEITEM], [CAT_SHOWITEM], [CAT_PERIOD], [CAT_PERIOD_ORDER], [CAT_TYPE], [CAT_LANGUAGE], [CAT_COUNT], [CAT_SEO_TITLE], [CAT_SEO_DESC], [CAT_SEO_KEYWORD], [CAT_SEO_URL], [CAT_IMAGE1], [CAT_IMAGE2], [CAT_HISTORY], [CAT_FIELD1], [CAT_FIELD2], [CAT_FIELD3], [CAT_FIELD4], [CAT_FIELD5], [CAT_CODE_EN], [CAT_NAME_EN], [CAT_DESC_EN], [CAT_SEO_TITLE_EN], [CAT_SEO_DESC_EN], [CAT_SEO_KEYWORD_EN], [CAT_SEO_URL_EN], [CAT_IMAGE3], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (3, NULL, N'about', NULL, N'#', NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-28 18:09:54.213' AS DateTime), CAST(N'2016-08-28 18:09:54.213' AS DateTime), N' ', N' ')
INSERT [dbo].[KOK_CATEGORIES] ([CAT_ID], [CAT_CODE], [CAT_NAME], [CAT_DESC], [CAT_URL], [CAT_TARGET], [CAT_STATUS], [CAT_ACCESS], [CAT_POSITION], [CAT_SHOWFOOTER], [CAT_ORDER], [CAT_PARENT_ID], [CAT_PARENT_PATH], [CAT_RANK], [CAT_ROWITEM], [CAT_PAGEITEM], [CAT_SHOWITEM], [CAT_PERIOD], [CAT_PERIOD_ORDER], [CAT_TYPE], [CAT_LANGUAGE], [CAT_COUNT], [CAT_SEO_TITLE], [CAT_SEO_DESC], [CAT_SEO_KEYWORD], [CAT_SEO_URL], [CAT_IMAGE1], [CAT_IMAGE2], [CAT_HISTORY], [CAT_FIELD1], [CAT_FIELD2], [CAT_FIELD3], [CAT_FIELD4], [CAT_FIELD5], [CAT_CODE_EN], [CAT_NAME_EN], [CAT_DESC_EN], [CAT_SEO_TITLE_EN], [CAT_SEO_DESC_EN], [CAT_SEO_KEYWORD_EN], [CAT_SEO_URL_EN], [CAT_IMAGE3], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (4, NULL, N'Liên hệ', NULL, N'#', NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-28 18:10:12.460' AS DateTime), CAST(N'2016-08-28 18:10:12.460' AS DateTime), N' ', N' ')
INSERT [dbo].[KOK_CATEGORIES] ([CAT_ID], [CAT_CODE], [CAT_NAME], [CAT_DESC], [CAT_URL], [CAT_TARGET], [CAT_STATUS], [CAT_ACCESS], [CAT_POSITION], [CAT_SHOWFOOTER], [CAT_ORDER], [CAT_PARENT_ID], [CAT_PARENT_PATH], [CAT_RANK], [CAT_ROWITEM], [CAT_PAGEITEM], [CAT_SHOWITEM], [CAT_PERIOD], [CAT_PERIOD_ORDER], [CAT_TYPE], [CAT_LANGUAGE], [CAT_COUNT], [CAT_SEO_TITLE], [CAT_SEO_DESC], [CAT_SEO_KEYWORD], [CAT_SEO_URL], [CAT_IMAGE1], [CAT_IMAGE2], [CAT_HISTORY], [CAT_FIELD1], [CAT_FIELD2], [CAT_FIELD3], [CAT_FIELD4], [CAT_FIELD5], [CAT_CODE_EN], [CAT_NAME_EN], [CAT_DESC_EN], [CAT_SEO_TITLE_EN], [CAT_SEO_DESC_EN], [CAT_SEO_KEYWORD_EN], [CAT_SEO_URL_EN], [CAT_IMAGE3], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (5, NULL, N'Bánh tráng 1.1', NULL, N'#', NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2016-08-28 18:10:33.643' AS DateTime), CAST(N'2016-08-28 18:10:33.643' AS DateTime), N' ', N' ')
SET IDENTITY_INSERT [dbo].[KOK_CATEGORIES] OFF
SET IDENTITY_INSERT [dbo].[KOK_NEWS] ON 

INSERT [dbo].[KOK_NEWS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_UPDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML]) VALUES (2, NULL, NULL, N'Bài viết 1 asdasdadasdasdasd', N'Mô tả 1', N'Keyword', N'Seo desc', N'SEO URL', N'SEO Title', NULL, NULL, NULL, N'bai-viet-1-asdasdadasdasdasd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p>Một chuyến bay của h&atilde;ng h&agrave;ng kh&ocirc;ng Southwest Airlines, Mỹ, buộc phải cho hạ c&aacute;nh khẩn cấp sau khi động cơ rơi một phần khi m&aacute;y bay với 99 người đang bay giữa kh&ocirc;ng trung.</p>

<p><em>AP</em>&nbsp;dẫn lời người đại diện h&atilde;ng h&agrave;ng kh&ocirc;ng Southwest Airlines cho biết, chuyến bay mang số hiệu 3472 từ New Orleans, bang Lousiana đến Orlando, bang Florida đ&atilde; phải hạ c&aacute;nh xuống Pensacola ở Florida sau khi phi c&ocirc;ng ph&aacute;t hiện một trong hai động cơ ch&iacute;nh của m&aacute;y bay c&oacute; vấn đề.</p>

<p>Sự cố xảy ra v&agrave;o khoảng 9h40 s&aacute;ng 27/8 khi m&aacute;y bay ở độ cao hơn 3.000 m. M&aacute;y bay bị rung lắc dữ dội v&agrave; mặt nạ oxy được bung ra, v&agrave;i h&agrave;nh kh&aacute;ch la h&eacute;t hoảng loạn v&agrave; kh&oacute;c th&eacute;t. Sau khi giữ được m&aacute;y bay ổn định, một vi&ecirc;n phi c&ocirc;ng đ&atilde; th&ocirc;ng b&aacute;o một phần động cơ đ&atilde; bị mất.</p>

<p>To&agrave;n bộ 99 h&agrave;nh kh&aacute;ch v&agrave; 5 người trong phi h&agrave;nh đo&agrave;n đều an to&agrave;n, kh&ocirc;ng c&oacute; ai bị thương.</p>
')
INSERT [dbo].[KOK_NEWS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_UPDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML]) VALUES (1002, NULL, NULL, N'Bánh tráng cuốn', N'Bánh tráng cuốn abc', N'banhtrang', N'banh-trang-cuon-abc', N'banh-trang-cuon', N'banh-trang-cuon', NULL, NULL, NULL, N'banh-trang-cuon', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Quy c&aacute;ch</strong>: hộp&nbsp;(10 cuốn)</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" /></strong>&nbsp;&nbsp;<strong>Gi&aacute; b&aacute;n</strong>: 20.000 đ/ phần</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Th&agrave;nh phần</strong>:&nbsp;B&aacute;nh tr&aacute;ng, trứng c&uacute;t, h&agrave;nh phi, rau r&acirc;m, nước sốt me, bơ v&agrave; đặc biệt l&agrave; kh&ocirc; b&ograve; T&acirc;y Ninh</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Bảo quản</strong>&nbsp;: Ăn trong ng&agrave;y</p>

<p>&nbsp; &nbsp;</p>

<p>&nbsp;<img alt="" src="http://icons.iconarchive.com/icons/hopstarter/sleek-xp-basic/32/Notes-icon.png" />&nbsp;<em><strong>Kh&aacute;ch h&agrave;ng ch&uacute; &yacute;</strong>: Một số nơi b&aacute;n b&aacute;nh cuốn, b&aacute;nh trộn hay d&ugrave;ng nguy&ecirc;n liệu &quot;kh&ocirc; b&ograve; đen&quot;, &quot;kh&ocirc; b&ograve; đen&quot; thực chất l&agrave; phổi heo thối được tẩm gia vị c&oacute; m&ugrave;i thịt b&ograve;, nếu ăn rất dễ mắc c&aacute;c bệnh về đường ti&ecirc;u h&oacute;a . V&igrave; an to&agrave;n sức khỏe h&atilde;y chia sẻ th&ocirc;ng tin n&agrave;y cho gia đ&igrave;nh v&agrave; bạn b&egrave; được biết. Hiện c&ograve;n một nguy&ecirc;n liệu nữa d&ugrave;ng trộn b&aacute;nh tr&aacute;ng cực thơm v&agrave; mềm l&agrave; &quot;Nước sốt b&ograve;&quot;, TNF chưa x&aacute;c định được &quot;nước sốt b&ograve;&quot; n&agrave;y l&agrave;m từ chất g&igrave; nhưng cũng khuyến c&aacute;o c&aacute;c bạn n&ecirc;n hạn chế sử dụng nguy&ecirc;n liệu n&agrave;y.</em></p>

<p>&nbsp;&nbsp;<img alt="http://icons.iconarchive.com/icons/icons8/ios7/32/Ecommerce-Delivery-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Ecommerce-Delivery-icon.png" style="height:32px; width:32px" />&nbsp;&nbsp;Giao h&agrave;ng v&agrave; thanh to&aacute;n</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;- KV1: Quận 1, 2, 3, 4, 5, 6, 10,11, T&acirc;n B&igrave;nh, T&acirc;n Ph&uacute;, B&igrave;nh Thạnh, Ph&uacute; Nhuận, G&ograve; Vấp&nbsp;mua bao nhi&ecirc;u cũng giao h&agrave;ng, nếu đơn h&agrave;ng từ 70.000 đ sẽ giao miễn ph&iacute; c&ograve;n dưới 70.000 đ sẽ t&iacute;nh ph&iacute; giao h&agrave;ng l&agrave; 15.000 đ</p>

<p>&nbsp;</p>

<p>&nbsp; &nbsp; &nbsp; - KV2:&nbsp;Quận 7,8, 9,12, B&igrave;nh T&acirc;n, B&igrave;nh Ch&aacute;nh, Thủ Đức , H&oacute;c M&ocirc;n đơn h&agrave;ng mua tối thiểu l&agrave; 70.000 đ, ph&iacute; giao h&agrave;ng của KV2 l&agrave; 15.000 đ &nbsp;</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp; Tất cả c&aacute;c đơn h&agrave;ng sau khi oder sẽ được giao h&agrave;ng nhanh v&agrave; ngay cho kh&aacute;ch h&agrave;ng trong giờ h&agrave;nh ch&iacute;nh.</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Đơn h&agrave;ng đặt trước 17 giờ sẽ được giao trong ng&agrave;y, đơn h&agrave;ng đặt sau 17 giờ sẽ chuyển qua ng&agrave;y h&ocirc;m sau</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Hoặc c&oacute; thể&nbsp;<strong>mua trực tiếp tại&nbsp;</strong>29 Bắc Hải, Quận 10&nbsp;( địa chỉ n&agrave;y b&ecirc;n cạnh c&ocirc;ng vi&ecirc;n L&ecirc; Thị Ri&ecirc;ng )</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/wwalczyszyn/iwindows/32/Pictures-Library-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Pictures-Library-icon.png" style="float:left; height:32px; width:32px" />&nbsp;&nbsp;Ảnh chụp B&aacute;nh tr&aacute;ng cuốn&nbsp;thực tế của TNF</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><em><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/banhtrang2015/cuon.jpg" style="height:500px; width:800px" /></em></p>

<p>&nbsp;</p>

<p>Nguy&ecirc;n liệu của 1 c&aacute;i b&aacute;nh cuốn&nbsp;<em>(ảnh c&oacute; bản quyền)</em></p>

<p>&nbsp;</p>

<p><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/banhtrang2015/intnf.jpg" style="height:700px; width:700px" /></p>

<p><em>H&igrave;nh ảnh v&agrave; nội dung đ&atilde; đăng k&yacute; bản quyền, cấm sao ch&eacute;p dưới mọi h&igrave;nh thức&nbsp;</em></p>
')
INSERT [dbo].[KOK_NEWS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_UPDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML]) VALUES (1003, NULL, NULL, N'Bánh tráng chà bông', N'Bánh tráng chà bông', NULL, N'banh-trang-cha-bong', N'banh-trang-cha-bong', N'banh-trang-cha-bong', NULL, NULL, NULL, N'banh-trang-cha-bong', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Quy c&aacute;ch</strong>: 1 x&acirc;u 12 b&aacute;nh</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" /></strong>&nbsp;&nbsp;<strong>Gi&aacute; b&aacute;n</strong>: 20.000 đ/ x&acirc;u</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Chất bảo quản</strong>: ho&agrave;n to&agrave;n kh&ocirc;ng c&oacute; chất bảo quản</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Th&agrave;nh phần</strong>: B&aacute;nh tr&aacute;ng, ch&agrave; b&ocirc;ng, muối, đường, h&agrave;nh phi</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Bảo quản</strong>&nbsp;: 20 ng&agrave;y</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; C&aacute;ch d&ugrave;ng</strong>: B&aacute;nh tr&aacute;ng ch&agrave; b&ocirc;ng đ&atilde; tẩm gia vị sẳn, ăn ngay kh&ocirc;ng cần chế biến th&ecirc;m</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Ch&uacute; &yacute;</strong>:</p>

<p>&nbsp;</p>

<p>&nbsp;&nbsp;<img alt="http://icons.iconarchive.com/icons/icons8/ios7/32/Ecommerce-Delivery-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Ecommerce-Delivery-icon.png" style="height:32px; width:32px" />&nbsp; Giao h&agrave;ng v&agrave; thanh to&aacute;n</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;- KV1: Quận 1, 2, 3, 4, 5, 6, 10,11, T&acirc;n B&igrave;nh, T&acirc;n Ph&uacute;, B&igrave;nh Thạnh, Ph&uacute; Nhuận, G&ograve; Vấp&nbsp;mua bao nhi&ecirc;u cũng giao h&agrave;ng, nếu đơn h&agrave;ng từ 70.000 đ sẽ giao miễn ph&iacute; c&ograve;n dưới 70.000 đ sẽ t&iacute;nh ph&iacute; giao h&agrave;ng l&agrave; 15.000 đ</p>

<p>&nbsp;</p>

<p>&nbsp; &nbsp; &nbsp; - KV2:&nbsp;Quận 7,8, 9,12, B&igrave;nh T&acirc;n, B&igrave;nh Ch&aacute;nh, Thủ Đức , H&oacute;c M&ocirc;n đơn h&agrave;ng mua tối thiểu l&agrave; 70.000 đ, ph&iacute; giao h&agrave;ng của KV2 l&agrave; 15.000 đ &nbsp;</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp; Tất cả c&aacute;c đơn h&agrave;ng sau khi oder sẽ được giao h&agrave;ng nhanh v&agrave; ngay cho kh&aacute;ch h&agrave;ng trong giờ h&agrave;nh ch&iacute;nh.</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Đơn h&agrave;ng đặt trước 17 giờ sẽ được giao trong ng&agrave;y, đơn h&agrave;ng đặt sau 17 giờ sẽ chuyển qua ng&agrave;y h&ocirc;m sau</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Hoặc c&oacute; thể&nbsp;<strong>mua trực tiếp tại&nbsp;</strong>29 Bắc Hải, Quận 10&nbsp;( địa chỉ n&agrave;y b&ecirc;n cạnh c&ocirc;ng vi&ecirc;n L&ecirc; Thị Ri&ecirc;ng )</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/wwalczyszyn/iwindows/32/Pictures-Library-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Pictures-Library-icon.png" style="float:left; height:32px; width:32px" />&nbsp;&nbsp;Ảnh chụp b&aacute;nh ch&agrave; b&ocirc;ng thực tế&nbsp;</p>

<p>&nbsp;</p>

<p><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/muoichabong.jpg" style="height:697px; width:600px" /></p>

<p>&nbsp;</p>

<p><em>H&igrave;nh ảnh v&agrave; nội dung đ&atilde; đăng k&yacute; bản quyền, cấm sao ch&eacute;p dưới mọi h&igrave;nh thức&nbsp;</em></p>
')
INSERT [dbo].[KOK_NEWS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_UPDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML]) VALUES (1004, NULL, NULL, N'Bánh tráng chà bông', N'Bánh tráng chà bông', NULL, N'banh-trang-cha-bong', N'banh-trang-cha-bong', N'banh-trang-cha-bong', NULL, NULL, NULL, N'banh-trang-cha-bong', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Quy c&aacute;ch</strong>: 1 x&acirc;u 12 b&aacute;nh</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" /></strong>&nbsp;&nbsp;<strong>Gi&aacute; b&aacute;n</strong>: 20.000 đ/ x&acirc;u</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Chất bảo quản</strong>: ho&agrave;n to&agrave;n kh&ocirc;ng c&oacute; chất bảo quản</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Th&agrave;nh phần</strong>: B&aacute;nh tr&aacute;ng, ch&agrave; b&ocirc;ng, muối, đường, h&agrave;nh phi</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Bảo quản</strong>&nbsp;: 20 ng&agrave;y</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; C&aacute;ch d&ugrave;ng</strong>: B&aacute;nh tr&aacute;ng ch&agrave; b&ocirc;ng đ&atilde; tẩm gia vị sẳn, ăn ngay kh&ocirc;ng cần chế biến th&ecirc;m</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Ch&uacute; &yacute;</strong>:</p>

<p>&nbsp;</p>

<p>&nbsp;&nbsp;<img alt="http://icons.iconarchive.com/icons/icons8/ios7/32/Ecommerce-Delivery-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Ecommerce-Delivery-icon.png" style="height:32px; width:32px" />&nbsp; Giao h&agrave;ng v&agrave; thanh to&aacute;n</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;- KV1: Quận 1, 2, 3, 4, 5, 6, 10,11, T&acirc;n B&igrave;nh, T&acirc;n Ph&uacute;, B&igrave;nh Thạnh, Ph&uacute; Nhuận, G&ograve; Vấp&nbsp;mua bao nhi&ecirc;u cũng giao h&agrave;ng, nếu đơn h&agrave;ng từ 70.000 đ sẽ giao miễn ph&iacute; c&ograve;n dưới 70.000 đ sẽ t&iacute;nh ph&iacute; giao h&agrave;ng l&agrave; 15.000 đ</p>

<p>&nbsp;</p>

<p>&nbsp; &nbsp; &nbsp; - KV2:&nbsp;Quận 7,8, 9,12, B&igrave;nh T&acirc;n, B&igrave;nh Ch&aacute;nh, Thủ Đức , H&oacute;c M&ocirc;n đơn h&agrave;ng mua tối thiểu l&agrave; 70.000 đ, ph&iacute; giao h&agrave;ng của KV2 l&agrave; 15.000 đ &nbsp;</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp; Tất cả c&aacute;c đơn h&agrave;ng sau khi oder sẽ được giao h&agrave;ng nhanh v&agrave; ngay cho kh&aacute;ch h&agrave;ng trong giờ h&agrave;nh ch&iacute;nh.</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Đơn h&agrave;ng đặt trước 17 giờ sẽ được giao trong ng&agrave;y, đơn h&agrave;ng đặt sau 17 giờ sẽ chuyển qua ng&agrave;y h&ocirc;m sau</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Hoặc c&oacute; thể&nbsp;<strong>mua trực tiếp tại&nbsp;</strong>29 Bắc Hải, Quận 10&nbsp;( địa chỉ n&agrave;y b&ecirc;n cạnh c&ocirc;ng vi&ecirc;n L&ecirc; Thị Ri&ecirc;ng )</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/wwalczyszyn/iwindows/32/Pictures-Library-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Pictures-Library-icon.png" style="float:left; height:32px; width:32px" />&nbsp;&nbsp;Ảnh chụp b&aacute;nh ch&agrave; b&ocirc;ng thực tế&nbsp;</p>

<p>&nbsp;</p>

<p><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/muoichabong.jpg" style="height:697px; width:600px" /></p>

<p>&nbsp;</p>

<p><em>H&igrave;nh ảnh v&agrave; nội dung đ&atilde; đăng k&yacute; bản quyền, cấm sao ch&eacute;p dưới mọi h&igrave;nh thức&nbsp;</em></p>
')
INSERT [dbo].[KOK_NEWS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_UPDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML]) VALUES (1005, NULL, NULL, N'Bánh tráng chà bông', N'Bánh tráng chà bông', NULL, N'banh-trang-cha-bong', N'banh-trang-cha-bong', N'banh-trang-cha-bong', NULL, NULL, NULL, N'banh-trang-cha-bong', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Quy c&aacute;ch</strong>: 1 x&acirc;u 12 b&aacute;nh</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" /></strong>&nbsp;&nbsp;<strong>Gi&aacute; b&aacute;n</strong>: 20.000 đ/ x&acirc;u</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Chất bảo quản</strong>: ho&agrave;n to&agrave;n kh&ocirc;ng c&oacute; chất bảo quản</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Th&agrave;nh phần</strong>: B&aacute;nh tr&aacute;ng, ch&agrave; b&ocirc;ng, muối, đường, h&agrave;nh phi</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Bảo quản</strong>&nbsp;: 20 ng&agrave;y</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; C&aacute;ch d&ugrave;ng</strong>: B&aacute;nh tr&aacute;ng ch&agrave; b&ocirc;ng đ&atilde; tẩm gia vị sẳn, ăn ngay kh&ocirc;ng cần chế biến th&ecirc;m</p>

<p>&nbsp;</p>

<p><strong><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Arrow-next-4-icon.png" style="height:16px; width:16px" />&nbsp; Ch&uacute; &yacute;</strong>:</p>

<p>&nbsp;</p>

<p>&nbsp;&nbsp;<img alt="http://icons.iconarchive.com/icons/icons8/ios7/32/Ecommerce-Delivery-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Ecommerce-Delivery-icon.png" style="height:32px; width:32px" />&nbsp; Giao h&agrave;ng v&agrave; thanh to&aacute;n</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;- KV1: Quận 1, 2, 3, 4, 5, 6, 10,11, T&acirc;n B&igrave;nh, T&acirc;n Ph&uacute;, B&igrave;nh Thạnh, Ph&uacute; Nhuận, G&ograve; Vấp&nbsp;mua bao nhi&ecirc;u cũng giao h&agrave;ng, nếu đơn h&agrave;ng từ 70.000 đ sẽ giao miễn ph&iacute; c&ograve;n dưới 70.000 đ sẽ t&iacute;nh ph&iacute; giao h&agrave;ng l&agrave; 15.000 đ</p>

<p>&nbsp;</p>

<p>&nbsp; &nbsp; &nbsp; - KV2:&nbsp;Quận 7,8, 9,12, B&igrave;nh T&acirc;n, B&igrave;nh Ch&aacute;nh, Thủ Đức , H&oacute;c M&ocirc;n đơn h&agrave;ng mua tối thiểu l&agrave; 70.000 đ, ph&iacute; giao h&agrave;ng của KV2 l&agrave; 15.000 đ &nbsp;</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp; Tất cả c&aacute;c đơn h&agrave;ng sau khi oder sẽ được giao h&agrave;ng nhanh v&agrave; ngay cho kh&aacute;ch h&agrave;ng trong giờ h&agrave;nh ch&iacute;nh.</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Đơn h&agrave;ng đặt trước 17 giờ sẽ được giao trong ng&agrave;y, đơn h&agrave;ng đặt sau 17 giờ sẽ chuyển qua ng&agrave;y h&ocirc;m sau</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/graphicloads/100-flat-2/16/arrow-upload-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/arrow-upload-icon.png" style="height:16px; width:16px" />&nbsp;&nbsp;Hoặc c&oacute; thể&nbsp;<strong>mua trực tiếp tại&nbsp;</strong>29 Bắc Hải, Quận 10&nbsp;( địa chỉ n&agrave;y b&ecirc;n cạnh c&ocirc;ng vi&ecirc;n L&ecirc; Thị Ri&ecirc;ng )</p>

<p>&nbsp;</p>

<p><img alt="http://icons.iconarchive.com/icons/wwalczyszyn/iwindows/32/Pictures-Library-icon.png" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/Pictures-Library-icon.png" style="float:left; height:32px; width:32px" />&nbsp;&nbsp;Ảnh chụp b&aacute;nh ch&agrave; b&ocirc;ng thực tế&nbsp;</p>

<p>&nbsp;</p>

<p><img alt="" src="http://24gio.vn/userfile/f2d695af/uploads/Banhtrang/muoichabong.jpg" style="height:697px; width:600px" /></p>

<p>&nbsp;</p>

<p><em>H&igrave;nh ảnh v&agrave; nội dung đ&atilde; đăng k&yacute; bản quyền, cấm sao ch&eacute;p dưới mọi h&igrave;nh thức&nbsp;</em></p>
')
SET IDENTITY_INSERT [dbo].[KOK_NEWS] OFF
SET IDENTITY_INSERT [dbo].[KOK_PRODUCTS] ON 

INSERT [dbo].[KOK_PRODUCTS] ([NEWS_ID], [USER_ID], [NEWS_CODE], [NEWS_TITLE], [NEWS_DESC], [NEWS_SEO_KEYWORD], [NEWS_SEO_DESC], [NEWS_SEO_URL], [NEWS_SEO_TITLE], [NEWS_FILEHTML], [NEWS_PUBLISHDATE], [NEWS_URL], [NEWS_TARGET], [NEWS_SHOWTYPE], [NEWS_SHOWINDETAIL], [NEWS_FEEDBACKTYPE], [NEWS_TYPE], [NEWS_LANGUAGE], [NEWS_PRINTTYPE], [NEWS_COUNT], [NEWS_PERIOD], [NEWS_ORDER_PERIOD], [NEWS_ORDER], [NEWS_IMAGE1], [NEWS_IMAGE2], [NEWS_IMAGE3], [NEWS_IMAGE4], [NEWS_IMAGE5], [NEWS_FIELD1], [NEWS_FIELD2], [NEWS_FIELD3], [NEWS_FIELD4], [NEWS_FIELD5], [NEWS_SENDEMAIL], [NEWS_SENDDATE], [NEWS_PRICE1], [NEWS_PRICE2], [NEWS_PRICE3], [UNIT_ID1], [UNIT_ID2], [UNIT_ID3], [NEWS_PACKAGE], [NEWS_KEYWORD_ASCII], [NEWS_VIDEO_URL], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER], [POST_HTML], [GIA], [THANH_PHAN], [BAO_QUAN], [NOTE], [ANH]) VALUES (1, NULL, NULL, N'Sản phẩm 1', N'sản phẩm chức năng', NULL, N'san-pham-chuc-nang', N'san-pham-1', N'san-pham-1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'<p>Cơ hội để bạn c&oacute; thể sở hữu c&aacute;c trang phục Đa Sắc chỉ bằng IP.</p>

<h4><img alt="banner da sac 600x300" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0829-cp/banner_da_sac_600x300.jpg" style="height:300px; width:600px" /></h4>

<p>Để mua c&aacute;c trang phục Đa Sắc, c&aacute;c bạn l&agrave;m theo những bước sau:</p>

<p>Đầu ti&ecirc;n, c&aacute;c bạn v&agrave;o mục Trang Phục trong Cửa h&agrave;ng:</p>

<h4><img alt="1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/1.png" style="height:320px; width:600px" /></h4>

<p>Sau đ&oacute; ở phần Trạng Th&aacute;i, c&aacute;c bạn chọn mục Đang Hạ Gi&aacute; để mua c&aacute;c trang phục Đa Sắc:</p>

<h4><img alt="2" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/2.png" style="height:336px; width:600px" /></h4>

<p>Từ ng&agrave;y 29/8 đến hết ng&agrave;y 4/9, những trang phục Đa Sắc dưới đ&acirc;y sẽ c&oacute; thể mua được bằng<strong>2000 IP&nbsp;</strong>hoặc&nbsp;<strong>20 RP</strong>:</p>

<h2>C&aacute;c m&agrave;u đa sắc của tướng</h2>

<p>Rất đơn giản, dễ hiểu. Để c&oacute; thể sở hữu những trang phục đa sắc n&agrave;y, điều đầu ti&ecirc;n bạn cần l&agrave;m đ&oacute; l&agrave; sở hữu tướng!</p>

<p>&nbsp;</p>

<p><strong>Bard Nở Hoa</strong></p>

<h4><img alt="bard 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/bard_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Bard Nở Hoa C&uacute;c V&agrave;ng</li>
	<li>Bard Nở Hoa Thường Xu&acirc;n</li>
</ul>

<p><strong>Blitzcrank Sắt Th&eacute;p</strong></p>

<h4><img alt="blitz 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/blitz_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Blitzcrank Sắt Th&eacute;p M&agrave;u Xanh Thẫm</li>
	<li>Blitzcrank Sắt Th&eacute;p M&agrave;u Trắng Bạc</li>
</ul>

<p><strong>Cassiopeia Lời Nguyền</strong></p>

<h4><img alt="cass3way 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/cass3way_1.jpg" style="height:195px; width:600px" /></h4>

<ul>
	<li>Cassiopeia Lời Nguyền Ban Ng&agrave;y</li>
	<li>Cassiopeia Lời Nguyền Ho&agrave;ng H&ocirc;n</li>
</ul>

<p><strong>Caitlyn Nổi Loạn</strong></p>

<h4><img alt="cait" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/cait.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Caitlyn Nổi Loạn Hồng</li>
	<li>Caitlyn Nổi Loạn Xanh L&aacute;</li>
	<li>Caitlyn Nổi Loạn Xanh Lam</li>
</ul>

<p><strong>Darius L&ograve; R&egrave;n</strong></p>

<h4><img alt="darius 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/darius_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Darius L&ograve; R&egrave;n Đồng Đỏ</li>
	<li>Darius L&ograve; R&egrave;n Sắt Đen</li>
</ul>

<p><strong>Fizz B&ugrave;ng Ch&aacute;y</strong></p>

<h4><img alt="fizz 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/fizz_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Fizz B&ugrave;ng Ch&aacute;y M&agrave;u Đen</li>
	<li>Fizz B&ugrave;ng Ch&aacute;y M&agrave;u Đỏ</li>
</ul>

<p><strong>Garen Qu&yacute; Tộc</strong></p>

<h4><img alt="garen 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/garen_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Garen Qu&yacute; Tộc M&agrave;u Mận</li>
	<li>Garen Qu&yacute; Tộc M&agrave;u Ng&agrave;</li>
</ul>

<p><strong>Lucian Rực Rỡ</strong></p>

<h4><img alt="lucian 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/lucian_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Lucian Rực Rỡ M&agrave;u Đỏ</li>
	<li>Lucian Rực Rỡ M&agrave;u Xanh Dương</li>
</ul>

<p><strong>Morgana &Aacute;m Ảnh</strong></p>

<h4><img alt="morg" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/morg.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Morgana &Aacute;m Ảnh Độc Tố</li>
	<li>Morgana &Aacute;m Ảnh Nhợt Nhạt</li>
	<li>Morgana &Aacute;m Ảnh Gỗ Mun</li>
</ul>

<p><strong>Zac Kẹo Dẻo</strong></p>

<h4><img alt="zac" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/zac.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Zac Kẹo Dẻo Da Cam</li>
	<li>Zac Kẹo Dẻo Hồng Nhạt</li>
	<li>Zac Kẹo Dẻo Mật Ong</li>
</ul>

<h2>C&aacute;c m&agrave;u đa sắc của trang phục</h2>

<p>Tương tự như ph&iacute;a tr&ecirc;n, chỉ kh&aacute;c ở chỗ, bạn cần phải sở hữu trang phục tương ứng.</p>

<p>&nbsp;</p>

<p><strong>Lee Tiểu Long Đấu Tay Đ&ocirc;i</strong></p>

<h4><img alt="lee 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/lee_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Lee Tiểu Long Đấu Tay Đ&ocirc;i M&agrave;u Xanh Dương</li>
	<li>Lee Tiểu Long Đấu Tay Đ&ocirc;i M&agrave;u V&agrave;ng</li>
</ul>

<p><strong>Vayne Đồ Long Hỗn Mang</strong></p>

<h4><img alt="vayne3way 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/vayne3way_1.jpg" style="height:195px; width:600px" /></h4>

<ul>
	<li>Vayne Đồ Long Hỗn Mang Đỏ</li>
	<li>Vayne Đồ Long Hỗn Mang Bạc</li>
</ul>

<p><strong>Nasus Hiệp Sĩ Đen Tai Ương</strong></p>

<h4><img alt="nasus 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/nasus_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Nasus Hiệp Sĩ Đen Tai Ương Hỏa Thi&ecirc;u</li>
	<li>Nasus Hiệp Sĩ Đen Tai Ương Độc Kh&iacute;</li>
</ul>

<p><strong>Karthus Thần Chết Tai Ương</strong></p>

<h4><img alt="karthus 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/karthus_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Karthus Thần Chết Tai Ương Độc Kh&iacute;</li>
	<li>Karthus Thần Chết Tai Ương Băng Phong</li>
</ul>

<p><strong>Master Yi Thợ Săn Chiến Đấu</strong></p>

<h4><img alt="yi 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/yi_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Master Yi Thợ Săn Chiến Đấu V&agrave;ng Kim</li>
	<li>Master Yi Thợ Săn Chiến Đấu Đỏ Son</li>
</ul>

<p><strong>Nami Tiểu Long Ngư Nguy&ecirc;n Tố</strong></p>

<h4><img alt="nami 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/nami_1.jpg" style="height:195px; width:600px" /></h4>

<ul>
	<li>Nami Tiểu Long Ngư Nguy&ecirc;n Tố Sương Kh&oacute;i</li>
	<li>Nami Tiểu Long Ngư Nguy&ecirc;n Tố Chạng Vạng</li>
</ul>

<p><strong>Leona Tiệc Bể Bơi B&igrave;nh Minh</strong></p>

<h4><img alt="leona 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/leona_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Leona Tiệc Bể Bơi B&igrave;nh Minh M&agrave;u Hồng</li>
	<li>Leona Tiệc Bể Bơi B&igrave;nh Minh M&agrave;u Chanh</li>
</ul>

<p><strong>Jax Phục Hận C&aacute;t Bụi</strong></p>

<h4><img alt="jax" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/jax.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Jax Phục Hận C&aacute;t Bụi M&agrave;u Kem</li>
	<li>Jax Phục Hận C&aacute;t Bụi M&agrave;u Gạch</li>
	<li>Jax Phục Hận C&aacute;t Bụi Hổ Ph&aacute;ch</li>
</ul>

<p><strong>Tristana Hỏa Tiễn Tinh Nghịch</strong></p>

<h4><img alt="trist 1" src="https://lienminh.garena.vn/images/articles/minhminh55/2016/1-khuyen-mai/0830-cp/trist_1.jpg" style="height:216px; width:600px" /></h4>

<ul>
	<li>Tristana Hỏa Tiễn Tinh Nghịch T&iacute;m</li>
	<li>Tristana Hỏa Tiễn Tinh Nghịch Xanh Thẫm</li>
</ul>

<p>&nbsp;</p>

<p>Một số trang phục Đa Sắc sẽ kh&ocirc;ng mở b&aacute;n trong đợt khuyến m&atilde;i n&agrave;y nhưng ho&agrave;n to&agrave;n c&oacute; thể trở lại trong c&aacute;c sự kiện - đợt khuyến m&atilde;i kế tiếp. Những th&ocirc;ng tin về c&aacute;c sự kiện sắp mở trong tương lai sẽ được cập nhật tr&ecirc;n trang chủ, c&aacute;c bạn nhớ ch&uacute; &yacute; theo d&otilde;i nh&eacute;.</p>

<ul>
	<li>Tra cứu điểm b&aacute;n thẻ Garena gần nhất tại:&nbsp;<a href="https://info.cyberpay.vn/dai-ly/diem-giao-dich" target="_blank">Cyberpay.vn</a></li>
	<li>Mua bằng V&iacute; điện tử TopPay:&nbsp;<a href="https://toppay.vn/" target="_blank">TopPay.vn</a></li>
</ul>

<p><a href="http://napthe.garena.vn/" target="_blank"><img alt="1" src="https://lienminh.garena.vn/images/articles/minhminh55/2015/1-khuyen-mai/0-button/1.png" style="height:129px; width:279px" /></a></p>

<p><a href="http://kmcyberpay.garena.vn/danh-sach-phong-may/" target="_blank"><img alt="3" src="https://lienminh.garena.vn/images/articles/minhminh55/2015/1-khuyen-mai/0-button/3.png" style="height:144px; width:274px" /></a><a href="http://diendan.garena.vn/showthread.php?164824" target="_blank"><img alt="4" src="https://lienminh.garena.vn/images/articles/minhminh55/2015/1-khuyen-mai/0-button/4.png" style="height:142px; width:266px" /></a></p>
', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[KOK_PRODUCTS] OFF
SET IDENTITY_INSERT [dbo].[MENU] ON 

INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (1, N'Chuyên mục', N'category_list.aspx', 1, 0, 99, 1, CAST(N'1994-01-01 00:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (2, N'Sản phẩm', N'news_list.aspx?type=1', 1, 0, 98, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (3, N'Danh sách sản phẩm', N'news_list.aspx?type=1', 2, 2, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (4, N'Thêm mới sản phẩm', N'news.aspx?type=1', 2, 2, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (5, N'Tin tức/Video', N'news_list.aspx?type=0', 1, 0, 98, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (6, N'Ds tin tức/video', N'news_list.aspx?type=0', 2, 8, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (7, N'Thêm mới tin tức/video', N'news.aspx?type=0', 2, 8, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[MENU] ([ID], [MENU_NAME], [MENU_LINK], [MENU_RANK], [MENU_PARENT_ID], [MENU_ORDER], [ACTIVE], [CREATE_DATE], [UPDATE_DATE], [CREATE_USER], [UPDATE_USER]) VALUES (8, N'aaaa', N'aaaa', 1, 1, 1, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MENU] OFF
ALTER TABLE [dbo].[KOK_CONFIG] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_EMAIL] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_GROUP] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_NEWS_ATT] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_NEWS_IMAGE] ADD  DEFAULT ((1)) FOR [ACTIVE]
GO
ALTER TABLE [dbo].[KOK_NEWS_ATT]  WITH CHECK ADD  CONSTRAINT [FK_KOK_NEWS_ATT_KOK_NEWS] FOREIGN KEY([NEWS_ID])
REFERENCES [dbo].[KOK_NEWS] ([NEWS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KOK_NEWS_ATT] CHECK CONSTRAINT [FK_KOK_NEWS_ATT_KOK_NEWS]
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT]  WITH CHECK ADD  CONSTRAINT [FK_KOK_NEWS_CAT_KOK_CATEGORIES] FOREIGN KEY([CAT_ID])
REFERENCES [dbo].[KOK_CATEGORIES] ([CAT_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT] CHECK CONSTRAINT [FK_KOK_NEWS_CAT_KOK_CATEGORIES]
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT]  WITH CHECK ADD  CONSTRAINT [FK_KOK_NEWS_CAT_KOK_NEWS] FOREIGN KEY([NEWS_ID])
REFERENCES [dbo].[KOK_NEWS] ([NEWS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT] CHECK CONSTRAINT [FK_KOK_NEWS_CAT_KOK_NEWS]
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT]  WITH CHECK ADD  CONSTRAINT [FK_KOK_NEWS_CAT_KOK_PRODUCTS] FOREIGN KEY([NEWS_ID])
REFERENCES [dbo].[KOK_PRODUCTS] ([NEWS_ID])
GO
ALTER TABLE [dbo].[KOK_NEWS_CAT] CHECK CONSTRAINT [FK_KOK_NEWS_CAT_KOK_PRODUCTS]
GO
ALTER TABLE [dbo].[KOK_NEWS_IMAGE]  WITH CHECK ADD  CONSTRAINT [FK_KOK_NEWS_IMAGE_KOK_NEWS] FOREIGN KEY([NEWS_ID])
REFERENCES [dbo].[KOK_NEWS] ([NEWS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KOK_NEWS_IMAGE] CHECK CONSTRAINT [FK_KOK_NEWS_IMAGE_KOK_NEWS]
GO
USE [master]
GO
ALTER DATABASE [KOK_DATA] SET  READ_WRITE 
GO
