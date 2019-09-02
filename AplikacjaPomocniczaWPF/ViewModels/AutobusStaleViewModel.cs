using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaPomocniczaWPF.ViewModels
{
    class AutobusStaleViewModel
    {
        private AutobusStaleViewModel instance = null;

        public AutobusStaleViewModel Instance { get { return instance ?? (instance = new AutobusStaleViewModel()); } }

        private AutobusStaleViewModel() { }
    }
}
