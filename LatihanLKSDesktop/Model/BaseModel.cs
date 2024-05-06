using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatihanLKSDesktop.Model
{
    internal class BaseModel
    {
        public class LogModel
        {
            public string id_log { get; set; }
            public string waktu { get; set; }
            public string aktivitas { get; set; }
            public string username { get; set; }
        }

        public class UserModel
        {
            public string id_user { get; set; }
            public string tipe_user { get; set; }
            public string nama { get; set; }
            public string telepon { get; set; }
            public string alamat { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }

        public class TransaksiModel
        {
            public string id_transaksi { get; set; }
            public string no_transaksi { get; set; }
            public string tgl_transaksi { get; set; }
            public long total_bayar { get; set; }
            public string id_user { get; set; }
            public string id_barang { get; set; }
        }

        public class BarangModel
        {
            public string id_barang { get; set; }
            public string kode_barang { get; set; }
            public string nama_barang { get; set; }
            public string expired_date { get; set; }
            public long jumlah_barang { get; set; }
            public string satuan { get; set; }
            public long harga_satuan { get; set; }
        }
    }
}
