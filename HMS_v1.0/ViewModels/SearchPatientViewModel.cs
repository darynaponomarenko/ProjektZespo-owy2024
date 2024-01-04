using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Commands;
using HMS_v1._0.Messages;
using HMS_v1._0.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class SearchPatientViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        readonly IMapper mapper = MapperConfig.InitializeAutomapper();
        

        public SearchPatientViewModel()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7057/")
            };
            SelectPatientCommand = new SelectPatientCommand(this);
            CloseAction = null!;
        }
        public SelectPatientCommand SelectPatientCommand { get; set; }
        public Action CloseAction { get; set; }
        private ObservableCollection<PatientModel> patients;

        public ObservableCollection<PatientModel> Patients
        {
            get { return patients; }
            set
            {
                if (patients != value)
                {
                    patients = value;
                    OnPropertyChanged(nameof(Patients));
                }
            }
        }

        private PatientModel selectedPatient = null!;
        public PatientModel SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (selectedPatient != value)
                {
                    selectedPatient = value;
                    OnPropertyChanged(nameof(SelectedPatient));
                }
            }
        }

        private string searchTerm = null!;
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                if (searchTerm != value)
                {
                    searchTerm = value;
                    OnPropertyChanged(nameof(SearchTerm));
                    FilterPatients(); 
                }
            }
        }

       
        private async void FilterPatients()
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                await LoadPatientsAsync();
            }
            else
            {
                var searchTerms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var filteredPatients = patients
                    .Where(patient =>
                        searchTerms.All(term =>
                            patient.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                            patient.Surname.Contains(term, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
                Patients = new ObservableCollection<PatientModel>(filteredPatients);
            }
        }


        public async Task LoadPatientsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/patient");
                response.EnsureSuccessStatusCode();

                var patientsFromApi = await response.Content.ReadAsAsync<List<Patient>>();

                var patientModel = patientsFromApi.Select(p => new PatientModel
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Pesel = p.Pesel,
                    DateOfBirth = p.DateOfBirth,
                    Id = p.Id
                }).ToList();

                Patients = new ObservableCollection<PatientModel>(patientModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void SelectPatient()
        {
            if(SelectedPatient != null)
            {
                Messenger.Default.Send(new NewlyAddedPatientMessage { PatientName = SelectedPatient.Name, Pesel = SelectedPatient.Pesel, PatientAge = (int)((DateTime.Now - SelectedPatient.DateOfBirth).TotalDays / 365.242199), PatientId = SelectedPatient.Id });
                Messenger.Default.Send(SelectedPatient, "PatientMessage");
                CloseAction();
            }
            else
            {
                MessageBox.Show("Wybierz pacjenta!");
            }
        }

    }
}
