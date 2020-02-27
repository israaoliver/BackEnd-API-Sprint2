CREATE DATABASE T_Peoples
GO
USE T_Peoples
CREATE TABLE Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Sobrenome VARCHAR(255) NOT NULL
);

ALTER TABLE Funcionarios 
ADD DataNacimento DATE;

