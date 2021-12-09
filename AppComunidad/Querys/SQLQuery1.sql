select * from Categoria;
select * from Menu;
select * from TipoDocumento;
select * from TipoUsuario;
select * from Usuario;
select * from TipoImagen;
select * from Imagen;
select * from TipoRed;
select * from Red;


--insert into TipoImagen
--values('Principal',1,'admin',GETDATE(),'admin',GETDATE())

--insert into Imagen
--values ('BannerPrincipal','Imagenes',1,'png',2,1,'admin',GETDATE(),'admin',GETDATE())

update Usuario
set Login = 'ELV00000000',
	Password = '123456'
	where id=3

insert into TipoRed
values('Celular','fa fa-phone-square',1,'admin',GETDATE(),'admin',GETDATE())

insert into Red
values(1,'https://www.facebook.com/RestaurantAlexandra',2,1,'admin',GETDATE(),'admin',GETDATE())