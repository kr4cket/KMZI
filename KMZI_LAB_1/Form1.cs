namespace KMZI_LAB_1
{
    public partial class Form1 : Form
    {
        private Dictionary<char, int> Map = new Dictionary<char, int>();
        private Dictionary<char, char> Decoding = new Dictionary<char, char>();
        private string encodingText = "";
        private List<Letter> LetterList = new List<Letter>();
        private string decodingText = "";
        public void GetId()
        {
            foreach (char letter in encodingText)
            {
                if (Map.ContainsKey(letter))
                {
                    Letter let = new Letter(letter, Map[letter]);
                    LetterList.Add(let);
                }
            }
        }
        public void Change(char ch, int id)
        {
            string res = "";
            foreach (Letter let in LetterList)
            {
                if (let.id == id)
                {
                    let.letter = ch;
                }
                res += let.letter;
            }
            textBox2.Text = res;
        }
        public void Decode()
        {
            string text = "";
            foreach(char let in encodingText)
            {
                text += Decoding[let];
            }
            textBox2.Text = text;
        }
        public void GetEncrypt(Dictionary<char,int> dict)
        {
            string decchars = "îåàèíòñðâëêìäïóÿûüãçá÷éõæøþöùýô¸ú";
            List<char> encchars = dict.Keys.ToList();
            encchars.Reverse();
            int index = 0;
            foreach(var l in encchars)
            {
                Decoding[l] = decchars[index];
                index++;
            }
        }
        public void GetMap(string text)
        {
            Map.Clear();
            foreach(char letter in text)
            {
                if (Map.ContainsKey(letter))
                    Map[letter]++;
                else
                    Map[letter] = 1;
            }
            Map = Map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x=> x.Value);
            GetId();
            GetEncrypt(Map);
            var list = Map.ToList();
            list.Reverse();
            dataGridView1.DataSource = list;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            encodingText = textBox1.Text;
            GetMap(encodingText);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox3.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decodingText = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Decode();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id = Map[textBox3.Text[0]];
            char c = textBox4.Text[0];
            Change(c, id);
        }
    }
}