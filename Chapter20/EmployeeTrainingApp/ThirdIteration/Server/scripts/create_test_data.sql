use EmployeeTraining
go

insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('E4F786EC-D8FC-472A-9E8C-4DDE307ABEC8', 'Rick', 'Warren', 'Miller', '3/13/1961', 'M')
go
insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('25BF3A98-AB02-445E-A5F7-67B74C6A9515', 'Steve', 'Jacob', 'Bishop', '2/10/1942', 'M')
go
insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('74F9A6B5-F099-4829-8CD1-89A4A01B5F96', 'Coralie', 'Sarah', 'Powell', '10/10/1974', 'F')
go
insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('439A7460-9D35-4ABC-ABDF-A48F6B224D42', 'Kyle', 'Victor', 'Miller', '8/25/1986', 'M')
go
insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('DF67C044-A7A8-4E22-B602-C4DA6C48E485', 'Patrick', 'Tony', 'Condemi', '4/17/1961', 'M')
go
insert into tbl_employee (employeeid, firstname, middlename, lastname, birthday, gender)
values ('522C2C1F-2088-40A3-9E1B-D27910CA0006', 'Dana', 'Lee', 'Condemi', '11/1/1965', 'F')
go


insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('E4F786EC-D8FC-472A-9E8C-4DDE307ABEC8', 'Advanced Microsoft Word', 'Description text here...', 
'11/2/2007', '11/5/2007', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('E4F786EC-D8FC-472A-9E8C-4DDE307ABEC8', 'Project Management Professional', 'Description text here...', 
'6/12/2006', '6/15/2006', 'Passed')
go

insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('25BF3A98-AB02-445E-A5F7-67B74C6A9515', 'Project Management Professional', 'Description text here...', 
'6/12/2006', '06/15/2006', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('74F9A6B5-F099-4829-8CD1-89A4A01B5F96', 'C# Programming', 'Description text here...', 
'1/15/2007', '5/8/2007', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('439A7460-9D35-4ABC-ABDF-A48F6B224D42', 'Managing Difficult Employees', 'Description text here...', 
'1/2/2007', '1/4/2007', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('439A7460-9D35-4ABC-ABDF-A48F6B224D42', 'Project Management Professional', 'Description text here...', 
'6/12/2006', '6/15/2006', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('DF67C044-A7A8-4E22-B602-C4DA6C48E485', 'Squeezing Profit Margins', 'Description text here...', 
'7/5/2004', '7/10/2004', 'Passed')
go
insert into tbl_employee_training (EmployeeID, Title, Description, StartDate, EndDate, Status)
values ('522C2C1F-2088-40A3-9E1B-D27910CA0006', 'Project Financial Management', 'Description text here...', 
'8/2/2007', '8/5/2007', 'Passed')
go

