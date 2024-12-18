create  Database skills; 
CREATE TABLE Users
(
    user_id SERIAL PRIMARY KEY,
    full_name VARCHAR(150) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    phone VARCHAR(20) UNIQUE,
    city VARCHAR(100),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)


CREATE TABLE Requests (
                          Request_Id SERIAL PRIMARY KEY,
                          from_user_id INT REFERENCES users(user_id) ,
                          to_user_id INT REFERENCES users(user_id),
                          requested_Skill_Id INT REFERENCES skills(skill_id),
                          offered_Skill_Id INT REFERENCES skills(skill_id,
                                                                 Status VARCHAR(20) NOT NULL DEFAULT 'Pending', -- Статус запроса: Pending, Accepted, Rejected
                                                                 Created_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата создания запроса
                                                                 Updated_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата последнего обновления запроса
                              )

                              CREATE TABLE Skills (
    Skill_Id SERIAL PRIMARY KEY,               -- Уникальный идентификатор навыка или услуги (автоинкремент)
    User_Id IN REFERENCES users(user_id) NOT NULL,                      -- ID пользователя, предложившего навык или услугу
    Title VARCHAR(150) NOT NULL,             -- Название навыка или услуги
    Description TEXT,                        -- Описание навыка или услуги
    Created_At TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Дата добавления навыка или услуги
 )