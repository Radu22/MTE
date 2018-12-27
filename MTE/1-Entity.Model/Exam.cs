using System;
using System.Collections.Generic;

namespace _1_Entity.Model
{
    public class Exam : BaseEntity
    {
        public string Subject { get; set; }

        public DateTime StartDate { get; set; }

        public double Time { get; set; }

        public List<Student> Students { get; set; }
    }
}
