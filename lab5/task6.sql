/* кількість квартир з однаковою ціною в одному районі ,яка перевищує 3 */
select count(*) area ,price
from [Table]
group by price
having count(*) >3