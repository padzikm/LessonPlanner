using System.Collections.Generic;
using System.Linq;

namespace LessonPlanner
{
    public class CourseClass
    {
        public Course Course { get; set; }
        public Professor Professor { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public int StudentCount
        {
            get
            {
                int sum = 0;
                foreach (var studentGroup in StudentGroups)
                    sum += studentGroup.StudentCount;
                return sum;
            }
        }
        public int LessonDuration { get; set; }
        public bool IsLabRequired { get; set; }

        // Returns TRUE if another class has one or overlapping student groups.
        public bool GroupsOverlap(CourseClass courseClass)
        {
            var commonStudentGroups = StudentGroups.Intersect(courseClass.StudentGroups, new Helper<StudentGroup>());

            return commonStudentGroups.Count() > 0;
        }

        // Returns TRUE if another class has same professor.
        public bool ProfessorOverlaps(CourseClass courseClass)
        {
            return Professor.Id == courseClass.Professor.Id;
        }
    }
}
