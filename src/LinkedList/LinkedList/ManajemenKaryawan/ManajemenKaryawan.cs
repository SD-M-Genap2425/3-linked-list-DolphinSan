namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        public DaftarKaryawan()
        {
            head = null;
            tail = null;
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);
            
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }

            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            if (head == null)
                return false;

            KaryawanNode current = head;
            while (current != null && current.Karyawan.NomorKaryawan != nomorKaryawan)
            {
                current = current.Next;
            }

            if (current == null)
                return false;

            if (current == head)
            {
                head = head.Next;
                if (head != null)
                    head.Prev = null;
                else
                    tail = null;
                return true;
            }

            if (current == tail)
            {
                tail = tail.Prev;
                tail.Next = null;
                return true;
            }

            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            return true;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            System.Collections.Generic.List<Karyawan> hasilPencarian = new System.Collections.Generic.List<Karyawan>();
            KaryawanNode current = head;

            while (current != null)
            {
                if (current.Karyawan.Nama.Contains(kataKunci) || current.Karyawan.Posisi.Contains(kataKunci))
                {
                    hasilPencarian.Add(current.Karyawan);
                }
                current = current.Next;
            }

            return hasilPencarian.ToArray();
        }

        public string TampilkanDaftar()
        {
            if (head == null)
                return string.Empty;

            System.Text.StringBuilder hasil = new System.Text.StringBuilder();
            KaryawanNode current = head;
            
            while (current != null)
            {
                hasil.AppendLine($"{current.Karyawan.NomorKaryawan}; {current.Karyawan.Nama}; {current.Karyawan.Posisi}");
                current = current.Next;
            }

            return hasil.ToString().Trim();
        }
    }
}
