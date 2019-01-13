use Music;
go
create procedure StyleList
@StyleName varchar(max)
as
	if @StyleName is not null begin
		select * from Styles where Name = @StyleName
		return
	end

	select * from Styles
go