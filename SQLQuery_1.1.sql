select Clients.ClientName, count(ClientContacts.Id)
from testdb.dbo.Clients
left join dbo.ClientContacts on ClientContacts.ClientId = Clients.Id
group by Clients.ClientName