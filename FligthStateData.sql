USE [MAANPP20-SAGA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FlightStateData](
	[CorrelationId] [uniqueidentifier] NOT NULL,
	[CurrentState] [nvarchar](max) NULL,
	[CreationDateTime] [datetime] NULL,
	[CancelDateTime] [datetime] NULL,
	[UserId] [nvarchar](max) NULL,
	[FlightId] [uniqueidentifier] NULL,
	[CarId] [int] NULL,
	[HotelId] [int] NULL,
	[PaymentId] [int] NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_FlightStateData] PRIMARY KEY CLUSTERED 
(
	[CorrelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

