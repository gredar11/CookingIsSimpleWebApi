USE DB_Agilistas

GO
BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] ON;
INSERT INTO [Ingredients] ([Id], [IngredientDescription], [IngredientName])
VALUES (4, N'Orange', N'Pumpkin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] ON;
INSERT INTO [Ingredients] ([Id], [IngredientDescription], [IngredientName])
VALUES (5, N'Salty and green', N'Pickle');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] ON;
INSERT INTO [Ingredients] ([Id], [IngredientDescription], [IngredientName])
VALUES (6, N'Bugs Bunny likes it.', N'Carrot');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IngredientDescription', N'IngredientName') AND [object_id] = OBJECT_ID(N'[Ingredients]'))
    SET IDENTITY_INSERT [Ingredients] OFF;
GO

GO

COMMIT;
GO

