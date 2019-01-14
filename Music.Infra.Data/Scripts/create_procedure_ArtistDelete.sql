use Music;
go
alter procedure ArtistRemove
@ArtistId int
as
	if @ArtistId is not null begin
		
		delete from Artists where IdArtist = @ArtistId
	end
go