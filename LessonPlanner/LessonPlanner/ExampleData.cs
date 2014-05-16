using System.Collections.Generic;
using System.Linq;

namespace LessonPlanner
{
    static class ExampleData
    {
        public static void FillExampleData(this Algorithm algorithm)
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

            algorithm.Classrooms = new List<Classroom>()
            {
                new Classroom(){Id = 1, IsLab = true, Size = 24, Name = "R3"},
                new Classroom(){Id = 2, IsLab = false, Size = 60, Name = "R7"},
            };

            algorithm.Courses = new List<Course>();
            for (int i = 1; i <= 8; ++i)
                algorithm.Courses.Add(new Course() { Id = i, Name = CourseNames[i - 1] });

            algorithm.Professors = new List<Professor>();
            for (int i = 1; i <= 13; ++i)
                algorithm.Professors.Add(new Professor() { Id = i, Name = FirstNames[i - 1] });

            algorithm.StudentGroups = new List<StudentGroup>()
            {
                new StudentGroup(){Id = 1, Name = "101", StudentCount = 19},
                new StudentGroup(){Id = 2, Name = "102", StudentCount = 19},
                new StudentGroup(){Id = 3, Name = "103", StudentCount = 19},
                new StudentGroup(){Id = 4, Name = "151", StudentCount = 19},
            };

            algorithm.CourseClasses = new List<CourseClass>()
            {
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 1), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 1), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3 || p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 9), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1).ToList(), LessonDuration = 3, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 9), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 2).ToList(), LessonDuration = 3, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 9), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3).ToList(), LessonDuration = 3, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 9), Course = algorithm.Courses.Find(p => p.Id == 1), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 4).ToList(), LessonDuration = 3, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 2), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3 || p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 2), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 3), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1).ToList(), LessonDuration = 2, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 3), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 2).ToList(), LessonDuration = 2, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 3), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3).ToList(), LessonDuration = 2, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 3), Course = algorithm.Courses.Find(p => p.Id == 2), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 4).ToList(), LessonDuration = 2, IsLab = true},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 4), Course = algorithm.Courses.Find(p => p.Id == 4), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3 || p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 4), Course = algorithm.Courses.Find(p => p.Id == 4), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3 || p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 4), Course = algorithm.Courses.Find(p => p.Id == 4), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 4), Course = algorithm.Courses.Find(p => p.Id == 4), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 5), Course = algorithm.Courses.Find(p => p.Id == 6), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2 || p.Id == 3).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 5), Course = algorithm.Courses.Find(p => p.Id == 6), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2 || p.Id == 3).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 7), Course = algorithm.Courses.Find(p => p.Id == 6), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2 || p.Id == 3).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 7), Course = algorithm.Courses.Find(p => p.Id == 5), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1 || p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 10), Course = algorithm.Courses.Find(p => p.Id == 5), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 8), Course = algorithm.Courses.Find(p => p.Id == 3), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 2).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 8), Course = algorithm.Courses.Find(p => p.Id == 3), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 3).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 12), Course = algorithm.Courses.Find(p => p.Id == 3), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 1).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 12), Course = algorithm.Courses.Find(p => p.Id == 3), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 11), Course = algorithm.Courses.Find(p => p.Id == 7), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 4).ToList(), LessonDuration = 2},
                new CourseClass(){Professor = algorithm.Professors.Find(p => p.Id == 13), Course = algorithm.Courses.Find(p => p.Id == 8), StudentGroups = algorithm.StudentGroups.Where(p => p.Id == 4).ToList(), LessonDuration = 2},
            };
        }
    }
}
