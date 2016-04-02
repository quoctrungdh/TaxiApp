USE [QLy_Taxi(Old)]
GO
/****** Object:  StoredProcedure [dbo].[LayDanhSachXe]    Script Date: 04/02/2016 12:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[LayDanhSachXe]
AS
BEGIN
	SELECT BienSoXe,MaTaiXe,LoaiXe.*
	FROM [QLy_Taxi(Old)].[dbo].[XeSoHuu] JOIN [QLy_Taxi(Old)].[dbo].[LoaiXe]
	ON (XeSoHuu.MaLoaiXe = LoaiXe.MaLoaiXe)
END