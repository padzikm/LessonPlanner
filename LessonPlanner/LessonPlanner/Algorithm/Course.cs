using System;

namespace LessonPlanner
{
    public class Course : IEntity, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
