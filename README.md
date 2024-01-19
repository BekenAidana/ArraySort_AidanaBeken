# ArraySort_AidanaBeken

## Функционал

Этот проект включает в себя следующие функции:

- Создание `n` объектов с рандомным цветом и значением `x`, которое используется для сортировки.
- Возможность выбора метода сортировки
  - Сортировка пузырьком
  - Сортировка вставками
  - Сортировка выбором
  - Быстрая сортировка
- Плавное перемещение объектов на целевые позиции после сортировки.
- Удаление всех объектов со сцены.

## Как Использовать

Чтобы использовать этот проект, выполните следующие шаги:

1. **Открытие Сцены:**
   Запустите сцену в Unity.

2. **Ввод Количества Объектов:**
   Введите числовое значение `n` во входное поле. Это число определит количество создаваемых объектов.

3. **Создание Объектов:**
   Нажмите на кнопку `Random create`. Это создаст `n` объектов с случайным цветом. Размер объекта будет пропорционален значению объекта, которое также определяется случайно.

4. **Выбор Вида Сортировки:**
   Выберите метод сортировки.

5. **Сортировка Объектов:**
   Нажмите на кнопку `Sort` для запуска процесса сортировки.

6. **Завершение Сортировки:**
   По желанию отключите плавное перемещение, нажав `Finish`.

7. **Удаление или Пересоздание Объектов:**
   Чтобы удалить все объекты, нажмите на `Remove`. Чтобы удалить текущие объекты и создать новые, повторно нажмите `Random Create` с новым или тем же значением во входном поле.

## Примечания
- Для демонстрации плавного перемещения рекомендуется использовать значения до 12, так как большее количество объектов может не поместиться в кадр камеры. Для сравнения алгоритмов сортировки можно использовать значение до 1000. Время выполнения сортировки будет отображаться в консоли.
- Во время сортировки кнопки `Random Create`, `Sort` и `Remove` будут неактивны.
- Доступ к кнопкам восстанавливается после завершения перемещения объектов.
