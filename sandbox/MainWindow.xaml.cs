using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List <Item> Itemky = new List<Item>();
        int control;
        bool answer;
        public void LoadJsonFile() {
            using (StreamReader r = new StreamReader(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\test.json")){
                string json = r.ReadToEnd();
                Itemky = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        public bool IsEnchanted(int predmet) {
            int[,] statboostager = Itemky[predmet].statboost;
            foreach(int r in statboostager) {
                control++;
            }
            switch (control)
            {
                case 2:
                    answer = false;
                    break;
                case 4:
                    answer = true;
                    break;
            }
            return answer;
            
        }
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = {"First line", "Second line", "Third line"};
            System.IO.File.WriteAllLines(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\WriteLines.txt", lines);

            string text = "A class is the most powerful data type in C#. Like structures, " +
                       "a class defines the data and behavior of the data type. ";
            System.IO.File.WriteAllText(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\WriteText.txt", text);

            List<Item> Itemy =  new List<Item>();
            int[,] statboostage = new int[,] { { 1,3 } , { 2,4 } };
            int[,] statboostage_ = new int[,] { { 5,1 } };
            for(int a = 0; a < 5;a++) {
                Item item_ = new Item("Pussydestroyer",1,statboostage);
                Itemy.Add(item_);
            }
            Item item_2 = new Item("Pussydestroyerka",2,statboostage_);
            Itemy.Add(item_2);
            string json = JsonConvert.SerializeObject(Itemy.ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\test.json", json);

            LoadJsonFile();
            text1.Text = IsEnchanted(1).ToString();
        }
    }
}
