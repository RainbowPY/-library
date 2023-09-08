
set IDENTITY_INSERT.book off
insert into book(id,bookname,typeid,price,num,indate,pricture) values(10106,'哈姆雷特的眼泪',4,35,100,'2023-8-6',null) 
go


alter trigger restore_book 
on backupTable for delete
as
    
   declare @id  int ,@bookname varchar(50),@typeid int,
   @price int,@num int,@indate datetime,@pricture varchar(50)=null;
   select @id=id,@bookname=bookname,@typeid=typeid,@price=price,@num=num,@indate=indate,@pricture=pricture
	from deleted;
	           select * from  deleted;
	         
				 set identity_insert book on
				insert into book(id,bookname,typeid,price,num,indate,pricture) values(@id,@bookname,@typeid,@price,@num,@indate,@pricture) 
				 set identity_insert book off
go


alter trigger delete_book 
on book for delete
as
   declare @id  int ,@bookname varchar(50),@typeid int,
   @price int,@num int,@indate datetime,@pricture varchar(50)=null;
   select @id=id,@bookname=bookname,@typeid=typeid,@price=price,@num=num,@indate=indate,@pricture=pricture
	from deleted;
	select * from deleted
	if(exists(select * from sysobjects where name='backupTable'))
				insert into backupTable(id,bookname,typeid,price,num,indate,pricture) values(@id,@bookname,@typeid,@price,@num,@indate,@pricture) 
			else
				select * into backupTable from deleted;
				
					set identity_insert.backupTable off
go


drop trigger restore_book 

create proc proc_del_book
 @id  int ,@bookname varchar(50),@typeid int,
   @price int,@num int,@indate datetime,@pricture varchar(50)=null
as 
		set identity_insert.book on
    insert into book(id,bookname,typeid,price,num,indate,pricture) values(@id,@bookname,@typeid,@price,@num,@indate,@pricture) 
	set identity_insert.book off
go

exec proc_del_book 10105,'安徒生童话',4,25,100,'2021-7-8',null
insert into book(id,bookname,typeid,price,num,indate,pricture) values(10105,'安徒生童话',4,25,100,'2021-7-8',null)

select * from backupTable
select * from book

delete from book where id =10117 
delete from backupTable where id =10117 