ALTER TABLE Pacientes
ADD usuario_id INT NULL;

GO

ALTER TABLE Pacientes
ADD CONSTRAINT FK_Pacientes_Usuarios
FOREIGN KEY (usuario_id)
REFERENCES Usuarios(id);

GO

CREATE UNIQUE INDEX UX_Pacientes_UsuarioId
ON Pacientes(usuario_id)
WHERE usuario_id IS NOT NULL;