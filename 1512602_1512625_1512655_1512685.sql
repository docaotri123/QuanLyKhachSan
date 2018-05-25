
create table KHACHHANG
(
	MaKH INT IDENTITY primary key,
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
	MaKS INT IDENTITY primary key,
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
	MaLoaiPhong INT IDENTITY primary key,
	TenLoaiPhong nvarchar(30),
	MaKS INT,
	DonGia money,
	MoTa nvarchar(300),
	SlotTrong int,
	FOREIGN KEY (MaKS) REFERENCES KHACHSAN(MaKS)
)

create index ID_MaKS ON LOAIPHONG(MaKS);
create index ID_MaKS_DonGia ON LOAIPHONG(MaKS,DonGia);

create table PHONG 
(
	MaPhong INT IDENTITY primary key,
	LoaiPhong INT,
	SoPhong int,
	FOREIGN KEY (LoaiPhong) REFERENCES LOAIPHONG(MaLoaiPhong)
)

create index ID_LoaiPhong ON PHONG(LoaiPhong);

create table TRANGTHAIPHONG
(
	MaPhong INT,
	Ngay date,	
	TinhTrang NVARCHAR(20),
	PRIMARY KEY(MaPhong,Ngay),
	FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
)

create index ID_MaPhong ON TRANGTHAIPHONG(MaPhong);

create table DATPHONG
(
	MaDP INT IDENTITY primary key,
	MaPhong INT,
	MaKH INT,
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
	MaHD INT IDENTITY primary key,
	NgayThanhToan date,
	TongTien money,
	MaDP INT,
	FOREIGN KEY (MaDP) REFERENCES DATPHONG(MaDP)
)

create index ID_MaDP ON HOADON(MaDP);
create index ID_NgayThanhToan_TongTien ON HOADON(NgayThanhToan,TongTien);