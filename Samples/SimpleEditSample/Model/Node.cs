namespace W7StyleSample.Model
{
	#region

	using System.Collections.ObjectModel;
    using System.ComponentModel;

    #endregion

    /// <summary>
    /// Model for testing
    /// </summary>
    public class Node : INotifyPropertyChanged
	{
		#region Constructors and Destructors

		public Node()
		{
			Children = new ObservableCollection<Node>();
            IsExpandedValue = true;
		}

		#endregion

		#region Public Properties

		public ObservableCollection<Node> Children { get; set; }
        string name;
        public string Name { get { return name; } set { name = value; } }
        public bool IsExpandedValue { get; set; }
		private bool _isEditingValue;

		public event PropertyChangedEventHandler PropertyChanged;

		public bool IsEditingValue 
		{
			get => _isEditingValue;
			set
			{
				_isEditingValue = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEditingValue)));
			}
		}
		#endregion

		#region Public Methods

		public override string ToString()
		{
			return Name;
		}

		#endregion
	}
}