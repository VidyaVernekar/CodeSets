USE [ProjectDB]
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 
GO
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (1, N'Author')
GO
INSERT [dbo].[RoleMaster] ([RoleId], [RoleName]) VALUES (2, N'Reader')
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTable] ON 
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (2, N'vidya', N'vid@gmail.com', N'sdf', 1, 1, N'Vidya', N'vernekar')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (3, N'VidyaNew', N'viyd@gmail.com', N'sdfg', 1, 1, N'Vidyarr', N'vernekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (4, N'vidya4', N'viyd@gmail.com', N'sdfg', 1, 1, N'Vidyarr', N'vernekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (5, N'vidya4', N'viyd@gmail.com', N'sdfg', 1, 1, N'Vidyarr', N'vernekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (6, N'vidssdya4', N'viydfd@gmail.com', N'sdsdfg', 1, 1, N'Viddfyarr', N'vernsdfekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (7, N'vidssdya4', N'viydfd@gmail.com', N'sdsdfg', 1, 1, N'Viddfyarr', N'vernsdfekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (8, N'vidssdya4', N'viydfd@gmail.com', N'sdsdfg', 1, 1, N'Viddfyarr', N'vernsdfekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (9, N'vidssdya4', N'viydfd@gmail.com', N'sdsdfg', 1, 1, N'Viddfyarr', N'vernsdfekarr')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (10, N'efsdf', N'stsdfsdring', N'dfsdf', 1, 1, N'stsdfring', N'stsdfring')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (11, N'efsdf', N'stsdfsdring', N'dfsdf', 1, 1, N'stsdfring', N'stsdfring')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (12, N'sdf', N'dsf', N's', 1, 1, N'dsf', N'sdf')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1012, N'name', N'vd@gmail.com', N'sdf', 2, NULL, N'd', N'b')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1013, N'name', N'vdm@gmail.com', N'mnb', 2, NULL, N'vd', N'vb')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1014, N'UserName', N'7priyankabhosale@gmail.com', N'password', 1, NULL, N'Priyanka', N'B')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1015, N'UserName', N'7priyankabhosale@gmail.com', N'password', 1, NULL, N'Priyanka', N'B')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1016, N'UserName', N'2216565@cognizant.com', N'password', 1, NULL, N'sasd', N'asd')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1017, N'UserName', N'7priyankabhosale@gmail.com', N'password', 1, NULL, N'Priyanka', N'B')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1018, N'UserName', N'2216565@cognizant.com', N'password', 1, NULL, N'sasd', N'asd')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1019, N'vidya', N'test@gmail.com', N'sdf', 1, NULL, N'test', N'data')
GO
INSERT [dbo].[UserTable] ([UserId], [UserName], [EmailId], [Password], [RoleId], [Active], [FirstName], [LastName]) VALUES (1020, N'manjula', N'man@gmail.com', N'sdf', 1, NULL, N'manjula', N'vernekar')
GO
SET IDENTITY_INSERT [dbo].[UserTable] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'comedy')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'drama')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1, N'Bookupdate', 1, CAST(5660.00 AS Decimal(18, 2)), N'publisher', 3, CAST(N'2022-09-04' AS Date), N'content', N'1', CAST(N'2022-09-04' AS Date), NULL, CAST(N'2022-09-04' AS Date), NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (2, N'zxcsdfd', 1, CAST(2323.00 AS Decimal(18, 2)), N'zcxzc', 4, CAST(N'2022-09-14' AS Date), N'xzczc', N'1', CAST(N'2022-09-14' AS Date), 4, CAST(N'2022-09-14' AS Date), 4)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (3, N'book3', 1, CAST(7980.00 AS Decimal(18, 2)), N'jgj', 4, CAST(N'2022-09-04' AS Date), N'content', N'1', CAST(N'2022-09-04' AS Date), NULL, CAST(N'2022-09-04' AS Date), NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (4, N'Bookupdate12', 1, CAST(5660.00 AS Decimal(18, 2)), N'publisher', 3, CAST(N'2022-09-04' AS Date), N'content', N'1', CAST(N'2022-09-04' AS Date), NULL, CAST(N'2022-09-04' AS Date), NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (5, N'Bookupdate1234', 1, CAST(5660.00 AS Decimal(18, 2)), N'publisher', 3, CAST(N'2022-09-04' AS Date), N'content', N'1', CAST(N'2022-09-04' AS Date), NULL, CAST(N'2022-09-04' AS Date), NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (6, N'new', 1, CAST(4560.00 AS Decimal(18, 2)), N'pub', 3, CAST(N'2022-09-05' AS Date), N'content', N'1', CAST(N'2022-09-05' AS Date), NULL, CAST(N'2022-09-05' AS Date), NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1007, N'sdf', 2, CAST(40000.00 AS Decimal(18, 2)), N'sdf', 2, CAST(N'2022-09-12' AS Date), N'dsfdsss', N'1', NULL, NULL, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1008, N'testBookName', NULL, CAST(34.00 AS Decimal(18, 2)), N'xpublish', NULL, NULL, N'34545', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1010, N'as', NULL, CAST(600.00 AS Decimal(18, 2)), N'd5', 2, NULL, N'Book contemts the data of Digital Book', NULL, NULL, 2, NULL, 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1012, N'testBookName', 1, CAST(600.00 AS Decimal(18, 2)), N'assa', NULL, NULL, N'aszx', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1014, N'testBookName', 1, CAST(600000.00 AS Decimal(18, 2)), N'd5', 2, CAST(N'2022-09-13' AS Date), N'aszx', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1015, N'testBookName', 1, CAST(5445.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-13' AS Date), N'content', NULL, NULL, 2, NULL, 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1016, N'testBookName', 1, CAST(600.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-13' AS Date), N'test content', NULL, NULL, 2, NULL, 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1017, N'sszx', 1, CAST(34454.00 AS Decimal(18, 2)), N'asdsad', NULL, CAST(N'2022-09-14' AS Date), N'Book contemts the data of Digital Book', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1018, N'sdf', 2, CAST(345.00 AS Decimal(18, 2)), N'sdsdf', 2, CAST(N'2022-09-14' AS Date), N'test content', N'1', NULL, NULL, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1019, N'testBookName', 1, CAST(23.00 AS Decimal(18, 2)), N'dsdf', 2, CAST(N'2022-09-14' AS Date), N'324sdacxxx', NULL, CAST(N'2022-09-14' AS Date), 2, CAST(N'2022-09-14' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1024, N'zX', 1, CAST(345.00 AS Decimal(18, 2)), N'ewr', 2, NULL, N'aszx', N'0', NULL, NULL, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1025, N'sdadasd', 1, CAST(345.00 AS Decimal(18, 2)), N'ewrew', 2, CAST(N'2022-09-14' AS Date), N'csaas', NULL, NULL, 2, NULL, 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1026, N'BookName', 2, CAST(800.00 AS Decimal(18, 2)), N'Publisher', 2, CAST(N'2022-09-14' AS Date), N'Content', N'true', CAST(N'2022-09-14' AS Date), 2, CAST(N'2022-09-14' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1027, N'TestName', 2, CAST(800.00 AS Decimal(18, 2)), N'TesterPublish', 2, CAST(N'2022-09-14' AS Date), N'Content', N'0', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1028, N'BookName', 1, CAST(809.00 AS Decimal(18, 2)), N'Publisher', 2, CAST(N'2022-09-17' AS Date), N'Contentt', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1029, N'BookName', 1, CAST(600.00 AS Decimal(18, 2)), N'testPublisher', 2, CAST(N'2022-09-17' AS Date), N'test content', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1030, N'BookName', 1, CAST(600.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-17' AS Date), N'Content', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1031, N'testBookName', 1, CAST(800.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-17' AS Date), N'csaas', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1035, N'testBookName', 1, CAST(800.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-17' AS Date), N'csaas', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1036, N'testBookName', 1, CAST(800.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-17' AS Date), N'csaas', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1037, N'testBookName', 1, CAST(34.00 AS Decimal(18, 2)), N'xpublish', 2, CAST(N'2022-09-17' AS Date), N'Book contemts the data of Digital Book', N'1', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-17' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1039, N'testBookName', 1, CAST(600.00 AS Decimal(18, 2)), N'testpublisher', 2, CAST(N'2022-09-17' AS Date), N'Book contemts the data of Digital Book', N'0', CAST(N'2022-09-17' AS Date), 2, CAST(N'2022-09-18' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1044, N'testBookName', 1, CAST(600.00 AS Decimal(18, 2)), N'd5', 2, CAST(N'2022-09-17' AS Date), N'Content', N'1', CAST(N'2022-09-17' AS Date), 2, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1045, NULL, NULL, NULL, NULL, 2, CAST(N'2022-09-18' AS Date), NULL, N'1', CAST(N'2022-09-18' AS Date), 2, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1046, N'testBookName', 2, CAST(34.00 AS Decimal(18, 2)), N'xpublish', 2, CAST(N'2022-09-18' AS Date), N'contectuh', N'1', CAST(N'2022-09-18' AS Date), 2, CAST(N'2022-09-18' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1047, N'testBookName', 1, CAST(34.00 AS Decimal(18, 2)), N'd5', 2, CAST(N'2022-09-18' AS Date), N'content', N'1', CAST(N'2022-09-18' AS Date), 2, NULL, NULL)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1048, N'testBookName', 1, CAST(34454.00 AS Decimal(18, 2)), N'd5', 2, CAST(N'2022-09-18' AS Date), N'dfiui', N'1', CAST(N'2022-09-18' AS Date), 2, CAST(N'2022-09-18' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1049, N'testBookName', 1, CAST(600.00 AS Decimal(18, 2)), N'33sd', 2, CAST(N'2022-09-18' AS Date), N'New Content', N'1', CAST(N'2022-09-18' AS Date), 2, CAST(N'2022-09-18' AS Date), 2)
GO
INSERT [dbo].[Book] ([BookId], [BookName], [CategoryId], [Price], [Publisher], [UserId], [PublishedDate], [Content], [Active], [CreatedDate], [Createdby], [ModifiedDate], [Modifiedby]) VALUES (1053, N'BookName', 1, CAST(600.00 AS Decimal(18, 2)), N'Publisher', 2, CAST(N'2022-09-20' AS Date), N'Content new ', N'0', CAST(N'2022-09-20' AS Date), 2, CAST(N'2022-09-20' AS Date), 2)
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
