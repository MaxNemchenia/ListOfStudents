using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using TexodeTask.Model;
using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace TexodeTask.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Student selectedStudent;
        #endregion

        #region Properties
        public ObservableCollection<Student> Students { get; set; }

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        #endregion

        #region Constructors
        public ApplicationViewModel()
        {
            Students = new ObservableCollection<Student>();
            var Data = XMlReader.readStudents(@".\Students.xml").ToArray();
            foreach (var student in Data)
            {
                Students.Add(student);
            }

            AddCommand = new DelegateCommand(AddStudent);
        }
        #endregion

        #region Buttons
        public ICommand RemoveCommand => new DelegateCommand(o => RemoveStudents((Collection<object>)o));
        public ICommand AddCommand { get; private set; }


        void AddStudent(object obj)
        {
            Student student = new Student() { FirstName = "", Last = ""};
            Students.Insert(0, student);
            SelectedStudent = student;
        }


        private void RemoveStudents(Collection<object> obj)
        {
            var result = MessageBox.Show("Удалить выбранные элементы?", "Remove", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                List<Student> list = obj.Select(e => (Student)e).ToList();
                list.ForEach(student => Students.Remove(student));
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }

}
