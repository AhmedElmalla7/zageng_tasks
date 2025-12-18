use cust_orders

select concat(first_name,last_name) as [Full_Name] ,Order_id ,Amount
from Customers c full join orders o
on c.customer_id = o.customer_id
