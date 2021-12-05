function ToggleDiv(cmd)
{
    if (cmd == "showStudent") {
        document.getElementById('btnStudentClose').style.display = 'block';
        document.getElementById('studentShow').style.display = 'block';
        document.getElementById('studentHide').style.display = 'none';
    }
    else if (cmd == "hideStudent") {
        document.getElementById('btnStudentClose').style.display = 'none';
        document.getElementById('studentShow').style.display = 'none';
        document.getElementById('studentHide').style.display = 'block';
    }
    else if (cmd == "showFaculty") {
        document.getElementById('btnFacultyClose').style.display = 'block';
        document.getElementById('facultyShow').style.display = 'block';
        document.getElementById('facultyHide').style.display = 'none';
    }
    else if (cmd == "hideFaculty") {
        document.getElementById('btnFacultyClose').style.display = 'none';
        document.getElementById('facultyShow').style.display = 'none';
        document.getElementById('facultyHide').style.display = 'block';
    }
    else if (cmd == "showCourse") {
        document.getElementById('btnCourseClose').style.display = 'block';
        document.getElementById('courseShow').style.display = 'block';
        document.getElementById('courseHide').style.display = 'none';
    }
    else if (cmd == "hideCourse") {
        document.getElementById('btnCourseClose').style.display = 'none';
        document.getElementById('courseShow').style.display = 'none';
        document.getElementById('courseHide').style.display = 'block';
    }
    else if (cmd == "showMajor") {
        document.getElementById('btnMajorClose').style.display = 'block';
        document.getElementById('majorShow').style.display = 'block';
        document.getElementById('majorHide').style.display = 'none';
    }
    else if (cmd == "hideMajor") {
        document.getElementById('btnMajorClose').style.display = 'none';
        document.getElementById('majorShow').style.display = 'none';
        document.getElementById('majorHide').style.display = 'block';
    }
}