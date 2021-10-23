using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_Grup2.Application.DTOs
{
    public class FilterDto
    {
        private int _pageNumber;
        public string Name { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = _pageNumber <= 0 ? 1 : _pageNumber;
            }
        }
        public int PageSize { get; set; } = 50;
    }
}
