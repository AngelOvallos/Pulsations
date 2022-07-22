namespace Entity
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string id, string name, string lastName, int age, string genre)
        {
            Id = id;
            Name = name;
            Lastname = lastName;
            Age = age;
            Genre = genre;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Genre { get; set; }

        public int Age { get; set; }

        public decimal Pulsation { get; set; }

        public void CalculatePulsation()
        {
            if (Genre.Equals("F") || Genre.Equals("f")) 
            {
                Pulsation = (220 - Age) / 10;
            } 
            else 
            {
                Pulsation = (210 - Age) / 10;
            }
        } 
    }
}