namespace SchoolApi.Models
{
    public class StudentGradeCreateDto
    {
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public string Section { get; set; }
    }
}
