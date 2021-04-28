-- CREATE Database

CREATE DATABASE DataBaseOP;
USE DataBaseOP;

CREATE TABLE Position
(
ID INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Client
(
ID INT PRIMARY KEY IDENTITY,
FIO NVARCHAR(100) NOT NULL,
Phone NVARCHAR(11) NOT NULL UNIQUE,
Address NVARCHAR(200) NOT NULL,
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
ClientID INT REFERENCES Client(ID),
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

INSERT INTO Client (FIO, Phone, Address)
VALUES
('Пестов Афанасий Евсеевич', '74957705111', '947904, Калининградская область, город Луховицы, пер. Ломоносова, 07'),
('Степанов Артем Владленович', '74953600899', '277529, Смоленская область, город Домодедово, пер. Домодедовская, 44')

INSERT INTO Realization (Number, RealizeDate, ClientID, SupplierID, SeniorID, Cost, Discount, AmountDue, PaidOf, Change, AmountProducts, ProductID, Realized)
VALUES
('00000001', '12.12.2020', 1, 1, 1, 1200, 10, 1080, 1500, 420, 10, 1, 1), 
('00000002', '12.03.2021', 2, 2, 1, 800, 0, 800, 1000, 200, 10, 2, 1)




-- PROCEDURES

-- INSERT

GO
CREATE PROCEDURE sp_InsertPosition
@Name NVARCHAR(50)
AS
INSERT INTO Position (Name) VALUES (@Name)
GO

GO
CREATE PROCEDURE sp_InsertCategory
@Name NVARCHAR(100)
AS
INSERT INTO Category (Name) VALUES (@Name)
GO

GO
CREATE PROCEDURE sp_InsertClient
@FIO NVARCHAR(100),
@Phone NVARCHAR(11),
@Address NVARCHAR(200)
AS
INSERT INTO Client (FIO, Phone, Address) VALUES (@FIO, @Phone, @Address)
GO

GO
CREATE PROCEDURE sp_InsertWorker
@FIO NVARCHAR(100),
@Phone NVARCHAR(11),
@PositionID INT
AS
INSERT INTO Worker (FIO, Phone, PositionID) VALUES (@FIO, @Phone, @PositionID)
GO

GO
CREATE PROCEDURE sp_InsertTrademark
@Name NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
INSERT INTO Trademark (Name, Address, Phone) VALUES (@Name, @Address, @Phone)
GO

GO
CREATE PROCEDURE sp_InsertProduct
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
CREATE PROCEDURE sp_InsertSupplier
@FIO NVARCHAR(100),
@Address NVARCHAR(200),
@Phone NVARCHAR(11)
AS
INSERT INTO Supplier (FIO, Address, Phone) VALUES (@FIO, @Address, @Phone)
GO

GO
CREATE PROCEDURE sp_InsertRealization
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
CREATE PROCEDURE sp_UpdatePosition
@ID INT,
@Name NVARCHAR(50)
AS
UPDATE Position
SET Name = @Name
WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_UpdateCategory
@ID INT,
@Name NVARCHAR(100)
AS
UPDATE Category
SET Name = @Name
WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_UpdateClient
@ID INT,
@FIO NVARCHAR(100),
@Phone NVARCHAR(11),
@Address NVARCHAR(200)
AS
UPDATE Client
SET FIO = @FIO, Phone = @Phone, Address = @Address
WHERE ID = @ID
GO

GO
CREATE PROCEDURE sp_UpdateWorker
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
CREATE PROCEDURE sp_UpdateTrademark
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
CREATE PROCEDURE sp_UpdateProduct
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
CREATE PROCEDURE sp_UpdateSupplier
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
CREATE PROCEDURE sp_UpdateRealization
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
CREATE PROCEDURE sp_DeleteClient
@ID INT
AS
DELETE Client WHERE ID = @ID
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



-- GET

GO
CREATE PROCEDURE sp_GetAllPositions
AS
SELECT ID, Name AS 'Наименование'
FROM Position
GO

GO
CREATE PROCEDURE sp_GetAllCategories
AS
SELECT ID, Name AS 'Наименование', 'Удалить' AS [Операция]
FROM Category
GO

GO
CREATE PROCEDURE sp_GetAllClients
AS
SELECT ID, FIO AS 'ФИО', Phone AS 'Телефон', Address AS 'Адрес', 'Удалить' AS [Операция]
FROM Client
GO

GO
CREATE PROCEDURE sp_GetAllTrademarks
AS
SELECT ID, Name AS 'Наименование', Address AS 'Адрес', Phone AS 'Телефон', 'Удалить' AS [Операция]
FROM Trademark
GO

GO
CREATE PROCEDURE sp_GetAllSuppliers
AS
SELECT ID, FIO AS 'ФИО', Address AS 'Адрес', Phone AS 'Телефон', 'Удалить' AS [Операция]
FROM Supplier
GO

GO
CREATE PROCEDURE sp_GetAllWorkers
AS
SELECT Worker.ID, FIO AS 'ФИО', Phone AS 'Телефон', Position.Name AS 'Должность'
FROM Worker
JOIN Position ON Worker.PositionID = Position.ID
GO

GO
CREATE PROCEDURE sp_GetAllProducts
AS
SELECT 
Product.ID, Product.Name AS 'Наименование', Amount AS 'Кол-во на складе', Unit AS 'Ед.изм.', 
Cost AS 'Стоимость', Category.Name AS 'Категория', Description AS 'Описание', 
Trademark.Name AS 'Бренд', 'Удалить' AS [Операция]
FROM Product
JOIN Category ON Product.CategoryID = Category.ID
JOIN Trademark ON Product.TrademarkID = Trademark.ID
GO

GO
CREATE PROCEDURE sp_GetAllRealizations
AS
SELECT 
Realization.ID, Number AS 'Номер договора', RealizeDate AS 'Срок реализации', 
Client.Phone AS 'Телефон заказчика', Supplier.Phone AS 'Телефон поставщика', Worker.Phone AS 'Телефон работника', 
Realization.Cost AS 'Стоимость', Discount AS 'Скидка (%)', AmountDue AS 'Сумма к оплате', PaidOf AS 'Оплачено', Change AS 'Сдача', 
AmountProducts AS 'Кол-во продукции', Product.Name AS 'Наименование продукта', Realized AS 'Реализовано', 'Удалить' AS [Операция]
FROM Realization
JOIN Supplier ON Realization.SupplierID = Supplier.ID
JOIN Worker ON Realization.SeniorID = Worker.ID
JOIN Product ON Realization.ProductID = Product.ID
JOIN Client ON Realization.ClientID = Client.ID
GO

GO
CREATE PROCEDURE sp_GetPositionIdByName
@Name NVARCHAR(50)
AS
SELECT ID
FROM Position
WHERE Name = @Name
GO

GO
CREATE PROCEDURE sp_GetClientIdByPhone
@Phone NVARCHAR(11)
AS
SELECT ID
FROM Client
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetClientInfoByPhone
@Phone NVARCHAR(11)
AS
SELECT FIO, Address
FROM Client
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetTrademarkIdByName
@Name NVARCHAR(100)
AS
SELECT ID
FROM Trademark
WHERE Name = @Name
GO

GO
CREATE PROCEDURE sp_GetTrademarkIdByPhone
@Phone NVARCHAR(11)
AS
SELECT ID
FROM Trademark
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetCategoryIdByName
@Name NVARCHAR(100)
AS
SELECT ID
FROM Category
WHERE Name = @Name
GO

GO
CREATE PROCEDURE sp_GetSupplierIdByPhone
@Phone NVARCHAR(11)
AS
SELECT ID
FROM Supplier
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetSupplierInfoByPhone
@Phone NVARCHAR(11)
AS
SELECT FIO, Address
FROM Supplier
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetWorkerIdByPhone
@Phone NVARCHAR(11)
AS
SELECT ID
FROM Worker
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetWorkerInfoByPhone
@Phone NVARCHAR(11)
AS
SELECT FIO, Position.Name
FROM Worker
JOIN Position ON Worker.PositionID = Position.ID
WHERE Phone = @Phone
GO

GO
CREATE PROCEDURE sp_GetProductIdByName
@Name NVARCHAR(100)
AS
SELECT ID
FROM Product
WHERE Name = @Name
GO

GO
CREATE PROCEDURE sp_GetRealizationIdByNumber
@Number NVARCHAR(8)
AS
SELECT ID
FROM Realization
WHERE Number = @Number
GO


-- REPORTS

GO
CREATE PROCEDURE sp_GetRealizationsResult
@BeginDate NVARCHAR(20),
@EndDate NVARCHAR(20)
AS
SELECT SUM(AmountDue) AS 'Выручка', SUM(Cost) AS 'Оборот'
FROM Realization
WHERE RealizeDate BETWEEN @BeginDate AND @EndDate
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