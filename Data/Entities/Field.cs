﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Data.Entities
{
    public class Field
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public TypeName FieldType { get; set; }
    }
    public enum TypeName
    {
        digit= 0,
        line,
        text,
        date,
        boolean,
    }
}
