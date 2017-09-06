<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageBrowser.aspx.cs" Inherits="DACN_TanPhuNong.Areas.Admin.brower.ImageBrowser" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Image Browser</title>
	<style type="text/css">
		body { margin: 0px; }
		form { background-color: #E3E3C7; }
		h1 { padding: 15px; margin: 0px; padding-bottom: 0px; font-family:Arial; font-size: 14pt; color: #737357; }
	</style>
</head>
<body>
	<form id="form1" runat="server" style="margin: 0 auto;">
	<div>
		<h1>Thư viện hình ảnh</h1>
        
		<table border="1" style="background-color:#F1F1E3; margin:15px; width: 720px; border-spacing: 0px;">
			<tr>
				<td style="width: 396px; vertical-align: middle; text-align: center; padding: 10px;">
					<asp:Image ID="Image1" runat="server" Style="max-height: 450px; max-width: 380px;" />
				</td>
				<td style="width: 324px; vertical-align: top; padding: 10px;">
					Thư mục:<br />
					<asp:DropDownList ID="DirectoryList" runat="server" Style="width: 159px;" OnSelectedIndexChanged="ChangeDirectory" AutoPostBack="true" />
					<asp:Button ID="DeleteDirectoryButton" runat="server" Text="Xóa bỏ" CssClass="btn btn-danger" OnClick="DeleteFolder" OnClientClick="return confirm('Bạn có chắc chắn xóa thư mục và nội dung bên trong?');" />
					<asp:HiddenField ID="NewDirectoryName" runat="server" />
					<asp:Button ID="NewDirectoryButton" runat="server" Text="Tạo mới" CssClass="btn btn-default" OnClick="CreateFolder" />
					<br /><br />
					
					<asp:Panel ID="SearchBox" runat="server" DefaultButton="SearchButton">
						Tìm kiếm:<br />
						<asp:TextBox ID="SearchTerms" runat="server" Style="width: 216px;"/>
					    <asp:Button ID="SearchButton" runat="server" Text="Tìm kiếm" OnClick="Search" UseSubmitBehavior="false"/>
						<br />
					</asp:Panel>
					<asp:ListBox  ID="ImageList" runat="server" Style="width: 290px; height: 180px; margin: 5px 0;" OnSelectedIndexChanged="SelectImage" AutoPostBack="true" />

					<asp:HiddenField ID="NewImageName" runat="server" />
					<asp:Button ID="RenameImageButton" runat="server" Text="Đổi tên" OnClick="RenameImage" />
					<asp:Button ID="DeleteImageButton" runat="server" Text="Xóa" OnClick="DeleteImage" OnClientClick="return confirm('Bạn chắc chắn là xóa ảnh này?');" />
					<br />
					<br />
					Kích thước:<br />
					<asp:TextBox ID="ResizeWidth" runat="server" Width="50" OnTextChanged="ResizeWidthChanged" />
					x
					<asp:TextBox ID="ResizeHeight" runat="server" Width="50" OnTextChanged="ResizeHeightChanged" />
					<asp:HiddenField ID="ImageAspectRatio" runat="server" />
					<asp:Button ID="ResizeImageButton" runat="server" Text="Resize Image" OnClick="ResizeImage" /><br />
					<asp:Label ID="ResizeMessage" runat="server" ForeColor="Red" />
					<br /><br />
					Tải ảnh lên: (dung lượng ảnh tối đa 10Mb)
					<asp:FileUpload ID="UploadedImageFile" runat="server" />
					<asp:Button ID="UploadButton" runat="server" Text="Tải lên" OnClick="Upload" /><br />
					<br />
				</td>
			</tr>
		</table>
        
		<div style="text-align: center;">
			<asp:Button ID="OkButton" runat="server" Text="Chọn" OnClick="Clear" />
			<asp:Button ID="CancelButton" runat="server" Text="Thoát" OnClientClick="window.top.close(); window.top.opener.focus();" OnClick="Clear" />
			<br /><br />
		</div>
	</div>
	</form>
</body>
</html>
