select * from Categoria;
select * from Menu;
select * from TipoDocumento;
select * from TipoUsuario;
select * from Usuario;
select * from TipoImagen;
select * from Imagen;
select * from TipoRed;
select * from Red;
select * from Negocio;
select * from SubCategoria;

--insert into TipoImagen
--values('Principal',1,'admin',GETDATE(),'admin',GETDATE())

--insert into Imagen
--values ('BannerPrincipal','Imagenes',1,'png',2,1,'admin',GETDATE(),'admin',GETDATE())

update Usuario
set Login = 'RES10101010101',
	Password = '123456',
	TipoDocumentoId='2',
	NroDocumento='10101010101',
	TipoUsuarioId=2,
	Correo='martinezislaluis@gmail.com'
	where id=2

insert into TipoRed
values('Celular','fa fa-phone-square',1,'admin',GETDATE(),'admin',GETDATE())

insert into Red
values(1,'https://www.facebook.com/RestaurantAlexandra',2,1,'admin',GETDATE(),'admin',GETDATE())

