CREATE TABLE Usuarios (
    [id] int NOT NULL IDENTITY(1,1),
    [nome] varchar(100) NOT NULL,
    [email] varchar(150) NOT NULL UNIQUE,
    [senha] varchar(255) NOT NULL,
    [perfil] varchar(30) NOT NULL,
    PRIMARY KEY([id])   
);