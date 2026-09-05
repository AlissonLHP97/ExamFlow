INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T19:30:11.943' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633901'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T19:30:43.527' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    N'Hemograma realizado. Resultados dentro dos valores de referência.',
    CAST(N'2026-09-02T19:34:58.047' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T19:36:05.217' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    N'Glicemia: 92 mg/dL.',
    CAST(N'2026-09-02T19:37:45.313' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T19:36:05.217' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Radiografia'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T20:13:42.117' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T20:13:42.117' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Radiografia'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633901'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T20:14:37.703' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    N'Hemograma realizado. Hemoglobina, hematócrito, leucócitos e plaquetas dentro dos valores de referência.',
    CAST(N'2026-09-03T18:41:21.850' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633901'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T20:14:37.703' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    N'Glicemia em jejum: 92 mg/dL. Resultado dentro dos valores de referência.',
    CAST(N'2026-09-03T18:41:41.793' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'japones@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T21:22:11.167' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345633888'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'japones@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-02T21:22:11.167' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T19:45:44.720' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    N'Resíduos de alimentos, açúcar ou suor na pele alteram a amostra de sangue.',
    CAST(N'2026-09-03T19:47:01.560' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T19:45:44.720' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    N'Se você colher sangue deitado e depois de ter tomado muita água, o sangue pode parecer mais "diluído", simulando uma anemia que não existe. O inverso ocorre na desidratação severa, que concentra o sangue e pode mascarar uma anemia real',
    CAST(N'2026-09-03T20:03:33.583' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T19:45:44.720' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Radiografia'),
    N'Sobreposição de estruturas: Ossos, órgãos ou tecidos normais do corpo que ficam sobrepostos na imagem, simulando uma mancha, nódulo ou fratura',
    CAST(N'2026-09-03T20:04:01.680' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T20:33:01.773' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    N'Mãos sujas: Resíduos de alimentos, açúcar ou bebidas nas mãos alteram a leitura para cima.',
    CAST(N'2026-09-03T20:35:05.757' AS DateTime)
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T20:33:01.773' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T20:33:52.897' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Glicemia'),
    NULL,
    NULL
);

INSERT INTO [dbo].[ExameSolicitados] ([exame_solicitacao_id], [exame_id], [resultado], [data_resultado])
VALUES
(
    (
        SELECT [id]
        FROM [dbo].[ExameSolicitacoes]
        WHERE [paciente_id] = (
            SELECT [id] FROM [dbo].[Pacientes]
            WHERE [cpf] = N'12345678910'
        )
        AND [usuario_id] = (
            SELECT [id] FROM [dbo].[Usuarios]
            WHERE [email] = N'carlos@examflow.com'
        )
        AND [data_solicitacao] = CAST(N'2026-09-03T20:33:52.897' AS DateTime)
    ),
    (SELECT [id] FROM [dbo].[Exame] WHERE [nome] = N'Hemograma'),
    NULL,
    NULL
);