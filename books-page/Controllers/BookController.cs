using Microsoft.AspNetCore.Mvc; // Add using directive for Controller and IActionResult
using books_page.Models; // Add using directive for your Book and BookViewModel classes

namespace books_page.Controllers;

public class BookController : Controller {

    public IActionResult Index(){
        var book = new BookViewModel();

        book.Id=1;
        book.Name="The Elephant Vanishes";
        book.Author="Haruki Murakami";
        book.Image="1.jpg";
        book.Description="With the same deadpan mania and genius for dislocation that he brought to his internationally acclaimed novels A Wild Sheep Chase and Hard-Boiled Wonderland and the End of the World, Haruki Murakami makes this collection of stories a determined assault on the normal. A man sees his favorite elephant vanish into thin air; a newlywed couple suffers attacks of hunger that drive them to hold up a McDonald's in the middle of the night; and a young woman discovers that she has become irresistible to a little green monster who burrows up through her backyard.";
        
        return View(book);
    }

     public IActionResult List(){

        var BookList = new List<BookViewModel>()
        {
            new BookViewModel() {Id=1, Name="The Elephant Vanishes", Author="Haruki Murakami", Image="1.jpg", Description="With the same deadpan mania and genius for dislocation that he brought to his internationally acclaimed novels A Wild Sheep Chase and Hard-Boiled Wonderland and the End of the World, Haruki Murakami makes this collection of stories a determined assault on the normal. A man sees his favorite elephant vanish into thin air; a newlywed couple suffers attacks of hunger that drive them to hold up a McDonald's in the middle of the night; and a young woman discovers that she has become irresistible to a little green monster who burrows up through her backyard."},
        
            new BookViewModel() {Id=2, Name="İntibah", Author="Namık Kemal", Image="2.jpg", Description="Gerçekçi bir dille yazılmış olan İntibah, aşırı korumacı bir aile tarafından yetiştirilen bir delikanlının yaşamın zorluklarıyla başa çıkamaması ve gerçek dünyaya uyum sağlayamamasını konu alır. Roman akıcı bir anlatıma sahiptir. Yaşanan olaylar karşısında soğukkanlılığını koruyamayan, pek düşünmeden ani kararlar veren delikanlı, hem kendisinin hem de sevdiklerinin hayatını mahvedecektir. Son pişmanlık fayda etmez şeklinde özetlenebilecek olan olaylar dizisi, dönemin yaşam tarzı, alışkanlıkları ve artık günümüzde geçerliliği kalmamış sosyal düzen içerisinde anlatılır. Uyanış anlamına gelen İntibah, gerek yazıldığı dönemle, gerek dönemin edebiyat anlayışıyla ilgili fikirler vermesi bakımından önemlidir."},
       
            new BookViewModel() {Id=3, Name="Gün Olur Asra Bedel", Author="Cengiz Aytmatov", Image="3.jpg", Description="Yedigey isimli karakterin aslında bir gün içinde aklından geçenler ve yaşadıklarını anımsaması. Yedigey, kadim dostu Kazangap'ın cenazesini taşırken geçmişte bir yolculuğa çıkıyor ve sizi hikâyenin en başına götürüyor. Bir Kazak Türkü olan Yedigey, dönemin sosyal karışıklığı ve belirsizliği yüzünden bir yere tutunmak istiyor ve böylece Kumbel istasyonunda çalışmaya başlıyor. Burada uzun süre arkadaşlık kuracağı ve en yakın dostu olacağı Kazangap ile tanışıyor. Uçsuz bucaksız bozkırlarda günlerini birlikte geçiren ikili, zorluklara da beraber göğüs geriyorlar. Kazangap'ın vefatı ise Yedigey için âdeta bir yıkım oluyor ve koca dünyada tek başına kaldığını hissetmesine sebep oluyor. Kazangap'ın gömüleceği mezarlığın ismi Ana-Beyit ve bu adı da Nayman Ana adlı bir efsanevi kadından alıyor."}
        
        };

        return View("BookList",BookList);
    }
}