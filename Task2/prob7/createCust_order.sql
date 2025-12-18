create database cust_orders
use cust_orders

create table Customers(
	customer_id int primary key,
	first_name varchar(10),
	last_name varchar(10),
	email varchar(20)
)

create table orders(
	order_id int primary key,
	customer_id int ,
	order_date date,
	amount decimal
)

alter table orders
add constraint FK_cust_order
foreign key (customer_id)
References Customers(customer_id)

insert into Customers
values(1,'John','Doe','john@email.com'),
	  (2,'Jane','Smith','jane@email.com'),
	  (3,'Mike','Johnson','mike@email.com')

insert into orders
values (101,1,'2024-01-15',250.00),
	   (102,1,'2024-02-20',180.50),
	   (103,NULL,'2024-03-10',99.99),
	   (104,2,'2024-03-15',320.00)

	  