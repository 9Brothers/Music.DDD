use Music;
go
create procedure SongsRemove
@SongId int
as
	if @SongId is not null begin
		delete from Songs where IdSong = @SongId
	end
go