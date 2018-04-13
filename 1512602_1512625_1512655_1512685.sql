
create table KHACHHANG
(
	MaKH varchar(10) primary key,
	HoTen nvarchar(30),
	TenDangNhap varchar(30),
	MatKhau varchar(30),
	SoCMND varchar(20),
	DiaChi nvarchar(50),
	SoDienThoai varchar(20),
	MoTa nvarchar(200),
	Email varchar(50)
)

create index ID_DangNhap ON KHACHHANG(TenDangNhap,MatKhau);
create index ID_SoCMND ON KHACHHANG(SoCMND);

create table KHACHSAN
(
	MaKS varchar(10) primary key,
	TenKS nvarchar(30),
	SoSao int,
	SoNha int,
	Duong nvarchar(30),
	Quan nvarchar(30),
	ThanhPho nvarchar (30),
	GiaTB money,
	MoTa nvarchar (200)
)

create index ID_SoSao_ThanhPho ON KHACHSAN (SoSao,ThanhPho);
create index ID_GiaTB_ThanhPho ON KHACHSAN(GiaTB,ThanhPho);
create index ID_ThanhPho ON KHACHSAN(ThanhPho);

create table LOAIPHONG
(
	MaLoaiPhong varchar(10) ,
	TenLoaiPhong nvarchar(30),
	MaKS varchar(10),
	DonGia money,
	MoTa nvarchar(300),
	SlotTrong int,
	primary key(MaLoaiPhong),
	FOREIGN KEY (MaKS) REFERENCES KHACHSAN(MaKS)
)

create index ID_MaKS ON LOAIPHONG(MaKS);
create index ID_MaKS_DonGia ON LOAIPHONG(MaKS,DonGia);

create table PHONG 
(
	MaPhong varchar(10) primary key,
	LoaiPhong varchar(10),
	SoPhong int,
	FOREIGN KEY (LoaiPhong) REFERENCES LOAIPHONG(MaLoaiPhong)
)

create index ID_LoaiPhong ON PHONG(LoaiPhong);

create table TRANGTHAIPHONG
(
	MaPhong varchar(10) ,
	Ngay date,
	TinhTrang NVARCHAR(20),
	PRIMARY KEY(MaPhong,Ngay),
	FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
)

create index ID_MaPhong ON TRANGTHAIPHONG(MaPhong);

create table DATPHONG
(
	MaDP varchar(10) primary key,
	MaPhong varchar(10),
	MaKH varchar(10),
	NgayBatDau date,
	NgayTraPhong date,
	NgayDat date,
	DonGia money,
	MoTa nvarchar(100),
	TinhTrang NVARCHAR(20),
	FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong),
	FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
)

create index ID_MaPhong ON dbo.PHONG(MaPhong);
create index ID_MaKH ON DATPHONG(MaKH);

create table HOADON
(
	MaHD varchar(10) primary key,
	NgayThanhToan date,
	TongTien money,
	MaDP varchar(10),
	FOREIGN KEY (MaDP) REFERENCES DATPHONG(MaDP)
)

create index ID_MaDP ON HOADON(MaDP);
create index ID_NgayThanhToan_TongTien ON HOADON(NgayThanhToan,TongTien);