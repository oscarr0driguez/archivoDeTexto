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
            //Ademas de utilizar el control openFileDialog, es necesario declarar un objeto de este tipo
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Directorio en donde se va a iniciar la busqueda
            openFileDialog1.InitialDirectory = "c:\\";
            //Tipos de archivos que se van a buscar, en este caso archivos de texto con extensión .txt
            openFileDialog1.Filter = "Archivos txt (*.txt)|*.txt| Todos los archivos (*.*)|*.*";

            //Muestra la ventana para abrir el archivo y verifica que si se pueda abrir
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //Guardamos en una variable el nombre del archivo que abrimos
                string nombreArchivo= openFileDialog1.FileName;

                //Abrimos el archivo, en este caso lo abrimos para lectura
                FileStream flujo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                StreamReader lector = new StreamReader(flujo);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (lector.Peek() > -1)
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    // richTextBox1.AppendText(lector.ReadLine());
                    string textoLeido = lector.ReadLine();
                    richTextBox1.AppendText(textoLeido);
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                lector.Close();
            }
        }

        private void BtnDirecto_Click(object sender, EventArgs e)
        {
                //Guardamos en una variable el nombre del archivo que abrimos
                string nombreArchivo = @"C:\Users\Oscar_Rodriguez\Desktop\progra 3 2024\archivoDeTexto\bin\Debug\archivo.txt";

                //Abrimos el archivo, en este caso lo abrimos para lectura
                FileStream flujo = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                StreamReader lector = new StreamReader(flujo);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (lector.Peek() > -1)
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    // richTextBox1.AppendText(lector.ReadLine());
                    string textoLeido = lector.ReadLine();
                    richTextBox1.AppendText(textoLeido);
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                lector.Close();
            
        }
    }
}
