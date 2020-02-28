USE  T_Peoples
go
SELECT * FROM Funcionarios;

SELECT CONCAT (Nome,' ',Sobrenome) FROM Funcionarios


SELECT * FROM TiposUsuarios;

SELECT * FROM Usuarios;

SELECT Usuarios.IdUsuario,Usuarios.IdTipoUsuario, Usuarios.Email, Usuarios.Senha, TiposUsuarios.Titulo 
FROM Usuarios INNER JOIN TiposUsuarios ON TiposUsuarios.IdTipoUsuario = Usuarios.IdTipoUsuario;