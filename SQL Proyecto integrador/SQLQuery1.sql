use master
go
if exists(select * from sysdatabases  where name = 'restauranteInteligente')
DROP DATABASE restauranteInteligente
GO

create database restauranteInteligente
go

use restauranteInteligente

/*************************Mantenimiento tipo********************************/
create table TB_TIPO(
	CODIGO_TIPO int identity(1,1) primary key,
	DESCRIPCION_TIPO varchar(25),
	ESTADO_TIPO INT DEFAULT(1)
)
go

SELECT * FROM TB_TIPO
GO

create proc sp_AgregarTipo(@descripcion varchar(25))
as
begin
	insert into TB_TIPO (DESCRIPCION_TIPO,ESTADO_TIPO) values (@descripcion,DEFAULT)
end
go

exec sp_AgregarTipo 'ADMINISTRADO'
exec sp_AgregarTipo 'COCINA'
exec sp_AgregarTipo 'CLIENTE'

go

create proc sp_ListarTipo(@estado int)
as
begin
	select CODIGO_TIPO,DESCRIPCION_TIPO,ESTADO_TIPO from TB_TIPO where ESTADO_TIPO = @estado
end
go

EXEC sp_ListarTipo 0
EXEC sp_ListarTipo 1
GO


create proc sp_ListarTipoXId(@id int)
as
begin
	select CODIGO_TIPO,DESCRIPCION_TIPO,ESTADO_TIPO from TB_TIPO where CODIGO_TIPO= @id
end
go

EXEC sp_ListarTipoXId 1
GO

create proc sp_ActualizarTipo(@id int, @descripcion varchar(25))
as
begin
	update TB_TIPO set DESCRIPCION_TIPO = @descripcion where CODIGO_TIPO = @id
end
go

exec sp_ActualizarTipo 3,'ADMINISTRADOR'
go

EXEC sp_ListarTipo 0
GO

create proc sp_EliminarTipo(@id int)
as
begin
	update TB_TIPO set ESTADO_TIPO = 0 where CODIGO_TIPO = @id
end
go

EXEC sp_EliminarTipo 3
GO

EXEC sp_ListarTipoXId 3
GO

create proc sp_RestaurarTipo(@id int)
as
begin
	update TB_TIPO set ESTADO_TIPO = 1 where CODIGO_TIPO = @id
end
go

EXEC sp_RestaurarTipo 3
GO

EXEC sp_ListarTipoXId 3
GO
/*************************Mantenimiento tipo********************************/

/*************************Mantenimiento usuario********************************/
create table TB_USUARIO(
	CODIGO_USUARIO int identity(1,1) primary key,
	NOMBRE_USUARIO varchar(25) unique,
	PASSWORD_USUARIO VARBINARY(50),
	ESTADO_USUARIO int default(1),
	CODIGO_TIPO int references TB_TIPO
)
go

SELECT * FROM TB_USUARIO
GO

create proc sp_AgregarUsuario(@nombre varchar(25),@password char(8),@tipo int)
as
begin
	insert into TB_USUARIO (NOMBRE_USUARIO,PASSWORD_USUARIO,ESTADO_USUARIO,CODIGO_TIPO) values (@nombre,cast(@password as varbinary(50)),DEFAULT,@tipo)
end
go

exec sp_AgregarUsuario 'CLIENTE11','Aaaa123',1
exec sp_AgregarUsuario 'admin','admin123',1
exec sp_AgregarUsuario 'CLIENTE1','12345678',3
go

create proc sp_ListarUsuarioXTipo(@estado int,@tipo int)
as
begin
	select u.CODIGO_USUARIO as CODIGO_USUARIO,u.NOMBRE_USUARIO as NOMBRE_USUARIO,u.ESTADO_USUARIO as ESTADO_USUARIO,t.DESCRIPCION_TIPO as DESCRIPCION_TIPO
	from TB_USUARIO u inner join TB_TIPO t on u.CODIGO_TIPO=t.CODIGO_TIPO
	where ESTADO_USUARIO = @estado AND u.CODIGO_TIPO = @tipo
end
go

EXEC sp_ListarUsuarioXTipo 1,1
GO


create proc sp_ListarUsuarioXId(@id int)
as
begin
	select u.CODIGO_USUARIO as CODIGO_USUARIO,u.NOMBRE_USUARIO as NOMBRE_USUARIO,u.ESTADO_USUARIO as ESTADO_USUARIO,u.CODIGO_TIPO as CODIGO_TIPO,t.DESCRIPCION_TIPO as DESCRIPCION_TIPO
	from TB_USUARIO u inner join TB_TIPO t on u.CODIGO_TIPO=t.CODIGO_TIPO
	where u.CODIGO_USUARIO = @id
end
go

EXEC sp_ListarUsuarioXId 1
GO

create proc sp_ActualizarUsuario(@id int, @nombre varchar(25),@password char(8),@tipo int)
as
begin
	update TB_USUARIO set NOMBRE_USUARIO = @nombre, PASSWORD_USUARIO = CAST(@password as varbinary(50)),CODIGO_TIPO=@tipo where CODIGO_USUARIO = @id
end
go

exec sp_ActualizarUsuario 1,'COCINA1','12345678',2
go

EXEC sp_ListarUsuarioXId 1
GO

create proc sp_EliminarUsuario(@id int)
as
begin
	update TB_USUARIO set ESTADO_USUARIO = 0 where CODIGO_USUARIO = @id
end
go

EXEC sp_EliminarUsuario 1
GO

EXEC sp_ListarUsuarioXId 1
GO

create proc sp_RestaurarUsuario(@id int)
as
begin
	update TB_USUARIO set ESTADO_USUARIO = 1 where CODIGO_USUARIO = @id
end
go

EXEC sp_RestaurarUsuario 1
GO

EXEC sp_ListarUsuarioXId 1
GO


create proc sp_Login(@nombre varchar(25),@password char(8))
as
begin
	select u.CODIGO_USUARIO as CODIGO_USUARIO,u.NOMBRE_USUARIO as NOMBRE_USUARIO,u.ESTADO_USUARIO as ESTADO_USUARIO,u.CODIGO_TIPO as CODIGO_TIPO,t.DESCRIPCION_TIPO as DESCRIPCION_TIPO
	from TB_USUARIO u inner join TB_TIPO t on u.CODIGO_TIPO=t.CODIGO_TIPO
	where u.NOMBRE_USUARIO = @nombre and u.PASSWORD_USUARIO = cast(@password as varbinary(50))
end
go

EXEC sp_Login 'COCINA1','12345678'
GO
/*************************Mantenimiento usuario********************************/

/*************************Mantenimiento categoria********************************/
create table TB_CATEGORIA(
	CODIGO_CATEGORIA int identity(1,1) primary key,
	DESCRIPCION_CATEGORIA varchar(25),
	ESTADO_CATEGORIA int default(1)
)
go

SELECT * FROM TB_CATEGORIA
GO

create proc sp_AgregarCategoria(@descripcion varchar(25))
as
begin
	insert into TB_CATEGORIA(DESCRIPCION_CATEGORIA,ESTADO_CATEGORIA) values (@descripcion,DEFAULT)
end
go

exec sp_AgregarCategoria 'CRIOLLO'
exec sp_AgregarCategoria 'POSTRES'
exec sp_AgregarCategoria 'BEDIDAS'
exec sp_AgregarCategoria 'SOPA'
go

create proc sp_ListarCategoria(@estado int)
as
begin
	select CODIGO_CATEGORIA,DESCRIPCION_CATEGORIA,ESTADO_CATEGORIA from TB_CATEGORIA where ESTADO_CATEGORIA = @estado
end
go

EXEC sp_ListarCategoria 0
EXEC sp_ListarCategoria 1
GO


create proc sp_ListarCategoriaXId(@id int)
as
begin
	select CODIGO_CATEGORIA,DESCRIPCION_CATEGORIA,ESTADO_CATEGORIA from TB_CATEGORIA where CODIGO_CATEGORIA= @id
end
go

EXEC sp_ListarCategoriaXId 1
GO


create proc sp_ActualizarCategoria(@id int, @descripcion varchar(25))
as
begin
	update TB_CATEGORIA set DESCRIPCION_CATEGORIA = @descripcion where CODIGO_CATEGORIA = @id
end
go

exec sp_ActualizarCategoria 3,'BEBIDAS ALCOHOLICAS'
go

EXEC sp_ListarCategoriaXId 3
GO

create proc sp_EliminarCategoria(@id int)
as
begin
	update TB_CATEGORIA set ESTADO_CATEGORIA = 0 where CODIGO_CATEGORIA = @id
end
go

EXEC sp_EliminarCategoria 3
GO

EXEC sp_ListarCategoriaXId 3
GO

create proc sp_RestaurarCategoria(@id int)
as
begin
	update TB_CATEGORIA set ESTADO_CATEGORIA = 1 where CODIGO_CATEGORIA = @id
end
go

EXEC sp_RestaurarCategoria 3
GO

EXEC sp_ListarCategoriaXId 3
GO
/*************************Mantenimiento categoria********************************/
/*************************Mantenimiento platillo********************************/
create table TB_PLATILLO(
	CODIGO_PLATILLO int identity(1,1) primary key,
	NOMBRE_PLATILLO varchar(25),
	DESCRIPCION_PLATILLO varchar(500),
	PRECIO_PLATILLO DECIMAL(10,2),
	ESTADO_PLATILLO int default(1),
	CODIGO_CATEGORIA int references TB_CATEGORIA,
	IMAGEN_PLATILLO varchar(500)
)
go

SELECT * FROM TB_PLATILLO
GO

create proc sp_AgregarPlatillo(@nombre varchar(25),@descripcion varchar(500),@precio decimal(10,2),@categoria int,@imagen varchar(500))
as
begin
	insert into TB_PLATILLO (NOMBRE_PLATILLO,DESCRIPCION_PLATILLO,PRECIO_PLATILLO,ESTADO_PLATILLO,CODIGO_CATEGORIA,IMAGEN_PLATILLO) values (@nombre,@descripcion,@precio,DEFAULT,@categoria,@imagen)
end
go

exec sp_AgregarPlatillo 'Platillo1','Descripcion1',99.99,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg'
exec sp_AgregarPlatillo 'Platillo1','Descripcion1',99.99,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg'
go



create proc sp_ListarPlatilloXCategoria_Nombre(@estado int,@categoria int,@nombre varchar(25))
as
begin
	select p.CODIGO_PLATILLO as CODIGO_PLATILLO,p.NOMBRE_PLATILLO as NOMBRE_PLATILLO,p.DESCRIPCION_PLATILLO as DESCRIPCION_PLATILLO, p.PRECIO_PLATILLO as PRECIO_PLATILLO, p.ESTADO_PLATILLO  as ESTADO_PLATILLO,c.DESCRIPCION_CATEGORIA as DESCRIPCION_CATEGORIA
	from TB_PLATILLO p inner join TB_CATEGORIA c on p.CODIGO_CATEGORIA=c.CODIGO_CATEGORIA
	where ESTADO_PLATILLO = @estado AND p.CODIGO_CATEGORIA = @categoria AND P.NOMBRE_PLATILLO LIKE ('%'+@nombre+'%')
end
go

EXEC sp_ListarPlatilloXCategoria_Nombre 1,1,null
GO


create proc sp_ListarPlatilloXId(@id int)
as
begin
	select p.CODIGO_PLATILLO as CODIGO_PLATILLO,p.NOMBRE_PLATILLO as NOMBRE_PLATILLO,p.DESCRIPCION_PLATILLO as DESCRIPCION_PLATILLO, p.PRECIO_PLATILLO as PRECIO_PLATILLO, p.ESTADO_PLATILLO  as ESTADO_PLATILLO,c.CODIGO_CATEGORIA as CODIGO_CATEGORIA,c.DESCRIPCION_CATEGORIA as DESCRIPCION_CATEGORIA,p.IMAGEN_PLATILLO as IMAGEN_PLATILLO
	from TB_PLATILLO p inner join TB_CATEGORIA c on p.CODIGO_CATEGORIA=c.CODIGO_CATEGORIA
	where p.CODIGO_PLATILLO = @id
end
go

EXEC sp_ListarPlatilloXId 1
GO

create proc sp_ActualizarPlatillo(@id int,@nombre varchar(25),@descripcion varchar(500),@precio decimal(10,2),@categoria int,@imagen varchar(500))
as
begin
	update TB_PLATILLO set NOMBRE_PLATILLO = @nombre, DESCRIPCION_PLATILLO =@descripcion,PRECIO_PLATILLO=@precio,CODIGO_CATEGORIA=@categoria,IMAGEN_PLATILLO=@imagen where CODIGO_PLATILLO = @id
end
go

exec sp_ActualizarPlatillo 2,'Platillo2','Descripcion2',100,2,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg'
go

EXEC sp_ListarPlatilloXId 2
GO

create proc sp_EliminarPlatillo(@id int)
as
begin
	update TB_PLATILLO set ESTADO_PLATILLO = 0 where CODIGO_PLATILLO = @id
end
go

EXEC sp_EliminarPlatillo 2
GO

EXEC sp_ListarPlatilloXId 2
GO

create proc sp_RestaurarPlatillo(@id int)
as
begin
	update TB_PLATILLO set ESTADO_PLATILLO = 1 where CODIGO_PLATILLO = @id
end
go

EXEC sp_RestaurarPlatillo 2
GO

EXEC sp_ListarPlatilloXId 2
GO
/*************************Mantenimiento platillo********************************/

/*************************Mantenimiento pedido********************************/
create table TB_PEDIDO(
	CODIGO_PEDIDO int primary key,
	CODIGO_USUARIO int references TB_USUARIO,
	FECHA_PEDIDO DATE,
	ESTADO_PEDIDO INT DEFAULT(0),
	TOTAL_PEDIDO decimal(10,2)
)
go

create table TB_DETALLEPEDIDO(
	CODIGO_PEDIDO int REFERENCES TB_PEDIDO,
	CODIGO_PLATILLO int references TB_PLATILLO,
	PRECIO  decimal(10,2),
	CANTIDAD INT
	PRIMARY KEY(CODIGO_PEDIDO,CODIGO_PLATILLO)
)
go

SELECT * FROM TB_PEDIDO
GO
SELECT * FROM TB_DETALLEPEDIDO
GO

create proc sp_AgregarPedido(@usuario int,@total decimal(10,2))
as
declare @max int
begin

	select @max = ISNULL(max(CODIGO_PEDIDO)+1,1) from TB_PEDIDO 
	insert into TB_PEDIDO(CODIGO_PEDIDO,CODIGO_USUARIO,FECHA_PEDIDO,ESTADO_PEDIDO,TOTAL_PEDIDO) values (@max,@usuario,GETDATE(),DEFAULT,@total)
	select @max as CODIGO_PEDIDO
end
go

create proc sp_AgregarDetallePedido(@pedido int,@platillo int,@precio decimal(10,2),@cantidad int)
as
begin
	
	insert into TB_DETALLEPEDIDO(CODIGO_PEDIDO,CODIGO_PLATILLO,PRECIO,CANTIDAD) values (@pedido,@platillo,@precio,@cantidad)
end
go

exec sp_AgregarPedido 1,5000
go



create proc sp_ListarPedidosXEstado(@estado int)
as
begin
	select CODIGO_PEDIDO,u.CODIGO_USUARIO as CODIGO_USUARIO,u.NOMBRE_USUARIO as NOMBRE_USUARIO,ESTADO_PEDIDO,FECHA_PEDIDO,TOTAL_PEDIDO
	from TB_PEDIDO p inner join TB_USUARIO u on p.CODIGO_USUARIO = u.CODIGO_USUARIO
	where ESTADO_PEDIDO = @estado
end
go

EXEC sp_ListarPedidosXEstado 0
GO

create proc sp_ListarDetallePedido(@pedido int)
as
begin
	select CODIGO_PEDIDO,p.CODIGO_PLATILLO as CODIGO_PLATILLO,p.NOMBRE_PLATILLO as NOMBRE_PLATILLO,p.CODIGO_CATEGORIA as CODIGO_CATEGORIA,c.DESCRIPCION_CATEGORIA as DESCRIPCION_CATEGORIA,PRECIO,CANTIDAD
	from TB_DETALLEPEDIDO dp inner join TB_PLATILLO p on dp.CODIGO_PLATILLO = p.CODIGO_PLATILLO
	inner join TB_CATEGORIA c on p.CODIGO_CATEGORIA = c.CODIGO_CATEGORIA
	where  CODIGO_PEDIDO = @pedido
end
go

EXEC sp_ListarDetallePedido 2
GO

create proc sp_ListarPedidosXFechas(@fecha1 date,@fecha2 date)
as
begin

	select CODIGO_PEDIDO,u.CODIGO_USUARIO as CODIGO_USUARIO,u.NOMBRE_USUARIO as NOMBRE_USUARIO,ESTADO_PEDIDO,FECHA_PEDIDO,TOTAL_PEDIDO
	from TB_PEDIDO p inner join TB_USUARIO u on p.CODIGO_USUARIO = u.CODIGO_USUARIO
	where FECHA_PEDIDO between isnull(@fecha1,GETDATE()) and isnull(@fecha2,GETDATE())
end
go

EXEC sp_ListarPedidosXFechas '2018/10/01','2018/12/01'
GO

create proc sp_ActualizarEstadoPedido(@id int)
as
begin
	update TB_PEDIDO set ESTADO_PEDIDO = 1 where CODIGO_PEDIDO = @id
end
go

create table TB_TIPO_TARJETA(
	ID_TIPO_TARJETA int identity(1,1) primary key,
	NOMBRE_TIPO_TARJETA VARCHAR(20)
)
go

INSERT INTO TB_TIPO_TARJETA VALUES ('Visa')
INSERT INTO TB_TIPO_TARJETA VALUES ('MasterCard')
INSERT INTO TB_TIPO_TARJETA VALUES ('Discover')

select * from TB_TIPO_TARJETA
go

create table TB_TARJETA(
	ID_TARJETA int identity(1,1) primary key,
	ID_TIPO_TARJETA int foreign key references TB_TIPO_TARJETA,
	NUMERO_TARJETA VARCHAR(16),
	NOMBRE_TARJETA VARCHAR(50),
	SECURITY_CODE_TARJETA CHAR(3),
	MES_EXPIRACION_TARJETA CHAR(2),
	AÑO_EXPIRACION_TARJETA CHAR(4),
	TARJETA_HABILITADA BIT,
	LINEA_CREDITO DECIMAL(10,2),
	CREDITO_DISPONIBLE DECIMAL(10,2)
)
go
INSERT INTO TB_TARJETA VALUES (1,'1234567812345678','Adrian Matos','111','01','2021',1,100000,50000)
INSERT INTO TB_TARJETA VALUES (1,'1111111122222222','Jaime Medina','222','02','2022',1,100,50)
INSERT INTO TB_TARJETA VALUES (1,'2222222233333333','Roger duglio','333','03','2023',1,100,12)
go

create proc sp_GetTarjetaByInfo(@idTipoTarjeta int,@numeroTarjeta varchar(16),
@nombreTarjeta varchar(50),@securityCodeTarjeta char(3),
@mesExpiracionTarjeta char(2),@añoExpiracionTarjeta char(4))
as
begin
	select tar.NUMERO_TARJETA as NUMERO_TARJETA,tar.NOMBRE_TARJETA as NOMBRE_TARJETA,tar.TARJETA_HABILITADA as TARJETA_HABILITADA,tar.CREDITO_DISPONIBLE as CREDITO_DISPONIBLE
	from TB_TARJETA tar where tar.ID_TIPO_TARJETA = @idTipoTarjeta
	and tar.NUMERO_TARJETA = @numeroTarjeta
	and tar.NOMBRE_TARJETA = @nombreTarjeta
	and tar.SECURITY_CODE_TARJETA = @securityCodeTarjeta
	and tar.MES_EXPIRACION_TARJETA = @mesExpiracionTarjeta
	and tar.AÑO_EXPIRACION_TARJETA = @añoExpiracionTarjeta
end
go
exec sp_GetTarjetaByInfo 1,'1234567812345678','Adrian Matos','111','01','2021'
go
/*************************Mantenimiento pedido********************************/
select * from TB_PLATILLO
/********************************Data ***************************************/
execute dbo.sp_EliminarPlatillo '1';
execute dbo.sp_EliminarPlatillo '2';
execute dbo.sp_AgregarCategoria 'ENTRADAS'
use restauranteInteligente
--ENTREDAS--
INSERT INTO TB_PLATILLO VALUES('Anticuchos de Corazón','El anticucho es un tipo de brocheta de origen peruano, ​ que también es popular en algunos países sudamericanos con diferentes variaciones por país. Consiste en carne y otros alimentos que se asan ensartados en un pincho',10,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz Árabe','Receta de arroz árabe.Una receta clásica para acompañar carnes asadas y al horno, ideal para las cena de navidad o año nuevo.',4,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Camarones al Ajillo','Plato confeccionado a base de Camarones y Ajo. Género. Plato Principal de la cocina Internacional. Ingredientes. Camarones, Ajo, Mantequilla, Jugo de Limón',5,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Causa Rellena','La causa rellena es una receta sencilla de preparar, sin embargo suele resultar un tanto trabajosa porque se tiene que amasar la papa sancochada a mano. A continuación vamos a dar la relación de ingredientes. La cantidad de calorías indicada, es para 100 gramos.',3,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cebiche Mixto','El cebiche mixto o cebiche con mariscos es la expresión máxima de la riqueza marina que existe en la cocina peruana. Esta vez presentamos la receta más popular de la gastronomía inca, pero el abanico de posibilidades de ingredientes, es infinito.',3,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cebiche de Champiñones','Sabe muy bien elíjalo para su deguste',9,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cebiche de Pollo','Sabe muy bien elíjalo para su deguste',9,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Club Sandwich','Sabe muy bien elíjalo para su deguste',9,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Choclo con Mantequilla','Sabe muy bien elíjalo para su deguste',4,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Choritos a la Chalaca','Sabe muy bien elíjalo para su deguste',3,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Coliflor Gratinada','Sabe muy bien elíjalo para su deguste',7,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Croquetas de Atún','Sabe muy bien elíjalo para su deguste',9,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Conchitas a la Parmesana','Sabe muy bien elíjalo para su deguste',9,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Empanada Mixta','Sabe muy bien elíjalo para su deguste',8,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Empanadas','Sabe muy bien elíjalo para su deguste',4,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Encurtidos','Sabe muy bien elíjalo para su deguste',8,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ensalada Cesar','Sabe muy bien elíjalo para su deguste',4,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ensalada de Chonta','Sabe muy bien elíjalo para su deguste',3,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ensalada de Arroz Medit','Sabe muy bien elíjalo para su deguste',8,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ensalada de Pollo','Sabe muy bien elíjalo para su deguste',6,1,5,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')


--CRIOLLO--
INSERT INTO TB_PLATILLO VALUES('Adobo a la Norteña','Es un plato titpico del norte del Perú con algunas variantes.',17,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Adobo de Cerdo','El adobo es la inmersión de un alimento crudo en un preparado en forma de caldo (o salsa) de distintos componentes: pimentón(el más habitual), orégano, sal, ajos y vinagre, mezclados según el lugar de procedencia y alimento en el que se vaya a usar, destinado principalmente a conservar y realzar el alimento',16,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ají de Camarones','El ají de camarones es un plato delicioso muy representativo y que a muchas personas les gusta.',16,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ají de Champiñones','Este plato lo tenía escondido. Es también uno de los platos más famosos de la gastronomía peruana ',18,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ají de Gallina','El ají de gallina es un plato oriundo del Perú, consiste en un ají o crema espesa con pechuga de gallina deshilachada. Esta crema es servida con papas cocidas, y en ocasiones arroz blanco. Es usual reemplazar la gallina por pollo.',20,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ajiaco de Caiguas','Sabe muy bien elíjalo para su deguste',18,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Ajiaco de Ollucos','Sabe muy bien elíjalo para su deguste',16,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Albondigas','Sabe muy bien elíjalo para su deguste',10,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arrimado de Col','Sabe muy bien elíjalo para su deguste',14,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz Chaufa','Sabe muy bien elíjalo para su deguste',20,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz a la Jardinera','Sabe muy bien elíjalo para su deguste',15,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz con Chancho','Sabe muy bien elíjalo para su deguste',12,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz con Mariscos','Sabe muy bien elíjalo para su deguste',10,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz con Pato','Sabe muy bien elíjalo para su deguste',13,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz con Pollo','Sabe muy bien elíjalo para su deguste',16,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz Tapado','Sabe muy bien elíjalo para su deguste',20,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Asado de Carne','Sabe muy bien elíjalo para su deguste',12,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bistec a lo Pobre','Sabe muy bien elíjalo para su deguste',12,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bistec Apanado','Sabe muy bien elíjalo para su deguste',12,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cabrito Norteño','Sabe muy bien elíjalo para su deguste',18,1,1,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')




--SOPAS--
INSERT INTO TB_PLATILLO VALUES('Aguadito','Es una sopa de pollo tradicionalen la cocina peruana que consiste en pollo, cilantro y verduras',7,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cazuela de Gallina','Es un plato típico, sencillo y sabroso, en especial para el invierno. Se puede preparar con diversos tipos de carne, no obstante en la región se prepara con gallina criolla. Lleva zapallo, choclo, arvejas, zanahorias, papas, ajo, sal, perejil (opcional), apio y arroz.',10,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Caldo de Gallina','El caldo de pollo (denominado a veces como sopa de pollo o caldo de gallina) es una sopa.​ A menudo se sirve con trozos de carne o con granos de arroz o cebada, pasta, zanahoria amarilla, apio, cebolla blanca, etc.',9,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Chilcano de Pescado','El chilcano es un caldo o sopa muy consumido en la costa norte del Perú. que se prepara principalmente con la cabeza del pescado bonito, cochayuyo y bastante limón. Se consume preferentemente caliente. Tiene propiedades energéticas dada la gran cantidad de proteínas que contiene y tiene fama de “levanta muertos”',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Crema de Espárragos','La crema de espárragos verdes casera es una receta vegetariana muy colorida y con un sabor inigualable.  La crema se prepara con patatas, espárragos verdes y leche evaporada Ideal, tu alternativa a la nata, y se sirve fría o caliente con las puntas de los espárragos como decoración. ¡Simple y deliciosa!',9,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Crema de Zapallo','Sabe muy bien elíjalo para su deguste',8,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Espesado Chiclayano','Sabe muy bien elíjalo para su deguste',8,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Patasca','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Puchero a la Limeña','Sabe muy bien elíjalo para su deguste',9,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sancochado a la Limeña','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa a la Minuta','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa Criolla','Sabe muy bien elíjalo para su deguste',8,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa de Pallares','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa de Pollo','Sabe muy bien elíjalo para su deguste',7,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa Serrana','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa Shambar','Sabe muy bien elíjalo para su deguste',7,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa Teóloga','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa de Pollo Chun-Lee','Sabe muy bien elíjalo para su deguste',9,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa de Cebada y Hongos','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Sopa de Vegetales Tofu','Sabe muy bien elíjalo para su deguste',8,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')



--POSTRES--
INSERT INTO TB_PLATILLO VALUES('Alfajores con Manjarblnco','Alfajores artesanales de maicena y dulce de leche',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Alfajores de Miel','Esta tradicional masa es la preferida de miles de argentinos, aunque no podemos titularnos como los inventores, ya que como el turrón, el almíbar o el mazapán, el alfajor es un invento culinario antiquísimo de origen árabe. La palabra deriva del árabe “al-hasú” que significa “relleno”.',3,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz con Leche','Arroz con leche. Postre típico de la gastronomía de múltiples países hecho cociendo lentamente el arrozen leche con azúcar. Se come frío o caliente. Se le suele echar canela, vainilla o cáscara de limón para aromatizarlo.',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Arroz Zambito','El arroz zambito es un postre peruano, derivado del arroz con leche,  siendo el principal ingrediente la chancaca, el cual le otorga el característico color marrón, de ello la razón del nombre.',4,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bizcocho de Limón','Este postre es muy típico, sobre todo en Francia, y se ha hecho por abuelas durante generaciones. La parte de la historia que me gusta es que estas abuelas francesas miden los ingredientes del bizcocho con los tarros de yogur.',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bizcochos','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bocadillo de Dama','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Borrachitos','Sabe muy bien elíjalo para su deguste',3,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bombas de Sémola','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Borrachitos de Chocolate','Sabe muy bien elíjalo para su deguste',3,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Budín de Chancay','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Brownies','Sabe muy bien elíjalo para su deguste',4,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Budín Navideño','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Budin de Pan','Sabe muy bien elíjalo para su deguste',4,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Buñuelos','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cake Volteado de Piña','Sabe muy bien elíjalo para su deguste',6,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cachangas','Sabe muy bien elíjalo para su deguste',5,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Camote con Dulce','Sabe muy bien elíjalo para su deguste',3,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Camotillo','Sabe muy bien elíjalo para su deguste',4,1,4,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Champús de Guanábana','Sabe muy bien elíjalo para su deguste',5,1,2,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')


--BEBIDAS--
INSERT INTO TB_PLATILLO VALUES('Mojito','El mojito es el rey extraoficial de Cuba, y de medio mundo. Como la caipirinha, es uno de los combinados más populares del mundo, sobre todo en los últimos años en que ha experimentado un auge. Aunque a decir verdad, ya tiene sus años, porque se inventó en la época de la Ley Seca americana...',11,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Blue Hawaii','El primer Blue Hawaii lo hizo Harry Yee, el jefe de los barman del hotel Hilton Hawaiian Village en Waikiki. Yee tuvo que crear un cocktail de color azul cuando un representante de una conocida destilería le exigió una bebida con esa tonalidad, ya que estaba promocionando el Curaçao. Aunque la... ',11,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Margarita','Tequila, Triple sec o Cointreau, y zumo bien de limón, bien de lima. Hielo opcional, sal en los bordes del vaso también optativa. Hasta aquí la receta del margarita, posiblemente el cocktail de tequila más popular del mundo. Sus variantes tienen una pinta deliciosa, pero lo más curioso es el...',11,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Daiquiri','Pensar en Daiquiri es pensar en playa, palmeras, música, verano... es pensar en Cuba. Allí nace este cocktail que se pide en los bares de todo el mundo y que tiene como alcohol básico el ron blanco. El daiquiri debe su nombre a una playa cercana a Santiago de Cuba y su origen a un americano... ',12,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Cosmopolitan','Son varios nombres los que se disputan la creación del Cosmopolitan. Algunos creen que fue una comunidad gay de Provincetown (Massachussets), en los años 70. Otros creen que fue Neal Murray en su churrasquería Cork & Cleaver, en el año 1975. Un tercer grupo apuesta por Cheryl Cook, que en el año..',15,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Caipirinha','La caipirinha es uno de los cocktails más famosos del mundo, de origen brasileño pero muy extendido por todas partes en los últimos años. El ingrediente principal y básico es la cachaça, la bebida alcohólica destilada más popular de Brasil. Se trata de un aguardiente que se obtiene como producto...',10,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('White Russian','Ideal para después de cenar, el White Russian se hizo famoso entre la gente joven porque era la bebida favorita de The Dude, el protagonista de El Gran Lebowski. Hoy te enseñamos su receta. ¿De dónde puede ser un cocktail que se llama White Russian? De Rusia, ¿verdad? Pues no. Recibe ese... ',12,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Long Island Iced Tea','En el mundo de los cocktails, hay una combinación nefasta: buen sabor y buena cantidad de alcohol. Nefasta, claro, para tu estabilidad y para tu hígado, que es el principal damnificado de que algunas bebidas entren tan bien. El Long Island Iced Tea forma parte de ese grupo, así que vaya por...',15,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Bahama Mama','¿Harto de clásicos del verano como el mojito o la capirinha? Prueba con el dulce y exótico Bahama Mama, un cocktail que triunfa en el Caribe. Allí se lo beben dentro de cocos recién cogidos, aquí nos tendremos que conformar con un vaso alto... Bahama Mama no es sólo el título de una canción...',12,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Mojito Royal','Si existiera el rey de los cocktails, sin duda el mojito estaría entre los aspirantes a llevar la corona. Originario de Cuba, cuenta con millones de seguidores en todo el mundo gracias a su acertada mezcla de lima, menta y ron. Debido a ese éxito, no es extraño encontrar diversas variaciones a',15,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Mai Tai','El Mai Tai nació en el restaurante Trader Vic de Oakland (California) en el año 1944, aunque, como sucede con muchos cocktails, son varios los que se apuntan su autoría. Uno de ellos, antiguo rival del creador de Trader Vic, es Don the Beachcomber, que también disponía de varios restaurantes con... ',14,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Coco Loco','El mundo está dividido en dos tipos de personas: los que les gusta el coco y los que no tienen paladar. Para los primeros, os traemos la receta del Coco Loco, un refrescante cocktail veraniego con muchísimo sabor al fruto de la palmera. Del Coco Loco existen dos versiones, una que se sirve en...',14,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Oceans','La historia de este combinado es bastante peculiar, ya que nace como respuesta a un desafío de La Voz de Galicia a una serie de cocteleros de A Coruña, a los que se les propuso captar la esencia de la ciudad en un cocktail. El resultado gustó a los responsables de Santa Teresa, el alcohol... ',10,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('DVicio','Refrescante y de gustos tropicales, el DVicio fue uno de los cocktails estrella que se presentaron en el Taller de los Sentidos dentro del Salón de Gourmets 2011. Así que si quieres estar a la última en el mundo de los combinados, ¡aprende a hacer un DVicio! Del 11 al 14 de abril, la Feria...',8,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Manhattan','Su origen, evidentemente, hay que buscarlo en la isla de Manhattan, puro Nueva York. Y nos tenemos que remontar a la década de 1870, cuando en el Manhattan Club de la ciudad a alguien le dio por mezclar sus ingredientes en honor a una cena dada para el candidato presidencial de turno. La bebida... ',8,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Gintonic (x3)','Recetas de gintonic hay tantas como formas de escribir la propia palabra. ¿Gintonic? ¿Gin-Tonic? ¿Gin&Tonic? ¿GinTonic? Todas hacen referencia a lo mismo, a esa copa transparente llena de hielo que mezcla ginebra y tónica, pero hay pequeños detalles que las diferencian. Igual que sus recetas... ',7,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Zombie','Sus primeros pasos se dan en la década de los 30. El cocktail fue inventado por Ernest Raymond Beaumont-Gannt en el Hollywoods Don Beachcomber Restaurant. El Zombie se popularizó poco después, en la década posterior. Ingredientes 3.5 cl. de zumo de limón 3 cl. de ron negro 2 cl. de zumo... ',7,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Tom Collins','El Tom Collins aparecía en 1876 en la The Bartenders Guide de Thomas, y poco después ya era un cocktail popular en los USA. Su receta se ha ido modificando un poco con el paso de los años, hasta quedar más o menos establecida así: Ingredientes 4.5 cl de ginebra 3 cl. de zumo de limón 1... ',14,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Negroni','Cuando llega la Navidad, los más pequeños de la casa piensan en los regalos y los más mayores en la comida que deben preparar para sus invitados. Una forma original y sencilla de empezar esas veladas es con un cocktail de aperitivo. Como el Negroni. El Negroni es ideal para estas fechas... ',11,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')
INSERT INTO TB_PLATILLO VALUES('Hurricane','El origen de esta bebida se atribuye al señor Pat OBrien, propietario de un bar a su nombre en la ciudad más grande del estado de Louisiana. Al parecer, OBrien acababa de abrir el bar y sólo tenía acceso a determinados licores, entre ellos el ron, que estableció como base para crear una bebida...',13,1,3,'https://api.norecipes.com/wp-content/uploads/2017/12/chicken-adobo_008.jpg')

