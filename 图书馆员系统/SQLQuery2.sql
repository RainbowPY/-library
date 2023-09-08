create proc  update_book 
@id  int ,
@bookname varchar(50),
@typeid int,
@price int,
@num int,
@indate datetime,
@pricture varchar(50) = null
as  
      update  book set bookname =@bookname ,typeid = @typeid,price=@price,num=@num,pricture=@pricture
	  where id = @id;
go

select * from book
select * from userole


create proc add_books 
@id  int ,
@bookname varchar(50),
@typeid int,
@price int,
@num int,
@indate datetime,
@pricture varchar(50) = null

as  
  
	  insert into book(bookname,typeid,price,num,indate,pricture) values(@bookname,@typeid,@price,@num,@indate,@pricture)

go


alter trigger delete_book 
on book for delete
as
   declare @id  int ,@bookname varchar(50),@typeid int,
   @price int,@num int,@indate datetime,@pricture varchar(50)=null;
   select @id=id,@bookname=bookname,@typeid=typeid,@price=price,@num=num,@indate=indate,@pricture=pricture
	from deleted;
	select * from deleted
	-- set identity_insert.book on
	-- set identity_insert.backupTable on
	if(exists(select * from sysobjects where name='backupTable'))
				insert into backupTable(id,bookname,typeid,price,num,indate,pricture) values(@id,@bookname,@typeid,@price,@num,@indate,@pricture) 
			else
				select * into backupTable from deleted;
				--set identity_insert.book off
					--set identity_insert.backupTable off
go

set identity_insert.book on
set identity_insert.backupTable on
delete from book where id =10117
select * from backupTable
select * from book
go
alter trigger restore_book 
on backupTable for delete
as
    
   declare @id  int ,@bookname varchar(50),@typeid int,
   @price int,@num int,@indate datetime,@pricture varchar(50)=null;
   select @id=id,@bookname=bookname,@typeid=typeid,@price=price,@num=num,@indate=indate,@pricture=pricture
	from deleted;
	           select * from  deleted;
	            -- alter table book alter column  id int null
				-- set identity_insert book on
				insert into book(id,bookname,typeid,price,num,indate,pricture) values(@id,@bookname,@typeid,@price,@num,@indate,@pricture) 
				--set identity_insert book off
go

--set identity_insert book off
set identity_insert book on
delete from backupTable where id =10122 
go
set IDENTITY_INSERT.book off
set IDENTITY_INSERT.book on
insert into book(id,bookname,typeid,price,num,indate,pricture) values(10106,'¹þÄ·À×ÌØµÄÑÛÀá',4,35,100,'2023-8-6',null) 
go