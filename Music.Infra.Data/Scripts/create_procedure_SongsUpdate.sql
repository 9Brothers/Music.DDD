use Music;
go
create procedure SongsUpdate
@SongId int,
@SongName varchar(max),
@StyleId varchar(max),
@ArtistId varchar(max)
as
	if @SongId is null begin
		return
	end

	if @SongName is not null and @StyleId is not null and @ArtistId is not null begin
		
		update Songs set Name = @SongName, IdStyle = @StyleId, IdArtist = @ArtistId where IdSong = @SongId
	end
go