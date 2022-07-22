using Data;
using Entity;
using System;

namespace Logic
{
    public class PersonService
    {
        readonly PeopleRepository peopleRepository;
        public PersonService()
        {
            peopleRepository = new PeopleRepository();
        }

        public string Save(Person person)
        {
            try
            {
                if (peopleRepository.Search(person.Id) == null)
                {
                    peopleRepository.Save(person);
                    return "Se han guardado los datos correctamente.";
                }
                return $"No fue posible Guardar la información, porque ya existe un registro con la identificaion  {person.Id}.";
            }
            catch(Exception e)
            {
                return "Error al guardar: " + e.Message;
            }
        }
        
        public (String message, Person person) Search(String id)
        {
            try
            {
                var person = peopleRepository.Search(id);
                if (person == null)
                {
                    return ("No se encontró un registro con la identificacion solicitada",person);
                }
                return ($" Se encuentra registrado{id}", person);
            }
            catch( Exception e)
            {
                return ($"Error inesperado al buscar: {e.Message}", null);
            }
        }

        public PersonConsultResponse Consult()
        {
            try
            {
                return new PersonConsultResponse(peopleRepository.Consult());
            }
            catch(Exception e)
            {
                return new PersonConsultResponse($"Error inesperado al Consultar: {e.Message}");
            }
        }
    }
}