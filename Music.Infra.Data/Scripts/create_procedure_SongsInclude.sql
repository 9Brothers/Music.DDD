use Music;
go
create procedure SongsInclude 
@Name varchar(max),
@StyleName varchar(max),
@ArtistName varchar(max)
as
	
	
	if not exists (select 1 from Styles (nolock) where Name = @StyleName) begin
		select 'Não foi encontrado um estilo musical com esse nome: "'+ @StyleName +'"' as 'Erro'
		return 0
	end
	
	if not exists (select 1 from Artists (nolock) where Name = @ArtistName) begin
		select 'Não foi encontrado um artista com esse nome: "'+ @ArtistName +'"' as 'Erro'
		return 0
	end

	declare @IdStyle int = (select IdStyle from Styles (nolock) where Name = @StyleName)
	declare @IdArtist int = (select IdArtist from Artists (nolock) where Name = @ArtistName)
	
	begin tran	
	insert into Songs (Name, IdStyle, IdArtist) values (@Name, @IdStyle, @IdArtist)
	commit tran

	return scope_identity()
go