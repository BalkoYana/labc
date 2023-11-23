/*порахувати кількість квартир з однаковою вартістю*/
select count(*)
from [Table]
group by price
