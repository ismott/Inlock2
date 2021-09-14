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
values (1,'Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '2018/05/15', 99.00),
(2,'Red Dead Redemption II','jogo eletrônico de ação-aventura western', '2018/10/26', 120.00)
go

update Jogo set NomeEstudio = 'a', Descricao = 'a', DataLancamento = '2018/10/26', 125.00 where idEstudio = 1;

Delete Jogo Where IdJogo = 4; 