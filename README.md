# Asal Sayı Bulucu

![Nasıl görünüyor?](testcase.mp4)


Bu .NET Core uygulaması, en büyük asal sayıyı bulmak amacıyla geliştirilmiştir. Sadece admin yetkisi olan kullanıcılar, asal sayıları girebilir ve işlemleri gerçekleştirebilir. Veritabanı, DB first yaklaşımı kullanılarak oluşturulmalıdır.

## Kullanıcılar (User) Tablosu

| id | username | password | is_admin |
|----|----------|----------|----------|
| 1  | user1    | pass123  | false    |
| 2  | admin    | admin123 | true     |
| 3  | johnDoe  | doe456   | false    |

Kullanıcılar tablosu, uygulamanın kullanıcı yönetimini sağlamak için kullanılır. "is_admin" sütunu, kullanıcının admin yetkisine sahip olup olmadığını belirtir. Veritabanına girmiş olduğunuz user için is_admin değerini True yaparsanız o kullanıcı üzerinden admin yetkisiyle asal sayı işlemlerinizi yapabilirsiniz.

## Asal Sayılar (PrimeNumbers) Tablosu

| id | number |
|----|--------|
| 1  | 13     |
| 2  | 29     |
| 3  | 37     |

Asal Sayılar tablosu, uygulamanın işlevselliğini sağlamak için kullanılır. "number" sütunu, asal sayıları içerir ve bu sayılar üzerinde işlemler yapılır.

## Veritabanı Oluşturma

Uygulamanın kullanılabilmesi için veritabanının oluşturulması gerekmektedir. Veritabanını oluşturmak için aşağıdaki adımları takip edebilirsiniz:

1. Uygulamayı bilgisayarınıza indirin.
2. .NET Core SDK'yı yükleyin, [buradan](https://dotnet.microsoft.com/download) indirebilirsiniz.
3. Terminal veya Komut İstemi'ni açın ve uygulama dizinine gidin.
4. `dotnet ef database update` komutunu kullanarak veritabanını oluşturun.

## Nasıl Çalışır?

Uygulama, kullanıcının belirlediği bir aralıkta en büyük asal sayıyı bulmak için tasarlanmıştır. Sadece admin yetkisine sahip kullanıcılar, asal sayıları girebilir ve bu işlemi gerçekleştirebilir.

## Kullanım

1. Uygulamayı bilgisayarınıza indirin.
2. Veritabanını oluşturun (Yukarıdaki "Veritabanı Oluşturma" bölümüne bakın).
3. .NET Core SDK'yı yükleyin, [buradan](https://dotnet.microsoft.com/download) indirebilirsiniz.
4. Terminal veya Komut İstemi'ni açın ve uygulama dizinine gidin.
5. `dotnet run` komutunu kullanarak uygulamayı başlatın.
6. Admin yetkisiyle giriş yaparak asal sayıları girebilir ve en büyük asal sayıyı bulabilirsiniz.

## Katkıda Bulunma

Eğer bu projeye katkıda bulunmak istiyorsanız, lütfen forklayın ve pull request gönderin. Her türlü katkı ve geri bildirimleri bekliyoruz!

## Lisans

Bu uygulama [MIT Lisansı](LICENSE) altında lisanslanmıştır. Detaylı bilgiler için lisans dosyasını inceleyebilirsiniz.
