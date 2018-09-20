CREATE TABLE paciente (
	id int identity(1,1) primary key,
	nome_completo varchar(250),
	endereco,
	data_de_nascimento,
	email,
	idade,
	celular,
	telefone,
	imagem
)

CREATE TABLE medico (
	id int identity(1,1) primary key,
	nome_completo varchar(250),
	data_de_nascimento,
	email,
	idade,
	celular,
	telefone,
	especialidade,
	imagem
)

CREATE TABLE consultas (
	id int identity(1,1) primary key,
	data
	idMedico
	idPaciente
	anotacoes
)

CREATE TABLE especialidades (
	id int identity(1,1) primary key
)