namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; set; }  // Menggunakan Data sesuai dengan unit test
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Data = buku;  // Menyimpan objek Buku di properti Data
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public KoleksiPerpustakaan()
        {
            head = null;
        }

        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);

            if (head == null)
            {
                head = newNode;
                return;
            }

            BukuNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public bool HapusBuku(string judul)
        {
            if (head == null)
                return false;

            if (head.Data.Judul == judul)
            {
                head = head.Next;
                return true;
            }

            BukuNode current = head;
            while (current.Next != null && current.Next.Data.Judul != judul)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                return true;
            }

            return false;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasilPencarian = new List<Buku>();

            BukuNode current = head;
            while (current != null)
            {
                if (current.Data.Judul.Contains(kataKunci))
                {
                    hasilPencarian.Add(current.Data);
                }
                current = current.Next;
            }

            return hasilPencarian.ToArray();
        }

        public string TampilkanKoleksi()
        {
            if (head == null)
                return string.Empty;

            string hasil = "";
            BukuNode current = head;
            while (current != null)
            {
                hasil += $"\"{current.Data.Judul}\"; {current.Data.Penulis}; {current.Data.Tahun}\n";
                current = current.Next;
            }
            return hasil;
        }
    }
}