using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Media;
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
        public List<BaseAnimal> listOfAnimals = new();

        //ini't
        public MainWindow()
        {
            InitializeComponent();
            foreach (BaseAnimal animal in new List<BaseAnimal> { new Horse(), new Monkey(), new Bacteria() }) { AddNewAnimal(animal); }
            foreach (string food in new List<string> {"hay", "meat", "apple", "chocolate"}) { AddToCombobox(food); }
            MessageBox.Show("Welcome to Crazy Zoo!\nSelect an animal from the list to see its info.\nYou can feed it, hear its voice or see them in action\nBut some of them were here for too long...");
        }

        public void AddToCombobox(string itmName)
        {
            Food_combo_box.Items.Add(itmName);
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
            if (Animal_list.SelectedItem == null || Food_combo_box.SelectedItem == null) { return; }
            ShowDial(listOfAnimals[Animal_list.SelectedIndex].EatFood(Food_combo_box.SelectedItem.ToString()));
        }

        private void On_Voice_button_press(object sender, RoutedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            ShowDial(listOfAnimals[Animal_list.SelectedIndex].MakeSound());
        }

        private void On_Crazy_action_button_press(object sender, RoutedEventArgs e)
        {
            if (Animal_list.SelectedItem == null) { return; }
            int action_id = listOfAnimals[Animal_list.SelectedIndex].Action();
            CrazyActions(action_id);
        }

        private void On_Add_new_button_press(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Owner = this;
            win.Show();
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

        //crazy action, because i cannot change components trough another script
        // so now, animal only returns int value to find needed crazy action
        //and main window preforms it
        //not officient, but it works

        private void CrazyActions(int act)
        {
            switch (act)
            {
                case 0:
                    ShowDial("This animal is pretty chill");
                    break;
                case 1:
                    //sets bg image on grid
                    ImageBrush imgBrush = new ImageBrush();
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/tomascore-horse.gif", UriKind.Absolute));
                    imgBrush.ImageSource = image.Source;
                    Bg_grid.Background = imgBrush;

                    /*
                    SoundPlayer player = new SoundPlayer();
                    player.Load();
                    player.Play();
                    */

                    break;
                case 2:
                    AddNewAnimal(new Human(listOfAnimals[Animal_list.SelectedIndex].GetName() + " but smarter"));
                    RemoveAnimal(Animal_list.SelectedIndex);
                    ClearInfo();
                    break;
                case 3:
                    Window2 win = new Window2();
                    win.Owner = this;
                    win.Show();
                    break;
                default:
                    break;
            }
        }
    }
}