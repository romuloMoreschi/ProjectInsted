SELECT * FROM [PlantaoFacil].[dbo].Vagas

SELECT * FROM [PlantaoFacil].[dbo].Escalas

SELECT * FROM [PlantaoFacil].[dbo].Funcionarios

SELECT * FROM [PlantaoFacil].[dbo].Situacoes

INSERT INTO [Situacoes] ([Nome]) VALUES ('Ativo');
INSERT INTO [Situacoes] ([Nome]) VALUES ('Cancelado');
INSERT INTO [Situacoes] ([Nome]) VALUES ('Finalizado');
INSERT INTO Roles ([Nome]) VALUES ('Gerente');
INSERT INTO Roles ([Nome]) VALUES ('Analista');
INSERT INTO [Vagas] ([Horario], [Funcao], [NumeroVagasDisponiveis], [SituacaoId], [EscalaId]) VALUES ('2023-12-02 06:30', 'Caixa', 4, 1 , 1);
INSERT INTO [Vagas] ([Horario], [Funcao], [NumeroVagasDisponiveis], [SituacaoId], [EscalaId]) VALUES ('2023-12-02 06:30', 'Açougueiro', 4, 1 , 1);
INSERT INTO [Escalas] ([DataInicial], [DataTermino]) VALUES ('2023-12-02 12:40', '2023-12-09 00:00');
INSERT INTO [Escalas] ([DataInicial], [DataTermino]) VALUES ('2023-10-05 13:30', '2023-10-12 01:00');
INSERT INTO [Escalas] ([DataInicial], [DataTermino]) VALUES ('2023-09-08 12:00', '2023-09-15 05:00');
INSERT INTO [Funcionarios] ([Nome], [Sexo], [Pontuacao], [EscalaId], [RoleId], [SituacaoId], [VagaId]) VALUES ('Romulo Moreschi Filho', 'M', 1000, 3 , 1, 1, 3);
INSERT INTO [Funcionarios] ([Nome], [Sexo], [Pontuacao], [EscalaId], [RoleId], [SituacaoId], [VagaId]) VALUES ('Leandro Martins Vieira ', 'M', 1000, 2 , 1, 1, 4);
INSERT INTO [Funcionarios] ([Nome], [Sexo], [Pontuacao], [EscalaId], [RoleId], [SituacaoId], [VagaId]) VALUES ('José Eduardo', 'M', 1000, 1 , 1, 1, null);
