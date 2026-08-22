CREATE TABLE Pacientes (
    [id] int NOT NULL IDENTITY(1,1),
    [nome] varchar(100) NOT NULL,
    [cpf] varchar(11) NOT NULL UNIQUE,
    [data_nascimento] date NOT NULL,
    [genero] varchar(20) NOT NULL,
    [telefone] varchar(20),
    PRIMARY KEY([id])
);