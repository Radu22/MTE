﻿using System;

namespace _1_DomainModels
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}