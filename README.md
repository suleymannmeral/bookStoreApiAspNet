# 📚 Book Store 

Bu proje ASP.NET Core WEB API kursu bünyesinde geliştirilen bir API projesidir.




## 🛠 Kullanılan Teknolojiler

| Teknoloji              | Açıklama                                              |
|------------------------|--------------------------------------------------------|
| **ASP.NET Core Web API** | Projenin backend altyapısı                            |
| **MSSQL**              | Veritabanı yönetimi için                              |
| **Entity Framework Core** | ORM aracı olarak                                     |
| **Identity + JWT**     | Kimlik doğrulama ve yetkilendirme işlemleri için      |
| **Postman -  Swagger**            | API testleri ve dokümantasyonu                        |

---

## 🧱 Katmanlar

Bu projede Clean Architecture yapısı temel alınarak katmanlı bir mimari benimsenmiştir. Her bir katman belirli bir sorumluluğu yerine getirmek üzere yapılandırılmıştır:

| Katman Adı           
|----------------------|
| **Entities** |
| **Presentation** |
| **Services** |
| **Repositories** |
| **WEBAPI Katmanı**|


| Özellikler              | Açıklama                                              |
|------------------------|--------------------------------------------------------|
| **HATEOAS** |HATEOAS (Hypermedia as the Engine of Application State), istemcinin API ile nasıl etkileşime geçeceğini linklerle yönlendirme.                      |
| **Caching**              | Caching, API yanıtlarının tekrar kullanılarak performansı artırmasını ve sunucu yükünün azaltılmasını sağlayan bir tekniktir.                              |
| **Rate Limiting** |API’ye yapılan istek sayısı belirli bir zaman diliminde sınırlanmıştır. .                               |
| **Nlog**     | Loglama işlemleri |
| **Versioning**            | Versiyonlama               |




## 📌 Notlar

- Kod yapısı `Clean Code` prensiplerine uygun olarak yazılmaya özen gösterilmiştir.

---

## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---
