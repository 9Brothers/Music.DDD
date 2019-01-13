use Music;
go
create procedure ArtistUpdate
@ArtistId varchar(max),
@ArtistName varchar(max)
as
	if @ArtistId is not null and @ArtistName is not null begin
		
		update Artists set Name = @ArtistName where IdArtist = @ArtistId

		return scope_identity()
	end

	return 0
go