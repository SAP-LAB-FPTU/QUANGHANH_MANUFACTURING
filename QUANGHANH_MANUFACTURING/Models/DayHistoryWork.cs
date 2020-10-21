using System;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class DayHistoryWork
    {
        public DateTime ngayDiemDanh { get; set; }
        public string calamViec { get; set; }
        public string ghiChu { get; set; }
        public DayHistoryWork() { }
        public DayHistoryWork(DateTime ngayDiemDanh, string calamViec, string ghiChu)
        {
            this.ngayDiemDanh = ngayDiemDanh;
            this.calamViec = calamViec;
            this.ghiChu = ghiChu;
        }
    }
}