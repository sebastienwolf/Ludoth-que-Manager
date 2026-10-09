# Ludothèque Manager

Application de gestion du catalogue de jeux d'une ludothèque associative et de leur cycle de prêt.

```
Jeu disponible → Prêt à un adhérent → Jeu sorti → Retour → Contrôle de l'état → Disponible
```

Au retour, une observation peut être saisie (« Il manque un pion rouge », « Boîte abîmée »…).
L'historique des prêts et des observations est conservé.

## Stack

C# · .NET 10 · ASP.NET Core · Blazor · Entity Framework Core · SQL Server · xUnit

## Feuille de route

- [ ] **Étape 1** — C# et fonctionnement de .NET (application console)
- [ ] **Étape 2** — Modèle Jeu / Adhérent
- [ ] **Étape 3** — Entity Framework Core + base de données
- [ ] **Étape 4** — Gestion des prêts
- [ ] **Étape 5** — Interface Blazor
- [ ] **Étape 6** — Retours + observations
- [ ] **Étape 7** — Règles métier + validation
- [ ] **Étape 8** — Tests xUnit
- [ ] **Étape 9** — Refactoring / architecture
- [ ] Plus tard — Exemplaires multiples d'un même jeu, réservations, retards, tableau de bord, authentification

## Règles métier

- Un même exemplaire ne peut pas être prêté à deux personnes simultanément.
- Un adhérent désactivé ne peut plus emprunter.
- Un retour peut modifier l'état du jeu.
- Un jeu très endommagé devient indisponible, même après son retour.

## Lancer le projet

Prérequis : [SDK .NET 10](https://dotnet.microsoft.com/download)

```bash
dotnet build
dotnet run --project src/LudothequeManager
```
