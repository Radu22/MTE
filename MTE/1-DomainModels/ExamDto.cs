using System;
using System.Collections.Generic;

namespace _1_DomainModels
{
    public class ExamDto
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartDate { get; set; }

        public double Time { get; set; }

        public List<StudentDto> Students { get; set; }
    }
}
