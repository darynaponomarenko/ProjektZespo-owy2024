using AutoMapper;
using GalaSoft.MvvmLight.Messaging;
using HMS_v1._0.ApiService;
using HMS_v1._0.Messages;
using HMS_v1._0.Models;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace HMS_v1._0.ViewModels
{
    public class SearchCodeViewModel : ViewModelBase
    {
        private readonly HttpClient httpClient;
        IMapper mapper = MapperConfig.InitializeAutomapper();

        public SearchCodeViewModel()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7057/");
        }

        public Action CloseAction { get; set; }

        private ObservableCollection<ICD10sModel> codes;
        public ObservableCollection<ICD10sModel> Codes
        {
            get { return codes; }
            set
            {
                if (codes != value)
                {
                    codes = value;
                    OnPropertyChanged(nameof(Codes));
                }
            }
        }

        private PatientModel selectedCode;
        public PatientModel SelectedCode
        {
            get { return selectedCode; }
            set
            {
                if (selectedCode != value)
                {
                    selectedCode = value;
                    OnPropertyChanged(nameof(SelectedCode));
                }
            }
        }

        private string searchTerm;
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                if (searchTerm != value)
                {
                    searchTerm = value;
                    OnPropertyChanged(nameof(SearchTerm));
                    FilterCodes(); 
                }
            }
        }

        private void FilterCodes()
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadCodesAsync();
            }
            else
            {
                var searchTerms = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var filteredICD10Codes = new List<ICD10sModel>();

                foreach(var code in codes)
                {
                    bool allTermsFound = true;

                    foreach (var term in searchTerms)
                    {
                        if (!(code.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                              code.Code.Contains(term, StringComparison.OrdinalIgnoreCase)))
                        {
                            allTermsFound = false;
                            break;
                        }
                    }

                    if (allTermsFound)
                    {
                        filteredICD10Codes.Add(code);
                    }

                }

               /* var filteredCodes = codes
                    .Where(code =>
                    searchTerms.All(term =>
                    code.Description.Split(' ').Any(word =>
                        word.Equals(term, StringComparison.OrdinalIgnoreCase)) ||
                    code.Code.Split(' ').Any(word =>
                        word.Equals(term, StringComparison.OrdinalIgnoreCase))))
                    .ToList();*/
                Codes = new ObservableCollection<ICD10sModel>(filteredICD10Codes);
            }
        }

        public async Task LoadCodesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/codes");
                response.EnsureSuccessStatusCode();

                var codesFromApi = await response.Content.ReadAsAsync<List<ICD10>>();
                var icd10Codes = mapper.Map<List<ICD10sModel>>(codesFromApi);
                Codes = new ObservableCollection<ICD10sModel>(icd10Codes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ICD-10 codes: {ex.Message}");
            }
        }

        public void SelectCode()
        {
            if (SelectedCode != null)
            {
                //Messenger.Default.Send(new NewlyAddedPatientMessage { PatientName = SelectedPatient.Name, Pesel = SelectedPatient.Pesel, PatientAge = (int)((DateTime.Now - SelectedPatient.DateOfBirth).TotalDays / 365.242199) });
                CloseAction();
            }
            else
            {
                MessageBox.Show("Wybierz pacjenta!");
            }
        }

    }
}
