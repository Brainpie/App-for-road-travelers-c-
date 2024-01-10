create table Tiket (
ID INT NOT NULL IDENTITY ,
	Data1 DateTime NOT NULL,
	CityId1 int NOT NULL,
	Data2 DateTime NOT NULL,
	CityId2 int NOT NULL,
	Price int NOT NULL,
	Typetransport VARCHAR(40) NOT NULL,
	ClientId INT NOT NULL,
	FOREIGN KEY (ClientId) REFERENCES Client (ID),
	FOREIGN KEY (CityId1) REFERENCES City (ID),
	FOREIGN KEY (CityId2) REFERENCES City (ID),
	PRIMARY KEY(ID))


create table Client(
ID INT NOT NULL IDENTITY ,
	Name VARCHAR(30) NOT NULL,
	Surname VARCHAR(30) NOT NULL,
	Lastname VARCHAR(30) NOT NULL,
	Dateborn date NOT NULL,
	Number VARCHAR(10) NOT NULL,
	Pasport VARCHAR(10) NOT NULL,
	PRIMARY KEY(ID)
)
drop table Tiket
drop table tiket
drop table tiket
drop table tiket
drop table tiket

create table Reviews(
ID INT NOT NULL IDENTITY ,
	CityFrom VARCHAR(16) NOT NULL,
	DateFrom DateTime NOT NULL,
	DateTo DateTime NOT NULL,
	CityTo VARCHAR(30) NOT NULL,
	Comment VARCHAR(100) NOT NULL,
	ClientID INT NOT NULL,
	FOREIGN KEY (ClientID) REFERENCES Client (ID),
	PRIMARY KEY(ID)
)
create table Grades(
ID INT NOT NULL IDENTITY ,
	Title VARCHAR(50) NOT NULL,
	Rate INT NOT NULL,
	ReviewID INT NOT NULL,
	FOREIGN KEY (ReviewID) REFERENCES Reviews (ID),
	PRIMARY KEY(ID)
)

create table City(
ID INT NOT NULL IDENTITY ,
	Name VARCHAR(50) NOT NULL,
	PRIMARY KEY(ID)
)

