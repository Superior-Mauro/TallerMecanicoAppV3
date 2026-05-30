-- Tablas usadas por la aplicación: Vehiculos y Trabajos

USE TallerMecanicoDb;
GO

IF OBJECT_ID(N'dbo.Trabajos', N'U') IS NOT NULL
    DROP TABLE dbo.Trabajos;

IF OBJECT_ID(N'dbo.Vehiculos', N'U') IS NOT NULL
    DROP TABLE dbo.Vehiculos;
GO

CREATE TABLE dbo.Vehiculos
(
    Id            INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Vehiculos PRIMARY KEY,
    Placa         NVARCHAR(15)       NOT NULL,
    Cliente       NVARCHAR(120)      NOT NULL,
    Telefono      NVARCHAR(20)       NOT NULL DEFAULT (N''),
    Modelo        NVARCHAR(80)       NOT NULL,
    Problema      NVARCHAR(500)      NOT NULL,
    FechaRegistro DATETIME2(0)       NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT UQ_Vehiculos_Placa UNIQUE (Placa)
);
GO

CREATE TABLE dbo.Trabajos
(
    Id                    INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Trabajos PRIMARY KEY,
    Placa                 NVARCHAR(15)       NOT NULL,
    Mecanico              NVARCHAR(120)      NOT NULL,
    Descripcion           NVARCHAR(500)      NOT NULL,
    Estado                NVARCHAR(30)       NOT NULL,
    ServicioNombre        NVARCHAR(80)       NOT NULL,
    PrecioBase            DECIMAL(10, 2)     NOT NULL,
    TiempoBaseMinutos     INT                NOT NULL,
    CambioRefrigerante    BIT                NOT NULL DEFAULT (0),
    CambioLiquidoFrenos   BIT                NOT NULL DEFAULT (0),
    CambioBujias          BIT                NOT NULL DEFAULT (0),
    TotalPagar            DECIMAL(10, 2)     NOT NULL,
    TiempoEstimadoMinutos INT                NOT NULL,
    FechaRegistro         DATETIME2(0)       NOT NULL DEFAULT (SYSUTCDATETIME()),
    CONSTRAINT FK_Trabajos_Vehiculos FOREIGN KEY (Placa) REFERENCES dbo.Vehiculos (Placa)
);
GO

-- Consultas para ver los datos en SSMS:
-- SELECT * FROM Vehiculos;
-- SELECT * FROM Trabajos;
