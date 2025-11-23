using System.Collections.ObjectModel;

namespace SolutionExplorer.DomainModels
{
    internal class SolutionExplorerItem : BaseDomainModel
    {
        private string _Name = "";
        public string Name { get => _Name; set => Set(ref _Name, value); }

        private bool _IsFolder = false;
        public bool IsFolder { get => _IsFolder; set => Set(ref _IsFolder, value); }

        private bool _IsExpanded = false;
        public bool IsExpanded { get => _IsExpanded; set => Set(ref _IsExpanded, value); }

        private bool _IsSelected = false;
        public bool IsSelected { get => _IsSelected; set => Set(ref _IsSelected, value); }

        private bool _IsEditting = false;
        public bool IsEditting { get => _IsEditting; set => Set(ref _IsEditting, value); }

        public string Icon { get => IsFolder ? "/Assets/folder.svg" : "/Assets/file.svg"; }

        public ObservableCollection<SolutionExplorerItem> Children { get; set; } = new();
    }
}
