using System;

namespace LessonPlanner
{
    class Room : IEntity, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeatCount { get; set; }
        public bool IsLab { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
