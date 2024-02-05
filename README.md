# Asal Sayı Bulucu

Bu .NET Core uygulaması, en büyük asal sayıyı bulmak amacıyla geliştirilmiştir. Sadece admin yetkisi olan kullanıcılar, asal sayıları girebilir ve işlemleri gerçekleştirebilir. Veritabanı, DB first yaklaşımı kullanılarak oluşturulmalıdır.

## Service Yapısı ve Design Patterns

Solid prensiplerinin ilki olan *Single Responsibility Principle* design pattern'i olan servis tabanlı tasarım, her servisin belirli bir sorumluluğa odaklanmasını sağlayarak kodun okunabilirliğini artırır ve geliştirilmesini kolaylaştırır. Bu modüler yaklaşım, her bir servisin bağımsız olarak test edilebilmesini mümkün kılar, bu da yazılımın güvenilirliğini artırır. Tek sorumluluk ilkesini destekleyen servis tabanlı tasarım, her bir servisin sadece belirli bir işlevselliği yönetmesini sağlayarak kodun karmaşıklığını azaltır ve daha etkili bir geliştirme süreci sunar.

### UnitOfWork ve Benzer Tasarım Methodları

Unit of Work tasarımı, veritabanı işlemlerini gruplamak ve tek bir işlem içinde yönetmek amacıyla kullanılır. Bu tasarım, aynı işlemlerin birbirine bağımlılıklarını yönetir ve işlemlerin başarılı bir şekilde tamamlanmasını sağlar. Diğer yandan, servis tabanlı tasarım daha modüler ve bağımsız bir yaklaşım sunar, her servis belirli bir işlevselliğe odaklanır ve birim testlerle daha iyi uyum sağlar. Unit of Work, veritabanı işlemleri üzerine odaklanırken, servis tabanlı tasarım genel uygulama mantığına odaklanır ve daha esnek bir yapı sunar.

#### Prime Number Service Tasarımı

Projede kullandığım sayı işlemleri için Prime Number adında ayrı bir servis geliştirdim. Bunu ayrı bir servis içinde organize etmek, kodun modülerliğini artırarak bakımını kolaylaştırır. Bu yaklaşım, her bir servisin belirli bir sorumluluğa odaklanmasını sağlar ve bu sayede kod daha okunabilir hale gelir. Ayrıca, bu sayı işlemlerinin bağımsız bir şekilde test edilmesi, yazılımın güvenilirliğini artırır. Servis tabanlı yapı, projenin büyümesi ve gelişmesi durumunda daha esnek bir yapı sunar. Sonuç olarak, bu yaklaşım, kodun daha sürdürülebilir ve genişletilebilir olmasına katkı sağlar.

## Kullanıcılar (User) Tablosu

| id | username | password | is_admin |
|----|----------|----------|----------|
| 1  | user1    | pass123  | false    |
| 2  | erdem    | erdem    | true     |
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
