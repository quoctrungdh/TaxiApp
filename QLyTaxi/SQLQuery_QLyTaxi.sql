USE [QLy_Taxi(Old)]
GO

---Lấy Danh Sách Tất Cả Tài Xế---
CREATE PROC LayDanhSachTatCaTaiXe
AS
BEGIN
	SELECT *
	FROM dbo.TaiXe
END
GO

---Lấy Danh sách tài xế theo mã TX---
CREATE PROC LayDanhSachTaiXeTheoMa(
	@MaTX nchar(5)
)
AS
BEGIN
	SELECT * 
	FROM dbo.TaiXe
	WHERE MaTaiXe=@MaTX
END

GO

---Lấy Danh sách tài xế theo tên TX---
CREATE PROC LayDanhSachTaiXeTheoTen(
	@tenTX nvarchar(50)
)
AS
BEGIN
	SELECT * 
	FROM dbo.TaiXe
	WHERE TenTX=@tenTX
END

GO

---Tìm kiếm Tài Xế theo Fullname---
CREATE PROC TimKiemTX_Fullname(
	@fullname nvarchar(50)
)
AS
BEGIN
	SELECT * 
	FROM dbo.TaiXe
	WHERE HoTX + ' '+ TenTX = @fullname
END
GO

EXEC TimKiemTX_Fullname N'Trần Thanh Quang Vinh'

DROP PROC TimKiemTX_Fullname
GO

---Kiem Tra Fullname Ten Tai Xe Co Ton Tai---
CREATE PROC KiemTraFullnameTX(
	@fullname nvarchar(50),
	@KQ int OUTPUT
)
AS
BEGIN
	IF @fullname IN (SELECT HoTX + ' '+ TenTX FROM TaiXe)
		SET @KQ = 1
	ELSE
		SET @KQ = 0
END

DROP PROC KiemTraFullnameTX
GO 

---Kiểm Tra mã tài xế có tồn tại---
CREATE PROC KiemTraMaTX(
	@MaTX nchar(5),
	@KQ int OUTPUT
)
AS
BEGIN
	if (@MaTX IN (SELECT MaTaiXe FROM dbo.TaiXe))
		SET @KQ = 1
	else
		SET @KQ = 0
END

drop proc KiemTraMaTX 
GO

---Kiểm tra Tên TX có tồn tại ---
CREATE PROC KiemTraTenTX(
	@TenTX nvarchar(50),
	@KQ int OUTPUT
)
AS
BEGIN
	if @TenTX IN (SELECT TenTX FROM dbo.TaiXe)
		SET @KQ = 1
	else
		SET @KQ = 0
END

GO 
DROP PROC KiemTraTenTX
GO

---Thêm Tài Xế---
CREATE PROC ThemTX(
	@MaTX nchar(5),
	@HoTX nvarchar(30),
	@TenTX nvarchar(50),
	@CMND nchar(10),
	@NgaySinh NVARCHAR(50),
	@DienThoai nchar(10)
)
AS
BEGIN
	DECLARE @dtime datetime
	SET @dtime=CONVERT(datetime,@NgaySinh,103)
	INSERT INTO dbo.TaiXe(MaTaiXe,HoTX,TenTX,CMND,NgaySinh,DienThoai)
	VALUES(@MaTX,@HoTX,@TenTX,@CMND,@dtime,@DienThoai)
END

GO
EXEC ThemTX N'TX007',N'Nguyễn Quang',N'Dương',N'0123456789',N'12-05-2010',N'0900000007'
DROP PROC ThemTX
GO

---Kiểm tra ràng buộc giữa tài xế và xe (khi xóa tài xế)---
CREATE PROC TX_Co_Xe(
	@MaTX nchar(5),
	@KQ int OUTPUT
)
AS
BEGIN
	IF @MaTX IN (SELECT MaTaiXe FROM dbo.XeSoHuu)
		SET @KQ = 1
	ELSE
		SET @KQ = 0
END

GO
DROP PROC TX_Co_Xe
GO

---Xóa Tài xế---
CREATE PROC Xoa_TX(
	@MaTX nchar(5)
)
AS
BEGIN
	DELETE FROM dbo.TaiXe WHERE MaTaiXe=@MaTX
END
GO
DROP PROC Xoa_TX
GO

---Sửa Tài Xế---
CREATE PROC Sua_TX(
	@MaTX nchar(5),
	@HoTX nvarchar(30),
	@TenTX nvarchar(50),
	@CMND nchar(10),
	@NgaySinh NVARCHAR(50),
	@DienThoai nchar(10)
)
AS
BEGIN
	DECLARE @dtime datetime
	SET @dtime=CONVERT(datetime,@NgaySinh,103)
	UPDATE dbo.TaiXe
	SET HoTX=@HoTX,
		TenTX=@TenTX,
		CMND=@CMND,
		NgaySinh=@dtime,
		DienThoai=@DienThoai
	WHERE MaTaiXe=@MaTX 
END
GO

Exec Sua_TX N'TX005',N'Nguyễn Quang',N'Dương',N'0123456789',N'15-7-2015',N'0900000007'

DROP PROC Sua_TX
GO

---Danh sách các xe của một tài xế---
CREATE PROC LayDanhSachXeCuaTX(
	@MaTX nchar(5)
)
AS
BEGIN
	SELECT XeSoHuu.*, HangXe,Model,DangCapXe
	FROM XeSoHuu,LoaiXe
	WHERE MaTaiXe=@MaTX AND XeSoHuu.MaLoaiXe=LoaiXe.MaLoaiXe
END

EXEC LayDanhSachXeCuaTX N'TX001'

DROP PROC LayDanhSachXeCuaTX
GO

---Lấy danh sách các chuyến xe của TX---
CREATE PROC LayDanhSachChuyenXeTX(
	@MaTX nchar(5)
)
AS
BEGIN
	SELECT MaTaiXe,NgayGio,MaLoaiXe,DiaDiem_XuatPhat,DiaDiem_Den,[QuangDuong(km)],ThanhTien
	FROM ChuyenDi
	WHERE MaTaiXe=@MaTX
END

EXEC LayDanhSachChuyenXeTX N'TX004'

DROP PROC LayDanhSachChuyenXeTX
GO
