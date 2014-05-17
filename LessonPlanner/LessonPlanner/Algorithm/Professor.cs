using System.Collections.Generic;

namespace LessonPlanner
{
    public class Professor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CourseClass> CourseClasses { get; set; } 
    }
}
