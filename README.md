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

# API Workspace Doküman Linkleri

Aşağıda projemizde bulunan API workspace'lerinin Postman dokümanlarına ait linkler yer almaktadır:

| Workspace Adı | Postman Doküman Linki                                    |
|---------------|----------------------------------------------------------|
| **Books**     | [Books API Dokümanı]([https://www.postman.com/your-books-link](https://documenter.getpostman.com/view/37005138/2sB34hEzUm#78156633-c077-4e58-a007-9bc0fdee5526))      |
| **User**      | [User API Dokümanı]([https://www.postman.com/your-auth-link](https://documenter.getpostman.com/view/37005138/2sB34hEzZ5))        |
| **Categories**| [Categories API Dokümanı]([https://www.postman.com/your-categories-link](https://documenter.getpostman.com/view/37005138/2sB34hEzZ6)) |
| **Users**     | [Users API Dokümanı]([https://www.postman.com/your-users-link](https://documenter.getpostman.com/view/37005138/2sB34hEzZ5))        |


## 📌 Notlar

- Kod yapısı `Clean Code` prensiplerine uygun olarak yazılmaya özen gösterilmiştir.

---

## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---
