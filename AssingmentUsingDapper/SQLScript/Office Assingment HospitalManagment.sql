
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
create proc Usp_UpdateUserManagement
(
@Id int,
@FirstName varchar(20),
@LastName varchar(20),
@EmailId varchar(50),
@Password varchar(8),
@UserRole varchar(10),
@Passward varchar(8),
@IsActive varchar(1)
)
as
begin
     begin tran
	       begin try
		          update [User Management] 
				  set FirstName=@FirstName,LastName=@LastName,EmailId=@EmailId,Password=@Password,IsActive=@IsActive
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
create table Users
(
MedicineName varchar(20),
Price int,
TotalStock int
)
insert into Users values('Paracitamol',10,200)

select * from Users
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
--===================================================================================
--InsertInto Patient
create proc Usp_InsertPatientRegistration
(
@FirstName varchar(20),
@LastName varchar(20),
@PhoneNumber varchar(50),
@Email varchar(8),
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

create proc Usp_DeletePatientRegistration
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

create proc Usp_PatientById
(@Id int 
)
as
begin
		begin tran
			begin try
				Select * from PatientRegistration
				where Id=@Id;
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
@PhoneNumber varchar(50),
@Email varchar(8),
@Address varchar(10),
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
Price	int,
Total_Stock int
)
insert into MedicineManagment values ('Paracetamol',10,100)
--===================================================================================
-- list Of Medicine Sp

create Proc Usp_ListOfMedicine
as
begin
	Select * from MedicineManagment;
End

exec Usp_ListOfMedicine