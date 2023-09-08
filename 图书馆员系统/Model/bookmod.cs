using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class bookmod : INotifyPropertyChanged
    {
        private int id;
        private string bookname;
        private int typeid;
        private int price;
        private int num;
        private DateTime indate;
        private string pricture;

        public int Id {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Bookname {
            get
            {
                return bookname;
            }
            set
            {
                bookname = value;
                OnPropertyChanged();
            }

        }
        public int Typeid {

            get
            {
                return typeid;
            }
            set
            {
                typeid = value;
                OnPropertyChanged();
            }
        }
        public int Price {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        public int Num {
            get
            {
                return num;
            }
            set
            {
                num = value;
                OnPropertyChanged();
            }

        }
        public DateTime Indate {
            get
            {
                return indate;
            }
            set
            {
                indate = value;
                OnPropertyChanged();
            }

        }
        public string Pricture {

            get
            {
                return pricture;
            }
            set
            {
                pricture = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
