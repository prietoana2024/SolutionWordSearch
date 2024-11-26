using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordSearch.DAL.Repositorios.Contrato;
using WordSearch.DLL.Servicios.Contrato;
using WordSearch.MODELS;

namespace WordSearch.DLL.Servicios
{
    public class CaracteresService:ICaracteresService
    {
        private readonly IGenericRepository<Caractere> _caracteresRepositorio;

        public CaracteresService(IGenericRepository<Caractere> caracteresRepositorio)
        {
            _caracteresRepositorio = caracteresRepositorio;
        }

        public async Task<List<Caractere>> Lista()
        {
            try
            {

                var queryCategoria = await _caracteresRepositorio.Consultar();
                return queryCategoria.ToList();

            }
            catch
            {
                throw;
            }
        }
        public async Task<Caractere> Crear(Caractere modelo)
        {
            try
            {
                var categoriaCreado = await _caracteresRepositorio.Crear(modelo);
                if (categoriaCreado.IdCaracteres == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el categoria");
                }
                return categoriaCreado;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Caractere modelo)
        {
            try
            {
                var categoriaModelo = modelo;
                var categoriaEncontrado = await _caracteresRepositorio.Obtener(u => u.IdCaracteres == categoriaModelo.IdCaracteres);
                if (categoriaEncontrado == null)
                {
                    throw new TaskCanceledException("No existe el caracteres");
                }
                categoriaEncontrado.Caracteres = categoriaModelo.Caracteres;

                bool respuesta = await _caracteresRepositorio.Editar(categoriaEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("No se pudo editar");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var productoEncontrado = await _caracteresRepositorio.Obtener(p => p.IdCaracteres == id);
                if (productoEncontrado == null)
                {
                    throw new TaskCanceledException("El Barrio no existe");
                }
                bool respuesta = await _caracteresRepositorio.Eliminar(productoEncontrado);
                if (respuesta == false)
                {
                    throw new TaskCanceledException("El barrio no se elimino con exito");
                }
                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}
