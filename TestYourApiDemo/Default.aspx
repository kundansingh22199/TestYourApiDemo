<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestYourApiDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-sm-12 mb-4 mt-4">
                    <div class="card border-4 border-primary">
                        <div class="card-header bg-primary">Add User Field</div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    User Name
                                    <asp:TextBox runat="server" ID="TxtName" CssClass="form-control" placeholder="Enter User Name..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    Mobile No
                                    <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile No..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    Email Id
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Enter Email ID..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    Address
                                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    City
                                    <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" placeholder="Enter City Name..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    Pin Code
                                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" placeholder="Enter Pin Code..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-4 mt-2">
                                    <asp:Button runat="server" ID="btnInsert" Text="Add" CssClass="btn btn-primary" OnClick="btnInsert_Click" />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 mb-5">
                    <div class="card  border-4 border-primary">
                        <div class="card-header bg-primary">Search By Mobile No</div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtSearchMobile" placeholder="Enter Mobile No..!!"></asp:TextBox>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div clas="col-sm-12 mb-5">
                    <div class="card border-4 border-primary">
                        <div class="card-header bg-primary">Show User Field</div>
                        <div class="card-body">
                            <div class="row">
                                <div class="container-fluid" style="overflow:scroll; width:100%; height:350px"
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageIndex="5" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="120%">
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="MOBILE NO" HeaderStyle-Height="50px">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMobileNo" runet="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtMobile" ReadOnly="true" runet="server" Text='<%# Eval("MobileNo") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NAME">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblName" runet="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtName" runet="server" Text='<%# Eval("Name") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EMAIL">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblEmail" runet="server" Text='<%# Eval("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtEmail" runet="server" Text='<%# Eval("Email") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ADDRESS">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAddress" runet="server" Text='<%# Eval("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtAddress" runet="server" Text='<%# Eval("Address") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CITY">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCity" runet="server" Text='<%# Eval("City") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtCity" runet="server" Text='<%# Eval("City") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PIN CODE">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPinCode" runet="server" Text='<%# Eval("PinCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPincode" runet="server" Text='<%# Eval("PinCode") %>' CssClass="form-control"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MANAGE">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="btnEdit" CommandName="Edit" Text="EDIT"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:LinkButton runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this Service?');" ID="btnDelete" CommandName="Delete" Text="DELETE"></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnUpdate" CommandName="Update" Text="UPDATE"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:LinkButton runat="server" CssClass="btn btn-secondary" ID="btnCancle" CommandName="Cancel" Text="CANCEL"></asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#000065" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="AlertModel" class="modal fade" role="dialog">
                <div class="modal-dialog modal-sm ">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header bg-danger">
                            <h4 class="modal-title text-left" style="text-align: left; position: relative">Aletr Model</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <p class="text-center"><i class="fa fa-times-circle fa-xl text-danger" aria-hidden="true" style="font-size: 30px"></i></p>
                            <h6 runat="server" id="msgerror" class="text-danger"></h6>
                            <h6 runat="server" id="msgerror1" class="text-warning"></h6>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <div id="ConformationModel" class="modal fade" role="dialog">
                <div class="modal-dialog modal-sm ">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header bg-success">
                            <h4 class="modal-title text-left" style="text-align: left; position: relative">Conformation Model</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <p class="text-center">
                                <i class="fa fa-check-circle fa-xl text-success" aria-hidden="true" style="font-size: 30px"></i>
                            </p>
                            <div runat="server" id="msgsuccess" class="text-success text-center"></div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script>
            function ShowPopup() {
                debugger;
                $("#AlertModel").modal("show");
                $("#AlertModel").css('background', 'inherit');
            }
        </script>
    </form>

</body>

</html>
