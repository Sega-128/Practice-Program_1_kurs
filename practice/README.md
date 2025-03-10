# Завдання
## Клас `BankAccountClass`, що містить:
- **Поле** `Balance` (баланс рахунку).
- **Конструктор** для ініціалізації балансу.
- **Методи**:
  - `Deposit()`: додає суму до балансу.
  - `Withdraw()`: знімає суму, якщо вона доступна.
  - `Transfer(BankAccountClass to, decimal amount)`: переказує гроші на інший рахунок.

## Структура `BankAccountStruct`, що містить:
- **Поле** `Balance` (баланс рахунку).
- **Конструктор** для ініціалізації балансу.
- **Методи**:
  - `Deposit()`: 
  - `Withdraw()`:
  - `Transfer()` :

## Клас `AccountHelper` з методами:
- `PrintBalance(IBankAccount account)`: виводить баланс будь-якого рахунку.
- `TryDeposit(IBankAccount account, )`: пробує поповнити рахунок.

## Інтерфейс `IBankAccount`, який реалізують і клас, і структура, що містить:
- `decimal Balance { get; }`
- `void Deposit()`
- `void Withdraw()`
