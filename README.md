# Solarlab.Academy.2023
Учебный проект в рамках курса Соларлаб Академия Backend 2023
![SolarAcademy Backend](https://user-images.githubusercontent.com/17419660/223259887-1c2a400d-08f0-42c8-bfd2-6669c1ac7642.jpg)

## docker-compose 

- Для запуска контейнеров выполняем:

	`docker-compose up -d`
	
  Запускаются сервисы:
  - персистентный сервис для работы с БД (PostgreSQL):
    - 5432:5432
  - сервис WebAPI (прокидываем 80-й порт из контрейнера на 5000-й порт локальной машины:
    - 5000:80  

- Проверить состояние сервисов: 
  
  `docker-compose ps` 

- Отключение: 
  
  `docker-compose down` 
  
  (порты свободны, сохраняется **persisted volume** для БД).
