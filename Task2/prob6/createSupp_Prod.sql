create database Supp_Prod

use Supp_Prod

create table Products(
	product_id int primary key,
	product_name varchar(20),
	supplier_id int
)

create table Suppliers(
	supplier_id int primary key,
	supplier_name varchar(20),
	country varchar(20)
)

alter table Products 
add constraint FK_Supp_Prod
foreign key (supplier_id)
References Suppliers(supplier_id)

insert into Products
values(1,'iPhone 14',201),(2,'Laptop Pro',202),(3,'Samsung Phone',NULL),(4,'Headphones',201),(5,'Android Phone X',203)

insert into Suppliers
values(201,'TechCorp','USA'),(202,'CompuWorld','Canada'),(203,'MobileTech','China')