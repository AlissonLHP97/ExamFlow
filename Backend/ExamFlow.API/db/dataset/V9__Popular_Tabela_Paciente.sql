INSERT INTO [dbo].[Pacientes]
    ([nome], [cpf], [data_nascimento], [genero], [telefone], [usuario_id])
VALUES
(
    N'Sthephany Rezende',
    N'12345633901',
    CAST(N'1998-05-20' AS Date),
    N'Feminino',
    N'1199899999',
    NULL
);

INSERT INTO [dbo].[Pacientes]
    ([nome], [cpf], [data_nascimento], [genero], [telefone], [usuario_id])
VALUES
(
    N'Alisson Pereira',
    N'12345633888',
    CAST(N'1998-05-20' AS Date),
    N'Masculino',
    N'1199899999',
    NULL
);

INSERT INTO [dbo].[Pacientes]
    ([nome], [cpf], [data_nascimento], [genero], [telefone], [usuario_id])
VALUES
(
    N'Admilson',
    N'12345678910',
    CAST(N'1998-05-20' AS Date),
    N'Masculino',
    N'11999999999',
    (
        SELECT [id]
        FROM [dbo].[Usuarios]
        WHERE [email] = N'admilson@examflow.com'
    )
);