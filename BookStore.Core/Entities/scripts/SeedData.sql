USE [nonstopio]
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'DRAFT')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'PUBLISHED')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[bookitem] ON 

INSERT [dbo].[bookitem] ([Id], [Title], [Author], [Content], [StatusId], [ImageUrl], [Creation_Date], [Published_Date]) VALUES (1, N'title', N'author', N'content', 2, N'\images\OIP.jpg', CAST(N'2023-08-19T15:40:55.5466667' AS DateTime2), CAST(N'2023-08-19T15:40:55.5466667' AS DateTime2))
INSERT [dbo].[bookitem] ([Id], [Title], [Author], [Content], [StatusId], [ImageUrl], [Creation_Date], [Published_Date]) VALUES (2, N'The Idiot', N'FyodorDostoesky', N'A god like figure battling with worldly atrocities with pure heart', 2, N'\images\idiot.jpg', CAST(N'2023-08-24T17:38:00.0000000' AS DateTime2), CAST(N'2023-08-26T17:38:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[bookitem] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (1, N'test', N'test@test.com', N'$2a$11$H54S1moxST7MQkEkifYgve01AgNJjT1Tpla/wMYcVb6EVuDIPbJLO')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (2, N'satyam satyam goel', N'satyamgoyal9@gmail.com', N'$2a$11$F9jdWYIs3PehPnPCjeXK6uhlSpZGT9BEQtt3yNW4EZlf9LupPaJEe')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password]) VALUES (3, N'shiva', N'shivamgoyal26@gmail.com', N'$2a$11$QizeWGRXfQD5urRVK2wIHO2REOusja/jPyJD1V/VTjFPNAihxNx0K')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
