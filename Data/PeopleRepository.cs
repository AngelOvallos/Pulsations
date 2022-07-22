using Entity;

namespace Data
{
    public class PeopleRepository
    {
        public string route = @"ListPeople.txt";

        public void Save(Person person)
        {
            using StreamWriter writer = new StreamWriter(route, true);
                writer.WriteLine($"{person.Id};{person.Name};{person.Lastname};{person.Age};{person.Genre};{person.Pulsation}");
        }
        public List<Person> Consult()
        {
            List<Person> people = new();
            StreamReader reader = new(route);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                Person person = new()
                {
                    Id = data[0],
                    Name = data[1],
                    Lastname = data[2],
                    Age = int.Parse(data[3]),
                    Genre = data[4],
                    Pulsation = decimal.Parse(data[5])
                };
                people.Add(person);
            }
            reader.Close();
            return people;
        }

        public Person Search(string id)
        {
            bool result = File.Exists(route);
            if(result == true)
            {
                List<Person> people = Consult();
                foreach (var item in people)
                {
                    if (item.Id.Equals(id))
                    {
                        return item;
                    }
                }
            }
            return null;

        }
    }
}