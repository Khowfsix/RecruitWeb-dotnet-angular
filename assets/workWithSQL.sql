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

select u.Id, u.UserName, ur.RoleId, r.Name as roleName
from dbo.AspNetUsers as u JOIN dbo.AspNetUserRoles as ur on (u.Id = ur.UserId) JOIN dbo.AspNetRoles as r on (ur.RoleId = r.Id)

select *
from dbo.Candidate

select *
from dbo.[Position]
select *
from dbo.Candidate
update dbo.[Position] set isDeleted = 0



-- INSERT [dbo].[CategoryPosition]
--     ([CategoryPositionId], [CategoryPositionName], [CategoryPositionDescription])
-- VALUES
--     (N'9c740272-34ff-4ce2-9133-f87f71dda321', N'Management', N'Management')
-- GO
-- INSERT [dbo].[CategoryPosition]
--     ([CategoryPositionId], [CategoryPositionName], [CategoryPositionDescription])
-- VALUES
--     (N'9c740272-34ff-4ce2-9133-f87f71dda325', N'Construction', N'Construction')
-- GO

select *
from Recruiter;

select *
from Company;

SELECT *
from refreshtoken