# **DIPLOMSKI**
**Migracija monolitnog sistema na distribuiranu mikroservisnu arhitekturu uz upotrebu SAGA sablona**

***Zadatak: Izvršti pregled literature, identifikovati moguće podele postojećih servisa na mikroservise koristeći metode dostupne u literaturi. Implementirati podelu. Upotrebiti Saga šablon na mestima gde je potrebna distribuirana transakcija.***

Pre pokretanja aplikacije, neophodno je instalirati softvere sa sledecih linkova https://www.erlang.org/ https://www.rabbitmq.com/

Nakon instalacije, proveriti da li je pokrenut RabbitMQ servis, inicijalni kredencijali su guest/guest -> http://localhost:15672/#/

Neohodno je rucno kreirati bazu za pracenje saga stanja, query za kreirenje tabele se nalazi u root-u repositorijuma FligthStateData.sql, zatim promenuti connection string u svakom appsettings.json fajlu od svakog pojedinacnog mikroserivisa i kod SagaMachine projekta u Program.cs-u.

Solution aplikacije se nalazi u folderu MAANPP20, neohodno je pokrenuti solution u Multiple startup projects modu, redosled aplikacija je sledeci:
  1. SagaMachine : Start
  2. AvioMicroservice : Start without debbuing
  3. CarMicroservice : Start without debbuing
  4. HotelMicroservice : Start without debbuing
  5. PaymentMicroservice : Start without debbuing
  6. UserMicroservice : Start without debbuing
  
Nakon uspesnog pokretanja solution-a, prvo kreirati bar po jedan entitet za svaku tabelu saga ucesnika pozivanjem sledecih api-ja iz aplikacije *Postman* :
  1. CarMicroservis:
    POST :
    https://localhost:{port}/api/Automobile/add
    {
      "Grad" : "Belgrade",
      "Avaible" : 10
    }
    
  2. HotelMikroservice:
    POST : 
    https://localhost:{port}/api/Hotel/add
    {
      "Grad" : "Belgrade",
      "Avaible" : 10
    }
  3. PaymentMikroservice: 
    POST : 
    https://localhost:{port}/api/Payment/add
    {
      "UserId" : "b0ef8d6e-769c-4fa5-ad40-eb3be04aabc5",
      "Avaible" : 267.6
    }

Nakon sto su dodati entiteti u tabelama, sad se moze testirati saga pozivom sledeceg api-ja:
  https://localhost:{port}/api/FlightSaga/reserve
  {
    "UserId": "b0ef8d6e-769c-4fa5-ad40-eb3be04aabc5",
    "Grad": "Belgrade",
    "Cena": 178.5
  }
  
Prikaz svih pojedinacnih tabela se nalazi u listingu *AllSagaTables.sql*.

Napomena: za potrene testiranja sage, nije neophodan rad UserMicroservisa.
