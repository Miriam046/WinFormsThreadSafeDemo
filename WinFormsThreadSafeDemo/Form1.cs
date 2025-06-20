using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsThreadSafeDemo
{
    public partial class Form1 : Form
    {
       /* public Form1()
        {
            InitializeComponent();
        }*/

        private delegate void SafeCallDelegate(string text);

        /* Llamadas no seguras entre subprocesos
         * public void WriteTextSafe(string text)
         {
             if (textBox1.InvokeRequired)
             {
                 var d = new SafeCallDelegate(WriteTextSafe);
                 textBox1.Invoke(d, new object[] { text });
             }
             else
             {
                 textBox1.Text = text;
             }
         }


          private void button1_Click(object sender, EventArgs e)
      {
          Thread thread = new Thread(() =>
          {
              WriteTextSafe("Este texto fue establecido desde un hilo de fondo.");
          });
          thread.Start();
      }*/

        /*  Ejemplo: Uso del método Invoke
         * private void button1_Click(object sender, EventArgs e)
         {
             var threadParameters = new System.Threading.ThreadStart(delegate { WriteTextSafe("This text was " +
                 "set safely."); });
             var thread2 = new System.Threading.Thread(threadParameters);
             thread2.Start();
         }

         public void WriteTextSafe(string text)
         {
             if (textBox1.InvokeRequired)
             {
                 // Call this same method but append THREAD2 to the text
                 Action safeWrite = delegate { WriteTextSafe($"{text} (THREAD2)"); };
                 textBox1.Invoke(safeWrite);
             }
             else
                 textBox1.Text = text;
         }*/

        private BackgroundWorker backgroundWorker1;

        public Form1()
        {
            InitializeComponent();

            // Inicializa y configura el BackgroundWorker
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int counter = 0;
            int max = 10;

            while (counter <= max)
            {
                // Reporta progreso al hilo principal (UI)
                backgroundWorker1.ReportProgress(0, counter.ToString());
                Thread.Sleep(1000); // Simula trabajo en segundo plano
                counter++;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBox1.Text = (string)e.UserState;
        }




    }
}
