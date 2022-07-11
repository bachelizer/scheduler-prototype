namespace backend.Model
{
    public class OfferedSubject
    {
        public int schedule_id { get; set; }
        public int offered_id { get; set; }
        public int subject_id { get; set; }
        public string subject { get; set; }
        public int course_id { get; set; }
        public string course_title { get; set; }
        public int year_level { get; set; }
        public string section { get; set; }
        public string Class { get; set; }
        public string days { get; set; }
        public int instructor_id { get; set; }
        public string instructor_name { get; set; }
        public int room_id { get; set; }
        public string time_in { get; set; }
        public string time_out { get; set; }
        public string room { get; set; }
    }
}