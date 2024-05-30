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
 Albümlerin Listesi 
 
 ![Image07](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/818cf554-220e-4eca-8bc0-d7df3b83b70b)

Burada tutuluyor yukarıda bahsettimiz x.pagedlist burada kullanılmıştır her sayfada 12 kayıt olmak şartıyla altlarda bulunan numaralar ile sayfalar arası geçiş sağlanıyor.
 

 Albüm Detay Sayfası  <br>

![Img01](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/30f69f21-27c3-4a07-8f7e-381214a9ea96)


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

<h1>Sanatçı Paneli</h1>

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/a3ee85cb-1143-4eca-a8a1-8d579e8f82d4)

Her sanatçı burada ilgili bilgileri görüntüleyebilmektedir.

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/5f5584bc-1934-478b-81a6-03fd95da7a84)

Bu kısım albüm ekleme sayfasıdır sanatçılar ilgili alanları doldurup başvurda bulunyorlar daha sonra admin tarafindan onay ve red işlemlerini tabi tutuluyor eğer onaylanırsa sitei içinde albüm görüntüleniyor.

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/b5ae93af-779b-4cd2-94b9-fa99987543b3)

Bu kısım sanatçı kendiyle alakalı bütün bilgileri güncelleyebilmektedir. Burada güvenli olabilmesi açısından mevcut şifreye göre işlem yapılmaktadır eğer şifre yanlış ise işlem yapılmamaktadır.

<h1>Admin Paneli</h1>

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/966d9e97-262a-49d8-8780-929c8bf5654a)

Sanatçıların başvuruda bulunduğu albümler burada görünür red ve onay işlemleri burada gerçekleşir onay işleminde direkt onaylama sağlanır red işleminde bir popup ekran açılıp red nedeni sorulur neden yazıldıktan sonra red işlemi sağlanır.


![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/2fca9aba-3468-4543-a0f8-6b36ede5bc96)

Bu kısım ilk bilgilendirmedir evet butonuna basılırsa aşağıdaki görseldeki gibi bir popup ekran açılacaktır

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/ae267ffc-2772-46a5-ac82-437943c0b013)

evet butonuna basıldığında açılan red nedeni yazma ekranı bu şekilde red işlemi tamamlanır.


![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/561472a6-0356-40df-9b0d-d798889e9b95)

rol ekleme silme güncelleme işlemleri buradan yapılır

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/7dbc9978-9f5d-4db9-9b03-1507c1030423)

Rol atanacak kullanıcı bu liste içersinden seçilir.

![image](https://github.com/Sinantosun/MyAcademyOneMusic/assets/145317724/5b71e0ab-9899-468a-9257-e21ca179668d)

kullanıcı seçildikten sonra aktif bulunduğu roller direk olarak işaretli olarak gelir istenilen rol atandıktan sonra işlem tamamlanır.








