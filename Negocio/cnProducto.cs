using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using AccesoDatos;
using Entidad;

using System.Data;



namespace Negocio
{
    public class cnProducto
    {


        adProducto nombre_datos = new adProducto();

        public void guardar(Producto nombre_entidad)
        {
            nombre_datos.insertar(nombre_entidad);


        }

        public void editar(Producto nombre_entidad)
        {
            nombre_datos.modificar(nombre_entidad);



        }

        public void cancelar(Producto nombre_entidad)
        {
            nombre_datos.eliminar(nombre_entidad);



        }


        public DataTable Consultar(String parametro)
        {

            return nombre_datos.Buscar(parametro);


        }

        public DataTable Consultar1(String parametro)
        {

            return nombre_datos.Buscar1(parametro);


        }

        public DataTable Mostrar_categoria()
        {

            return nombre_datos.Listar_categoria();


        }




    }
}

