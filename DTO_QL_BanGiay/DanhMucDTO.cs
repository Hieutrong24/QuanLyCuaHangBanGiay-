namespace DTO_QL_BanGiay
{
    public class DanhMucDTO
    {
        public long MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        public DanhMucDTO() { }

        public DanhMucDTO(long maDanhMuc, string tenDanhMuc)
        {
            MaDanhMuc = maDanhMuc;
            TenDanhMuc = tenDanhMuc;
        }
    }
}
