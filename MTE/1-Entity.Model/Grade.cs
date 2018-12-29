using System;

namespace _1_Entity.Model
{
    public class Grade : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid ExamId { get; set; }

        public Student Student { get; set; }

        public Exam Exam { get; set; }

        public double Value { get; set; }

        public double FinalGrade { get; set; }
    }
}
