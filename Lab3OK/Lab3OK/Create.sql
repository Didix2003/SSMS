
Create Database GestionaCheltuieli
go
USE GestionaCheltuieli;


if OBJECT_ID(N'Utilizator',N'U') is null
create table Utilizator
(id_u int primary key identity(1,1),
nume_u varchar(100),
parola varchar(100));

if OBJECT_ID(N'Cheltuiala',N'U') is null
create table Cheltuiala
(id_ch int primary key identity(1,1),
id_u int,
suma_cheltuita int,
data_cheltuiala datetime,
constraint fk_UtilizatorCheltuiala foreign key (id_u) references Utilizator(id_u)
);

if OBJECT_ID(N'Categorie',N'U') is null
create table Categorie
(id_cat int primary key identity(1,1),
nume_cat varchar(100));

if OBJECT_ID(N'Organizare',N'U') is null
create table Organizare
(id_ch int,
id_cat int,
tip_organizare varchar(100),
constraint fk_CheltuialaOrganizare foreign key (id_ch) references Cheltuiala(id_ch),
constraint fk_CategorieOrganizare foreign key (id_cat) references Categorie(id_cat),
constraint pk_Organizare primary key (id_ch,id_cat)
);

if OBJECT_ID(N'Buget',N'U') is null
create table Buget 
(id_buget int primary key identity(1,1),
id_u int,
luna varchar(100),
anul int,
constraint fk_UtilizatorBuget foreign key (id_u) references Utilizator(id_u)
);
alter table Buget
alter column luna varchar(100);


if OBJECT_ID(N'Locatie',N'U') is null
create table Locatie 
(id_locatie int primary key identity(1,1),
nume_locatie varchar(100),
adresa varchar(100),
oras varchar(100),
tara varchar(100),
);
if OBJECT_ID(N'Detalii_CheltuialaLocatie',N'U') is null
create table Detalii_CheltuialaLocatie
(id_ch int,
id_locatie int,
suma_cheltuita int,
constraint fk_CheltuialaDetalii_CheltuialaLocatie foreign key (id_ch) references Cheltuiala(id_ch),
constraint fk_LocatieDetalii_CheltuialaLocatie foreign key (id_locatie) references Locatie(id_locatie),
constraint pk_Detalii_CheltuialaLocatie primary key (id_ch,id_locatie)
);


/*TRUNCATE TABLE Utilizator;
TRUNCATE TABLE Buget;
TRUNCATE TABLE Organizare;
TRUNCATE TABLE Categorie;
TRUNCATE TABLE Cheltuiala;*/
