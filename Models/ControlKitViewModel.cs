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
		
		public ControlKitViewModel () {
		}

		public ControlKitViewModel (ControlKit controlKit) {

			ControlKit = controlKit;

			name = ControlKit.Name;
			elements = ControlKit.Elements;
		}

		public void Restore(ControlKit originalControlKit) {

			Name = ControlKit.Name = originalControlKit.Name;
			Elements = ControlKit.Elements = originalControlKit.Elements;
		}

		public void Save() {

			ControlKit.Name = name;
			ControlKit.Elements = elements;

			App.Database.Save (ControlKit);
		}
	}
}

