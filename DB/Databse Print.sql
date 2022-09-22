UserTable
========
UserId int
UserName varchar(500)
EmailId varchar(300)
Password nvarchar(500)
RoleId int
Active bit
FirstName varchar(50)
LastName Varchar(50)


RoleMaster
===========
RoleName varchar(50),
RollId int primary key

Category
========

CategoryId int 
CategoryName varchar(50)


Book
====

BookId int
BookName varchar(500)
CategoryId int 
Price decimal
Publisher varchar(500)
UserId int 
PublishedDate Date
Content Ntext
Active bit
CreatedDate date
Createdby int
ModifiedDate date
Modifiedby int

Purchase
========

PurchaseId int 
EmailId varchar(500)
BoodId int
PurchaseDate date
PaymentMode varchar(100)
