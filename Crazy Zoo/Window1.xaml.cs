using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals.Presets;
using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
        public Window1()
        {
            InitializeComponent();
            foreach (string type in new List<string> { "GroundAnimal", "BirdAnimal", "FishAnimal" }) { Type_field.Items.Add(type); }
        }

        private void On_Create_new_animal_button_press(object sender, RoutedEventArgs e)
        {
            List<string> check = new() { Name_field.Text, Species_field.Text, Voice_field.Text, Introduction_field.Text, Age_field.Text};
            if (check.Contains("")) { return; }

            Dictionary<string, string> data = new();
            data.Add("name", check[0]);
            data.Add("species", check[1]);
            data.Add("voice", check[2]);
            data.Add("introduction", check[3]);
            data.Add("age", check[4]);

            BaseAnimal animal = App.Services.GetService<IAnimalFactory>().CreatAnimal(Type_field.SelectedItem.ToString(), data["name"], int.Parse(data["age"]), data["species"], data["voice"], data["introduction"]);

            if (this.Owner is IAnimalHolder && (bool)App.Services.GetService<IAnimalDatabaseController>().IsUniqueAnimal(animal)) { ((IAnimalHolder)this.Owner).AddAnimal(animal); }
            this.Close();
        }

        private void On_Age_field_change(object sender, TextChangedEventArgs e)
        {
            int value;
            try { value = int.Parse(Age_field.Text); }
            catch { Age_field.Text = "0"; return; }
            if (0 > value) { Age_field.Text = "0"; }
        }
    }
}
