-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
CREATE TRIGGER updatestok
   ON detail_penjualan
   AFTER INSERT
AS 

	DECLARE @id_detail AS int;
	DECLARE @id_produk AS int;
	DECLARE @stok AS int;
	DECLARE @jumlah_produk AS int;
	DECLARE @subtotal AS real;

	SELECT @jumlah_produk = i.jumlah_produk FROM inserted i;
	SELECT @id_produk = i.id_produk FROM inserted i;
	SELECT @stok = produk.stok FROM produk WHERE id_produk = @id_produk;
	SELECT @subtotal = @jumlah_produk - @stok;

BEGIN
    UPDATE produk SET stok = stok - @jumlah_produk WHERE id_produk = @id_produk;

END