<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faculty.aspx.cs" Inherits="persons_management.faculty"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="App_Theme/css/awesome.css" />
    <link rel="stylesheet" type="text/css" href="App_Theme/css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500" />
    <title>Campus Information System</title>
</head>
<body>
    <nav class="navbar navbar-light bg-light justify-content-between">
        <a class="navbar-brand" href="index.aspx">
            <img src="App_Theme/images/logo.png" width="30" height="30" class="d-inline-block align-top" alt="logo" />
            Campus Website
        </a>
        <a class="btn btn-danger btn-sm" href="index.aspx">Log out</a>
    </nav>
    <div class="container">
        <form id="formFaculty" runat="server">
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center">
                    <h1>Campus Information System</h1>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-2 col-md-2 col-sm-12">
                    <a class="btn btn-primary btn-sm btn-block" href="student.aspx">New Student</a>
                </div>
                <div class="col-md-2 col-sm-12">
                    <a class="btn btn-primary btn-sm btn-block" href="faculty.aspx">Faculty</a>
                </div>
                <div class="col-md-2 col-sm-12">
                    <a class="btn btn-primary btn-sm btn-block" href="course.aspx">Course</a>
                </div>
                <div class="col-md-2 col-sm-12">
                    <a class="btn btn-primary btn-sm btn-block" href="major.aspx">Major</a>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-10 col-sm-12">
                    <h4 id="operationH4" runat="server"></h4>   <%--"You will add/update person" text--%>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4 col-sm-12">
                    <label>Faculty Name</label>
                    <asp:TextBox CssClass="form-control" ID="txtFacultyName" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-12">
                    <label>Position</label>
                    <asp:TextBox CssClass="form-control" ID="txtPosition" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-4 col-sm-12">
                    <label>Status</label>
                    <asp:TextBox CssClass="form-control" ID="txtStatus" runat="server"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-3 col-md-6 col-sm-12">
                    <asp:Button CssClass="btn btn-success btn-md btn-block" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center ">
                    <h2>Faculty Database</h2>
                </div>
                <div style="margin:auto;">
                    <asp:GridView ID="tblFaculty" CssClass="table table-responsive table-bordered table-hover" runat="server"
                        AllowCustomPaging="true"
                        AllowPaging="true"
                        PagerStyle-CssClass="pagination"
                        AutoGenerateColumns="false"
                        OnRowCommand="tblFaculty_RowCommand"
                        OnRowDeleting="tblFaculty_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                            <asp:BoundField DataField="Position" HeaderText="Position" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Update">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" CommandName="update" CommandArgument='<%#Eval("FacultyID") %>' ImageUrl="~/App_Theme/images/edit.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("FacultyID") %>' ImageUrl="~/App_Theme/images/trash.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
