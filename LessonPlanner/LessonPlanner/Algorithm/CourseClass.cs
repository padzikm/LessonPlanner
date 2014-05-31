using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonPlanner
{
    public class CourseClass : ICloneable
    {
        public Course Course { get; set; }
        public Professor Professor { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }
        public int LessonDuration { get; set; }
        public bool IsLabRequired { get; set; }
        public int SeatCount
        {
            get
            {
                int sum = 0;
                foreach (var studentGroup in StudentGroups)
                    sum += studentGroup.StudentCount;
                return sum;
            }
        }

        // Returns TRUE if another class has one or overlapping student groups.
        public bool GroupsOverlap(CourseClass courseClass)
        {
            for (int i = 0; i < StudentGroups.Count; i++)
                for (int j = 0; j < courseClass.StudentGroups.Count; ++j)
                    if (StudentGroups[i].Id == courseClass.StudentGroups[j].Id)
                        return true;

            return false;
        }

        // Returns TRUE if another class has same professor.
        public bool ProfessorOverlaps(CourseClass courseClass)
        {
            return Professor.Id == courseClass.Professor.Id;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
