  --drop table RoleMaster
  --drop table Category
  --drop table UserTable
  --drop table Book
  --drop table Purchase


CREATE TABLE RoleMaster (
    RoleId int IDENTITY(1,1) NOT NULL Primary key,
    RoleName varchar(50)
);
CREATE TABLE Category (
    CategoryId int IDENTITY(1,1) NOT NULL Primary key,
    CategoryName varchar(50)
);
CREATE TABLE UserTable (
    UserId int IDENTITY(1,1) NOT NULL Primary key,
    UserName varchar(500),
    EmailId varchar(300),
	Password nvarchar(500),
	RoleId int,
	Active bit,
	FirstName varchar(256),
	LastName Varchar(256),
    CONSTRAINT FK_Role FOREIGN KEY (RoleId)
    REFERENCES RoleMaster(RoleId)
);
CREATE TABLE Book (
    BookId int IDENTITY(1,1) NOT NULL Primary key,
    BookName varchar(500),
    CategoryId int, 
	Price decimal(18,2),
	Publisher varchar(500),
	UserId int, 
	PublishedDate Date,
	Content Ntext,
	Active bit,
	CreatedDate date,
	Createdby int,
	ModifiedDate date,
	Modifiedby int,
    CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId),
    CONSTRAINT FK_UserTable_UserId FOREIGN KEY (UserId) REFERENCES UserTable(UserId),
);
CREATE TABLE Purchase (
   PurchaseId int IDENTITY(1,1) NOT NULL Primary key, 
EmailId varchar(500),
BookId int,
PurchaseDate date,
PaymentMode varchar(100),
    CONSTRAINT FK_Book FOREIGN KEY (BookId) REFERENCES Book(BookId)
);


