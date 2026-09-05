-- Solicitação: Alisson Pereira / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633888'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'Solicitado',
    CAST(N'2026-09-02T19:30:11.943' AS DateTime)
);

-- Solicitação: Sthephany Rezende / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633901'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'LaudoDisponivel',
    CAST(N'2026-09-02T19:30:43.527' AS DateTime)
);

-- Solicitação: Alisson Pereira / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633888'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'EmAndamento',
    CAST(N'2026-09-02T19:36:05.217' AS DateTime)
);

-- Solicitação: Alisson Pereira / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633888'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'Solicitado',
    CAST(N'2026-09-02T20:13:42.117' AS DateTime)
);

-- Solicitação: Sthephany Rezende / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633901'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'LaudoDisponivel',
    CAST(N'2026-09-02T20:14:37.703' AS DateTime)
);

-- Solicitação: Alisson Pereira / Japones
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345633888'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'japones@examflow.com'),
    N'Solicitado',
    CAST(N'2026-09-02T21:22:11.167' AS DateTime)
);

-- Solicitação: Admilson / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345678910'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'LaudoDisponivel',
    CAST(N'2026-09-03T19:45:44.720' AS DateTime)
);

-- Solicitação: Admilson / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345678910'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'EmAndamento',
    CAST(N'2026-09-03T20:33:01.773' AS DateTime)
);

-- Solicitação: Admilson / Dr. Carlos
INSERT INTO [dbo].[ExameSolicitacoes]
    ([paciente_id], [usuario_id], [status], [data_solicitacao])
VALUES
(
    (SELECT [id] FROM [dbo].[Pacientes] WHERE [cpf] = N'12345678910'),
    (SELECT [id] FROM [dbo].[Usuarios] WHERE [email] = N'carlos@examflow.com'),
    N'Solicitado',
    CAST(N'2026-09-03T20:33:52.897' AS DateTime)
);