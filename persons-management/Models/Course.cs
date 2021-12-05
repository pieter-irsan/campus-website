namespace persons_management.Models
{
    public class Course
    {
        private int courseID;
        private string courseCode;
        private string courseName;
        private int credit;

        public int CourseID
        {
            get { return courseID; }
            set { this.courseID = value; }
        }
        public string CourseCode
        {
            get { return courseCode; }
            set { this.courseCode = value; }
        }
        public string CourseName
        {
            get { return courseName; }
            set { this.courseName = value; }
        }
        public int Credit
        {
            get { return credit; }
            set { this.credit = value; }
        }
    }
}