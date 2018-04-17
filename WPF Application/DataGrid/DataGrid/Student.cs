using System.Collections.ObjectModel;

namespace DataGrid
{
    public class Student
    {
        public int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isSoccerPlayer;
        public bool IsSoccerPlayer
        {
            get { return isSoccerPlayer; }
            set { isSoccerPlayer = value; }
        }

        public Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public static ObservableCollection<Student> GetStudent()
        {
            var studentColl = new ObservableCollection<Student>();
            studentColl.Add(new Student { Id = 001, Name = "John", IsSoccerPlayer = true, Gender = Gender.Male });
            studentColl.Add(new Student { Id = 002, Name = "Johny", IsSoccerPlayer = true, Gender = Gender.Male });
            studentColl.Add(new Student { Id = 003, Name = "Tim",  Gender = Gender.Male });
            studentColl.Add(new Student { Id = 004, Name = "Lucky", IsSoccerPlayer = true, Gender = Gender.Female });
            studentColl.Add(new Student { Id = 005, Name = "Lucy",  Gender = Gender.Female });

            return studentColl;
        }
    }
    public enum Gender
    {
        Male,
        Female,
        Unknow
    }
}
