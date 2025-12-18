create database Emp_Dept
use Emp_Dept

create table Employees(
	emp_id int primary key,
	emp_name varchar(20),
	dept_id int
)

create table Departments(
	dept_id int primary key,
	dept_name varchar(20)
)

Alter table Employees
Add Constraint FK_Emp_Depart
Foreign Key (dept_id)
References Departments(dept_id)

insert into Departments
values (101,'Sales'),(102,'Marketing'),(103,'IT')

insert into Employees
values(1,'Alice',101),(2,'Bob',NULL),(3,'Charlie',102),(4,'Diana',NULL)