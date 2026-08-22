CREATE TABLE ExameSolicitacoes (
    [id] int NOT NULL IDENTITY(1,1),
    [paciente_id] int NOT NULL,
    [usuario_id] int NOT NULL,
    [status] varchar(30) NOT NULL,
    [data_solicitacao] datetime NOT NULL,
    PRIMARY KEY([id]),
    FOREIGN KEY([paciente_id]) REFERENCES Pacientes([id]),
    FOREIGN KEY([usuario_id]) REFERENCES Usuarios([id])
);