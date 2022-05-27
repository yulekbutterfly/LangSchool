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

namespace LangSchool
{
    /// <summary>
    /// Логика взаимодействия для AdditionWindow.xaml
    /// </summary>
    public partial class AdditionWindow : Window
    {
        bool isEdit = false;
        Data.Client editClient = new Data.Client();



        public AdditionWindow()
        {
            InitializeComponent();
            CmB_Gender.ItemsSource = Data.DataEntities.context.Client.ToList();
            CmB_Gender.DisplayMemberPath = "NameGender";
            CmB_Gender.SelectedItem = "0";

            isEdit = false;
        }

        public AdditionWindow(Data.Client Client)
        {
                InitializeComponent();
            //cmbGender.ItemsSource =Data.DataEntities.context.Gender.ToList();
            //cmbGender.DisplayMemberPath = "NameRole";
                Lname.Text = Client.LName;
                FName.Text = Client.FName;
                MName.Text = Client.MName;
                Phone.Text = Client.Phone;
                Email.Text = Client.Email;


            CmB_Gender.SelectedIndex = Convert.ToInt32(Client.IDGender - 1);
            //cmbRole.SelectedIndex = Client.IDRole - 1; 

            tbTitle.Text = "Изменение данных";
            btnadd.Content = "Сохранить";

            isEdit = true;
            editClient = Client;

        }

            private void btnadd_Click(object sender, RoutedEventArgs e)

            {
            //bool IsValidEmail(string email)
            //{
            //    //    string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            //    //    Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            //    //    return isMatch.Success;
            //    //    }
           
            //валидация
            if (string.IsNullOrWhiteSpace(Lname.Text))
                {
                    MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(FName.Text))
                {
                    MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(Phone.Text))
                {
                     MessageBox.Show("Поле Телефон не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                     return;
                }
                if (Phone.Text.Length > 12)
                {
                    MessageBox.Show("Поле Телефон содержит больше 12 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //if (IsValidEmail(Email.Text) == false)
                //{
                //    MessageBox.Show("Поле Почта заполнено неккорректно", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                 if (!Int32.TryParse(Phone.Text, out int res))
                 {
                     MessageBox.Show("Поле Телефон должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                     return;
                 }

               
                if (isEdit) //Изменение пользователя 
                {
                    var resClick = MessageBox.Show("Изменить пользователя?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resClick == MessageBoxResult.No)
                    {
                        return;
                    }
                    try
                    {
                        editClient.LName = Lname.Text;
                        editClient.FName = FName.Text;
                        editClient.MName = MName.Text;
                        editClient.Phone = Phone.Text;
                        editClient.Email = Email.Text;
                        editClient.IDGender = CmB_Gender.SelectedIndex + 1;
                   

                       Data.DataEntities.context.SaveChanges();
                        MessageBox.Show("Пользователь изменён");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
                else
                {
                    var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resClick == MessageBoxResult.No)
                    {
                        return;
                    }
                    try
                    {
                        Data.Client newstaff = new Data.Client();
                        newstaff.LName = Lname.Text;
                        newstaff.FName = FName.Text;
                        newstaff.MName = MName.Text;
                        newstaff.Phone = Phone.Text;
                        newstaff.Email = Email.Text;
                        newstaff.IDGender = (CmB_Gender.SelectedItem as Data.Gender).ID;
                      
                       Data.DataEntities.context.Client.Add(newstaff);
                       Data.DataEntities.context.SaveChanges();
                        MessageBox.Show("Пользователь добавлен");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

            }

            private void Phone_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

        private void CmB_Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
