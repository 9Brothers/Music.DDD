use Music;
go
create procedure SongsList
@SongName varchar(max),
@StyleName varchar(max),
@ArtistName varchar(max)
as
	-- 1) by song name and style name and artist name
	if (@SongName is not null and @StyleName is not null and @ArtistName is not null) begin

		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock)
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.Name = @SongName
		and Songs.IdStyle = (select IdStyle from Styles (nolock) where Name = @StyleName)
		and Songs.IdArtist = (select IdArtist from Artists (nolock) where Name = @ArtistName)

		return
	end

	-- 2) by style name and artist name
	if (@StyleName is not null and @ArtistName is not null) begin

		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock)
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.IdStyle = (select IdStyle from Styles (nolock) where Styles.Name = @StyleName)
		and Songs.IdArtist = (select IdArtist from Artists (nolock) where Artists.Name = @ArtistName)

		return
	end

	-- 3) by song name and artist name
	if (@SongName is not null and @ArtistName is not null) begin

		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock)
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.Name = @SongName
		and Songs.IdArtist = (select IdArtist from Artists (nolock) where Artists.Name = @ArtistName)

		return
	end

	-- 4) by song name and style name
	if (@SongName is not null and @StyleName is not null) begin
	
		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock)
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.Name = @SongName
		and Songs.IdStyle = (select IdStyle from Styles (nolock) where Name = @StyleName)

		return
	end

	-- 5) by artist name
	if (@ArtistName is not null) begin

		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock) 
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.IdArtist = (select IdArtist from Artists (nolock) where Name = @ArtistName)

		return
	end

	-- 6) by style name
	if (@StyleName is not null) begin

		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock) 
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.IdStyle = (select IdStyle from Styles (nolock) where Name = @StyleName)

		return
	end

	-- 7) by song name
	if (@SongName is not null) begin
		
		select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock) 
		inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
		inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
		where Songs.Name = @SongName

		return
	end

	-- 8) all
	select Songs.IdSong, Songs.Name, Songs.IdArtist, Artists.Name as 'Artist', Songs.IdStyle, Styles.Name as 'Style' from Songs (nolock) 
	inner join Styles (nolock) on Styles.IdStyle = Songs.IdStyle
	inner join Artists (nolock) on Artists.IdArtist = Songs.IdArtist
go