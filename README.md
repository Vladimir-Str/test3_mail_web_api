# test3_mail_web_api
Требуется разработать web-сервис, задача которого формировать и отправлять письма адресатам и логировать результат в БД.

1. Web-сервис должен принимать POST запрос по url: /api/mails/. Тело запроса в формате json. Модельзапросаприкладывается:
{
"subject":"string",
"body":"string",
"recipients":["string"]
}

2. Метод обработки должен: 
2.1. Сформировать email сообщение, выполнить его отправку.
2.2. Добавить запись в БД. В записи указать все поля, которые пришли в сообщении, дату создания и результат отправки в виде поля Result: (значения Ok, Failed), а также полеFailedMessage (должно быть пустым или содержать ошибку отсылки уведомления).

3. Web-сервис должен отвечать на GET запросы по url /api/mails/. В результате запроса на этот url требуется выдать список всех отправленных сообщений (сохраненных в БД), включая поля с п.2.2. в формате json.

4. Требуется написать комментарии на все public свойства и методы (написанные разработчиком) придерживаясь XML DocumentationComments (https://msdn.microsoft.com/en-us/library/b2s063f7.aspx)

5. Конфигурацию SMTP сервера вынести в файл конфигурации. Не нужно указывать реальные настройки вашего GMAIL аккаунта или SMTP релея!

6. Разработку сервиса выполнить на c# .NET. В VisualStudio 2015+ (2015 и 2017 есть CommunityEdition) либо в VisualStudioCode (для linux). 

7. Для разработки сервиса использовать строго ASP.NET Core (любой удобной версии).

8. В качестве СУБД можно использовать любую реляционную (PgSQL, MySQL, MS SQL, или другую, с которой знакомы).

9. В качестве ORM фреймворка можно использовать EntityFramework или NHibernate или Dapper. Если используется Dapper, то схему БД выдать в виде SQL скрипта (CREATE DATABASE…).

10. Библиотеку для отправки сообщений выбрать на свое усмотрение.
