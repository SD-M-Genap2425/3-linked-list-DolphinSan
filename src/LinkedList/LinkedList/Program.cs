using LinkedList.Inventori;
using LinkedList.ManajemenKaryawan;
using LinkedList.Perpustakaan;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        Buku buku = new Buku("Test Book", "Test Author", 2021);
        BukuNode node = new BukuNode(buku);

        Buku buku1 = new Buku("Test Book 1", "Test Author", 2021);
        Buku buku2 = new Buku("Test Book 2", "Test Author", 2022);
        BukuNode node1 = new BukuNode(buku1);
        node1.Next = new BukuNode(buku2);

        KoleksiPerpustakaan perpustakaan = new KoleksiPerpustakaan();
        Buku buku3 = new Buku("Test Book", "Test Author", 2021);
        perpustakaan.TambahBuku(buku3);
        perpustakaan.CariBuku("2021");
        perpustakaan.HapusBuku("Test Book");
        perpustakaan.TampilkanKoleksi();

        // Soal ManajemenKaryawan
        DaftarKaryawan daftarKaryawan = new DaftarKaryawan();
        daftarKaryawan.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftarKaryawan.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
        Console.WriteLine("Daftar Karyawan:");
        Console.WriteLine(daftarKaryawan.TampilkanDaftar());

        Console.WriteLine("\nMenghapus karyawan dengan ID 001...");
        daftarKaryawan.HapusKaryawan("001");
        Console.WriteLine(daftarKaryawan.TampilkanDaftar());

        // Soal Inventori
        ManajemenInventori manajemen = new ManajemenInventori();
        manajemen.TambahItem(new Item("Apple", 50));
        manajemen.TambahItem(new Item("Orange", 30));
        manajemen.TambahItem(new Item("Banana", 20));

        Console.WriteLine("\nInventori:");
        Console.WriteLine(manajemen.TampilkanInventori());

        Console.WriteLine("\nMenghapus 'Orange'...");
        bool sukses = manajemen.HapusItem("Orange");
        Console.WriteLine(sukses ? "Item berhasil dihapus." : "Item tidak ditemukan.");

        Console.WriteLine("\nInventori setelah penghapusan:");
        Console.WriteLine(manajemen.TampilkanInventori());

    }
}
