using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


using Entidad;
using Negocio;


namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Producto descripcion_entidad = new Producto();

        cnProducto descripcion_negocio = new cnProducto();

        cnProducto Listado = new cnProducto();

        private void mostrar()
        {

            DataTable dt = new DataTable();

            String dato = txtconsultar.Text;


            dt = Listado.Consultar1(dato);

            grilla_listado.DataSource = dt;


        }


        private void mostrar_categoria()
        {
            DataTable dt = new DataTable();
            dt = Listado.Mostrar_categoria();
            cbocategoria.DataSource = dt;


            this.cbocategoria.DisplayMember = "Nombre";
            this.cbocategoria.ValueMember = "idcategoria";



        }





        private void limpiar()
        {

            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtobservacion.Text = "";
            txtstock.Text = "";
            cbocategoria.Text = "";
            txtmarca.Text = "";
            txtprecio.Text = "";





        }

        private void habilitar()
        {


            btnguardar.Enabled = false;

            btnmodificar.Enabled = true;

            btneliminar.Enabled = true;

        }

        private void desahilitar()
        {

            btnguardar.Enabled = true;

            btnmodificar.Enabled = false;

            btneliminar.Enabled = false;


        }


        private void btnguardar_Click(object sender, EventArgs e)
        {


           int stock;

           stock= Convert.ToInt32(txtstock.Text);


            if (txtnombre.Text == "")

            // ---------->  ||
            {



                MessageBox.Show("Ingrese el Nombre ", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if (txtprecio.Text == "")

            // ---------->  ||
            {



                MessageBox.Show("Ingrese el Precio", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }



            else if (stock >= 5)




            {

                MessageBox.Show("Ingrese el Stock Igual o Mayor 5 ", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtstock.Text = "";

            }



            else if (txtstock.Text == "")

            // ---------->  ||
            {



                MessageBox.Show("Ingrese el Stock", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            








            else
            {

                descripcion_entidad.Nombre = txtnombre.Text;

                descripcion_entidad.Marca= txtmarca.Text;
                descripcion_entidad.Precio= txtprecio.Text;

                descripcion_entidad.Stock= txtstock.Text;
                descripcion_entidad.Observacion = txtobservacion.Text;

                descripcion_entidad.Foto = txtfoto.Text;


                descripcion_entidad.Categoria = cbocategoria.SelectedValue.ToString();







            
                descripcion_negocio.guardar(descripcion_entidad);


                MessageBox.Show("Asido Guardado Correctamente", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

                mostrar();

                limpiar();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            mostrar();



            mostrar_categoria();

            desahilitar();


        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrar();

            desahilitar();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {

            // la variables que representa  para la caja de textos

            descripcion_entidad.Id = txtcodigo.Text;
            descripcion_entidad.Nombre = txtnombre.Text;

            descripcion_entidad.Marca = txtmarca.Text;
            descripcion_entidad.Precio = txtprecio.Text;

            descripcion_entidad.Stock = txtstock.Text;
            descripcion_entidad.Observacion = txtobservacion.Text;

            descripcion_entidad.Foto = txtfoto.Text;


            descripcion_entidad.Categoria = cbocategoria.SelectedValue.ToString();








            
            descripcion_negocio.editar(descripcion_entidad);


            MessageBox.Show("Asido Actualizado Correctamente", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

            mostrar();

            limpiar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea Eliminar el Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {


                return;

          

              
            }

           

            descripcion_entidad.Id = txtcodigo.Text;


           
            descripcion_negocio.cancelar(descripcion_entidad);

           
            mostrar();

            limpiar();

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grilla_listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtcodigo.Text = grilla_listado.CurrentRow.Cells["IdProducto"].Value.ToString();

            txtnombre.Text = grilla_listado.CurrentRow.Cells["nombre"].Value.ToString();

            txtmarca.Text = grilla_listado.CurrentRow.Cells["marca"].Value.ToString();

            txtprecio.Text = grilla_listado.CurrentRow.Cells["precio"].Value.ToString();

            txtstock.Text = grilla_listado.CurrentRow.Cells["stock"].Value.ToString();

           // txtobservacion.Text = grilla_listado.CurrentRow.Cells["observacion"].Value.ToString();

           //txtfoto.Text = grilla_listado.CurrentRow.Cells["foto"].Value.ToString();


            //cbocategoria.Text = grilla_listado.CurrentRow.Cells["categoria"].Value.ToString();

            habilitar();

        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {

            try

            {

                int stock;

                stock = Convert.ToInt32(txtstock.Text);


                if (stock <= 4)




                {

                    MessageBox.Show("El Stock Minimo Del Producto deberi ser Mayor a  5 ", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //txtstock.Text = "";

                }



            }


            catch (Exception ex)
            {
                string error = "Error de dato" + ex;

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {

          

            }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {


            try

            {

                int precio;

                precio = Convert.ToInt32(txtprecio.Text);


                if (precio >=2501)




                {

                    MessageBox.Show("el Precio de los Producto No  puede Exceder los S/. 2500.00 ", "Aviso....", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtprecio.Text = "";

                }



            }


            catch (Exception ex)
            {
                string error = "Error de dato" + ex;

            }

        }
    }
}
