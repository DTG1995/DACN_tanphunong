USE [dbtanphunong]
GO
/****** Object:  Table [dbo].[tb_BaiViet]    Script Date: 9/13/2017 9:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_BaiViet](
	[MaBV] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](250) NULL,
	[TomTat] [ntext] NULL,
	[NoiDung] [ntext] NULL,
	[LoaiBaiViet] [int] NULL,
	[NgayViet] [datetime] NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[NguoiViet] [varchar](50) NULL,
 CONSTRAINT [PK_tb_BaiViet] PRIMARY KEY CLUSTERED 
(
	[MaBV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_DoiTac]    Script Date: 9/13/2017 9:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_DoiTac](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[TenDT] [nvarchar](100) NULL,
	[SDT] [nvarchar](50) NULL,
	[Email] [nvarchar](200) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[ChiTiet] [ntext] NULL,
	[WebsiteDT] [nvarchar](100) NULL,
 CONSTRAINT [PK_DoiTac] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_LoaiSP]    Script Date: 9/13/2017 9:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_LoaiSP](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](100) NULL,
	[MoTa] [nvarchar](200) NULL,
	[LoaiCha] [int] NULL,
	[TrangThai] [bit] NULL,
	[NguoiThem] [varchar](50) NULL,
 CONSTRAINT [PK_tb_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_NguoiDung]    Script Date: 9/13/2017 9:22:55 PM ******/
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_NhatKy]    Script Date: 9/13/2017 9:22:55 PM ******/
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
/****** Object:  Table [dbo].[tb_SanPham]    Script Date: 9/13/2017 9:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[HinhAnh] [nvarchar](100) NULL,
	[TenSanPham] [nvarchar](100) NULL,
	[UuDiem] [ntext] NULL,
	[DacDiem] [ntext] NULL,
	[ThanhPhanChinh] [ntext] NULL,
	[LuuY] [ntext] NULL,
	[QuyCachDongGoi] [nvarchar](100) NULL,
	[XuatXu] [nvarchar](100) NULL,
	[CachDung] [ntext] NULL,
	[GiaThanh] [money] NULL,
	[TrangThai] [bit] NULL,
	[MaLoai] [int] NOT NULL,
	[NguoiThem] [varchar](50) NULL,
 CONSTRAINT [PK_tb_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_TuyChon]    Script Date: 9/13/2017 9:22:55 PM ******/
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
 CONSTRAINT [PK_tb_TuyChon] PRIMARY KEY CLUSTERED 
(
	[MaTuyChon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_VanPhong]    Script Date: 9/13/2017 9:22:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_VanPhong](
	[MaVP] [int] IDENTITY(1,1) NOT NULL,
	[TenVP] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [nvarchar](11) NULL,
	[Email] [nvarchar](100) NULL,
	[ChiTiet] [ntext] NULL,
 CONSTRAINT [PK_tb_VanPhong] PRIMARY KEY CLUSTERED 
(
	[MaVP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tb_BaiViet] ON 

INSERT [dbo].[tb_BaiViet] ([MaBV], [TieuDe], [TomTat], [NoiDung], [LoaiBaiViet], [NgayViet], [HinhAnh], [NguoiViet]) VALUES (1, N'Sửa bài viết', N'asdasdasd', N'<p>asdasdasdasd</p>
', 0, CAST(0x0000A7ED0110271A AS DateTime), N'/images/lua-980x290.jpg', NULL)
INSERT [dbo].[tb_BaiViet] ([MaBV], [TieuDe], [TomTat], [NoiDung], [LoaiBaiViet], [NgayViet], [HinhAnh], [NguoiViet]) VALUES (2, N'Thử thêm bài viết', N'test2', N'<p>teast12</p>
', 0, CAST(0x0000A7ED010F66EB AS DateTime), N'/images/lua-980x290.jpg', NULL)
INSERT [dbo].[tb_BaiViet] ([MaBV], [TieuDe], [TomTat], [NoiDung], [LoaiBaiViet], [NgayViet], [HinhAnh], [NguoiViet]) VALUES (3, N'Tuyển nhân viên quản trị web', N'Tuyển nhân viên quản trị website của công ty', N'<p><strong>-Y&ecirc;u cầu:</strong></p>

<ol>
	<li>th&ocirc;ng thạo m&aacute;y t&iacute;nh</li>
	<li>th&ocirc;ng thạo&nbsp;thao t&aacute;c tr&ecirc;n website</li>
</ol>

<p><strong>-Li&ecirc;n hệ</strong></p>

<p style="margin-left:40px"><strong>Đinh Ti&ecirc;n Giỏi - SĐT: 01693638xxx&nbsp;- Email: tiengioiit@gmail.com</strong></p>
', 1, CAST(0x0000A7ED015DD8EB AS DateTime), N'/images/logo-tan-phu-nong.png', NULL)
SET IDENTITY_INSERT [dbo].[tb_BaiViet] OFF
SET IDENTITY_INSERT [dbo].[tb_LoaiSP] ON 

INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (3, N'Phân Bón', N'Phân bón', NULL, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (4, N'Thuốc BVTV', N'Thuốc trừ sâu bọ, côn trùng, ..', NULL, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (5, N'Phân Bón Hữu Cơ', N'Phân bón hữu cơ', 3, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (6, N'Phân Bón Vô Cơ', N'Phân bón vô cơ', 3, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (7, N'Thuốc trừ sâu', N'thuốc trừ sâu', 4, 1, NULL)
INSERT [dbo].[tb_LoaiSP] ([MaLoaiSP], [TenLoaiSP], [MoTa], [LoaiCha], [TrangThai], [NguoiThem]) VALUES (8, N'Thuốc trừ bệnh', N'thuốc trừ bệnh', 4, 1, NULL)
SET IDENTITY_INSERT [dbo].[tb_LoaiSP] OFF
INSERT [dbo].[tb_NguoiDung] ([TenDangNhap], [MatKhau], [TrangThai], [LoaiND], [ThoiGianDNCuoi]) VALUES (N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, N'0,3', NULL)
INSERT [dbo].[tb_NguoiDung] ([TenDangNhap], [MatKhau], [TrangThai], [LoaiND], [ThoiGianDNCuoi]) VALUES (N'dtg0106', N'21232f297a57a5a743894a0e4a801fc3', 1, N'1,2', NULL)
SET IDENTITY_INSERT [dbo].[tb_NhatKy] ON 

INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (1, N'dtg1995', N'Bài viết', N'13/09/2017 - Thêm Bài viết', 2)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (2, N'dtg1995', N'Bài viết', N'13/09/2017:04:30:52 - Sửa Bài viết', 1)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (3, N'dtg1995', N'Trang chủ', N'13/09/2017 07:46:05 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (4, N'dtg1995', N'Trang chủ', N'13/09/2017 07:49:10 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (5, N'dtg1995', N'Trang chủ', N'13/09/2017 07:50:29 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (6, N'dtg1995', N'Trang chủ', N'13/09/2017 07:50:40 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (7, N'dtg1995', N'Trang chủ', N'13/09/2017 07:51:11 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (8, N'dtg1995', N'Trang chủ', N'13/09/2017 07:51:52 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (9, N'dtg1995', N'Trang chủ', N'13/09/2017 07:52:55 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (10, N'dtg1995', N'Trang chủ', N'13/09/2017 07:53:03 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (11, N'dtg1995', N'Trang chủ', N'13/09/2017 07:58:25 - Sửa nội dung header', NULL)
INSERT [dbo].[tb_NhatKy] ([MaNK], [NguoiDung], [DoiTuong], [ThaoTac], [MaDoiTuong]) VALUES (12, N'dtg1995', N'Tuyển dụng', N'13/09/2017 09:13:45 - Thêm tuyển dụng "Tuyển nhân viên quản trị web"', 3)
SET IDENTITY_INSERT [dbo].[tb_NhatKy] OFF
SET IDENTITY_INSERT [dbo].[tb_SanPham] ON 

INSERT [dbo].[tb_SanPham] ([MaSP], [HinhAnh], [TenSanPham], [UuDiem], [DacDiem], [ThanhPhanChinh], [LuuY], [QuyCachDongGoi], [XuatXu], [CachDung], [GiaThanh], [TrangThai], [MaLoai], [NguoiThem]) VALUES (2, N'/images/25-5-5-bag.jpg', N'Phân hữu cơ khoáng RealStrong 25.5.5', N'– Chuyên dùng giai đoạn sinh trưởng, giúp cây phát triển nhanh và khỏe
– Cung cấp đầy đủ hữu cơ, NPK, Trung vi lượng, Zeolite, Acid Humic trong 1 viên phân.
– Giúp tăng năng suất cây trồng từ 10-20%
– Giúp giảm chi phí sản xuất
– Tái tạo và phân giải các nguồn dinh dưỡng khó tiêu tồn lưu lâu ngày ở trong đất mà cây trồng không hấp thu được.
– Cây trồng rất ít bị nhiễm bệnh ở gốc và rễ. Giúp cây kháng bệnh và chống úng, chống hạn tốt.
– Không chứa mầm bệnh và hạt cỏ dại', N'<p>&ndash; Th&agrave;nh phần hữu cơ của ph&acirc;n RealStrong gồm: B&atilde; cọ dầu, b&atilde; ca cao, c&aacute;m gạo, mật đường, tro n&uacute;i lửa (Zeolite)<br />
&ndash; Chứa 8 chủng vi sinh ngủ đ&ocirc;ng duy nhất tại Việt Nam<br />
+ Lactobacillus Series: Ph&acirc;n giải Rơm rạ<br />
+ Photosynthetic Bacteria Series: Cố định đạm<br />
+ Nitrogen Fixing Series: Chuyển Nitơ th&agrave;nh Đạm<br />
+ Nitrifying Bacteria Series: Chuyển acid nitric th&agrave;nh đạm Nitrate<br />
+ Factors Producing Bacteria Series: B&agrave;i tiết tạo ra k&iacute;ch th&iacute;ch tố tăng trưởng cho c&acirc;y trồng<br />
+ Yeast Group Series: B&agrave;i tiết tạo ra k&iacute;ch th&iacute;ch tố tăng trưởng v&agrave; ph&acirc;n chia tế b&agrave;o rễ<br />
+ Actinomyces Series: Tạo ra m&ugrave;i xua đuổi c&ocirc;n tr&ugrave;ng</p>
', N'<p>HC: 50% (Axit humic: 2); N-P<sub>2</sub>O<sub>5</sub>-K<sub>2</sub>O: 25%-2,8%-5% (P<sub>2</sub>O<sub>5</sub>&nbsp;ts: 5)<br />
Độ ẩm: 18%<br />
pH: 5-6,5</p>
', N'<p>&ndash; Cần tưới đủ nước khi b&oacute;n ph&acirc;n RealStrong tr&ecirc;n đất kh&ocirc;<br />
&ndash; Định lượng b&oacute;n ph&acirc;n tr&ecirc;n đ&acirc;y chỉ l&agrave; hướng dẫn chung, tỉ lệ n&agrave;y c&oacute; thể thay đổi tuỳ theo loại đất đai, c&acirc;y trồng, thời vụ m&agrave; &aacute;p dụng cho th&iacute;ch hợp<br />
&ndash; Để ph&acirc;n nơi kh&ocirc; r&aacute;o tho&aacute;ng m&aacute;t.</p>
', N'25kg/bao', N'MALAYSIA', N'<table border="1" cellpadding="1" cellspacing="1" summary="hướng dẫn sử dụng phân bón">
	<caption>
	<p style="text-align:left"><strong>C&aacute;ch sử dụng</strong></p>
	</caption>
	<tbody>
		<tr>
			<td>Đồng cỏ s&acirc;n Golf</td>
			<td>&quot;25 &ndash; 50kg/1.000m2/lần(b&oacute;n 3-4 lần/năm)&rdquo;</td>
		</tr>
		<tr>
			<td>C&acirc;y lương thực: Bắp, l&uacute;a, đậu</td>
			<td>&ldquo;25 &ndash; 50kg/1.000m2/lần(b&oacute;n 3-4 lần/năm)&rdquo;</td>
		</tr>
		<tr>
			<td>C&acirc;y rau m&agrave;u: Dưa hấu, dưa leo, c&agrave; chua, ớt, b&iacute;, rau ăn l&aacute;, khoai t&acirc;y, d&acirc;u t&acirc;y, bắp s&uacute;, cải thảo, s&uacute;p lơ, su h&agrave;o, c&agrave; rốt&hellip;</td>
			<td>&quot;50 &ndash; 100kg/1.000m2/lần(b&oacute;n 3-4 lần/năm)&rdquo;</td>
		</tr>
		<tr>
			<td>C&acirc;y ăn quả: Cam, qu&yacute;t, bưởi, chanh, thanh long, nh&atilde;n, xo&agrave;i, ch&ocirc;m ch&ocirc;m, sầu ri&ecirc;ng, vải, hồng, dứa (kh&oacute;m)&hellip;</td>
			<td colspan="1" rowspan="2">&ldquo;C&acirc;y non: 0,2-0,4kg/gốc/lần(b&oacute;n 3-4 lần/năm)&rdquo;</td>
		</tr>
		<tr>
			<td>C&acirc;y tr&ecirc;n 1,5 tuổi: 1-2kg/gốc/lần</td>
		</tr>
		<tr>
			<td>C&acirc;y c&ocirc;ng nghiệp ngắn ng&agrave;y: B&ocirc;ng vải, thuốc l&aacute;, m&egrave; đậu phộng&hellip;</td>
			<td>&ldquo;50 &ndash; 75kg/1.000m2/lần(b&oacute;n 3-4 lần/năm)&rdquo;</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>
', 150000.0000, 1, 5, NULL)
SET IDENTITY_INSERT [dbo].[tb_SanPham] OFF
SET IDENTITY_INSERT [dbo].[tb_TuyChon] ON 

INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (4, N'ContentHome', N'<h2><strong>T&acirc;n Ph&uacute; N&ocirc;ng &ndash; Vững bước c&ugrave;ng nh&agrave; n&ocirc;ng</strong></h2>

<p><strong>C&ocirc;ng ty TNHH SX DV TM T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;th&agrave;nh lập ng&agrave;y 26/04/2005, trải qua hơn một thập kỷ đến nay, c&ocirc;ng&nbsp;ty đ&atilde; ph&aacute;t triển vững mạnh với phương ch&acirc;m &ldquo;<em><strong>Vững bước c&ugrave;ng nh&agrave; n&ocirc;ng</strong></em>&rdquo;, đặt lợi &iacute;ch của người n&ocirc;ng d&acirc;n n&oacute;i&nbsp;ri&ecirc;ng v&agrave; cả nền n&ocirc;ng nghiệp n&oacute;i chung l&ecirc;n h&agrave;ng đầu, đặc biệt l&agrave; ng&agrave;nh n&ocirc;ng nghiệp c&ocirc;ng nghệ cao theo định&nbsp;hướng ph&aacute;t triển quốc gia.</p>

<p><img alt="logo-tan-phu-nong" src="http://tanphunong.vn/wp-content/uploads/2015/11/logo-tan-phu-nong.png" style="clear:both; display:block; height:442px; margin-left:auto; margin-right:auto; width:450px" /></p>

<h1>Sứ mệnh</h1>

<p>Nhận thấy sứ mệnh của m&igrave;nh, c&ocirc;ng ty ch&uacute;ng t&ocirc;i lu&ocirc;n đồng h&agrave;nh c&ugrave;ng c&aacute;c doanh nghiệp v&agrave; người n&ocirc;ng d&acirc;n&nbsp;bằng nhiều h&igrave;nh thức kh&aacute;c nhau, nhằm ứng dụng rộng r&atilde;i kỹ thuật canh t&aacute;c quốc tế v&agrave; chọn lọc sử dụng những&nbsp;sản phẩm vật tư n&ocirc;ng nghiệp hữu cơ ti&ecirc;n tiến, bền vững để tiết kiệm đầu tư , c&ocirc;ng sức, từng bước n&acirc;ng cao&nbsp;chất lượng n&ocirc;ng sản của Việt Nam, đ&aacute;p ứng ph&ugrave; hợp mọi ti&ecirc;u chuẩn khắt khe của thị trường quốc tế v&agrave; quan&nbsp;trọng nhất l&agrave; bảo vệ được nền đất canh t&aacute;c n&ocirc;ng nghiệp cũng như bảo vệ m&ocirc;i trường sống của ch&uacute;ng ta.</p>

<h1>Tầm nh&igrave;n</h1>

<p>Để thực hiện những nhiệm vụ tr&ecirc;n, c&ocirc;ng ty&nbsp;<strong>T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;với hệ thống b&aacute;n lẻ b&aacute;n bu&ocirc;n d&agrave;y đặc rải r&aacute;c khắp&nbsp;cả nước, ph&acirc;n phối những sản phẩm nhập khẩu lẫn nội địa một c&aacute;ch chọn lọc. Tất cả những sản phẩm nhập&nbsp;khẩu của ch&uacute;ng t&ocirc;i đều xuất ph&aacute;t từ những nước c&oacute; nền c&ocirc;ng nghiệp ti&ecirc;n tiến như Đức, Bỉ, Ph&aacute;p, Sing,&nbsp;Malaysia, đều được Ch&iacute;nh Phủ Việt Nam kiểm định v&agrave; khảo nghiệm nghi&ecirc;m ngặt. B&ecirc;n cạnh đ&oacute; để ủng hộ&nbsp;ng&agrave;nh sản xuất nước nh&agrave;, ch&uacute;ng t&ocirc;i cũng ph&acirc;n phối những sản phẩm nội địa c&oacute; uy t&iacute;n, chất lượng cao, &aacute;p dụng&nbsp;kỹ thuật sản xuất bậc nhất hiện nay.</p>

<p>Uy t&iacute;n v&agrave; bề d&agrave;y kinh nghiệm của c&ocirc;ng ty&nbsp;<strong>T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;đ&atilde; được b&agrave; con n&ocirc;ng d&acirc;n c&ugrave;ng những doanh nghiệp&nbsp;lớn khẳng định bằng sự gắn b&oacute; l&acirc;u d&agrave;i. Điển h&igrave;nh như một số doanh nghiệp lớn như Hasfarm, L&rsquo;ang Farm,&nbsp;L&acirc;m Đ&agrave;i, Rừng Hoa &hellip; đều đặt sự t&iacute;n nhiệm cao v&agrave;o&nbsp;<strong>T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;v&agrave; trở th&agrave;nh những đối t&aacute;c trung th&agrave;nh.</p>

<p>Đến với&nbsp;<strong>T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;để trải nghiệm phong c&aacute;ch phục vụ tận t&igrave;nh tận t&acirc;m, sản phẩm đầy đủ, đa dạng v&agrave; để&nbsp;tận hưởng sự phục vụ của một nh&agrave; ph&acirc;n phối chuy&ecirc;n nghiệp.</p>

<h3>Ch&uacute;ng t&ocirc;i tự h&agrave;o khẳng định &ldquo;Nh&agrave; ph&acirc;n phối n&agrave;o chuy&ecirc;n nghiệp nhất, ch&uacute;ng t&ocirc;i chuy&ecirc;n nghiệp hơn!&rdquo;</h3>

<p>&nbsp;</p>

<h4>Th&ocirc;ng tin li&ecirc;n hệ</h4>

<h1>C&ocirc;ng ty TNHH SX DV TM T&acirc;n Ph&uacute; N&ocirc;ng</h1>

<p><strong>Địa chỉ văn ph&ograve;ng</strong>&nbsp;: Số 01B Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam</p>

<p><strong>Trung t&acirc;m ph&acirc;n phối</strong>: Số 57 Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam</p>

<p>Chăm s&oacute;c kh&aacute;ch h&agrave;ng:</p>

<p>C&ocirc;&nbsp;<strong>Ngọc Thủy &ndash; Điện thoại: 0633 828958 &ndash; Di động:&nbsp;0982785 629&nbsp;</strong></p>

<p>C&ocirc;&nbsp;<strong>Hạnh Trang &ndash; Điện thoại:&nbsp;063 3549797 &ndash; Di động:&nbsp;0125 970 33 79</strong></p>

<p>C&ocirc;&nbsp;<strong>Hồng Nhung &ndash; Điện thoại:&nbsp;063 3810168 &ndash; Di động:&nbsp;0986 873 037</strong></p>
')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (1002, N'VeChungToi', N'<p>C&ocirc;ng ty TNHH Sản xuất-Dịch vụ-Thương mại T&acirc;n Ph&uacute; N&ocirc;ng l&agrave; 1 doanh nghiệp chuy&ecirc;n kinh doanh trong lĩnh vực vật tư n&ocirc;ng nghiệp, c&oacute; trụ sở đặt tại số 1 đường Hồ Xu&acirc;n Hương, phường 9, th&agrave;nh phố Đ&agrave; Lạt, tỉnh L&acirc;m Đồng.</p>

<p>C&ocirc;ng ty TNHH SX-DV-TM T&acirc;n Ph&uacute; N&ocirc;ng được th&agrave;nh lập ng&agrave;y 26/04/2005, sau 10 năm hoạt động C&ocirc;ng ty đ&atilde; từng bước trưởng th&agrave;nh v&agrave; lớn mạnh (mở rộng), mang t&iacute;nh chuy&ecirc;n nghiệp cao.</p>
')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (1003, N'LienHe', N'<p><strong>C&ocirc;ng ty TNHH Sản xuất-Dịch vụ-Thương mại T&acirc;n Ph&uacute; N&ocirc;ng</strong>&nbsp;<br />
<strong>Địa chỉ văn ph&ograve;ng&nbsp;</strong>: Số 01B Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam<br />
<strong>Trung t&acirc;m ph&acirc;n phối</strong>: Số 57 Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam&nbsp;<br />
Chăm s&oacute;c kh&aacute;ch h&agrave;ng:<br />
C&ocirc; Ngọc Thủy &ndash; Điện thoại: 0633 828958 &ndash; Di động: 0982785 629&nbsp;<br />
C&ocirc; Hạnh Trang &ndash; Điện thoại: 063 3549797 &ndash; Di động: 0125 970 33 79&nbsp;<br />
C&ocirc; Hồng Nhung &ndash; Điện thoại: 063 3810168 &ndash; Di động: 0986 873 037</p>
')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (1004, N'SanPhamFooter', N'<ul>
	<li>1. Ph&acirc;n b&oacute;n đất: Ph&acirc;n phức hợp, Ph&acirc;n đơn, Ph&acirc;n hữu cơ</li>
	<li>2. Ph&acirc;n b&oacute;n chuy&ecirc;n dụng cho hệ thống tưới nhỏ giọt</li>
	<li>3. Ph&acirc;n b&oacute;n l&aacute;: Hữu cơ, V&ocirc; cơ, K&iacute;ch th&iacute;ch tố sinh trưởng</li>
	<li>4. Thuốc BVTV: Thuốc bệnh, Thuốc s&acirc;u, Thuốc diệt cỏ</li>
	<li>5. Vật tư n&ocirc;ng nghiệp: M&agrave;ng phủ n&ocirc;ng nghiệp</li>
</ul>
')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (2002, N'SlideShow', N'/images/bannertpn1-1050x311.jpg;/images/bannertpn2-837x248.jpg;/images/slider-3-976x366-976x289.jpg;/images/lua-980x290.jpg;/images/tanphunongx-1350x400.jpg')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (2003, N'NameEnterprise', N'Tân Phú Nông')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (2004, N'DesEnterprise', N'Công ty TNHH Sản xuất Dịch vụ Thương mại Tân Phú Nông')
INSERT [dbo].[tb_TuyChon] ([MaTuyChon], [TenTuyChon], [NoiDungTuyChon]) VALUES (2006, N'ContentLienHe', N'<h1>C&ocirc;ng ty TNHH SX DV TM T&acirc;n Ph&uacute; N&ocirc;ng</h1>

<p><strong>Địa chỉ văn ph&ograve;ng</strong>&nbsp;: Số 01B Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam</p>

<p><strong>Trung t&acirc;m ph&acirc;n phối</strong>: Số 57 Hồ Xu&acirc;n Hương, phường 9, TP Đ&agrave; Lạt, Tỉnh L&acirc;m Đồng, Việt Nam</p>

<p>Chăm s&oacute;c kh&aacute;ch h&agrave;ng:</p>

<p>C&ocirc;&nbsp;<strong>Ngọc Thủy &ndash; Điện thoại: 0633 828958 &ndash; Di động:&nbsp;0982785 629&nbsp;</strong></p>

<p>C&ocirc;&nbsp;<strong>Hạnh Trang &ndash; Điện thoại:&nbsp;063 3549797 &ndash; Di động:&nbsp;0125 970 33 79</strong></p>

<p>C&ocirc;&nbsp;<strong>Hồng Nhung &ndash; Điện thoại:&nbsp;063 3810168 &ndash; Di động:&nbsp;0986 873 037</strong></p>
')
SET IDENTITY_INSERT [dbo].[tb_TuyChon] OFF
SET IDENTITY_INSERT [dbo].[tb_VanPhong] ON 

INSERT [dbo].[tb_VanPhong] ([MaVP], [TenVP], [DiaChi], [SDT], [Email], [ChiTiet]) VALUES (1, N'CÔNG TY TNHH SX - DV - TM TÂN PHÚ NÔNG', N'Số 1B đường Hồ Xuân Hương, Phường 9, Thành phố Đà Lạt, Lâm Đồng', N'0633810168', N'chưa cập nhật', NULL)
INSERT [dbo].[tb_VanPhong] ([MaVP], [TenVP], [DiaChi], [SDT], [Email], [ChiTiet]) VALUES (2, N'CHI NHÁNH CÔNG TY TNHH SX - DV - TM TÂN PHÚ NÔNG', N' Thôn Bồng Lai, Xã Hiệp Thạnh, , Huyện Đức Trọng, Lâm Đồng', N'063.828958', NULL, N'<p><img alt="" src="/images/logo-tan-phu-nong.png" style="height:810px; width:824px" /></p>
')
SET IDENTITY_INSERT [dbo].[tb_VanPhong] OFF
ALTER TABLE [dbo].[tb_BaiViet]  WITH CHECK ADD  CONSTRAINT [FK_tb_BaiViet_tb_NguoiDung] FOREIGN KEY([NguoiViet])
REFERENCES [dbo].[tb_NguoiDung] ([TenDangNhap])
GO
ALTER TABLE [dbo].[tb_BaiViet] CHECK CONSTRAINT [FK_tb_BaiViet_tb_NguoiDung]
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
