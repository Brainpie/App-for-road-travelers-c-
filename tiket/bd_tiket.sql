create table Tiket (
ID INT NOT NULL IDENTITY ,
	Data1 DateTime NOT NULL,
	CityId1 int NOT NULL,
	CityName1 varchar(40) NOT NULL,
	Data2 DateTime NOT NULL,
	CityId2 int NOT NULL,
	CityName2 varchar(40) NOT NULL,
	Price int NOT NULL,
	Typetransport VARCHAR(40) NOT NULL,
	LoginClient VARCHAR(50) NOT NULL,
	PRIMARY KEY(ID))

	select id, Data1 ,CityId1 ,Data2 ,
CityId2,Price ,Typetransport ,LoginClient 
from Tiket where LoginClient='lapshailya'

create table Client(
ID INT NOT NULL IDENTITY ,
	Name VARCHAR(30) NOT NULL,
	Surname VARCHAR(30) NOT NULL,
	Lastname VARCHAR(30) NOT NULL,
	Dateborn date NOT NULL,
	Number VARCHAR(10) NOT NULL,
	Pasport VARCHAR(10) NOT NULL,
	Password VARCHAR(25) NOT NULL UNIQUE,
	Login VARCHAR(25) NOT NULL UNIQUE,
	PRIMARY KEY(ID)
)
drop table GradePlace
drop table tiket
drop table reviews
drop table tiket
drop table tiket

create table Reviews(
ID INT NOT NULL IDENTITY ,
	CityFrom VARCHAR(16) NOT NULL,
	DateFrom DateTime NOT NULL,
	DateTo DateTime NOT NULL,
	CityTo VARCHAR(30) NOT NULL,
	Comment VARCHAR(100) NOT NULL,
	Rate INT NOT NULL,
	ClientID VARCHAR(50) NOT NULL,
	PRIMARY KEY(ID)
)

create table GradePlace(
ID INT NOT NULL IDENTITY ,
	Place VARCHAR(50) NOT NULL,
	Rate INT NOT NULL,
	CityFrom VARCHAR(16) NOT NULL,
	DateFrom DateTime NOT NULL,
	DateTo DateTime NOT NULL,
	CityTo VARCHAR(30) NOT NULL,
	ClientID VARCHAR(50) NOT NULL
	PRIMARY KEY(ID)
)

create table City(
ID INT NOT NULL IDENTITY ,
	Name VARCHAR(50) NOT NULL,
	PRIMARY KEY(ID)
)

insert into City values ('Пенза')
insert into City values ('Москва')
insert into City values ('Саратов')
insert into City values ('Тамбов')
insert into City values ('Нижний Новгород')
insert into City values ('Саранск')
