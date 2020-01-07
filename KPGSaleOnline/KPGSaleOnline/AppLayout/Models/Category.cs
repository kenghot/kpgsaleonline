using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Internals;

namespace KPGSaleOnline.AppLayout.Models
{
    [Preserve(AllMembers = true)]
    public class Category : INotifyPropertyChanged
    {
        #region Constructor

        public Category(string name, string icon, string description, string updateType, bool isUpdate)
        {
            this.Pages = new List<Template>();
            this.Name = name;
            this.Icon = icon;
            this.Description = description;
            this.UpdateType = updateType;
            this.IsUpdate = isUpdate;
        }

        #endregion

        #region Properties

        // public string Name { get; set; }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        private string _Name;
        public string Icon
        {
            get { return _Icon; }
            set
            {
                if (_Icon != value)
                {
                    _Icon = value;
                    this.OnPropertyChanged("Icon");
                }
            }
        }
        private string _Icon;

        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }
        private string _Description;
        public event PropertyChangedEventHandler PropertyChanged;

       

 

        public List<Template> Pages { get; set; }

        public string TemplateCount
        {
            get
            {
                return this.Pages.Count > 1 ? $"{this.Pages.Count.ToString()} Templates" : $"{this.Pages.Count.ToString()} Template";
            }
        }

        public string UpdateType { get; set; }

        public bool IsUpdate { get; set; }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}