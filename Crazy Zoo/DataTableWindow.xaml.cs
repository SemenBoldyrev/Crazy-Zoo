using Crazy_Zoo.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DataTableWindow.xaml
    /// </summary>
    public partial class DataTableWindow : Window
    {
        public DataTableWindow()
        {
            InitializeComponent();
            ShowData();
        }

        //Table doesnt clear itself, so i just adding items again and again every fresh start, i need A: use database to init and save (what is good but long) B: to not save existing creatures (problem with load but i think faster)
        private async void ShowData()
        {
            DataTable_listbox.Items.Clear();

            var data = App.Services.GetService<IAnimalDatabaseController>().GetAnimalData();

            foreach ( DataRow row in data.AsEnumerable() )
            {
                DataTable_listbox.Items.Add($"{row["Name"]} -- {row["Specie"]} -- {row["Enclosure"]}" );
            }

            data = App.Services.GetService<IAnimalDatabaseController>().GetEnclosureData();

            foreach (DataRow row in data.AsEnumerable())
            {
                DataTableEnc_listbox.Items.Add($"{row["Name"]}");
            }

            DataTable_listbox.Items.Refresh();
            DataTableEnc_listbox.Items.Refresh();
        }
    }
}
