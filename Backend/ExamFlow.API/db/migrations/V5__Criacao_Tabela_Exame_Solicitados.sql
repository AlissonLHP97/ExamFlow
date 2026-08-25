CREATE TABLE ExameSolicitados (
    [id] int NOT NULL IDENTITY(1,1),
    [exame_solicitacao_id] int NOT NULL,
    [exame_id] int NOT NULL,
    PRIMARY KEY([id]),
    FOREIGN KEY([exame_solicitacao_id]) REFERENCES ExameSolicitacoes([id]),
    FOREIGN KEY([exame_id]) REFERENCES Exame([id])
);