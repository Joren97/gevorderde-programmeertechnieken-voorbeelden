using Generics_DAL;
using Generics_DAL.Data;
using Generics_DAL.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_WPF.ViewModels
{
    internal class MainViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new VerkoopBeheerEntities());

        public ObservableCollection<Product> Producten { get; set; }
        public bool ComboboxEnabled { get; set; }
        public Orderlijn OrderlijnRecord { get; set; }
        public string Foutmelding { get; set; }
        public string OrderID { get; set; }
        public ObservableCollection<Orderlijn> Orderlijnen { get; set; }

        //geselecteerd orderlijn uit datagrid
        private Orderlijn _selectedOrderlijn;

        public Orderlijn SelectedOrderlijn
        {
            get { return _selectedOrderlijn; }
            set
            {
                _selectedOrderlijn = value;
                OrderlijnRecordInstellen();
                //NotifyPropertyChanged("SelectedOrderlijn");
                //NotifyPropertyChanged(); //omdat er gewerkt wordt met nuget package Propertychanged.Fody hoeft dit niet meer
            }
        }

        public MainViewModel()
        {
            Producten = new ObservableCollection<Product>(unitOfWork.ProductRepo.Ophalen());
            OrderlijnRecordInstellen();
            ComboboxEnabled = true;
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "OrderID" && !int.TryParse(OrderID, out int intOrderID))
                {
                    return "OrderID moet een numerieke waarde zijn!" + Environment.NewLine;
                }

                return "";
            }
        }

        public void Aanpassen()
        {
            if (SelectedOrderlijn != null)
            {
                if (OrderlijnRecord.IsGeldig())
                {
                    #region aanpassen orderlijn

                    unitOfWork.OrderlijnRepo.ToevoegenOfAanpassen(OrderlijnRecord);
                    int ok = unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Orderlijn is niet aangepast");

                    #endregion aanpassen orderlijn
                }
            }
            else
            {
                Foutmelding = "Selecteer een orderlijn!";
            }
        }

        private void RefreshOrderlijnen()
        {
            int i = int.Parse(OrderID);
            List<Orderlijn> listOrderlijnen = unitOfWork.OrderlijnRepo.Ophalen(x => x.OrderID == i).ToList();

            Orderlijnen = new ObservableCollection<Orderlijn>(listOrderlijnen);
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshOrderlijnen();
                Resetten();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        public void Resetten()
        {
            if (this.IsGeldig())
            {
                SelectedOrderlijn = null;
                OrderlijnRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            if (IsGeldig())
            {
                RefreshOrderlijnen();
                if (Orderlijnen == null || Orderlijnen.Count <= 0)
                {
                    Foutmelding = "Er zijn geen orderlijnen gevonden horende bij orderID " + OrderID;
                }
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        public void Verwijderen()
        {
            if (SelectedOrderlijn != null)
            {
                #region verwijder + update velden

                unitOfWork.OrderlijnRepo.Verwijderen(SelectedOrderlijn.OrderlijnID);
                int ok = unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Orderlijn is niet verwijderd");

                #endregion verwijder + update velden
            }
            else
            {
                Foutmelding = "Eerst Orderlijn selecteren";
            }
        }

        public void Toevoegen()
        {
            if (this.IsGeldig())
            {
                OrderlijnRecord.OrderID = int.Parse(OrderID);
                if (OrderlijnRecord.IsGeldig())
                {
                    unitOfWork.OrderlijnRepo.Toevoegen(OrderlijnRecord);
                    int ok = unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Orderlijn is niet toegevoegd");
                }
            }
        }

        private void OrderlijnRecordInstellen()
        {
            if (SelectedOrderlijn != null)
            {
                OrderlijnRecord = SelectedOrderlijn;
                ComboboxEnabled = false;
            }
            else
            {
                OrderlijnRecord = new Orderlijn();
                ComboboxEnabled = true;
            }
        }

        public override bool CanExecute(object parameter)
        {
            //returnwaarde true -> methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Zoeken": return true;
                case "Verwijderen": return true;
                case "Toevoegen": return true;
                case "Aanpassen": return true;
                case "Annuleren": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Zoeken": Zoeken(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Annuleren": Resetten(); break;
            }
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}