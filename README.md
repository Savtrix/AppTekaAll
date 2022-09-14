Opis Projektu
Projekt składa się z 2 elementów: AppTeka - który otrzymuje polecenia przez REST API oraz wykonuje je na bazie oraz Klienta MVC który odpowiada 
za komunikację pomiędzy WWW oraz serwerem REST. Całość wykonana jest w .NET 6.
Uruchomienie
Wczytanie projektu do VS 2022 , uruchomienie konsoli dev oraz wykonanie migracji bazy AppTeka( dotnet ef database update)
projekt jest już skompilowany więc następnie wystarczy uruchomić AppTeka.exe oraz ClientMVC.exe.
Poza graficzną obsługą bazy , zmiany można wykonywać również za pomocą swaggera lub postmana.
aplikacje mają ustawione adresy "na sztywno"- dla klienta są to https://localhost:5005 oraz https://localhost:5006 natomiast dla serwera REST
przez postmana https://localhost:5000 oraz 5001, żeby uruchomić swaggera wystarczy dopisać /swagger
