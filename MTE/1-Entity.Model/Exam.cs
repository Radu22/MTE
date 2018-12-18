using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Entity.Model
{
    public class Exam : BaseEntity
    {
        public IList<Student> Students { get; set; }
        
        public string Subject { get; set; }

        public DateTime StartDate { get; set; }

        public double Time { get; set; }
    }
}
