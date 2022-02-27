select Clients.ClientName
from testdb.dbo.Clients
left join dbo.ClientContacts on ClientContacts.ClientId = Clients.Id
group by Clients.ClientName
having count(ClientContacts.Id) > 2