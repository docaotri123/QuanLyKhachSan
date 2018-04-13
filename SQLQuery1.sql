create PROC ThongKeDTNgay @ngay DATE
AS
	DECLARE @kq MONEY
	SET @kq=0
	BEGIN
		SET @kq=(SELECT SUM(HD.TongTien) FROM dbo.HOADON HD WHERE HD.NgayThanhToan=@ngay)
	END
    RETURN @kq
GO
DECLARE @kq MONEY
 EXEC @kq= dbo.ThongKeDTNgay @ngay = '2003-10-17' -- date
 PRINT @kq

----PROC Them Khách Hàng

CREATE PROC ThemKhachHang 
@maKH VARCHAR(10),
@hoTen NVARCHAR(30),
@tenDangNhap VARCHAR(30),
@matKhau varchar(30),
@soCMND VARCHAR(20),
@diaChi NVARCHAR(50),
@soDienThoai VARCHAR(20),
@moTa NVARCHAR(200),
@email VARCHAR(50)
 AS
	--Check xem mot KhachHang ton tai hay chua
	DECLARE @ck VARCHAR(10)
	SET @ck='x'
	SET @ck=(SELECT KH.MaKH FROM dbo.KHACHHANG KH WHERE KH.MaKH=@maKH)
	IF(@ck=@maKH)
		RETURN -1
	ELSE
		BEGIN
			INSERT INTO dbo.KHACHHANG
			(
			    MaKH,
			    HoTen,
			    TenDangNhap,
			    MatKhau,
			    SoCMND,
			    DiaChi,
			    SoDienThoai,
			    MoTa,
			    Email
			)
			VALUES
			(
				@maKH,
				@hoTen,
				@tenDangNhap,
				@matKhau,
				@soCMND,
				@diaChi,
				@soDienThoai,
				@moTa,
				@email
			)
			RETURN 1
		END
 GO
 DECLARE @test INT
 EXEC @test=ThemKhachHang 'aBc56ok','?? Trí','docaotri','123456','291155458','Tay Ninh','19001560',N'Vui tính','dctri211997@gmail.com'
 IF (@test=-1)
	PRINT 'THem That Bai'
ELSE
	PRINT 'Them Thanh Cong'
--PROC TimKiemGiaVaThanhPho
CREATE PROC TimKiemGiaVaThanhPho @gia money,@thanhPho NVARCHAR(30)
AS
	SELECT * FROM dbo.KHACHSAN KS WHERE (KS.GiaTB>=@gia-30 AND KS.GiaTB<=@gia+30) AND KS.ThanhPho LIKE (@thanhPho)
GO
EXEC TimKiemGiaVaThanhPho 100,N'Tây Ninh'

--PROC TimKiemSaoVaThanhPho
CREATE PROC TimKiemSaoVaThanhPho @sao int,@thanhPho NVARCHAR(30)
AS
	SELECT * FROM dbo.KHACHSAN KS WHERE (KS.SoSao=@sao) AND KS.ThanhPho LIKE (@thanhPho)
GO

EXEC TimKiemSaoVaThanhPho 3,N'Tây Ninh'

--PROC Signin
ALTER PROC Signin @userName VARCHAR(30),@passWord VARCHAR(30)
AS
	DECLARE @user_Name NVARCHAR(30),@pass_Word NVARCHAR(30)
	IF EXISTS (SELECT 1 FROM dbo.KHACHHANG WHERE TenDangNhap=@userName AND MatKhau=@password)
		RETURN 1;
	RETURN -1;
GO
DECLARE @ck INT
EXEC @ck=Signin 'TriDo113','123456'
PRINT @ck

--test 
SELECT *FROM dbo.HOADON WHERE YEAR(NgayThanhToan) >2000
SELECT *FROM dbo.KHACHHANG WHERE SoCMND='29115562'


exec [dbo].[Signin] @userName=N'TriDo113',@passWord=N'123456'