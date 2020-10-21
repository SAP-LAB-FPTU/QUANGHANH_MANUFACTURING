namespace QUANGHANH_MANUFACTURING.Models
{
    public class DocumentaryDB: Documentary
    {
        public string stringtype { get; set; }
        public string stringstatus { get; set; }
        public string stringdate { get; set; }
        public string department_name { get; set; }
        public LinkIdCode linkIdCode { get; set; }
        public string documentary_name { get; set; }
    }

    public class LinkIdCode
    {
        public string link { get; set; }
        public int id { get; set; }
        public string code { get; set; }
    }
}