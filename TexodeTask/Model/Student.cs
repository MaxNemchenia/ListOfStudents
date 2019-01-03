using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TexodeTask.Model
{
    public class Student : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        private int id;
        private string firstName;
        private string last;
        private int age;
        private Gender gender;
        #endregion

        #region Propherties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Name
        {
            get { return firstName + " " + last; ; }
        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("Name");
            }
        }

        public string Last
        {
            get { return last; }
            set
            {
                last = value;
                OnPropertyChanged("Name");
            }
        }


        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("StringAge");
            }
        }


        public string StringAge
        {
            get
            {
                if (age % 10 == 1)
                    return age + " год";
                else
                if ((age % 10 == 2 || age % 10 == 3))
                {
                    return age + " года";
                }
                return age + " лет";
            }
        }


        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        #endregion

        #region Validation
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 16) || (Age > 50))
                        {
                            error = "Возраст должен быть больше 16 и меньше 100";

                        }
                        break;
                    case "FirstName":
                        if (firstName == "")
                        {
                            error = "Введите имя";
                        }
                        break;
                    case "Last":
                        if (last == "")
                        {
                            error = "Введите Фамилию";
                        }
                        break;
                    case "Gender":
                        if (Gender != 0 && Gender != (Gender)1)
                        {
                            error = "Введите М или Ж";
                        }
                        break;
                }
                return error;
            }
        }


        public string Error { get; }
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


    public enum Gender
    {
        М = 0,
        Ж
    }
}