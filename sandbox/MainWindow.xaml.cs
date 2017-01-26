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
        string line;
        List <Item> Itemky = new List<Item>();
        List <Item> Merchant_Itemky = new List<Item>();
        string[,] name_of_item = new string[,] { 
            {
                "Železný meč","Železná přilba","Železný hrudní plát","Železné kalhoty","Železné boty"
            },
            {
                "Zlatý meč","Zlatá přilba","Zlatý hrudní plát","Zlaté kalhoty","Zlaté boty"
            },
            {
                "Diamantový meč","Diamantová přilba","Diamantový hrudní plát","Diamantové kalhoty","Diamantové boty"
            }
        };
        string[,] name_of_enchant = new string[,]{
            {
                "zdraví","síly","obrana"
            }
        };
        static Random rnd0 = new Random();
        int random_item_type;
        int random_item_level;
        //int is_enchanted;
        int[,] statboostager;
		//int random_item_type = rnd0.Next(1,5);
        int control;
        bool answer;
        public void LoadJsonFile() {
            using (StreamReader r = new StreamReader(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\test.json")){
                string json = r.ReadToEnd();
                Itemky = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        public void GenerateMerchantInventory(){
            Item item;
            for(int a=1;a<=15;a++) {
                random_item_type = rnd0.Next(0,5);
                random_item_level = rnd0.Next(0,3);
                if(random_item_type == 1) {
                    statboostager = new int[,] { { 1,(1+random_item_level) } };
                }
                else {
                    statboostager = new int[,] { { 3,(1+random_item_level)*2,5 } };
                }
                //is_enchanted = rnd0.Next(1,2);
                item = new Item(name_of_item[random_item_level,random_item_type],random_item_type,statboostager);
                bool alreadyIn = Merchant_Itemky.Any(derp => derp == item);

                if(alreadyIn == true) {
                    a = a - 1;
                }
                else {
                    Merchant_Itemky.Add(item);
                }  
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

            GenerateMerchantInventory();
            for(int a=0;a<=14;a++){
                line += Merchant_Itemky[a].name.ToString()+Environment.NewLine;
            }
            text1.Text = line;
        }
    }
}
