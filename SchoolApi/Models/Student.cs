﻿namespace SchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName{ get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }

}