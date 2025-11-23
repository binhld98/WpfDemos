using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }
    }
}
