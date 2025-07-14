# 📚 Book Store API Projesi

Bu proje, **ASP.NET Core WEB API** kursu kapsamında geliştirilen, katmanlı mimariye sahip bir API uygulamasıdır.

---

## 🛠 Kullanılan Teknolojiler

| Teknoloji               | Açıklama                                             |
|------------------------|-----------------------------------------------------|
| **ASP.NET Core Web API**| Projenin backend altyapısı                           |
| **MSSQL**               | Veritabanı yönetimi için                             |
| **Entity Framework Core**| ORM aracı olarak                                    |
| **Identity + JWT**      | Kimlik doğrulama ve yetkilendirme işlemleri için    |
| **Postman & Swagger**   | API testleri ve dokümantasyonu için                  |

---

## 🧱 Katmanlar

Projede **Clean Architecture** yapısı temel alınmış olup, katmanlar şu şekildedir:

| Katman Adı           |
|----------------------|
| **Entities**         |
| **Presentation**     |
| **Services**         |
| **Repositories**     |
| **WEBAPI Katmanı**   |

---

## 🏗 Architecture & Design Patterns

| Desen Adı             | Açıklama                                                                                             |
|-----------------------|----------------------------------------------------------------------------------------------------|
| **Repository Pattern** | Veri erişimini soyutlayarak, veri katmanının yönetimini kolaylaştırır ve uygulamadan bağımsız kılar.|
| **Dependency Injection** | Bağımlılıkların dışarıdan verilmesini sağlayarak, kodun test edilebilirliğini ve esnekliğini artırır.|
| **Unit of Work**       | Birden fazla repository işlemini tek bir işlem olarak yönetmeyi sağlar (SaveChanges).               |

---

## ⚙️ API Özellikleri

| Özellik           | Açıklama                                                                                       |
|-------------------|-----------------------------------------------------------------------------------------------|
| **HATEOAS**       | İstemcinin API ile nasıl etkileşime geçeceğini linklerle yönlendiren REST prensibidir.          |
| **Caching**       | API yanıtlarının tekrar kullanılarak performansı artırır ve sunucu yükünü azaltır.             |
| **Rate Limiting** | Belirli zaman diliminde API’ye yapılabilecek istek sayısını sınırlar, aşırı yüklenmeyi önler.  |
| **NLog**          | .NET uygulamalarında loglama işlemleri için kullanılan güçlü bir kütüphane.                    |
| **Versioning**    | API versiyonlaması ile geriye dönük uyumluluk ve geliştirme kolaylığı sağlar.                   |

---

## 📄 API Workspace Doküman Linkleri

| Workspace Adı  | Postman Doküman Linki                                                                                      |
|---------------|------------------------------------------------------------------------------------------------------------|
| **Books**     | [Books API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzUm#78156633-c077-4e58-a007-9bc0fdee5526)      |
| **Categories**| [Categories API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzZ6)                        |
| **User**      | [User API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzZ5)                             |

---

## 📌 Notlar

- Kod yapısı **Clean Code** prensiplerine uygun olarak yazılmıştır.
- Proje geliştirilmeye ve iyileştirilmeye açıktır.

---

## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---

