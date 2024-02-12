using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace archivoDeTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Guardar(@"C:\Users\Oscar_Rodriguez\Desktop\archivo.txt", textBox1.Text);
            Guardar("archivo.txt", textBox1.Text);
            MessageBox.Show("Texto Guardado");
        }
        private void Guardar(string nombreArchivo, string texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            //FileMode.Append salto de linea 
            FileStream flujo = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter escritor = new StreamWriter(flujo);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            escritor.WriteLine(texto);
            //Cerrar el archivo
            escritor.Close();
        }

        private void BtnLeer_Click(object sender, EventArgs e)
        {

        }
    }
}
