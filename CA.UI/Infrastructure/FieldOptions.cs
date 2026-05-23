using System;
using System.Collections.Generic;
using System.Text;

namespace CA.UI
{
    [Serializable]
    public class FieldOptions
    {
        public int SizeOfField{get;set;}
        public bool ShowMatrixBorders { get; set; }
        public FieldOptions(bool _vizSitka, int RozmirPolya)
        {
            this.ShowMatrixBorders = _vizSitka;
            this.SizeOfField = RozmirPolya;
        }
    }
}
