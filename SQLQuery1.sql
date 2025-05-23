﻿CREATE TABLE Users(
	UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(255) NOT NULL,
	UserPassword VARCHAR(50) NOT NULL,
	UserEmail VARCHAR(100) NOT NULL,
	UserGender VARCHAR(100) NOT NULL,
	UserDOB DATE NOT NULL,
	UserRole VARCHAR(100) NOT NULL
)

CREATE TABLE "Card"(
	CardID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CardName VARCHAR(100) NOT NULL,
	CardPrice DECIMAL(10, 2) NOT NULL,
	CardDesc VARCHAR(100) NOT NULL,
	CardType VARCHAR(100) NOT NULL,
	isFoil BIT NOT NULL,
	CartsCartID INT NOT NULL
)

CREATE TABLE Carts(
	CartID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CardID INT NOT NULL REFERENCES "Card"(CardID),
	UserID INT NOT NULL REFERENCES Users(UserID),
	Quantity INT NOT NULL
)

CREATE TABLE TransactionHeader(
	TransactionID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	TransactionDate DATE NOT NULL,
	CustomerID INT NOT NULL REFERENCES Users(UserID),
	Status VARCHAR(100) NOT NULL
)

CREATE TABLE TransactionDetail(
	TransacttionID INT NOT NULL REFERENCES TransactionHeader(TransactionID),
	CardID INT NOT NULL REFERENCES "Card"(CardID),
	Quantity INT NOT NULL
)