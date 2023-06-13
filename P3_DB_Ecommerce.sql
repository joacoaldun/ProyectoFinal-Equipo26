--CREACION BD TP FINAL PROGRAMACION 3--
create DATABASE P3_ECOMMERCE_DB

GO
create table Marcas(
    Id int not null primary key identity (1,1),
    Descripcion varchar(50)

);
GO
create table Categorias(
    Id int not null primary key identity (1,1),
    Descripcion varchar(50)

);
go
create table Articulos(
    Id int not null primary key identity (1,1),
    Codigo varchar(50) not null,
    Nombre varchar(50) not null,
    Descripcion varchar (150) null,
    IdMarca int null,
    IdCategoria int null,
    Precio money null
)
go
create table Imagenes(
    Id int not null primary key identity (1,1),
    IdArticulo int not null,
    ImagenUrl varchar(1000) not null
)

go
insert into MARCAS values ('Sony'), ('Microsoft'), ('Nintendo'), ('HP'), ('Razer'),('Noganet'),('Edifier'),('Cooler Master'),('Logitech'), ('Redragon')
insert into CATEGORIAS values ('Consolas'),('Computadoras escritorio'), ('Notebook'), ('Accesorios'),('Videojuegos')
insert into ARTICULOS values 
('S01', 'Playstation 4', 'Con tu consola PlayStation 4 tendrás entretenimiento asegurado todos los días.', 1, 1, 200000),
('S02', 'Playstation 5', 'Con tu consola PlayStation 5 tendrás entretenimiento asegurado todos los días.', 1, 1, 300000),
('C03', 'Resident Evil 4 Remake', 'Salvando a Ashley por 10° vez.', 1, 5, 30000),
('D04', 'Teclado Redragon Yama K550', 'Gracias al rgb podrás ser mas habilidoso en los juegos', 10, 4, 30000),
('F05', 'Notebook', null, 4, 3, 300000)


insert into Imagenes values 
(1,'https://http2.mlstatic.com/D_NQ_NP_885600-MLA51045269675_082022-O.webp'),
(2,'https://images.fravega.com/f300/af1a88e0d12772f769e6f824a3cb236e.jpg.webp'),
(3,'https://http2.mlstatic.com/D_NQ_NP_880036-MLA53990748326_022023-O.webp'),
(4,'https://http2.mlstatic.com/D_NQ_NP_935185-MLA46504064329_062021-O.webp')



--SP LISTAR--
go
create procedure storedListar as
SELECT a.Id, Codigo, Nombre, a.Descripcion 
as DescripcionArticulo, 
Precio,m.Id as IdMarca, 
m.Descripcion as NombreMarca,
c.Id as IdCategoria, 
c.Descripcion as NombreCategoria, 
i.ImagenUrl as imagen,i.Id as IdImagen ,i.IdArticulo as idArticuloImagen from ARTICULOS a 
left join MARCAS m on a.IdMarca=m.Id 
left join CATEGORIAS c on a.IdCategoria=c.Id 
left join IMAGENES i on a.Id=i.IdArticulo

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