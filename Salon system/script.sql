USE [master]
GO
/****** Object:  Database [DBFinalPID10]    Script Date: 5/14/2024 1:41:44 AM ******/
CREATE DATABASE [DBFinalPID10]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBFinalPID10', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBFinalPID10.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBFinalPID10_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DBFinalPID10_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DBFinalPID10] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBFinalPID10].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBFinalPID10] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBFinalPID10] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBFinalPID10] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBFinalPID10] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBFinalPID10] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBFinalPID10] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBFinalPID10] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBFinalPID10] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBFinalPID10] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBFinalPID10] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBFinalPID10] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBFinalPID10] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBFinalPID10] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBFinalPID10] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBFinalPID10] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBFinalPID10] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBFinalPID10] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBFinalPID10] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBFinalPID10] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBFinalPID10] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBFinalPID10] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBFinalPID10] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBFinalPID10] SET RECOVERY FULL 
GO
ALTER DATABASE [DBFinalPID10] SET  MULTI_USER 
GO
ALTER DATABASE [DBFinalPID10] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBFinalPID10] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBFinalPID10] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBFinalPID10] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBFinalPID10] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBFinalPID10] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBFinalPID10', N'ON'
GO
ALTER DATABASE [DBFinalPID10] SET QUERY_STORE = ON
GO
ALTER DATABASE [DBFinalPID10] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DBFinalPID10]
GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lookup](
	[lookupId] [int] IDENTITY(1,1) NOT NULL,
	[value] [nvarchar](50) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[lookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[city] [nvarchar](30) NOT NULL,
	[country] [nvarchar](30) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[status] [int] NOT NULL,
	[gender] [int] NOT NULL,
	[role] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[personId] [int] NOT NULL,
	[joiningDate] [datetime] NULL,
	[salary] [money] NULL,
	[username] [nvarchar](30) NOT NULL,
	[updatedOn] [datetime] NULL,
	[password] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_AllEmployees]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* Create a view to get all data of employees*/
CREATE VIEW [dbo].[vw_AllEmployees]
AS
SELECT P.id, P.name, P.email, P.address, P.city, P.country, P.phone, L1.value AS gender, L2.value AS role, E.username, E.salary, E.joiningDate, E.updatedOn
FROM     dbo.Employee AS E INNER JOIN
                  dbo.Person AS P ON E.personId = P.id INNER JOIN
                  dbo.Lookup AS L1 ON P.gender = L1.lookupId AND L1.category = 'gender' INNER JOIN
                  dbo.Lookup AS L2 ON P.role = L2.lookupId AND L2.category = 'role'
WHERE  (L2.value <> 'owner') AND (P.status =
                      (SELECT lookupId
                       FROM      dbo.Lookup
                       WHERE   (category = 'status') AND (value = 'active')))
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[personId] [int] NOT NULL,
	[customerTypeId] [int] NOT NULL,
	[addedBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[updatedBy] [int] NULL,
	[updatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[personId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewCustomers]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCustomers]
AS
SELECT P.id, P.name, P.email, P.phone AS [Phone Number], P.country, P.city, P.address, P.gender, P.role, C.addedBy, C.createdOn, C.updatedBy, C.updatedOn, P.status, C.customerTypeId
FROM     dbo.Customer AS C INNER JOIN
                  dbo.Person AS P ON C.personId = P.id
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
	[startTime] [nvarchar](20) NOT NULL,
	[date] [nvarchar](20) NOT NULL,
	[status] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[updatedOn] [datetime] NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppointmentDetails]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentDetails](
	[appointmentId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[serviceId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[updatedOn] [datetime] NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerType]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[discountPercentage] [decimal](5, 2) NOT NULL,
	[noOfAppointments] [int] NOT NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[updatedOn] [datetime] NULL,
	[createdOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeAttendance]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAttendance](
	[attendanceId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[attendanceStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[attendanceId] ASC,
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeNotification]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeNotification](
	[notificationId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[notificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSalary]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSalary](
	[salaryId] [int] NULL,
	[employeeId] [int] NOT NULL,
	[transferredOn] [datetime] NULL,
	[amount] [int] NOT NULL,
	[fine] [int] NOT NULL,
	[attendancePercentage] [decimal](5, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[sentBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[isDeleted] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[createDate] [datetime] NOT NULL,
	[updatedOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[supplierId] [int] NOT NULL,
	[companyId] [int] NOT NULL,
	[productType] [int] NOT NULL,
	[price] [money] NOT NULL,
	[restocklevel] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[updatedOn] [datetime] NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](30) NOT NULL,
	[description] [nvarchar](max) NULL,
	[createdOn] [datetime] NOT NULL,
	[updatedOn] [datetime] NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[orderid] [int] NOT NULL,
	[productid] [int] NOT NULL,
	[recivedby] [int] NOT NULL,
	[recivedon] [datetime] NOT NULL,
	[quantity] [int] NOT NULL,
	[expiryDate] [datetime] NOT NULL,
	[status] [int] NOT NULL,
	[price] [money] NOT NULL,
	[isDeleted] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnedProducts]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnedProducts](
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[reason] [varchar](max) NOT NULL,
	[returnedBy] [int] NOT NULL,
	[returnDate] [datetime] NOT NULL,
	[status] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalonAttendance]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalonAttendance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attendanceDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalonSalary]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalonSalary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[serviceCharges] [money] NOT NULL,
	[timeDuration] [decimal](5, 2) NOT NULL,
	[serviceTypeId] [int] NOT NULL,
	[updatedOn] [datetime] NULL,
	[createdOn] [datetime] NOT NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceProducts]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceProducts](
	[serviceId] [int] NOT NULL,
	[productId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[serviceId] ASC,
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
	[contact] [nvarchar](11) NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[updatedBy] [int] NULL,
	[updatedOn] [datetime] NULL,
	[isDeleted] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsedStock]    Script Date: 5/14/2024 1:41:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsedStock](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[empId] [int] NOT NULL,
	[useDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (3, CAST(N'2024-01-05T00:00:00.000' AS DateTime), NULL, N'asmaW', NULL, N'asmaW@123')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (4, CAST(N'2024-02-05T00:00:00.000' AS DateTime), 10000.0000, N'VarishA', NULL, N'passworD*1')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (6, CAST(N'2024-03-05T00:00:00.000' AS DateTime), 8000.0000, N'ZubariA', NULL, N'abcD%3ef')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (7, CAST(N'2024-03-05T00:00:00.000' AS DateTime), 9000.0000, N'aliZeeshan', NULL, N'aliZ#123')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (8, CAST(N'2024-03-05T00:00:00.000' AS DateTime), 7000.0000, N'Afeera', NULL, N'aff%Fat12')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (9, CAST(N'2024-03-05T00:00:00.000' AS DateTime), 10000.0000, N'Nooray', NULL, N'noorUet^1')
INSERT [dbo].[Employee] ([personId], [joiningDate], [salary], [username], [updatedOn], [password]) VALUES (10, CAST(N'2024-03-06T00:00:00.000' AS DateTime), 11000.0000, N'Kulsoom', NULL, N'kulSum$12')
GO
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (1, N'active', N'status')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (2, N'inactive', N'status')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (3, N'male', N'gender')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (4, N'female', N'gender')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (5, N'owner', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (6, N'receptionist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (7, N'customer', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (8, N'hairspecialist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (9, N'makeupspecialist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (10, N'skinspecialist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (11, N'nailartist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (12, N'yes', N'isdeleted')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (13, N'no', N'isdeleted')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (14, N'hair', N'servicetype')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (15, N'makeup', N'servicetype')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (16, N'nails', N'servicetype')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (17, N'skin', N'servicetype')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (18, N'present', N'attendancestatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (19, N'absent', N'attendancestatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (20, N'late', N'attendancestatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (21, N'leave', N'attendancestatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (22, N'hennaartist', N'role')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (23, N'pending', N'appstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (24, N'complete', N'appstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (25, N'cancelled', N'appstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (26, N'delivered', N'notification')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (27, N'deleted', N'notification')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (28, N'return', N'orderstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (29, N'refund', N'orderstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (30, N'completed', N'orderstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (31, N'partiallycompleted', N'orderstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (32, N'empty', N'orderstatus')
INSERT [dbo].[Lookup] ([lookupId], [value], [category]) VALUES (33, N'expert', N'role')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (3, N'Asma Waseem', N'asma28@gmail.com', N'not specify', N'Lahore', N'Pakistan', N'03344666683', 1, 4, 5)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (4, N'Varisha', N'varisha@gmail.com', N'garden town', N'Gujranwala', N'Pakistan', N'03333333333', 1, 4, 6)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (6, N'Zubaria', N'zubi@gmail.com', N'sui gas road', N'Gujranwala', N'Pakistan', N'03565666666', 1, 4, 8)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (7, N'Ali', N'aliZ@gmail.com', N'Gulberg', N'Lahore', N'Pakistan', N'03124567889', 1, 3, 11)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (8, N'Afeera', N'affatima@gmail.com', N'village', N'Multan', N'Pakistan', N'03556565656', 1, 4, 22)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (9, N'Noor', N'noorF@gmail.com', N'bahria town', N'Lahore', N'Pakistan', N'03556666666', 1, 4, 9)
INSERT [dbo].[Person] ([id], [name], [email], [address], [city], [country], [phone], [status], [gender], [role]) VALUES (10, N'Kulsoom', N'kulSoom@gmail.com', N'not specify', N'Lahore', N'Pakistan', N'03847847847', 1, 4, 33)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Employee__F3DBC572EEA5313E]    Script Date: 5/14/2024 1:41:44 AM ******/
ALTER TABLE [dbo].[Employee] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Person__AB6E6164AFA7504F]    Script Date: 5/14/2024 1:41:44 AM ******/
ALTER TABLE [dbo].[Person] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([personId])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[AppointmentDetails]  WITH CHECK ADD FOREIGN KEY([appointmentId])
REFERENCES [dbo].[Appointment] ([id])
GO
ALTER TABLE [dbo].[AppointmentDetails]  WITH CHECK ADD FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[AppointmentDetails]  WITH CHECK ADD FOREIGN KEY([serviceId])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([addedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([customerTypeId])
REFERENCES [dbo].[CustomerType] ([id])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD FOREIGN KEY([createdBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([personId])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[EmployeeAttendance]  WITH CHECK ADD FOREIGN KEY([attendanceStatus])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[EmployeeAttendance]  WITH CHECK ADD FOREIGN KEY([attendanceId])
REFERENCES [dbo].[SalonAttendance] ([id])
GO
ALTER TABLE [dbo].[EmployeeAttendance]  WITH CHECK ADD FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[EmployeeNotification]  WITH CHECK ADD FOREIGN KEY([employeeId])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[EmployeeNotification]  WITH CHECK ADD FOREIGN KEY([notificationId])
REFERENCES [dbo].[Notification] ([id])
GO
ALTER TABLE [dbo].[EmployeeNotification]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD FOREIGN KEY([salaryId])
REFERENCES [dbo].[SalonSalary] ([id])
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD FOREIGN KEY([sentBy])
REFERENCES [dbo].[Person] ([id])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([empId])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD FOREIGN KEY([gender])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD FOREIGN KEY([role])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([companyId])
REFERENCES [dbo].[Company] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([productType])
REFERENCES [dbo].[ProductType] ([id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([supplierId])
REFERENCES [dbo].[Supplier] ([id])
GO
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([orderid])
REFERENCES [dbo].[OrderDetails] ([id])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([productid])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([recivedby])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD FOREIGN KEY([orderId])
REFERENCES [dbo].[OrderDetails] ([id])
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD FOREIGN KEY([returnedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD FOREIGN KEY([status])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([serviceTypeId])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[ServiceProducts]  WITH CHECK ADD FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[ServiceProducts]  WITH CHECK ADD FOREIGN KEY([serviceId])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD FOREIGN KEY([createdBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD FOREIGN KEY([isDeleted])
REFERENCES [dbo].[Lookup] ([lookupId])
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD FOREIGN KEY([updatedBy])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[UsedStock]  WITH CHECK ADD FOREIGN KEY([empId])
REFERENCES [dbo].[Employee] ([personId])
GO
ALTER TABLE [dbo].[UsedStock]  WITH CHECK ADD FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([startTime] like '[0-9][0-9]:[0-9][0-9]'))
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([date] like '[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]'))
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD CHECK  ((len([name])>=(3) AND len([name])<=(50) AND NOT [name] like ' %' AND NOT [name] like '% ' AND NOT [name] like '%[^a-zA-Z0-9 &@.-]%' AND NOT [name] like '%  %'))
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD CHECK  (([discountPercentage]>=(0)))
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD CHECK  (([noOfAppointments]>=(0)))
GO
ALTER TABLE [dbo].[CustomerType]  WITH CHECK ADD  CONSTRAINT [CK__CustomerTy__name__18EBB532] CHECK  (([name] like '%[^ ]%' AND [name] like '%[A-Za-z0-9 ]%' AND len([name])>=(3)))
GO
ALTER TABLE [dbo].[CustomerType] CHECK CONSTRAINT [CK__CustomerTy__name__18EBB532]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([password])>=(8) AND len([password])<=(20) AND [password] like '%[A-Z]%' AND [password] like '%[a-z]%' AND [password] like '%[0-9]%' AND [password] like '%[!@#$%^&*()]%'))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  (([salary]>=(0)))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([username])>=(3) AND len([username])<=(20) AND NOT [username] like '%[^a-zA-Z0-9_.#@]%' AND NOT [username] like ' %' AND NOT [username] like '% '))
GO
ALTER TABLE [dbo].[EmployeeAttendance]  WITH CHECK ADD CHECK  (([attendanceStatus]>(0)))
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD CHECK  (([amount]>(0)))
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD CHECK  (([attendancePercentage]>=(0)))
GO
ALTER TABLE [dbo].[EmployeeSalary]  WITH CHECK ADD CHECK  (([fine]>=(0)))
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD CHECK  (([message] like '%[^ ]%'))
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  (([address] like '%[^ ]%' AND [address] like '%[A-Za-z0-9#.-]%' AND len([address])>=(5)))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  ((NOT [city] like ' %' AND NOT [city] like '% ' AND NOT [city] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  ((NOT [country] like ' %' AND NOT [country] like '% ' AND NOT [country] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  (([email] like '%@%.com'))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  ((len([name])>=(3) AND NOT [name] like ' %' AND NOT [name] like '% ' AND NOT [name] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD CHECK  ((len([phone])=(11) AND NOT [phone] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  ((len([name])>=(3) AND NOT [name] like ' %' AND NOT [name] like '% ' AND NOT [name] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([price]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD CHECK  (([restocklevel]>=(0)))
GO
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD CHECK  (([description] like '%[^ ]%'))
GO
ALTER TABLE [dbo].[ProductType]  WITH CHECK ADD CHECK  ((NOT [type] like ' %' AND NOT [type] like '% ' AND NOT [type] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD CHECK  (([price]>=(0)))
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
ALTER TABLE [dbo].[ReturnedProducts]  WITH CHECK ADD CHECK  ((len([reason])>=(5) AND NOT [reason] like ' %' AND NOT [reason] like '% ' AND NOT [reason] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[SalonSalary]  WITH CHECK ADD CHECK  (([month]>=(1) AND [month]<=(12)))
GO
ALTER TABLE [dbo].[SalonSalary]  WITH CHECK ADD CHECK  (([year]>=(2023)))
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD CHECK  (([description] like '%[^ ]%'))
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD CHECK  ((len([name])>=(5) AND NOT [name] like ' %' AND NOT [name] like '% ' AND NOT [name] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD CHECK  (([serviceCharges]>=(0)))
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD CHECK  (([timeDuration]>(0)))
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD CHECK  ((len([contact])=(11) AND NOT [contact] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD CHECK  ((len([name])>=(3) AND NOT [name] like ' %' AND NOT [name] like '% ' AND NOT [name] like '%[^a-zA-Z ]%'))
GO
ALTER TABLE [dbo].[UsedStock]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[addProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addProduct](

	@productname varchar(50),
    @product_type_name VARCHAR(255),
    @supplier_name VARCHAR(255),
    @company_name VARCHAR(255),
    @quantity INT,
    @price money,
    @restockLevel INT,
    @isdeleted INT,
	@createdOn dateTime,
	@updatedOn dateTime
)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    
    BEGIN TRANSACTION;

    -- Insert into Product table
    INSERT INTO Product (name, productType, supplierId, companyId, quantity, price, restocklevel, createdOn, isDeleted,updatedOn)
    VALUES 
    (
        @productname,
        (SELECT id FROM ProductType WHERE type = @product_type_name),
        (SELECT id FROM Supplier WHERE name = @supplier_name),
        (SELECT id FROM Company WHERE name = @company_name),
        @quantity,
        @price,
        @restockLevel,
        @createdOn,
        @isdeleted,
		@updatedOn
    );

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[AddService]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddService]
    @Name NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @ServiceCharges DECIMAL(18, 2),
    @TimeDuration DECIMAL(5, 2),
    @ServiceTypeId INT,
	@createdOn DateTime,
	@updatedOn DateTime,
    @IsDeleted INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Service (Name, Description, ServiceCharges, TimeDuration, ServiceTypeId, UpdatedOn, CreatedOn, IsDeleted)
    VALUES (@Name, @Description, @ServiceCharges, @TimeDuration, @ServiceTypeId, @updatedOn, @createdOn, @IsDeleted);
END
GO
/****** Object:  StoredProcedure [dbo].[CheckEmployeeInAppointments]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckEmployeeInAppointments]
    @empId INT
AS
BEGIN
    SET NOCOUNT ON;

    WITH Apps AS (
        SELECT DISTINCT appointmentId 
        FROM AppointmentDetails 
        WHERE employeeId = @empId
    )
    SELECT a.Id 
    FROM Appointment a  
    WHERE a.id IN (SELECT appointmentId FROM Apps) 
    AND a.status = (SELECT lookupId FROM Lookup WHERE category = 'appstatus' AND value = 'pending') 
    AND CONVERT(datetime, a.Date + ' ' + a.startTime) <= GETDATE();
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCompany]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCompany]
    @CompanyName NVARCHAR(100),
    @UpdateDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    -- Update isDeleted flag for products associated with the company
    
    -- Delete the company
    UPDATE Company 
    SET isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes'), updatedOn = @UpdateDate
    WHERE name = @CompanyName;

    -- Update the update date for auditing purposes

    COMMIT;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeById]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEmployeeById]
    @EmployeeId INT
AS
BEGIN
    SET NOCOUNT ON;

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    BEGIN TRANSACTION;
        Update Person SET status = (SELECT lookupid FROM Lookup WHERE value = 'inactive' and category = 'status') WHERE id = @EmployeeId
		Update Employee SET updatedOn = GETDATE() WHERE personId = @EmployeeId
	COMMIT TRANSACTION;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSupplier]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSupplier]
    @CompanyName NVARCHAR(100),
    @UpdateDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    -- Update isDeleted flag for products associated with the company
  
    -- Delete the company
    UPDATE Supplier 
    SET isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'yes'), updatedOn = @UpdateDate
    WHERE name = @CompanyName;

    -- Update the update date for auditing purposes

    COMMIT;
END

GO
/****** Object:  StoredProcedure [dbo].[discardProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[discardProduct] (
    @productName NVARCHAR(50),
    @companyName NVARCHAR(100),
    @productType NVARCHAR(100),
    @quantity INT,
    @empId INT,
    @date DATETIME
	)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @productId INT;

    BEGIN TRANSACTION;
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    -- Retrieve the product ID
    SELECT @productId = id 
    FROM Product 
    WHERE name = @productName 
    AND companyId = (SELECT id FROM Company WHERE name = @companyName) 
    AND productType = (SELECT id FROM ProductType WHERE type = @productType);

    -- Insert data into the UsedStock table
    INSERT INTO UsedStock(productId, quantity, empId, useDate)
    VALUES (@productId, @quantity, @empId, @date);
	UPDATE Product
SET 
    quantity = quantity - @quantity
   
WHERE 
    id = @productId;


    COMMIT;
END
GO
/****** Object:  StoredProcedure [dbo].[expiryProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[expiryProduct]
AS
BEGIN
    SELECT 
        p.id AS ProductId,
        p.name AS ProductName,
        p.quantity AS Quantity,
        MAX(p.price) AS Price,
        s.name AS SupplierName,
        c.name AS CompanyName,
        pt.type AS ProductType,
		pr.expiryDate

    FROM 
        Product p
    LEFT JOIN 
        Purchase pr ON p.id = pr.productid
    JOIN 
        Supplier s ON p.supplierId = s.id
    JOIN 
        ProductType pt ON p.productType = pt.id
    JOIN 
        Company c ON p.companyId = c.id
    WHERE 
        pr.expirydate <= GETDATE() 
        AND p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no') 
    GROUP BY 
        p.id, p.name, p.quantity, s.name, c.name, pt.type, pr.expiryDate
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeAttendanceByDate]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeAttendanceByDate]
    @AttendanceDate DATE
AS
BEGIN
    SELECT Lookup.value as [Status], P.name, P.email, P.phone, SA.attendanceDate, SA.id AS attendanceID, P.id AS employeeID  
    FROM SalonAttendance SA 
    JOIN EmployeeAttendance EA ON EA.attendanceId = SA.id
    JOIN Employee E ON EA.employeeId = E.personId
    JOIN Person P ON E.personId = P.id
    JOIN Lookup ON EA.attendanceStatus = Lookup.lookupId
    WHERE CONVERT(date, SA.attendanceDate) = CONVERT(date, @AttendanceDate)
    AND EXISTS (
        SELECT 1 FROM SalonAttendance SA2
        WHERE CONVERT(date, SA2.attendanceDate) = CONVERT(date, @AttendanceDate)
    )
    AND P.status = (SELECT lookupId FROM Lookup WHERE category = 'status' AND value = 'active')
    AND P.role = ANY (SELECT lookupId FROM Lookup WHERE category = 'role' and value <> 'owner');
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeAttendanceReport]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetEmployeeAttendanceReport]
    @SelectedMonth DATE
AS
BEGIN
    SELECT 
        p.name AS EmployeeName, 
        p.phone, 
        p.email,
        COUNT(*) AS TotalAttendanceDays,
        SUM(CASE WHEN l.value = 'absent' THEN 1 ELSE 0 END) AS AbsentDays,
        SUM(CASE WHEN l.value = 'present' THEN 1 ELSE 0 END) AS PresentDays,
        SUM(CASE WHEN l.value = 'leave' THEN 1 ELSE 0 END) AS LeaveDays,
        SUM(CASE WHEN l.value = 'late' THEN 1 ELSE 0 END) AS LateDays,
        (SUM(CASE WHEN l.value = 'present' THEN 1 ELSE 0 END) + 
         SUM(CASE WHEN l.value = 'late' THEN 0.8 ELSE 0 END) + 
         SUM(CASE WHEN l.value = 'leave' THEN 0 ELSE 0 END) + 
         SUM(CASE WHEN l.value = 'absent' THEN 0 ELSE 0 END)) * 100.0 / COUNT(*) AS AttendancePercentage
    FROM 
        EmployeeAttendance ea
    JOIN 
        SalonAttendance sa ON sa.id = ea.attendanceId
    JOIN 
        Employee e ON ea.employeeId = e.personId
    JOIN 
        Person p ON e.personId = p.id
    JOIN 
        Lookup l ON ea.attendanceStatus = l.lookupId
    WHERE 
        MONTH(sa.attendanceDate) = MONTH(@SelectedMonth)
        AND YEAR(sa.attendanceDate) = YEAR(@SelectedMonth)
    GROUP BY 
        p.name, p.email, p.phone;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeSalariesByMonthYear]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeSalariesByMonthYear]
    @month INT,
    @year INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.id,
        P.name,
        P.email,
		E.salary,
        ISNULL(SA.attendancePercentage, 0) AS attendancePercentage,
        CASE WHEN ES.salaryId IS NOT NULL THEN 'yes' ELSE 'no' END AS isTransferred
    FROM 
        Person P
    LEFT JOIN 
        (
            SELECT 
                EA.employeeId,
                CAST(COUNT(*) AS DECIMAL) * 100.0 / (SELECT COUNT(*) FROM SalonAttendance WHERE CONVERT(date, attendanceDate) BETWEEN DATEFROMPARTS(@year, @month, 1) AND EOMONTH(DATEFROMPARTS(@year, @month, 1))) AS attendancePercentage
            FROM 
                EmployeeAttendance EA
            JOIN 
                SalonAttendance SA ON EA.attendanceId = SA.id
            WHERE 
                YEAR(SA.attendanceDate) = @year
            AND 
                MONTH(SA.attendanceDate) = @month
            AND 
                EA.AttendanceStatus IN (SELECT lookupId FROM Lookup WHERE category = 'attendanceStatus' AND value IN ('present', 'late'))
            GROUP BY 
                employeeId
        ) AS SA ON P.id = SA.employeeId
    LEFT JOIN 
        Employee E ON P.id = E.personId
    LEFT JOIN 
        EmployeeSalary ES ON P.id = ES.employeeId 
                            AND ES.salaryId IN (SELECT id FROM SalonSalary WHERE month = @month AND year = @year)
    WHERE 
        P.role <> (SELECT lookupId FROM Lookup WHERE category = 'role' AND value = 'owner')
    AND
        E.joiningDate <= DATEFROMPARTS(@year, @month, 1)
    AND 
        NOT EXISTS (SELECT 1 FROM EmployeeSalary WHERE employeeId = P.id AND salaryId IN (SELECT id FROM SalonSalary WHERE month = @month AND year = @year));
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeSalariesBySalaryId]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeSalariesBySalaryId]
    @salaryId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ES.employeeId,
        P.name,
        ES.transferredOn,
        ES.amount,
        ES.fine,
        ES.attendancePercentage
    FROM 
        EmployeeSalary ES
    JOIN 
        Person P ON ES.employeeId = P.id
    WHERE 
        ES.salaryId = @salaryId;
END
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeSalaryReport]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEmployeeSalaryReport]
    @SelectedMonth DATE
AS
BEGIN
    SELECT
        e.personId AS EmployeeId,
        p.name AS EmployeeName,
        Convert(Date, e.joiningDate) AS JoiningDate,
        es.transferredOn AS SalaryTransferredOn,
        es.amount AS MonthlyAssignedSalary,
        es.fine AS SalaryFine,
        es.attendancePercentage AS AttendancePercentage,
        CASE WHEN ss.id IS NULL THEN 0 ELSE es.amount - es.fine END AS AmountPaid
    FROM
        [DBFinalPID10].[dbo].[Employee] e
    LEFT JOIN
        [DBFinalPID10].[dbo].[Person] p ON e.personId = p.id
    LEFT JOIN
        [DBFinalPID10].[dbo].[EmployeeSalary] es ON e.personId = es.employeeId
        AND MONTH(e.joiningDate) <= MONTH(@SelectedMonth)
        AND YEAR(e.joiningDate) <= YEAR(@SelectedMonth)
    LEFT JOIN 
        SalonSalary ss ON es.salaryId = ss.id
    WHERE
        ss.month = MONTH(@SelectedMonth) AND ss.year = YEAR(@SelectedMonth);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductStock]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductStock]
AS
BEGIN
    SELECT
        p.id AS ProductId,
        p.name AS ProductName,
		Company.name AS CompanyName,
		Supplier.name AS SupplierName,
		Supplier.contact AS SupplierContact,
        p.quantity - ISNULL(rt.TotalReturned, 0) - ISNULL(ud.TotalUsed, 0) - ISNULL(sl.TotalSold, 0) AS TotalInStock
    FROM
        [DBFinalPID10].[dbo].[Product] p
    LEFT JOIN (
        SELECT productId, SUM(quantity) AS TotalReturned
        FROM [DBFinalPID10].[dbo].[ReturnedProducts]
        GROUP BY productId
    ) rt ON p.id = rt.productId
    LEFT JOIN (
        SELECT productId, SUM(quantity) AS TotalUsed
        FROM [DBFinalPID10].[dbo].[UsedStock]
        GROUP BY productId
    ) ud ON p.id = ud.productId
    LEFT JOIN (
        SELECT od.productId, SUM(pur.quantity) AS TotalSold
        FROM [DBFinalPID10].[dbo].[OrderDetails] od
        JOIN [DBFinalPID10].[dbo].[Purchase] pur ON od.id = pur.orderid
        WHERE pur.status = ANY (SELECT lookupId FROM Lookup WHERE category = 'orderstatus' AND (value = 'completed' OR value = 'partiallycompleted'))
        GROUP BY od.productId
    ) sl ON p.id = sl.productId
	JOIN Company ON p.companyId = Company.id
	JOIN Supplier ON p.supplierId = Supplier.id
    WHERE p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no');
END;
GO
/****** Object:  StoredProcedure [dbo].[GetSalonAttendance]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalonAttendance]
    @AttendanceDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT P.name, P.email, P.phone, E.joiningDate, SA.attendanceDate, SA.id AS attendanceID, P.id AS employeeID  
    FROM SalonAttendance SA, Employee E 
    INNER JOIN Person P ON E.personId = P.id
    WHERE CONVERT(date, SA.attendanceDate) = CONVERT(date, @AttendanceDate)
    AND CONVERT(date, E.joiningDate) <= attendanceDate
    AND P.status = (SELECT lookupId FROM Lookup WHERE category = 'status' AND value = 'active')
    AND P.role = ANY(SELECT lookupId FROM Lookup WHERE category = 'role' AND value <> 'owner')
END
GO
/****** Object:  StoredProcedure [dbo].[InsertEmployeeSalary]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEmployeeSalary]
    @EmployeeId INT,
    @SalaryId INT,
    @TransferredOn DATETIME,
    @Amount DECIMAL(10, 2),
    @Fine DECIMAL(10, 2),
    @AttendancePercentage DECIMAL(5, 2)
AS
BEGIN
    SET NOCOUNT ON;
	Set Transaction Isolation level serializable;
    BEGIN TRANSACTION; -- Start the transaction

    BEGIN TRY
        INSERT INTO EmployeeSalary (employeeId, salaryId, transferredOn, amount, fine, attendancePercentage)
        VALUES (@EmployeeId, @SalaryId, @TransferredOn, @Amount, @Fine, @AttendancePercentage);

        COMMIT TRANSACTION; -- Commit the transaction
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; -- Rollback the transaction in case of error
        THROW; -- Raise the error to the caller
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertInSalonSalary]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertInSalonSalary]
    @Month INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM SalonSalary WHERE month = @Month AND year = @Year)
    BEGIN
        INSERT INTO SalonSalary (month, year)
        VALUES (@Month, @Year);

        SELECT SCOPE_IDENTITY() AS NewSalaryID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertReturnedProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertReturnedProduct]

    @ProductName NVARCHAR(100),
    @ProductType NVARCHAR(100),
    @Company NVARCHAR(100),
    @Quantity INT,
    @Reason VARCHAR(max),
    @ReceivedBy int,
    @ReceivedOn DATETIME,
    
    @Status int,
	@orderId int
AS
BEGIN
    SET NOCOUNT ON;

    -- Declare variables
    DECLARE @ProductID INT;

    -- Start transaction
    BEGIN TRANSACTION;

    -- Extract product ID based on provided details
    SELECT @ProductID = id 
    FROM Product 
    WHERE name = @ProductName 
    AND companyId = (SELECT id FROM Company WHERE name = @Company) 
    AND supplierId = (SELECT id FROM Supplier WHERE name = @ProductType);

    -- Insert into ReturnedProducts table
    INSERT INTO ReturnedProducts (orderId,productId, quantity, reason, returnedBy, returnDate,  status)
    VALUES (@orderId,@ProductID, @Quantity, @Reason, @ReceivedBy, @ReceivedOn,  @Status);

		UPDATE Product
SET 
    quantity = quantity - @quantity
   
WHERE 
    id = @productId;
    -- Commit transaction
    COMMIT TRANSACTION;
END;

GO
/****** Object:  StoredProcedure [dbo].[orderProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create a stored procedure with serializable transaction
CREATE PROCEDURE [dbo].[orderProduct] (
    @productName NVARCHAR(100),
	@quantity INT,
	@productType NVARCHAR(100),
    @companyName NVARCHAR(100),
    @receivedBy int,
	@isdeleted int,
    @receivedOn DATETIME,
	@updatedOn DateTime
	
)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION;

    DECLARE @productId INT;

    -- Retrieve the Product ID based on provided details
    SELECT @productId = id 
    FROM Product 
    WHERE name = @productName 
    AND companyId = (SELECT id FROM Company WHERE name = @companyName) 
    AND productType = (SELECT id FROM ProductType WHERE type = @productType);

    -- Insert into OrderProduct table
    INSERT INTO OrderDetails(productId, quantity,  empId, createDate, isDeleted, updatedOn)
    VALUES (@productId, @quantity, @receivedBy, @receivedOn, @isdeleted, @updatedOn);

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[outOfStock]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[outOfStock]
AS
BEGIN
    SELECT 
        p.id AS ProductId,
        p.name AS ProductName,
        p.quantity AS Quantity,
        p.price AS Price,
        s.name AS SupplierName,
        c.name AS CompanyName,
        pt.type AS ProductType,
        p.restocklevel AS RestockLevel
        
    FROM 
        Product p
    JOIN 
        Supplier s ON p.supplierId = s.id
    JOIN 
        ProductType pt ON p.productType = pt.id
    JOIN 
        Company c ON p.companyId = c.id
    WHERE 
        p.quantity = 0 
        AND p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no')
END
GO
/****** Object:  StoredProcedure [dbo].[purchaseProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[purchaseProduct]
    @orderId INT,
    @productId INT,
    @receivedBy INT,
    @receivedOn DATETIME,
    @quantity INT,
    @expiryDate DATETIME,
    @status INT,
    @price INT,
    @isdeleted INT
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION;

    -- Insert the purchase record
    INSERT INTO Purchase (orderId, productId, recivedby, recivedon, quantity, expiryDate, status, price, isdeleted)
    VALUES (@orderId, @productId, @receivedBy, @receivedOn, @quantity, @expiryDate, @status, @price, @isdeleted);

    -- Update the quantity of the product
		UPDATE Product
		SET 
			quantity = quantity + @quantity,
			price = @price
		WHERE 
			id = @productId;

    COMMIT TRANSACTION;
END;

GO
/****** Object:  StoredProcedure [dbo].[SearchRecords]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchRecords]
    @ColumnName NVARCHAR(100),
    @Value NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQLQuery NVARCHAR(MAX);

    IF @ColumnName = 'expiry'
    BEGIN
        SET @SQLQuery = 'SELECT p.id AS ProductId,
                                p.name AS ProductName,
                                p.quantity AS Quantity,
                                MAX(p.price) AS Price,
                                s.name AS SupplierName,
                                c.name AS CompanyName,
                                pt.type AS ProductType,
                                p.restocklevel AS RestockLevel,
                                p.createdOn AS CreatedOn,
		                        p.updatedOn AS UpdatedOn
                         FROM Product p
                         LEFT JOIN Purchase pr ON p.id = pr.productid
                         JOIN Supplier s ON p.supplierId = s.id
                         JOIN ProductType pt ON p.productType = pt.id
                         JOIN Company c ON p.companyId = c.id
                         WHERE pr.expirydate <= GETDATE() AND p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = ''isdeleted'' AND value = ''no'') 
                         GROUP BY p.id, p.quantity, p.name';
    END
    ELSE IF @ColumnName = 'out of stock'
    BEGIN
        SET @SQLQuery = 'SELECT p.id AS ProductId,
                                p.name AS ProductName,
                                p.quantity AS Quantity,
                                p.price AS Price,
                                s.name AS SupplierName,
                                c.name AS CompanyName,
                                pt.type AS ProductType,
                                p.restocklevel AS RestockLevel,
                                p.createdOn AS CreatedOn,
		                        p.updatedOn AS UpdatedOn
                         FROM Product p
                         JOIN Supplier s ON p.supplierId = s.id
                         JOIN ProductType pt ON p.productType = pt.id
                         JOIN Company c ON p.companyId = c.id
                         WHERE p.quantity = 0 AND p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = ''isdeleted'' AND value = ''no'')';
    END
    ELSE
    BEGIN
        SET @SQLQuery = 'SELECT p.id AS ProductId,
                                p.name AS ProductName,
                                p.quantity AS Quantity,
                                p.price AS Price,
                                s.name AS SupplierName,
                                c.name AS CompanyName,
                                pt.type AS ProductType,
                                p.restocklevel AS RestockLevel,
                                p.createdOn AS CreatedOn,
		                        p.updatedOn AS UpdatedOn
                         FROM Product p
                         JOIN Supplier s ON p.supplierId = s.id
                         JOIN ProductType pt ON p.productType = pt.id
                         JOIN Company c ON p.companyId = c.id
                         WHERE ';

        SET @SQLQuery = @SQLQuery +
            CASE 
                WHEN @ColumnName = 'name' THEN 'p.name LIKE ''%' + @Value + '%'''
                WHEN @ColumnName = 'quantity' THEN 'p.quantity = ' + @Value
                WHEN @ColumnName = 'restock level' THEN 'p.restocklevel = ' + @Value
                WHEN @ColumnName = 'supplier name' THEN 's.name LIKE ''%' + @Value + '%'''
                WHEN @ColumnName = 'product type' THEN 'pt.type LIKE ''%' + @Value + '%'''
                WHEN @ColumnName = 'company name' THEN 'c.name LIKE ''%' + @Value + '%'''
            END;
        
        SET @SQLQuery = @SQLQuery + ' AND p.isDeleted = (SELECT lookupId FROM Lookup WHERE category = ''isdeleted'' AND value = ''no'')';
    END

    EXEC sp_executesql @SQLQuery;
END

GO
/****** Object:  StoredProcedure [dbo].[stpAddAppointment]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpAddAppointment]
@customerId int,
@startTime nvarchar(20),
@date nvarchar(20),
@AppId int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Set Transaction Isolation level serializable;
	Begin Transaction
	
	INSERT INTO Appointment(customerId, startTime, date, status, isDeleted) VALUES(@customerId, @startTime, @date, (SELECT lookupid FROM lookup Where value = 'pending'), (SELECT lookupid from lookup Where value = 'no'))
	SET @AppId = SCOPE_IDENTITY();

	Commit Transaction
END

GO
/****** Object:  StoredProcedure [dbo].[stpAddCustomer]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpAddCustomer]
@name nvarchar(50),
@email nvarchar(30),
@address nvarchar(50),
@city nvarchar(30),
@country nvarchar(30),
@phone nvarchar(30),
@gender nvarchar(10),
@addedBy int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Set Transaction Isolation level serializable;
	Begin Transaction
		Insert into Person(name, email, address, city, country, phone,status, gender, role ) Values(@name, @email,@address, @city, @country, @phone,1, @gender, (SELECT lookupId from Lookup where value = 'customer'));
		Insert into Customer(personid, customerTypeid, addedby, createdon) Values((SELECT id From Person Where name = @name and email= @email),1,@addedBy,getdate());
	Commit Transaction;
END
GO
/****** Object:  StoredProcedure [dbo].[stpAddCustomerType]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpAddCustomerType]
@name nvarchar(30),
@discountPercentage decimal(5,2),
@noOfAppointments int,
@addedby int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT into CustomerType(name, discountPercentage, noOfAppointments, createdBy, createdOn) VALUES (@name, @discountPercentage, @noOfAppointments, @addedby, getdate())
END

GO
/****** Object:  StoredProcedure [dbo].[stpAddEmployee]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpAddEmployee]
	@name nvarchar(50),
    @email nvarchar(30),
    @address nvarchar(50),
    @city nvarchar(30),
    @country nvarchar(30),
    @phone nvarchar(30),
    @gender nvarchar(10),
    @role nvarchar(30),
    @joiningDate datetime, 
	@salary money, 
	@username nvarchar(30),
	@password nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Set Transaction Isolation level serializable;
	Begin Transaction
		Insert into Person(name, email, address, city, country, phone,status, gender, role ) Values(@name, @email,@address, @city, @country, @phone,1, @gender, @role);
		Insert into Employee (personid,joiningDate, salary, username, updatedOn, password) Values((SELECT id From Person Where name = @name and email= @email), @joiningDate, @salary, @username,getdate(), @password)
	Commit Transaction;
END
GO
/****** Object:  StoredProcedure [dbo].[stpCancelAppointmentByAppId]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpCancelAppointmentByAppId] 
@appId int,
@employeeActive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Update Appointment SET status = (SELECT Lookupid FROM Lookup Where value = 'cancelled' AND category = 'appstatus'), updatedBy = @employeeActive, updatedOn = getdate() WHERE id = @appId
END

GO
/****** Object:  StoredProcedure [dbo].[stpCancelAppointmentBycustomerId]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[stpCancelAppointmentBycustomerId]
@customerId int,
@employeeActive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Update Appointment SET status = (SELECT Lookupid FROM Lookup Where value = 'cancelled' AND category = 'appstatus'), updatedBy = @employeeActive, updatedOn = getdate() WHERE customerId = @customerId
END

GO
/****** Object:  StoredProcedure [dbo].[stpDeleteCustomer]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpDeleteCustomer]
@id int,
@ownerActive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    BEGIN TRANSACTION;
        Update Person SET status = (SELECT lookupid FROM Lookup WHERE value = 'inactive' and category = 'status') WHERE id = @id

		Update Customer SET updatedBy = @ownerActive, updatedOn = GETDATE() WHERE personId = @id
	COMMIT TRANSACTION;

END
GO
/****** Object:  StoredProcedure [dbo].[stpDeleteCustomerType]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpDeleteCustomerType]
@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE CustomerType Where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[stpGetEmployeeById]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpGetEmployeeById]
    @EmployeeId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.name,
        P.email,
        P.address,
        P.city,
        P.country,
        P.phone,
        L1.value AS gender,
        L2.value AS role,
        E.username,
		E.password,
        E.salary,
        E.joiningDate,
        E.updatedOn
    FROM 
        dbo.Employee AS E
    INNER JOIN 
        dbo.Person AS P ON E.personId = P.id
    INNER JOIN 
        dbo.Lookup AS L1 ON P.gender = L1.lookupId AND L1.category = 'gender'
    INNER JOIN 
        dbo.Lookup AS L2 ON P.role = L2.lookupId AND L2.category = 'role'
    WHERE 
        P.id = @EmployeeId;
END
GO
/****** Object:  StoredProcedure [dbo].[stpGetProfitLossReport]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpGetProfitLossReport]
@Year int
AS
BEGIN
    -- Insert statements for procedure here
WITH AllMonths AS (
    SELECT 1 AS monthNumber
    UNION ALL
    SELECT monthNumber + 1
    FROM AllMonths
    WHERE monthNumber < 12
)

SELECT 
    DATENAME(month, DATEFROMPARTS(2024, AM.monthNumber, 1)) AS MonthName,
    ISNULL(App.[Number of Appointments], 0) AS [Number of Appointments],
    ISNULL(App.[Total amount], 0) AS [Total amount],
    ISNULL(Ex.[Order Expenditure],0) + ISNULL(SalaryExp.salary, 0) AS [Expenditure],
    ISNULL(App.[Total amount],0) - (ISNULL(Ex.[Order Expenditure],0) + ISNULL(SalaryExp.salary, 0)) AS [ProfitOrLoss]
FROM 
    AllMonths AM
LEFT JOIN
    (
        SELECT 
            COUNT(DISTINCT A.id) AS [Number of Appointments], 
            SUM(S.serviceCharges) AS [Total amount], 
            MONTH(A.date) AS [month]
        FROM 
            Appointment A
        JOIN 
            AppointmentDetails AD ON AD.appointmentId = A.id	
        JOIN 
            Service S ON S.id = AD.serviceId
        WHERE 
            YEAR(A.date) = @Year  
            AND A.status = ANY(
                SELECT 
                    lookupid 
                FROM 
                    lookup  
                WHERE 
                    value = 'completed'
                    AND category = 'appstatus'
            )
        GROUP BY 
            MONTH(A.date)
    ) AS App ON AM.monthNumber = App.[month]
	LEFT JOIN 
(SELECT SUM(ES.amount - ES.fine) [salary], SS.month [month]
							FROM EmployeeSalary ES 
							JOIN SalonSalary SS
							ON SS.id = ES.salaryId Group BY SS.MONTH) AS SalaryExp
ON AM.monthNumber = SalaryExp.[month]
LEFT JOIN
    (
        SELECT 
            MONTH(pu.recivedon) AS [month],
            SUM(Pu.price ) AS [Order Expenditure] 
        FROM 
            OrderDetails OD 
        JOIN 
            Purchase Pu ON Pu.orderid = OD.id
        WHERE 
            YEAR(pu.recivedon) = 2024  -- Filter by year
            AND Pu.status = ANY(
                SELECT 
                    lookupid 
                FROM 
                    lookup  
                WHERE 
                    (value = 'completed' OR value = 'partiallycompleted') 
                    AND category = 'orderstatus'
            )
        GROUP BY 
            MONTH(pu.recivedon)
    ) AS Ex ON AM.monthNumber = Ex.[month]


ORDER BY 
    AM.monthNumber;

END
GO
/****** Object:  StoredProcedure [dbo].[stpsetAppointmentCompleted]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpsetAppointmentCompleted]
@id int,
@employeeActive int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update Appointment SET status = (SELECT Lookupid FROM Lookup Where value = 'completed' AND category = 'appstatus'), updatedBy = @employeeActive, updatedOn = getdate() WHERE Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[stpUpdateCustomerType]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stpUpdateCustomerType]
@name nvarchar(30),
@discountPercentage decimal(5,2),
@appointments int,
@updatedBy int,
@id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update CustomerType SET name = @name, discountPercentage = @discountPercentage, noOfAppointments = @appointments, updatedBy = @updatedBy, updatedOn = GETDATE() WHERE id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[stpUpdateEmployee]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpUpdateEmployee]
    @id INT,
    @name NVARCHAR(50),
    @email NVARCHAR(30),
    @address NVARCHAR(50),
    @city NVARCHAR(30),
    @country NVARCHAR(30),
    @phone NVARCHAR(30),
    @gender NVARCHAR(10),
    @role NVARCHAR(30),
    @joiningDate DATETIME,
    @salary MONEY,
    @username NVARCHAR(30),
    @password NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    BEGIN TRANSACTION

    UPDATE Person
    SET
        name = @name,
        email = @email,
        address = @address,
        city = @city,
        country = @country,
        phone = @phone,
        gender = @gender,
        role = @role
    WHERE
        id = @id;

    UPDATE Employee
    SET
        joiningDate = @joiningDate,
        salary = @salary,
        username = @username,
        updatedOn = GETDATE(),
        [password] = @password
    WHERE
        personid = @id;

    COMMIT TRANSACTION;
END
GO
/****** Object:  StoredProcedure [dbo].[updateProduct]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateProduct]
(
    @productname varchar(50),
    @product_type_name VARCHAR(255),
    @supplier_name VARCHAR(255),
    @company_name VARCHAR(255),
    @quantity INT,
    @price money,
    @restockLevel INT,
    @isdeleted INT,
    @updatedOn dateTime
)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    
    BEGIN TRANSACTION;

    -- Update Product table
    UPDATE Product
    SET 
        name = @productname,
        productType = (SELECT id FROM ProductType WHERE type = @product_type_name),
        supplierId = (SELECT id FROM Supplier WHERE name = @supplier_name),
        companyId = (SELECT id FROM Company WHERE name = @company_name),
        quantity = @quantity,
        price = @price,
        restocklevel = @restockLevel,
        isDeleted = @isdeleted,
        updatedOn = @updatedOn
    WHERE 
        name = @productname;

    COMMIT TRANSACTION;
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateService]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateService]
    @ServiceId INT,
    @Name NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @ServiceCharges DECIMAL(18, 2),
    @TimeDuration DECIMAL(5, 2),
    @ServiceTypeId INT,
    @UpdatedOn DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Service
    SET
        name = @Name,
        description = @Description,
        serviceCharges = @ServiceCharges,
        timeDuration = @TimeDuration,
        serviceTypeId = @ServiceTypeId,
        updatedOn = @UpdatedOn
    WHERE
        id = @ServiceId;
END
GO
/****** Object:  StoredProcedure [dbo].[viewproducts]    Script Date: 5/14/2024 1:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[viewproducts]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.name AS ProductName,
        p.quantity AS Quantity,
        p.price AS Price,
        s.name AS SupplierName,
        c.name AS CompanyName,
        t.type AS ProductType,
        p.restocklevel AS RestockLevel,
        p.createdOn AS CreatedOn,
		p.updatedOn AS UpdatedOn
		
    FROM 
        product p
    JOIN 
        supplier s ON p.supplierId = s.id
    JOIN 
        company c ON p.companyId = c.id
    JOIN 
        producttype t ON p.productType = t.id
	join Lookup l on l.lookupId=p.isDeleted
    WHERE 
        p.isDeleted =(SELECT lookupId FROM Lookup WHERE category = 'isdeleted' AND value = 'no') 
END;

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "C"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 338
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCustomers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCustomers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "E"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 171
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "P"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 339
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "L1"
            Begin Extent = 
               Top = 343
               Left = 48
               Bottom = 485
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "L2"
            Begin Extent = 
               Top = 490
               Left = 48
               Bottom = 632
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_AllEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_AllEmployees'
GO
USE [master]
GO
ALTER DATABASE [DBFinalPID10] SET  READ_WRITE 
GO
