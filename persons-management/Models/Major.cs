namespace persons_management.Models
{
    public class Major
    {
        private int majorID;
        private string majorCode;
        private string majorName;
        private string program;

        public int MajorID
        {
            get { return majorID; }
            set { this.majorID = value; }
        }
        public string MajorCode
        {
            get { return majorCode; }
            set { this.majorCode = value; }
        }
        public string MajorName
        {
            get { return majorName; }
            set { this.majorName = value; }
        }
        public string Program
        {
            get { return program; }
            set { this.program = value; }
        }
    }
}