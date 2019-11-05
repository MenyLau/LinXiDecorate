using System;
using System.Collections.Generic;
using System.Text;

namespace LinXiDecorate.WPF.ViewModel
{
    public class QuoteItemModel
    {
        private string name;
        private QuoteType type;
        private string info;

    }

    public enum QuoteType
    {
        CAILIAO,
        RENGONG,
        OTHER
    }
}
