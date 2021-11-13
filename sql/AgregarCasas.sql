-- Generar las casas
USE Hogwarts
GO

SET IDENTITY_INSERT [dbo].[Casas] ON 
GO
INSERT [dbo].[Casas] ([Id], [NombreCasa]) VALUES (1, N'Gryffindor')
GO
INSERT [dbo].[Casas] ([Id], [NombreCasa]) VALUES (2, N'Hufflepuff')
GO
INSERT [dbo].[Casas] ([Id], [NombreCasa]) VALUES (3, N'Ravenclaw')
GO
INSERT [dbo].[Casas] ([Id], [NombreCasa]) VALUES (4, N'Slytherin')
GO
SET IDENTITY_INSERT [dbo].[Casas] OFF
GO



-- Verificacion
SELECT * FROM Casas
