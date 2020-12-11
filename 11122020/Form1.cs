using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11122020
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            CreateButton();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateButton()
        {

            Button bt = new Button
            {
                Text = "ok",
                Name = "btOk",
                Size = new Size(100, 50),
                Location = new Point(170, 110),
            };
            this.Controls.Add(bt);

            bt.Click += Bt_Click;

        }

        private string TextRadioButton(Control.ControlCollection controls)
        {

            return controls
                .OfType<RadioButton>()
                .FirstOrDefault(rb => rb.Checked)
                ?.Text;
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            string kurs = TextRadioButton(panel1.Controls);
            if (String.IsNullOrWhiteSpace(kurs))
            {
                MessageBox.Show($"Виберіть напрям підготовки");
                return;
            }
            string forma = TextRadioButton(groupBox1.Controls); ;
            if (String.IsNullOrWhiteSpace(forma))
            {
                MessageBox.Show($"Виберіть форму підготовки");
                return;
            }
            MessageBox.Show($"{kurs}\n{forma} {TextRadioButton(panel2.Controls)}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> subject = new List<string> { "C++", "C--", "C#", "PHP" };
            for (int i = 0; i < subject.Count; i++)
            {
                RadioButton radioButton = new RadioButton
                {
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    Location = new System.Drawing.Point(10, 10 + 30 * i),
                    Name = "radButton" + i,                    
                    Text = subject[i],
                };
                panel2.Controls.Add(radioButton);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {           
            var texts= groupBox1
                .Controls
                .OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Text);

            MessageBox.Show($"{String.Join(";\n", texts)}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             if (panel2.Location.X- button1.Location.X < button1.Width+10) 
            {
                timer1.Stop();
                return;
            }
            button1.Location = new Point(
                button1.Location.X + 3,
                button1.Location.Y
               );

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Text = "" + progressBar1.Value;
            progressBar1.Value+=50;
            //progressBar1.PerformStep();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            progressBar1.Value = trackBar1.Value;
        }
    }
}
