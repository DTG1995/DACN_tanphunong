
CREATE TABLE [dbo].[tb_BaiViet](
	[MaBV] [int] IDENTITY(1,1) NOT NULL,
	[LoaiBaiViet] [int] NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[NguoiViet] [varchar](50) NULL,
	[NoiBo] [bit] NULL,
	[NgayViet] [datetime] NULL,
 CONSTRAINT [PK_tb_BaiViet] PRIMARY KEY CLUSTERED 
(
	[MaBV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_BaiVietTrans]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_BaiVietTrans](
	[MaBV] [int] NOT NULL,
	[TieuDeTrans] [nvarchar](250) NULL,
	[TomTatTrans] [ntext] NULL,
	[NoiDungTrans] [ntext] NULL,
	[NgonNgu] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tb_BaiVietTrans] PRIMARY KEY CLUSTERED 
(
	[MaBV] ASC,
	[NgonNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_DoiNguQL_Trans]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_DoiNguQL_Trans](
	[MaQL] [int] NOT NULL,
	[NgonNgu] [varchar](5) NOT NULL,
	[TenNguoiQL] [nvarchar](200) NULL,
	[ChucVu] [nvarchar](100) NULL,
	[MoTa] [ntext] NULL,
	[CauNoi] [ntext] NULL,
 CONSTRAINT [PK_tb_DoiNguQL_Trans] PRIMARY KEY CLUSTERED 
(
	[MaQL] ASC,
	[NgonNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_DoiNguQuanLy]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DoiNguQuanLy](
	[MaQL] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [ntext] NULL,
	[ThuBac] [int] NULL,
 CONSTRAINT [PK_tb_DoiNguQuanLy] PRIMARY KEY CLUSTERED 
(
	[MaQL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_DoiTac]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DoiTac](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[TenDT] [nvarchar](100) NULL,
	[HinhAnh] [ntext] NULL,
 CONSTRAINT [PK_tb_DoiTac] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_LoaiSP]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_LoaiSP](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[LoaiCha] [int] NULL,
	[TrangThai] [bit] NULL,
	[NguoiThem] [varchar](50) NULL,
 CONSTRAINT [PK_tb_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_LoaiSPTrans]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_LoaiSPTrans](
	[MaLoaiSP] [int] NOT NULL,
	[TenLoaiSPTrans] [nvarchar](100) NULL,
	[MoTaTrans] [nvarchar](200) NULL,
	[NgonNgu] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tb_LoaiSPTrans] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC,
	[NgonNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_NguoiDung]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_NguoiDung](
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NULL,
	[TrangThai] [bit] NULL,
	[LoaiND] [varchar](50) NULL,
	[ThoiGianDNCuoi] [datetime] NULL,
 CONSTRAINT [PK_tb_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_NhatKy]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhatKy](
	[MaNK] [int] IDENTITY(1,1) NOT NULL,
	[NguoiDung] [nvarchar](50) NULL,
	[DoiTuong] [nvarchar](50) NULL,
	[ThaoTac] [nvarchar](250) NULL,
	[MaDoiTuong] [int] NULL,
 CONSTRAINT [PK_tb_NhatKy] PRIMARY KEY CLUSTERED 
(
	[MaNK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_PhanHoi]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PhanHoi](
	[MaPH] [int] NOT NULL,
	[NoiDung] [nvarchar](100) NULL,
	[TrangThai] [int] NULL,
	[Email] [nvarchar](200) NULL,
	[SDT] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_PhanHoi] PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_SanPham]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[QuyCachDongGoi] [nchar](100) NULL,
	[XuatXu] [nchar](100) NULL,
	[GiaThanh] [money] NULL,
	[TrangThai] [bit] NULL,
	[MaLoai] [int] NOT NULL,
	[NguoiThem] [varchar](50) NULL,
 CONSTRAINT [PK_tb_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_SanPhamTrans]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_SanPhamTrans](
	[MaSP] [int] NOT NULL,
	[TenSanPhamTrans] [nchar](100) NULL,
	[UuDienTrans] [ntext] NULL,
	[DacDiemTrans] [ntext] NULL,
	[ThanhPhanChinhTrans] [ntext] NULL,
	[LuuYTrans] [ntext] NULL,
	[QuyCachDongGoiTrans] [nchar](100) NULL,
	[CachDungTrans] [ntext] NULL,
	[NgonNgu] [varchar](5) NOT NULL,
 CONSTRAINT [PK_tb_SanPhamTrans] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[NgonNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[tb_TuyChon]    Script Date: 11/10/2017 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_TuyChon](
	[MaTuyChon] [int] IDENTITY(1,1) NOT NULL,
	[TenTuyChon] [varchar](50) NULL,
	[NoiDungTuyChon] [ntext] NULL,
	[Nhom] [varchar](50) NULL,
 CONSTRAINT [PK_tb_TuyChon] PRIMARY KEY CLUSTERED 
(
	[MaTuyChon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
INSERT [dbo].[tb_DoiNguQL_Trans] ([MaQL], [NgonNgu], [TenNguoiQL], [ChucVu], [MoTa], [CauNoi]) VALUES (2, N'en', N'Dinh Tien Gioi', N'Developer', N'MoTa En', N'SaidEn')
INSERT [dbo].[tb_DoiNguQL_Trans] ([MaQL], [NgonNgu], [TenNguoiQL], [ChucVu], [MoTa], [CauNoi]) VALUES (2, N'vi', N'Đinh Tiên Giỏi', N'Lập trình viên', N'Mota VN', N'Tiền là giấy, đốt là cháy')
SET IDENTITY_INSERT [dbo].[tb_DoiNguQuanLy] ON 

INSERT [dbo].[tb_DoiNguQuanLy] ([MaQL], [HinhAnh], [ThuBac]) VALUES (2, N'test', 1)
SET IDENTITY_INSERT [dbo].[tb_DoiNguQuanLy] OFF
SET IDENTITY_INSERT [dbo].[tb_LoaiSP] ON 

INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (4, NULL, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (6, NULL, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (7, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (8, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (9, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (10, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (11, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (12, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (13, 6, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (14, 6, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (15, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (16, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (17, 6, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (18, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (19, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (20, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (21, 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (22, 6, 1, NULL)
SET IDENTITY_INSERT [dbo].[tb_LoaiSP] OFF
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (4, N'Fertilizers', N'Fertilizers', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (4, N'Phân bón', N'Phân bón', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (6, N'Pesticides', N'Pesticides', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (6, N'Thuốc trừ sâu bệnh', N'Thuốc trừ sâu bệnh', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (7, N'ACI', N'ACI', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (7, N'ACI', N'ACI', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (8, N'Mappacific Viet Nam', N'Fertilizers VietName', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (8, N'Mappacific Việt Nam', N'Phân bón Việt Nam', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (9, N'', N'', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (9, N'Long Thành', N'Phân bón Long Thành', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (10, N'DaNang Chemistry', N'Fertilizers DaNang Chemistry', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (10, N'Hóa Chất Đà Nẵng', N'Phân bón Đà Nẵng', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (11, N'Agricode', N'Fertilizers agricode', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (11, N'Agricode', N'Phân bón Agricode', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (12, N'Behn Meyer', N'Behn Meyer', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (12, N'Behn Meyer', N'Phân bón Behn Meyer', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (13, N'SUNDAT', N'Pesticides SunDAt', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (13, N'SUNDAT', N'Thuốc trừ bệnh SUNDAT', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (14, N'', N'', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (14, N'Mappacific ', N'Thuốc trừ bệnh Mappacific ', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (15, N'Hoang Lan', N'Fertilizers Hoang Lan', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (15, N'Hoàng Lan', N'Phân bón Hoàng Lan', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (16, N'Behn Meyer VN', N'Fertilizers Behn Meyer VN', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (16, N'Behn Meyer VN', N'Phân bón Behn Meyer VN', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (17, N'Cuu Long', N'Cuu Long Company ', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (17, N'Cửu Long', N'Công ty Cửu Long', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (18, N'Con Co Vang', N'Fertilizers Con Co Vang', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (18, N'Con Cò Vàng', N'Phân bón Con Cò Vàng', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (19, N'Song Gianh', N'Song Gianh Company', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (19, N'Sông Gianh', N'Công ty Sông Gianh', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (20, N'Agrilong', N'Fertilizers Agrilong', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (20, N'Agrilong', N'Phân bón Agrilong', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (21, N'TASMA', N'Fertilizers TASMA', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (21, N'TASMA', N'Phân bón TASMA', N'vi')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (22, N'BAYER', N'Pesticides BAYER', N'en')
INSERT [dbo].[tb_LoaiSPTrans] ([MaLoaiSP], [TenLoaiSPTrans], [MoTaTrans], [NgonNgu]) VALUES (22, N'BAYER', N'Thuốc trừ sâu bênh', N'vi')
INSERT [dbo].[tb_NguoiDung] ([TenDangNhap], [MatKhau], [TrangThai], [LoaiND], [ThoiGianDNCuoi]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, N'0,3', NULL)
INSERT [dbo].[tb_NguoiDung] ([TenDangNhap], [MatKhau], [TrangThai], [LoaiND], [ThoiGianDNCuoi]) VALUES (N'dtg0106', N'21232f297a57a5a743894a0e4a801fc3', 1, N'1,2', NULL)
SET IDENTITY_INSERT [dbo].[tb_NhatKy] ON 

INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (1, N'admin', N'Trang chủ', N'10/11/2017 01:08:14 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (2, N'admin', N'Trang chủ', N'10/11/2017 01:08:15 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (3, N'admin', N'Loại Sản Phẩm', N'10/11/2017 02:50:01 - Thêm loại sản phẩm ""', 1)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (4, N'admin', N'Loại Sản Phẩm', N'10/11/2017 02:57:02 - Thêm loại sản phẩm ""', 1)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (5, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:10:50 - Thêm loại sản phẩm ""', 1)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (6, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:11:50 - Thêm loại sản phẩm ""', 2)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (7, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:13:50 - Thêm loại sản phẩm ""', 3)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (8, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:14:06 - Thêm loại sản phẩm ""', 3)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (9, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:14:11 - Thêm loại sản phẩm ""', 2)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (10, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:14:37 - Thêm loại sản phẩm ""', 4)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (11, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:20:57 - Thêm loại sản phẩm ""', 5)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (12, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:21:29 - Thêm loại sản phẩm ""', 6)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (13, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:32:19 - Thêm loại sản phẩm ""', 7)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (14, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:35:06 - Thêm loại sản phẩm ""', 8)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (15, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:35:34 - Thêm loại sản phẩm ""', 9)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (16, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:36:15 - Thêm loại sản phẩm ""', 9)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (17, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:37:11 - Thêm loại sản phẩm ""', 10)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (18, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:38:01 - Thêm loại sản phẩm ""', 11)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (19, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:38:46 - Thêm loại sản phẩm ""', 12)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (20, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:40:06 - Thêm loại sản phẩm ""', 13)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (21, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:40:52 - Thêm loại sản phẩm ""', 14)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (22, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:41:09 - Thêm loại sản phẩm ""', 14)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (23, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:41:44 - Thêm loại sản phẩm ""', 15)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (24, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:42:07 - Thêm loại sản phẩm ""', 16)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (25, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:42:47 - Thêm loại sản phẩm ""', 17)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (26, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:43:51 - Thêm loại sản phẩm ""', 18)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (27, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:44:54 - Thêm loại sản phẩm ""', 19)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (28, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:46:12 - Thêm loại sản phẩm ""', 20)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (29, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:46:52 - Thêm loại sản phẩm ""', 21)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (30, N'admin', N'Loại Sản Phẩm', N'10/11/2017 03:47:23 - Thêm loại sản phẩm ""', 22)
SET IDENTITY_INSERT [dbo].[tb_NhatKy] OFF
SET IDENTITY_INSERT [dbo].[tb_TuyChon] ON 

INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (1, N'TriAnvi', N'<p>Sự y&ecirc;u mến v&agrave; niềm tin của qu&yacute; kh&aacute;ch ch&iacute;nh l&agrave; niềm tự h&agrave;o, l&agrave; th&agrave;nh c&ocirc;ng lớn nhất của ch&uacute;ng t&ocirc;i trong qu&aacute; tr&igrave;nh h&igrave;nh th&agrave;nh v&agrave; ph&aacute;t triển, nh&igrave;n lại hơn 10 năm x&acirc;y dựng v&agrave; ph&aacute;t triển vừa qua, tất cả c&aacute;c th&agrave;nh vi&ecirc;n trong ng&ocirc;i nh&agrave; chung TPN đều nhận thấy để đạt được những th&agrave;nh c&ocirc;ng ng&agrave;y h&ocirc;m nay khg chỉ đến từ nỗ lực, cố gắng của tập thể c&aacute;n bộ nh&acirc;n vi&ecirc;n TPN m&agrave; tr&ecirc;n hết l&agrave; sự t&iacute;n nhiệm của qu&yacute; kh&aacute;ch h&agrave;ng, cũng như sự tin cậy hợp t&aacute;c của qu&yacute; đối t&aacute;c.</p>

<p>Nhận định chung về t&igrave;nh h&igrave;nh n&ocirc;ng nghiệp hiện tại:<br />
T&igrave;nh h&igrave;nh thế giới:</p>

<ul>
	<li>Gia nhập c&aacute;c hiệp ước kinh tế quốc tế như:</li>
	<li>Bằng thỏa thuận Đối t&aacute;c Xuy&ecirc;n Th&aacute;i B&igrave;nh Dương (TPP).</li>
	<li>Để bớt bị phụ thuộc v&agrave;o một đối t&aacute;c thương mại duy nhất v&agrave; c&oacute; được mối quan hệ rộng r&atilde;i hơn,</li>
	<li>TPP sẽ gi&uacute;p đẩy mạnh hợp t&aacute;c khu vực, gi&uacute;p giải quyết vấn đề b&igrave;nh đẳng kinh tế</li>
	<li>Đ&oacute; l&agrave; điều m&agrave; TPP sẽ mang tới cho tất cả ch&uacute;ng ta bởi Mỹ, Việt Nam v&agrave; c&aacute;c đối t&aacute;c kh&aacute;c sẽ phải tu&acirc;n thủ nguy&ecirc;n tắc m&agrave; c&aacute;c b&ecirc;n đ&atilde; c&ugrave;ng nhau đưa ra. Đ&oacute; l&agrave; tương lai đang đợi ch&uacute;ng ta</li>
</ul>

<p>T&igrave;nh h&igrave;nh trong nước:</p>

<ul>
	<li>X&acirc;y dựng lại hệ thống ch&iacute;nh quyền cởi mở v&agrave; tu&acirc;n thủ theo hiến ph&aacute;p v&agrave; ph&aacute;p luật.</li>
	<li>Lấy kinh tế tư nh&acirc;n l&agrave;m nền tảng th&uacute;c đẩy ph&aacute;t triển kinh tế đất nước</li>
	<li>Nghi&ecirc;m trị thực phẩm bẩn, h&agrave;ng gian, h&agrave;ng giả nh&aacute;i, k&eacute;m chất lượng</li>
	<li>Ngo&agrave;i ra, TPP cũng c&oacute; những phương thức bảo vệ m&ocirc;i trường v&agrave; chống tham nhũng thương mại quyết liệt hơn.</li>
	<li>T&igrave;nh h&igrave;nh x&acirc;m nhập mặn ở c&aacute;c tỉnh đồng bằng s&ocirc;ng cửu long, hạn h&aacute;n trầm trọng ở v&ugrave;ng t&acirc;y nguy&ecirc;n</li>
</ul>

<p>Định hướng của Tỉnh L&acirc;m Đồng:</p>

<ul>
	<li>Mở rộng địa giới TP vệ tinh ph&aacute;t triển th&agrave;nh v&ugrave;ng Du Lịch Rau Hoa v&agrave; N&ocirc;ng Nghiệp C&ocirc;ng Nghệ cao,</li>
	<li>Tổ chức quy hoạch t&aacute;i canh v&agrave; x&acirc;y dựng thương hiệu c&agrave; ph&ecirc; ri&ecirc;ng cho LĐ</li>
</ul>

<p>Kế hoạch ph&aacute;t triển của Cty TPN c&ugrave;ng với qu&yacute; kh&aacute;ch h&agrave;ng trong những năm sắp tới:</p>

<ul>
	<li>Chọn lọc kỹ lưỡng những nh&oacute;m sản phẩm kh&ocirc;ng để lại độc hại cho m&ocirc;i trường.</li>
	<li>Bổ sung những d&ograve;ng sản phẩm tinh khiết v&agrave; cao cấp v&agrave;o bộ sản phẩm.</li>
	<li>Tăng cường c&aacute;c d&ograve;ng ph&acirc;n b&oacute;n hữu cơ cao cấp.</li>
	<li>Để đảm bảo xứng đ&aacute;ng với t&ecirc;n gọi T&acirc;n Ph&uacute; N&ocirc;ng : với mục ti&ecirc;u li&ecirc;n tục đổi mới, x&oacute;a bỏ nền n&ocirc;ng nghiệp lạc hậu, l&atilde;ng ph&iacute;, li&ecirc;n tục cập nhật c&ocirc;ng nghệ sản xuất n&ocirc;ng nghiệp cao, từng bước s&aacute;t c&aacute;nh c&ugrave;ng b&agrave; con n&ocirc;ng d&acirc;n li&ecirc;n tục thay đổi v&agrave; ph&aacute;t triển nhịp nh&agrave;ng với sự ph&aacute;t triển kh&ocirc;ng ngừng tr&ecirc;n to&agrave;n cầu.</li>
</ul>

<p>Đ&acirc;y chỉ l&agrave; bước khởi đầu khẳng định t&iacute;nh đ&uacute;ng đắn v&agrave; hiệu quả trong định hướng ph&aacute;t triển của một Doanh nghiệp tiến tới sự chuy&ecirc;n nghiệp của một nh&agrave; Ph&acirc;n Phối, từ đ&acirc;y mở ra nhiều cơ hội để C&ocirc;ng ty TNHH SX-DV- TM T&acirc;n ph&uacute; N&ocirc;ng tiếp tục tiến xa với những mục ti&ecirc;u lớn hơn nữa.<br />
Ch&uacute;ng ta học được b&agrave;i học từ thiền sư Th&iacute;ch Nhất Hạnh đ&aacute;ng k&iacute;nh. &Ocirc;ng từng n&oacute;i rằng: &amp;quot;Chỉ c&oacute; những đối thoại ch&acirc;n th&agrave;nh mới l&agrave;m cho cả hai b&ecirc;n sẵn s&agrave;ng thay đổi&amp;quot;. C&ocirc;ng ty lu&ocirc;n ch&uacute; trọng v&agrave;o chọn lọc chất lượng sản phẩm, kh&ocirc;ng ngừng cải tiến chất lượng dịch vụ để cung cấp những sản phẩm VTNN c&oacute; chất lượng cao, gi&aacute; th&agrave;nh hợp l&yacute;, đ&aacute;p ứng kịp thời nhu cầu ng&agrave;y c&agrave;ng cao của kh&aacute;ch h&agrave;ng tại c&aacute;c khu vực trọng điểm, đem đến sự h&agrave;i l&ograve;ng cao nhất cho kh&aacute;ch h&agrave;ng v&agrave; nhất l&agrave; kh&aacute;ch h&agrave;ng &aacute;p dụng c&ocirc;ng nghệ sản xuất n&ocirc;ng nghiệp chất lượng cao.</p>
', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (2, N'TriAnen', N'<p>Your love and confidence is our pride, our greatest success in the process of formation and development, looking back over 10 years of construction and development, all members In the same house TPN realized that to achieve today&#39;s success is not only from the efforts, efforts of all employees of TPN but above all the trust of customers, as well as the belief. The cooperation of partners.</p>

<p>General outlook on current agricultural situation:<br />
World situation:</p>

<ul>
	<li>Accession to international economic treaties such as:</li>
	<li>By the Transpacific Partner Agreement (TPP).</li>
	<li>To be less dependent on a single trading partner and to have a broader relationship,</li>
	<li>TPP will help promote regional cooperation, helping to solve the problem of economic equality</li>
	<li>That is what TPP will bring to us all because the United States, Vietnam and other partners will have to adhere to the principle that the parties have come together. That is the future is waiting for us</li>
</ul>

<p>Domestic situation:</p>

<ul>
	<li>Rebuild the government system open and comply with the constitution and the law.</li>
	<li>Taking the private economy as a foundation for boosting the country&#39;s economic development</li>
	<li>Serve dirty food, counterfeit goods, imitation goods, poor quality</li>
	<li>In addition, the TPP also has more aggressive ways of protecting the environment and fighting corruption.</li>
	<li>The situation of saline intrusion in the provinces of Mekong Delta, severe drought in the Central Highlands</li>
</ul>

<p>Orientation of Lam Dong Province:</p>

<ul>
	<li>Expand the satellite city to develop into a vegetable tourism area and high technology Agriculture,</li>
	<li>Organize the plan to re-cultivate and build its own brand of coffee</li>
</ul>

<p>Development plan of TPN company with customers in the coming years:</p>

<ul>
	<li>Carefully filter out product groups that do not leave the environment harmful.</li>
	<li>Add pure and premium product lines to the range.</li>
	<li>Enhanced organic fertilizer lines.</li>
</ul>

<p>To ensure the worthy name of Tan Phu Nong: with the goal of continuously renovating, eliminating the backward agriculture, wasting, constantly updating the technology of agricultural production, step by step with the people. Farmers are constantly changing and developing in harmony with the ever-evolving global development.<br />
This is just the beginning to affirm the correctness and efficiency in the development orientation of a business to the professionalism of a Distributor, thus opening up many opportunities for the Company Limited. Tan Phu Nong continues to move forward with greater goals.<br />
We learn from the respected teacher Thich Nhat Hanh. He said: &quot;Only new sincere dialogues make both sides ready to change.&quot; The company always focuses on the selection of quality products, constantly improve the quality of services to provide high quality products with reasonable price, timely response to the increasing demand of customers. At the focus areas, bring the highest satisfaction to customers and especially customers apply high quality agricultural production technology.</p>
', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (3, N'NameEnterprise', N'', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (4, N'DesEnterprise', N'', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (5, N'SlideShow', N'/images/bannertpn1-1050x311.jpg;/images/bannertpn2-837x248.jpg;/images/img02.jpg', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (6, N'LichSuvi', N'<h1 dir="ltr"><strong>C&ocirc;ng ty T&acirc;n Ph&uacute; N&ocirc;ng trong hơn 10 năm</strong></h1>

<p dir="ltr">C&ocirc;ng ty TNHH SX-DV-TM T&acirc;n ph&uacute; N&ocirc;ng th&agrave;nh lập ng&agrave;y 26/04/2005, trải qua hơn 10 năm h&igrave;nh th&agrave;nh v&agrave; ph&aacute;t triển,&nbsp; qua gần 02 năm t&igrave;m kiếm đối t&aacute;c v&agrave; thiết lập thị trường với lực lượng nh&acirc;n sự ban đầu chỉ vỏn vẹn c&oacute; 05 người, diện t&iacute;ch VP ch&iacute;nh l&agrave; Gara xe chưa đầy 12m2, trang thiết bị, kho t&agrave;ng v&agrave; phương tiện vận chuyển thiếu thốn phải sử dụng chung với cửa h&agrave;ng Sơn Thủy, cộng với sự quyết t&acirc;m cao độ v&agrave; định hướng chiến lược đ&uacute;ng đắn C&ocirc;ng ty TNHH SX-DV-TM T&acirc;n ph&uacute; N&ocirc;ng ch&iacute;nh thức được Sở Kế Hoạch Đầu Tư Tỉnh l&acirc;m Đồng c&ocirc;ng nhận th&agrave;nh lập từ ng&agrave;y 26/04/2005 cho đến nay đ&atilde; hơn 10 năm tuổi. Đ&acirc;y l&agrave; khoảng thời gian kh&ocirc;ng d&agrave;i so với tuổi đời của 1 tổ chức v&agrave; l&agrave; khoảng thời gian kh&oacute; khăn nhất m&agrave; một doanh nghiệp phải đương đầu với những th&aacute;ch thức cạnh tranh gay gắt của nền kinh tế thị trường, đặc biệt trong thời hội nhập kinh tế quốc tế. Tuy nhi&ecirc;n với sự nỗ lực kh&ocirc;ng ngừng, sự quyết t&acirc;m, đồng l&ograve;ng của ban l&atilde;nh đạo v&agrave; tập thể nh&acirc;n vi&ecirc;n,C&ocirc;ng ty TNHH SX-DV-TM T&acirc;n ph&uacute; N&ocirc;ng đ&atilde; nhanh ch&oacute;ng đưa mọi hoạt động kinh doanh đi v&agrave;o ổn định v&agrave; ph&aacute;t triển một c&aacute;ch nhanh ch&oacute;ng, hiệu quả.</p>

<p dir="ltr">&nbsp;</p>

<p dir="ltr">Để đảm bảo xứng đ&aacute;ng với t&ecirc;n gọi T&acirc;n Ph&uacute; N&ocirc;ng : với mục ti&ecirc;u li&ecirc;n tục đổi mới, x&oacute;a bỏ nền n&ocirc;ng nghiệp lạc hậu, l&atilde;ng ph&iacute;, li&ecirc;n tục cập nhật c&ocirc;ng nghệ sản xuất n&ocirc;ng nghiệp cao, từng bước s&aacute;t c&aacute;nh c&ugrave;ng b&agrave; con n&ocirc;ng d&acirc;n li&ecirc;n tục thay đổi v&agrave; ph&aacute;t triển nhịp nh&agrave;ng với sự ph&aacute;t triển kh&ocirc;ng ngừng tr&ecirc;n to&agrave;n cầu.</p>

<p dir="ltr">Trước hết, đ&oacute; l&agrave; chỉ với đội ngũ c&aacute;n bộ quản l&yacute;, c&aacute;n bộ kinh doanh c&ograve;n rất trẻ nhưng ch&uacute;ng ta đ&atilde; tổ chức vận h&agrave;nh hoạt động nhịp nh&agrave;ng, kh&ocirc;ng ngừng t&igrave;m kiếm đối t&aacute;c c&oacute; c&ocirc;ng nghệ sản xuất hiện đại tại Việt Nam v&agrave; tr&ecirc;n thị trường quốc tế để kinh doanh một c&aacute;ch an to&agrave;n, ổn định li&ecirc;n tục trong hơn 10 năm qua. Kh&ocirc;ng chỉ vận h&agrave;nh an to&agrave;n, ổn định m&agrave; ch&uacute;ng ta c&ograve;n kh&ocirc;ng ngừng s&aacute;ng tạo, li&ecirc;n tục cải tiến chiến thuật, ch&iacute;nh s&aacute;ch thương mại để n&acirc;ng cao doanh số, n&acirc;ng cao doanh thu, tiết kiệm chi ph&iacute; vận h&agrave;nh đảm bảo hiệu quả kinh tế cao nhất của C&ocirc;ng Ty song song với việc chăm lo bảo vệ m&ocirc;i trường một c&aacute;ch tốt nhất.</p>

<p dir="ltr">Tổng doanh thu nh&igrave;n chung c&oacute; l&uacute;c trồi sụt nhưng đảm bảo tăng ổn định từ 40- 50% li&ecirc;n tục sau hơn 10 năm hoạt động.</p>

<p dir="ltr">Khẳng định thuế nộp ng&acirc;n s&aacute;ch Nh&agrave; nước vừa l&agrave; tr&aacute;ch nhiệm, vừa l&agrave; nghĩa vụ cao cả của doanh nghiệp</p>

<p dir="ltr">V&agrave; thu nhập của c&aacute;n bộ c&ocirc;ng nh&acirc;n vi&ecirc;n li&ecirc;n tục tăng theo sự ph&aacute;t triển của doanh nghiệp.</p>

<p dir="ltr">&nbsp;&nbsp;&nbsp;&nbsp;Đ&acirc;y chỉ l&agrave; bước khởi đầu khẳng định t&iacute;nh đ&uacute;ng đắn v&agrave; hiệu quả trong định hướng ph&aacute;t triển của một Doanh nghiệp tiến tới sự chuy&ecirc;n nghiệp của một nh&agrave; Ph&acirc;n Phối, từ đ&acirc;y mở ra nhiều cơ hội để C&ocirc;ng ty TNHH SX-DV-TM T&acirc;n ph&uacute; N&ocirc;ng tiếp tục tiến xa với những mục ti&ecirc;u lớn hơn nữa. C&ocirc;ng ty lu&ocirc;n ch&uacute; trọng v&agrave;o chọn lọc chất lượng sản phẩm, kh&ocirc;ng ngừng cải tiến chất lượng dịch vụ để cung cấp những sản phẩm VTNN c&oacute; chất lượng cao, gi&aacute; th&agrave;nh hợp l&yacute;, đ&aacute;p ứng kịp thời nhu cầu ng&agrave;y c&agrave;ng cao của kh&aacute;ch h&agrave;ng tại c&aacute;c khu vực trọng điểm, đem đến sự h&agrave;i l&ograve;ng cao nhất cho kh&aacute;ch h&agrave;ng v&agrave; nhất l&agrave; kh&aacute;ch h&agrave;ng &aacute;p dụng c&ocirc;ng nghệ sản xuất n&ocirc;ng nghiệp chất lượng cao. Với c&aacute;c ti&ecirc;u ch&iacute; kinh doanh đ&atilde; được x&aacute;c định ngay từ đầu của Cty TNHH SX-DV-TM T&acirc;n ph&uacute; N&ocirc;ng l&agrave; Tu&acirc;n thủ Ph&aacute;p Luật, Kinh Doanh hiệu quả, ph&aacute;t triển bền vững v&agrave; chiến lược ch&iacute;nh: l&agrave; tạo ra sự kh&aacute;c biệt v&agrave; chất lượng.</p>

<p dir="ltr">&nbsp;</p>
', NULL)
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon], [Nhom]) VALUES (7, N'LichSuen', N'<h1><strong>Tan Phu Nong Company for more than 10 years</strong></h1>

<p>Tan Phu Nong Production - Trading - Service Company Limited was established on 26/04/2005, over 10 years of establishment and development,<br />
a main car is not full 12m2, device page, storage and moving media used to be used with the shop Son Shui, plus the degree decisive and right orientation Tan Phu Company Limited is a Ho Chi Minh City Investment Company set from date 26/04/2005 for this now than 10 years old. This is a great time to start your business with a great deal of money. However, with the unceasing efforts, the determination and synchrony of leaders and employees, Tan Phu Manufacturing - Trading Co., Ltd. has quickly put all business activities into a stable and developing a. quick way, effect.</p>

<p>To make sure about the name of Tan Phu Nong: with the latest renewal links, remove the consequences of agriculture, the consequences, romantic, linked high agricultural technology, each step alongside her will change the countrys and growly pace with the developer kh&ocirc;ng kết th&uacute;c với mọi.<br />
Before the last, which is only for the manager of the team, the business but very young but the organized activities of a lotly, and did not follow the search for the author in Vietnam. and the continuous business over the past 10 years. Can not support all in all, stable with we can not create the highlight, successive operation, trade for trade to upgrade the city of business, up to rent, cost savings of a environment.<br />
Total revenue has generally declined, but is expected to increase steadily from 40-50% after more than 10 years of operation.<br />
The tax assessment of the medium-term group is the responsibility, ie the noble duty of the business<br />
With the information of the employee of the employer to follow the development of the business.<br />
Tan Phu Agriculture will continue to implement the objectives of the State of the State of the State. more. The company always pay attention to quality filter products without the need to provide quality service to provide high quality products with reasonable price to meet the increasing demand of customers at a regional region, giving the best at best to customers and best product of the best product of agriculture. With the business criteria have been identified at the beginning of Tan Phu Nong Production - Trading - Service Co., Ltd. is Compliance with Laws, Business Effectiveness, Development of difference and quality.</p>
', NULL)
SET IDENTITY_INSERT [dbo].[tb_TuyChon] OFF
ALTER TABLE [dbo].[tb_BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_tb_BaiViet_tb_NguoiDung] FOREIGN KEY([NguoiViet])
REFERENCES [dbo].[tb_NguoiDung] ([TenDangNhap])
GO
ALTER TABLE [dbo].[tb_BaiViet] CHECK CONSTRAINT [FK_tb_BaiViet_tb_NguoiDung]
GO
ALTER TABLE [dbo].[tb_BaiVietTrans]  WITH CHECK ADD  CONSTRAINT [FK_tb_BaiVietTrans_tb_BaiViet] FOREIGN KEY([MaBV])
REFERENCES [dbo].[tb_BaiViet] ([MaBV])
GO
ALTER TABLE [dbo].[tb_BaiVietTrans] CHECK CONSTRAINT [FK_tb_BaiVietTrans_tb_BaiViet]
GO
ALTER TABLE [dbo].[tb_DoiNguQL_Trans]  WITH CHECK ADD  CONSTRAINT [FK_tb_DoiNguQL_Trans_tb_DoiNguQuanLy] FOREIGN KEY([MaQL])
REFERENCES [dbo].[tb_DoiNguQuanLy] ([MaQL])
GO
ALTER TABLE [dbo].[tb_DoiNguQL_Trans] CHECK CONSTRAINT [FK_tb_DoiNguQL_Trans_tb_DoiNguQuanLy]
GO
ALTER TABLE [dbo].[tb_LoaiSP]  WITH CHECK ADD  CONSTRAINT [FK_tb_LoaiSP_tb_LoaiSP] FOREIGN KEY([LoaiCha])
REFERENCES [dbo].[tb_LoaiSP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[tb_LoaiSP] CHECK CONSTRAINT [FK_tb_LoaiSP_tb_LoaiSP]
GO
ALTER TABLE [dbo].[tb_LoaiSP]  WITH CHECK ADD  CONSTRAINT [FK_tb_LoaiSP_tb_NguoiDung] FOREIGN KEY([NguoiThem])
REFERENCES [dbo].[tb_NguoiDung] ([TenDangNhap])
GO
ALTER TABLE [dbo].[tb_LoaiSP] CHECK CONSTRAINT [FK_tb_LoaiSP_tb_NguoiDung]
GO
ALTER TABLE [dbo].[tb_LoaiSPTrans]  WITH CHECK ADD  CONSTRAINT [FK_tb_LoaiSPTrans_tb_LoaiSP] FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[tb_LoaiSP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[tb_LoaiSPTrans] CHECK CONSTRAINT [FK_tb_LoaiSPTrans_tb_LoaiSP]
GO
ALTER TABLE [dbo].[tb_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tb_SanPham_tb_LoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[tb_LoaiSP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[tb_SanPham] CHECK CONSTRAINT [FK_tb_SanPham_tb_LoaiSP]
GO
ALTER TABLE [dbo].[tb_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tb_SanPham_tb_NguoiDung] FOREIGN KEY([NguoiThem])
REFERENCES [dbo].[tb_NguoiDung] ([TenDangNhap])
GO
ALTER TABLE [dbo].[tb_SanPham] CHECK CONSTRAINT [FK_tb_SanPham_tb_NguoiDung]
GO
ALTER TABLE [dbo].[tb_SanPhamTrans]  WITH CHECK ADD  CONSTRAINT [FK_tb_SanPhamTrans_tb_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tb_SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[tb_SanPhamTrans] CHECK CONSTRAINT [FK_tb_SanPhamTrans_tb_SanPham]
GO
