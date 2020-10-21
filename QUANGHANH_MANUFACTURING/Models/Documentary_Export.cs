using System;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class Documentary_Export
    {
        public DateTime date_created { get; set; }
        public string documentary_code { get; set; }
        public string person_created { get; set; }
        public string reason { get; set; }
        public string out_in_come{ get; set; }
        public int count { get; set; }
        public Documentary_Export() { }
        public Documentary_Export(DateTime date_created, string documentary_code, string person_created, string reason, string out_in_come, int count)
        {
            this.date_created = date_created;
            this.documentary_code = documentary_code;
            this.person_created = person_created;
            this.reason = reason;
            this.out_in_come = out_in_come;
            this.count = count;
        }
    }
}