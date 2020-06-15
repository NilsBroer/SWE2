using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using PicDB.Models;

namespace PicDB.ViewModels
{
    ///
    /// ViewModel for the Search UI Element
    ///
    public class SearchViewModel : BaseViewModel
    {
        private String _search;

        ///
        /// Empty Constructor
        ///
        public SearchViewModel() { }

        ///
        /// Constructor for existing Data
        ///
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

        ///
        /// Whether search is being modified
        ///
        public bool IsActive { get; set; }

        ///
        /// Whether there are multiple search terms
        ///
        public bool HasMultiple { get; set; }

        ///
        /// Whether there are search terms for a specific category only
        ///
        public bool IsSpecific { get; set; }

        ///
        /// gets the String that is being searched for
        ///
        public String Search
        {
            get => _search;
            set
            {
                _search = value;
                IsActive = !String.IsNullOrEmpty(_search) && !Regex.IsMatch(_search, @"^ *$");
            }
        }

        ///
        /// Gets the Strings for a Multiple Term Search
        ///
        public String[] MultipleSearch { get; set; } = null;

        ///
        /// Gets the Strings for a Specific Term Search
        ///
        public String[] SpecificSearch { get; set; } = null;
    }
}
