using System.ComponentModel;
using System.Windows.Input;
using MauiAppFit.Models;

namespace MauiAppFit.ViewModels
{
    [QueryProperty("GetQueryID", "ID_Parameter")]
    public class ActivityRegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string description, observations;
        int id;
        DateTime date;
        double? weight;

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

        public double? Weight
        {
            get => weight;
            set
            {
                weight = value;
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
                Weight = null;
                Observations = string.Empty;
            });
        }

        public ICommand SaveActivity
        {
            get => new Command(async () =>
            {
                try
                {
                    Activity model = new Activity()
                    {
                        Description = this.Description,
                        Date = this.Date,
                        Weight = this.Weight,
                        Observations = this.Observations
                    };

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);
                    }
                    else
                    {
                        model.ID = this.Id;

                        await App.Database.Update(model);
                    }

                    await Application.Current.MainPage.DisplayAlert("Saved", "Saved exercise", "OK");

                    await Shell.Current.GoToAsync("//MyActivities");

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }

        public ICommand ShowActivity
        {
            get => new Command<int>(async (int id) =>
            {
                try
                {
                    Activity model = await App.Database.GetById(id);

                    this.Id = model.ID;
                    this.Description = model.Description;
                    this.Weight = model.Weight;
                    this.Date = model.Date;
                    this.Observations = model.Observations;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }
    }
}
