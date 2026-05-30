USE TallerMecanicoDb;
GO

DELETE FROM dbo.Trabajos;
DELETE FROM dbo.Vehiculos;

DBCC CHECKIDENT (N'dbo.Trabajos', RESEED, 0);
DBCC CHECKIDENT (N'dbo.Vehiculos', RESEED, 0);

SELECT N'Tablas Vehiculos y Trabajos limpias.' AS Resultado;
GO
