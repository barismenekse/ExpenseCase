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

```json
{
  "openapi": "3.0.1",
  "info": {
    "title": "ExpenseCase API",
    "version": "v1"
  },
  "paths": {
    "/Account/CreateAccount": {
      "post": {
        "tags": [
          "Account"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/CreateAccountDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Account/GetMyAccounts": {
      "get": {
        "tags": [
          "Account"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/AccountDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/AccountDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/AccountDto"
                  }
                }
              },
              "application/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/AccountDto"
                  }
                }
              },
              "text/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/AccountDto"
                  }
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Report/GetPeriodReport": {
      "get": {
        "tags": [
          "Report"
        ],
        "parameters": [
          {
            "name": "startDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "endDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/PeriodReportDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/PeriodReportDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/PeriodReportDto"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/PeriodReportDto"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/PeriodReportDto"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Report/GetMonthlyReport": {
      "get": {
        "tags": [
          "Report"
        ],
        "parameters": [
          {
            "name": "year",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "month",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/MonthlyReportDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/MonthlyReportDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/MonthlyReportDto"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/MonthlyReportDto"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/MonthlyReportDto"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Report/GetCategoryReport": {
      "get": {
        "tags": [
          "Report"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/CategoryReportDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/CategoryReportDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/CategoryReportDto"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/CategoryReportDto"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/CategoryReportDto"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Report/PredictCurrentMonthExpenses": {
      "get": {
        "tags": [
          "Report"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/PredictionReportDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/PredictionReportDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/PredictionReportDto"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/PredictionReportDto"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/PredictionReportDto"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Transaction/GetMyTransactions": {
      "get": {
        "tags": [
          "Transaction"
        ],
        "parameters": [
          {
            "name": "startDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "endDate",
            "in": "query",
            "style": "form",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/TransactionDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/TransactionDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/TransactionDto"
                  }
                }
              },
              "application/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/TransactionDto"
                  }
                }
              },
              "text/xml": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/TransactionDto"
                  }
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/Transaction/AddTransaction": {
      "post": {
        "tags": [
          "Transaction"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/AddTransactionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/TransactionDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/TransactionDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/TransactionDto"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/TransactionDto"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/TransactionDto"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/User/Register": {
      "post": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/RegisterRequestDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/User/Login": {
      "post": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json-patch+json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "application/xml": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "text/xml": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            },
            "application/*+xml": {
              "schema": {
                "$ref": "#/components/schemas/LoginRequestDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    },
    "/User/MyInfo": {
      "get": {
        "tags": [
          "User"
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "application/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              },
              "text/xml": {
                "schema": {
                  "$ref": "#/components/schemas/IResult"
                }
              }
            }
          }
        },
        "security": [
          {
            "Bearer": [ ]
          }
        ]
      }
    }
  },
  "components": {
    "schemas": {
      "AccountDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "balance": {
            "type": "number",
            "format": "double"
          },
          "createdDate": {
            "type": "string",
            "format": "date-time"
          },
          "transactions": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/TransactionDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "AddTransactionDto": {
        "type": "object",
        "properties": {
          "accountId": {
            "type": "integer",
            "format": "int32"
          },
          "categoryId": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "date": {
            "type": "string",
            "format": "date-time"
          }
        },
        "additionalProperties": false
      },
      "CategoryAmountDto": {
        "type": "object",
        "properties": {
          "categoryName": {
            "type": "string",
            "nullable": true
          },
          "totalAmount": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "CategoryDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CategoryPredictionDto": {
        "type": "object",
        "properties": {
          "categoryName": {
            "type": "string",
            "nullable": true
          },
          "predictedAmount": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "CategoryReportDto": {
        "type": "object",
        "properties": {
          "categoryAmounts": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/CategoryAmountDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CreateAccountDto": {
        "type": "object",
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "userId": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "IResult": {
        "type": "object",
        "additionalProperties": false
      },
      "LoginRequestDto": {
        "type": "object",
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "MonthlyReportDto": {
        "type": "object",
        "properties": {
          "month": {
            "type": "integer",
            "format": "int32"
          },
          "year": {
            "type": "integer",
            "format": "int32"
          },
          "income": {
            "type": "number",
            "format": "double"
          },
          "expense": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "PeriodReportDto": {
        "type": "object",
        "properties": {
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "totalIncome": {
            "type": "number",
            "format": "double"
          },
          "totalExpense": {
            "type": "number",
            "format": "double"
          }
        },
        "additionalProperties": false
      },
      "PredictionReportDto": {
        "type": "object",
        "properties": {
          "categoryPredictions": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/CategoryPredictionDto"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "RegisterRequestDto": {
        "type": "object",
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "TransactionDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "accountId": {
            "type": "integer",
            "format": "int32"
          },
          "categoryId": {
            "type": "integer",
            "format": "int32"
          },
          "amount": {
            "type": "number",
            "format": "double"
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "category": {
            "$ref": "#/components/schemas/CategoryDto"
          },
          "account": {
            "$ref": "#/components/schemas/AccountDto"
          }
        },
        "additionalProperties": false
      }
    },
    "securitySchemes": {
      "Bearer": {
        "type": "apiKey",
        "description": "Please enter a valid token",
        "name": "Authorization",
        "in": "header"
      }
    }
  }
}

