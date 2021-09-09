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

select * from Usuario 
where Email = 'admin@admin.com' and Senha = 'admin'
go

select * from Jogo
where IdJogo = 1
go

select * from Estudio 
where IdEstudio = 1
go