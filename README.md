# SQL Tablo Diyagramları ve İlişkiler


## Tablo Diyagramları

### Category
| Sütun      | Açıklama  |
|------------|-----------|
| `Id`        | PK        |
| `Name`      |           |

### User
| Sütun         | Açıklama  |
|---------------|-----------|
| `Id`          | PK        |
| `Name`        |           |
| `PasswordHash`|           |
| `Email`       |           |
| `CreatedDate` |           |

### Account
| Sütun         | Açıklama                |
|---------------|--------------------------|
| `Id`          | PK                       |
| `UserId`      | FK -> User(Id)           |
| `Name`        |                          |
| `Balance`     |                          |
| `CreatedDate` |                          |

### Transaction
| Sütun         | Açıklama                   |
|---------------|-----------------------------|
| `Id`          | PK                          |
| `AccountId`   | FK -> Account(Id)           |
| `Amount`      |                             |
| `CategoryId`  | FK -> Category(Id)          |
| `Description` |                             |
| `Date`        |                             |

## İndeksler

- `IX_Account_UserId` on `Account(UserId)`
- `IX_Transaction_AccountId` on `Transaction(AccountId)`
- `IX_Transaction_CategoryId` on `Transaction(CategoryId)`

## Açıklamalar

- **PK:** Primary Key (Birincil Anahtar)
- **FK:** Foreign Key (Yabancı Anahtar)

# Swagger
![image](https://github.com/user-attachments/assets/883dfbe3-cbe5-4b9b-b1d2-73c63b193f9b)
