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

| Workspace Adı | Postman Doküman Linki                                                                                      |
|---------------|------------------------------------------------------------------------------------------------------------|
| **Books**     | [Books API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzUm#78156633-c077-4e58-a007-9bc0fdee5526)      |
| **Categories**| [Categories API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzZ6)                        |
| **User**      | [User API Dokümanı](https://documenter.getpostman.com/view/37005138/2sB34hEzZ5)        

<img width="1901" height="950" alt="image" src="https://github.com/user-attachments/assets/513dcf56-6084-49ab-b5b6-1544ba8244d7" />
|


## 📌 Notlar

- Kod yapısı `Clean Code` prensiplerine uygun olarak yazılmaya özen gösterilmiştir.

---

## 📬 İletişim

Her türlü soru, görüş veya öneriniz için bana GitHub üzerinden ulaşabilirsiniz.

---
