using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Technoservice4.DbSingletone;

namespace Technoservice4.ViewModel
{
    public class MainWindowVIewModel : BaseViewModel
    {
        private ObservableCollection<Request> _requests;
        private Request _selectedRequest;
        private Request _request;

        public Request Request
        {
            get => _request;
            set
            {
                _request = value;
                OnPropertyChanged(nameof(Request));
            }
        }


        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        public Request SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }

        public MainWindowVIewModel()
        {
            Requests = new ObservableCollection<Request>();
            LoadData();
        }

        public void LoadData()
        {
            if (Requests.Count > 0)
            {
                Requests.Clear();
            }
            var res = DbSingletone.DbSingletone.Db.Request.ToList();
            res.ForEach(x => Requests?.Add(x));
        }

        private int _requestId;
        public int RequestId
        {
            get => _requestId;
            set
            {
                _requestId = value;
                OnPropertyChanged(nameof(RequestId));
            }
        }

        private string _equipment;
        public string Equipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                OnPropertyChanged(nameof(Equipment));
            }
        }

        private int _equipmentTypeId;
        public int EquipmentTypeId
        {
            get => _equipmentTypeId;
            set
            {
                _equipmentTypeId = value;
                OnPropertyChanged(nameof(EquipmentTypeId));
            }
        }

        private int _statusId;


        public int StatusId
        {
            get => _statusId;
            set
            {
                _statusId = value;
                OnPropertyChanged(nameof(StatusId));
            }
        }

        private string _problemDescription;
        public string ProblemDescription
        {
            get => _problemDescription;
            set
            {
                _problemDescription = value;
                OnPropertyChanged(nameof(ProblemDescription));
            }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            set
            {
                _clientId = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private int? _masterId;
        public int? MasterId
        {
            get => _masterId;
            set
            {
                _masterId = value;
                OnPropertyChanged(nameof(MasterId));
            }
        }

        public void DeleteRequest()
        {

            using (var Db = new TecnoserviceEntities())
            {
                var ers = MessageBox.Show("Вы действительно хотите удалить данные?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (ers == MessageBoxResult.Yes)
                {
                    try
                    {
                        var del = Db.Request.FirstOrDefault(a => a.RequestId == SelectedRequest.RequestId);
                        Db.Request.Remove(del);
                        Db.SaveChanges();
                        MessageBox.Show("Данные успешно удалены!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }
    }
}
