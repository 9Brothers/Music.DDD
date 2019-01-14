use Music;
go
create procedure StyleRemove
@StyleId int
as
	if @StyleId is not null begin
		delete from Styles where IdStyle = @StyleId
	end
go