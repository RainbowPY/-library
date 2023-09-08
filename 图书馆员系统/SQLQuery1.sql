alter proc selec_sid_role 
@sid varchar(50)
as
	declare @roleid int;
    select @roleid = roleid from userole where sid = @sid;
	select u.sid,r.rolename from userole u,role r where u.roleid=r.roleid and sid=@sid and r.roleid=@roleid;
go

exec selec_sid_role 'zhangsan'


select * from book where id  like'%1%' or bookname like '%∑…÷Ì%';
SELECT * FROM book 