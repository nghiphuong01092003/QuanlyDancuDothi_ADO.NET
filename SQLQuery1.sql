--drop table Thue
--drop table Tamvang
--drop table Tamtru
--drop table Lyhon
--drop table QuanHe
--drop table HoKhau
--drop table GiayChungTu
--drop table DangNhap
--drop table Cnkh
--drop table DanhGia
--drop table CongDan
--drop table KhaiSinh
--Go

create table KhaiSinh
(
	ID integer identity(1,1) not null constraint Mks_ID unique,
	MaKS as right('KS0' + cast(ID as varchar(10)),10) persisted constraint PK_Mks primary key clustered,
	HoTenKS nvarchar(255),
	GioiTinh nvarchar(20),
	NgaySinh date,
	NoiSinh nvarchar(100),
	DanToc nvarchar(20),
	QuocTich nvarchar(20),
	QueQuan nvarchar(100),
	Cha nvarchar(20),
	Me nvarchar(20),
	NguoiKhaiSinh nvarchar(20),
	QuanHe nvarchar(100),
	NgayDk date,
	NoiDk nvarchar(100),
	TrangThai int
)
insert into KhaiSinh(HoTenKS, GioiTinh, NgaySinh, NoiSinh, DanToc, QuocTich, QueQuan, Cha, Me, NguoiKhaiSinh,QuanHe, NgayDk, NoiDk, TrangThai)
values (N'Phạm Văn T',N'Nam', '1978-05-10', N'TP. Hồ Chí Minh', N'Kinh', N'Việt Nam', N'TP. Hồ Chí Minh', '083078008462', '083078008463', '083078008462', N'Cha', '1978-06-01', N'TP. Hồ Chí Minh', 1)
	,(N'Đinh Thị Kim H',N'Nữ', '1979-07-03', N'TP. Hồ Chí Minh', N'Kinh', N'Việt Nam', N'TP. Hồ Chí Minh', '083078002562', '083078005163', '083078008462', N'Mẹ', '1979-08-05', N'TP. Hồ Chí Minh', 1)
	,(N'Phạm Thị Phương N',N'Nữ', '2003-09-01', N'TP. Hồ Chí Minh', N'Kinh', N'Việt Nam', N'TP. Hồ Chí Minh', '083303008061', '083303008072', '083303008061', N'Cha', '2003-09-10', N'TP. Hồ Chí Minh', 1)
	,(N'Phạm Nhat T', N'Nam', '2008-01-21', N'TP. Hồ Chí Minh', N'Kinh', N'Việt Nam', N'TP. Hồ Chí Minh', '083303008071', '083303048071', '083303008071', N'Cha', '2008-01-30', N'TP. Hồ Chí Minh', 1)
	,(N'Lê Hoàng L', N'Nam', '1965-12-10', N'TP HCM', N'Kinh', N'Việt Nam', N'Bình Dương', '092174003985', '092174003984', '092174003985', N'Cha', '1695-12-21', N'Bình Dương', 1)
	,(N'Hoàng Thị Thùy D', N'Nữ', '1968-01-24', N'Đồng Nai', N'Kinh', N'Việt Nam', N'Đồng Nai', '091301724456', '091301721156', '091301724456', N'Cha', '1968-02-20', N'Đồng Nai', 1)
	,(N'Lê Minh D', N'Nam', '2000-11-22', N'Bình Dương', N'Kinh', N'Việt Nam', N'Bình Dương', '09217400315', '09217400415', '09217400315', N'Cha', '2000-11-29', N'Bình Dương', 1)
create table CongDan
(
	CCCD nvarchar(20) primary key,
	HoTen nvarchar(255),
	NcCccd nvarchar(50),
	NgcCccd date, 
	MaKS varchar(10) references KhaiSinh(MaKS),
	SDT nvarchar(20),
	Email nvarchar(50),
	TrangThai int
)

insert into CongDan(CCCD, HoTen, NcCccd, NgcCccd, MaKS, SDT, Email, TrangThai)
values ('083303008061',N'Phạm Văn T', N'TP. Hồ Chí Minh', '2021-12-21', 'KS01', '0814096656', 'phamvant@gmail.com', 1)
	 ,('083303008072',N'Đinh Thị Kim H', N'TP. Hồ Chí Minh', '2021-12-20', 'KS02', '0814096245', 'dinhthikimh@gmail.com', 1)
	 ,('083303008211',N'Phạm Thị Phương N', N'TP. Hồ Chí Minh', '2021-12-21', 'KS03', '0987455412', 'phamthiphuongn@gmail.com', 1)
	 ,('083303008161',N'Phạm Nhat T', N'TP. Hồ Chí Minh', '2022-12-27', 'KS04', '0358046675', 'phamnhatt@gmail.com', 1)
	 ,('083303002561',N'Lê Hoàng L', N'Bình Dương', '2021-10-12', 'KS05', '0912124748', 'lehoangl@gmail.com', 1)
	 ,('083303003061',N'Hoàng Thị Thùy D', N'Đồng Nai', '2021-10-10', 'KS06', '0345696784', 'hoangthithuyd@gmail.com', 0)
	 ,('083303008761',N'Lê Minh D', N'Bình Dương', '2023-01-20', 'KS07', '0754141469', 'leminhd@gmail.com', 1)
create table Tamtru
(
	ID integer identity(1,1) not null constraint Mtt_ID unique,
	MaTT as right('TT0' + cast(ID as varchar(10)),10) persisted constraint PK_Mtt primary key clustered,
	Cccd nvarchar(20) references CongDan(CCCD),
	Ngaydk date,
	Noidk nvarchar(100),
	Ngayden date,
	Ngaydi date,
	Lydo nvarchar(255),
	TrangThai int
)
insert into Tamtru (CCCD, Ngaydk, Noidk, Ngayden, Ngaydi, Lydo, TrangThai)
values ('083303008211', '2023-01-02', N'TP HCM', '2023-01-01','2025-01-01', N'Làm công ty', 1)
,('083303008761', '2021-02-20', N'TP HCM', '2021-02-10','2023-02-10',	N'Điều trị bệnh', 1)
,('083303008761', '2023-03-01', N'TP HCM', '2023-02-10','2024-02-10',	N'Điều trị bệnh', 1)

create table Tamvang
(
	ID integer identity(1,1) not null constraint Mtv_ID unique,
	MaTV as right('TV0' + cast(ID as varchar(10)),10) persisted constraint PK_Mtv primary key clustered,
	CCCD nvarchar(20) references CongDan(CCCD),
	Ngaydk date,
	Ncdi nvarchar(50),
	Ncden nvarchar(50),
	Ngaydi	date,
	Ngayve	date,
	Lydo nvarchar(100),
	TrangThai int
)

insert into Tamvang (CCCD, Ngaydk, Ncdi, Ncden, Ngaydi, Ngayve, Lydo, TrangThai)
values ('083303008211', '2022-12-30', N'TP. Hồ Chí Minh', N'TP HCM', '2023-01-01','2025-01-01', N'Làm công ty', 1)
	,('083303008761', '2021-02-01',N'Bình Dương', N'TP HCM', '2021-02-10','2023-02-10',	N'Điều trị bệnh', 1)
	,('083303008761', '2023-02-25',N'Bình Dương', N'TP HCM', '2023-02-10','2024-02-10',	N'Điều trị bệnh', 1)
create table Thue
(
	ID integer identity(1,1) not null constraint Mst_ID unique,
	Masothue as right('TH0' + cast(ID as varchar(10)),10) persisted constraint PK_Mst primary key clustered,
	Coquanthue nchar(100),
	SoCMT_CCCD nvarchar(20)references CongDan(Cccd),
	Ngaythaydoithongtingannhat datetime,
	TrangThai int
)
insert into Thue (Coquanthue, SoCMT_CCCD, Ngaythaydoithongtingannhat, TrangThai)
values (N'Cục thuế tỉnh TP. Hồ Chí Minh', '083303008061', '2022-01-20', 1)
	, (N'Cục thuế tỉnh TP. Hồ Chí Minh', '083303008072', '2022-05-12', 1)
	, (N'Cục thuế tỉnh Bình Dương', '083303002561', '2021-07-14', 1)
	, (N'Cục thuế tỉnh Đồng Nai', '083303008061', '2021-12-22', 1)
create table Cnkh
(
	ID integer identity(1,1) not null constraint Mcnkh_ID unique,
	MaCnkh as right('KH0' + cast(ID as varchar(10)),10) persisted constraint PK_Mcnkh primary key clustered,
	CccdVo nvarchar(20)references CongDan(Cccd),
	CccdChong nvarchar(20)references CongDan(Cccd),
	Noidk nvarchar(100),
	Ngaydk date,
	TrangThai int
);
insert into Cnkh (CccdVo, CccdChong, Noidk, Ngaydk, TrangThai)
values ('083303008072', '083303008061', N'Ủy ban nhân dân xã TTB', '2002-10-11', 1)
	, ('083303003061', '083303002561', N'Ủy ban nhân dân tỉnh Bình Dương', '1993-04-12', 0)
create table Lyhon
(
	ID integer identity(1,1) not null constraint Mlh_ID unique,
	MaLh as right('LH0' + cast(ID as varchar(10)),10) persisted constraint PK_Mlh primary key clustered,
	MaCnkh varchar(10) references Cnkh(MaCnkh),
	CccdNguoiNopDon nvarchar(20) references CongDan(CCCD),
	Noidk nvarchar(100),
	Ngaydk date,
	Lydo nvarchar(255),
	TrangThai int
)

insert into Lyhon (MaCnkh, CccdNguoiNopDon, Noidk, Ngaydk, Lydo, TrangThai)
values ('KH02', '083303003061', N'Ủy ban nhân dân xã TTB', '2017-03-23', N'Không hòa hợp', 1)
create table HoKhau
(
	ID integer identity(1,1) not null constraint Mhk_ID unique,
	MaHK as right('HK0' + cast(ID as varchar(10)),10) persisted constraint PK_Mhk primary key clustered,
	DiaChi nvarchar(255),
	KhaiSinhChuHo varchar(10) references KhaiSinh(MaKS),
	TrangThai int
)
insert into HoKhau (DiaChi, KhaiSinhChuHo, TrangThai)
values (N'123 đường Lê Văn Duyệt, Phường 5, thành phố TP. Hồ Chí Minh, tỉnh TP. Hồ Chí Minh, Việt Nam', 'KS01', 1),
		(N'67, đường Lý Thái Tổ, phường Trần Phú, thành phố Nha Trang, tỉnh Khánh Hòa, Việt Nam', 'KS05', 1)

create table QuanHe
(
	MaHK varchar(10) references HoKhau(MaHK),
	KhaiSinhNguoiThamGia varchar(10) references KhaiSinh(MaKS),
	QuanHeVoiChuHo nvarchar(50),
	TrangThai int,
	Primary Key (MaHK, KhaiSinhNguoiThamGia)
)
insert into QuanHe (MaHK, KhaiSinhNguoiThamGia, QuanHeVoiChuHo, TrangThai)
values ('HK01', 'KS01', N'Chủ hộ', 1),
		('HK01', 'KS02', N'Vợ', 1),
		('HK01', 'KS03', N'Con gái', 1),
		('HK01', 'KS04', N'Con trai', 1),
		('HK02', 'KS05', N'Chủ hộ', 1),
		('HK02', 'KS06', N'Vợ', 0),
		('HK02', 'KS07', N'Con trai', 1)
create table DangNhap
(
	Quyen char(20),
	TenDangNhap nvarchar(20) primary key,
	MatKhau char(20),
	TrangThai int
)
insert into DangNhap (Quyen, TenDangNhap, MatKhau, TrangThai)
values ('admin', 'admin12345', '12345',1)
	 ,('user', '083303008061','phamt123',1)
	 ,('user','083303008072', 'kimh123',1)
	 ,('user','083303008211', 'phuongn123',1)
	 ,('user','083303008161', 'nhatt123', 1)
	 ,('user','083303002561', 'hoangl123', 1)
	 ,('user','083303003061','thuyd123', 0)	
	 ,('user','083303008761', 'minhd123', 1)
create table GiayChungTu
(
	ID integer identity(1,1) not null constraint Mct_ID unique,
	MaCT as right('CT0' + cast(ID as varchar(10)),10) persisted constraint PK_MCT primary key clustered,
	CCCD nvarchar(20) references CongDan(CCCD),
	NgayMat date,
	NoiMat nvarchar(100),
	NguyenNhan nvarchar(100),
	TrangThai int
)

insert into GiayChungTu(CCCD, NgayMat, NoiMat, NguyenNhan, TrangThai)
values ('083303003061', '2023-04-01', N'TP HCM', N'Benh tim', 1)

create table DanhGia 
(	
	CCCD nvarchar(20) references CongDan(CCCD),
	DanhGia nvarchar(200),
	Tongquan int,
	Thuantien int,
	Dedang int,
	Chinhxac int,
	Trucquan int
)

insert into DanhGia values ('083303008072', N'OK', '4', '3', '5', '3', '2')
