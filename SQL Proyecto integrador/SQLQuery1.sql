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

exec sp_AgregarTipo 'CLIENTE'
exec sp_AgregarTipo 'COCINA'
exec sp_AgregarTipo 'ADMINISTRADO'
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
	NOMBRE_USUARIO varchar(25),
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

exec sp_AgregarUsuario 'CLIENTE1','Aaaa123',1
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

exec sp_ActualizarUsuario 1,'COCINA1','123456789',2
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
	CODIGO_CATEGORIA int references TB_CATEGORIA
)
go

SELECT * FROM TB_PLATILLO
GO

create proc sp_AgregarPlatillo(@nombre varchar(25),@descripcion varchar(500),@precio decimal(10,2),@categoria int)
as
begin
	insert into TB_PLATILLO (NOMBRE_PLATILLO,DESCRIPCION_PLATILLO,PRECIO_PLATILLO,ESTADO_PLATILLO,CODIGO_CATEGORIA) values (@nombre,@descripcion,@precio,DEFAULT,@categoria)
end
go

exec sp_AgregarPlatillo 'Platillo1','Descripcion1',99.99,1
exec sp_AgregarPlatillo 'Platillo1','Descripcion1',99.99,1
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
	select p.CODIGO_PLATILLO as CODIGO_PLATILLO,p.NOMBRE_PLATILLO as NOMBRE_PLATILLO,p.DESCRIPCION_PLATILLO as DESCRIPCION_PLATILLO, p.PRECIO_PLATILLO as PRECIO_PLATILLO, p.ESTADO_PLATILLO  as ESTADO_PLATILLO,c.CODIGO_CATEGORIA as CODIGO_CATEGORIA,c.DESCRIPCION_CATEGORIA as DESCRIPCION_CATEGORIA
	from TB_PLATILLO p inner join TB_CATEGORIA c on p.CODIGO_CATEGORIA=c.CODIGO_CATEGORIA
	where p.CODIGO_PLATILLO = @id
end
go

EXEC sp_ListarPlatilloXId 1
GO

create proc sp_ActualizarPlatillo(@id int,@nombre varchar(25),@descripcion varchar(500),@precio decimal(10,2),@categoria int)
as
begin
	update TB_PLATILLO set NOMBRE_PLATILLO = @nombre, DESCRIPCION_PLATILLO =@descripcion,PRECIO_PLATILLO=@precio,CODIGO_CATEGORIA=@categoria where CODIGO_PLATILLO = @id
end
go

exec sp_ActualizarPlatillo 2,'Platillo2','Descripcion2',100,2
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