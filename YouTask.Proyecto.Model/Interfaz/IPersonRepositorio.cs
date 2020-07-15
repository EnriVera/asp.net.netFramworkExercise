using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;

namespace YouTask.Proyecto.Model.Interfaz
{
    public interface IPersonRepositorio
    {
        List<PersonEntidades> GetPerson();
        PersonEntidades GetPersonID(int id);
        PersonEntidades GetPersonEmailPaswork(string email, string passwork);
        PersonEntidades PostPerson(PersonEntidades salaEntidad);
        PersonEntidades PutPerson(PersonEntidades salaEntidad);
        PersonEntidades DeletePerson(int id);
    }
}
