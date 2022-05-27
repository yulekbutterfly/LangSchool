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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LangSchool.Data.DataEntities;

namespace LangSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> combo = new List<String>()
{
            "id",
            "Фамилия",
            "Дата Посещения",
            "Кол-Во Посещений"
            };
        
        List<String> comboGender = new List<String>()
            {
            "Любой",
            "Женский",
            "Мужской"
            };

        List<String> ComList = new List<String>()
            {
            "10",
            "50",
            "200",
            "Все"
            };









        public MainWindow()
            {
                InitializeComponent();
                ComFilter1.ItemsSource = combo;
                ComFilter1.SelectedIndex = 0;
                ComFilterGender.ItemsSource = comboGender;
                ComFilterGender.SelectedIndex = 0;
                ComList.ItemsSource =ComList;
                ComList.SelectedIndex = 0;
        }

            private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            Filter(1);
            }

            public void Filter(int shoose)
            {
                int a = shoose;
                List<Data.Client> ListClient = Data.DataEntities.context.Client.ToList();
            if (CheckBirth.IsChecked == true)
            {
                ListClient = ListClient.Where(i => i.DateOfBirth.Value.Month == DateTime.Now.Month).ToList();
            }
            switch (a)
                {
                    default:
                        break;
                        case 1:
                        ListClient = ListClient
                        .Where(i => i.LName.ToLower().Contains(txtSearch.Text.ToLower())
                        || i.FName.ToLower().Contains(txtSearch.Text.ToLower())
                        || i.MName.ToLower().Contains(txtSearch.Text.ToLower())
                        || i.Email.ToLower().Contains(txtSearch.Text.ToLower())
                        || i.Phone.ToLower().Contains(txtSearch.Text.ToLower())).ToList();


                        switch (ComFilter1.SelectedIndex)
                        {
                            case 0:
                                ListClient = ListClient.OrderBy(i => i.ID).ToList();
                                break;
                            case 1:
                                ListClient = ListClient.OrderBy(i => i.LName).ToList();
                                break;
                            case 2:
                                ListClient = ListClient.OrderByDescending(i => i.LName).ToList();
                                break;
                            case 3:
                                ListClient = ListClient.OrderByDescending(i => i.CountVisit).ToList();
                                break;
                        }
                        switch (ComFilterGender.SelectedIndex)
                        {
                            default:
                                break;
                            case 1:
                                ListClient = ListClient.OrderByDescending(i => i.IDGender).ToList();
                                break;
                            case 2:
                                ListClient = ListClient.OrderBy(i => i.IDGender).ToList();
                                break;
                        }

                    //if (CheckBirth.IsChecked == true)
                    //{
                    //    ListClient = ListClient.Where(i => i.DateOfBirth.Month == DateTime.Today.Month).ToList();
                    //}
                    break;


               }

                ClientList.ItemsSource = ListClient;
            }

           

     

            private void CheakBirth_Click(object sender, RoutedEventArgs e)
            {
                Filter(1);
            }

        private void ComFilterGender_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Filter(1);
        }

        private void ComFilter1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter(1);
        }

        private void txtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Filter(1);
        }

        private void CheckBirth_Checked(object sender, RoutedEventArgs e)
        {
            Filter(1);
        }

        private void CheckBirth_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ComFilter1.SelectedIndex = 0;
            ComFilterGender.SelectedIndex = 0;
            txtSearch.Text = "";
            CheckBirth.IsChecked = false;

        }

        private void btn_AddClient_Click(object sender, RoutedEventArgs e)
        {
           
                AdditionWindow addClientWindow = new AdditionWindow();
                this.Hide();
                addClientWindow.ShowDialog();
                this.Show();
                ClientList.ItemsSource = Data.DataEntities.context.Client.ToList();
                Filter(1);
            
        }


        private void ClientList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                if (ClientList.SelectedItem is Data.Client)
                {
                    var cln = ClientList.SelectedItem as Data.Client;
                    AdditionWindow addEmployeeWindow = new AdditionWindow(cln);
                    addEmployeeWindow.ShowDialog();
                    Filter(1);
                }
            
        }
        //Удаление пользователя 
        private void ClientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                //try
                //{
                if (ClientList.SelectedItem is Data.Client)
                {
                    var resmsg = MessageBox.Show("Удалить клиента?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resmsg == MessageBoxResult.No)
                    {
                        return;
                    }
                    var stf = ClientList.SelectedItem as Data.Client;
                    stf.IsDeleted = true;
                    Data.DataEntities.context.SaveChanges();
                    MessageBox.Show("Клиент успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Filter(1);
                }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}
            }

        }

        private void ComList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}


