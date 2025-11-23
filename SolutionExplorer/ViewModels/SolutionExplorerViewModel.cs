using SolutionExplorer.DomainModels;
using System.Collections.ObjectModel;

namespace SolutionExplorer.ViewModels
{
    internal class SolutionExplorerViewModel
    {
        public ObservableCollection<SolutionExplorerItem> Items { get; set; } = new();
    }
}
