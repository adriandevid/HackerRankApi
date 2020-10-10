using System.Collections.Generic;

namespace api.Entitys
{
    class Page
    {
        public string  PageNumber { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Data> Data { get; set; }
    }
}