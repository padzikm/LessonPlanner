namespace LessonPlanner
{
    class Room : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public bool IsLab { get; set; }
    }
}
