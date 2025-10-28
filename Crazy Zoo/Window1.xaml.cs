using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals.Presets;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Localization.CodeLocalization.MainCodeLoc;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Crazy_Zoo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<string> animal_types = new() { MainLoc.Ground, MainLoc.Bird, MainLoc.Fish };
        public Window1()
        {
            InitializeComponent();
            foreach (string type in animal_types)
            {
                Type_field.Items.Add(type);
            }
        }

        private void On_Create_new_animal_button_press(object sender, RoutedEventArgs e)
        {
            List<string> check = new() { Name_field.Text, Species_field.Text, Voice_field.Text};
            if (check.Contains("")) { return; }

            Dictionary<string, string> data = new();
            data.Add("name", check[0]);
            data.Add("species", check[1]);
            data.Add("voice", check[2]);

            BaseAnimal animal;

            switch (Type_field.SelectedIndex)
            {
                case 0:
                    animal = new GroundAnimal(data["name"], data["species"], data["voice"]);
                    break;

                case 1:
                    animal = new BirdAnimal(data["name"], data["species"], data["voice"]);
                    break;

                case 2:
                    animal = new FishAnimal(data["name"], data["species"], data["voice"]);
                    break;

                default:
                    animal = new WormAnimal(data["name"], data["species"], data["voice"]);
                    break;
            }

            ((MainWindow)this.Owner).AddNewAnimal(animal);
            this.Close();
        }
    }
}
