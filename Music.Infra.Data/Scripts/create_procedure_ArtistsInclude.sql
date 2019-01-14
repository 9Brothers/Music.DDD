use Music;
go
alter procedure ArtistInclude
@ArtistName varchar(max)
as
	if exists (select 1 from Artists where Name = @ArtistName) begin
		select 'Já existe um artista com esse nome: "'+ @ArtistName +'"' as 'Erro'
		return 0
	end

	begin tran
	insert into Artists (Name) values (@ArtistName)	
	commit tran

	return scope_identity()
go