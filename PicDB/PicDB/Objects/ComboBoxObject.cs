using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace PicDB.Objects
{
    ///
    /// Class for the ComboBox Entries
    ///
    public class ComboBox
    {
        ///
        /// Name
        ///
        public String Name { get; set; }

        ///
        /// Different Options
        ///
        public List<string> Options { get; set; }
    }
}