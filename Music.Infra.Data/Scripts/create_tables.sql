if not exists (select 1 from sysobjects where name = 'Styles' and xtype = 'U') begin
	create table Style (
		IdStyle int identity(1,1) primary key,
		Name varchar(max)
	)
end

if not exists(select 1 from sysobjects where name = 'Artists' and xtype = 'U') begin
	create table Artists (
		IdArtist int identity(1,1) primary key,
		Name varchar(max)
	)
end

if not exists(select 1 from sysobjects where name = 'Songs' and xtype = 'U') begin
	create table Songs (
		IdSong int identity(1,1) primary key,
		Name varchar(max),
		IdStyle int foreign key references Styles(IdStyle),
		IdArtist int foreign key references Artists(IdArtist)
	)
end

