using EvaParcial.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class DistribuidoresModel
    {
        public ApplicationDbContext _contexto;

        public DistribuidoresModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Distribuidor_Model(
            string Nombres,
            string Direccion,
            string listaReseptor)
        {
            IdentityError resultado = new IdentityError();
            Distribuidores distribuidores = new Distribuidores()
            {
                Nombres = Nombres,
                Direccion = Direccion,
                listaReseptor = listaReseptor

            };
            try
            {

                _contexto.Distribuidores.Add(distribuidores);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Guardo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }

        public Distribuidores Un_Distribuidor_Model(int idDistribuidor)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Distribuidores distribuidores = (from d in _contexto.Distribuidores
                                where d.idDistribuidor == idDistribuidor
                                             select d).FirstOrDefault();
            return distribuidores;
        }

        public IdentityError Editar_Distribuidor_Model(
            int idDistribuidor,
            string Nombres,
            string Direccion,
            string listaReseptor)
        {
            IdentityError resultado = new IdentityError();
            Distribuidores distribuidores = new Distribuidores()
            {
                Nombres = Nombres,
                Direccion = Direccion,
                listaReseptor = listaReseptor,
                idDistribuidor = idDistribuidor
            };
            try
            {
                _contexto.Distribuidores.Update(distribuidores);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Actualizo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }
        public IdentityError Eliminar_Distribuidor_Model(
           int idDistribuidor)
        {
            IdentityError resultado = new IdentityError();
            Distribuidores distribuidores = new Distribuidores()
            {
                idDistribuidor = idDistribuidor
            };
            try
            {
                _contexto.Distribuidores.Remove(distribuidores);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Elimino con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }



        public List<object[]> Lista_Distribuidor_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var distribuidor = _contexto.Distribuidores.ToList();

            foreach (var item in distribuidor)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombres + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.listaReseptor + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Distribuidor' " +
                    "onclick ='Un_Distribuidor(" + item.idDistribuidor + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_distribuidor(" + item.idDistribuidor + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
