SELECT * FROM [MAANPP20-SAGA].[dbo].[FlightStateData] order by CreationDateTime desc

SELECT * FROM [MAANPP20-F].[dbo].[SagaFlightReservations]

SELECT * FROM [MAANPP20-C].[dbo].[Automobiles] where Grad='Belgrade'

SELECT * FROM [MAANPP20-H].[dbo].[Hotels] where Grad='Belgrade'

SELECT p.UserId, u.firstName, u.lastName, u.Email, p.Avaible, p.Updated FROM [MAANPP20-P].[dbo].[Payments] as p left join [MAANPP20-U].[dbo].[Users] as u on p.UserId=u.Id

