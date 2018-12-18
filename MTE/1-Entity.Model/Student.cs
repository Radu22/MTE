using System;

namespace _1_Entity.Model
{
    public class Student : BaseEntity
    {
        public Guid ExamId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsPresent { get; set; }

        public Exam Exam { get; set; }
    }
}
