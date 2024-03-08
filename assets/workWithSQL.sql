begin TRANSACTION
DECLARE @user NVARCHAR(450)
DECLARE @role NVARCHAR(450)

SELECT @user=id
from dbo.AspNetUsers
where UserName='lyhongphat'
-- SELECT @role=id
-- from dbo.AspNetRoles
-- where Name='Recruiter'

-- insert into dbo.AspNetUserRoles
--     (UserId, RoleId)
-- VALUES
--     (@user, @role)

DELETE Candidate WHERE UserId=@user
delete AspNetUsers where Id=@user

commit TRANSACTION

-- SELECT *
-- from dbo.Recruiter
-- select *
-- from AspNetUsers
-- where Id='0a83d50d-1c70-44ef-9f0c-da0cde344d5f'
-- select *
-- from AspNetUserRoles;

select u.UserName, ur.RoleId, r.Name
from dbo.AspNetUsers as u JOIN dbo.AspNetUserRoles as ur on (u.Id = ur.UserId) JOIN dbo.AspNetRoles as r on (ur.RoleId = r.Id)


select *
from dbo.AspNetRoles
select *
from dbo.AspNetUsers

select *
from dbo.[Position]
select *
from dbo.Recruiter

update dbo.[Position] set isDeleted = 0