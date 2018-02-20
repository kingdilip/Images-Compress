<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ImageResize.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image size</title>
    <link href="Design/css/bootstrap.css" rel="stylesheet" />
    <link href="Design/css/style.css" rel="stylesheet" />
    <script src="Design/js/bootstrap-3.1.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="row">                  
                   <div class="col-sm-4">
                        <div class="form-group">						    
                            <label>PAN Card Image</label>
                           <asp:Image ID="Image1" CssClass="img-responsive" Width="100px" Height="100px" runat="server" />
                            <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                            <asp:Button ID="Button1" runat="server" Text="PAN Card Upload" OnClick="Button1_Click" CssClass="btn btn-primary" />
                             
				        </div>
                       <div class="form-group">						    
                            <label>Adhar card Image</label>
                          <asp:Image ID="Image2" runat="server" CssClass="img-responsive" Width="100px" Height="100px" />
                            <asp:FileUpload ID="FileUpload2" CssClass="form-control" runat="server" />
                          <asp:Button ID="Button2" runat="server" Text="Adhar Card Upload" OnClick="Button2_Click" CssClass="btn btn-primary" />
				        </div>
                      

                   </div>
                   <div class="col-sm-4">
                        <div class="form-group">						    
                            <label>Passport Image</label>
                           <asp:Image ID="Image3" runat="server" CssClass="img-responsive" Width="100px" Height="100px" />
                            <asp:FileUpload ID="FileUpload3" CssClass="form-control" runat="server" />
                            <asp:Button ID="Button3" runat="server" Text="Passport Upload" OnClick="Button3_Click" CssClass="btn btn-primary" />
				        </div>

                       <div class="form-group">						    
                            <label>Driving Licence Image</label>
                           <asp:Image ID="Image4" runat="server" CssClass="img-responsive" Width="100px" Height="100px" />
                            <asp:FileUpload ID="FileUpload4" CssClass="form-control" runat="server" />
                           <asp:Button ID="Button4" runat="server" Text="DrivingLic Upload" OnClick="Button4_Click" CssClass="btn btn-primary" />
				        </div>

                       
                   </div>

              </div>
    </form>
</body>
</html>
