Cinema Automation User
Projemizden bahsetmek istiyorum.
Katmanlı bir mimari yapısı ile yapılmıstır.
Projemizde ASP.NET MVC yapısı kullanılmıştır.
Veri tabanı EntityFramework CodeFirst ile kurulmustur (SQL Server)
Projenin içerigine gelirse Kullanıcılar sitemize kayıt olabilirler. Kullanıcılara VIP seçenegi sunabiliyoruz.
Normal(member) kullanıcı Vizyondaki filimlerin 2 gün sonrasını görebilirler ve ona göre reservasyon/satış işlemleri yapılabilir.
VIP kullanıcılarımız vip olabilmek için belirli bir ücret odemek zorundadırlar. VIP Kullanıcıların ozellıklerı gösterimdeki filmleri 7 gün ilerisi filmler için
reservasyon/satış işlemleri yapabilir. VIP Kullanıcılara bilet fiyatı %40 indirimli satılır.Sinema Salonunda Hafta içi Perşembe günleri Halk günü olarak kabul edilir ve 
hafta içi her seans için %50 indirim uygulanır ve Hafta içi günlerde ilk seanslara %50 indirim uygulanır. Ozel günlerde indirim fiyatları degişebilir.
Özel günler için ek seans eklenebilir bu eklenen seanslar farklı gosterilir.
Ögrenciler için bilet fiyatları %50 indirimli olarak uygulanır. reservasyon işleminde ögrenci adeti seçilir. Bilet sinema salonunda bilet numarası ile onaylanırken
ögrenci arkadaşlar ögrenci kimliklerini gostermek zorundadırlar aksi taktirde bilet iptal olarak tekrar satışa çıkarılır..
Seans saatlerinden yarım saat (30 dk) öncesine kadar reserve edilen biletler onaylanmaz ise bilet rezervi iptal olur ilgili koltuklar tekrar satışa sunulur.
Rezervasyon/Satış işlemleri sonrası ilgili koltuklar ilgili salonda ilgili seans için kapatılır bu bilgiler kullanıcaya gösterilir ve ek olarak mail adreslerine
bu bilgiler gonderilir.

Yukarıda bahsettigim olaylar Kullanıcı içindir.

Cinema Automation Employee
Projede çalışan arkadaşların görevleri şu şekildedir.

Patron(Boss) Patronun sadece Görme yetkisi vardır ekstra ekleme silme guncelleme vs yetkisi yoktur. Patron istedigi çalışana istedi görev tanımını yapabilir ve maaşlarını düzenleyebilir. 

Gişe Çalışanı(BookingClerk)Gişe çalışanlarının yetkileri Film,Tür,Oyuncu,Yonetmen,Seans,Listeleme ekleme güncelleme yetkilerine sahiptir.

Gişe Müdürü(BoxOfficeSupervisor) Gişe Müdürü yetkileri Film,Tür,Oyuncu,Yonetmen,Seans,Listeleme ekleme silme güncelleme yetkilerine sahiptir.

Yönetim(Management) Yönetimin yetkileri Film,Tür,Oyuncu,Yonetmen,Seans,Listeleme, ekleme, silme ,güncelleme ,Çalışanlarla ilgili silme güncelleme yetki verme yetkilerine ,sahiptir


