using EvaParcial.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class PedidosModel
    {
        public ApplicationDbContext _contexto;

        public PedidosModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Pedido_Model(
            DateTime Fecha,
            string NomCorte,
            int NPiezas,
            decimal PesoCarne)
        {
            IdentityError resultado = new IdentityError();
           Pedidos pedidos  = new Pedidos()
            {
               Fecha = Fecha,
               NomCorte = NomCorte,
               NPiezas = NPiezas,
               PesoCarne = PesoCarne

           };
            try
            {

                _contexto.Pedidos.Add(pedidos);
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

        public Pedidos Un_Pedidos_Model(int idPedidos)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Pedidos pedidos = (from p in _contexto.Pedidos
                                             where p.idPedidos == idPedidos
                               select p).FirstOrDefault();
            return pedidos;
        }

        public IdentityError Editar_Pedidos_Model(
            int idPedidos,
            DateTime Fecha,
            string NomCorte,
            int NPiezas,
            decimal PesoCarne)
        {
            IdentityError resultado = new IdentityError();
            Pedidos pedidos = new Pedidos()
            {
                Fecha = Fecha,
                NomCorte = NomCorte,
                NPiezas = NPiezas,
                idPedidos = idPedidos
            };
            try
            {
                _contexto.Pedidos.Update(pedidos);
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
        public IdentityError Eliminar_Pedidos_Model(
           int idPedidos)
        {
            IdentityError resultado = new IdentityError();
            Pedidos pedidos = new Pedidos()
            {
                idPedidos = idPedidos
            };
            try
            {
                _contexto.Pedidos.Remove(pedidos);
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



        public List<object[]> Lista_Pedidos_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var pedidos = _contexto.Pedidos.ToList();

            foreach (var item in pedidos)
            {
                dato += "<tr>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>" + item.NomCorte + "</td>" +
                    "<td>" + item.NPiezas + "</td>" +
                    "<td>" + item.PesoCarne + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Pedido' " +
                    "onclick ='Un_Pedido(" + item.idPedidos + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_pedidos(" + item.idPedidos + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
