create database rr_protrack_bd;
use rr_protrack_bd;

create table Endereco(
id int not null primary key auto_increment,
cep varchar(10) not null,
logradouro varchar(100) not null,
bairro varchar(100) not null,
numero varchar (10) not null,
cidade varchar(100) not null,
estado varchar(100) not null
);

create table Vendedor(
id int not null primary key auto_increment,
nome varchar(100) not null,
data_nascimento date not null,
cpf varchar(100) not null,
vinculo varchar(100)
);

create table Cliente(
id int not null primary key auto_increment,
nome varchar(100) not null,
data_nasc date not null,
cpf varchar(25) not null,
telefone varchar(20),
id_end_fk int not null,
Foreign key (id_end_fk) references Endereco(id),
id_ven_fk int not null,
Foreign key (id_ven_fk) references Vendedor(id)
);

create table Insercao(
id int not null primary key auto_increment,
tempo varchar(50) not null,
valor double not null
);

create table Contrato(
id int not null primary key auto_increment,
numero_documento varchar(50) not null,
situacao varchar(100) not null,
plano varchar(100) not null,
descricao varchar(200),
data_emissao date not null, 
data_inicio date not null,
data_fim date not null,
horarios varchar(100) not null,
total_insercoes int not null,
valor_bruto double not null,
valor_desconto double not null,
valor_total double not null,
valor_comissao double not null,
id_cli_fk int not null,
id_ven_fk int not null,
id_ins_fk int not null,
Foreign Key(id_cli_fk) references Cliente(id),
Foreign Key(id_ven_fk) references Vendedor(id),
Foreign Key(id_ins_fk) references Insercao(id)
);

create table Programa(
id int not null primary key auto_increment,
nome varchar(200) not null,
sigla varchar(100) not null,
duracao varchar(100) not null,
dias_semana varchar(100),
data_inicio date not null,
data_fim date not null,
horario_inicio varchar(100) not null,
horario_fim varchar(100) not null
);

create table Ordem_bloco(
id int not null primary key auto_increment,
data_bloco date not null,
hora varchar(110) not null,
id_pro_fk int not null,
Foreign Key(id_pro_fk) references Programa(id)
);

create table Ordem_bloco_contrato(
id int not null primary key auto_increment,
numero_ordem int not null,
id_ord_fk int not null,
id_con_fk int not null,
Foreign Key(id_ord_fk) references Ordem_bloco(id),
Foreign Key(id_con_fk) references Contrato(id)
);

INSERT INTO Endereco Values(null, '76916000', 'Rua José Vidal', 'Centro', '2673', 'Presidente Médici', 'RO');

INSERT INTO Vendedor Values(null, 'Eduardo França', '2005-02-15', '982.545.942-00', null);

INSERT INTO Cliente Values(null, 'Renan Rocha', '2005-02-15', '702.389.712-00', '69984073296', 1, 1);
