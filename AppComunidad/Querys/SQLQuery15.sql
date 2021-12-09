select * from Imagen;
delete Imagen
DBCC CHECKIDENT ('Imagen', RESEED, 0)

select * from red;
delete red
DBCC CHECKIDENT ('Red', RESEED, 0)