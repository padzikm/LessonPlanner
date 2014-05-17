using System.Collections.Generic;

namespace LessonPlanner
{
    class Configuration
    {
        // Parsed professors
        public Dictionary<int, Professor> Professors { get; set; }

        // Parsed student groups
        public Dictionary<int, StudentGroup> StudentGroups { get; set; }

        // Parsed courses
        public Dictionary<int, Course> Courses { get; set; }

        // Parsed rooms
        public Dictionary<int, Room> Rooms { get; set; }

        // Parsed classes
        public List<CourseClass> CourseClasses { get; set; }

        // Inidicate that configuration is not prsed yet
        public bool IsEmpty { get; set; }

        // Initialize data
        public Configuration()
        {
            IsEmpty = true;
        }

        // Parse file and store parsed object
        public void ParseFile(string fileName)
        {

        }

        // Returns number of parsed professors
        public int GetNumberOfProfessors()
        {
            return Professors.Count;
        }

        // Returns number of parsed student groups
        public int GetNumberOfStudentGroups()
        {
            return StudentGroups.Count;
        }

        // Returns number of parsed rooms
        public int GetNumberOfRooms()
        {
            return Rooms.Count;
        }

        // Returns number of parsed classes
        public int GetNumberOfCourseClasses()
        {
            return CourseClasses.Count;
        }

        // Returns number of parsed courses
        public int GetNumberOfCourses()
        {
            return Courses.Count;
        }

        // Returns pointer to professor with specified ID
        // If there is no professor with such ID method returns NULL
        public Professor GetProfessorById(int id)
        {
            return Professors.ContainsKey(id) ? Professors[id] : null;
        }

        // Returns pointer to course with specified ID
        // If there is no course with such ID method returns NULL
        public Course GetCourseById(int id)
        {
            return Courses.ContainsKey(id) ? Courses[id] : null;
        }

        // Returns pointer to student group with specified ID
        // If there is no student group with such ID method returns NULL
        public StudentGroup GetStudentsGroupById(int id)
        {
            return StudentGroups.ContainsKey(id) ? StudentGroups[id] : null;
        }

        // Returns pointer to room with specified ID
        // If there is no room with such ID method returns NULL
        public Room GetRoomById(int id)
        {
            return Rooms.ContainsKey(id) ? Rooms[id] : null;
        }
    }
}
