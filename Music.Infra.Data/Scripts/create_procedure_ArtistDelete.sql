use Music;
go
create procedure ArtistRemove
@ArtistId varchar(max)
as
	if @ArtistId is not null begin
		
		delete from Artists where IdArtist = @ArtistId
	end
go