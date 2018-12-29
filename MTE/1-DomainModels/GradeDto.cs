using System;

namespace _1_DomainModels
{
    public class GradeDto
    {
        public Guid StudentId { get; set; }

        public Guid ExamId { get; set; }

        public StudentDto Student { get; set; }

        public ExamDto Exam { get; set; }

        public double Value { get; set; }

        public double FinalGrade { get; set; }
    }
}
