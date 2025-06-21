namespace Fibonacci
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startAsyncButton = new Button();
            cancelAsyncButton = new Button();
            resultLabel = new Label();
            numericUpDown1 = new NumericUpDown();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            pictureBox1 = new PictureBox();
            loadImageButton = new Button();
            loadSoundButton = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // startAsyncButton
            // 
            startAsyncButton.Location = new Point(25, 148);
            startAsyncButton.Name = "startAsyncButton";
            startAsyncButton.Size = new Size(112, 34);
            startAsyncButton.TabIndex = 0;
            startAsyncButton.Text = "Start";
            startAsyncButton.UseVisualStyleBackColor = true;
            startAsyncButton.Click += startAsyncButton_Click;
            // 
            // cancelAsyncButton
            // 
            cancelAsyncButton.Location = new Point(193, 148);
            cancelAsyncButton.Name = "cancelAsyncButton";
            cancelAsyncButton.Size = new Size(112, 34);
            cancelAsyncButton.TabIndex = 1;
            cancelAsyncButton.Text = "Cancel";
            cancelAsyncButton.UseVisualStyleBackColor = true;
            cancelAsyncButton.Click += cancelAsyncButton_Click;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(218, 36);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(59, 25);
            resultLabel.TabIndex = 2;
            resultLabel.Text = "label1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(40, 34);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(140, 31);
            numericUpDown1.TabIndex = 3;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(14, 87);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(316, 34);
            progressBar1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(409, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(353, 295);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(447, 388);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(112, 34);
            loadImageButton.TabIndex = 6;
            loadImageButton.Text = "cargar";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += loadImageButton_Click;
            // 
            // loadSoundButton
            // 
            loadSoundButton.Location = new Point(650, 388);
            loadSoundButton.Name = "loadSoundButton";
            loadSoundButton.Size = new Size(112, 34);
            loadSoundButton.TabIndex = 7;
            loadSoundButton.Text = "sonido";
            loadSoundButton.UseVisualStyleBackColor = true;
            loadSoundButton.Click += loadSoundButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(437, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(255, 31);
            textBox1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(loadSoundButton);
            Controls.Add(loadImageButton);
            Controls.Add(pictureBox1);
            Controls.Add(progressBar1);
            Controls.Add(numericUpDown1);
            Controls.Add(resultLabel);
            Controls.Add(cancelAsyncButton);
            Controls.Add(startAsyncButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startAsyncButton;
        private Button cancelAsyncButton;
        private Label resultLabel;
        private NumericUpDown numericUpDown1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private PictureBox pictureBox1;
        private Button loadImageButton;
        private Button loadSoundButton;
        private TextBox textBox1;
    }
}
