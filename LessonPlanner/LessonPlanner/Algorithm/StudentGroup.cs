using System.Collections.Generic;

namespace LessonPlanner
{
    class StudentGroup : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public List<CourseClass> CourseClasses { get; set; }
    }
}
