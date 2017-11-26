use EmployeeTraining

alter table tbl_employee_training drop constraint fk_employee
go

drop table tbl_employee
go

create table tbl_employee (
   EmployeeID uniqueidentifier not null primary key,
   FirstName varchar(50) not null,
   MiddleName varchar(50) not null,
   LastName varchar(50) not null,
   Birthday datetime not null,
   Gender varchar(1) not null,
   Picture varbinary(max) null
)
go

drop table tbl_employee_training
go

create table tbl_employee_training (
   TrainingID int not null Identity(1,1) primary key,
   EmployeeID uniqueidentifier not null,
   Title varchar(200) not null,
   Description varchar(500) not null,
   StartDate datetime null,
   EndDate datetime null,
   Status varchar(25)
)
go

alter table tbl_employee_training
add constraint fk_employee
foreign key (EmployeeID)
references tbl_employee (EmployeeID) on delete cascade
go