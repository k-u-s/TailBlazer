using System.Collections.Generic;
using TailBlazer.LogViewer.Views.Searching;

namespace TailBlazer.LogViewer.Views.Tail
{
    public sealed class TailViewState
    {
        public static readonly TailViewState Empty = new TailViewState();

        public string FileName { get; }
        public string SelectedSearch { get; }

        public IEnumerable<SearchState> SearchItems { get; }

        public TailViewState(string fileName, string selectedSearch, IEnumerable<SearchState> searchItems)
        {
            FileName = fileName;
            SelectedSearch = selectedSearch;
            SearchItems = searchItems;
        }

        private TailViewState()
        {
            
        }
    }
}