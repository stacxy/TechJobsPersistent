#--Part 1
select column_name, data_type
from information_schema.columns
where table_name = 'jobs';

#--Part 2
SELECT name 
FROM employers
WHERE Location = "Saint Louis";

#--Part 3
SELECT Name, Description
from techjobs.skills
INNER JOIN jobskills ON skills.id = jobskills.SkillId
ORDER BY Name;
