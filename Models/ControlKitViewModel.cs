using System;

namespace GeStock {
	
	public class ControlKitViewModel:AViewModel {

		public ControlKit ControlKit { get; private set; }

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

		string elements;
		public string Elements {

			set {
				if (elements != value) {
					elements = value;

					OnPropertyChanged ("Elements");
				}
			}

			get { return elements; }
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
		
		public ControlKitViewModel () {
		}

		public ControlKitViewModel (ControlKit controlKit) {

			ControlKit = controlKit;

			name = ControlKit.Name;
			elements = ControlKit.Elements;
			description = ControlKit.Description;
		}

		public void Restore(ControlKit originalControlKit) {

			Name = ControlKit.Name = originalControlKit.Name;
			Elements = ControlKit.Elements = originalControlKit.Elements;
			Description = ControlKit.Description = originalControlKit.Description;
		}

		public void Save() {

			ControlKit.Name = name;
			ControlKit.Elements = elements;
			ControlKit.Description = description;

			App.Database.Save (ControlKit);
		}
	}
}

