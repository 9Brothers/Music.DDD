use Music;
go

create procedure StyleInclude
@Name varchar(max)
as
	if @Name is null begin
		select 'Por favor, informe um nome para o estilo musical' as 'Erro'
		return 0
	end

	if exists(select 1 from Styles (nolock) where Name = @Name) begin
		select 'Já foi incluído um estilo musical com esse nome: "'+ @Name +'" ' as 'Erro'
		return 0
	end
	
	begin tran
	insert into Styles (Name) values (@Name)
	commit tran

	return scope_identity()
go