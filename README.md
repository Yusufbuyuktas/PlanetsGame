🪐 Planet Drop: İnteraktif Güneş Sistemi
Planet Drop, oyuncuların gezegenleri doğru yörüngelere yerleştirerek Güneş Sistemimizi tanımasını sağlayan, eğitim odaklı interaktif bir 2D puzzle oyunudur.

🚀 Proje Hakkında
Bu proje, temel sürükle-bırak mekaniklerini modern Unity araçlarıyla birleştirerek hem eğitici hem de görsel olarak tatmin edici bir deneyim sunmayı amaçlar. Oyuncu, rastgele gelen gezegenleri isimlerine ve yörünge sıralamalarına göre doğru boşluklara yerleştirmeye çalışır.

🛠️ Öne Çıkan Özellikler
Eğitici Oyun Mekaniği: 8 gezegenin (Merkür'den Neptün'e) Güneş'e olan uzaklık sıralamasını öğretir.

Dinamik Ölçeklendirme: Gezegenler yörüngeye oturduğunda, o seviyeye özel belirlenmiş boyutlara pürüzsüzce (smooth transition) geçer.

Çoklu Seviye Sistemi: Farklı zorluklarda ve farklı görsel ölçeklerde tasarlanmış bölümler.

Kullanıcı Dostu UI: Ana menü, oyun içi can sistemi ve geçiş ekranları.

🎨 Teknik Sanat & Görselleştirme (Technical Art)
Bir Technical Artist adayı olarak bu projede şu teknik yaklaşımları uyguladım:

Procedural Orbits: Yörünge çizgileri, her gezegen için özel yarıçap değerleriyle Line Renderer kullanılarak matematiksel olarak çizdirildi.

Sıvı Animasyonlar: Gezegenlerin yörüngeye oturma anındaki boyut değişimleri C# Coroutine ve Vector3.Lerp kullanılarak pürüzsüz hale getirildi.

💻 Kod Yapısı
Proje, temiz ve genişletilebilir bir C# mimarisi üzerine kurulmuştur:

Event-Based Interaction: Sürükle-bırak işlemleri Unity IDragHandler ve IDropHandler arayüzleri (interfaces) ile yönetilir.

Data Responsibility: Gezegenlerin hedef boyutları gibi veriler, her seviye için bağımsız olarak DropPoint objeleri üzerinde tanımlanarak "Prefab" bağımlılığı azaltılmıştır.

Scene Management: Sahneler arası geçiş ve veri kontrolü için merkezi bir yapı kurulmuştur.

🛠️ Kurulum ve Çalıştırma
Bu depoyu klonlayın: git clone https://github.com/kullaniciadi/planet-drop.git

Unity 2022.3 veya üzeri bir sürümle projeyi açın.

Scenes klasöründen MainMenu sahnesini çalıştırın.

👥 Geliştirici
Yusuf - https://www.linkedin.com/in/yusufbuyuktas/

Sakarya Üniversitesi - Yazılım Mühendisliği

🔗 Linkler
Oynanabilir Web Sürümü (itch.io): https://yusuf-buyuktas.itch.io/
