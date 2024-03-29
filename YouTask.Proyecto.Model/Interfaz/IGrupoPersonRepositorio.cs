﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTask.Proyecto.Model.Entidades;

namespace YouTask.Proyecto.Model.Interfaz
{
    public interface IGrupoPersonRepositorio
    {
        bool AgregarGrupoPerson(GrupoPersonEntidades grupoPersonEntidades);
        bool EliminarGrupoPerson(int IDGrupo, int IDPerson);
    }
}
