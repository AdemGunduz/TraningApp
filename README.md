# Kullanıcı ve Ürün Yönetim Sistemi

Bu proje, kullanıcılar, roller, kategoriler ve ürünleri yönetmek için tasarlanmış bir uygulamadır. 
Uygulama, kullanıcı yetkilendirmesi ve kimlik doğrulama için JWT ve rol tabanlı erişim kontrolü sağlar.

## Kullanılan Teknolojiler

- **MSSQL:** Veritabanı yönetimi için kullanılmıştır.
- **JWT (JSON Web Token):** Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için kullanılmıştır.
- **Authorization:** Rol tabanlı erişim kontrolü ve yetkilendirme işlemleri için kullanılmıştır.


### Sınıflar

#### AppRole

Roller ile ilgili bilgileri tutar.

- **Id:** Rolün benzersiz kimliği.
- **Definition:** Rolün tanımı.
- **AppUsers:** Bu role ait kullanıcıların listesi.

#### AppUser

Kullanıcı bilgilerini tutar.

- **Id:** Kullanıcının benzersiz kimliği.
- **UserName:** Kullanıcının kullanıcı adı.
- **Password:** Kullanıcının şifresi.
- **AppRoleId:** Kullanıcının rolünün kimliği.
- **AppRole:** Kullanıcının rolü.

#### Category

Ürün kategorilerini tutar.

- **Id:** Kategorinin benzersiz kimliği.
- **Definition:** Kategorinin tanımı.
- **Products:** Bu kategoriye ait ürünlerin listesi.

#### Product

Ürün bilgilerini tutar.

- **Id:** Ürünün benzersiz kimliği.
- **Name:** Ürünün adı.
- **Stock:** Ürünün stok durumu.
- **Price:** Ürünün fiyatı.
- **CategoryId:** Ürünün kategorisinin kimliği.
- **Category:** Ürünün kategorisi.
