using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Logic
{
    public class PersonSearchResponse
    {
        public Person Person { get; set; }  

        public string Message { get; set; }

        public bool IsError { get; set; }

        public PersonSearchResponse(Person person)
        {
            Person = person;
            IsError = false;
        }

        public PersonSearchResponse(string message)
        {
            Message = message;  
            IsError = true;
        }
    }
}
