--USE RecruitmentWeb

-- BEGIN TRANSACTION
-- DECLARE @user NVARCHAR(450);
-- DECLARE @role NVARCHAR(450);

-- SELECT @user=id
-- from dbo.AspNetUsers AS u
-- where UserName='lyhongphat';

-- SELECT @role=id
-- from dbo.AspNetRoles
-- where Name='Recruiter';

-- insert into dbo.AspNetUserRoles
--     (UserId, RoleId)
-- VALUES
--     (@user, @role);

-- commit TRANSACTION;


--update dbo.Application set Company_Status = 102014 
--select * from dbo.Application

select u.Id, u.UserName, u.FullName, r.Name as roleName
from dbo.AspNetUsers as 
u JOIN dbo.AspNetUserRoles as ur on (u.Id = ur.UserId) JOIN dbo.AspNetRoles as r on (ur.RoleId = r.Id)
WHERE r.Name='Candidate'

--update dbo.Interview set Notes=N'Nhớ đem theo não'

select * from dbo.Interview