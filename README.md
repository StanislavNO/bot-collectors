# bot-collectors

## 🎥 Демонстрация

📺 [Смотреть демо на YouTube](https://youtu.be/lXjnF72bpWo)

## 🚀 Возможности

- 🤖 Боты с FSM (Finite State Machine)
- 🧭 Навигация через NavMesh
- 📦 Сбор ресурсов с респавном и пулом объектов
- 🎞 Анимации и масштабирование через DoTween и аниматор
- 🧩 Внедрение зависимостей через Zenject
- 🎥 Камера, следящая за юнитами
- 👁 Отрисовка пути 
- Возможность изменять скорость ботов видимость пути и количество ботов в фракции искользуя UI

## 🛠️ Используемые технологии

- Unity `2022.3 LTS`
- C#
- NavMesh
- [Zenject](https://github.com/modesttree/Zenject)
- [DoTween](http://dotween.demigiant.com/)

## Структура папок

Assets/
└── Source/
    ├── CodeBase/
    │   ├── Configs/
    │   ├── Controllers/     
    │   ├── GameData/
    │   ├── GameplayModels/
            ├── Bot/
            ├── Camera
            ├── Loot
    │   ├── Infrastructure/
            ├── Installers/
            ├── Presenters
            ├── Services
    │   └── View/
    

## 📦 Установка

1. Клонируй репозиторий:
   ```bash
   git clone https://github.com/StanislavNO/bot-collectors.git
