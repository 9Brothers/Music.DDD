use Music;
go
create procedure StyleUpdate
@StyleId int,
@StyleName varchar(max)
as
	if @StyleId is not null and @StyleName is not null begin

		update Styles set Name = @StyleName where IdStyle = @StyleId

	end
go