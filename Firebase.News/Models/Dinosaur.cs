namespace Firebase.News.Models
{
    public class Dinosaur
    {
        public static Dinosaur TRex => new Dinosaur("T-Rex", "Male", 2);
        public static Dinosaur Velociraptor => new Dinosaur("Velociraptor", "Female", 21);
        public static Dinosaur Spinosaurus => new Dinosaur("Spinosaurus", "Male", 28);
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Dinosaur(string name, string gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}