# Приложение для спортивного комплекса "Muscule"
## Состав команды
* Божков Олег Антонович (@SeriysLay)
* Евдокимов Артем Денисович (@mFoxes)
* Еременко Иван Михайлович (@Ivan-Kalyvan)

## Функциональные требования
* получение рабочего расписания тренера
* получение списка тренировок пользователя
* получение расписания тренировок всего комплекса
* админ может добавлять/удалять новых тренеров
* админ может изменять расписание тренера
* регистрация и авторизация пользователей
* получение информации о тренерах(могут просматривать даже не зарегистрированные пользователи)

## Нефункциональные требования
* интуитивно понятный интерфейс пользователя
* быстрая скорость отклика на пользовательские запросы
* учетным данным пользователя ничего не угрожает
* приложение не зависает от фонового выполнения задачи, а продолжает отвечать на отклики пользователя

## Данные
### База данных пользователя
#### Subscribtion
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |
| price           | float         |
| count           | int           |

#### User
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |
| dob             | datatime      |
| mail            | string        |
| password        | string        |
| phone           | string        |
| id_role         | int           |

#### Subscribtion_to_User
| name            | type          |
| --------------- |:-------------:|
| id_subscription | int           |
| id_user         | int           |
| start_data      | datatime      |

#### Role
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |
| descr           | string        |

#### Documet
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |
| photo           | string        |
| descr           | string        |
| id_user         | int           |

#### Coach
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| descr           | string        |
| id_direction    | int           |

### База данных оборудования
#### Equipment
| name            | type          |
| --------------- |:-------------:|
| id | int |
| name | string |
| descr | string |

#### Hall
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |
| id_building     | int           |

#### Equipment_to_Hall
| name            | type          |
| --------------- |:-------------:|
| id_equipment    | int           |
| id_hall         | int           |
| quantity        | int           |

#### Building
| name            | type          |
| --------------- |:-------------:|
| id              | int           |
| name            | string        |

#### Direction
| name            | type          |
| --------------- |:-------------:|
| id              | int     |
| name            | string |
| id_building     | int           |
| descr           | string |

## Ипользованные библиотеки:
* EntityFrameworkCore - технология, которая используется для связи с базами данных, позволяет взаимодействовать с СУБД
* EntityFrameworkCore.Tools - инструменты для упраления миграциями и формирования DBContext
* Npgsql.EntityFrameworkCore.PostgreSQL - библиотека для связи с СУБД postgeSQL
