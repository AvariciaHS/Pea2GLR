using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using System.Data.SqlClient;
using System.Data;



using Entidad;

namespace AccesoDatos
{
    public class adProducto
    {

       
        Conexion con = new Conexion();


  
        public void insertar(Producto nombre)
        {
         
            //try
            //{
              
                SqlCommand cmd = new SqlCommand("insert into producto values(@nombre,@marca,@precio,@stock,@observacion,@foto,@idcategoria)", con.con);

            

                cmd.CommandType = CommandType.Text;

               

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre.Nombre;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 50).Value = nombre.Marca;
                cmd.Parameters.Add("@precio", SqlDbType.VarChar, 50).Value = nombre.Precio;

                cmd.Parameters.Add("@stock", SqlDbType.VarChar, 50).Value = nombre.Stock;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 50).Value = nombre.Observacion;
                cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = nombre.Foto;

                cmd.Parameters.Add("@idcategoria", SqlDbType.Int, 10).Value = nombre.Categoria;



              
                con.con.Open();
           
                cmd.ExecuteNonQuery();

               
                con.con.Close();

            //}

   

            //catch (Exception ex)
            //{
            //    string error = "Error de dato" + ex;

            //}




        }



     
        public void modificar(Producto nombre)
        {
         
            //try
            //{
              
                SqlCommand cmd = new SqlCommand("update producto set  nombre=@nombre,marca=@marca,precio=@precio,stock=@stock,observacion=@observacion,foto=@foto,idcategoria=@idcategoria where idproducto=@idproducto", con.con);

               

                cmd.CommandType = CommandType.Text;

                
                cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = nombre.Id;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre.Nombre;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 50).Value = nombre.Marca;
                cmd.Parameters.Add("@precio", SqlDbType.VarChar, 50).Value = nombre.Precio;

                cmd.Parameters.Add("@stock", SqlDbType.VarChar, 50).Value = nombre.Stock;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 50).Value = nombre.Observacion;
                cmd.Parameters.Add("@foto", SqlDbType.VarChar, 50).Value = nombre.Foto;

                cmd.Parameters.Add("@idcategoria", SqlDbType.Int, 10).Value = nombre.Categoria;



           
                con.con.Open();
             
                cmd.ExecuteNonQuery();

              
                con.con.Close();

            //}



            //catch (Exception ex)
            //{
            //    string error = "Error de dato" + ex;

            //}




        }
 

        public void eliminar(Producto nombre)
        {
           
            //try
            //{
                
                SqlCommand cmd = new SqlCommand("delete from producto  where idproducto=@idproducto", con.con);

               

                cmd.CommandType = CommandType.Text;

              
                cmd.Parameters.Add("@idproducto", SqlDbType.Int).Value = nombre.Id;

             
          
                con.con.Open();
          
                cmd.ExecuteNonQuery();

          
                con.con.Close();


            //}


            //catch (Exception ex)
            //{
            //    string error = "Error de dato" + ex;

            //}


        }
        

        public DataTable Buscar1(String Nombre)
        {

          
            SqlCommand cmd = new SqlCommand("SELECT        Producto.IdProducto, Producto.Nombre, Producto.Marca, Producto.Precio,Producto.Stock FROM            Producto INNER JOIN Categoria ON Producto.IdCategoria = Categoria.IdCategoria", con.con);

  
            cmd.CommandType = CommandType.Text;

         
            cmd.Parameters.AddWithValue("@idproducto", "%" + Nombre);

        
            SqlDataAdapter da = new SqlDataAdapter(cmd);

          
            DataTable dt = new DataTable();

    
            da.Fill(dt);

            return dt;




        }

        public DataTable Buscar(String Nombre)
        {


            SqlCommand cmd = new SqlCommand("SELECT        Producto.IdProducto, Producto.Nombre, Producto.Marca, Producto.Precio, Producto.Stock ,Categoria.Nombre AS Categoria FROM            Producto INNER JOIN Categoria ON Producto.IdCategoria = Categoria.IdCategoria", con.con);


            cmd.CommandType = CommandType.Text;


            cmd.Parameters.AddWithValue("@idproducto", "%" + Nombre);


            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataTable dt = new DataTable();


            da.Fill(dt);

            return dt;




        }




        public DataTable Listar_categoria()
        {

        

            SqlDataAdapter da = new SqlDataAdapter("select  * from categoria", con.con);
            da.SelectCommand.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

           
            da.Fill(dt);

            return dt;



        }




    }


}
