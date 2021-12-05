<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="persons_management.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="stylesheet" type="text/css" href="App_Theme/css/stylesheet.css" />--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="App_Theme/css/awesome.css" />
    <link rel="stylesheet" type="text/css" href="App_Theme/css/font-awesome.css" />
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500" />
    <script src="App_Theme/css/jquery.min.js"></script>
    <script src="App_Theme/css/bootstrap.min.js"></script>
    <script src="App_Theme/css/script.js"></script>
    <title>Campus Website</title>
</head>
<body style="background-color:beige">
    <nav class="navbar navbar-light bg-light justify-content-between">
        <a class="navbar-brand" href="index.aspx">
            <img src="App_Theme/images/logo.png" width="30" height="30" class="d-inline-block align-center" alt="logo" />
            Campus Website
        </a>
        <a class="btn btn-info btn-sm" href="login.aspx">Log in</a>
    </nav>

    <div class="container" style="padding-bottom:5%">
        <form id="formIndex" runat="server">
            <div class="row">
                <div class="col-md-offset-2 col-md-8 text-center">
                    <h1>Welcome to Campus Website</h1>
                </div>
            </div>
            <style>
                .carousel-inner > .item > img {width:640px; height:360px;}
            </style>
            <div id="carousel" class="carousel slide" data-ride="carousel">
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img class="d-block center-block" src="App_Theme/images/img1.jpg" alt="First slide"  />
                </div>
                <div class="carousel-item">
                  <img class="d-block center-block" src="App_Theme/images/img2.jpg" alt="Second slide" />
                </div>
                <div class="carousel-item">
                  <img class="d-block center-block" src="App_Theme/images/img3.jpg" alt="Third slide" />
                </div>
              </div>
            </div>
            <br />
            <div class="text-center">
                <h2>List of New Students</h2>
                <p>Congratulations to the new students on your acceptance to this campus! 
                    Thank you for entrusting us on giving you further education.
                    <br />
                    Below are the list of students and their majors that are enrolling in this year's academic term.
                </p>
            </div>
            <div id="studentSection" class="row">
                <asp:Button ID="btnStudent" class="col-md-offset-4 col-md-4 btn btn-primary btn-sm btn-block" 
                    runat="server" Text="List of New Students" OnClientClick="ToggleDiv('showStudent');return false;" />
                <asp:Button ID="btnStudentClose" class="col-md-offset-4 col-md-4 btn btn-warning btn-sm btn-block" 
                    runat="server" Text="Close Table" OnClientClick="ToggleDiv('hideStudent');return false;" style="display: none;" />
                <br />
                <div id="studentShow" style="display:none; margin:auto;">
                    <br />
                    <asp:GridView ID="tblStudent" CssClass="table table-responsive table-bordered table-hover" runat="server"
                        AllowCustomPaging="true" AllowPaging="true" PagerStyle-CssClass="pagination" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="StudentID" HeaderText="ID" />
                            <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                            <asp:BoundField DataField="SchoolOrigin" HeaderText="School Origin" />
                            <asp:BoundField DataField="Major" HeaderText="Major" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="studentHide" style="display: none;"></div>
            </div>
            <br />
            <div class="text-center">
                <h2>Course Table</h2>
                <p>This year's academic term will start next week. 
                    Below are the introductory courses that each student are going to take
                </p>
            </div>
            <div id="courseSection" class="row">
                <asp:Button ID="btnCourse" class="col-md-offset-4 col-md-4 btn btn-primary btn-sm btn-block" 
                    runat="server" Text="Course Table" OnClientClick="ToggleDiv('showCourse');return false;" />
                <asp:Button ID="btnCourseClose" class="col-md-offset-4 col-md-4 btn btn-warning btn-sm btn-block" 
                    runat="server" Text="Close Table" OnClientClick="ToggleDiv('hideCourse');return false;" style="display: none;" />
                <br />
                <div id="courseShow" style="display:none; margin:auto;">
                    <br />
                    <asp:GridView ID="tblCourse" CssClass="table table-responsive table-bordered table-hover" runat="server"
                        AllowCustomPaging="true" AllowPaging="true" PagerStyle-CssClass="pagination" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                            <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                            <asp:BoundField DataField="Credit" HeaderText="Credit" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="courseHide" style="display: none;"></div>
            </div>
            <br />
            <div class="text-center">
                <h2>Academic Majors</h2>
                <p>Our campus provide you with a range of academic majors to choose from. 
                    <br />We currently have three programs and six academic majors for students to choose from, 
                    each with their own promising career prospects.
                </p>
            </div>
            <div id="majorSection" class="row">
                <asp:Button ID="btnMajor" class="col-md-offset-4 col-md-4 btn btn-primary btn-sm btn-block" 
                    runat="server" Text="Available Majors" OnClientClick="ToggleDiv('showMajor');return false;" />
                <asp:Button ID="btnMajorClose" class="col-md-offset-4 col-md-4 btn btn-warning btn-sm btn-block" 
                    runat="server" Text="Close Table" OnClientClick="ToggleDiv('hideMajor');return false;" style="display: none;" />
                <br />
                <div id="majorShow" style="display:none; margin:auto;">
                    <br />
                    <asp:GridView ID="tblMajor" CssClass="table table-responsive table-bordered table-hover" runat="server"
                        AllowCustomPaging="true" AllowPaging="true" PagerStyle-CssClass="pagination" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="MajorCode" HeaderText="Major Code" />
                            <asp:BoundField DataField="MajorName" HeaderText="Major Name" />
                            <asp:BoundField DataField="Program" HeaderText="Program" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="majorHide" style="display: none;"></div>
            </div>
            <br />
            <div class="text-center">
                <h2>Our Faculty</h2>
                <p>Our faculty consists of trained and educated professionals, with active backgrounds in the industry and academia. 
                    <br />They will surely provide students who aspire to make an impact with the tools and knowledge
                    needed to compete in the outside world, especially in the industry.
                </p>
            </div>
            <div id="facultySection" class="row">
                <asp:Button ID="btnFaculty" class="col-md-offset-4 col-md-4 btn btn-primary btn-sm btn-block" 
                    runat="server" Text="Our Faculty" OnClientClick="ToggleDiv('showFaculty');return false;" />
                <asp:Button ID="btnFacultyClose" class="col-md-offset-4 col-md-4 btn btn-warning btn-sm btn-block" 
                    runat="server" Text="Close Table" OnClientClick="ToggleDiv('hideFaculty');return false;" style="display: none;" />
                <br />
                <div id="facultyShow" style="display:none; margin:auto;">
                    <br />
                    <asp:GridView ID="tblFaculty" CssClass="table table-responsive table-bordered table-hover" runat="server"
                        AllowCustomPaging="true" AllowPaging="true" PagerStyle-CssClass="pagination" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="FacultyName" HeaderText="Faculty Name" />
                            <asp:BoundField DataField="Position" HeaderText="Position" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="facultyHide" style="display: none;"></div>
            </div>
        </form>
    </div>
</body>
</html>
