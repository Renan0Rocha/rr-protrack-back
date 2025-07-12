create database rr_protrack_bd;
use rr_protrack_bd;

create table Endereco(
id_end int not null primary key auto_increment,
cep_end varchar(10) not null,
logradouro_end varchar(100) not null,
bairro_end varchar(100) not null,
numero_end varchar (10) not null,
cidade_end varchar(100) not null,
estado_end varchar(100) not null
);

create table Vendedor(
id_ven int not null primary key auto_increment,
nome_ven varchar(100) not null,
data_nasc_ven date not null,
cpf_ven varchar(100) not null,
vinculo_ven varchar(100)
);

create table Cliente(
id_cli int not null primary key auto_increment,
nome_cli varchar(100) not null,
data_nasc_cli date not null,
tipo_cli boolean not null default false,
cpf_cnpj_cli varchar(25),
telefone_cli varchar(20),
id_end_fk int,
Foreign key (id_end_fk) references Endereco(id_end),
id_ven_fk int,
Foreign key (id_ven_fk) references Vendedor(id_ven)
);

create table Insercao(
id_ins int not null primary key auto_increment,
tempo_ins time not null,
valor_ins double not null
);

create table Contrato(
id_con int not null primary key auto_increment,
numero_documento_con varchar(50),
situacao_con varchar(100),
plano_con varchar(100),
descricao_con varchar(200),
data_emissao_con date, 
data_inicio_con date,
data_fim_con date,
horarios_con time,
total_insercoes_con int,
valor_bruto_con double,
valor_desconto_con double,
valor_total_con double,
valor_comissao_con double,
id_cli_fk int,
id_ven_fk int,
id_ins_fk int,
Foreign Key(id_cli_fk) references Cliente(id_cli),
Foreign Key(id_ven_fk) references Vendedor(id_ven),
Foreign Key(id_ins_fk) references Insercao(id_ins)
);

create table Programa(
id_pro int not null primary key auto_increment,
nome_pro varchar(200),
sigla_pro varchar(100),
duracao_pro time,
dias_semana_pro varchar(100),
data_inicial_pro date,
data_dinal_pro date,
horario_inicial_pro time,
hhorario_final_pro time
);

create table Ordem_bloco(
id_ord int not null primary key auto_increment,
data_ord date,
hora_ord time,
id_pro_fk int,
Foreign Key(id_pro_fk) references Programa(id_pro)
);

create table Ordem_bloco_contrato(
id_obc int not null primary key auto_increment,
numero_ordem_obc int,
id_ord_fk int,
id_con_fk int,
Foreign Key(id_ord_fk) references Ordem_bloco(id_ord),
Foreign Key(id_con_fk) references Contrato(id_con)
);

INSERT INTO Endereco Values(null, '76916000', 'Rua José Vidal', 'Centro', '2673', 'Presidente Médici', 'RO');

INSERT INTO Vendedor Values(null, 'Eduardo França', '2005-02-15', '982.545.942-00', null);

INSERT INTO Cliente Values(null, 'Renan Rocha', '2005-02-15', false, '702.389.712-00', '69984073296', 1, 1);
