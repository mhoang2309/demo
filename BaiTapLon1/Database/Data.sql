create database PhongTro
on primary
(
	size = 10MB,
	filename = 'D:\baitap\BaiTapLon\Database\PhongTro_csdl.mdf',
	maxsize = 50MB,
	filegrowth = 10MB,
	name = PhongTro_csdl
)
log on
(
	size = 10MB,
	filename = 'D:\baitap\BaiTapLon\Database\PhongTro_csdl.ldf',
	maxsize = 50MB,
	filegrowth = 10MB,
	name = PhongTro_csdl_log
)

use PhongTro
go
-------------------------------------------------------------------------

create table TaiKhoan
(
	uses nvarchar(10) not null primary key,
	pass nvarchar(10) not null,
	quyen nvarchar(5) not null
)

CREATE FUNCTION AUTO_IDKH()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaKH) FROM ThongTinKH) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaKH, 3)) FROM ThongTinKH
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END


CREATE FUNCTION AUTO_IDThue()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaThue) FROM ThongTinThue) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaThue, 4)) FROM ThongTinThue
		SELECT @ID = CASE
			when @ID >= 0 and @ID < 9 THEN 'T000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'T00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'T0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END


CREATE FUNCTION AUTO_IDPhong()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MaPhong) FROM ThongTinPhong) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MaPhong, 4)) FROM ThongTinPhong
		SELECT @ID = CASE
			when @ID >= 0 and @ID < 9 THEN 'P000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'P00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'P0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
create table ThongTinKH
(
	MaKH char(5) not null primary key CONSTRAINT IDKH DEFAULT DBO.AUTO_IDKH(),
	HoTen nvarchar(50) not null,
	SDT varchar(10) not null,
	CMND varchar(10),
	NgaySinh date,
	DiaChi nvarchar(100),
	anh text
)

create table ThongTinPhong
(
	MaPhong char(5) not null primary key CONSTRAINT IDPHONG DEFAULT DBO.AUTO_IDPhong(),
	DienTich varchar(5) not null,
	GiaPhong varchar(10) not null,
	ChuThich nvarchar(200)
)

create table ThongTinThue
(
	MaThue char(5) not null primary key CONSTRAINT IDTHUE DEFAULT DBO.AUTO_IDThue(),
	MaPhong char(5) not null foreign key(MaPhong) references ThongTinPhong,
	MaKH char(5) not null foreign key(MaKH) references ThongTinKH,
	NgayThue date not null,
	NgayTra date
)
go
--------------------------------------------------------------------------------

insert into TaiKhoan(uses, pass, quyen) values
('admin','admin','admin'),
('uses','123','uses')

insert into ThongTinKH(MaKH,HoTen, SDT, CMND, NgaySinh, DiaChi, anh) values
('KH001',N'Võ Đang Khoa','0355841359','285525274','1998-04-14',N'1141/24 Tỉnh Lộ 43, Bình Chiểu, Thủ Đức, HCM','..\..\imgKH\images.jpg')
insert into ThongTinKH(HoTen, SDT, CMND, NgaySinh, DiaChi, anh) values
(N'Nguyễn Mạnh Hoàng','0355438866','285588294','1998-09-23',N'1141/24 Tỉnh Lộ 43, Bình Chiểu, Thủ Đức, HCM','..\..\imgKH\images.jpg')

insert into ThongTinPhong(MaPhong, DienTich, GiaPhong, ChuThich) values
('P0001','35','100000',null)
insert into ThongTinPhong(DienTich, GiaPhong, ChuThich) values
('35','100000',null)


insert into ThongTinThue(MaThue, MaKH, MaPhong, NgayThue, NgayTra) values
('T0001','KH002','P0001','2020-09-01',null),
('T0004','KH002','P0001','2020-09-01',null)
insert into ThongTinThue(MaKH, MaPhong, NgayThue, NgayTra) values
('KH002','P0005','2020-09-01',null)






select * from [dbo].[ThongTinKH] h,[dbo].[ThongTinPhong] p,[dbo].[ThongTinThue] t
where t.MaKH=h.MaKH and t.MaPhong=p.MaPhong

set ansi_nulls on
go
set quoted_identifier on
go
alter proc [dbo].[ThongTinKH_TimKiemTheoTen
(
@Hoten nvarchar(50)
)
as
select * from [dbo].[ThongTinKH]
where HoTen like '%'+@Hoten+'%'