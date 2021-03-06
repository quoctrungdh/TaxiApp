USE [QLy_Taxi(Old)]
GO

---Lấy Danh Sách Tất Cả Khách Hàng---
CREATE PROC LayDanhSachTatCaKhachHang
AS
BEGIN
	SELECT *
	FROM dbo.KhachHang
END
GO

---Lấy Danh sách Khách Hàng theo mã KH---
CREATE PROC LayDanhSachKhachHangTheoMa(
	@MaKH nchar(5)
)
AS
BEGIN
	SELECT * 
	FROM dbo.KhachHang
	WHERE MaKH=@MaKH
END

GO

---Lấy Danh sách Khách hàng theo tên KH---
CREATE PROC LayDanhSachKhachHangTheoTen(
	@tenKH nvarchar(50)
)
AS
BEGIN
	SELECT * 
	FROM dbo.KhachHang
	WHERE TenKH=@tenKH
END

GO

---Tìm kiếm Khách Hàng theo Fullname---
CREATE PROC TimKiemKH_Fullname(
	@fullname nvarchar(50)
)
AS
BEGIN
	SELECT * 
	FROM dbo.KhachHang
	WHERE HoKH + ' '+ TenKH = @fullname
END
GO

EXEC TimKiemKH_Fullname N'Trần Thanh Quang Vinh'

DROP PROC TimKiemKH_Fullname
GO

---Kiem Tra Fullname Tên Khách Hàng Co Ton Tai---
CREATE PROC KiemTraFullnameKH(
	@fullname nvarchar(50),
	@KQ int OUTPUT
)
AS
BEGIN
	IF @fullname IN (SELECT HoKH + ' '+ TenKH FROM KhachHang)
		SET @KQ = 1
	ELSE
		SET @KQ = 0
END

DROP PROC KiemTraFullnameKH
GO 

---Kiểm Tra mã khách hàng có tồn tại---
CREATE PROC KiemTraMaKH(
	@MaKH nchar(5),
	@KQ int OUTPUT
)
AS
BEGIN
	if (@MaKH IN (SELECT MaKH FROM dbo.KhachHang))
		SET @KQ = 1
	else
		SET @KQ = 0
END

drop proc KiemTraMaKH 
GO

---Kiểm tra Tên KH có tồn tại ---
CREATE PROC KiemTraTenKH(
	@TenKH nvarchar(50),
	@KQ int OUTPUT
)
AS
BEGIN
	if @TenKH IN (SELECT TenKH FROM dbo.KhachHang)
		SET @KQ = 1
	else
		SET @KQ = 0
END

GO 
DROP PROC KiemTraTenKH
GO

---Thêm Khách Hàng---
CREATE PROC ThemKH(
	@MaKH nchar(5),
	@HoKH nvarchar(30),
	@TenKH nvarchar(50),
	@DienThoai nchar(10),
	@Email nchar(30)
)
AS
BEGIN
	INSERT INTO dbo.KhachHang(MaKH,HoKH,TenKH,DienThoai,Email)
	VALUES(@MaKH,@HoKH,@TenKH,@DienThoai,@Email)
END

GO
EXEC ThemKH N'TX007',N'Nguyễn Quang',N'Dương',N'0123456789',N'12-05-2010',N'0900000007'
DROP PROC ThemKH
GO

---Xóa Khách Hàng---
CREATE PROC Xoa_KH(
	@MaKH nchar(5)
)
AS
BEGIN
	DELETE FROM dbo.ChuyenDi WHERE MaKH = @MaKH
	DELETE FROM dbo.KhachHang WHERE MaKH = @MaKH
END
GO
DROP PROC Xoa_KH
GO

---Sửa Khách Hàng---
CREATE PROC Sua_KH(
	@MaKH nchar(5),
	@HoKH nvarchar(30),
	@TenKH nvarchar(50),
	@DienThoai nchar(10),
	@Email nchar(30)
)
AS
BEGIN
	UPDATE dbo.KhachHang
	SET HoKH=@HoKH,
		TenKH=@TenKH,
		DienThoai=@DienThoai,
		Email=@Email
	WHERE MaKH=@MaKH 
END
GO

Exec Sua_KH 

DROP PROC Sua_KH
GO


---Lay danh sach cac chuyen di cua Khach Hang---
CREATE PROC LayDanhSachCacChuyenDiCuaKH(
	@MaKH nchar(5)
)
AS
BEGIN
	SELECT * 
	FROM dbo.ChuyenDi
	WHERE MaKH=@MaKH
END
