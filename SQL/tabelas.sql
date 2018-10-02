CREATE TABLE paciente (
	id int identity(1,1) primary key,
	nome_completo varchar(250),
	endereco varchar() not null,
	data_de_nascimento char(10) not null,
	email varchar(50) not null,
	idade int not null,
	celular int not null,
	telefone int not null,
	imagem image not null
)

CREATE TABLE medico (
	id int identity(1,1) primary key,
	nome_completo varchar(250) not null,
	data_de_nascimento char(10) not null,
	email varchar(75 not null),
	idade int,
	celular varchar(),
	telefone varchar(),
	especialidade int not null,
	imagem image not null
)

CREATE TABLE consultas (
	id int identity(1,1) primary key,
	data
	idMedico
	idPaciente
	anotacoes
)

CREATE TABLE especialidades (
	id int identity(1,1) primary key,
	especialidade varchar()
)