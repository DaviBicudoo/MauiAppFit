using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Android.Views;

namespace MauiAppFit.ViewModels
{
    [QueryProperty("GetQueryID", "ID_Parameter")]
    public class ActivityRegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanged;

        string description, observations;
        int id;
        DateTime date;
        double? weights;

        public string GetQueryID
        {
            set
            {
                int ID_Parameter = Convert.ToInt32(Uri.UnescapeDataString(value));

                ShowActivity.Execute(ID_Parameter);
            }
        }


        public string Description
        {
            get => description;
            set
            {
                description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public string Observations
        {
            get => observations;
            set
            {
                observations = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Observations"));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ID"));
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public double? Weights
        {
            get => weights;
            set
            {
                weights = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weights"));
            }
        }

        public ICommand NewActivity
        {
            get => new Command(() =>
            {
                Id = 0;
                Description = String.Empty;
                Date = DateTime.Now;
                Weights = null;
                Observations = string.Empty;
            });
        }
    }
}
