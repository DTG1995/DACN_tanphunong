USE [db_tanphunong]
GO
/****** Object:  Table [dbo].[tb_BaiViet]    Script Date: 8/27/2017 10:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_BaiViet](
	[MaBV] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [ntext] NULL,
	[LoaiBaiViet] [int] NULL,
	[NgayViet] [datetime] NULL,
 CONSTRAINT [PK_tb_BaiViet] PRIMARY KEY CLUSTERED 
(
	[MaBV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_DoiTac]    Script Date: 8/27/2017 10:11:55 PM ******/
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
/****** Object:  Table [dbo].[tb_LoaiSP]    Script Date: 8/27/2017 10:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_LoaiSP](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](100) NULL,
	[MoTa] [nvarchar](200) NULL,
	[LoaiCha] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_tb_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_NguoiDung]    Script Date: 8/27/2017 10:11:55 PM ******/
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
	[LaQTV] [bit] NULL,
	[ThoiGianDNCuoi] [datetime] NULL,
 CONSTRAINT [PK_tb_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_SanPham]    Script Date: 8/27/2017 10:11:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_tb_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_TuyChon]    Script Date: 8/27/2017 10:11:55 PM ******/
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
/****** Object:  Table [dbo].[tb_VanPhong]    Script Date: 8/27/2017 10:11:55 PM ******/
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
SET IDENTITY_INSERT [dbo].[tb_TuyChon] OFF
ALTER TABLE [dbo].[tb_LoaiSP]  WITH CHECK ADD  CONSTRAINT [FK_tb_LoaiSP_tb_LoaiSP] FOREIGN KEY([LoaiCha])
REFERENCES [dbo].[tb_LoaiSP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[tb_LoaiSP] CHECK CONSTRAINT [FK_tb_LoaiSP_tb_LoaiSP]
GO
ALTER TABLE [dbo].[tb_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_tb_SanPham_tb_LoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[tb_LoaiSP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[tb_SanPham] CHECK CONSTRAINT [FK_tb_SanPham_tb_LoaiSP]
GO
