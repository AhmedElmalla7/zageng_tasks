use Supp_Prod

select product_name ,supplier_name
from Products p  left join Suppliers s
on p.supplier_id = s.supplier_id
where p.product_name like '%Phone%'	