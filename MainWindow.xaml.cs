using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ej26.models;

namespace Ej26
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> Employees { get; set; }
        private List<string> Cities { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Employees = new List<Employee>();
            Cities = new List<string>();

            Cities.AddRange(new string[] {
                "Alicante",
                "Valencia",
                "Barcelona",
                "Benidorm",
                "La Vila Joiosa",
                "Altea"
            });

            destinationComboBox.ItemsSource = Cities;


            Employees.Add(new Worker("24557784L", "Jesus", "Garcia Valiente", 1200, "Alicante", 4, 24));
            Employees.Add(new Worker("94757084E", "Jesica", "Valiente Mora", 1300, "Benidorm", 5, 24));

            EmployeelistView.ItemsSource = Employees;
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeelistView.SelectedItem = null;
            CleanUI();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteEmployee();
            EmployeelistView.SelectedItem = null;
            CleanUI();
            RefreshEmployeeListView();
        }

        private void DepartmentHeadCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (departmentHeadCheckBox.IsChecked == null)
                return;

            bool isChecked = (bool) departmentHeadCheckBox.IsChecked;

            if (isChecked)
                VisibleDepartmentHeadOptions();
            else
                CollapsedDepartmentHeadOptions();
        }

        private void AddScoreButton_Click(object sender, RoutedEventArgs e)
        {
            

            if (EmployeelistView.SelectedItem != null)
            {
                ((Scholar)EmployeelistView.SelectedItem).ExamScores.Add(float.Parse(addScoreTextBox.Text));
                scoresListBox.ItemsSource = null;
                scoresListBox.ItemsSource = ((Scholar)EmployeelistView.SelectedItem).ExamScores;
                threeScoreListBox.ItemsSource = null;
                threeScoreListBox.ItemsSource = ((Scholar)EmployeelistView.SelectedItem).Exams();
            }
            else
            {
                scoresListBox.Items.Add(addScoreTextBox.Text);
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeelistView.SelectedItem == null)
                CreateEmployee();
            else
                UpdateEmployee();

            RefreshEmployeeListView();
        }

        private void CreateEmployee()
        {
            switch (employeeTabControl.SelectedIndex)
            {
                case 1:
                    CreateTrained();
                    break;
                case 2:
                    CreateScholar();
                    break;
                default:
                    CreateWorker();
                    break;
            }
        }

        private void UpdateEmployee()
        {
            DeleteEmployee();
            switch (employeeTabControl.SelectedIndex)
            {
                case 1:
                    CreateTrained();
                    break;
                case 2:
                    CreateScholar();
                    break;
                default:
                    CreateWorker();
                    break;
            }
        }

        private void DeleteEmployee()
        {
            Type type = EmployeelistView.SelectedItem.GetType();

            if (IsWorker(type))
                Employees.Remove((Worker)EmployeelistView.SelectedItem);
            if (IsTrained(type))
                Employees.Remove((Trained)EmployeelistView.SelectedItem);
            if (IsScholar(type))
                Employees.Remove((Scholar)EmployeelistView.SelectedItem);
            if (IsDepartmentHead(type))
                Employees.Remove((DepartmentHead)EmployeelistView.SelectedItem);
        }

        private void CreateWorker()
        {
            Employees.Add(new Worker(
                dniTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                double.Parse(SalaryTextBox.Text),
                destinationComboBox.Text,
                int.Parse(overtimeTextBox.Text),
                double.Parse(overtimePriceTextBox.Text)
            ));
        }

        private void CreateTrained()
        {
            if (IsDepartamentHead())
            {
                CreateDeparmentHead();
                return;
            }

            Employees.Add(new Trained(
                dniTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                double.Parse(SalaryTextBox.Text),
                degreeTitleTextBox.Text,
                double.Parse(plusTextBox.Text),
                departmentQTextBox.Text
            ));
        }

        private bool IsDepartamentHead()
        {
            if (departmentHeadCheckBox.IsChecked == null)
                return false;

            return (bool)departmentHeadCheckBox.IsChecked;
        }

        private void CreateDeparmentHead()
        {
            Employees.Add(new DepartmentHead(
                dniTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                double.Parse(SalaryTextBox.Text),
                degreeTitleTextBox.Text,
                double.Parse(plusTextBox.Text),
                departmentQTextBox.Text,
                int.Parse(wokersTextBox.Text),
                int.Parse(projectsTextBox.Text),
                double.Parse(plusQTextBox.Text)
            ));
        }

        private void CreateScholar()
        {
            Scholar scholar = new Scholar(
                dniTextBox.Text,
                nameTextBox.Text,
                surnameTextBox.Text,
                double.Parse(SalaryTextBox.Text),
                DegreeTextBox.Text,
                CourseTextBox.Text,
                departmentTextBox.Text,
                universityTextBox.Text
            );

            if (scoresListBox.Items.Count > 0)
            {
                foreach (string score in scoresListBox.Items) 
                    scholar.ExamScores.Add(int.Parse(score));
            }

            Employees.Add(scholar);
        }

        private void RefreshEmployeeListView()
        {
            EmployeelistView.ItemsSource = null;
            EmployeelistView.ItemsSource = Employees;
        }

        private void CleanUI()
        {
            employeeTabControl.TabIndex = 0;
            nameTextBox.Text = "";
            surnameTextBox.Text = "";
            dniTextBox.Text = "";
            SalaryTextBox.Text = "";
            CleanTab();
        }

        private void CleanTab()
        {
            destinationComboBox.SelectedItem = null;
            overtimeTextBox.Text = "";
            overtimePriceTextBox.Text = "";
            degreeTitleTextBox.Text = "";
            plusTextBox.Text = "";
            departmentQTextBox.Text = "";
            departmentHeadCheckBox.IsChecked = false;
            DegreeTextBox.Text = "";
            universityTextBox.Text = "";
            CourseTextBox.Text = "";
            departmentTextBox.Text = "";
            avarageScoreTextBlock.Text = "";
            threeScoreListBox.ItemsSource = null;
            threeScoreListBox.Items.Clear();
            scoresListBox.ItemsSource = null;
            scoresListBox.Items.Clear();
            CollapsedDepartmentHeadOptions();
            wokersTextBox.Text = "";
            projectsTextBox.Text = "";
            plusQTextBox.Text = "";
            addScoreTextBox.Text = "";
        }

        private void EmployeelistView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CleanUI();
            if (EmployeelistView.SelectedItem == null)
                return;

            Type type = EmployeelistView.SelectedItem.GetType();

            if (IsWorker(type))
                Featch((Worker)EmployeelistView.SelectedItem);
            if (IsTrained(type))
                Featch((Trained)EmployeelistView.SelectedItem);
            if (IsScholar(type))
                Featch((Scholar)EmployeelistView.SelectedItem);
            if (IsDepartmentHead(type))
                Featch((DepartmentHead)EmployeelistView.SelectedItem);
        }

        private static bool IsWorker(Type type) => type == typeof(Worker);

        private static bool IsTrained(Type type) => type == typeof(Trained);

        private static bool IsScholar(Type type) => type == typeof(Scholar);

        private static bool IsDepartmentHead(Type type) => type == typeof(DepartmentHead);

        private void Featch(Worker employee)
        {
            employeeTabControl.SelectedIndex = 0;
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            dniTextBox.Text = employee.Dni;
            SalaryTextBox.Text = employee.BaseSalary.ToString();
            destinationComboBox.SelectedItem = employee.Destination;
            overtimeTextBox.Text = employee.Overtime.ToString();
            overtimePriceTextBox.Text = employee.OvertimePrice.ToString();
        }

        private void Featch(Trained employee)
        {
            employeeTabControl.SelectedIndex = 1;
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            dniTextBox.Text = employee.Dni;
            SalaryTextBox.Text = employee.BaseSalary.ToString();
            degreeTitleTextBox.Text = employee.Degree;
            plusTextBox.Text = employee.Plus.ToString();
            departmentQTextBox.Text = employee.Department;
            departmentHeadCheckBox.IsChecked = false;
            CollapsedDepartmentHeadOptions();
        }

        private void Featch(Scholar employee)
        {
            employeeTabControl.SelectedIndex = 2;
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            dniTextBox.Text = employee.Dni;
            SalaryTextBox.Text = employee.BaseSalary.ToString();
            DegreeTextBox.Text = employee.Degree;
            universityTextBox.Text = employee.University;
            CourseTextBox.Text = employee.Course;
            departmentTextBox.Text = employee.Department;
            avarageScoreTextBlock.Text = employee.AverageGrade().ToString();
            threeScoreListBox.ItemsSource = employee.Exams();
            scoresListBox.ItemsSource = employee.ExamScores;
        }

        private void Featch(DepartmentHead employee)
        {
            employeeTabControl.SelectedIndex = 1;
            nameTextBox.Text = employee.Name;
            surnameTextBox.Text = employee.Surname;
            dniTextBox.Text = employee.Dni;
            SalaryTextBox.Text = employee.BaseSalary.ToString();
            degreeTitleTextBox.Text = employee.Degree;
            plusTextBox.Text = employee.Plus.ToString();
            departmentQTextBox.Text = employee.Department;
            departmentHeadCheckBox.IsChecked = true;
            VisibleDepartmentHeadOptions();
            wokersTextBox.Text = employee.TotalEmployeesInCharge.ToString();
            projectsTextBox.Text = employee.Projects.ToString();
            plusQTextBox.Text = employee.PlusDH.ToString();
        }

        private void CollapsedDepartmentHeadOptions()
        {
            wokersTextBox.Visibility = Visibility.Collapsed;
            projectsTextBox.Visibility = Visibility.Collapsed;
            plusQTextBox.Visibility = Visibility.Collapsed;
            wokersTextBox.IsReadOnly = true;
            projectsTextBox.IsReadOnly = true;
            plusQTextBox.IsReadOnly = true;
        }

        private void VisibleDepartmentHeadOptions()
        {
            wokersTextBox.Visibility = Visibility.Visible;
            projectsTextBox.Visibility = Visibility.Visible;
            plusQTextBox.Visibility = Visibility.Visible;
            wokersTextBox.IsReadOnly = false;
            projectsTextBox.IsReadOnly = false;
            plusQTextBox.IsReadOnly = false;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
