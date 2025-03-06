# Исследование законов Фиттса и Хика в C# WinForms

## 📌 О проекте  
Этот проект представляет собой экспериментальное исследование **закона Фиттса** и **закона Хика** с использованием C# WinForms. Программа измеряет время реакции пользователя при различных условиях, моделируя реальные когнитивно-моторные задачи.  

## 📁 Структура проекта  
- **Lab_i1** — проект для проверки закона Фиттса.  
- **Lab_i2** — проект для проверки закона Хика.  

## 📖 Описание экспериментов  

### 🔹 Закон Фиттса (Lab_i1)  
Закон Фиттса описывает зависимость времени достижения цели от ее размера и расстояния до нее.  
Формула:  
T = a + b * log2(S / D + 1)

- **Первая серия**: фиксированный размер мишени, разное расстояние.  
- **Вторая серия**: фиксированное расстояние, разный размер мишени.  
- **Третья серия**: комбинированные изменения (разные S и D).  

**Как работает:**  
Пользователь кликает по случайно появляющейся мишени, программа фиксирует время реакции и записывает данные в файл.  

### 🔹 Закон Хика (Lab_i2)  
Закон Хика гласит, что время реакции зависит от количества возможных выборов.  
Формула:  
T = a + b * log2(N + 1)

- **Эксперимент**: пользователю предлагается выбрать один из N вариантов, время выбора фиксируется.  

**Как работает:**  
Появляется несколько кнопок, пользователь должен выбрать правильную. Количество вариантов варьируется.  

## 🛠️ Как запустить  
1. **Склонируйте репозиторий**:  
   ```sh
   git clone https://github.com/FedkinDmitriy/Lab_works_interfaces.git
   ```
2. **Откройте проект в Visual Studio**.  
3. **Выберите нужный проект** (`Lab_i1` или `Lab_i2`) и запустите.  

## 📊 Сбор и анализ данных  
Результаты сохраняются в файлы txt и csv
