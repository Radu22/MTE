﻿using System;
using _1_DomainModels;
using _3_Cqrs.Service.CommandContracts;

namespace _3_Cqrs.Service.Command
{
    public class AddGradeCommand : ICommand
    {
        public AddGradeCommand(GradeDto grade, Guid studentId)
        {
            Grade = grade;
            StudentId = studentId;
        }

        public GradeDto Grade { get; set; }

        public Guid StudentId { get; set; }
    }
}
