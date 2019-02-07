using EvaParcial.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class EntregaModel
    {
        public ApplicationDbContext _contexto;

        public EntregaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Entrega_Model(
            DateTime Fecha,
            string ResponsableResive)
        {
            IdentityError resultado = new IdentityError();
            Entrega entrega = new Entrega()
            {
                Fecha = Fecha,
                ResponsableResive = ResponsableResive};
            try
            {

                _contexto.Entrega.Add(entrega);
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

        public Entrega Un_Entrega_Model(int idEntrega)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Entrega entrega = (from e in _contexto.Entrega
                                             where e.idEntrega == idEntrega
                               select e).FirstOrDefault();
            return entrega;
        }

        public IdentityError Editar_Entrega_Model(
            int idEntrega,
            DateTime Fecha,
            string ResponsableResive)
        {
            IdentityError resultado = new IdentityError();
            Entrega entrega = new Entrega()
            {
                Fecha = Fecha,
                ResponsableResive = ResponsableResive,
                idEntrega = idEntrega
            };
            try
            {
                _contexto.Entrega.Update(entrega);
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
        public IdentityError Eliminar_Entrega_Model(
           int idEntrega)
        {
            IdentityError resultado = new IdentityError();
            Entrega entrega = new Entrega()
            {
                idEntrega = idEntrega
            };
            try
            {
                _contexto.Entrega.Remove(entrega);
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



        public List<object[]> Lista_Entrega_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var entrega = _contexto.Entrega.ToList();

            foreach (var item in entrega)
            {
                dato += "<tr>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>" + item.ResponsableResive + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Entrega' " +
                    "onclick ='Un_Entrega(" + item.idEntrega + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_entrega(" + item.idEntrega + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
