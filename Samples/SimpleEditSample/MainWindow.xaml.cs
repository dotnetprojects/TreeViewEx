namespace W7StyleSample
{
    using TreeViewEx.SimpleSample.ViewModel;
    #region

    using W7StyleSample.Model;

    #endregion

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constructors and Destructors

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();

            InitializeComponent();
        }

        #endregion

        private void TreeViewExItem_OnEditing(object sender, System.Windows.RoutedEventArgs e)
        {
            var tvei = (System.Windows.Controls.TreeViewExItem)sender;
            Node nodeContext = (Node)tvei.DataContext;
            var viewModel = (MainWindowViewModel)DataContext;
            viewModel.EditedText = $"{nodeContext.Name} is being edited.";
            e.Handled = true;
        }

        private void TreeViewExItem_OnEdited(object sender, System.Windows.RoutedEventArgs e)
        {
            var tvei = (System.Windows.Controls.TreeViewExItem)sender;
            Node nodeContext = (Node)tvei.DataContext;
            var viewModel = (MainWindowViewModel)DataContext;
            viewModel.EditedText = $"{nodeContext.Name} was edited.";
            e.Handled = true;
        }
    }
}