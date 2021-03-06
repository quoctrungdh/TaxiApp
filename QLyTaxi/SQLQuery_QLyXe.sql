USE [QLy_Taxi(Old)]
GO
/****** Object:  StoredProcedure [dbo].[LayDanhSachXe]    Script Date: 04/02/2016 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	--LayDanhSachToanBoCacXe--
CREATE PROC [dbo].[LayDanhSachXe]
AS
BEGIN
	SELECT BienSoXe,MaTaiXe,LoaiXe.*
	FROM [QLy_Taxi(Old)].[dbo].[XeSoHuu] JOIN [QLy_Taxi(Old)].[dbo].[LoaiXe]
	ON (XeSoHuu.MaLoaiXe = LoaiXe.MaLoaiXe)
END

EXEC [dbo].[LayDanhSachXe]

GO


	--LayDanhSachXeTheoMaTaiXe--
CREATE PROC LayDanhSachXeTheoMaTaiXe(
		@MaTX nchar(5)
)

AS
BEGIN
	SELECT BienSoXe, MaTaiXe, LoaiXe.*
	FROM XeSoHuu JOIN LoaiXe
	ON XeSoHuu.MaLoaiXe = LoaiXe.MaLoaiXe
	WHERE MaTaiXe = @MaTX
END

EXEC LayDanhSachXeTheoMaTaiXe N'TX001'

DROP PROC LayDanhSachXeTheoMaTaiXe

GO

--Lay danh sach xe theo bien so xe--
CREATE PROC LayDanhSachXeTheoBienSo(
		@BienSoXe nchar(10)
)
AS
BEGIN
	SELECT BienSoXe, MaTaiXe, LoaiXe.*
	FROM XeSoHuu JOIN LoaiXe
	ON XeSoHuu.MaLoaiXe = LoaiXe.MaLoaiXe
	WHERE BienSoXe = @BienSoXe
END
EXEC LayDanhSachXeTheoBienSo N'BSX01'
GO

	--Lay danh sach cac loai xe--
CREATE PROC LayDanhSachCacLoaiXe
AS
BEGIN
		SELECT MaLoaiXe
		FROM LoaiXe
END
EXEC LayDanhSachCacLoaiXe
GO

		--kiểm tra tính tồn tại của bản số xe--
CREATE PROC KiemTraBienSoXe_CoTonTai(
		@BienSoXe nchar(5),
		@KetQua int OUTPUT
)
AS
BEGIN
		if @BienSoXe IN (SELECT BienSoXe FROM dbo.XeSoHuu)
				SET @KetQua = 1
		else
				SET	@KetQua = 0
END
GO

		--them xe vao DB--
CREATE PROC ThemXe(
		@BienSoXe nchar(5),
		@MaTaiXe nchar(5),
		@MaLoaiXe nchar(5)
)
AS
BEGIN
	INSERT INTO dbo.XeSoHuu(BienSoXe,MaLoaiXe,MaTaiXe)
	VALUES(@BienSoXe,@MaLoaiXe,@MaTaiXe)
END
GO
EXEC ThemXe N'BSX09',N'TO001',N'TX001' 
DROP PROC ThemXe
GO

		--xoa khach hang--
CREATE PROC XoaXe(
		@BienSoXe nchar(5)
)
AS
BEGIN
	DELETE FROM dbo.XeSoHuu WHERE BienSoXe = @BienSoXe
END
GO

EXEC XoaXe N'BSX10'
GO

		--Sửa thông tin xe--
CREATE PROC SuaThongTinXe(
			@BienSoXe nchar(5),
			@MaLoaiXe nchar(5),
			@MaTaiXe nchar(5)
)
AS
BEGIN
	UPDATE dbo.XeSoHuu
	SET BienSoXe = @BienSoXe,
		MaLoaiXe = @MaLoaiXe,
		MaTaiXe = @MaTaiXe
	WHERE BienSoXe = @BienSoXe
END
GO

EXEC SuaThongTinXe N'BSX06',N'TO001',N'TX001' 
GO
