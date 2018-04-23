namespace Firebase.News.Models
{
    public class DinosaurDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public DinosaurDto()
        {
        }
        public DinosaurDto(string id,string name, string gender, int age)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}