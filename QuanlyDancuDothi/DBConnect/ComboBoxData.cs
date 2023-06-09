using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyDancuDothi.DBConnect
{
    public class ComboBoxData
    {
        public List<string> TinhThanh()
        {
            return new List<string> 
            {
                "Bình Dương", "Đồng Nai", "Hà Nội", "TP. Hồ Chí Minh"
            };
        }
        public List<string> QuanHuyenBinhDuong()
        {
            return new List<string>
            {
                "Thủ Dầu Một", "Bến Cát", "Dĩ An", "Thuận An"
            };
        }
        public List<string> PhuongXaThuDauMot()
        {
            return new List<string>
            {
                "Phú Cường", "Hiệp Thành", "Phú Hòa", "Phú Lợi"
            };
        }
        public List<string> PhuongXaBenCat()
        {
            return new List<string>
            {
                "Chánh Phú Hòa", "Hòa Lợi", "Mỹ Phước", "Tân Định"
            };
        }
        public List<string> PhuongXaDiAn()
        {
            return new List<string>
            {
                "Vĩnh Phú", "An Bình", "An Phú", "Bình Lợi"
            };
        }
        public List<string> PhuongXaThuanAn()
        {
            return new List<string>
            {
                "Bình Chuẩn", "Bình Hòa", "Hưng Định", "Lái Thiêu"
            };
        }
        public List<string> QuanHuyenDongNai()
        {
            return new List<string>
            {
                "Biên Hòa", "Long Khánh", "Tân Phú", "Trảng Bom"
            };
        }
        public List<string> PhuongXaBienHoa()
        {
            return new List<string>
            {
                "Bửu Hòa", "Long Bình","Tam Hiệp", "Thống Nhất"
            };
        }
        public List<string> PhuongXaLongKhanh()
        {
            return new List<string>
            {
                "Phú Bình", "Xuân Bình", "Xuân Thịnh", "Xuân Lập"
            };
        }
        public List<string> PhuongXaTanPhu()
        {
            return new List<string>
            {
                "Tân Tiến", "Tân Hưng", "Tân Minh", "Tân Quý Tây"
            };
        }
        public List<string> PhuongXaTrangBom()
        {
            return new List<string>
            {
                "Đông Hoà", "Bắc Sơn", "Hố Nai 3", "Tây Hoà"
            };
        }
        public List<string> QuanHuyenHaNoi()
        {
            return new List<string>
            {
                "Ba Đình", "Hoàn Kiếm", "Đống Đa", "Cầu Giấy"
            };
        }
        public List<string> PhuongXaBaDinh()
        {
            return new List<string>
            {
                "Nguyễn Trãi", "Thành Công", "Ô Chợ Dừa", "Nguyễn Du"
        };
        }
        public List<string> PhuongXaHoanKiem()
        {
            return new List<string>
            {
                "Đồng Xuân", "Hàng Mã", "Hàng Buồm", "Cửa Đông"
            };
        }
        public List<string> PhuongXaDongDa()
        {
            return new List<string>
            {
                "Cát Linh", "Văn Miếu", "Quốc Tử Giám", "Trung Phụng"
            };
        }
        public List<string> PhuongXaCauGiay()
        {
            return new List<string>
            {
                "Phương Mai", "Mỹ Đình 1", "Mỹ Đình 2", "Phú Diễn"
            };
        }
        public List<string> QuanHuyenHCM()
        {
            return new List<string>
            {
                "Quận 1", "Quận 3", "Thành phố Thủ Đức", "Gò Vấp"
            };
        }
        public List<string> PhuongXaQuan1()
        {
            return new List<string>
            {
                "Bến Nghé", "Bến Thành", "Đa Kao", "Nguyễn Cư Trinh"
            };
        }
        public List<string> PhuongXaQuan3()
        {
            return new List<string>
            {
                "Phường 1", "Phường 2", "Phường 3", "Phường 4"
            };
        }
        public List<string> PhuongXaThuDuc()
        {
            return new List<string>
            {
                "Phường Linh Chiểu", "Phường Linh Tây", "Phường Long Trường", "Phường Phước Bình",
            };
        }
        public List<string> PhuongXaGoVap()
        {
            return new List<string>
            {
                "Phường 1", "Phường 2", "Phường 3", "Phường 4"
            };
        }
        public List<string> GioiTinh()
        {
            return new List<string>
            {
                "Nam",
                "Nữ"
            };
        }
        public List<string> DanToc()
        {
            return new List<string>
            {
                "Chăm", "Ê Đê", "Hoa", "Khơ Me", "Kinh", "Mường", "Tày", "Thái"
            };
        }
        public List<string> QuocTich()
        {
            return new List<string>
            {
                "Việt Nam",
                "Khác"
            };
        }
        public List<string> QuanHe()
        {
            return new List<string>
            { 
                "Ông", "Bà", "Cha", "Mẹ", "Anh", "Chị", "Em", "Con gái", "Con trai", "Cháu gái", "Cháu trai", "Vợ", "Chồng", "Chủ hộ", "Con dâu", "Con rể"
            };
        }
        public List<string> QuanHeKS()
        {
            return new List<string>
            {
                "Cha", "Mẹ", "Người giám hộ"
            };
        }
    }
}
