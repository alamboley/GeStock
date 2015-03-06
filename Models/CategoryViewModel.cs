using System;
using System.ComponentModel;

namespace GeStock {

	public class CategoryViewModel {

		public event PropertyChangedEventHandler PropertyChanged;

		public Category Category { get; private set; }

		string name;
		public string Name {

			set {
				if (name != value) {
					name = value;

					OnPropertyChanged ("Name");
				}
			}

			get { return name; }
		}

		public CategoryViewModel () {
		}

		public CategoryViewModel (Category category) {

			Category = category;

			name = Category.Name;
		}

		public void Save() {

			Category.Name = name;

			App.Database.Save (Category);
		}
		protected void OnPropertyChanged(string propertyName) {

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

