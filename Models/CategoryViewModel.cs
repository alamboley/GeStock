using System;
using System.ComponentModel;

namespace GeStock {

	public class CategoryViewModel:AViewModel {

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

		string description;
		public string Description {

			set {
				if (description != value) {
					description = value;

					OnPropertyChanged ("Description");
				}
			}

			get { return description; }
		}

		public CategoryViewModel () {
		}

		public CategoryViewModel (Category category) {

			Category = category;

			name = Category.Name;
			description = Category.Description;
		}

		public void Save() {

			Category.Name = name;
			Category.Description = description;

			App.Database.Save (Category);
		}
	}
}

