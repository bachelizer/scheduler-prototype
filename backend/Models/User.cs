namespace backend.Model
{
    public class User
    {
        public int instructor_id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string designation { get; set; }
        public string role { get; set; }
        public string fkcourseidPC { get; set; }
    }
}