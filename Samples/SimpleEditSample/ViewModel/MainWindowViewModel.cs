﻿using DragNDropSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using W7StyleSample.Model;

namespace TreeViewEx.SimpleSample.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _isEditingCommand;
        public ICommand IsEditingCommand
        {
            get
            {
                if (_isEditingCommand == null)
                    _isEditingCommand = new RelayCommand(EditItem);
                return _isEditingCommand;
            }
        }

        public Node FirstNode { get; set; }
        public ObservableCollection<Node> SelectedItems { get; set; }
        private string _editedText;
        public string EditedText 
        {
            get => _editedText;
            set
            {
                _editedText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditedText)));
            }
        }
        public bool IsButtonEditEnabled
        {
            get { return SelectedItems.Count == 1; }
        }

        public MainWindowViewModel()
        {
            SelectedItems = new ObservableCollection<Node>();
            FirstNode = new Node { Name = "element" };
            var first1 = new Node { Name = "element1" };
            var first2 = new Node { Name = "element2" };
            var first11 = new Node { Name = "element11" };
            var first12 = new Node { Name = "element12" };
            var first13 = new Node { Name = "element13", IsExpandedValue = false };
            var first14 = new Node { Name = "element14", IsExpandedValue = false };
            var first15 = new Node { Name = "element15" };
            var first131 = new Node { Name = "element131" };
            var first132 = new Node { Name = "element132" };

            for (int i = 1; i <= 50; i++)
            {
                first14.Children.Add(new Node { Name = "element14_" + i });
            }

            FirstNode.Children.Add(first1);
            FirstNode.Children.Add(first2);
            first1.Children.Add(first11);
            first1.Children.Add(first12);
            first1.Children.Add(first13);
            first1.Children.Add(first14);
            first1.Children.Add(first15);
            first13.Children.Add(first131);
            first13.Children.Add(first132);
        }

        private void EditItem(object parameter)
        {
            if (SelectedItems.Any())
                SelectedItems[0].IsEditingValue = !SelectedItems[0].IsEditingValue;
        }
    }
}
