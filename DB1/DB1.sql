create database [db1_test]
go
use [db1_test]
go
create table [dbo].[technologies]
(
	[id] int identity(1,1) not null,
	[name] varchar(250) not null,
	constraint [pk_technologies_1] primary key(id)
);
go
insert into [dbo].[technologies] ([name]) values ('Angular JS');
insert into [dbo].[technologies] ([name]) values ('C#');
insert into [dbo].[technologies] ([name]) values ('Javascript');
insert into [dbo].[technologies] ([name]) values ('MVC');
insert into [dbo].[technologies] ([name]) values ('ASP');
insert into [dbo].[technologies] ([name]) values ('VB.Net');
insert into [dbo].[technologies] ([name]) values ('C++');
go
create table [dbo].[vacancies]
(
	[id] int identity(1,1) not null,
	[name] varchar(250) not null,
	constraint [pk_vacancies_1] primary key(id)
);
go
insert into [dbo].[vacancies] ([name]) values ('Analista de Sistemas Sênior');
insert into [dbo].[vacancies] ([name]) values ('Analista de Sistemas Pleno');
insert into [dbo].[vacancies] ([name]) values ('Programador Júnior');
go
create table [dbo].[candidates]
(
	[id] int identity(1,1) not null,
	[id_vacancy] int not null,
	[name] varchar(250) not null,
	constraint [pk_candidates_1] primary key(id),
	constraint [fk_candidates_vacancies_1] foreign key([id_vacancy]) references [dbo].[vacancies]([id])
);
go
create table [dbo].[candidates_technologies]
(
	[id_candidate] int not null,
	[id_technology] int not null,
	constraint [fk_candidates_technologies_1] foreign key([id_candidate]) references [dbo].[candidates]([id]),
	constraint [fk_candidates_technologies_2] foreign key([id_technology]) references [dbo].[technologies]([id])
);
