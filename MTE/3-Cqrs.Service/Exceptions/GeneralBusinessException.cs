﻿using System;

namespace _3_Cqrs.Service.Exceptions
{
    public class GeneralBusinessException : Exception
    {
        public GeneralBusinessException(string message)
            : base(message)
        {
        }
    }
}
