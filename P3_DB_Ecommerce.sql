--CREACION BD TP FINAL PROGRAMACION 3--
create DATABASE P3_ECOMMERCE_DB

use P3_ECOMMERCE_DB
GO
create table Marcas(
    Id int not null primary key identity (1,1),
    Descripcion varchar(50) null,
    ImagenUrl varchar(1000) not null

);
GO
create table Categorias(
    Id int not null primary key identity (1,1),
    Descripcion varchar(50) null

);

go
create table Articulos(
    Id int not null primary key identity (1,1),
    Codigo varchar(50) not null,
    Nombre varchar(50) not null,
    Descripcion varchar (150) null,
    IdMarca int null,
    IdCategoria int null,
    Precio money null,
    Estado bit null default 1
)
---JOACO! Para dropear la de articulos hay que dropear las de stock y fav por la FK...
-- drop table stock
-- drop table ListaFavoritos
-- drop table Articulos

go
create table Imagenes(
    Id int not null primary key identity (1,1),
    IdArticulo int not null,
    ImagenUrl varchar(1000) not null
)

go
insert into MARCAS values 
('Sony','https://historia-biografia.com/wp-content/uploads/2019/10/sony.jpg'), 
('Microsoft', 'https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RWCZER?ver=1433&q=90&m=6&h=195&w=348&b=%23FFFFFFFF&l=f&o=t&aim=true'), 
('Nintendo','https://1000marcas.net/wp-content/uploads/2019/12/Nintendo-Logo-PNG-1.png'), 
('HP','https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/HP_New_Logo_2D.svg/2048px-HP_New_Logo_2D.svg.png'), 
('Razer','https://hardwareviews.com/wp-content/uploads/2019/03/razer-logo.jpg'),
('Noganet','https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-thumbnail/s3/092019/noga.jpg?bhemwa3OZZKNvMmuKZeromyOdQMY1i2o&itok=C9fALjj4'),
('Edifier','https://events.channelpronetwork.com/sites/default/files/Edifier_logo_2016.jpg'),
('Cooler Master','https://cdn.worldvectorlogo.com/logos/cooler-master-logo.svg'),
('Logitech','https://logodownload.org/wp-content/uploads/2018/03/logitech-logo.png'), 
('Redragon','https://cdn.worldvectorlogo.com/logos/redragon.svg')

insert into CATEGORIAS values 
('Consolas'),
('Computadoras escritorio'),
('Notebook'),
('Accesorios'),
('Videojuegos')

insert into ARTICULOS values 
('S01', 'Playstation 4', 'Con tu consola PlayStation 4 tendrás entretenimiento asegurado todos los días.', 1, 1, 200000,1),
('S02', 'Playstation 5', 'Con tu consola PlayStation 5 tendrás entretenimiento asegurado todos los días.', 1, 1, 300000,1),
('C03', 'Resident Evil 4 Remake', 'Salvando a Ashley por 10° vez.', 1, 5, 30000,1),
('D04', 'Teclado Redragon Yama K550', 'Gracias al rgb podrás ser mas habilidoso en los juegos', 10, 4, 30000,1),
('F05', 'Notebook', null, 4, 3, 300000, 1),
('S05', 'Diablo IV', 'Otro juegazo', 1, 5, 300000, 1),
('S06', 'Street Fighter 6', 'Clasico', 1, 5, 300000, 1),
('S07', 'Joystick Ps4', 'Joystick', 1, 4, 300000, 1)

insert into Imagenes values 
(1,'https://http2.mlstatic.com/D_NQ_NP_885600-MLA51045269675_082022-O.webp'),
(2,'https://images.fravega.com/f300/af1a88e0d12772f769e6f824a3cb236e.jpg.webp'),
(3,'https://http2.mlstatic.com/D_NQ_NP_880036-MLA53990748326_022023-O.webp'),
(3,'https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/media/image/2023/01/resident-evil-4-2942734.jpg'),
(4,'https://http2.mlstatic.com/D_NQ_NP_935185-MLA46504064329_062021-O.webp'),
(6,'https://http2.mlstatic.com/D_NQ_NP_848738-MLA69844613350_062023-O.webp'),
(7,'https://http2.mlstatic.com/D_NQ_NP_827935-MLA69763347798_062023-O.webp'),
(8,'https://http2.mlstatic.com/D_NQ_NP_611053-MLA54979368420_042023-O.webp')




--SP LISTAR CON STOCK--
go
create procedure storedListar as
SELECT a.Id, Codigo, Nombre, a.Descripcion 
as DescripcionArticulo, a.Estado as Estado, 
Precio,m.Id as IdMarca, 
m.Descripcion as NombreMarca,
c.Id as IdCategoria, 
c.Descripcion as NombreCategoria, 
i.ImagenUrl as imagen,i.Id as IdImagen ,i.IdArticulo as idArticuloImagen , s.cantidad as Stock from ARTICULOS a 
left join MARCAS m on a.IdMarca=m.Id 
left join CATEGORIAS c on a.IdCategoria=c.Id 
left join IMAGENES i on a.Id=i.IdArticulo
left join stock s on a.Id=s.IdArticulo

--JUEGOS DE LA MARCA SONY
select A.nombre, M.Descripcion from Articulos A
inner join Marcas M on M.Id=A.IdMarca
inner join Categorias C on C.Id=A.IdCategoria
where M.Id=1 and C.Id=5

--CANTIDAD CATEGORIAS DE UNA MARCA--
select  count (distinct c.Id) from Categorias C 
inner join Articulos A on A.IdCategoria=C.Id
inner join Marcas M on M.Id=A.IdMarca
where M.Id=1


select id, descripcion, ImagenUrl from marcas



--------------------------------------------------
--TIPO 1= ADMIN, TIPO 2=CLIENTE
go
create table Usuarios(
    Id int not null primary key identity (1,1),
    Nombre varchar (30) not null,
    Apellido varchar(30) not null,
    Username varchar(30) not null,
    Pass varchar(20) not null,
    TipoAcceso int not null check(TipoAcceso=1 or TipoAcceso=2),
    Email varchar(30) not null,
    EstadoActivo bit default 1
)

go
CREATE TABLE Provincias(
    IDProvincia int not null primary key identity (1, 1),
    NombreProvincia varchar(50) not null
)
go
CREATE TABLE Localidades(
    IDLocalidad int not null primary key identity (1, 1),
    NombreLocalidad varchar(150) not null,
    IDProvincia int not null foreign key references Provincias(IDProvincia)
)

go
create table Domicilio(
    Id int not null primary key identity (1,1),
    IdLocalidad int not null foreign key references Localidades(IdLocalidad),
    CodigoPostal int not null, 
    Direccion varchar(30) not null,
    Vivienda varchar(20) not null,
    NumeroDepartamento varchar(10) null
)
go
create table Cliente(
    Id int not null foreign key references Usuarios(Id),
    Dni varchar(20) not null,
    FechaNacimiento DATE not null,
    IDDomicilio int null foreign key references Domicilio (Id),
    PRIMARY KEY (Id)
)
go
CREATE TABLE ListaFavoritos (
    IdCliente INT,
    IdArticulo INT,
    PRIMARY KEY (IdCliente, IdArticulo),
    FOREIGN KEY (IdCliente) REFERENCES Cliente(Id),
    FOREIGN KEY (IdArticulo) REFERENCES Articulos(Id)
)
GO
create table Stock(
    IdArticulo int foreign key references Articulos (Id),
    Cantidad int default 0,
    Primary key (IdArticulo)
)

-- drop table stock


---------------SP ARTICULOS-----------------
go
create PROCEDURE SpAgregarArticulo
@Nombre varchar(50),
@Codigo VARCHAR(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@Precio money,
@Estado bit
as
insert into Articulos values (@Nombre,@Codigo,@Descripcion,@IdMarca,@IdCategoria,@Precio,@Estado)


select * from Articulos
select * from Imagenes
select max(id) from Articulos


go
create Procedure SpModificarArticulo
@Nombre varchar(50),
@Codigo VARCHAR(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@Precio money,
@Id int,
@Estado bit
as
Update Articulos set Nombre = @Nombre, Codigo = @Codigo, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio, Estado=@Estado
where Id = @Id



select * from Articulos
select * from Imagenes
select max(id) from Articulos

-----------------SP STOCK-----------------
go 
create Procedure SPagregarStock
@Cantidad int,
@IdArticulo int
AS
INSERT INTO Stock (Cantidad, IdArticulo) VALUES (@Cantidad, @IdArticulo)

go
Create Procedure SPmodificarStock
@Cantidad int,
@IdArticulo int
as
Update Stock set Cantidad = @Cantidad
where IdArticulo = @IdArticulo

select * from articulos a 
left join stock s on s.IdArticulo= a.Id

insert into Stock values 
(1,0),
(2,0),
(3,0),
(4,0),
(5,0),
(6,0),
(7,0),
(8,0)

------BAJA FÍSICA-----
--HACER EL ALTER PARA BORRAS IMAGENES DE ARTICULO TAMBIEN.
go
create Procedure SPeliminarArticulo (
    @id int
)
As begin
    delete from Stock where idArticulo=@id
    delete from Articulos where id = @id
    delete from Imagenes where IdArticulo = @id
    END
go


--Modificamos la tabla Cliente para que no alla problema si no hay Domicilio vinculado
ALTER TABLE Cliente
ALTER COLUMN IDDomicilio int NULL;

ALTER TABLE Cliente
ADD CONSTRAINT FK_Cliente_Domicilio FOREIGN KEY (IDDomicilio) REFERENCES Domicilio(Id);




--INSERT PARA PROBAR LOS CLIENTES
INSERT INTO Usuarios (Nombre, Apellido, Username, Pass, TipoAcceso, Email)
VALUES ('John', 'Doe', 'johndoe', 'password123', 2, 'johndoe@example.com');

INSERT INTO Cliente (Id, Dni, FechaNacimiento, IDDomicilio)
VALUES (1, '123456789', '1990-01-01', null);


GO
--LISTAR LOS CLIENTES CON SP
alter PROCEDURE SPListarClientes
AS 
BEGIN
select U.id, Nombre, Apellido, Username, TipoAcceso, Email, Dni, FechaNacimiento, EstadoActivo, Pass, c.Validado,
c.CodigoValidacion, c.CodigoRecuperacion from Usuarios u
inner join Cliente c on U.Id = c.id
END

GO
--LISTAR LOS ADMINS CON SP
alter PROCEDURE SPListarAdmins
AS 
BEGIN
select U.id, Nombre, Apellido, Username, TipoAcceso, Email,EstadoActivo, Pass from Usuarios u
where u.TipoAcceso = 1
END

exec SPListarAdmins

GO
--INSERTO UN ADMIN

INSERT INTO Usuarios (Nombre, Apellido, Username, Pass, TipoAcceso, Email)
VALUES ('Joaquin', 'Aldun', 'AldunAdmin', 'password123', 1, 'joacoaldun@gmail.com');


GO

--SP PARA CREAR CLIENTES
alter PROCEDURE SPCrearCliente
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(30),
    @Username VARCHAR(30),
    @Pass VARCHAR(20),
    @TipoAcceso INT,
    @Email VARCHAR(30),
    @Dni VARCHAR(20),
    @FechaNacimiento DATE,
    @Estado BIT,
    @CodigoValidacion varchar(8)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insertar en la tabla Usuarios
        INSERT INTO Usuarios (Nombre, Apellido, Username, Pass, TipoAcceso, Email,EstadoActivo)
        VALUES (@Nombre, @Apellido, @Username, @Pass, @TipoAcceso, @Email,@Estado);
    
        -- Obtener el ID generado en la tabla Usuarios
        DECLARE @usuarioID INT;
        SET @usuarioID = SCOPE_IDENTITY();
    
        -- Insertar en la tabla Cliente utilizando el ID de la tabla Usuarios
        INSERT INTO Cliente (Id, Dni, FechaNacimiento, CodigoValidacion)
        VALUES (@usuarioID, @Dni, @FechaNacimiento, @CodigoValidacion);
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

select * from Usuarios u 
inner join cliente c on u.id=c.Id
GO
--SP PARA MODIFICAR CLIENTE
create PROCEDURE SPModificarCliente
    @Id INT,
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(30),
    @Username VARCHAR(30),
    @Email VARCHAR(30),
    @Dni VARCHAR(20),
    @FechaNacimiento DATE,
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Actualizar en la tabla Usuarios
        UPDATE Usuarios
        SET Nombre = @Nombre,
            Apellido = @Apellido,
            Username = @Username,
            Email = @Email,
            EstadoActivo = @Estado
        WHERE Id = @Id;
    
        -- Actualizar en la tabla Cliente utilizando el ID
        UPDATE Cliente
        SET Dni = @Dni,
            FechaNacimiento = @FechaNacimiento
        WHERE Id = @Id;
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;


go
--SP AGREGAR ADMIN
CREATE PROCEDURE SPCrearAdmin
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(30),
    @Username VARCHAR(30),
    @Pass VARCHAR(20),
    @TipoAcceso INT,
    @Email VARCHAR(30),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Insertar en la tabla Usuarios
        INSERT INTO Usuarios (Nombre, Apellido, Username, Pass, TipoAcceso, Email,EstadoActivo)
        VALUES (@Nombre, @Apellido, @Username, @Pass, @TipoAcceso, @Email,@Estado);
    
        

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

--SP MODIFICAR ADMIN
GO
CREATE PROCEDURE SPModificarAdmin
    @Id INT,
    @Nombre VARCHAR(30),
    @Apellido VARCHAR(30),
    @Username VARCHAR(30),
    @Email VARCHAR(30),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Actualizar en la tabla Usuarios
        UPDATE Usuarios
        SET Nombre = @Nombre,
            Apellido = @Apellido,
            Username = @Username,
            Email = @Email,
            EstadoActivo = @Estado
        WHERE Id = @Id;
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

--SP PARA LISTAR MAIL Y USERNAME NADA MAS
CREATE PROCEDURE SPListarMailYUsername
AS 
BEGIN
select Username, Email from Usuarios u


END
GO

EXEC SPListarMailYUsername


select * from Usuarios;
select * from cliente

delete from Usuarios where id>3


--Agregamos estado de validacion y codigoValidacion a cliente
ALTER TABLE Cliente
add Validado bit default 0,
CodigoValidacion varchar(8), 
CodigoRecuperacion varchar(8)

go
create procedure SP_ValidarCliente(
    @Id int
)
as
BEGIN
    update Cliente set Validado=1 where id=@Id
END

select * from Cliente

go 
create procedure SP_GenerarCodigoRecuperacion(
    @Id int,
    @Codigo varchar(8)
)
AS
BEGIN
    update Cliente set CodigoRecuperacion=@Codigo where id=@Id
END

go
create procedure SP_CambiarPass(
    @Id int,
    @Pass VARCHAR(20)
)
as
Begin
    update Usuarios set pass=@Pass where id=@Id
end


--TABLA MEDIOS DE PAGO..
create table MediosPago(
    Id int not null primary key identity(1,1),
    Nombre varchar(50) not null
)

INSERT INTO MediosPago (Nombre) VALUES ('Mercadopago');
INSERT INTO MediosPago (Nombre) VALUES ('Transferencia bancaria');


--INSERT DE PROVINCIAS

INSERT INTO Provincias VALUES
('Provincia de Buenos Aires'),
('CABA'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Córdoba'),
('Corrientes'),
('Entre Ríos'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquén'),
('Río Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santa Fe'),
('Santiago del Estero'),
('Tierra del Fuego'),
('Tucumán')

--INSERT DE LOCALIDADES
-- Provincia de Buenos Aires

INSERT INTO Localidades (NombreLocalidad, IDProvincia) VALUES ('25 de Mayo', 1);
INSERT INTO Localidades (NombreLocalidad, IDProvincia) VALUES ('9 de Julio', 1);

-- Provincia de CABA

INSERT INTO Localidades (NombreLocalidad, IDProvincia) VALUES ('Agronomía', 2);
INSERT INTO Localidades (NombreLocalidad, IDProvincia) VALUES ('Almagro', 2);

select * from provincias
select P.idProvincia, P.nombreProvincia from provincias P

select * from localidades

select idLocalidad, nombreLocalidad, idProvincia from localidades

GO
-- CREAMOS TABLAS NUEVAS
Create table Pedido(
Id int not null PRIMARY KEY IDENTITY(1,1),
IdEstadoPedido INT NOT NULL foreign key references EstadoPedido(IdEstadoPedido),
IdCliente INT NOT NULL foreign key references cliente(Id),
IdMedioPago INT NOT NULL foreign key references MediosPago(Id),
FechaPedido DATE NOT NULL,
EstadoPago bit not null DEFAULT 0,
ImporteTotal money not null check(ImporteTotal > = 0),
)

GO
Create table EstadoPedido(
IdEstadoPedido int not null PRIMARY key IDENTITY(1,1),
EstadoEnvio varchar(20) not null
)

GO

CREATE table ArticulosPedido(

    IdPedido INT not null,
    IdArticulo INT not null,
    Cantidad int not null
    PRIMARY KEY (IdPedido, IdArticulo),
    FOREIGN KEY (IdPedido) REFERENCES Pedido(Id),
    FOREIGN KEY (IdArticulo) REFERENCES Articulos(Id)
)


go


-- SP PARA GENERAR PEDIDOS

CREATE PROCEDURE SPGenerarPedido(

@IdEstadoPedido int,
@IdCliente int,
@IdMedioPago int,
@FechaPedido date,
@ImporteTotal Money
)
AS
BEGIN
 
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Actualizar en la tabla Usuarios
        INSERT INTO Pedido(IdEstadoPedido,IdCliente,IdMedioPago,FechaPedido,ImporteTotal)
        VALUES(@IdEstadoPedido,@IdCliente,@IdMedioPago,@FechaPedido,@ImporteTotal)
       
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

-- SP PARA GENERAR ARTICULOSPEDIDO(TABLAINTERMEDIA)


CREATE PROCEDURE SPGenerarArticulosPedido(

@IdPedido int,
@idArticulo int,
@Cantidad int
)
AS
BEGIN
 
    
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Actualizar en la tabla Usuarios
        INSERT INTO ArticulosPedido values(@IdPedido,@idArticulo,@Cantidad)
        
       
    
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshacer la transacción
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

select * from usuarios u inner join Cliente  c on  u.id = c.id

select * from usuarios

-- Insertar el estado RECIBIDO
INSERT INTO EstadoPedido (EstadoEnvio)
VALUES ('RECIBIDO');

-- Insertar el estado PREPARACION
INSERT INTO EstadoPedido (EstadoEnvio)
VALUES ('PREPARACION');

-- Insertar el estado ENCAMINO
INSERT INTO EstadoPedido (EstadoEnvio)
VALUES ('ENCAMINO');

-- Insertar el estado ENTREGADO
INSERT INTO EstadoPedido (EstadoEnvio)
VALUES ('ENTREGADO');

-- Insertar el estado CANCELADO
INSERT INTO EstadoPedido (EstadoEnvio)
VALUES ('CANCELADO');


GO
create procedure SPAgregarDomicilio(
    @IdLocalidad int,
    @CodigoPostal int,
    @Direccion varchar(30),
    @NumeroDepartamento varchar(10)

)
AS
BEGIN
begin TRY
    insert into Domicilio (IdLocalidad,CodigoPostal,Direccion,NumeroDepartamento,Vivienda)
    VALUES (@IdLocalidad,@CodigoPostal,@Direccion,@NumeroDepartamento,'a')
end TRY

begin CATCH
    THROW
end CATCH
END


GO
create procedure SPAgregarDomicilioCliente(
    @IdCliente int,
    @IDDomicilio int

)
AS
BEGIN
begin TRY
    update Cliente set IDDomicilio=@IDDomicilio where Id=@IdCliente
end TRY

begin CATCH
    THROW
end CATCH
END


--pruebas
--select * from usuarios
--select * from pedido
--select * from Localidades
--
--select MAX(id) as maxId from Domicilio
--
--select max(id) from pedido
--
--select * from Domicilio 
--select * from cliente