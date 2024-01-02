namespace Othello_Project_1._0
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            button1 = new Button();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(264, 543);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-329, -337);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1169, 1019);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(156, 326);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(306, 195);
            richTextBox1.TabIndex = 2;
            richTextBox1.Tag = "\u007f";
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 616);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(pictureBox1);
            Name = "About";
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
    }
}