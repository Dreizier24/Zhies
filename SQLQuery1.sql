create table [Request](
[RequestId] int primary key identity(1,1),
Equipment nvarchar(50) not null,
EquipmentTypeId int not null,
StatusId int not null,
ProblemDescription nvarchar(500) not null,
StartDate date not null,
ClientId int not null,
DateEnd date,
MasterId int,
)
go
create table [Status](
Id int primary key identity(1,1),
[StatusTitle] nvarchar(30) not null,
)
go
create table [EquipmentType](
Id int primary key identity(1,1),
[EquipmentTitle] nvarchar(30) not null,
)
go
create table [UserType](
Id int primary key identity(1,1),
[UserTitle] nvarchar(30) not null,
)

create table Client(
Id int primary key identity(1,1),
[UserId] int not null,
)

create table Master(
Id int primary key identity(1,1),
[UserId] int not null,
)
create table [User](
[UserId] int primary key identity(1,1),
[Login] nvarchar(30) not null,
[Password] nvarchar(30) not null,
[Name] nvarchar(30) not null,
[Surname] nvarchar(30) not null,
[LastName] nvarchar(30),
[Phone] nvarchar(12) not null,
[TypeId] int not null,
)

create table Comment(
Id int primary key identity(1,1),
Comment nvarchar(250) not null,
RequsetId int not null,
MasterId int not null,
)