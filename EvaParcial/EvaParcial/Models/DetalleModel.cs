using EvaParcial.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class DetalleModel
    {

        public ApplicationDbContext _contexto;

        public DetalleModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Detalle_Model(
            int idCliente,
            int idDistribuidor
            )
        {
            IdentityError resultado = new IdentityError();
            Detalle detalle = new Detalle()
            {
                idCliente = idCliente,
                idDistribuidor = idDistribuidor

            };
            try
            {

                _contexto.Detalle.Add(detalle);
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

        public Detalle Un_Detalle_Model(int idDetalle)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Detalle detalle = (from d in _contexto.Detalle
                                             where d.idDetalle == idDetalle
                               select d).FirstOrDefault();
            return detalle;
        }

        public IdentityError Editar_Detalle_Model(
            int idDetalle,
            int idCliente,
            int idDistribuidor)
        {
            IdentityError resultado = new IdentityError();
            Detalle detalle = new Detalle()
            {
                idCliente = idCliente,
                idDistribuidor = idDistribuidor,
                idDetalle = idDetalle
            };
            try
            {
                _contexto.Detalle.Update(detalle);
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
        public IdentityError Eliminar_Detalle_Model(
           int idDetalle)
        {
            IdentityError resultado = new IdentityError();
            Detalle detalle = new Detalle()
            {
                idDetalle = idDetalle
            };
            try
            {
                _contexto.Detalle.Remove(detalle);
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



        public List<object[]> Lista_Detalle_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var detalles = _contexto.Detalle.ToList();

            foreach (var item in detalles)
            {
                dato += "<tr>" +
                    "<td>" + item.idCliente + "</td>" +
                    "<td>" + item.idDistribuidor + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Distribuidor' " +
                    "onclick ='Un_Detalle(" + item.idDetalle + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_detalle(" + item.idDetalle + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
