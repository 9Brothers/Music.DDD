use Music;
go
create procedure ArtistList
@ArtistId int,
@ArtistName varchar(max)
as
	if @ArtistId is not null begin
		select * from Artists where IdArtist = @ArtistId
		return
	end


	if @ArtistName is not null begin
		select * from Artists where Name = @ArtistName
		return
	end

	select * from Artists
go