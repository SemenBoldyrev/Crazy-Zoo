using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crazy_Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BaseAnimal> listOfAnimals = new();

        //ini't
        public MainWindow()
        {
            InitializeComponent();
            AddNewAnimal(new SampleAnimal ("sm name", "sm specie", "sm intro", "sm voice"));
        }

        public void AddNewAnimal(BaseAnimal animal)
        {
            listOfAnimals.Add(animal);
            Animal_list.Items.Add(animal.GetName());
        }

        public void RemoveAnimal(int index)
        { 
            listOfAnimals.RemoveAt(index);
            Animal_list.Items.RemoveAt(index);
        }

        //Shower

        public void ClearInfo()
        {
            ShowName("");
            ShowSpecies("");
            ShowDial("");
        }

        public void ShowStartInfo(int animalIndex)
        {
            BaseAnimal animal = listOfAnimals[animalIndex];
            ShowName(animal.GetName());
            ShowSpecies(animal.GetSpecies());
            ShowDial(animal.GetIntroduction());
        }

        public void ShowName(string name)
        {
            if (name == null)
            {
                Name_box.Text = "NO NAME FOUND";
                return;
            }
            Name_box.Text = name;
        }

        public void ShowSpecies(string species)
        {
            if (species == null)
            {
                Species_box.Text = "NO SPECIES FOUND";
                return;
            }
            Species_box.Text = species;
        }

        public void ShowDial(string dial)
        {
            if (dial == null)
            {
                Dial_box.Text = "NO DIAL FOUND";
                return;
            }
            Dial_box.Text = dial;
        }

        //Triggers
        private void On_Feed_animal_button_press(object sender, RoutedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            string action_dial = listOfAnimals[Animal_list.SelectedIndex].Action();
            if (action_dial == null) { return; }
            else { ShowDial(action_dial); }
        }

        private void On_Voice_button_press(object sender, RoutedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            ShowDial(listOfAnimals[Animal_list.SelectedIndex].GetVoice());
        }

        private void On_Crazy_action_button_press(object sender, RoutedEventArgs e)
        {
        
        }

        private void On_Add_new_button_press(object sender, RoutedEventArgs e)
        {

        }

        private void On_Delete_button_press(object sender, RoutedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            RemoveAnimal(Animal_list.SelectedIndex);
            ClearInfo();
        }

        private void On_Animal_list_selected(object sender, SelectionChangedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            ShowStartInfo(Animal_list.SelectedIndex);
        }
    }
}