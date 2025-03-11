using System;
using System.Threading;
namespace TicTacToe
{
    class Program
    {
        // Dizi oluşturuluyor ve varsayılan olarak 0-9 değerleri atanıyor (0 kullanılmayacak)
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; // Varsayılan olarak oyuncu 1 başlıyor
        static int choice; // Kullanıcının hangi konuma işaret koymak istediğini tutan değişken
        
        // flag değişkeni oyunun durumunu kontrol eder: 
        // 1 → Bir oyuncu kazandı, -1 → Oyun berabere, 0 → Oyun devam ediyor
        static int flag = 0;
        
        static void Main(string[] args)
        {
            do
            {
                Console.Clear(); // Her turda ekran temizlenir
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                
                // Oyuncunun sırasını kontrol etme
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                Console.WriteLine("\n");
                
                Board(); // Tahtayı çizme fonksiyonu çağırılır
                choice = int.Parse(Console.ReadLine()); // Kullanıcının seçimini al
                
                // Seçilen pozisyonun zaten işaretlenip işaretlenmediğini kontrol etme
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) // Eğer sıra oyuncu 2'deyse O koy, değilse X koy
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    // Seçilen konum zaten işaretlenmişse uyarı ver ve tahtayı tekrar yükle
                    Console.WriteLine("Üzgünüm, {0} numaralı alan zaten {1} ile işaretlenmiş", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Lütfen 2 saniye bekleyin, tahta yeniden yükleniyor...");
                    Thread.Sleep(2000);
                }
                
                flag = CheckWin(); // Kazanma durumunu kontrol etme fonksiyonunu çağır
            }
            while (flag != 1 && flag != -1); // Kazanan biri çıkana veya beraberlik olana kadar devam et
            
            Console.Clear(); // Konsolu temizle
            Board(); // Son haliyle tahtayı göster
            
            if (flag == 1)
            {
                // Eğer flag 1 ise son hamleyi yapan oyuncu kazanmıştır
                Console.WriteLine("Oyuncu {0} kazandı!", (player % 2) + 1);
            }
            else
            {
                // Eğer flag -1 ise oyun berabere bitmiştir
                Console.WriteLine("Berabere!");
            }
            
            Console.ReadLine();
        }
        
        // Tahta çizme fonksiyonu
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        
        // Oyunun kazanılıp kazanılmadığını kontrol eden fonksiyon
        private static int CheckWin()
        {
            #region Yatay Kazanma Koşulları
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            
            #region Dikey Kazanma Koşulları
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            
            #region Çapraz Kazanma Koşulları
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            
            #region Beraberlik Kontrolü
            // Eğer tüm hücreler X veya O ile doluysa ve kazanan yoksa oyun berabere
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            
            else
            {
                return 0; // Oyun devam ediyor
            }
        }
    }
}