using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Entities;
using NodaTime;

namespace School.Entity
{
    public class Student : Person, ICreated, IUpdated
    {

        public int StudentId { get; set; }


        public ICollection<Grade> Grades { get; set; }


        public Instant Created { get; set; }
        public Instant Updated { get; set; }

    }

    public class Grade : ICreated, IUpdated
    {
        public int GradeId { get; set; }

        public int StudentId { get; set; }

        public GradeType Value { get; set; }

        public string Course { get; set; }

        public int GradingTeacherId { get; set; }
        public Teacher GradingTeacher { get; set; }

        public Instant Created { get; set; }
        public Instant Updated { get; set; }
    }

    public enum GradeType
    {
        NotSet = 0,
        Fail = 1,
        E = 2,
        D = 3,
        C = 4,
        B = 5,
        A = 6,
    }
}
