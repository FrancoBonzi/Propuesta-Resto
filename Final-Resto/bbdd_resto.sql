
USE MASTER
GO
CREATE DATABASE BBDD_Resto
GO
USE BBDD_Resto
GO





CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) CHECK (Rol IN ('Gerente', 'Mesero')) NOT NULL
);

INSERT INTO Usuarios (Nombre, Usuario, Contrasena, Rol) VALUES 
('Maxi Profe', 'maxiprograma', 'admin123', 'Gerente'),
('Luis Pérez', 'lperez', '123456', 'Mesero'),
('María Fernández', 'mfernandez', '123456', 'Mesero'),
('Juan López', 'jlopez', '123456', 'Mesero');




CREATE TABLE Mesas(
IdMesa INT NOT NULL PRIMARY KEY IDENTITY (1,1),
Numero INT NOT NULL UNIQUE,
IdMozo INT FOREIGN KEY REFERENCES Usuarios (Id),
Disponible INT NOT NULL DEFAULT 1,
Capacidad INT NOT NULL
);


CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
	Descripcion NVARCHAR(100) NOT NULL,
	Categoria NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
	StockActual INT NOT NULL ,
	StockMinimo INT NOT NULL
);


CREATE TABLE Pedidos (
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    IdMesa INT NOT NULL,
    IdMozo INT NOT NULL,
    FechaHora DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(50) DEFAULT 'Abierto', -- Estados: Abierto, Cerrado
    FOREIGN KEY (IdMesa) REFERENCES Mesas(IdMesa),
    FOREIGN KEY (IdMozo) REFERENCES Usuarios(Id)
);




CREATE TABLE DetallePedidos (
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal AS (Cantidad * PrecioUnitario) PERSISTED,
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);




INSERT INTO Productos (Nombre, Descripcion, Categoria, Precio, StockActual, StockMinimo) VALUES 

('Bruschetta', 'Pan tostado con tomate, ajo y albahaca', 'Entrada', 900.00, 1, 1),
('Provoleta', 'Queso provolone fundido con especias', 'Entrada', 1200.00,1, 1)),
('Empanadas Caprese', 'Masa rellena de tomate, mozzarella y albahaca', 'Entrada', 1100.00,1, 1),
('Lasagna Bolognesa', 'Láminas de pasta con carne, bechamel y queso', 'Plato Principal', 2500.00,1, 1),
('Risotto de Hongos', 'Arroz cremoso con champiñones y parmesano', 'Plato Principal', 2300.00,1, 1),
('Milanesa Napolitana', 'Milanesa con jamón, tomate y mozzarella', 'Plato Principal', 2200.00,1, 1),
('Tiramisú', 'Postre italiano con mascarpone y café', 'Postre', 1400.00,1, 1),
('Panna Cotta', 'Postre de crema con salsa de frutos rojos', 'Postre', 1300.00,1, 1),
('Profiteroles', 'Bocaditos rellenos de crema con chocolate', 'Postre', 1500.00,1, 1),
('Coca-Cola 500ml', 'Gaseosa cola original', 'Bebidas', 500.00,1, 1),
('Agua Mineral 500ml', 'Agua natural sin gas', 'Bebidas', 400.00,1, 1),
('Vino Malbec', 'Copa de vino tinto Malbec', 'Bebidas', 1800.00,1, 1),
('Aperol Spritz', 'Bebida con Aperol, Prosecco y soda', 'Bebidas', 1900.00,1, 1);
