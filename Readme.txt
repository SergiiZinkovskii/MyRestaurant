# MyRestoraunt Цей проект буде представляти собою систему управління рестораном, розроблену на платформі ASP.NET Core 6.0 з використанням Entity Framework Core для доступу до бази даних. Система дозволить ресторанам управляти замовленнями, стравами та іншими аспектами роботи ресторану. 
# Основні функції
# Управління Замовленнями: Система дозволятиме створювати та відстежувати замовлення. Кожне замовлення містить інформацію про страви, адресу доставки, дату створення та інші важливі дані.

# Управління Стравами: Адміністратори ресторану зможуть додавати, редагувати та видаляти страви з меню. Для кожної страви можна вказати назву, опис, ціну та інші характеристики.

# Система Автентифікації та Авторизації: Використовується механізм аутентифікації за допомогою кукі. Користувачі можуть входити в систему, адміністратори мають спеціальні права доступу для управління даними.

# Візуалізація Даних: Система надає можливість відображати дані про замовлення, страви та інші аспекти ресторанного бізнесу у зручному візуальному вигляді.

# Конфігурування Бази Даних: Для зручності, конфігурація бази даних реалізована за допомогою Entity Framework Core. 

# Проект розроблений, використовуючи шаблон архітектури MVC (Model-View-Controller), що дозволяє розділити логіку додатку на різні компоненти з чітко визначеними обов'язками.

# Компоненти Архітектури
# Моделі (Models): Відображають бізнес-об'єкти та структури даних. В даному проекті, вони відображаються в класах, наприклад, Order, Dish, і т.д.

# Контролери (Controllers): Оброблюють HTTP-запити від користувачів та взаємодіють з моделями та пересилають дані в представлення (views). Вони відповідають за керування взаємодією між веб-інтерфейсом та бізнес-логікою. Приклади: OrderController, DishController.

# Представлення (Views): Отримують дані від контролера та відображають їх для користувача. Використовуються HTML-шаблони та додаткові допоміжні засоби (наприклад, Razor) для вбудовування даних.

# Сервіси (Services): Містять бізнес-логіку та логіку взаємодії з базою даних. Вони допомагають уникнути безпосередньої залежності контролерів від репозиторіїв або бази даних.

# Репозиторії (Repositories): Відповідають за доступ до бази даних та взаємодію з моделями. Вони допомагають відділити бізнес-логіку від деталей зберігання даних.