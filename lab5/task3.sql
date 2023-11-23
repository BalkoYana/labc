/*вибрати квартири які знаходяться на 1 поверсі і ціна більша 1000*/
select [Table].floor,[Table].price
from [Table]
where price>1000
and floor='1'