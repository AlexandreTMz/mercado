USE [dbventas]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 26/02/2019 9:16:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](1024) NULL,
	[imagen] [image] NULL,
	[idcategoria] [int] NOT NULL,
	[idpresentacion] [int] NOT NULL,
 CONSTRAINT [PK_articulo] PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NULL,
	[sexo] [varchar](1) NULL,
	[fecha_nacimiento] [date] NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[descuento] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
	[estado] [varchar](7) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NOT NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](50) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](20) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](256) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[fecha_nac] [date] NOT NULL,
	[numero_documento] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NULL,
	[pasword] [varchar](20) NULL,
 CONSTRAINT [PK_trabajador] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[venta]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha_venta] [date] NOT NULL,
	[tipo_comprobante_venta] [varchar](20) NOT NULL,
	[serie_venta] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_articulo]
GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  StoredProcedure [dbo].[spanular_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spanular_ingreso]
@idingreso int
as
update ingreso set estado='anulado'
where idingreso=@idingreso
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_articulo]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_articulo]
@textobuscar varchar(50)
as
begin
SELECT
   a.idarticulo,
   a.codigo,
   a.nombre,
   a.descripcion,
   a.imagen,
   a.idcategoria,
   a.nombre AS categoria,
   a.idpresentacion,
   ap.nombre AS presentacion 
FROM
   dbo.articulo as a 
   INNER JOIN    dbo.categoria as e
      ON a.idcategoria = e.idcategoria 
   INNER JOIN    dbo.presentacion as ap
      ON a.idpresentacion = ap.idpresentacion 
where
   a.nombre like @textobuscar + '%' 
order by
   a.idarticulo desc
end 
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_categoria]
@textobuscar varchar(50)
as 
select * from categoria
where nombre like @textobuscar + '%' 
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente]
@textobuscar varchar(50)
as
select * from cliente
where apellidos like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_num_documento]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_cliente_num_documento]
@textobuscar varchar(50)
as
select * from cliente
where num_documento like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_ingreso_fecha]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_ingreso_fecha]
@textobuscar varchar(20),
@textobuscar2 varchar(20)
as
select
   i.idingreso,
   (
      t.apellidos + '' + t.nombre
   )
   as trabajador,
   p.razon_social as proveedor,
   i.fecha,
   i.tipo_comprobante,
   i.serie,
   i.correlativo,
   i.estado,
   SUM(d.precio_compra * d.stock_inicial) as total 
from
   detalle_ingreso d 
   inner join
      ingreso i 
      on d.idingreso = i.idingreso 
   inner join
      proveedor p 
      on i.idproveedor = p.idproveedor 
   inner join
      trabajador t 
      on i.idtrabajador = t.idtrabajador 
group by
   i.idingreso,
   t.apellidos + '' + t.nombre,
   p.razon_social,
   i.fecha,
   i.tipo_comprobante,
   i.serie,
   i.correlativo,
   i.estado 
   having 
   i.fecha>=@textobuscar and i.fecha<= @textobuscar2
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_presentacion]
@textobuscar varchar(50)
as
select * from presentacion
where nombre like @textobuscar + '%';
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_num_documento]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_num_documento]
@textobuscar varchar(11)
as
select * from proveedor
where num_documento like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_proveedor_razon_social]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_proveedor_razon_social]
@textobuscar varchar(50)
as
select * from proveedor
where razon_social like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_apellido]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_apellido]
@textobuscar varchar(50)
as
select * from trabajador
where apellidos like @textobuscar  + '%'
order by apellidos asc
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_num_documento]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spbuscar_trabajador_num_documento]
@textobuscar varchar(50)
as
select * from trabajador
where numero_documento like @textobuscar  + '%'
order by numero_documento asc
GO
/****** Object:  StoredProcedure [dbo].[speditar_articulo]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_articulo]
@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update articulo set codigo=@codigo, nombre=@nombre, descripcion=@descripcion,
imagen=@imagen, idcategoria=@idcategoria, idpresentacion=@idpresentacion
where idarticulo=@idarticulo
GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
update categoria set nombre=@nombre, descripcion=@descripcion
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[speditar_cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_cliente]
@idcliente int output,
@nombre varchar (50),
@apellidos varchar(50),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(50),
@email varchar(50)
as
update cliente set nombre=@nombre, apellidos=@apellidos, sexo=@sexo, fecha_nacimiento=@fecha_nacimiento, 
tipo_documento=@tipo_documento, num_documento=@num_documento, direccion=@direccion,
telefono=@telefono, email=@email
where idcliente=@idcliente
GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_presentacion]
@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update presentacion set nombre=@nombre, descripcion=@descripcion
where idpresentacion=@idpresentacion
GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speditar_proveedor]
@idproveedor int,
@razon_social varchar(50),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(20),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(256)
as
update proveedor set razon_social=@razon_social, sector_comercial=@sector_comercial, tipo_documento=@tipo_documento,
num_documento=@num_documento, direccion=@direccion, telefono=@telefono, email=@email, url=@url
where idproveedor=@idproveedor;
GO
/****** Object:  StoredProcedure [dbo].[speditar_trabajador]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_trabajador]
@idtrabajador int,
@nombre varchar(50),
@apellidos varchar(50),
@sexo varchar(50),
@fecha_nac date,
@numero_documento varchar(50),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
update trabajador set nombre=@nombre, apellidos=@apellidos, sexo=@sexo,fecha_nac=@fecha_nac ,numero_documento=@numero_documento, 
direccion=@direccion, telefono=@telefono, email=@email, acceso=@acceso, usuario=@usuario, pasword=@password
where idtrabajador=@idtrabajador
GO
/****** Object:  StoredProcedure [dbo].[speliminar_articulo]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_articulo]
@idarticulo int
as
delete from articulo
where idarticulo=@idarticulo 
GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_categoria]
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
GO
/****** Object:  StoredProcedure [dbo].[speliminar_cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_cliente]
@idcliente int
as
delete from cliente
where idcliente=@idcliente
GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_presentacion]
@idpresentacion int
as
delete from presentacion
where idpresentacion = @idpresentacion
GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_proveedor]
@idproveedor int
as
delete from proveedor
where idproveedor=@idproveedor
GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[speliminar_trabajador]
 @idtrabajador int
 as
 delete from trabajador
 where idtrabajador=@idtrabajador
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_articulo]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_articulo]
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(1024),
@imagen image,
@idcategoria int,
@idpresentacion int 
as
insert into articulo(codigo, nombre, descripcion, imagen, idcategoria, idpresentacion)
values(@codigo, @nombre, @descripcion, @imagen, @idcategoria, @idpresentacion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_categoria]
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into categoria (nombre, descripcion)
values (@nombre, @descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_cliente]
@idcliente int output,
@nombre varchar (50),
@apellidos varchar(50),
@sexo varchar(1),
@fecha_nacimiento date,
@tipo_documento varchar(20),
@num_documento varchar(11),
@direccion varchar(100),
@telefono varchar(50),
@email varchar(50)
as
insert into cliente(nombre, apellidos, sexo, fecha_nacimiento, tipo_documento,
 num_documento, direccion, telefono, email)
values(@nombre, @apellidos, @sexo, @fecha_nacimiento, @tipo_documento,
@num_documento, @direccion, @telefono, @email)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_detalle_ingreso]
@iddetalle_ingreso int output,
@idingreso int,
@idarticulo int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int,
@fecha_produccion date,
@fecha_vencimiento date
as
insert into detalle_ingreso (idingreso, idarticulo, precio_compra, precio_venta, stock_inicial, 
stock_actual, fecha_produccion, fecha_vencimiento)
values(@idingreso, @idarticulo, @precio_compra, @precio_venta, @stock_inicial,
 @stock_inicial, @fecha_produccion, @fecha_vencimiento)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_ingreso]
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@fecha date,
@tipo_comprobante varchar(20),
@serie varchar(4),
@correlativo varchar(7),
@igv decimal (4,2),
@estado varchar(7)
as
insert into ingreso(idtrabajador, idproveedor, fecha, tipo_comprobante, serie,
 correlativo, igv, estado)
 values (@idtrabajador, @idproveedor, @fecha, @tipo_comprobante,@serie, @correlativo, @igv, @estado)
 set @idingreso=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_presentacion]
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into presentacion(nombre, descripcion)
values(@nombre, @descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@razon_social varchar(50),
@sector_comercial varchar(50),
@tipo_documento varchar(20),
@num_documento varchar(20),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@url varchar(256)
as
insert into proveedor(razon_social, sector_comercial, tipo_documento, num_documento, direccion, telefono, email, url)
values(@razon_social, @sector_comercial, @tipo_documento, @num_documento, @direccion, @telefono, @email, @url)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_trabajador]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_trabajador]
@idtrabajador int output,
@nombre varchar(50),
@apellidos varchar(50),
@sexo varchar(50),
@fecha_nac date,
@numero_documento varchar(50),
@direccion varchar(100),
@telefono varchar(10),
@email varchar(50),
@acceso varchar(20),
@usuario varchar(20),
@password varchar(20)
as
insert into trabajador(nombre, apellidos, sexo, fecha_nac, numero_documento,
direccion, telefono, email, acceso, usuario, pasword )
values(@nombre, @apellidos, @sexo, @fecha_nac, @numero_documento, @direccion, @telefono,
@email, @acceso, @usuario, @password)
GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[splogin]
@usuario varchar(20),
@password varchar(20)
as
select idtrabajador,apellidos,nombre,acceso
from trabajador
where usuario=@usuario and pasword=@password
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_articulo]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_articulo]
as
begin
SELECT
   top 100 a.idarticulo,
   a.codigo,
   a.nombre,
   a.descripcion,
   a.imagen,
   a.idcategoria,
   e.nombre AS categoria,
   a.idpresentacion,
   f.nombre AS presentacion 
FROM
   dbo.articulo as a 
   INNER JOIN dbo.categoria as e
      ON a.idcategoria = e.idcategoria 
   INNER JOIN dbo.presentacion as f
      ON a.idpresentacion = f.idpresentacion 
order by
   a.idarticulo desc
end
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_categoria]
as
select top 200 * from categoria
order by idcategoria desc 
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_cliente]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_cliente]
as
select top 100 * from cliente
order by apellidos asc
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_detalle_ingreso]
@texto_buscar int
as 
select d.idarticulo, a.nombre as Articulo, d.precio_compra, d.precio_venta, d.stock_inicial, d.fecha_produccion, 
d.fecha_vencimiento, ( d.stock_inicial* d.precio_compra) as subtotal
from detalle_ingreso d inner join articulo a
on d.idarticulo = a.idarticulo
where d.idingreso=@texto_buscar
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ingreso]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_ingreso] as 
select top 100
   i.idingreso,
   (
      t.apellidos + '' + t.nombre
   )
   as trabajador,
   p.razon_social as proveedor,
   i.fecha,
   i.tipo_comprobante,
   i.serie,
   i.correlativo,
   i.estado,
   SUM(d.precio_compra * d.stock_inicial) as total 
from
   detalle_ingreso d 
   inner join
      ingreso i 
      on d.idingreso = i.idingreso 
   inner join
      proveedor p 
      on i.idproveedor = p.idproveedor 
   inner join
      trabajador t 
      on i.idtrabajador = t.idtrabajador 
group by
   i.idingreso,
   t.apellidos + '' + t.nombre,
   p.razon_social,
   i.fecha,
   i.tipo_comprobante,
   i.serie,
   i.correlativo,
   i.estado 
order by
   i.idingreso desc 
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_presentacion]
as
select top 100 * from presentacion
order by idpresentacion desc
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_proveedor]
as
select top 100 * from proveedor
order by razon_social asc
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_trabajador]    Script Date: 26/02/2019 9:16:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spmostrar_trabajador]
as
select top 100  * from trabajador
order by apellidos asc
GO
