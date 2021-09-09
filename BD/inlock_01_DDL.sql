--DDL

create database inlock_games_tarde
go

use inlock_games_tarde
go

create table Estudio (
	IdEstudio int primary key identity(1,1),
	NomeEstudio varchar(50) unique not null 
);
go

create table Jogo (
	IdJogo bigint primary key identity(1,1),
	IdEstudio int foreign key references Estudio(IdEstudio),
	NomeJogo varchar(100) not null, 
	Descricao  varchar(400) not null, 
	DataLancamento date not null,
	Valor decimal(5,2) not null
);
go

create table TipoUsuario (
	IdTipoUsuario tinyint primary key identity(1,1),
	Titulo varchar(50)
);
go

create table Usuario (
	IdUsuario bigint primary key identity(1,1),
	IdTipoUsuario tinyint foreign key references TipoUsuario(IdTipoUsuario),
	Email varchar(256) not null unique,
	Senha varchar(50) not null check(len(Senha) >= 4)
);
go
