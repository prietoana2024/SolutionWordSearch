using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.MODELS;

namespace WordSearch.DLL.Servicios.Contrato
{
    public interface ICaracteresService
    {
        Task<List<Caractere>> Lista();
        Task<Caractere> Crear(Caractere modelo);
        Task<bool> Editar(Caractere modelo);
        Task<bool> Eliminar(int id);
    }
}
