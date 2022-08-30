
USE DB_Agilistas

GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Ingredients] (
    [Id] int NOT NULL IDENTITY,
    [IngredientName] nvarchar(max) NOT NULL,
    [IngredientDescription] nvarchar(250) NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Ingredients_Id] ON [Ingredients] ([Id]);
GO

GO

COMMIT;
GO

