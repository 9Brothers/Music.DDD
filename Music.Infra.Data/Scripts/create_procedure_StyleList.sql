use Music;
go
create procedure StyleList
@StyleId int,
@StyleName varchar(max)
as
	if @StyleName is not null begin
		select * from Styles where Name = @StyleName
		return
	end

	if @StyleId is not null begin
		select * from Styles where IdStyle = @StyleId
		return
	end

	select * from Styles
go