using System;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace Fibonacci
{
    public partial class Form1 : Form
    {
        private int numberToCompute = 0;
        private int highestPercentageReached = 0;
        private SoundPlayer player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);
        }


        private void ReportStatus(string message)
        {
            MessageBox.Show("Estado: " + message);
        }



        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;

        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            pictureBox1.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox1.LoadAsync("https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png");
            // Reset the text in the result label.
            resultLabel.Text = String.Empty;
            this.numericUpDown1.Enabled = false;
            this.startAsyncButton.Enabled = false;
            this.cancelAsyncButton.Enabled = true;


            // Get the value from the UpDown control.
            numberToCompute = (int)numericUpDown1.Value;

            // Reset the variable for percentage tracking.
            highestPercentageReached = 0;

            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync(numberToCompute);
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.backgroundWorker1.CancelAsync();

            // Disable the Cancel button.
            cancelAsyncButton.Enabled = false;
        }

        long ComputeFibonacci(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
    
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentException(
                    "value must be >= 0 and <= 91", "n");
            }

            long result = 0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2)
                {
                    result = 1;
                }
                else
                {
                    result = ComputeFibonacci(n - 1, worker, e) +
                             ComputeFibonacci(n - 2, worker, e);
                }

                // Report progress as a percentage of the total task.
                int percentComplete =
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                resultLabel.Text = e.Result.ToString();
            }

            // Enable the UpDown control.
            this.numericUpDown1.Enabled = true;

            // Enable the Start button.
            startAsyncButton.Enabled = true;

            // Disable the Cancel button.
            cancelAsyncButton.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            // to the Result property of the DoWorkEventArgs

            e.Result = ComputeFibonacci((int)e.Argument, worker, e);
        }

        private void LoadImageAsync(string url)
        {
            pictureBox1.WaitOnLoad = false;
            pictureBox1.LoadAsync(url);
        }
        private void LoadSoundAsync(string filepath)
        {
            try
            {
                player.SoundLocation = filepath;
                player.LoadAsync();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
        }

        private void loadSoundButton_Click(object sender, EventArgs e)
        {
            LoadSoundAsync(textBox1.Text);
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            LoadImageAsync("https://upload.wikimedia.org/wikipedia/commons/4/47/PNG_transparency_demonstration_1.png");
        }
    }
}
