using System;
using System.Collections.Generic;
using System.Text;

namespace LinXiDecorate.WPF.ViewModel
{
    public class RoomModel
    {
        private RoomType type;

        private List<QuoteItemModel> quoteList = null;

        public RoomType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public List<QuoteItemModel> QuoteList
        {
            get
            {
                return quoteList;
            }

            set
            {
                quoteList = value;
            }
        }
    }

    public enum RoomType
    {
        WOSHI,
        WEISHENGJIAN,
        KETING,
        CHUFANG,
        YANGTAI,
        CANTING
    }
}
