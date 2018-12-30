using System;
using System.Collections.Generic;

namespace _1_Entity.Model
{
    public class Exam : BaseEntity
    {
        public string Subject { get; set; }

        public Professor Professor { get; set; }

        public Guid ProfessorId { get; set; }

        public DateTime StartDate { get; set; }

        public double Time { get; set; }

        public List<Student> Students { get; set; }
    }
}
