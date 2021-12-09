Select
	USU.Nombre,
	NEG.Descripcion--,
	--SBC.Nombre as SubCategoria
From Usuario USU
INNER JOIN Negocio NEG ON USU.Id = NEG.UsuarioId
--INNER JOIN SubCategoria SBC ON  NEG.SubCategoriaId = SBC.Id

	Select
		SBC.Nombre as SubCategoria
	From Usuario USU
	INNER JOIN Negocio NEG ON USU.Id = NEG.UsuarioId
	INNER JOIN SubCategoria SBC ON  NEG.SubCategoriaId = SBC.Id
	WHERE USU.Id=2

	Select
	SBC.Nombre as SubCategoria
	From Usuario USU
	INNER JOIN Negocio NEG ON USU.Id = NEG.UsuarioId
	INNER JOIN SubCategoria SBC ON  NEG.SubCategoriaId = SBC.Id
	WHERE USU.Id=2



Usp_Get_Negocio_UsuarioId 2
Usp_Get_Negocio_Categorias_UsuarioId 2