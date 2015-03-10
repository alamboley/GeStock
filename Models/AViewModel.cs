using System;
using System.ComponentModel;

namespace GeStock {

	abstract public class AViewModel:INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		public AViewModel () {
		}

		protected void OnPropertyChanged(string propertyName) {

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

