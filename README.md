# HSPExpenseTracker

Exchange Tracker uygulaması ile kullanıcı oluşturabilir, kullanıcı ile hesap oluşturabilir ve hesaba ait işlemleri ekleyip yönetebilirsiniz.

Uygulamayı kurabilmek için postgreSql localhost'unuzun connection stringini appsettings.json dosyasına girip migration yapmanız yeterli olacaktır.

Migration işleminin ardından otomatik olarak Categories tablosuna 3 adet kayıt atılacak ve transactionlar bu categoryId ler ile işlenebilecektir.

Sırasıyla User, User ile Account ve Account ile Transactionlar oluşturabilirsiniz.

Kullanıcıya ait Accountları görebilmek için Account/GetAccountListForUser
Accountlara ait Transaction işlemlerini ve detaylarını(bakiye vb.) bilgilerini görebilmek için <b>Account/GetAccountsTransactionsAndDetails</b>
endpointlerini kullanabilirsiniz.
