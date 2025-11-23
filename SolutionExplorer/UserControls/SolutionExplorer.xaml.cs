using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SolutionExplorer.UserControls
{
    /// <summary>
    /// Interaction logic for SolutionExplorer.xaml
    /// </summary>
    public partial class SolutionExplorer : UserControl
    {
        public SolutionExplorer()
        {
            InitializeComponent();

            #region Init Data
            var vm = new ViewModels.SolutionExplorerViewModel();
            this.DataContext = vm;

            vm.Items.Add(new DomainModels.SolutionExplorerItem()
            {
                Name = "Sample Folder 1",
                IsFolder = true,
                IsExpanded = true,
                Children =
                {
                    new DomainModels.SolutionExplorerItem()
                    {
                        Name = "Sample File 1.txt",
                        IsFolder = false
                    },
                    new DomainModels.SolutionExplorerItem()
                    {
                        Name = "Sample File 2.txt",
                        IsFolder = false
                    },
                    new DomainModels.SolutionExplorerItem()
                    {
                        Name = "Sample Folder 2",
                        IsFolder = true,
                        Children =
                        {
                            new DomainModels.SolutionExplorerItem()
                            {
                                Name = "Sample File 3.txt",
                                IsFolder = false
                            }
                        }
                    }
                }
            });

            vm.Items.Add(new DomainModels.SolutionExplorerItem()
            {
                Name = "Sample Folder 3",
                IsFolder = true
            });

            vm.Items.Add(new DomainModels.SolutionExplorerItem()
            {
                Name = "Sample File 4.txt",
                IsFolder = false
            });
            #endregion
        }

        private void HeaderedItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (sender is not Border border)
                return;

            if (border.DataContext is not DomainModels.SolutionExplorerItem item)
                return;

            item.IsSelected = true;
        }

        private void RenameMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuItem menuItem || menuItem.DataContext is not DomainModels.SolutionExplorerItem item)
                return;

            item.IsEditting = true;
        }

        private void CaptionEditMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.DataContext is not DomainModels.SolutionExplorerItem item)
                return;

            switch (e.Key)
            {
                case Key.Enter:
                    textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
                    item.IsEditting = false;
                    break;

                case Key.Escape:
                    textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
                    item.IsEditting = false;
                    break;
            }
        }

        private void CaptionEditMode_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.DataContext is not DomainModels.SolutionExplorerItem item)
                return;

            item.IsEditting = false;
        }

        private void CaptionEditMode_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is not TextBox textBox || textBox.DataContext is not DomainModels.SolutionExplorerItem item)
                return;

            if (item.IsEditting)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    textBox.Focus();
                    textBox.SelectAll();
                }));
            }
        }
    }
}
