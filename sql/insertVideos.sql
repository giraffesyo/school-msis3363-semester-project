--DELETE FROM videos;
-- insert initial team building videos
INSERT INTO videos (name, link, topicId) SELECT 'How to build a team', 'https://www.youtube.com/embed/xFxavUOfn9k', id from videoTopics where name = 'Team Building';
INSERT INTO videos (name, link, topicId) SELECT 'Start Stop Continue', 'https://www.youtube.com/embed/NKN6Ad78gfA', id from videoTopics where name = 'Team Building';
INSERT INTO videos (name, link, topicId) SELECT 'Good teamwork Bad teamwork', 'https://www.youtube.com/embed/fUXdrl9ch_Q', id from videoTopics where name = 'Team Building';
-- insert initial communication videos
INSERT INTO videos (name, link, topicId) SELECT '5 Communication Tips', 'https://www.youtube.com/embed/xr1q-uBtIH4', id from videoTopics where name = 'Communication';
INSERT INTO videos (name, link, topicId) SELECT 'Kiss vs Kill', 'https://www.youtube.com/embed/sHeFWHpmHSM', id from videoTopics where name = 'Communication';
INSERT INTO videos (name, link, topicId) SELECT 'Art of Communication', 'https://www.youtube.com/embed/KqKAG-hRIyE', id from videoTopics where name = 'Communication';
-- insert initial leadership videos
INSERT INTO videos (name, link, topicId) SELECT 'Steve Jobs Leadership Breakdown', 'https://www.youtube.com/embed/dVLERJ5IdrA', id from videoTopics where name = 'Leadership';
INSERT INTO videos (name, link, topicId) SELECT 'Psychology of Exceptional Leaders', 'https://www.youtube.com/embed/mBNoUhHtmVc', id from videoTopics where name = 'Leadership';
INSERT INTO videos (name, link, topicId) SELECT 'Leadership in Utopia', 'https://www.youtube.com/embed/vlpKyLklDDY', id from videoTopics where name = 'Leadership';
-- insert initial management videos
INSERT INTO videos (name, link, topicId) SELECT 'How to manage', 'https://www.youtube.com/embed/PWmhl6rzVpM', id from videoTopics where name = 'Management';
INSERT INTO videos (name, link, topicId) SELECT 'Speak like a Manager', 'https://www.youtube.com/embed/TUSxq7KoTsM', id from videoTopics where name = 'Management';
INSERT INTO videos (name, link, topicId) SELECT 'Lead people and tasks', 'https://www.youtube.com/embed/-8JCSCf_wA4', id from videoTopics where name = 'Management';
-- insert initial technology videos
INSERT INTO videos (name, link, topicId) SELECT 'React with MVC 5', 'https://www.youtube.com/embed/xq9XkCyWBTw', id from videoTopics where name = 'Technology';
INSERT INTO videos (name, link, topicId) SELECT 'React for beginners', 'https://www.youtube.com/embed/6Ied4aZxUzc', id from videoTopics where name = 'Technology';
INSERT INTO videos (name, link, topicId) SELECT 'Redux Crash Course', 'https://www.youtube.com/embed/93p3LxR9xfM', id from videoTopics where name = 'Technology';