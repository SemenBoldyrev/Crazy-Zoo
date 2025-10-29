using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using Crazy_Zoo.Usables.Script;
using System;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window, IAnimalHolder
    {
        public Enclosure<BaseAnimal> curEnclosure = new("SampleName") { };
        // --- add here new animals to appear on start ---
        public List<BaseAnimal> listOfAnimals;

        //ini't
        public MainWindow()
        {
            listOfAnimals = curEnclosure.GetAll().ToList();
            InitializeComponent();
            foreach (string food in new List<string> {"hay", "meat", "apple", "chocolate"}) { AddToCombobox(food); }
            Animal_list.ItemsSource = listOfAnimals;
        }

        public void SetEnclosure(Enclosure<BaseAnimal> enclosure)
        {
            curEnclosure.clear();
            curEnclosure = enclosure;
            listOfAnimals = curEnclosure.GetAll().ToList();
            Animal_list.ItemsSource = listOfAnimals;
            Animal_list.Items.Refresh();
            Title_textbox.Text = "Welcom to: "+ enclosure.GetName();
        }

        public void AddToCombobox(string itmName)
        {
            Food_combo_box.Items.Add(itmName);
        }

        public void AddAnimal(BaseAnimal animal)
        {
            curEnclosure.Add(animal);
            listOfAnimals.Add(animal);
            RefreshAnimalListBox();
        }

        public void RemoveAnimal(int index)
        { 
            curEnclosure.Remove(listOfAnimals[index]);
            listOfAnimals.RemoveAt(index);
            RefreshAnimalListBox();
        }

        public void RefreshAnimalListBox()
        {
            Animal_list.Items.Refresh();
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
            if (animal is ICrazy)
            {
                Crazy_action_button.IsEnabled = true;
            }
            else
            {
                Crazy_action_button.IsEnabled = false;
            }
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
            if (Animal_list.SelectedItem == null || listOfAnimals[Animal_list.SelectedIndex] is not ICrazy) { return; }
            ICrazy crazy_animal = (ICrazy)listOfAnimals[Animal_list.SelectedIndex];
            CrazyActionEnumerates.CrazyActionEnum action_enum = crazy_animal.CrazyAction();
            CrazyActions(action_enum);
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
        //so now, animal only returns int value to find needed crazy action
        //and main window preforms it
        //not officient, but it works

        private void CrazyActions(CrazyActionEnumerates.CrazyActionEnum act)
        {
            switch (act)
            {
                case CrazyActionEnumerates.CrazyActionEnum.None:
                    ShowDial("This animal is pretty chill");
                    break;
                case CrazyActionEnumerates.CrazyActionEnum.Horse:
                    //sets bg image on grid
                    ImageBrush imgBrush = new ImageBrush();
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/tomascore-horse.gif", UriKind.Absolute));
                    imgBrush.ImageSource = image.Source;
                    Bg_grid.Background = imgBrush;

                    Dial_box.Background = Brushes.White;

                    /* idk how to implement this, i managed it to doesnt throw error, but still no sound
                    SoundPlayer player = new SoundPlayer();
                    player.Load();
                    player.Play();
                    */

                    break;
                case CrazyActionEnumerates.CrazyActionEnum.Monkey:
                    AddAnimal(new Human(listOfAnimals[Animal_list.SelectedIndex].GetName() + " but smarter", age: listOfAnimals[Animal_list.SelectedIndex].GetAge()));
                    RemoveAnimal(Animal_list.SelectedIndex);
                    ClearInfo();
                    break;
                case CrazyActionEnumerates.CrazyActionEnum.Bacteria:
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