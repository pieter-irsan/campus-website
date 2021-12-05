namespace persons_management.Models
{
    public class Faculty
    {
        private int facultyID;
        private string facultyName;
        private string position;
        private string status;

        public int FacultyID
        {
            get { return facultyID; }
            set { this.facultyID = value; }
        }
        public string FacultyName
        {
            get { return facultyName; }
            set { this.facultyName = value; }
        }
        public string Position
        {
            get { return position; }
            set { this.position = value; }
        }
        public string Status
        {
            get { return status; }
            set { this.status = value; }
        }
    }
}