# Blazor - Lista ćwiczeń do utrwalania wiedzy

## Przygotowanie projektu

- [X] Utwórz nowy projekt Blazor Server/WebAssembly
    - Nazwij projekt: `BlazorDemo`
    - Dodaj folder `Demos` w głównym katalogu projektu

## CLI

### Interactivity: NONE

- `dotnet new blazor -int None -o src\BlazorIntNoneDemo -f net9.0 -lang C# -au None -n BlazorIntNoneDemo`
- `dotnet sln add src\BlazorIntNoneDemo`

### Interactivity: Server

- `dotnet new blazor -int Server -o src\BlazorIntServerDemo -n BlazorIntServerDemo -f net9.0 -lang C# -au None `
- `dotnet sln add src\BlazorIntServerDemo`

### Interactivity: WebAssembly

-
`dotnet new blazor -int WebAssembly -o src\BlazorIntWebAssemblyDemo -n BlazorIntWebAssemblyDemo -f net9.0 -lang C# -au None`

### Interactivity: AUTO

- `dotnet new blazor -int Auto -o src\BlazorIntAutoDemo -n BlazorIntAutoDemo -f net9.0 -lang C# -au None`

---

## 1. Składnia Razor - Podstawy

### Zadania:

- [X] **Utwórz komponent `RazorSyntaxDemo.razor`**
- [X] **Implicit Razor expressions**
    - Wyświetl swoję imię: `@name`
    - Wyświetl liczbę: `@count`
- [X] **Explicit Razor expressions**
    - Wyświetl aktualną datę: `@(DateTime.Now)`
    - Wyświetl wynik obliczeń: `@((10 + 5) * 2)`
- [X] **Bloki kodu @{ }**
    - Stwórz metodę `GetWelcomeMessage()` zwracającą string
    - Wywołaj metodę w HTML i wyświetl rezultat

---

## 2. Routing i parametry

### Zadania:

- [X] **Utwórz komponent `RoutingDemo.razor`**
- [X] **Implementuj następujące ścieżki:**
    - `/routing-demo` - strona główna
    - `/routing-demo/{id:int}` - parametr liczbowy
    - `/routing-demo/user/{name}` - parametr tekstowy
    - `/routing-demo/videos/{categoryId:int}/{videoId:int}` - multiple parametry
- [X] **Dodaj obsługę Query Parameters**
    - `?firstName=Jan&lastName=Kowalski`
- [X] **Utwórz osobny plik Code-Behind**
    - `RoutingDemo.razor.cs` z logiką routingu

---

## 3. Parametry komponentów

### Zadania:

- [X] **Utwórz komponent `UserCard.razor`**
- [X] **Dodaj parametry z walidacją:**
    - `Name` - wymagany parametr
    - `Age` - opcjonalny parametr
    - `Email` - z Query Parameter
- [X] **Użyj atrybutów:**
    - `[EditorRequired]` dla wymaganego parametru
    - `[SupplyParameterFromQuery]` dla email

---

## 4. Dependency Injection

### Zadania:

- [X] **Utwórz nowy projekt biblioteki klas `BlazorServices`**
- [X] **Stwórz interfejs `IGreetingService`**
- [X] **Implementuj serwisy:**
    - `TransientGreetingService` - nowa instancja przy każdym wywołaniu
    - `SingletonGreetingService` - jedna instancja dla całej aplikacji
    - `ScopedGreetingService` - jedna instancja per request
- [X] **Zarejestruj serwisy w `Program.cs`**
- [X] **Utwórz komponent `ServiceDemo.razor` używający wszystkich serwisów**

---

## 5. Komponenty generyczne

### Zadania:

- [X] **Utwórz komponent `GenericList.razor`**
- [X] **Dodaj parametr generyczny `@typeparam TItem`**
- [X] **Implementuj wyświetlanie listy:**
    - Lista stringów
    - Lista liczb
    - Lista custom obiektów

---

## 6. Atrybuty komponentów

### Zadania:

- [X] **Utwórz komponent z atrybutem `[Authorize]`**
- [X] **Implementuj custom `RouteAttribute`**
- [X] **Utwórz `MyButton.razor` z `CaptureUnmatchedValues`**
- [X] **Przetestuj przekazywanie dodatkowych atrybutów HTML**

---

## 7. Zarządzanie importami

### Zadania:

- [X] **Utwórz folder `Admin` w `Demos`**
- [X] **Dodaj `_Imports.razor` tylko dla folderu `Admin`**
- [X] **Dodaj specyficzne importy dla komponentów administracyjnych**
- [X] **Utwórz komponent `AdminPanel.razor` używający tych importów**

---

## 8. Custom Layout

### Zadania:

- [X] **Utwórz `CustomLayout.razor`**
- [X] **Implementuj niestandardowy layout z:**
    - Header
    - Sidebar
    - Main content area
    - Footer
- [X] **Utwórz komponent używający tego layoutu**
- [X] **Dodaj `_Imports.razor` dla layoutu**

---

## 9. Event Handling

### Zadania:

- [X] **Utwórz `Counter.razor` z podstawowym onclick**
- [X] **Implementuj `MyButton` z EventCallback**
- [X] **Stwórz komponent `CounterWithButton` używający MyButton**
- [X] **Dodaj invoke async event handling**

---

## 10. Data Binding

### Zadania:

- [X] **Utwórz `DataBindingDemo.razor`**
- [X] **Implementuj różne typy bindowania dla znaczników html oraz wbudowanych komponentów Razor np. 'InputTexxt':**
    - dwukierunkowe
    - jednokierunkowe
    - z custom eventem
- [X] **Stwórz custom komponent z bindingiem**
- [X] **Dodaj `Value`, `ValueChanged`, `ValueExpression`**

---

## 11. StateHasChanged i Lifecycle

### Zadania:

- [X] **Utwórz `ClockComponent.razor`**
    - Wyświetl aktualny czas
    - Aktualizuj co sekundę
    - Użyj `StateHasChanged()`
- [X] **W `MyButton.razor`**
    - Po kliknięciu staje się disabled na 2 sekundy
    - Automatycznie wraca do stanu aktywnego

---

## 12. Cascading Parameters

### Zadania:

- [X] **Utwórz component CascadeDemo.razor'
- [X] **Przekaż parametry bez cascade**
- [X] **Utwórz model `UserContext`**
- [X] **Implementuj `CascadingValue` w głównym komponencie**
- [X] **Stwórz komponenty potomne używające `CascadingParameter`**
- [X] **Przekaż parametr po typie i nazwie np. 'CParam'**
- [X] **Porównaj wydajność z i bez `IsFixed="true"`**
- [X] **Dodaj cascading parameter na poziomie root (Program.cs)**

---

## 13. Code-Behind Pattern

### Zadania:

- [X] **Utwórz `ProductList.razor` i `ProductList.razor.cs`**
- [X] **Przenieś całą logikę do pliku .cs**
- [X] **Implementuj partial class**

---

