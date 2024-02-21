CREATE TRIGGER updatestok 
   ON  detail_penjualan
   FOR INSERT
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