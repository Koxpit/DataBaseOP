-- CREATE Database

CREATE DATABASE DataBaseOP;
USE DataBaseOP;

CREATE TABLE Position
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Worker
(
ID INT PRIMARY KEY IDENTITY,
FIO NVARCHAR(100) NOT NULL,
Phone NVARCHAR(11) NOT NULL UNIQUE,
PositionID INT REFERENCES Position(ID) NOT NULL
);

CREATE TABLE Category
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Trademark
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL UNIQUE,
Address NVARCHAR(200) NOT NULL,
Phone NVARCHAR(11) NOT NULL UNIQUE
);

CREATE TABLE Product
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(100) NOT NULL UNIQUE,
Amount INT NOT NULL,
Unit NVARCHAR(20) NOT NULL,
Cost MONEY NOT NULL,
CategoryID INT REFERENCES Category(ID) NOT NULL,
Description NVARCHAR(500) NOT NULL,
TrademarkID INT REFERENCES Trademark(ID) NOT NULL
);

CREATE TABLE Supplier
(
ID INT PRIMARY KEY IDENTITY,
FIO NVARCHAR(100) NOT NULL,
Address NVARCHAR(200) NOT NULL,
Phone NVARCHAR(11) NOT NULL UNIQUE
);

CREATE TABLE Realization
(
ID INT PRIMARY KEY IDENTITY,
Number NVARCHAR(8) NOT NULL UNIQUE,
RealizeDate DATE NOT NULL,
SupplierID INT REFERENCES Supplier(ID),
SeniorID INT REFERENCES Worker(ID),
Cost MONEY NOT NULL,
Discount MONEY NOT NULL,
AmountDue MONEY NOT NULL,
PaidOf MONEY NOT NULL,
Change MONEY NOT NULL,
AmountProducts INT NOT NULL,
ProductID INT REFERENCES Product(ID),
Realized BIT NOT NULL
);




-- INIT Database

INSERT INTO Position (Name)
VALUES ('Менеджер'), ('Бухгалтер'), ('Директор')

INSERT INTO Worker (FIO, Phone, PositionID)
VALUES 
('Емельянов Терентий Куприянович', '74954088724', 1),
('Фролов Андрей Александрович', '74950418722', 2),
('Чернов Харитон Федорович', '74955829532', 3)

INSERT INTO Category (Name)
VALUES ('Игрушки'), ('Кухонная мебель'), ('Кацелярия')

INSERT INTO Trademark (Name, Address, Phone)
VALUES
('Mistery', '027143, Сахалинская область, город Шатура, проезд Ладыгина, 97', '74957705124'),
('Ласка', '292616, Вологодская область, город Серпухов, наб. Космонавтов, 70', '74953600800')

INSERT INTO Product (Name, Amount, Unit, Cost, CategoryID, Description, TrademarkID)
VALUES
('Робокоп', 200, 'шт.', 120, 1, 'Плюшевая игрушка', 1),
('EcoPoint', 500, 'шт.', 80, 1, 'Синяя шариковая ручка', 1)

INSERT INTO Supplier (FIO, Address, Phone)
VALUES
('Рябов Борис Юрьевич', '475265, Саратовская область, город Видное, бульвар Косиора, 42', '74957705128'),
('Тихонов Феликс Игоревич', '057649, Калужская область, город Дмитров, шоссе Ломоносова, 89', '74957705199')

INSERT INTO Realization (Number, RealizeDate, SupplierID, SeniorID, Cost, Discount, AmountDue, PaidOf, Change, AmountProducts, ProductID, Realized)
VALUES
('00000001', '12.12.2020', 1, 1, 1200, 10, 1080, 1500, 420, 10, 1, 1), 
('00000002', '12.03.2021', 2, 1, 800, 0, 800, 1000, 200, 10, 2, 1)



-- PROCEDURES

-- INSERT

GO
CREATE PROCEDURE cp_InsertPosition
@Name NVARCHAR(50)
AS
INSERT INTO Position (Name) VALUES (@Name)
GO

GO
CREATE PROCEDURE cp_InsertCategory
@Name NVARCHAR(100)
AS
INSERT INTO Category (Name) VALUES (@Name)
GO

GO
CREATE PROCEDURE cp_InsertWorker
@FIO NVARCHAR(100),
@Phone NVARCHAR(11),
@PositionID INT
AS
INSERT INTO Worker (FIO, Phone, PositionID) VALUES (@FIO, @Phone, @PositionID)
GO

GO
CREATE PROCEDURE cp_InsertTrademark
@Name NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
INSERT INTO Trademark (Name, Address, Phone) VALUES (@Name, @Address, @Phone)
GO

GO
CREATE PROCEDURE cp_InsertProduct
@Name NVARCHAR(100),
@Amount INT,
@Unit NVARCHAR(20),
@Cost MONEY,
@CategoryID INT,
@Description NVARCHAR(500),
@TrademarkID INT
AS
INSERT INTO Product (Name, Amount, Unit, Cost, CategoryID, Description, TrademarkID) 
VALUES (@Name, @Amount, @Unit, @Cost, @CategoryID, @Description, @TrademarkID)
GO

GO
CREATE PROCEDURE cp_InsertSupplier
@FIO NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
INSERT INTO Supplier (FIO, Address, Phone) VALUES (@FIO, @Address, @Phone)
GO

GO
CREATE PROCEDURE cp_InsertRealization
@Number NVARCHAR(8),
@RealizeDate DATE,
@SupplierID INT,
@SeniorID INT,
@Cost MONEY,
@Discount MONEY,
@AmountDue MONEY,
@PaidOf MONEY,
@Change MONEY,
@AmountProducts INT,
@ProductID INT,
@Realized BIT
AS
INSERT INTO Realization(Number, RealizeDate, SupplierID, SeniorID, Cost, Discount, AmountDue, PaidOf, Change, AmountProducts, ProductID, Realized) 
VALUES (@Number, @RealizeDate, @SupplierID, @SeniorID, @Cost, @Discount, @AmountDue, @PaidOf, @Change, @AmountProducts, @ProductID, @Realized)
GO



-- UPDATE

GO
CREATE PROCEDURE cp_UpdatePosition
@ID INT,
@Name NVARCHAR(50)
AS
UPDATE Position
SET Name = @Name
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateCategory
@ID INT,
@Name NVARCHAR(100)
AS
UPDATE Category
SET Name = @Name
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateWorker
@ID INT,
@FIO NVARCHAR(100),
@Phone NVARCHAR(11),
@PositionID INT
AS
UPDATE Worker
SET FIO = @FIO, Phone = @Phone, PositionID = @PositionID
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateTrademark
@ID INT,
@Name NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
UPDATE Trademark
SET Name = @Name, Address = @Address, Phone = @Phone
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateProduct
@ID INT,
@Name NVARCHAR(100),
@Amount INT,
@Unit NVARCHAR(20),
@Cost MONEY,
@CategoryID INT,
@Description NVARCHAR(500),
@TrademarkID INT
AS
UPDATE Product
SET Name = @Name, Amount = @Amount, Unit = @Unit, 
Cost = @Cost, CategoryID = @CategoryID, 
Description = @Description, TrademarkID = @TrademarkID
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateSupplier
@ID INT,
@FIO NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
UPDATE Supplier
SET FIO = @FIO, Address = @Address, Phone = @Phone
WHERE ID = @ID
GO

GO
CREATE PROCEDURE cp_UpdateRealization
@ID INT,
@Number NVARCHAR(8),
@RealizeDate DATE,
@SupplierID INT,
@SeniorID INT,
@Cost MONEY,
@Discount MONEY,
@AmountDue MONEY,
@PaidOf MONEY,
@Change MONEY,
@AmountProducts INT,
@ProductID INT,
@Realized BIT
AS
UPDATE Realization
SET Number = @Number, RealizeDate = @RealizeDate, SupplierID = @SupplierID, 
SeniorID = @SeniorID, Cost = @Cost, Discount = @Discount, AmountDue = @AmountDue,
PaidOf = @PaidOf, Change = @Change, AmountProducts = @AmountProducts, 
ProductID = @ProductID, Realized = @Realized
WHERE ID = @ID
GO


-- DELETE

GO
CREATE PROCEDURE sp_DeletePosition
@ID INT
AS
DELETE Position WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteCategory
@ID INT
AS
DELETE Category WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteWorker
@ID INT
AS
DELETE Worker WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteTrademark
@ID INT
AS
DELETE Trademark WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteProduct
@ID INT
AS
DELETE Product WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteSupplier
@ID INT
AS
DELETE Supplier WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_DeleteRealization
@ID INT
AS
DELETE Realization WHERE ID = @ID
GO


-- Supplier - поставщик, Trademark - бренд.

-- Realization:
-- Senior - ответсвтенный за работу;
-- Discount - скидка;
-- AmountDue - сумма к оплате;
-- PaidOf - оплачено;
-- Change - сдача.

-- Product:
-- Unit - ед. измерения;
-- Amount - кол-во на складе.