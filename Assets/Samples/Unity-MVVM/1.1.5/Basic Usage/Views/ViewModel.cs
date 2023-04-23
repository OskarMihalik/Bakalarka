using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMVVM.ViewModel;

namespace UnityMVVM.Samples.UsingViews
{
    public class ViewModel : ViewModelBase
    {
        public Dictionary<string, string> PlcValues
        {
            get { return plcValues; }
            set
            {
                if (value == plcValues) return;
                
                plcValues = value;
                NotifyPropertyChanged(nameof(PlcValues));
            }
        }

        [SerializeField]
        private Dictionary<string, string> plcValues;

        // public void ToggleViewVisibility()
        // {
        //     PlcValues = !PlcValues;
        // }
    }
}
