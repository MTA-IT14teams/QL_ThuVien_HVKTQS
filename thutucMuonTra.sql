-- lấy dữ liệu của phiếu mượn trả có mã độc giả
alter proc get_PMTcuaDG(@maDG char(10))
as
begin
	select soPMT as [Số PMT], ngayLap as [Ngày lập],ngayHTra as [Ngày hẹn trả], ngayTra as [Ngày trả], maDG as [Mã độc giả], maTT as [Mã thủ thư]
	from PhieuMuonTra
	where maDG=@maDG
end
go

-- lấy dữ liệu của độc giả có mã
alter proc get_DGcoMa(@maDG char(10))
as
begin
	select maDG as [Mã ĐG], tenDG as [Tên ĐG], gioiTinh as [Giới tính], ngaySinh as [Ngày sinh], diaChi as [Địa chỉ], SDT as [SĐT], loaiDG as [Loại ĐG]
	from DocGia
	where maDG=@maDG
end
go

--lấy dữ liệu chi tiêt mượn của phiếu mượn trả
create proc get_CTMcuaPM(@soPMT char(10))
as
begin
	select ChiTietMuon.maCS as [Mã cuốn sách],  tenTS as [Tên Sách], tienCoc as [Tiền cọc], tienTToan as [Tiền thanh toán]
	from CuonSach	join ChiTietMuon
				on CuonSach.maCS=ChiTietMuon.maCS
					join TuaSach
				on CuonSach.maTS=TuaSach.maTS
	where soPMT=@soPMT
end
go

EXEC get_CTMcuaPM'0000000001'

-- thủ tục thêm phiếu mượn
create proc them_PMT
	(@sopmt char(10),
	@ngaylappmt date,
	@ngayhtra date,
	@ngaytra date,
	@madg char(10),
	@matt char(10))
as
begin
	insert into PhieuMuonTra 
	values(@soPMT,@ngaylappmt,@ngayhtra,@ngaytra,@madg,@matt)
end
go
