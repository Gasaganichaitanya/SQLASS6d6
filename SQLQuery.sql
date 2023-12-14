create database Assignment6
use Assignment6

create table Products(
ProductId int primary key,
ProductName nvarchar(50),
Price float not null,
Quantity int not null,
MfDate date,
ExpDate date)

insert into Products values (1,'Lays',20,1,'10/20/2023','11/22/2024')
insert into Products values (2,'Sprite',105,2,'08/23/2022','09/18/2023')
insert into Products values (3,'Maggi',50,3,'02/27/2023','06/15/2025')
insert into Products values (4,'Dairy Milk',200,1,'06/04/2022','03/24/2024')

select * from Products