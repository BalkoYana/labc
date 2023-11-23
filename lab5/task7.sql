/*посортувати у порядку зростання ціни на квартиру*/
select count(*) price, (price) area
from [Table]
group by price
order by [Table].price ASC;