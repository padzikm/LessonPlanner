using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonPlanner
{
    class CourseClass
    {
        public Course Course { get; set; }
        public Professor Professor { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public int LessonDuration { get; set; }
        public bool IsLab { get; set; }
    }
}
