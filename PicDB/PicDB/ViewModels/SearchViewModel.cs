﻿using System;
using System.Collections.Generic;
using System.Text;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private String _search;

        public SearchViewModel() { }
        public SearchViewModel(String searchtext)
        {
            Search = searchtext;
            HasMultiple = searchtext.Contains(' ');
            IsSpecific = searchtext.Contains(':');

            if (HasMultiple)
                MultipleSearch = searchtext.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (IsSpecific) //WIP
                SpecificSearch = searchtext.Split(' ', ':', StringSplitOptions.RemoveEmptyEntries);                
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
