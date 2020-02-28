USE T_Peoples
GO
INSERT INTO Funcionarios(Nome,Sobrenome)
VALUES ('Catarina', 'Strada'),
	('Tadeu', 'Vitelli');

INSERT INTO TiposUsuarios(Titulo)
VALUES ('Adm'),
	('Comum');

INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (1,'adm@email.com','132'),
	(2,'Catarina@hotmail.com','asd');


