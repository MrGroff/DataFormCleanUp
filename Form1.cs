namespace DataFormCleanUp
{
    using System;
    using System.IO;
    public partial class CSVCleaner : Form
    {
        public string filepathCSV;
        public CSVCleaner()
        {
            InitializeComponent();
            filepathCSV = "";
        }
        //Using openFileDialog
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr  = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filepathCSV = openFileDialog1.FileName;
                CSVDataCleanUp dataCleanUp = new CSVDataCleanUp();
                dataCleanUp.ReaderCleanUP(filepathCSV);
            }
        
            else
            {
                filepathCSV = "";
            }
            
        }

        private void Process_Click(object sender, EventArgs e)
        {
            if (filepathCSV == "")
            {
                MessageBox.Show("No File Selected");
                return;
            }
            else
            {
                
            }

        }
    }
}
