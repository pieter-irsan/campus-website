namespace persons_management.Models
{
    public class Student
    {
        private int studentID;
        private string studentName;
        private string schoolOrigin;
        private string major;

        public int StudentID
        {
            get { return studentID; }
            set { this.studentID = value; }
        }
        public string StudentName
        {
            get { return studentName; }
            set { this.studentName = value; }
        }
        public string SchoolOrigin
        {
            get { return schoolOrigin; }
            set { this.schoolOrigin = value; }
        }
        public string Major
        {
            get { return major; }
            set { this.major = value; }
        }
    }
}