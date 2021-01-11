# DIPLOMSKI
Migracija monolitnog sistema na distribuiranu mikroservisnu arhitekturu uz upotrebu SAGA sablona

Zadatak: Izvršti pregled literature, identifikovati moguće podele postojećih servisa na mikroservise koristeći metode dostupne u literaturi. Implementirati podelu. Upotrebiti Saga šablon na mestima gde je potrebna distribuirana transakcija.

Pre pokretanja aplikacije, neophodno je instalirati softvere sa sledecih linkova https://www.erlang.org/ https://www.rabbitmq.com/

Nakon instalacije, proveriti da li je pokrenut RabbitMQ servis, inicijalni kredencijali su guest/guest -> http://localhost:15672/#/

Neohodno je rucko kreirati bazu za pracenje saga stanja, query za kreirenje tabele se nalazi u root-u repositorijuma FligthStateData.sql

Solution aplikacije se nalazi u folderu MAANPP20, neohodno je pokrenuti solution u Multiple startup projects modu, redosled aplikacija je sledeci:
  1. SagaMachine : Start
  2. AvioMicroservice : Start without debbuing
  3. CarMicroservice : Start without debbuing
  4. HotelMicroservice : Start without debbuing
  5. PaymentMicroservice : Start without debbuing
  6. UserMicroservice : Start without debbuing
