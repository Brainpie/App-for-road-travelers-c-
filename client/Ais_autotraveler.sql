create table autotreveler(
ID INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name VARCHAR(20) NOT NULL,
	surname VARCHAR(25) NOT NULL,
	lastname VARCHAR(20) NOT NULL,
	dateborn DATE NOT NULL,
	number VARCHAR(10) NOT NULL,
	pasport VARCHAR(10) NOT NULL UNIQUE
)
Drop table autotreveler