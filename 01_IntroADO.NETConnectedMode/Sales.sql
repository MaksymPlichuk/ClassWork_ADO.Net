create database Sales
use Sales

create table Buyers(
	Id int not null primary key identity,
	Name nvarchar(50) not null check(Name<>''),
	Surname nvarchar(50) not null check(Surname<>''),
);
create table Sellers(
	Id int not null primary key identity,
	Name nvarchar(50) not null check(Name<>''),
	Surname nvarchar(50) not null check(Surname<>''),
);
create table Sales(
	Id int not null primary key identity,
	BuyerId int not null references Buyers(Id),
	SellerId int not null references  Sellers(Id),
	Price int not null check(Price>0),
	SaleDate date not null check(SaleDate<GETDATE()) default(GETDATE())
)

----
select * from Sellers
select * from Buyers

select b.Name +' '+b.Surname as [Buyer],s.Price,s.SaleDate,sl.Name+' '+ sl.Surname as [Seller]
from Sales as s join Buyers as b on s.BuyerId=b.Id
				join Sellers as sl on s.SellerId=sl.Id



----

INSERT INTO Buyers (Name, Surname) VALUES (N'Ivan', N'Petrenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Oksana', N'Sydorenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Andrii', N'Melnyk');
INSERT INTO Buyers (Name, Surname) VALUES (N'Svitlana', N'Kovalenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Mykola', N'Bondarenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Olha', N'Zinchenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Vasyl', N'Datsenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Yulia', N'Ivchenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Roman', N'Shevchenko');
INSERT INTO Buyers (Name, Surname) VALUES (N'Nadiia', N'Tymoshenko');

INSERT INTO Sellers (Name, Surname) VALUES (N'Dmytro', N'Krutov');
INSERT INTO Sellers (Name, Surname) VALUES (N'Alina', N'Lebedieva');
INSERT INTO Sellers (Name, Surname) VALUES (N'Petro', N'Romanenko');
INSERT INTO Sellers (Name, Surname) VALUES (N'Kateryna', N'Shapoval');
INSERT INTO Sellers (Name, Surname) VALUES (N'Artem', N'Horbach');
INSERT INTO Sellers (Name, Surname) VALUES (N'Mariia', N'Semenova');
INSERT INTO Sellers (Name, Surname) VALUES (N'Ihor', N'Kuzmenko');
INSERT INTO Sellers (Name, Surname) VALUES (N'Natalia', N'Lytvyn');
INSERT INTO Sellers (Name, Surname) VALUES (N'Serhii', N'Makarenko');
INSERT INTO Sellers (Name, Surname) VALUES (N'Anna', N'Drozd');


INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (1, 2, 1500, '2025-09-01');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (3, 4, 2300, '2025-08-15');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (5, 1, 3200, '2025-07-30');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (2, 3, 2800, '2025-06-20');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (6, 5, 1700, '2025-05-25');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (4, 6, 2100, '2025-04-10');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (7, 7, 1900, '2025-03-12');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (8, 8, 3100, '2025-02-18');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (9, 9, 2700, '2025-01-05');
INSERT INTO Sales (BuyerId, SellerId, Price, SaleDate) VALUES (10, 10, 2500, '2024-12-01');