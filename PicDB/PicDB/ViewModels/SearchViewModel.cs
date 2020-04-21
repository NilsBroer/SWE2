using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private String _search;

        public SearchViewModel() { }
        public SearchViewModel(String searchText)
        {
            Search = searchText;
            HasMultiple = searchText.Contains(' ');
            IsSpecific = searchText.Contains(':');

            if (HasMultiple)
                MultipleSearch = searchText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (IsSpecific) //WIP
                SpecificSearch = searchText.Split(' ', ':', StringSplitOptions.RemoveEmptyEntries);                
        }

        public bool IsActive { get; set; }
        public bool HasMultiple { get; set; }
        public bool IsSpecific { get; set; }
        public String Search
        {
            get => _search;
            set
            {
                _search = value;
                IsActive = !String.IsNullOrEmpty(_search);
            }
        }
        public String[] MultipleSearch { get; set; } = null;
        public String[] SpecificSearch { get; set; } = null;
    }
}
