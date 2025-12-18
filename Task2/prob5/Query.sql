use Emp_Dept

select emp_name , isnull(dept_name,'Unassigned') as dept_name
from Employees e left join Departments d
on e.dept_id = d.dept_id