using Crazy_Zoo.Classes;
using Crazy_Zoo.Classes.Animals;
using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Script;
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
using static System.Net.Mime.MediaTypeNames;

namespace Crazy_Zoo
{
    /// <summary>
    /// Interaction logic for EncosuresWindow.xaml
    /// </summary>
    public partial class EncosuresWindow : Window, IAnimalHolder
    {

        List<Enclosure<BaseAnimal>> enclosures = new List<Enclosure<BaseAnimal>> { 
            new Enclosure<BaseAnimal>("Original Enclosure") { new Horse(), new Monkey(), new Bacteria(), new Snail(), new Zebra(), new Virus() },
            new Enclosure<BaseAnimal>("Crazy fields") { new Horse(age:20), new Zebra(age:25), new Horse(name:"Another horse", age:35), new Horse(name:"Cool horse", age:15), new Horse(name:"not cool horse",age:14), },
            new Enclosure<BaseAnimal>("Micro world") { new Bacteria(age:2), new Virus(age:324), new Bacteria(name:"Ameba", species:"Ameba", age:1), new Bacteria(age:4), },
            new Enclosure<BaseAnimal>("Pre-urban jungle") { new Monkey(age:15), new Monkey(name:"Karl",age:34), new Monkey(name:"Mathew", age:42), new Monkey(name:"Someone", age:23),}};

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        //hours and minutes
        int[] curTime = new int[2] { 12, 0 };
        bool nighttime = false;

        public EncosuresWindow()
        {
            InitializeComponent();
            Enclosure_listbox.ItemsSource = enclosures;
            Enclosure_listbox.Items.Refresh();
            ClearInfo();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            SignalBus.writeDial += ChangeDial;
            ClearDial();
        }
        //functions
        public void ChangeDial(string text)
        {
            Dial_textbox.Items.Add($"{GetTimeText()}: " + text);
            Dial_textbox.Items.Add("----------------------------------------");
        }

        public void ClearDial() => Dial_textbox.Items.Clear();

        public void RemoveEnclosure(int index)
        {
            enclosures.RemoveAt(index);
            EncAnimals_listbox.ItemsSource = null;
            EncAnimals_listbox.Items.Refresh();
            Enclosure_listbox.Items.Refresh();
        }

        public void RemoveAnimal(int animalIndex)
        {
            BaseAnimal selectedAnimal = enclosures[Enclosure_listbox.SelectedIndex].GetAll().ElementAt(animalIndex);
            enclosures[Enclosure_listbox.SelectedIndex].Remove(selectedAnimal);
            EncAnimals_listbox.Items.Refresh();
        }

        public void AddAnimal(BaseAnimal animal)
        {
            enclosures[Enclosure_listbox.SelectedIndex].Add(animal);
            EncAnimals_listbox.Items.Refresh();
        }

        public void UpdateInfo()
        {
            Enclosure<BaseAnimal> selectedEnclosure = enclosures[Enclosure_listbox.SelectedIndex];
            AmounOfAnimals_textblock.Text = selectedEnclosure.GetAll().Count().ToString();
            UniqueAnimals_textblock.Text = selectedEnclosure.GetAll().Select(a => a.GetSpecies()).Distinct().Count().ToString();
            CrazyAnimals_textblock.Text = selectedEnclosure.Find(a => a is ICrazy).Count().ToString();
            BabyAmount_textblock.Text = selectedEnclosure.Find(a => a.GetAge()<10).Count().ToString();
            AnimalAge_listbox.ItemsSource = selectedEnclosure.GetAll().
                GroupBy(a => a.GetSpecies()).
                Select(g => new 
                { 
                    specie = g.Key, 
                    age = g.Average(a => a.GetAge()) 
                }).
                Select(a => $"{a.specie} - avg. age {a.age}");
        }

        public void ClearInfo()
        {
            AmounOfAnimals_textblock.Text = "";
            UniqueAnimals_textblock.Text = "";
            CrazyAnimals_textblock.Text = "";
            BabyAmount_textblock.Text = "";
            AnimalAge_listbox.ItemsSource = null;
        }

        public void CloseExcessiveWindows()
        {
            foreach (Window win in App.Current.Windows)
            {
                if (win is EncosuresWindow) { continue; }
                win.Close();
            }
        }

        public void CheckTime()
        {
            if (curTime[0] == 1 && !nighttime) { CloseZoo(); nighttime = true; ClearDial(); }
            if (curTime[0] == 11 && nighttime) { OpenZoo(); nighttime = false; ClearDial(); }
        }

        public string GetTimeText()
        {
            string timeText = "";
            if (curTime[0] < 10)
            {
                timeText += "0";
            }
            timeText += curTime[0].ToString() + ":";

            if (curTime[1] < 10)
            {
                timeText += "0";
            }
            timeText += curTime[1].ToString();
            return timeText;
        }

        public void UpdateTimeTextbox()
        {
            

            Time_textbox.Text = GetTimeText();
        }

        public void CloseZoo()
        {
            CloseExcessiveWindows();
            EnterEnclosure_btn.IsEnabled = false;
            MessageBox.Show("The zoo is now closed...\nCome back later!");
        }

        public void OpenZoo()
        {
            EnterEnclosure_btn.IsEnabled = true;
            MessageBox.Show("The zoo is now open!\nWelcome back!");
        }

        //triggers
        private void On_Enclosure_listbox_change(object sender, SelectionChangedEventArgs e)
        {
            if (Enclosure_listbox.SelectedItem == null) { return; }
            EncAnimals_listbox.ItemsSource = enclosures[Enclosure_listbox.SelectedIndex].GetAll();
            EncAnimals_listbox.Items.Refresh();
            UpdateInfo();
        }

        private void On_Add_Enclosure_Btn_press(object sender, RoutedEventArgs e)
        {
            if (EncName_textbox.Text == "" || EncName_textbox.Text == "Enter name here...") { return; }
            enclosures.Add(new Enclosure<BaseAnimal>(EncName_textbox.Text));
            Enclosure_listbox.Items.Refresh();
            EncName_textbox.Text = "Enter name here...";
        }

        private void on_EncName_textbox_focus(object sender, RoutedEventArgs e)
        {
            EncName_textbox.Text = "";
        }

        private void on_EncName_textbox_focusLost(object sender, RoutedEventArgs e)
        {
            if (EncName_textbox.Text == "")
            {
                EncName_textbox.Text = "Enter name here...";
            }
        }

        private void on_RemoveAnimal_btn_click(object sender, RoutedEventArgs e)
        {
           if (EncAnimals_listbox.SelectedItem == null) { return; }
            RemoveAnimal(EncAnimals_listbox.SelectedIndex);
            UpdateInfo();
        }

        private void on_RemoveEnclosure_btn_click(object sender, RoutedEventArgs e)
        {
            if (Enclosure_listbox.SelectedItem == null) { return; }
            RemoveEnclosure(Enclosure_listbox.SelectedIndex);
            ClearInfo();
        }

        private void on_EnterEnclosure_btn_press(object sender, RoutedEventArgs e)
        {
            if (Enclosure_listbox.SelectedItem == null) { return; }
            MainWindow win = new MainWindow();
            win.Owner = this;
            win.SetEnclosure(enclosures[Enclosure_listbox.SelectedIndex]);
            win.Show();
        }

        private void On_AddAnimal_btn_click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Owner = this;
            win.Show();
        }
        


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int increacer = 25; // seconds per tick (please, do not place higher than 60)
            int span = 0;

            curTime[1]+=increacer;
            if (curTime[1] >= 60)
            {
                span = curTime[1] - 60;
                curTime[0]++;
                curTime[1] = 0;
                if(curTime[0]>=24)
                {
                    curTime[0] = 0;
                }
            }
            curTime[1] += span;
            UpdateTimeTextbox();
            CheckTime();
        }
    }
}
