﻿using System;

namespace _1_Entity.Model
{
    public class Professor : BaseEntity
    {
        public string Firstname { get; set; }

        public string Subject { get; set; }

        public Exam Exam { get; set; }
    }
}
