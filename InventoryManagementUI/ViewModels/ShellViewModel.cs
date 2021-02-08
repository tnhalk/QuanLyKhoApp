using Caliburn.Micro;
using InventoryManagementUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private string _firstName="tnhalk";

        public string FirstName
        {
            get 
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }
        private string _lastName;


        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corery" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            People.Add(new PersonModel { FirstName = "Nha", LastName = "Le Thanh" });
        }

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        

        public string FullName
        {
            get { return $"{FirstName} {LastName}" ; }
                    
        }

        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
        

        public BindableCollection<PersonModel> People
        {
            get { return _people; }
            set { _people = value; }
        }
        private PersonModel personModel;

        public PersonModel SelectedPerson
        {
            get { return personModel; }
            set 
            { 
                personModel = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) /*=> !String.IsNullOrEmpty(firstName) && !String.IsNullOrWhiteSpace(lastName);*/
        {
            // return !String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName);
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName , string lastName)
        {
            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }
        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}
