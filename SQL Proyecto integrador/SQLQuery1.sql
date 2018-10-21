use master
go
if exists(select * from sysdatabases  where name = 'restauranteInteligente')
DROP DATABASE restauranteInteligente
GO

create database restauranteInteligente
go

use restauranteInteligente

create table TB_TIPO(
	CODIGO_TIPO int identity(1,1) primary key,
	DESCRIPCION_TIPO varchar(25)
)
go

create proc sp_AgregarTipo(@descripcion varchar(25))
as
begin
	insert into TB_TIPO (DESCRIPCION_TIPO) values (@descripcion)
end
go

exec sp_AgregarTipo 'CLIENTE'
exec sp_AgregarTipo 'COCINA'
exec sp_AgregarTipo 'ADMINISTRADOR'
exec sp_AgregarTipo 'PROVEEDOR'
go

create proc sp_ListarTipo
as
begin
	select CODIGO_TIPO,DESCRIPCION_TIPO from TB_TIPO
end
go

EXEC sp_ListarTipo
GO


create proc sp_ListarTipoXId(@id int)
as
begin
	select CODIGO_TIPO,DESCRIPCION_TIPO from TB_TIPO where CODIGO_TIPO= @id
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

exec sp_ActualizarTipo 4,'PROVEEDORES'
go

EXEC sp_ListarTipo
GO

create proc sp_EliminarTipo(@id int)
as
begin
	delete from TB_TIPO where CODIGO_TIPO = @id
end
go

EXEC sp_EliminarTipo 4
GO

EXEC sp_ListarTipo
GO
