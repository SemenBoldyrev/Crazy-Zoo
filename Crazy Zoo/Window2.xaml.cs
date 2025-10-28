using System;
using Crazy_Zoo.Usables.Localization.CodeLocalization.MainCodeLoc;

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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        private int value = 0;
        private int increase = 1;
        private int inc_cost = 10;
        public Window2()
        {
            InitializeComponent();
            More_button.Content = MainLoc.NextLevelCost + $": {inc_cost}";
            Info_block.Text = MainLoc.Colony + $": {value}";
            Multiply_button.Content = $"+{increase}";
        }

        private void On_Multiply_button_press(object sender, RoutedEventArgs e)
        {
            value += increase;
            Info_block.Text = MainLoc.Colony + $": {value}";
        }

        private void On_More_button_press(object sender, RoutedEventArgs e)
        {
            if (value >= inc_cost)
            {
                value -= inc_cost;
                increase += 3;
                inc_cost *= 2;
                More_button.Content =  MainLoc.NextLevelCost+ $": {inc_cost}";
                Info_block.Text = MainLoc.Colony + $": {value}";
                Multiply_button.Content = $"+{increase}";

            }
        }
    }
}
