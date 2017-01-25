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
        public MainWindow()
        {
            InitializeComponent();

            string[] lines = {"First line", "Second line", "Third line"};
            System.IO.File.WriteAllLines(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\WriteLines.txt", lines);

            string text = "A class is the most powerful data type in C#. Like structures, " +
                       "a class defines the data and behavior of the data type. ";
            System.IO.File.WriteAllText(@"C:\Users\Tom\Desktop\Škola\VS\sandbox\WriteText.txt", text);

            List<Item> Itemy =  new List<Item>();
            int[,] statboostage = new int[,] { { 1,3 } };

            for(int a = 0; a < 5;a++) {
                Item item_ = new Item("Pussydestroyer",1,statboostage);
                Itemy.Add(item_);
            }
            string serializationFile = @"C:\Users\Tom\Desktop\Škola\VS\sandbox\itemy.bin";

            //serialize
            using (Stream stream = File.Open(serializationFile, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, Itemy);
            }

            //deserialize
            using (Stream stream = File.Open(serializationFile, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                List<Item>  Itemy_ = (List<Item>)bformatter.Deserialize(stream);
            }
        }
    }
}
