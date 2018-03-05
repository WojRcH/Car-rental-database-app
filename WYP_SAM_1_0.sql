drop database wyp_sam
GO
create database wyp_sam
GO

use wyp_sam
create table Samochody
(	ID_Samochodu int not null primary key IDENTITY (1,1),
	Marka nvarchar (40) not null,
	Model nvarchar(40) not null,
	Silnik nvarchar(20) not null,
	Pojemnosc_cm3 int,
	Numer_rejestracyjny nvarchar(20) not null,	
	Status_wypozyczenia bit,
	Cena_wypo¿yczenia int,	--[zl/dzien]
	Stan_techniczny nvarchar(40), 
	OC date,
	AC date,
	Przeglad_techniczny date,		 
)
create table Klienci
(
ID_Klienta int not null primary key identity(1,1),
Nazwisko nvarchar(40),
Imie nvarchar(40),
Tel_kontaktowy nvarchar(15),
Miejscowosc nvarchar(40),
Ulica nvarchar(40),
Kod_pocztowy nvarchar(40),
Nr_dokumentu int,
Dokumenty_wydany_przez nvarchar(40)
)
create table Rezerwacje
(
ID_Rezerwacji int not null primary key identity(1,1),
Stan_rezerwacji nvarchar(40),
Rezerwuj_od date,
Rezerwuj_do date,
ID_Klienta int not null foreign key references Klienci(ID_Klienta),
ID_Samochod int not null foreign key references Samochody(ID_Samochodu)  
)


select * from Samochody
select * from Klienci
select * from Rezerwacje

