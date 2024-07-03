USE RecruitmentWeb

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

-- SELECT *
-- from dbo.Recruiter
-- select *
-- from AspNetUsers
-- where Id='0a83d50d-1c70-44ef-9f0c-da0cde344d5f'
-- select *
-- from AspNetUserRoles;

select u.id, u.UserName, u.Email, r.Name, u.EmailConfirmed
from dbo.AspNetUsers as u join dbo.AspNetUserRoles as ur on (u.Id = ur.UserId) JOIN AspNetRoles as r on (ur.RoleId=r.Id)


