USE [CoopShop_DataShop_v1]
GO

/****** Object:  Table [dbo].[Territories]    Script Date: 04/03/2018 14:43:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Taxes](
	[TaxID] [int] NOT NULL,
	[TaxDescription] [nvarchar](50) NOT NULL,
	[RegionID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RatePercentage] [real] NOT NULL,
	[OfficialDate] [datetime] NULL,

 CONSTRAINT [PK_Taxes] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Taxes]  WITH CHECK ADD  CONSTRAINT [FK_Taxes_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO

ALTER TABLE [dbo].[Taxes] CHECK CONSTRAINT [FK_Taxes_Region]
GO
/*************/

ALTER TABLE [dbo].[Suppliers] ADD [RegionID] [int] Default(0)
GO

ALTER TABLE [dbo].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO
/*************/

ALTER TABLE [dbo].[Categories] ADD [TaxType] [int] Default(0)
GO
/********MODIFY Stocked procedure : change ContactName by ProductName
*/
USE [CoopShop_DataShop_v1]
GO
/****** Object:  StoredProcedure [dbo].[CustomerGrossSales]    Script Date: 11/03/2018 12:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[CustomerGrossSales]
    @startDate DATE,
    @endDate DATE
AS
BEGIN
    SELECT
        p.ProductName,
        GrossAmount = Sum(d.UnitPrice* d.Quantity)
    FROM
        Orders o
        LEFT OUTER JOIN
            Customers c on c.CustomerID = o.CustomerID
        LEFT OUTER JOIN
            [Order Details] d on d.OrderID = o.OrderID
        LEFT OUTER JOIN
            Products p on p.ProductID = d.ProductID
    WHERE
        (@startDate IS NULL OR o.OrderDate >= @startDate) AND
        (@endDate IS NULL OR o.OrderDate <= @endDate)
    GROUP BY p.ProductName
    ORDER BY p.ProductName, Sum(d.UnitPrice* d.Quantity) DESC
END
GO

USE [CoopShop_DataShop_v1]
GO

/****** Object:  StoredProcedure [dbo].[CustomerGrossSales]    Script Date: 11/03/2018 13:14:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerGrossProductsSales]
    @startDate DATE,
    @endDate DATE
AS
BEGIN
    SELECT

        p.ProductName,
		SalesTotal = Sum(d.OrderID),
        GrossAmount = Sum(d.UnitPrice* d.Quantity)
    FROM
        Orders o
        LEFT OUTER JOIN
            Customers c on c.CustomerID = o.CustomerID
        LEFT OUTER JOIN
            [Order Details] d on d.OrderID = o.OrderID
        LEFT OUTER JOIN
            Products p on p.ProductID = d.ProductID
    WHERE
        (@startDate IS NULL OR o.OrderDate >= @startDate) AND
        (@endDate IS NULL OR o.OrderDate <= @endDate)
    GROUP BY p.ProductName
    ORDER BY p.ProductName, Sum(d.UnitPrice* d.Quantity) DESC
END
GO
