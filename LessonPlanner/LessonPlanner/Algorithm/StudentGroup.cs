using System;
using System.Collections.Generic;

namespace LessonPlanner
{
    public class StudentGroup : IEntity, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public List<CourseClass> CourseClasses { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
