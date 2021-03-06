USE [SHOPVT]
GO
/****** Object:  Table [dbo].[B00AppUser]    Script Date: 10/11/2021 20:15:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00AppUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](256) NOT NULL DEFAULT (''),
	[username] [varchar](24) NOT NULL DEFAULT (''),
	[PassWord] [varchar](8) NOT NULL DEFAULT (''),
	[FullName] [nvarchar](256) NOT NULL DEFAULT (''),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[EmployeeCode] [varchar](24) NOT NULL DEFAULT (''),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00CommandLog]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00CommandLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Command] [varchar](6) NOT NULL DEFAULT (''),
	[UserIp] [varchar](15) NOT NULL DEFAULT (''),
	[AppUserCode] [varchar](24) NOT NULL DEFAULT (''),
	[LastWriteAt] [datetime] NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00Contact]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Facebook] [nvarchar](256) NOT NULL,
	[address] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00EventLog]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00EventLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [varchar](66) NOT NULL DEFAULT (''),
	[LastValue] [nvarchar](256) NOT NULL DEFAULT (''),
	[Command] [varchar](30) NOT NULL DEFAULT (''),
	[NewValue] [nvarchar](256) NOT NULL DEFAULT (''),
	[TableName] [varchar](20) NOT NULL DEFAULT (''),
	[LastWriteAt] [datetime] NOT NULL DEFAULT (''),
	[LastWriteBy] [int] NOT NULL DEFAULT ((-1)),
	[RowId] [int] NULL DEFAULT ((-1)),
	[ColumnName] [varchar](24) NULL DEFAULT (''),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00Footer]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00Footer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00Function]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00Function](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL DEFAULT ((0)),
	[ParentId] [int] NOT NULL DEFAULT ((-1)),
	[Code] [varchar](24) NOT NULL DEFAULT (''),
	[CategoryFunc] [int] NOT NULL DEFAULT ((-1)),
	[Name] [nvarchar](256) NOT NULL DEFAULT (''),
	[Url] [nvarchar](256) NOT NULL DEFAULT (''),
	[DisplayOrder] [int] NOT NULL DEFAULT ((1)),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00Permision]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00Permision](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](24) NOT NULL DEFAULT (''),
	[Name] [nvarchar](50) NOT NULL DEFAULT (''),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00PermisionDetail]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00PermisionDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PermisionCode] [varchar](24) NOT NULL DEFAULT (''),
	[functionCode] [varchar](24) NOT NULL DEFAULT (''),
	[CanCreate] [bit] NOT NULL DEFAULT ((1)),
	[CanRead] [bit] NOT NULL DEFAULT ((1)),
	[Canupdate] [bit] NOT NULL DEFAULT ((1)),
	[Candelete] [bit] NOT NULL DEFAULT ((1)),
	[CanReport] [bit] NOT NULL DEFAULT ((1)),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B00UserPermision]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B00UserPermision](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[userCode] [varchar](24) NOT NULL DEFAULT (''),
	[PermisionCode] [varchar](24) NOT NULL DEFAULT (''),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Customer]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[email] [nvarchar](256) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[gender] [int] NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[Code] [varchar](24) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10CustomerAccount]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10CustomerAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [varchar](24) NOT NULL,
	[username] [varchar](24) NOT NULL,
	[PassWord] [varchar](8) NOT NULL,
	[FullName] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10CustomerAddress]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10CustomerAddress](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerAccountId] [int] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Phone] [varchar](10) NOT NULL,
	[Note] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Employee]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Name2] [nvarchar](256) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Address] [nvarchar](256) NOT NULL,
	[IdCardNo] [int] NOT NULL,
	[IdCardDate] [date] NOT NULL,
	[IdCardIssuePlace] [nvarchar](256) NOT NULL,
	[BankAccount] [int] NOT NULL,
	[BankName] [nvarchar](256) NOT NULL,
	[Tel1] [varchar](10) NOT NULL,
	[Tel2] [varchar](10) NOT NULL,
	[MarriageStatus] [int] NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Gender] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10HomePage]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10HomePage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[imagePath] [nvarchar](500) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[PostCode] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Post]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10Post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Alias] [varchar](500) NOT NULL,
	[PostCategoryCode] [varchar](24) NOT NULL,
	[Image] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[MetaDescription] [nvarchar](500) NOT NULL,
	[MetaKeyword] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10PostCategory]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10PostCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Alias] [varchar](500) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[MetaDescription] [nvarchar](500) NOT NULL,
	[MetaKeyword] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10PostTag]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10PostTag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [varchar](24) NOT NULL,
	[TagId] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Product]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](24) NOT NULL DEFAULT (''),
	[Name] [nvarchar](256) NOT NULL DEFAULT (''),
	[Alias] [varchar](256) NOT NULL DEFAULT (''),
	[ProductCategoryCode] [varchar](24) NOT NULL DEFAULT (''),
	[UnitCost] [numeric](18, 2) NOT NULL DEFAULT ((0)),
	[UnitPrice] [numeric](18, 2) NOT NULL DEFAULT ((0)),
	[Warranty] [int] NOT NULL DEFAULT ((1)),
	[Description] [nvarchar](256) NOT NULL DEFAULT (''),
	[Content] [nvarchar](256) NOT NULL DEFAULT (''),
	[Information] [nvarchar](max) NOT NULL DEFAULT (''),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedBy] [int] NOT NULL DEFAULT ((-1)),
	[CreatedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
	[ModifiedBy] [int] NOT NULL DEFAULT ((-1)),
	[ModifiedAt] [datetime] NOT NULL DEFAULT (getutcdate()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10ProductCategory]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10ProductCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Alias] [varchar](256) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10ProductImg]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10ProductImg](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[ImagePath] [nvarchar](256) NOT NULL,
	[Caption] [nvarchar](256) NOT NULL,
	[ImageDefault] [nvarchar](256) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[ImglengthSize] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10ProductInformation]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10ProductInformation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[name] [nvarchar](256) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10ProductTag]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10ProductTag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[TagId] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Slide]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B10Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Image] [nvarchar](500) NOT NULL,
	[Url] [nvarchar](500) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B10Tag]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[B10Tag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Type] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[B20Announcement]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20Announcement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](256) NOT NULL,
	[content] [nvarchar](256) NOT NULL,
	[HasRead] [bit] NOT NULL,
	[UserCode] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20Chats]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[B20Chats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Type] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[B20ChatUser]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20ChatUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](24) NOT NULL,
	[customerCode] [varchar](24) NOT NULL,
	[IpAddress] [varchar](24) NOT NULL,
	[ChatId] [int] NOT NULL,
	[Role] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20Flashsale]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20Flashsale](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](24) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20FlashSaleDetail]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20FlashSaleDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Flashsalecode] [varchar](24) NOT NULL,
	[ApplyForAll] [bit] NOT NULL,
	[ProductCategoryCode] [varchar](24) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[DiscountPercent] [decimal](5, 2) NOT NULL,
	[UnitPrice] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20message]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[B20message](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ChatsId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[B20OpenInventory]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20OpenInventory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[ItemCode] [varchar](24) NOT NULL,
	[Year] [varchar](4) NOT NULL,
	[Month] [varchar](4) NOT NULL,
	[DocDate] [smalldatetime] NOT NULL,
	[OriginalUnitCost] [numeric](15, 4) NOT NULL,
	[UnitCost] [numeric](18, 2) NOT NULL,
	[Unit] [nvarchar](20) NOT NULL,
	[Quantity] [int] NOT NULL,
	[rate] [numeric](15, 4) NOT NULL,
	[OriginalExpenseAmount] [numeric](18, 2) NOT NULL,
	[ExpenseAmount] [numeric](18, 2) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20Order]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](24) NOT NULL,
	[CustomerName] [nvarchar](256) NOT NULL,
	[CustomerAddress] [nvarchar](256) NOT NULL,
	[CustomerEmail] [nvarchar](256) NOT NULL,
	[CustomerMobile] [varchar](10) NOT NULL,
	[IdCardNo] [int] NOT NULL,
	[note] [nvarchar](256) NOT NULL,
	[PaymentMethod] [nvarchar](256) NOT NULL,
	[PaymentStatus] [nvarchar](max) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20OrderDetail]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20OrderDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [varchar](24) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[Quantitty] [int] NOT NULL,
	[UnitPrice] [numeric](18, 2) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20ProductPromotion]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20ProductPromotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PromotionCode] [varchar](24) NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20ProductReturn]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20ProductReturn](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [varchar](24) NOT NULL,
	[CustomerName] [nvarchar](256) NOT NULL,
	[CustomerAddress] [nvarchar](256) NOT NULL,
	[CustomerEmail] [nvarchar](256) NOT NULL,
	[CustomerMobile] [varchar](10) NOT NULL,
	[IdCardNo] [int] NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[ProductPrice] [numeric](18, 2) NOT NULL,
	[Quantity] [numeric](15, 4) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[note] [nvarchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20Promotion]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[B20Promotion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IsGroup] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
	[code] [varchar](24) NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[ProductCode] [varchar](24) NOT NULL,
	[Price] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[B20StockLedger]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[B20StockLedger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocGroup] [bit] NOT NULL,
	[DocDate] [smalldatetime] NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Unit] [nvarchar](8) NOT NULL,
	[Quantity] [numeric](15, 4) NOT NULL,
	[UnitCost] [numeric](18, 2) NOT NULL,
	[OriginalUnitCost] [numeric](18, 2) NOT NULL,
	[Warranty] [numeric](18, 2) NOT NULL,
	[Unitprice] [numeric](18, 2) NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[OriginalAmount] [numeric](18, 2) NOT NULL,
	[ExpenseAmount] [numeric](18, 2) NOT NULL,
	[transportationcosts] [numeric](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[B00AppUser] ON 

INSERT [dbo].[B00AppUser] ([ID], [code], [username], [PassWord], [FullName], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [EmployeeCode]) VALUES (1, N'abc', N'abc', N'abc', N'', 1, -1, CAST(N'2021-10-10 09:31:31.887' AS DateTime), -1, CAST(N'2021-10-10 09:31:31.887' AS DateTime), N'')
SET IDENTITY_INSERT [dbo].[B00AppUser] OFF
SET IDENTITY_INSERT [dbo].[B00CommandLog] ON 

INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1, N'LOGIN', N'abc', N'', CAST(N'2021-10-10 09:47:03.150' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (2, N'LOGIN', N'abc', N'', CAST(N'2021-10-10 09:47:24.123' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (3, N'LOGIN', N'abc', N'', CAST(N'2021-10-10 09:48:48.647' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (4, N'LOGIN', N'abc', N'', CAST(N'2021-10-10 13:13:50.260' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1004, N'LOGIN', N'', N'', CAST(N'2021-10-11 07:27:24.553' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1005, N'LOGIN', N'', N'', CAST(N'2021-10-11 07:29:05.180' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1006, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 07:31:31.047' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1007, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 08:46:38.030' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1008, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 08:51:00.423' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1009, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 08:51:17.280' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1010, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 08:51:45.380' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1011, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 08:53:52.680' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1012, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:00:57.133' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1013, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:03:35.967' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1014, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:04:26.833' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1015, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:04:43.813' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1016, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:21:24.480' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1017, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:21:28.530' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1018, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:23:05.333' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1019, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:23:05.343' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1020, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:24:16.153' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1021, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:24:16.187' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1022, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:27:00.713' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1023, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:27:00.723' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1024, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:27:11.193' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1025, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:27:11.200' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1026, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:29:58.397' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1027, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:30:26.960' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1028, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:36:03.130' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1029, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:36:03.143' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1030, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:37:20.327' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1031, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:37:20.333' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1032, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:40:26.243' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1033, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:40:26.467' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1034, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:47:40.500' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1035, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 09:47:40.697' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1036, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:02:02.537' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1037, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:02:02.717' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1038, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:03:52.703' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1039, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:03:52.963' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1040, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:08:09.310' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1041, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:08:09.523' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1042, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:09:44.123' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1043, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:09:44.293' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1044, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:11:38.083' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1045, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:11:38.223' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1046, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:20:06.230' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1047, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:20:21.073' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1048, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:20:21.950' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1049, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:20:23.037' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1050, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:03.773' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1051, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:12.967' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1052, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:13.563' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1053, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:43.547' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1054, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:44.150' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1055, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:46.847' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1056, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:21:47.397' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1057, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:23:53.300' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1058, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:24:02.820' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1059, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:24:09.570' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1060, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:25:22.120' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1061, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:25:22.603' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1062, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:41:08.820' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1063, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:41:26.100' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1064, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:41:59.340' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1065, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:41:59.920' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1066, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:42:09.300' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1067, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:42:09.763' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1068, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:42:16.180' AS DateTime))
INSERT [dbo].[B00CommandLog] ([Id], [Command], [UserIp], [AppUserCode], [LastWriteAt]) VALUES (1069, N'LOGIN', N'', N'abc', CAST(N'2021-10-11 10:42:16.630' AS DateTime))
SET IDENTITY_INSERT [dbo].[B00CommandLog] OFF
SET IDENTITY_INSERT [dbo].[B00EventLog] ON 

INSERT [dbo].[B00EventLog] ([ID], [SessionId], [LastValue], [Command], [NewValue], [TableName], [LastWriteAt], [LastWriteBy], [RowId], [ColumnName]) VALUES (1, N'FAB3588295584BDCB3C46FF5A127FC29-56-721391', N'', N'DELETE', N'', N'B10Product', CAST(N'2021-10-08 14:24:01.283' AS DateTime), 1102, 1, N'')
INSERT [dbo].[B00EventLog] ([ID], [SessionId], [LastValue], [Command], [NewValue], [TableName], [LastWriteAt], [LastWriteBy], [RowId], [ColumnName]) VALUES (2, N'7A5450BADD614417A542044AA7C0A6A7-52-821508', N'', N'INSERT', N'', N'B10Product', CAST(N'2021-10-08 15:42:06.333' AS DateTime), 123, 2, N'')
INSERT [dbo].[B00EventLog] ([ID], [SessionId], [LastValue], [Command], [NewValue], [TableName], [LastWriteAt], [LastWriteBy], [RowId], [ColumnName]) VALUES (3, N'7A5450BADD614417A542044AA7C0A6A7-52-822419', N'', N'INSERT', N'', N'B10Product', CAST(N'2021-10-08 15:44:08.587' AS DateTime), 123, 3, N'')
INSERT [dbo].[B00EventLog] ([ID], [SessionId], [LastValue], [Command], [NewValue], [TableName], [LastWriteAt], [LastWriteBy], [RowId], [ColumnName]) VALUES (4, N'7A5450BADD614417A542044AA7C0A6A7-52-823233', N'', N'INSERT', N'', N'B10Product', CAST(N'2021-10-08 15:46:12.247' AS DateTime), 123, 4, N'')
SET IDENTITY_INSERT [dbo].[B00EventLog] OFF
SET IDENTITY_INSERT [dbo].[B00Function] ON 

INSERT [dbo].[B00Function] ([ID], [IsGroup], [ParentId], [Code], [CategoryFunc], [Name], [Url], [DisplayOrder], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, 0, -1, N'PRODUCT', -1, N'S?n ph?m', N'', 1, 1, -1, CAST(N'2021-10-11 07:20:24.357' AS DateTime), -1, CAST(N'2021-10-11 07:20:24.357' AS DateTime))
SET IDENTITY_INSERT [dbo].[B00Function] OFF
SET IDENTITY_INSERT [dbo].[B00Permision] ON 

INSERT [dbo].[B00Permision] ([ID], [Code], [Name], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, N'NV', N'Nhân viên', 1, -1, CAST(N'2021-10-11 07:24:23.803' AS DateTime), -1, CAST(N'2021-10-11 07:24:23.803' AS DateTime))
SET IDENTITY_INSERT [dbo].[B00Permision] OFF
SET IDENTITY_INSERT [dbo].[B00PermisionDetail] ON 

INSERT [dbo].[B00PermisionDetail] ([ID], [PermisionCode], [functionCode], [CanCreate], [CanRead], [Canupdate], [Candelete], [CanReport], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, N'NV', N'PRODUCT', 1, 1, 1, 1, 1, 1, -1, CAST(N'2021-10-11 07:26:16.623' AS DateTime), -1, CAST(N'2021-10-11 07:26:16.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[B00PermisionDetail] OFF
SET IDENTITY_INSERT [dbo].[B00UserPermision] ON 

INSERT [dbo].[B00UserPermision] ([ID], [userCode], [PermisionCode], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, N'abc', N'NV', 1, -1, CAST(N'2021-10-11 07:25:53.783' AS DateTime), -1, CAST(N'2021-10-11 07:25:53.783' AS DateTime))
SET IDENTITY_INSERT [dbo].[B00UserPermision] OFF
SET IDENTITY_INSERT [dbo].[B10Product] ON 

INSERT [dbo].[B10Product] ([ID], [code], [Name], [Alias], [ProductCategoryCode], [UnitCost], [UnitPrice], [Warranty], [Description], [Content], [Information], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (2, N'string', N'string', N'string', N'string', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 0, N'string', N'string', N'string', 1, -1, CAST(N'2021-10-08 15:42:05.957' AS DateTime), -1, CAST(N'2021-10-08 15:42:05.957' AS DateTime))
INSERT [dbo].[B10Product] ([ID], [code], [Name], [Alias], [ProductCategoryCode], [UnitCost], [UnitPrice], [Warranty], [Description], [Content], [Information], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (3, N'test23', N'string', N'string', N'string', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 0, N'string', N'string', N'string', 1, -1, CAST(N'2021-10-08 15:44:08.437' AS DateTime), -1, CAST(N'2021-10-08 15:44:08.437' AS DateTime))
INSERT [dbo].[B10Product] ([ID], [code], [Name], [Alias], [ProductCategoryCode], [UnitCost], [UnitPrice], [Warranty], [Description], [Content], [Information], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (4, N'test123', N'string', N'string', N'string', CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 0, N'string', N'string', N'string', 1, 123, CAST(N'2021-10-08 15:46:12.037' AS DateTime), -1, CAST(N'2021-10-08 15:46:12.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[B10Product] OFF
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [Facebook]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ('') FOR [address]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B00Contact] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT ('') FOR [Content]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B00Footer] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ('') FOR [phone]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ((-1)) FOR [gender]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ('') FOR [BirthDate]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Customer] ADD  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ('') FOR [CustomerCode]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ('') FOR [username]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ('') FOR [PassWord]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ('') FOR [FullName]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10CustomerAccount] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ((-1)) FOR [CustomerId]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ((-1)) FOR [CustomerAccountId]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ('') FOR [Phone]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ('') FOR [Note]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10CustomerAddress] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Name2]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [BirthDate]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Address]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [IdCardNo]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [IdCardDate]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [IdCardIssuePlace]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [BankAccount]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [BankName]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Tel1]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Tel2]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [MarriageStatus]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [Gender]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10Employee] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ('') FOR [imagePath]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ('') FOR [PostCode]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10HomePage] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [Alias]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [PostCategoryCode]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [Image]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [Content]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [MetaDescription]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ('') FOR [MetaKeyword]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10Post] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [Alias]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((-1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [MetaDescription]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ('') FOR [MetaKeyword]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10PostCategory] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT ('') FOR [PostId]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT ('') FOR [TagId]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10PostTag] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ('') FOR [Alias]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10ProductCategory] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ('') FOR [ImagePath]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ('') FOR [Caption]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ('') FOR [ImageDefault]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((-1)) FOR [SortOrder]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((-1)) FOR [ImglengthSize]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10ProductImg] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ('') FOR [name]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10ProductInformation] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT ('') FOR [TagId]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10ProductTag] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ('') FOR [Image]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ('') FOR [Url]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((0)) FOR [Type]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10Slide] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT ('') FOR [Type]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B10Tag] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ('') FOR [title]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ('') FOR [content]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ((1)) FOR [HasRead]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ('') FOR [UserCode]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20Announcement] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20Chats] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B20Chats] ADD  DEFAULT ((-1)) FOR [Type]
GO
ALTER TABLE [dbo].[B20Chats] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20Chats] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ('') FOR [UserCode]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ('') FOR [customerCode]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ('') FOR [IpAddress]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ((-1)) FOR [ChatId]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ((-1)) FOR [Role]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20ChatUser] ADD  DEFAULT ((-1)) FOR [UserId]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT (getutcdate()) FOR [FromDate]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT (getutcdate()) FOR [ToDate]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20Flashsale] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ('') FOR [Flashsalecode]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((1)) FOR [ApplyForAll]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ('') FOR [ProductCategoryCode]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((0)) FOR [DiscountPercent]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20FlashSaleDetail] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT ('') FOR [Text]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT ((-1)) FOR [ChatsId]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20message] ADD  DEFAULT ((-1)) FOR [UserId]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ('') FOR [ItemCode]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ('') FOR [Year]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ('') FOR [Month]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ('') FOR [DocDate]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [OriginalUnitCost]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [UnitCost]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ('') FOR [Unit]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [rate]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [OriginalExpenseAmount]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [ExpenseAmount]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20OpenInventory] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [CustomerName]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [CustomerAddress]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [CustomerEmail]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [CustomerMobile]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((-1)) FOR [IdCardNo]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [note]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [PaymentMethod]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ('') FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((1)) FOR [OrderStatus]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20Order] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ('') FOR [OrderCode]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((1)) FOR [Quantitty]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20OrderDetail] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT ('') FOR [PromotionCode]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20ProductPromotion] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [OrderCode]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [CustomerName]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [CustomerAddress]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [CustomerEmail]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [CustomerMobile]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((-1)) FOR [IdCardNo]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((0)) FOR [ProductPrice]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ('') FOR [note]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20ProductReturn] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((0)) FOR [IsGroup]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((-1)) FOR [ParentId]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ('') FOR [code]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT (getutcdate()) FOR [FromDate]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT (getutcdate()) FOR [ToDate]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ('') FOR [ProductCode]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20Promotion] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((1)) FOR [DocGroup]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT (getutcdate()) FOR [DocDate]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ('') FOR [Unit]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [UnitCost]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [OriginalUnitCost]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [Warranty]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [Unitprice]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [OriginalAmount]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [ExpenseAmount]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((0)) FOR [transportationcosts]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((-1)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT (getutcdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT ((-1)) FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[B20StockLedger] ADD  DEFAULT (getutcdate()) FOR [ModifiedAt]
GO
/****** Object:  StoredProcedure [dbo].[B10Product_create]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[B10Product_create]
	(@code varchar(24), @Name nvarchar(256), @Alias varchar(256), @ProductCategoryCode varchar(24), @UnitCost numeric, @UnitPrice numeric, @Warranty int, @Description nvarchar(256), @Content nvarchar(256), @Information nvarchar(MAX) , @user_id int)


AS
    BEGIN
	BEGIN TRY	
	IF(EXISTS
	(
		SELECT 1
		FROM B10Product
		 WHERE B10Product.code = @code  
	))
	BEGIN
		SELECT 'MESSAGE.B10Product_exist';
	END;
	ELSE
		BEGIN
		EXEC sp_set_session_context 'user_id', @user_id; 
		INSERT INTO B10Product
		(
code,
			Name,
			Alias,
			ProductCategoryCode,
			UnitCost,
			UnitPrice,
			Warranty,
			Description,
			Content,
			Information,
createdBy
		)
		VALUES
		(
@code,
			@Name,
			@Alias,
			@ProductCategoryCode,
			@UnitCost,
			@UnitPrice,
			@Warranty,
			@Description,
			@Content,
			@Information,
			@user_id
		);
		END;
	END TRY

	-- If any error
	BEGIN CATCH
		SELECT 'MESSAGE. failed';
	END CATCH
    END;


GO
/****** Object:  StoredProcedure [dbo].[B10Product_delete]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[B10Product_delete]
	(@code varchar(24), @user_id int)

AS
    BEGIN
        IF(NOT EXISTS
        (
            SELECT 1
            FROM B10Product
            WHERE B10Product.code = @code  
        ))
            BEGIN
                SELECT 'MESSAGE.not_exist';
        END;
            ELSE
            BEGIN
	EXEC sp_set_session_context 'user_id', 1102; 
	DELETE FROM B10Product 
	WHERE B10Product.code = @code  
             END;
    END;

GO
/****** Object:  StoredProcedure [dbo].[B10Product_get_all]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









CREATE PROCEDURE [dbo].[B10Product_get_all]
AS
    BEGIN
        SELECT 
            code, Name, Alias, ProductCategoryCode, UnitCost, UnitPrice, Warranty, Description, Content, Information, IsActive, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
        FROM B10Product 

    END;

GO
/****** Object:  StoredProcedure [dbo].[B10Product_get_by_id]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[B10Product_get_by_id]
	( @code varchar(24) )
AS
    BEGIN
        SELECT 
            code, Name, Alias, ProductCategoryCode, UnitCost, UnitPrice, Warranty, Description, Content, Information, IsActive, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
        FROM B10Product 
        WHERE B10Product.code = @code  
	
    END;

GO
/****** Object:  StoredProcedure [dbo].[B10Product_search]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






--CREATE PROCEDURE [dbo].[B10Product_search] 
--	( @Name nvarchar(256) )
--AS
--    BEGIN 
--		IF(@lang = 'e')
--			BEGIN	
--				SELECT code, Name, Alias, ProductCategoryCode, UnitCost, UnitPrice, Warranty, Description, Content, Information, IsActive, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
--				FROM B10Product
--				WHERE  WHERE B10Product.Name = @Name   
--				
--			END
--		ELSE
--			BEGIN
--				SELECT code, Name, Alias, ProductCategoryCode, UnitCost, UnitPrice, Warranty, Description, Content, Information, IsActive, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
--				FROM  B10Product
--				WHERE  WHERE B10Product.Name = @Name   
--				
--			END
--    END;
--
CREATE PROCEDURE [dbo].[B10Product_search] 
	( @Name nvarchar(256) )
AS
BEGIN	
SELECT code, Name, Alias, ProductCategoryCode, UnitCost, UnitPrice, Warranty, Description, Content, Information, IsActive, CreatedBy, CreatedAt, ModifiedBy, ModifiedAt
FROM B10Product
 WHERE B10Product.Name =@Name
    END;

GO
/****** Object:  StoredProcedure [dbo].[B10Product_update]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











CREATE PROCEDURE [dbo].[B10Product_update]
	( @code varchar(24), @Name nvarchar(256), @Alias varchar(256), @ProductCategoryCode varchar(24), @UnitCost numeric, @UnitPrice numeric, @Warranty int, @Description nvarchar(256), @Content nvarchar(256), @Information nvarchar(MAX), @IsActive bit , @user_id int)


AS
    BEGIN
        IF(NOT EXISTS
        (
            SELECT 1
            FROM B10Product
             WHERE B10Product.code = @code  
        ))
            BEGIN
                SELECT 'MESSAGE.not_exist';
        END;
            ELSE
            BEGIN
	EXEC sp_set_session_context 'user_id', @user_id; 
                UPDATE B10Product
                  SET 
B10Product.code=@code,
			B10Product.Name=@Name,
			B10Product.Alias=@Alias,
			B10Product.ProductCategoryCode=@ProductCategoryCode,
			B10Product.UnitCost=@UnitCost,
			B10Product.UnitPrice=@UnitPrice,
			B10Product.Warranty=@Warranty,
			B10Product.Description=@Description,
			B10Product.Content=@Content,
			B10Product.Information=@Information,
			B10Product.IsActive=@IsActive
                WHERE B10Product.code = @code  ;
              
        END;
    END;

GO
/****** Object:  StoredProcedure [dbo].[usp_Login]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_Login] 
 @userName varchar(24), 
 @password varchar(8)
AS
BEGIN
	DECLARE @_userName VARCHAR(32)
	DECLARE @_passWord VARCHAR(32)
	SET @_userName=CONVERT(VARCHAR(32), HashBytes('MD5',@userName), 2)
	SET @_passWord=CONVERT(VARCHAR(32), HashBytes('MD5',@password), 2)

	SELECT TOP 1 id, code, fullname, EmployeeCode, Cast(SPACE(5000) AS VARCHAR(5000)) AS Roles INTO #result
	FROM B00AppUser
	WHERE IsActive=1 
			AND (CONVERT(VARCHAR(32), HashBytes('MD5',username), 2) =@_userName) 
			AND (CONVERT(VARCHAR(32), HashBytes('MD5',[PassWord]), 2) =@_passWord)

	IF 1 = (SELECT COUNT(*) FROM #result)
	BEGIN
		UPDATE #result
		SET Roles= (
						SELECT pd.FunctionCode, CanCreate, CanRead, CanUpdate, CanDelete, CanReport
						FROM B00UserPermision up
							 LEFT JOIN b00Permision p ON p.Code= up.PermisionCode AND p.IsActive=1
							 LEFT JOIN B00PermisionDetail pd ON pd.permisionCode= p.code AND pd.IsActive=1
							 LEFT JOIN B00Function f ON f.Code = pd.FunctionCode AND f.IsActive = 1
						WHERE UP.IsActive=1 AND up.userCode=(SELECT code FROM #result)
						FOR JSON AUTO
					)

		INSERT INTO B00CommandLog (Command, AppUserCode)
		SELECT 'LOGIN', code
		FROM #result

		SELECT * FROM #result

		DROP TABLE #result
	END
	ELSE
	BEGIN
		SELECT N'TÀI KHOẢN KHÔNG TỒN TẠI';
		DROP TABLE #result
		RETURN;
	END
END








GO
/****** Object:  StoredProcedure [dbo].[usp_sys_PagingForTable]    Script Date: 10/11/2021 20:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_sys_PagingForTable]
		 @PageSize  int= 10, 
		 @PageIndex  int=0, 
		 @orderby varchar(10)='id', 
		 @table varchar(10)
AS
BEGIN
		DECLARE @_column varchar(1000);
		DECLARE @_index varchar(1000);
		DECLARE @_str varchar(5000);

		IF @PageIndex>0
			BEGIN 
				SET @_index=(@PageIndex-1) * @PageSize
			END
		ELSE
			BEGIN 
				SET @_index=@PageSize
			END
		SELECT @_column= STRING_AGG (COLUMN_NAME, ',')   
		FROM INFORMATION_SCHEMA.COLUMNS 
		WHERE TABLE_NAME =@table;


		SET @_str=  N'DECLARE @result table
					(
						PageSize int,
						PageIndex int,
						TotalRecords  int,
						[PageCount] int,
						ListObj nvarchar(max)
				    );'+ SPACE(3) +
					N'INSERT INTO @result(PageSize, PageIndex, TotalRecords, [PageCount])'+ SPACE(3) +
					N'SELECT '+CAST(@PageSize AS VARCHAR(10))+', '+CAST(@PageIndex AS VARCHAR(10))+ ', COUNT(ID), CEILING(CAST(COUNT(ID) AS FLOAT)/'+ CAST(@PageSize AS VARCHAR(10))+')'+ SPACE(3) +
					N'FROM '+ @table + SPACE(3) +
					N'UPDATE @result'+ SPACE(3) +
					N'SET ListObj = ('+ SPACE(3) +
					N'					SELECT '+ @_column + SPACE(3) +
					N'					FROM '+ @table + SPACE(3) +
					N'					WHERE IsActive=  1' + SPACE(3) +
					N'					ORDER BY '+ @orderby + SPACE(3) +
					N'					OFFSET '+ @_index +' ROWS FETCH NEXT ' + CAST(@PageSize AS VARCHAR(10)) + ' ROWS ONLY '+ SPACE(3) +
					N'					FOR JSON AUTO'+ SPACE(3) +
					N'				)'+ SPACE(3) +
					N'SELECT * FROM @result';

		EXEC ( @_str)
END

GO
