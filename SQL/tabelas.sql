CREATE TABLE especialidade (
	id int identity(1,1) primary key,
	especialidade varchar(50) not null
)

CREATE TABLE paciente (
	id int identity(1,1) primary key,
	nome_completo varchar(100),
	email varchar(50) not null,
	senha varchar(400) not null,
	data_de_nascimento char(10) not null,
	endereco varchar(100) not null,
	celular varchar(16) not null,
	telefone_residencial varchar(16) not null,
	imagem varchar(100)
)

CREATE TABLE medico (
	id int identity(1,1) primary key,
	nome_completo varchar(100),
	email varchar(50) not null,
	senha varchar(400) not null,
	data_de_nascimento char(10) not null,
	endereco varchar(100) not null,
	celular varchar(16) not null,
	telefone_residencial varchar(16) not null,
	imagem varchar(100),
	especialidade int not null,
	constraint fkIdEspecialidade foreign key(especialidade) references especialidade(id)
)

CREATE TABLE consulta (
	id int identity(1,1) primary key,
	data char(16) not null,
	idMedico int not null,
	idPaciente int not null,
	status varchar(9) not null,
	diagnostico ntext,
	anotacoes ntext,
	pacienteAvisado bit not null default 0,
	constraint fkIdMedico foreign key(idMedico) references medico(id),
	constraint fkIdPaciente foreign key(idPaciente) references paciente(id)
)

CREATE TABLE secretaria (
	codigo char(5) primary key,
	nome_completo varchar(50) not null,
	senha varchar(400) not null
)