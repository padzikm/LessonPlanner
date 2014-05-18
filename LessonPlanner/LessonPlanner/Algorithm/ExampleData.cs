using System.Collections.Generic;
using System.Linq;

namespace LessonPlanner
{
    static class ExampleData
    {
        public static void FillExampleData(this Configuration configuration)
        {
            List<string> FirstNames = new List<string>()
            {
                "Victor",
                "Red",
                "Philip",
                "Marry",
                "Don",
                "Mark",
                "Peter",
                "John",
                "Ben",
                "Mike",
                "Steve",
                "Ann",
                "Alex",
            };

            List<string> CourseNames = new List<string>()
            {
                "Introduction to Programming",
                "Introduction to Computer Architecture",
                "Business Applications",
                "English",
                "Discrete Mathematic I",
                "Linear Algebra",
                "Introduction to Information Technology I",
                "System Administration and Maintenance I",
            };

            configuration.Rooms = new Dictionary<int, Room>()
            {
                {0, new Room() {Id = 0, IsLab = true, SeatCount = 24, Name = "R3"}},
                {1, new Room(){Id = 1, IsLab = false, SeatCount = 60, Name = "R7"}},
            };

            configuration.Courses = new Dictionary<int, Course>();
            for (int i = 1; i <= 8; ++i)
                configuration.Courses.Add(i, new Course() { Id = i, Name = CourseNames[i - 1] });

            configuration.Professors = new Dictionary<int, Professor>();
            for (int i = 1; i <= 13; ++i)
                configuration.Professors.Add(i, new Professor() { Id = i, Name = FirstNames[i - 1] });

            configuration.StudentGroups = new Dictionary<int, StudentGroup>()
            {
                {1, new StudentGroup(){Id = 1, Name = "101", StudentCount = 19}},
                {2, new StudentGroup(){Id = 2, Name = "102", StudentCount = 19}},
                {3, new StudentGroup(){Id = 3, Name = "103", StudentCount = 19}},
                {4, new StudentGroup(){Id = 4, Name = "151", StudentCount = 19}},
            };

            configuration.CourseClasses = new List<CourseClass>()
            {
                new CourseClass(){Professor = configuration.Professors[1], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[1], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3 || p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[9], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1).Select(p => p.Value).ToList(), LessonDuration = 3, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[9], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 3, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[9], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 3, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[9], Course = configuration.Courses[1], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 3, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[2], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3 || p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[2], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[3], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1).Select(p => p.Value).ToList(), LessonDuration = 2, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[3], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[3], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[3], Course = configuration.Courses[2], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2, IsLabRequired = true},
                new CourseClass(){Professor = configuration.Professors[4], Course = configuration.Courses[4], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3 || p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[4], Course = configuration.Courses[4], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3 || p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[4], Course = configuration.Courses[4], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[4], Course = configuration.Courses[4], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[5], Course = configuration.Courses[6], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2 || p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[5], Course = configuration.Courses[6], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2 || p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[7], Course = configuration.Courses[6], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2 || p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[7], Course = configuration.Courses[5], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1 || p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[10], Course = configuration.Courses[5], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[8], Course = configuration.Courses[3], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 2).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[8], Course = configuration.Courses[3], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 3).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[12], Course = configuration.Courses[3], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 1).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[12], Course = configuration.Courses[3], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[11], Course = configuration.Courses[7], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = configuration.Professors[13], Course = configuration.Courses[8], StudentGroups = configuration.StudentGroups.Where(p => p.Key == 4).Select(p => p.Value).ToList(), LessonDuration = 2},
            };
        }
    }
}
