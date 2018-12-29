using System;

namespace _1_DomainModels
{
    public class ExamDto
    {
        public Guid Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartDate { get; set; }

        public double Time { get; set; }
    }
}
