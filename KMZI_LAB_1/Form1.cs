namespace KMZI_LAB_1
{
    public class Letter
    {
        public char letter { get; set; }
        public int id { get; set; }
        public Letter(char letter, int id)
        {
            this.letter = letter;
            this.id = id;
        }
    }
    public partial class Form1 : Form
    {
        private Dictionary<char, int> Map = new Dictionary<char, int>();
        private List<Letter> LetterList = new List<Letter>();
        private string encodingText = "";
        private string decodingText = "";
        public void GetId()
        {
            foreach(char letter in encodingText)
            {
                if (Map.ContainsKey(letter))
                {
                    Letter let = new Letter(letter, Map[letter]);
                    LetterList.Add(let);
                }
            }
        }
        public void GetMap(string text)
        {
            foreach(char letter in text)
            {
                if (Map.ContainsKey(letter))
                    Map[letter]++;
                else
                    Map[letter] = 1;
            }
            Map = Map.OrderBy(x => x.Value).ToDictionary(x => x.Key, x=> x.Value);
            GetId();
            var list = Map.ToList();
            list.Reverse();
            dataGridView1.DataSource = list;
        }
        public void Change(char ch, int id)
        {
            string res = "";
            foreach(Letter let in LetterList)
            {
                if (let.id == id)
                {
                    let.letter = ch;
                }
                res += let.letter;
            }
            textBox2.Text = res;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encodingText = textBox1.Text;
            GetMap(encodingText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Map[textBox3.Text[0]];
            char c = textBox4.Text[0];
            Change(c, id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1[1,e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox3.Text = dataGridView1[0, e.RowIndex].Value.ToString();
        }
    }
}