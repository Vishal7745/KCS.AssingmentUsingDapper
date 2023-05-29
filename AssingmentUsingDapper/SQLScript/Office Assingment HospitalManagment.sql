
create Database HospitalManagement
use HospitalManagement

create table [User Management]
(
Id int primary key identity,
FirstName varchar(20) not null,
LastName varchar(20) not null,
EmailId varchar(50) not null unique,
Password varchar(8) not null,
UserRole varchar(10) not null,
IsActive varchar(1)
)

insert into [User Management] values('Ram','charan','ram.charan@gamil.com','123456','user',1)

select * from [User Management]

--===================================================================================
--Select From [User Management]
Create proc Usp_GetUserManagement
as
begin
   select Id,FirstName,LastName,EmailId,Password,UserRole,IsActive from [User Management]
end

exec Usp_GetUserManagement
--===================================================================================

--Select Single userBy ID [User Management]
Create proc Usp_GetUserManagementById
(@id int)
as
begin
   select *from [User Management]
   where Id=@id
end

exec Usp_GetUserManagementById 6
--===================================================================================
--Insert Record Into LoginUser
Create proc Usp_InsertUserManagement
(
@Id int,
@FirstName varchar(20),
@LastName varchar(20),
@EmailId varchar(50),
@Password varchar(8),
@UserRole varchar(10),
@IsActive varchar(1)
)
as
begin
    begin tran
		   begin try
				   Insert into [User Management] (Id,FirstName,LastName,EmailId,Password,UserRole,IsActive) 
				   values(@Id,@FirstName,@LastName,@EmailId,@Password,@UserRole,@IsActive)
				   commit;
		   end try
	    begin catch
		           SELECT ERROR_MESSAGE() as Response
				   RollBack;
		end catch
end


--===================================================================================
--Delete From [User Management] 
create proc Usp_DeleteUserManagement
(
@Id int
)
as
begin
     begin tran
	     begin try
		          Delete from [User Management] where Id=@Id
				  select 'DELETED USER SUCCESSFULLY' as Successfully
				  COMMIT;
		 end try
		 begin catch
		         select ERROR_MESSAGE() as Response
				 ROLLBACK;
		 end catch
    
end

--===================================================================================
--Update [User Management] 
alter proc Usp_UpdateUserProfile
(
@Id int,
@FirstName varchar(20),
@LastName varchar(20),
@EmailId varchar(50),
@Password varchar(8),
@UserRole varchar(10),

@IsActive varchar(1)
)
as
begin
     begin tran
	       begin try
		          update [User Management] 
				  set FirstName=@FirstName,LastName=@LastName,EmailId=@EmailId,Password=@Password,UserRole=@UserRole,IsActive=@IsActive
				  where Id=@Id;
				  Select 'RECORD UPDATED SUCCESSFULLY' as Response
		          COMMIT;
		   end try
		   begin catch
		            select ERROR_MESSAGE() as Response
					ROLLBACK;
		   end catch
end

--===================================================================================
--Login Admin/User
create proc usp_GetLogin
@EmailId varchar(50) ,
@Password varchar(8)
as
begin
		select * from [User Management] where EmailId=@EmailId and Password=@Password
end

exec usp_GetLogin @EmailId=[ram.charan@gamil.com],@Password=123456


--===================================================================================


create table PatientRegistration

(
Id int primary key identity,
FirstName Varchar(20) not null,
LastName varchar(20) not null,
PhoneNumber varchar(10) not null,
Email Varchar(50) unique not null,
Address varchar(100),
MedicalCondition varchar(100) not null,
Followup varchar(20)
)
insert into PatientRegistration values('Vishal','Chimkar','8087637315','vishal.chimkar@gmail.com',
'Pune','Stong','no')

select * from PatientRegistration

--===================================================================================
--Select * from PatientRegistration
Create proc [dbo].[Usp_ListOfPatient]
as
begin
	select * from PatientRegistration
end
exec Usp_ListOfPatient
--===================================================================================
--InsertInto Patient
alter proc Usp_InsertPatientRegistration
(
@FirstName varchar(20),
@LastName varchar(20),
@PhoneNumber varchar(50),
@Email varchar(50),
@Address varchar(10),
@MedicalCondition varchar(10),
@Followup varchar(20)
)
as
begin
   
		   begin try
				   Insert into PatientRegistration  values(@FirstName,@LastName,@PhoneNumber,@Email,@Address,@MedicalCondition,@Followup)
				  
		   end try
	    begin catch
		           SELECT ERROR_MESSAGE() as Response
				
		end catch
end
--===================================================================================
--Delete From PatientRegistration

alter proc Usp_DeletePatientRegistration
(@Id int 
)
as
begin
		begin tran
			begin try
				Delete PatientRegistration
				where Id=@Id;
				Select 'Delete Successfully'As Response
				COMMIT;
			end try

			begin catch
				select ERROR_MESSAGE() As Response
				ROLLBACK;
			end catch
end

exec Usp_DeletePatientRegistration 8

--===================================================================================

alter proc Usp_PatientById
(@Id int 
)
as
begin
		begin tran
			begin try
				Select * from PatientRegistration
				where Id=2;
				Select 'Delete Successfully'As Response
				COMMIT;
			end try

			begin catch
				select ERROR_MESSAGE() As Response
				ROLLBACK;
			end catch
end

--===================================================================================
--Upadate Patient
alter proc Usp_UpdatePatient
(
@Id int,
@FirstName varchar(20),
@LastName varchar(20),
@PhoneNumber varchar(10),
@Email varchar(50),
@Address varchar(50),
@MedicalCondition varchar(10),
@Followup varchar(20)
)
as
begin
		begin tran
			begin try
				Update PatientRegistration
				set FirstName=@FirstName,LastName=@LastName,PhoneNumber=@PhoneNumber,
				    Email=@Email,Address=@Address,MedicalCondition=@MedicalCondition,
					Followup=@Followup
				where Id=@Id;
				Select 'Update Successfully'As Response
				COMMIT;
			end try

			begin catch
				select ERROR_MESSAGE() As Response
				ROLLBACK;
			end catch
end
--===================================================================================


create table MedicineManagment
(
Id int Primary key identity,

Medicine_Name varchar(20), 
Price int,
Total_Stock int
)
insert into MedicineManagment values ('Paracetamol',10,100)
--===================================================================================
-- list Of Medicine Sp

alter Proc Usp_ListOfMedicine
as
begin
	Select Id, Medicine_Name,Price,Total_Stock from MedicineManagment
End

exec Usp_ListOfMedicine
--===================================================================================
alter Proc Usp_MedicineById
(@id int)
as
begin
	Select Medicine_Name,Price,Total_Stock from MedicineManagment
	where Id=@id;
End
--===================================================================================
create proc Usp_UpdateMedicine
(
@Id int,
@Medicine_Name varchar(20),
@Price int,
@Total_Stock int
)
as
begin
     begin tran
	       begin try
		          update MedicineManagment 
				  set Medicine_Name=@Medicine_Name,Price=@Price,Total_Stock=@Total_Stock
				  where Id=@Id;
				  Select 'RECORD UPDATED SUCCESSFULLY' as Response
		          COMMIT;
		   end try
		   begin catch
		            select ERROR_MESSAGE() as Response
					ROLLBACK;
		   end catch
end
--===================================================================================
create proc Usp_deleteMedicine
(
@Id int
)
as
begin
     begin tran
	       begin try
		         delete MedicineManagment
				  where Id=@Id;
				  Select 'RECORD UPDATED SUCCESSFULLY' as Response
		          COMMIT;
		   end try
		   begin catch
		            select ERROR_MESSAGE() as Response
					ROLLBACK;
		   end catch
end
--===================================================================================
--insert Into Medicine
create proc Usp_CreateMedicine
(
@Medicine_Name varchar(20),
@Price int,
@Total_Stock int
)
as
begin
     begin tran
	       begin try
		          Insert into MedicineManagment values(@Medicine_Name,@Price,@Total_Stock)
				  Select 'RECORD UPDATED SUCCESSFULLY' as Response
		          COMMIT;
		   end try
		   begin catch
		            select ERROR_MESSAGE() as Response
					ROLLBACK;
		   end catch
end
go

exec Usp_CreateMedicine 'Coldact',20,500
--====================================================================================

--Medicine Record
--drop table MedicineStock
create Table MedicineStock
(
MedicineCode char(10) primary key,
MedicineName varchar(50),
Price Double Precision,
Medicine_In_Stock int,
Medicine_Sold int
)
 insert into MedicineStock values('a1','Paracetamol',10,500,1)
  insert into MedicineStock values('a2','Disprin',11,1500,15)
   insert into MedicineStock values('a3','Zantac150',18,589,21)

 select * from MedicineStock

 --===================================================================================
 --drop table MedicineSales

 create table MedicineSales
 (
 Order_Id int primary key Identity,
 Order_date date,
 MedicineCode char(10),
 Quantiry_Order int,
 Sell_Price Double Precision
 )

 insert into MedicineSales values('2023-04-28','a1',100,482)
 insert into MedicineSales values('2022-04-29','a2',54,784)

 --==================================================================================
 --==================================================================================
 --==================================================================================
 create table PatientRegistration

(
Id int primary key identity,
FirstName Varchar(20) not null,
LastName varchar(20) not null,
PhoneNumber varchar(10) not null,
Email Varchar(50) unique not null,
Address varchar(100),
MedicalCondition varchar(100) not null,
Followup varchar(20)
)
--drop table details
create table PatientDetails
(
	Id int primary key identity,
	FirstName Varchar(20) not null,
	LastName varchar(20) not null,
	PhoneNumber varchar(10) not null,
	MedicalCondition varchar(100) not null,
	Followup varchar(20)
)
select * from PatientDetails
alter proc Usp_Details
@id int 
as
begin
	declare @FirstName Varchar(20),
	@LastName varchar(20),
	@PhoneNumber varchar(10),
	@MedicalCondition varchar(100) ,
	@Followup varchar(20)
	
	select @FirstName=FirstName,@LastName=LastName,@PhoneNumber=PhoneNumber,@MedicalCondition=MedicalCondition,@Followup=Followup from PatientRegistration 
	where id=@id

	insert into PatientDetails values(@FirstName,@LastName,@PhoneNumber,@MedicalCondition,@Followup)

	select * from PatientDetails where Id=@id

end

exec Usp_Details 1