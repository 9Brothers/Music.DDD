use Music;
go
create procedure ArtistInclude
@Name varchar(max)
as
	if exists (select 1 from Artists where Name = @Name) begin
		select 'Já existe um artista com esse nome: "'+ @Name +'"' as 'Erro'
		return 0
	end

	begin tran
	insert into Artists (Name) values (@Name)	
	commit tran

	return scope_identity()
go