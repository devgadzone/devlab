# SimpleTodoList

Prosty projekt konsolowy .NET do zarządzania listą zadań (TODO) z wykorzystaniem SQLite oraz Dapper. Aplikacja pozwala dodawać, przeglądać, aktualizować i usuwać zadania, zapisując je w lokalnym pliku bazy danych.

## Funkcje
- Przegląd wszystkich zadań
- Dodawanie nowego zadania
- Aktualizacja opisu istniejącego zadania
- Usuwanie zadania
- Automatyczne tworzenie bazy danych (SQLite) przy pierwszym uruchomieniu

## Stos technologiczny
- Język: C#
- Platforma: .NET 9.0
- Baza danych: SQLite (plik `Todos.db` w katalogu uruchomieniowym)
- ORM/Mapper: Dapper

## Struktura projektu
```
SimpleTodoList.sln
src\ConsoleSimpleTodoList\
  ├─ ConsoleSimpleTodoList.csproj
  ├─ Program.cs
  ├─ SqlActions.cs
  └─ Todo.cs
```

## Wymagania
- Zainstalowany .NET SDK 9.0 lub nowszy: https://dotnet.microsoft.com/

Sprawdzenie wersji:
```
dotnet --version
```

## Uruchomienie
W konsoli/PowerShell przejdź do katalogu głównego repozytorium i wykonaj:

1) Przygotowanie pakietów i kompilacja:
```
dotnet restore
 dotnet build
```

2) Uruchomienie aplikacji konsolowej:
```
dotnet run --project src\ConsoleSimpleTodoList\ConsoleSimpleTodoList.csproj
```

Przy pierwszym uruchomieniu aplikacja utworzy lokalny plik bazy danych `Todos.db` oraz tabelę `Todos` (jeśli jeszcze nie istnieje).

## Jak używać
Po uruchomieniu zobaczysz menu:
```
What do you want to do?

[S]see all todos
[A]dd a todo
[U]pdate todo
[R]emove a todo
[E]xit
```
Wpisz literę odpowiadającą operacji i zatwierdź Enter.

- S — wyświetla wszystkie zadania (ID, opis, data utworzenia)
- A — dodaje nowe zadanie (poprosi o unikalny opis)
- U — aktualizuje istniejące zadanie (najpierw wybierasz ID, następnie nowy opis)
- R — usuwa zadanie (po podaniu ID)
- E — kończy działanie programu

Uwagi:
- Aplikacja waliduje podstawowe dane wejściowe (np. ID musi być liczbą, opis nie może być pusty).
- Daty zapisywane są jako tekst w SQLite; kolejność listy bazuje na CreatedAt malejąco (najnowsze na górze).

## Plik bazy danych
- Domyślny łańcuch połączenia: `Data Source=Todos.db;`
- Plik `Todos.db` znajduje się w katalogu roboczym procesu (np. `src\ConsoleSimpleTodoList\bin\Debug\net9.0` podczas uruchamiania z IDE lub polecenia `dotnet run`).

## Rozwój
- Styl nullowalności i ostrzeżenia: włączone (`<Nullable>enable</Nullable>`, `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`)
- Ewentualne dalsze refaktoryzacje mogą wydzielić warstwy Models/Persistence/Repositories (foldery są już przygotowane w csproj).
