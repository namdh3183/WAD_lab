namespace lab1rework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONDATHANG")]
    public partial class DONDATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONDATHANG()
        {
            CHITIETDONTHANGs = new HashSet<CHITIETDONTHANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDonHang { get; set; }

        public bool? Dathanhtoan { get; set; }

        public bool? Tinhtranggiaohang { get; set; }

        public DateTime? Ngaydat { get; set; }

        public DateTime? Ngaygiao { get; set; }

        public int? MaKH { get; set; }

        public string DiaChiGH { get; set; }
        public string DienThoaiGH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONTHANG> CHITIETDONTHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
