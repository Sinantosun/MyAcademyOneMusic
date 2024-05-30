Merhaba

MY YAZILIM EĞİTİM AKADEMİ DANIŞMANLIK bünyesinde katıldığım full stack developer eğitimi kapsamında geliştirdiğim 3. projem Olan One Music projesini bitirmiş bulunmaktayım.

One Music Projesi, sanatçıların albümlerini ve şarkı yükleyebildiği; kullanıcıların ise bu albümleri görüntüleyip müzikleri dinleyebildiği, adminin site içinde yer alan crud operasyonlarını kontrol ettiği ve ayrıca albümlerin onaylanması/reddedilmesi gibi işlemleri içeren bir web ara yüzüdür.

Projenin albüm detay görüntüleme sayfasında ile ilgili albümün şarkı sözleri Rapid Api - Genius - Song Lyrics ile çekilmiştir.

 Teknolojiler

 → Identity Kütüphanesi <br>
 → Entity Framework Code First <br>
 → ASP.NET Core 8.0 <br>
 → Fluent Validation <br>
 → HTML, CSS, Bootstrap <br> 
 → MSSQL Server <br>
 → X.PagedList ile sayfalama <br>
 → Ajax <br>
 → Rapid Api Song Lycris <br>
 → Sweet Alert <br>
 → LINQ <br>

 Teknik Özellikler;<br>
→ İki panel içinde oturum 5 dakika işlem yapılmadığı sürece oturumun otomatik düşürülmesi (session time out)<br>
→ Identity Kütüphanesi ile mail onaylama işlemleri şifre sıfırlama işlemleri         <br>
→ N Katmanlı Mimari

<h1>İdentity Kütüphanesi Nedir ?</h1>
 → Identity Microsoft tarafından geliştirilen ve üyelik sistemi inşa etmek amacıyla kullanılan bir kütüphanedir. <br>
 → Hazır gelen ve özelleştirilebilen bir yapıdadır <br>
 → Hazır gelenden kastım burada Varsayılan olarak kullanıcı tablosu rol tablosu ve bununla ilişkili bir çok tablo içinde barındırmaktadır isteğe göre bu tablolara sütün eklenebilir.<br>
 → Şifrelerin Hashlenmesi, İki adımlı doğrulama, Kullanıcıların 5 defa hatalı girişlerinde oturum kitlenmesi gibi özellikleride barındırır.<br>

<h1>Rapid Api Nedir ?</h1>

 → Sitedeki 10.000'den fazla genel API ve 1 milyon aktif geliştirici ile en büyük küresel API pazarıdır. RapidAPI, kullanıcılara satın alma kararını vermeden önce API'leri doğrudan platform üzerinde test etme imkanı sunar.

<h1>Sweet Alert Nedir ?</h1>

 → Sweet Alert 2 ile projelerinizde daha güzel iletişim geri bildirimleri yapabilirsiniz. 

<h1>X.PagedList Nedir ?</h1>

 → En basit tabir ile sayfalamadır yani verilerin belli her sayfada istenilen adet olarak gösterilmesi kalanların ise hemen verilerin altında oluşan butonlar yardımıyla (1-2-3-4...sayfa sonu) erişilmesidir.

<h1>Proje Görselleri </h1> <br>
 Albümlerin Listesi <br>
 ![Image07](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/d7238138-70c4-4695-b610-08ea81cb6048)
Burada tutuluyor yukarıda bahsettimiz x.pagedlist burada kullanılmıştır her sayfada 12 kayıt olmak şartıyla altlarda bulunan numaralar ile sayfalar arası geçiş sağlanıyor.
 

 Albüm Detay Sayfası  <br>
![Img01](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/50751832-56aa-483b-b7c0-7bf84946a0dc)
Burada rapid api ile şarkı sözleri albüm adına göre çekilmiştir.

 Ana Sayfa Carsouel alanı <br>
![Image02](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/0b4dea6e-fea5-4f01-9693-b3b8a9e1a1e8)
burada admin tarafindan kayıt edilen veriler işlenmektedir.

![Image03](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/fc6befaa-5f54-4410-9247-09d597694164)
sanatçıların en son ekledikleri albümlerden 6 tanesinin listesi

![Image04](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/8824978f-0641-4da2-86a9-416a1a1a89c1)
Bu kısım veri tabanında bulunan kayıtlar üstünden random olarak gelmektedir. (sayfa yenilendiğinde burası veriler değişiklik gösterebilir.)


![Image05](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/25bb8171-b81e-47e9-a081-12783f5300d9)
Bu kısımların tamamı veri tabanında bulunan kayıtlardan random listeleniyor.


![Image08](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/bb77ecf5-bb45-4116-a6b1-cb33bfaa10ca)
Admin tarafından eklenen etkinlikler burada listeleniyor.

