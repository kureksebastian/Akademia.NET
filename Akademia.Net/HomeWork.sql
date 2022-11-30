select i.Number, c.FirstName, c.LastName
from Clients c 
join Invoices i on c.Id = i.ClientNumber


select i.Number, p.Name, p.Price
from Products p 
join InvoicePositions ips on ips.ProductId = p.Id
join Invoices i on i.Id = ips.InvoiceId


select i.Number, SUM(ips.Quantity) as suma
from InvoicePositions ips
join Invoices i on i.Id = ips.InvoiceId
group by i.Number


select i.Number as [Numer FV], SUM(ips.Quantity * p.Price) as cenaCalkowita
from Products p 
join InvoicePositions ips on ips.ProductId = p.Id
join Invoices i on i.Id = ips.InvoiceId
group by i.Number