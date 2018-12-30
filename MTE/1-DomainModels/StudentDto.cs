using System;
using System.Collections.Generic;

namespace _1_DomainModels
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public Guid ExamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public ExamDto Exam { get; set; }

        public List<GradeDto> Grades { get; set; }

        public bool IsPresent { get; set; }
    }
}
