using System.ComponentModel;

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
    }  
}