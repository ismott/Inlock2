--DML

use inlock_games_tarde
go

--Inserindo tipos de usuario
insert into TipoUsuario (Titulo)
values ('Administrador'),('Cliente')
go

insert into Usuario (IdTipoUsuario, Email, Senha)
values (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente')
go

insert into Estudio (NomeEstudio)
values ('Blizzard,'),('Rockstar Studios'),('Square Enix')
go

insert into Jogo (IdEstudio, NomeJogo, Descricao, DataLancamento, Valor)
values (1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00),
(2,'Red Dead Redemption II','jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00)
go

update Estudio set NomeEstudio = 'Blizzard' where idEstudio = 1;