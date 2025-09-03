using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiAppFit.Models;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Platform;

namespace MauiAppFit.ViewModels
{
    internal class ActivityListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchParameter { get; set; }
        bool isUpdating = false;

        public bool IsUpdating
        {
            get => isUpdating;
            set
            {
                isUpdating = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsUpdating"));
            }
        }

        ObservableCollection<Activity> activityList = new ObservableCollection<Activity>();

        public ObservableCollection<Activity> ActivityList
        {
            get => ActivityList;
            set => activityList = value;
        }

        public ICommand UpdateList
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        if (IsUpdating)
                        {
                            return;
                        }

                        IsUpdating = true;

                        List<Activity> tmp = await App.Database.GetAllRows();

                        activityList.Clear();

                        tmp.ForEach(i => ActivityList.Add(i));
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlert("Ops", ex.Message, "OK");
                    }
                    finally
                    {
                        isUpdating = false;
                    }
                });
            }
        }
    }
}
