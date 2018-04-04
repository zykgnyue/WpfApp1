//using System.ComponentModel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    internal class Student:INotifyPropertyChanged
    {
        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set
            {
                lastname = value;
                if (PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(
                                              this,
                                              new PropertyChangedEventArgs("LastName"));
                
}
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private int studentID;
        public int StudentID {
            get=>studentID;
            set {
                if (studentID != value)
                {
                    studentID=value;
                    OnPropertyChanged();
                }
            }
        }

        private string emailAddress;
        public string EmailAddress {
            get=>emailAddress;
            set {
                if(this.emailAddress != value)
                {
                    emailAddress = value;
                    NotifyPropertyChanged();
                    //OnPropertyChanged(); //C#6.0
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged<T>([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // any type can use
        private int studentFee;
        public int StudentFee {
            get =>studentFee;
            set
            {
                if(value!=this.studentFee)
                {
                    studentFee = value;
                    OnPropertyChanged();
                }
            }
        }



    }
}