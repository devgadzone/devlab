# Blazor - Lista ćwiczeń do utrwalania wiedzy

## Przygotowanie projektu
- [X] Utwórz nowy projekt Blazor Server/WebAssembly
  - Nazwij projekt: `BlazorDemo`
  - Dodaj folder `Demos` w głównym katalogu projektu
##  CLI
### Interactivity: NONE
  - `dotnet new blazor -int None -o src\BlazorIntNoneDemo -f net9.0 -lang C# -au None -n BlazorIntNoneDemo`
  - `dotnet sln add src\BlazorIntNoneDemo`

### Interactivity: Server
  - `dotnet new blazor -int Server -o src\BlazorIntServerDemo -n BlazorIntServerDemo -f net9.0 -lang C# -au None `
  - `dotnet sln add src\BlazorIntServerDemo`

### Interactivity: WebAssembly
  - `dotnet new blazor -int WebAssembly -o src\BlazorIntWebAssemblyDemo -n BlazorIntWebAssemblyDemo -f net9.0 -lang C# -au None`

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
- [ ] **Utwórz komponent `RoutingDemo.razor`**
- [ ] **Implementuj następujące ścieżki:**
  - `/routing-demo` - strona główna
  - `/routing-demo/{id:int}` - parametr liczbowy
  - `/routing-demo/user/{name}` - parametr tekstowy
  - `/routing-demo/videos/{categoryId:int}/{videoId:int}` - multiple parametry
- [ ] **Dodaj obsługę Query Parameters**
  - `?firstName=Jan&lastName=Kowalski`
- [ ] **Utwórz osobny plik Code-Behind**
  - `RoutingDemo.razor.cs` z logiką routingu

---

## 3. Parametry komponentów

### Zadania:
- [ ] **Utwórz komponent `UserCard.razor`**
- [ ] **Dodaj parametry z walidacją:**
  - `Name` - wymagany parametr
  - `Age` - opcjonalny parametr
  - `Email` - z Query Parameter
- [ ] **Użyj atrybutów:**
  - `[EditorRequired]` dla wymaganego parametru
  - `[SupplyParameterFromQuery]` dla email

---

## 4. Dependency Injection

### Zadania:
- [ ] **Utwórz nowy projekt biblioteki klas `BlazorServices`**
- [ ] **Stwórz interfejs `IGreetingService`**
- [ ] **Implementuj serwisy:**
  - `TransientGreetingService` - nowa instancja przy każdym wywołaniu
  - `SingletonGreetingService` - jedna instancja dla całej aplikacji
  - `ScopedGreetingService` - jedna instancja per request
- [ ] **Zarejestruj serwisy w `Program.cs`**
- [ ] **Utwórz komponent `ServiceDemo.razor` używający wszystkich serwisów**

---

## 5. Komponenty generyczne

### Zadania:
- [ ] **Utwórz komponent `GenericList.razor`**
- [ ] **Dodaj parametr generyczny `@typeparam TItem`**
- [ ] **Implementuj wyświetlanie listy:**
  - Lista stringów
  - Lista liczb
  - Lista custom obiektów

---

## 6. Atrybuty komponentów

### Zadania:
- [ ] **Utwórz komponent z atrybutem `[Authorize]`**
- [ ] **Implementuj custom `RouteAttribute`**
- [ ] **Utwórz `MyButton.razor` z `CaptureUnmatchedValues`**
- [ ] **Przetestuj przekazywanie dodatkowych atrybutów HTML**

---

## 7. Zarządzanie importami

### Zadania:
- [ ] **Utwórz folder `Admin` w `Components`**
- [ ] **Dodaj `_Imports.razor` tylko dla folderu `Admin`**
- [ ] **Dodaj specyficzne importy dla komponentów administracyjnych**
- [ ] **Utwórz komponent `AdminPanel.razor` używający tych importów**

---

## 8. Custom Layout

### Zadania:
- [ ] **Utwórz `CustomLayout.razor`**
- [ ] **Implementuj niestandardowy layout z:**
  - Header
  - Sidebar
  - Main content area
  - Footer
- [ ] **Utwórz komponent używający tego layoutu**
- [ ] **Dodaj `_Imports.razor` dla layoutu**

---

## 9. Event Handling

### Zadania:
- [ ] **Utwórz `Counter.razor` z podstawowym onclick**
- [ ] **Implementuj `MyButton` z EventCallback**
- [ ] **Stwórz komponent `CounterWithButton` używający MyButton**
- [ ] **Dodaj invoke async event handling**

---

## 10. Data Binding

### Zadania:
- [ ] **Utwórz `DataBindingDemo.razor`**
- [ ] **Implementuj różne typy bindowania dla znaczników html oraz wbudowanych komponentów Razor np. 'InputTexxt':**
  - dwukierunkowe
  - jednokierunkowe
  - z custom eventem
- [ ] **Stwórz custom komponent z bindingiem**
- [ ] **Dodaj `Value`, `ValueChanged`, `ValueExpression`**

---

## 11. StateHasChanged i Lifecycle

### Zadania:
- [ ] **Utwórz `ClockComponent.razor`**
  - Wyświetl aktualny czas
  - Aktualizuj co sekundę
  - Użyj `StateHasChanged()`
- [ ] **W `MyButton.razor`**
  - Po kliknięciu staje się disabled na 2 sekundy
  - Automatycznie wraca do stanu aktywnego

---

## 12. Cascading Parameters

### Zadania:
- [ ] **Utwórz component CascadeDemo.razor'
- [ ] **Przekaż parametry bez cascade**
- [ ] **Utwórz model `UserContext`**
- [ ] **Implementuj `CascadingValue` w głównym komponencie**
- [ ] **Stwórz komponenty potomne używające `CascadingParameter`**
- [ ] **Przekaż parametr po typie i nazwie np. 'CParam'**
- [ ] **Porównaj wydajność z i bez `IsFixed="true"`**
- [ ] **Dodaj cascading parameter na poziomie root (Program.cs)**

---

## 13. Code-Behind Pattern

### Zadania:
- [ ] **Utwórz `ProductList.razor` i `ProductList.razor.cs`**
- [ ] **Przenieś całą logikę do pliku .cs**
- [ ] **Implementuj partial class**

---

