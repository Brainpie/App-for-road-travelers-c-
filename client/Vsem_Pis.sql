create table Route(
ID INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	TypeCar VARCHAR(15) NOT NULL,
	PointOfDeparture VARCHAR(25) NOT NULL,
	PointOfArrivale VARCHAR(25) NOT NULL,
	Price INT NOT NULL
)
SELECT * FROM ROUTE
