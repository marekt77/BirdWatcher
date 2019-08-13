using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using BirdWatcherMobileApp.Models;
using BirdWatcherMobileApp.Services;

namespace BirdWatcherMobileApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //Local data serivce for known birds.
        //public IKnownBirdsService<Bird> BirdService => DependencyService.Get<IKnownBirdsService<Bird>>() ?? new MockBirdExampleDataService();
        public IKnownBirdsService<Bird> BirdService => DependencyService.Get<IKnownBirdsService<Bird>>() ?? new KnownBirdsDataService();

        public IBirdWatcherService<BirdWatcher> BirdWatcherService => DependencyService.Get<IBirdWatcherService<BirdWatcher>>() ?? new BirdWatcherDataService();

        public IBirdWatcherLogService<BirdLogRootObject, BirdLog> BirdWatcherLogService => DependencyService.Get<IBirdWatcherLogService<BirdLogRootObject, BirdLog>>() ?? new BirdWatcherLogDataService();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
