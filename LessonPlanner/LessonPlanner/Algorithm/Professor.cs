using System;
using System.Collections.Generic;

namespace LessonPlanner
{
    public class Professor : IEntity, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseClass> CourseClasses { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
