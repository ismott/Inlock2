--DQL

use inlock_games_tarde
go

select * from TipoUsuario
select * from Usuario
select * from Estudio
select * from Jogo
go

select NomeJogo, NomeEstudio from Jogo
inner join Estudio on Estudio.IdEstudio = Jogo.IdEstudio
go

select NomeEstudio, NomeJogo from Estudio as e
left join Jogo as j on e.IdEstudio = j.IdEstudio
go

select Email, Senha, IdTipoUsuario from Usuario where Email = 'admin@admin.com' and Senha = 'admin'
go

select Estudio.NomeEstudio, NomeJogo, Descricao, DataLancamento, Valor from Jogo inner join Estudio on jogo.IdEstudio = Estudio.IdEstudio where IdJogo = 4
go

select * from Estudio 
where IdEstudio = 1
go