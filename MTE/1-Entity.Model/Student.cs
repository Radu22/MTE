using System;
using System.Collections.Generic;

namespace _1_Entity.Model
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Exam Exam { get; set; }

        public Guid ExamId { get; set; }

        //public List<Grade> Grades { get; set; }
    }
}
