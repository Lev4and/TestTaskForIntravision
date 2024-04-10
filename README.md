Тестовое задание на разработку Web приложения «Автомат по продаже напитков»

Реализованы все основные требования, а также необязательные за исключением «Возможности импорта напитков»

Backend

Стэк: .NET Core 8.0, ASP.NET Core WebAPI, MediatR, FluentValidation, EntityFrameworkCore, Serilog, Swagger, Asp.Versioning

База данных: PostregeSQL

Как запустить?

Через IIS Express

Где находяться строки подключения к PostregeSQL?

Внутри поекта «TestTaskForIntravision.WebApi» в файлах конфигурации «appsettings.*.json» в разделе «ConnectionStrings».

Frontend

Стэк: Vue.js 2, Vite.js, Vue Router, Bootstrap 5, Pinia, Axios, Lodash, Eslint, Prettier

Как запустить?

- Перейти в папку проекта;
- Перейти в папку «src»;
- Перейти в папку «UIs»;
- Перейти в папку «vue-js-app»;
- Открыть терминал;
- Ввести комманду «npm i»;
- Ввести комманду «npm run dev».

Как перейти в панель администратора?

В адреной строке указать «/admin?secret=admin»
