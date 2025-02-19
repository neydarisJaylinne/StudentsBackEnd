namespace SchoolApi.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public string Section { get; set; }
    }

}