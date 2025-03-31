namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama { get; set; }
        public int Kuantitas { get; set; }

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    public class ItemNode
    {
        public Item Data { get; set; }
        public ItemNode Next { get; set; }

        public ItemNode(Item data)
        {
            Data = data;
            Next = null;
        }
    }

    public class ManajemenInventori
    {
        private ItemNode head;

        public ManajemenInventori()
        {
            head = null;
        }

        public void TambahItem(Item item)
        {
            ItemNode newNode = new ItemNode(item);
            if (head == null)
            {
                head = newNode;
                return;
            }

            ItemNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public bool HapusItem(string nama)
        {
            if (head == null)
                return false;

            if (head.Data.Nama == nama)
            {
                head = head.Next;
                return true;
            }

            ItemNode current = head;
            while (current.Next != null && current.Next.Data.Nama != nama)
            {
                current = current.Next;
            }

            if (current.Next == null)
                return false;

            current.Next = current.Next.Next;
            return true;
        }

        public string TampilkanInventori()
        {
            if (head == null)
                return string.Empty;

            string hasil = "";

            ItemNode current = head;
            while (current != null)
            {
                hasil += $"{current.Data.Nama}; {current.Data.Kuantitas}{Environment.NewLine}";
                current = current.Next;
            }

            return hasil.TrimEnd();
        }

        


    }
}
