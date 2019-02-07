using EvaParcial.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class ClientesModel
    {
        public ApplicationDbContext _contexto;

        public ClientesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Cliente_Model(
            string Nombres,
            string Direccion,
            string Ruc)
        {
            IdentityError resultado = new IdentityError();
            Clientes cliente = new Clientes()
            {
                Nombre = Nombres,
                Direccion = Direccion,
                Ruc = Ruc

            };
            try
            {

                _contexto.Cliente.Add(cliente);
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

        public Clientes Un_Cliente_Model(int idCliente)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Clientes cliente = (from c in _contexto.Cliente
                               where c.idCliente == idCliente
                               select c).FirstOrDefault();
            return cliente;
        }

        public IdentityError Editar_Cliente_Model(
            int idCliente,
            string Nombres,
            string Direccion,
            string Ruc)
        {
            IdentityError resultado = new IdentityError();
            Clientes cliente = new Clientes()
            {
                Nombre = Nombres,
                Direccion = Direccion,
                Ruc = Ruc,
                idCliente = idCliente
            };
            try
            {
                _contexto.Cliente.Update(cliente);
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
        public IdentityError Eliminar_Cliente_Model(
           int idCliente)
        {
            IdentityError resultado = new IdentityError();
            Clientes cliente = new Clientes()
            {
                idCliente = idCliente
            };
            try
            {
                _contexto.Cliente.Remove(cliente);
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



        public List<object[]> Lista_Clientes_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var clientes = _contexto.Cliente.ToList();

            foreach (var item in clientes)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Ruc + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Cliente' " +
                    "onclick ='Un_Cliente(" + item.idCliente + ")' " +
                    "class='btn btn-primary'>Edit</a> |" +
                    "<a onclick='eliminar_cliente(" + item.idCliente + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
