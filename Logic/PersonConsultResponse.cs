using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;


namespace Logic
{
    public class PersonConsultResponse
    {
        public List<Person> People { get; set; }
        
        public string Message { get; set; }
        
        public bool Error { get; set; }

        public PersonConsultResponse(string message)
        {
            Message = message;
            Error = true;
        }

        public PersonConsultResponse(List<Person> people)
        {
            People = people;
            Error = false;
        }
    }
}
